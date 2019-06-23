FROM mcr.microsoft.com/dotnet/core/sdk:2.2-bionic AS buildDomain

WORKDIR /team3-skep-project2

COPY Domain/ ../Domain
RUN dotnet restore ../Domain/*.csproj --no-dependencies
RUN dotnet build ../Domain/*.csproj --no-restore -c Release
RUN ls ../team3-skep-project2

#####

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-bionic AS buildData

WORKDIR /team3-skep-project2

COPY Data/ ../Data
COPY --from=buildDomain ./Domain/ ../Domain
RUN dotnet restore ../Data/*.csproj --no-dependencies
RUN dotnet build ../Data/*.csproj --no-restore -c Release

#####

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-bionic AS buildWeb

WORKDIR /team3-skep-project2

COPY webapi/ ../webapi
COPY --from=buildDomain ./Domain/ ../Domain
COPY --from=buildData ./Data/ ../Data
RUN dotnet restore ../webapi/*.csproj --no-dependencies
RUN dotnet build ../webapi/*.csproj --no-restore -c Release
RUN dotnet publish ../webapi/*.csproj --no-build -c Release -o out

#####
FROM mcr.microsoft.com/dotnet/core/sdk:2.2-bionic AS test

WORKDIR /team3-skep-project2

COPY Test/ ../Test
COPY --from=buildDomain ./Domain/ ../Domain
COPY --from=buildData ./Data/ ../Data
COPY --from=buildWeb ./webapi/ ../webapi
ARG CACHEBUST=1
RUN dotnet test ../Test/*.csproj /p:CollectCoverage=true 


FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-bionic AS deploy

WORKDIR /team3-skep-project2

EXPOSE 80
EXPOSE 443

COPY --from=buildWeb webapi/out ./
ENV ASPNETCORE_URLS="http://+:80"
#ENV ASPNETCORE_Kestrel__Certificates__Default__Password=""
#ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/aspnetapp.pfx

CMD [ "dotnet", "webapi.dll"]

