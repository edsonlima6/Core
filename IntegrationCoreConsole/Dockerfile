FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY Directory.Packages.props ./
COPY Domain/Domain.csproj Domain/
COPY InfraCoreEF/InfraCoreEF.csproj InfraCoreEF/
COPY InfraCoreDapper/InfraCoreDapper.csproj InfraCoreDapper/
COPY Application/Application.csproj Application/
COPY Infra.IoC/Infra.IoC.csproj Infra.IoC/
COPY IntegrationCoreConsole/IntegrationCoreConsole.csproj IntegrationCoreConsole/

RUN dotnet restore IntegrationCoreConsole/IntegrationCoreConsole.csproj

COPY . .
RUN dotnet publish IntegrationCoreConsole/IntegrationCoreConsole.csproj \
    --configuration Release \
    --output /app/publish \
    --no-restore \
    /p:UseAppHost=false

FROM runtime AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "IntegrationCoreConsole.dll"]
