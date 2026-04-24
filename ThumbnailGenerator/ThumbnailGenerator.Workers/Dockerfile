# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
USER $APP_UID
WORKDIR /app


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ThumbnailGenerator/ThumbnailGenerator.Workers/ThumbnailGenerator.Workers.csproj", "ThumbnailGenerator/ThumbnailGenerator.Workers/"]
COPY ["Shared/Shared.csproj", "Shared/"]
COPY ["Media.Models/Media.Models.csproj", "Media.Models/"]
COPY ["ThumbnailGenerator/ThumbnailGenerator.Application/ThumbnailGenerator.Application.csproj", "ThumbnailGenerator/ThumbnailGenerator.Application/"]
COPY ["ThumbnailGenerator/ThumbnailGenerator.Infrastructure/ThumbnailGenerator.Infrastructure.csproj", "ThumbnailGenerator/ThumbnailGenerator.Infrastructure/"]
RUN dotnet restore "./ThumbnailGenerator/ThumbnailGenerator.Workers/ThumbnailGenerator.Workers.csproj"
COPY . .
WORKDIR "/src/ThumbnailGenerator/ThumbnailGenerator.Workers"
RUN dotnet build "./ThumbnailGenerator.Workers.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ThumbnailGenerator.Workers.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ThumbnailGenerator.Workers.dll"]