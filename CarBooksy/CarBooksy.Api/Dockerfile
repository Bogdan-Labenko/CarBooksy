FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CarBooksy.Api/CarBooksy.Api.csproj", "CarBooksy.Api/"]
COPY ["CarBooksy.Application/CarBooksy.Application.csproj", "CarBooksy.Application/"]
COPY ["CarBooksy.Domain/CarBooksy.Domain.csproj", "CarBooksy.Domain/"]
COPY ["CarBooksy.Shared/CarBooksy.Shared.csproj", "CarBooksy.Shared/"]
COPY ["CarBooksy.Persistance/CarBooksy.Persistance.csproj", "CarBooksy.Persistance/"]
RUN dotnet restore "CarBooksy.Api/CarBooksy.Api.csproj"
COPY . .
WORKDIR "/src/CarBooksy.Api"
RUN dotnet build "CarBooksy.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CarBooksy.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarBooksy.Api.dll"]
