FROM mcr.microsoft.com/dotnet/core/aspnet:2.2

# copy files into the image
COPY out/ /team3-skep-project2

CMD ["dotnet", "/team3-skep-project2/mySkepProj.dll"]
