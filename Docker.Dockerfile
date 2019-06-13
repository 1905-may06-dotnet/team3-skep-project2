FROM mcr.microsoft.com/dotnet/core/sdk:2.2-bionic AS buildDomain

WORKDIR /team3-skep-project2

COPY Domain/ ../Domain
RUN dotnet restore ../Domain/*.csproj --no-dependencies
RUN dotnet build ../Domain/*.csproj --no-restore -c Release
RUN ls ../team3-skep-project2

#####

FROM mcr.microsoft.com/dotnet/core.sdk:2.2-bionic AS buildData

WORKDIR /team3-skep-project2

COPY Data/ ../Data
COPY --from=buildDomain ./Domain/ ../Domain
RUN dotnet restore ../Data/*.csproj --no-dependencies
RUN dotnet build ../Data/*.csproj --no-restore -c Release

#####

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-bionic AS buildWeb

WORKDIR /team3-skep-project2

COPY web/ ../web
COPY --from=buildDomain ./Domain/ ../Domain
COPY --from=buildData ./Data/ ../Data
RUN dotnet restore ../web/*.csproj --no-dependencies
RUN dotnet publish ../web/*.csproj --no-build -c Release -o out
RUN dotnet build ../web/web.csproj --no-restore -c Release

#####

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-bionic AS deploy

WORKDIR /team3-skep-project2

EXPOSE 80
EXPOSE 443

COPY --from=buildWeb web/out ./
ENV ASPNETCORE_URLS="https://+:443"
#ENV ASPNETCORE_Kestrel__Certificates__Default__Password=""
#ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/aspnetapp.pfx

CMD [ "dotnet", "web.dll"]

