FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE  5000
EXPOSE  5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/AppMicroServiceProduct.WebApi/AppMicroServiceProduct.WebApi.csproj", "src/AppMicroServiceProduct.WebApi/"]
COPY ["src/AppMicroServiceProduct.Application/AppMicroServiceProduct.Application.csproj", "src/AppMicroServiceProduct.Application/"]
COPY ["src/AppMicroServiceProduct.Domain/AppMicroServiceProduct.Domain.csproj", "src/AppMicroServiceProduct.Domain/"]
COPY ["src/AppMicroServiceProduct.Infrastructure/AppMicroServiceProduct.Infrastructure.csproj", "src/AppMicroServiceProduct.Infrastructure/"]
RUN dotnet restore "src/AppMicroServiceProduct.WebApi/AppMicroServiceProduct.WebApi.csproj"
COPY . .
WORKDIR "/src/src/AppMicroServiceProduct.WebApi"
RUN dotnet build "AppMicroServiceProduct.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AppMicroServiceProduct.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppMicroServiceProduct.WebApi.dll"]