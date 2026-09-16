# SkynetProductsApi Docker Workflow & Azure Container Registry Guide

This reference document details the architecture, Docker configuration, Azure Container Registry (ACR) integration, and troubleshooting procedures for containerizing the `SkynetProductsApi` service.

---

## 1. Docker Build Context Architecture

`SkynetProductsApi/Dockerfile` is a multi-stage Dockerfile targeting .NET 10.

- **SDK Build Stage**: `mcr.microsoft.com/dotnet/sdk:10.0`
  - Restores packages centrally via `Directory.Packages.props` and `Core.sln`.
  - Publishes `SkynetProductsApi.csproj` in `Release` mode with `/p:UseAppHost=false`.
- **Runtime Stage**: `mcr.microsoft.com/dotnet/aspnet:10.0`
  - Copies published DLLs from the build stage into `/app`.
  - Configures `ASPNETCORE_URLS=http://+:80` and exposes port 80.
  - Sets entrypoint: `["dotnet", "SkynetProductsApi.dll"]`.

### Build Context Rule

Always execute the build command from the **solution root**, never from inside the `SkynetProductsApi` subdirectory:

```bash
# Correct:
cd /path/to/Core
docker build -f SkynetProductsApi/Dockerfile -t SkynetProductsApi:v0.0.1 .

# Incorrect (will fail to find Directory.Packages.props and sibling projects):
cd /path/to/Core/SkynetProductsApi
docker build .
```

---

## 2. Docker Tagging & Azure Container Registry (ACR)

### Registry Information
- **Registry Name**: `skynetapibart`
- **Login Server**: `skynetapibart.azurecr.io`
- **Azure Subscription**: `Pay-As-You-Go`
- **Resource Group**: `grp-warehouse-product-dev`

### Docker Tag Syntax and Restrictions

Under the Open Container Initiative (OCI) and Docker reference grammar:
```
[domain '/'] path-component ['/' path-component]* [':' tag]
```

- A tag follows a **single colon (`:`)**.
- A tag can only contain alphanumeric characters, underscores (`_`), periods (`.`), and hyphens (`-`).
- **A tag cannot contain a colon (`:`)**.

Therefore:
- `skynetapibart.azurecr.io/skynetproductsapi:dev:v0.0.2` ❌ (*Invalid syntax: two colons - triggers "invalid reference format" error*)
- `skynetapibart.azurecr.io/skynetproductsapi:dev-v0.0.2`  (*Valid: repository `skynetproductsapi`, combined tag `dev-v0.0.2`*)
- `skynetapibart.azurecr.io/skynetproductsapi/dev:v0.0.2`  (*Valid: repository path `skynetproductsapi/dev`, tag `v0.0.2`*)
- `skynetapibart.azurecr.io/skynetproductsapi/skynetproductsapi:v0.0.2`  (*Valid: repository path `skynetapibart/skynetproductsapi`, tag `v0.0.2`*)
- `skynetapibart.azurecr.io/skynetproductsapi:v0.0.2`  (*Valid: repository `skynetproductsapi`, tag `v0.0.2`*)

### Pushing to Azure Container Registry

To push images to ACR:

```bash
# 1. Authenticate with Azure Container Registry
az acr login --name skynetapibart

# 2. Push the tagged image
docker push skynetapibart.azurecr.io/skynetproductsapi:dev-v0.0.1
```

---

## 3. Container Runtime Configuration

### Port Mapping
The container listens on port 80. To expose it locally on port 5000:
`-p 5000:80`

### Environment Variables
Common environment variables to configure when running the container:
- `ASPNETCORE_ENVIRONMENT`: `Development` (enables Swagger UI at `/swagger`) or `Production`.
- `ConnectionStrings__connectionStringLinux`: SQL Server connection string accessible from Linux container network.
- `RabbitMQ__HostName`: RabbitMQ broker host.

Example with environment variables:
```bash
docker run -d \
  --name SkynetProductsApi \
  -p 5000:80 \
  -e ASPNETCORE_ENVIRONMENT=Development \
  -e RabbitMQ__HostName=host.docker.internal \
  skynetapibart.azurecr.io/skynetproductsapi:dev-v0.0.2
```

---

## 4. Useful Management Commands

```bash
# Inspect container health & status
docker ps --filter "name=SkynetProductsApi"

# View logs in real-time
docker logs -f SkynetProductsApi

# Stop and remove container
docker stop SkynetProductsApi
docker rm SkynetProductsApi

# Open interactive shell inside container
docker exec -it SkynetProductsApi /bin/sh
```
