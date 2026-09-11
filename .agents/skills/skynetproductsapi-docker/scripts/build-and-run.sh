#!/usr/bin/env bash
set -eo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
SKILL_ROOT="$(cd "${SCRIPT_DIR}/.." && pwd)"
VERSION_FILE="${SKILL_ROOT}/VERSION"

# Determine current baseline version
CURRENT_VERSION="0.0.2"
if [ -f "$VERSION_FILE" ]; then
    FILE_CONTENT="$(tr -d '[:space:]' < "$VERSION_FILE" | sed 's/^[vV]//')"
    if [[ "$FILE_CONTENT" =~ ^[0-9]+\.[0-9]+\.[0-9]+$ ]]; then
        CURRENT_VERSION="$FILE_CONTENT"
    fi
fi

# Cross-reference existing docker tags to prevent regressions
if command -v docker >/dev/null 2>&1; then
    for tag in $(docker images "skynetproductsapi" --format "{{.Tag}}" 2>/dev/null || true); do
        CLEAN_TAG=$(echo "$tag" | sed 's/^[vV]//')
        if [[ "$CLEAN_TAG" =~ ^[0-9]+\.[0-9]+\.[0-9]+$ ]]; then
            HIGHER=$(printf '%s\n%s\n' "$CURRENT_VERSION" "$CLEAN_TAG" | sort -V | tail -n1)
            if [ "$HIGHER" = "$CLEAN_TAG" ]; then
                CURRENT_VERSION="$CLEAN_TAG"
            fi
        fi
    done
fi

# Calculate new version
if [ -n "$VERSION" ]; then
    RESOLVED_VERSION="$(echo "$VERSION" | sed 's/^[vV]//')"
    echo -e "\n[Version] Using explicit version: v${RESOLVED_VERSION}"
elif [ "$NO_BUMP" = "true" ]; then
    RESOLVED_VERSION="$CURRENT_VERSION"
    echo -e "\n[Version] Rebuilding existing version (NO_BUMP=true): v${RESOLVED_VERSION}"
else
    IFS='.' read -r MAJ MIN PATCH <<< "$CURRENT_VERSION"
    BUMP="${BUMP:-patch}"
    case "$BUMP" in
        major)
            MAJ=$((MAJ + 1)); MIN=0; PATCH=0 ;;
        minor)
            MIN=$((MIN + 1)); PATCH=0 ;;
        *)
            PATCH=$((PATCH + 1)) ;;
    esac
    RESOLVED_VERSION="${MAJ}.${MIN}.${PATCH}"
    echo -e "\n[Version] Automatically incremented: v${CURRENT_VERSION} -> v${RESOLVED_VERSION} (bump: ${BUMP})"
fi

# Save to VERSION file
printf "%s" "$RESOLVED_VERSION" > "$VERSION_FILE"
TAG_SUFFIX="v${RESOLVED_VERSION}"

IMAGE_TAG="${IMAGE_TAG:-skynetapibart.azurecr.io/skynetproductsapi:dev-${TAG_SUFFIX}}"
ALTERNATE_TAG="${ALTERNATE_TAG:-skynetapibart.azurecr.io/skynetproductsapi/dev:${TAG_SUFFIX}}"
LOCAL_TAG="${LOCAL_TAG:-skynetproductsapi:${TAG_SUFFIX}}"
PORT="${PORT:-5001}"
CONTAINER_NAME="${CONTAINER_NAME:-skynetproductsapi}"
SKIP_DOTNET_BUILD="${SKIP_DOTNET_BUILD:-false}"

echo "=========================================================="
echo "SkynetProductsApi Docker Build & Run Workflow (${TAG_SUFFIX})"
echo "=========================================================="

# 1. Build .NET Project locally
if [ "$SKIP_DOTNET_BUILD" != "true" ]; then
    echo -e "\n[Step 1/5] Compiling SkynetProductsApi (Release)..."
    dotnet build SkynetProductsApi/SkynetProductsApi.csproj -c Release
fi

# 2. Build Docker Image
echo -e "\n[Step 2/5] Building Docker image from  SkynetProductsApi/Dockerfile..."
echo "  -> Local Tag: ${LOCAL_TAG}"
docker build -f SkynetProductsApi/Dockerfile -t "${LOCAL_TAG}" .

# 3. Tag Docker Image
echo -e "\n[Step 3/5] Tagging image..."
echo "  -> Primary Tag:   ${IMAGE_TAG}"
docker tag "${LOCAL_TAG}" "${IMAGE_TAG}"

if [ -n "${ALTERNATE_TAG}" ]; then
    echo "  -> Alternate Tag: ${ALTERNATE_TAG}"
    docker tag "${LOCAL_TAG}" "${ALTERNATE_TAG}"
fi

# 4. Recreate Container
echo -e "\n[Step 4/5] Preparing container '${CONTAINER_NAME}'..."
if docker ps -a -q --filter "name=^/${CONTAINER_NAME}$" | grep -q .; then
    echo "Stopping and removing existing container '${CONTAINER_NAME}'..."
    docker rm -f "${CONTAINER_NAME}" > /dev/null
fi

echo "Starting container '${CONTAINER_NAME}' on port ${PORT} -> 80..."
docker run -d \
    --name "${CONTAINER_NAME}" \
    -p "${PORT}:80" \
    -e ASPNETCORE_ENVIRONMENT=Development \
    "${IMAGE_TAG}"

# 5. Verify Container
echo -e "\n[Step 5/5] Verifying container status..."
sleep 2
docker ps --filter "name=^/${CONTAINER_NAME}$"

echo -e "\nRecent container logs:"
docker logs --tail 20 "${CONTAINER_NAME}"

echo "=========================================================="
echo " SkynetProductsApi (${TAG_SUFFIX}) container is successfully running!"
echo " API URL: http://localhost:${PORT}/api/supplier/hi"
echo "=========================================================="

