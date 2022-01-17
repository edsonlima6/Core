#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#FROM mcr.microsoft.com/mssql/server:2019-CU14-ubuntu-20.04 AS sql
#RUN docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=I10easttoLA" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-CU14-ubuntu-20.04

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80



FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SkyNetApiCore/SkyNetApiCore.csproj", "SkyNetApiCore/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["InfraCoreEF/InfraCoreEF.csproj", "InfraCoreEF/"]
COPY ["Infra.IoC/Infra.IoC.csproj", "Infra.IoC/"]
COPY ["Application/Application.csproj", "Application/"]

RUN dotnet restore "SkyNetApiCore/SkyNetApiCore.csproj"
COPY . .
WORKDIR "/src/SkyNetApiCore"
RUN dotnet build "SkyNetApiCore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SkyNetApiCore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SkyNetApiCore.dll"]