#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SkyNetAPI/SkyNetAPI.csproj", "SkyNetAPI/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["InfraCoreEF/InfraCoreEF.csproj", "InfraCoreEF/"]
COPY ["InfraCoreDapper/InfraCoreDapper.csproj", "InfraCoreDapper/"]
COPY ["Infra.IoC/Infra.IoC.csproj", "Infra.IoC/"]
COPY ["InfraCoreSQLite/InfraCoreSQLite.csproj", "InfraCoreSQLite/"]
RUN dotnet restore "SkyNetAPI/SkyNetAPI.csproj"
COPY . .
WORKDIR "/src/SkyNetAPI"
RUN dotnet build "SkyNetAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SkyNetAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SkyNetAPI.dll"]