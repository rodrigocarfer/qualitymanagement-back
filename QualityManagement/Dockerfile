FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src

COPY ["QualityManagement.API/QualityManagement.API.csproj", "QualityManagement.API/"]
COPY ["QualityManagement.Business/QualityManagement.Business.csproj", "QualityManagement.Business/"]
COPY ["QualityManagement.Frontier.Business/QualityManagement.Frontier.Business.csproj", "QualityManagement.Frontier.Business/"]
COPY ["QualityManagement.Frontier.Repository/QualityManagement.Frontier.Repository.csproj", "QualityManagement.Frontier.Repository/"]
COPY ["QualityManagement.Service/QualityManagement.Service.csproj", "QualityManagement.Service/"]
COPY ["QualityManagement.Map/QualityManagement.Map.csproj", "QualityManagement.Map/"]
COPY ["QualityManagement.Repository/QualityManagement.Repository.csproj", "QualityManagement.Repository/"]
COPY ["QualityManagement.Util/QualityManagement.Util.csproj", "QualityManagement.Util/"]

RUN dotnet restore "QualityManagement.API/QualityManagement.API.csproj"
COPY . .
WORKDIR "/src/QualityManagement.API"
RUN dotnet build "QualityManagement.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QualityManagement.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QualityManagement.API.dll"]