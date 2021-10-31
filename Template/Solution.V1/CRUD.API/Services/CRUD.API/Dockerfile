FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
COPY bin/Release/netcoreapp3.1/ PhotoPrint.API/
WORKDIR /PhotoPrint.API
ENV ASPNETCORE_URLS=http://+:8082
ENTRYPOINT ["dotnet", "PhotoPrint.API.dll"]