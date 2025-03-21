FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY EventfulPeace.sln .
COPY ["EventfulPeace.Domain/EventfulPeace.Domain.csproj", "EventfulPeace.Domain/"]
COPY ["EventfulPeace.Persistence/EventfulPeace.Persistence.csproj", "EventfulPeace.Persistence/"]
COPY ["EventfulPeace.Identity/EventfulPeace.Identity.csproj", "EventfulPeace.Identity/"]
COPY ["EventfulPeace.Application/EventfulPeace.Application.csproj", "EventfulPeace.Application/"]
COPY ["EventfulPeace.Web/EventfulPeace.Web.csproj", "EventfulPeace.Web/"]
RUN dotnet restore
COPY . .
RUN dotnet build -c $BUILD_CONFIGURATION

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventfulPeace.Web.dll"]