FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["gestaoqualidade.API.csproj", ""]
RUN dotnet restore "./gestaoqualidade.API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "gestaoqualidade.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "gestaoqualidade.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "gestaoqualidade.API.dll"]