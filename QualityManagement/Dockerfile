FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
WORKDIR /app
EXPOSE 80

COPY . .
ENTRYPOINT ["dotnet", "QualityManagement.API.dll"]