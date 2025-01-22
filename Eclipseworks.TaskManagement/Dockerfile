# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Eclipseworks.TaskManagement/Eclipseworks.TaskManagement.csproj", "Eclipseworks.TaskManagement/"]
COPY ["Eclipseworks.TaskManagement.Core.Application/Eclipseworks.TaskManagement.Core.Application.csproj", "Eclipseworks.TaskManagement.Core.Application/"]
COPY ["Eclipseworks.TaskManagement.Core.Domains/Eclipseworks.TaskManagement.Core.Domains.csproj", "Eclipseworks.TaskManagement.Core.Domains/"]
COPY ["Eclipseworks.TaskManagement.Infraestruture.Persistence/Eclipseworks.TaskManagement.Infraestruture.Persistence.csproj", "Eclipseworks.TaskManagement.Infraestruture.Persistence/"]
RUN dotnet restore "./Eclipseworks.TaskManagement/Eclipseworks.TaskManagement.csproj"
COPY . .
WORKDIR "/src/Eclipseworks.TaskManagement"
RUN dotnet build "./Eclipseworks.TaskManagement.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Eclipseworks.TaskManagement.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Eclipseworks.TaskManagement.dll"]