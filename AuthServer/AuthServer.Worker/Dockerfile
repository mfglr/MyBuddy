# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AuthServer/AuthServer.Worker/AuthServer.Worker.csproj", "AuthServer/AuthServer.Worker/"]
COPY ["AuthServer/AuthServer.Application/AuthServer.Application.csproj", "AuthServer/AuthServer.Application/"]
COPY ["Shared/Shared.csproj", "Shared/"]
COPY ["Media.Models/Media.Models.csproj", "Media.Models/"]
COPY ["AuthServer/AuthServer.Domain/AuthServer.Domain.csproj", "AuthServer/AuthServer.Domain/"]
COPY ["AuthServer/AuthServer.Infrastructure/AuthServer.Infrastructure.csproj", "AuthServer/AuthServer.Infrastructure/"]
RUN dotnet restore "./AuthServer/AuthServer.Worker/AuthServer.Worker.csproj"
COPY . .
WORKDIR "/src/AuthServer/AuthServer.Worker"
RUN dotnet build "./AuthServer.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AuthServer.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthServer.Worker.dll"]