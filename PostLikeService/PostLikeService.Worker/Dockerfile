# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
USER $APP_UID
WORKDIR /app


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PostLikeService/PostLikeService.Worker/PostLikeService.Worker.csproj", "PostLikeService/PostLikeService.Worker/"]
COPY ["PostLikeService/PostLikeService.Application/PostLikeService.Application.csproj", "PostLikeService/PostLikeService.Application/"]
COPY ["Shared/Shared.csproj", "Shared/"]
COPY ["Media.Models/Media.Models.csproj", "Media.Models/"]
COPY ["PostLikeService/PostLikeService.Domain/PostLikeService.Domain.csproj", "PostLikeService/PostLikeService.Domain/"]
COPY ["PostLikeService/PostLikeService.Infrastructure/PostLikeService.Infrastructure.csproj", "PostLikeService/PostLikeService.Infrastructure/"]
RUN dotnet restore "./PostLikeService/PostLikeService.Worker/PostLikeService.Worker.csproj"
COPY . .
WORKDIR "/src/PostLikeService/PostLikeService.Worker"
RUN dotnet build "./PostLikeService.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PostLikeService.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PostLikeService.Worker.dll"]