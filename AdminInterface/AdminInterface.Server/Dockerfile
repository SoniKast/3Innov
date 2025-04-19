# Start from the .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Install Node.js (LTS version)
RUN apt-get update && apt-get install -y \
    curl && \
    curl -fsSL https://deb.nodesource.com/setup_18.x | bash - && \
    apt-get install -y nodejs

# Rest of your build steps
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AdminInterface/AdminInterface.Server/AdminInterface.Server.csproj", "AdminInterface/AdminInterface.Server/"]
COPY ["AdminInterface/admininterface.client/admininterface.client.esproj", "AdminInterface/admininterface.client/"]
RUN dotnet restore "./AdminInterface/AdminInterface.Server/AdminInterface.Server.csproj"
COPY . .
WORKDIR "/src/AdminInterface/AdminInterface.Server"
RUN dotnet build "./AdminInterface.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the project
FROM build AS publish
RUN dotnet publish "./AdminInterface.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final image (production-ready)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdminInterface.Server.dll"]
