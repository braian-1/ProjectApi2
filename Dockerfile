FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["apiWeb.Api/apiWeb.Api.csproj", "apiWeb.Api/"]
COPY ["apiWeb.Application/apiWeb.Application.csproj", "apiWeb.Application/"]
COPY ["apiWeb.Domain/apiWeb.Domain.csproj", "apiWeb.Domain/"]
COPY ["apiWeb.Infrastructure/apiWeb.Infrastructure.csproj", "apiWeb.Infrastructure/"]
RUN dotnet restore "apiWeb.Api/apiWeb.Api.csproj"
COPY . .
WORKDIR "/src/apiWeb.Api"
RUN dotnet build "./apiWeb.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./apiWeb.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "apiWeb.Api.dll"]

#docker build -t miapi:1.0 -f apiWeb.Api/Dockerfile . && \
#docker run -d -p 8080:80 --name miapi-contenedor miapi:1.0
