#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 44301
EXPOSE 44302

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1903 AS build
WORKDIR /src
COPY ["NetDocsCore2_1/NetDocsCore2_1.csproj", "NetDocsCore2_1/"]
COPY ["Infra/Infra.csproj", "Infra/"]
COPY ["MyBI.Domain1/MyBI.Domain1.csproj", "MyBI.Domain1/"]
COPY ["Infra.CrossCutting2/Infra.CrossCutting2.csproj", "Infra.CrossCutting2/"]
COPY ["MyBI.Application1/MyBI.Application1.csproj", "MyBI.Application1/"]
RUN dotnet restore "NetDocsCore2_1/NetDocsCore2_1.csproj"
COPY . .
WORKDIR "/src/NetDocsCore2_1"
RUN dotnet build "NetDocsCore2_1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetDocsCore2_1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetDocsCore2_1.dll"]