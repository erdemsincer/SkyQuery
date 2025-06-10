FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Projeleri kopyala
COPY ["src/Services/GeoData/SkyQuery.GeoData.API/SkyQuery.GeoData.API.csproj", "SkyQuery.GeoData.API/"]
COPY ["src/Services/GeoData/SkyQuery.GeoData.Application/SkyQuery.GeoData.Application.csproj", "SkyQuery.GeoData.Application/"]
COPY ["src/Services/GeoData/SkyQuery.GeoData.Infrastructure/SkyQuery.GeoData.Infrastructure.csproj", "SkyQuery.GeoData.Infrastructure/"]
COPY ["src/Services/GeoData/SkyQuery.GeoData.Domain/SkyQuery.GeoData.Domain.csproj", "SkyQuery.GeoData.Domain/"]

# Restore
RUN dotnet restore "SkyQuery.GeoData.API/SkyQuery.GeoData.API.csproj"

# Diðer tüm dosyalarý kopyala
COPY src/Services/GeoData/SkyQuery.GeoData.API/ SkyQuery.GeoData.API/
COPY src/Services/GeoData/SkyQuery.GeoData.Application/ SkyQuery.GeoData.Application/
COPY src/Services/GeoData/SkyQuery.GeoData.Infrastructure/ SkyQuery.GeoData.Infrastructure/
COPY src/Services/GeoData/SkyQuery.GeoData.Domain/ SkyQuery.GeoData.Domain/

WORKDIR /src/SkyQuery.GeoData.API
RUN dotnet publish "SkyQuery.GeoData.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SkyQuery.GeoData.API.dll"]
