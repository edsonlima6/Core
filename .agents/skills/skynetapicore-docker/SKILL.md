--
name: skynetapicore-docker
description: >-
  Builds the SkyNetApiCore .NET project, creates a Docker container image using the Dockerfile,
  tags it for Azure Container Registry (skynetapibart.azurecr.io), and creates and runs the container.
  Use this skill whenever the user asks to build, package, dockerize, tag, or run SkyNetApiCore in Docker.
---

# SkyNetApiCore Docker Build & Run Skill

This skill guides the agent through building the `SkyNetApiCore` web API, creating a Docker image using `SkyNetApiCore/Dockerfile`, tagging the image for Azure Container Registry (`skynetapibart.azurecr.io`), and running a local container instance.

---

## Quick Execution & Automatic Versioning

The skill includes built-in automatic semantic versioning tracked in [.agents/skills/skynetapicore-docker/VERSION](./VERSION). Each execution automatically increments the patch version (e.g., `v0.0.2` -> `v0.0.3` -> `v0.0.4`), builds the Docker image, tags it, and runs the container.

- **Standard Run (auto-increments patch version)**:
  - **Windows (PowerShell)**:
    ```powershell
    pwsh .agents/skills/skynetapicore-docker/scripts/build-and-run.ps1
    ```
  - **Linux / WSL (Bash)**:
    ```bash
    bash .agents/skills/skynetapicore-docker/scripts/build-and-run.sh
    ```

- **Advanced Options (PowerShell)**:
  ```powershell
  # Rebuild without incrementing version
  pwsh .agents/skills/skynetapicore-docker/scripts/build-and-run.ps1 -NoBump

  # Bump minor (e.g. 0.0.3 -> 0.1.0) or major (0.0.3 -> 1.0.0)
  pwsh .agents/skills/skynetapicore-docker/scripts/build-and-run.ps1 -Bump minor

  # Specify an exact version
  pwsh .agents/skills/skynetapicore-docker/scripts/build-and-run.ps1 -Version 0.1.0
  ```

---

## Detailed Step-by-Step Procedure

### 1. Build the .NET Project Locally (Pre-check)

Verify that the solution and `SkyNetApiCore` compile without errors before creating the container:

```bash
dotnet build SkyNetApiCore/SkyNetApiCore.csproj -c Release
```

Ensure the build output reports `0 Error(s)`.

---

### 2. Build the Docker Image

> [!IMPORTANT]
> The Docker build context **must** be the repository root (`.`), because `SkyNetApiCore/Dockerfile` references `Directory.Packages.props`, `Core.sln`, and sibling project directories (`Application`, `Domain`, `Infra.IoC`, `InfraCoreEF`, etc.).

Run from the root directory:

```bash
docker build -f SkyNetApiCore/Dockerfile -t skynetapicore:v0.0.2 .
```

---

### 3. Tag the Image for Azure Container Registry (ACR)

Docker/OCI reference grammar dictates:
`[REGISTRY_HOST/][REPOSITORY_PATH:]TAG`

A Docker tag cannot contain multiple colons (`:`). If given `skynetapibart.azurecr.io/skynetapibart:dev:v0.0.2`, Docker CLI will return an `invalid reference format` error.

Use one of the standard valid tag formats:

| Format Type | Tag Syntax | Description |
| :--- 		  | :--- 	   | :--- 		 |
| **Combined Tag (Recommended)** | `skynetapibart.azurecr.io/skynetapibart:dev-v0.0.2` | Uses repo `skynetapibart` with combined tag `dev-v0.0.2` |
| **Nested Repository** | `skynetapibart.azurecr.io/skynetapibart/dev:v0.0.2` | Namespaces repo as `skynetapibart/dev` with tag `v0.0.2` |
| **Service Repository** | `skynetapibart.azurecr.io/skynetapibart/skynetapicore:v0.0.2` | Namespaces the image under `skynetapibart/skynetapicore` |

Apply the tags:

```bash
# Recommended combined ACR tag
docker tag skynetapicore:v0.0.2 skynetapibart.azurecr.io/skynetapibart:dev-v0.0.2

# Nested repository alternative
docker tag skynetapicore:v0.0.2 skynetapibart.azurecr.io/skynetapibart/dev:v0.0.2
```

---

### 4. Create and Execute the Container

Stop and remove any previously running container with the same name:

```bash
docker rm -f skynetapicore 2>$null || true
```

Run the container mapping host port (e.g. `5000`) to container port `80`:

```bash
docker run -d \
  --name skynetapicore \
  -p 5000:80 \
  -e ASPNETCORE_ENVIRONMENT=Development \
  skynetapibart.azurecr.io/skynetapibart:dev-v0.0.2
```

---

### 5. Verification & Health Check

1. **Verify container status**:
   ```bash
   docker ps --filter "name=skynetapicore"
   ```
   Confirm status shows `Up X seconds`.

2. **Inspect container logs**:
   ```bash
   docker logs --tail 30 skynetapicore
   ```
   Confirm ASP.NET Core has started listening on `http://[::]:80`.

3. **Test API endpoint**:
   ```bash
   curl -i http://localhost:5000/api/supplier/hi
   ```
   Expected response: `HTTP/1.1 200 OK` with JSON `{"data":{"msg":"OK"},"msg":"Hello from SupplierController"}`.

---

## References & Advanced Workflows

- See [references/docker-workflow.md](./references/docker-workflow.md) for Azure Container Registry authentication (`az acr login`), pushing images, and environment configuration.
- See [scripts/build-and-run.ps1](./scripts/build-and-run.ps1) for the automated Windows PowerShell runner.
- See [scripts/build-and-run.sh](./scripts/build-and-run.sh) for the automated Bash runner.
