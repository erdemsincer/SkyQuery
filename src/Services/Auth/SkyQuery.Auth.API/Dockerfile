FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["src/Services/Auth/SkyQuery.Auth.API/SkyQuery.Auth.API.csproj", "SkyQuery.Auth.API/"]
COPY ["src/Services/Auth/SkyQuery.Auth.Application/SkyQuery.Auth.Application.csproj", "SkyQuery.Auth.Application/"]
COPY ["src/Services/Auth/SkyQuery.Auth.Infrastructure/SkyQuery.Auth.Infrastructure.csproj", "SkyQuery.Auth.Infrastructure/"]
COPY ["src/Services/Auth/SkyQuery.Auth.Domain/SkyQuery.Auth.Domain.csproj", "SkyQuery.Auth.Domain/"]
COPY ["src/Services/Auth/SkyQuery.Auth.Contracts/SkyQuery.Auth.Contracts.csproj", "SkyQuery.Auth.Contracts/"]

RUN dotnet restore "SkyQuery.Auth.API/SkyQuery.Auth.API.csproj"

COPY src/Services/Auth/SkyQuery.Auth.API/ SkyQuery.Auth.API/
COPY src/Services/Auth/SkyQuery.Auth.Application/ SkyQuery.Auth.Application/
COPY src/Services/Auth/SkyQuery.Auth.Infrastructure/ SkyQuery.Auth.Infrastructure/
COPY src/Services/Auth/SkyQuery.Auth.Domain/ SkyQuery.Auth.Domain/
COPY src/Services/Auth/SkyQuery.Auth.Contracts/ SkyQuery.Auth.Contracts/

WORKDIR /src/SkyQuery.Auth.API
RUN dotnet publish "SkyQuery.Auth.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SkyQuery.Auth.API.dll"]
