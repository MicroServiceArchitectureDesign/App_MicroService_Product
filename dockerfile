FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["App_MicroService_BuildingBlock/src/AppMicroServiceBuildingBlock.Contract/AppMicroServiceBuildingBlock.Contract.csproj", "App_MicroService_BuildingBlock/src/AppMicroServiceBuildingBlock.Contract/"]
COPY ["App_MicroService_BuildingBlock/src/AppMicroServiceBuildingBlock.Shared/AppMicroServiceBuildingBlock.Shared.csproj", "App_MicroService_BuildingBlock/src/AppMicroServiceBuildingBlock.Shared/"]

COPY ["src/AppMicroServiceProduct.WebApi/AppMicroServiceProduct.WebApi.csproj", "src/AppMicroServiceProduct.WebApi/"]
COPY ["src/AppMicroServiceProduct.Infrastructure/AppMicroServiceProduct.Infrastructure.csproj", "src/AppMicroServiceProduct.Infrastructure/"]
COPY ["src/AppMicroServiceProduct.Application/AppMicroServiceProduct.Application.csproj", "src/AppMicroServiceProduct.Application/"]
COPY ["src/AppMicroServiceProduct.Domain/AppMicroServiceProduct.Domain.csproj", "src/AppMicroServiceProduct.Domain/"]
RUN dotnet restore "./src/AppMicroServiceProduct.WebApi/AppMicroServiceProduct.WebApi.csproj"
COPY . .
WORKDIR "/src/src/AppMicroServiceProduct.WebApi"
RUN dotnet build "./AppMicroServiceProduct.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AppMicroServiceProduct.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppMicroServiceProduct.WebApi.dll"]