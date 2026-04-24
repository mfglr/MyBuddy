# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PostService/src/PostService.Api/PostService.Api.csproj", "PostService/src/PostService.Api/"]
COPY ["PostService/src/PostService.Application/PostService.Application.csproj", "PostService/src/PostService.Application/"]
COPY ["PostService/src/PostService.Domain/PostService.Domain.csproj", "PostService/src/PostService.Domain/"]
COPY ["Shared/Shared.csproj", "Shared/"]
COPY ["Media.Models/Media.Models.csproj", "Media.Models/"]
COPY ["PostService/src/PostService.Infrastructure/PostService.Infrastructure.csproj", "PostService/src/PostService.Infrastructure/"]
RUN dotnet restore "./PostService/src/PostService.Api/PostService.Api.csproj"
COPY . .
WORKDIR "/src/PostService/src/PostService.Api"
RUN dotnet build "./PostService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PostService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PostService.Api.dll"]