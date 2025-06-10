FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["src/Services/Location/SkyQuery.Location.API/SkyQuery.Location.API.csproj", "SkyQuery.Location.API/"]
COPY ["src/Services/Location/SkyQuery.Location.Application/SkyQuery.Location.Application.csproj", "SkyQuery.Location.Application/"]
COPY ["src/Services/Location/SkyQuery.Location.Infrastructure/SkyQuery.Location.Infrastructure.csproj", "SkyQuery.Location.Infrastructure/"]
COPY ["src/Services/Location/SkyQuery.Location.Domain/SkyQuery.Location.Domain.csproj", "SkyQuery.Location.Domain/"]

RUN dotnet restore "SkyQuery.Location.API/SkyQuery.Location.API.csproj"

COPY src/Services/Location/SkyQuery.Location.API/ SkyQuery.Location.API/
COPY src/Services/Location/SkyQuery.Location.Application/ SkyQuery.Location.Application/
COPY src/Services/Location/SkyQuery.Location.Infrastructure/ SkyQuery.Location.Infrastructure/
COPY src/Services/Location/SkyQuery.Location.Domain/ SkyQuery.Location.Domain/

WORKDIR /src/SkyQuery.Location.API
RUN dotnet publish "SkyQuery.Location.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SkyQuery.Location.API.dll"]
