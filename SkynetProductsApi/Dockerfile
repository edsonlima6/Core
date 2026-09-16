FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY ["SkynetProductsApi/SkynetProductsApi.csproj", "SkynetProductsApi/"]
RUN dotnet restore "SkynetProductsApi/SkynetProductsApi.csproj"

# Copy everything else and build
COPY . .
RUN dotnet publish "SkynetProductsApi/SkynetProductsApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./

# Bind to port 80 inside the container
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "SkynetProductsApi.dll"]
