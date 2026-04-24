# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
USER $APP_UID
WORKDIR /app


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PostQueryService/PostQueryService.Worker/PostQueryService.Worker.csproj", "PostQueryService/PostQueryService.Worker/"]
COPY ["Shared/Shared.csproj", "Shared/"]
COPY ["Media.Models/Media.Models.csproj", "Media.Models/"]
COPY ["PostQueryService/PostQueryService.Application/PostQueryService.Application.csproj", "PostQueryService/PostQueryService.Application/"]
COPY ["PostQueryService/PostQueryService.Domain/PostQueryService.Domain.csproj", "PostQueryService/PostQueryService.Domain/"]
COPY ["PostQueryService/PostQueryService.Infrastructure/PostQueryService.Infrastructure.csproj", "PostQueryService/PostQueryService.Infrastructure/"]
RUN dotnet restore "./PostQueryService/PostQueryService.Worker/PostQueryService.Worker.csproj"
COPY . .
WORKDIR "/src/PostQueryService/PostQueryService.Worker"
RUN dotnet build "./PostQueryService.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PostQueryService.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PostQueryService.Worker.dll"]