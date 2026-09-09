<#
.SYNOPSIS
    Builds the SkyNetApiCore project, builds its Docker image, tags it for ACR with automatic version bumping, and runs the container.

.PARAMETER Version
    Explicit version to use (e.g., '0.0.3' or 'v0.0.3'). If omitted, automatically increments the version from the VERSION file.

.PARAMETER Bump
    Semantic version segment to increment: 'patch' (default), 'minor', or 'major'.

.PARAMETER NoBump
    If specified, builds using the current recorded version without incrementing.

.PARAMETER ImageTag
    Optional custom image tag override. Defaults to 'skynetapibart.azurecr.io/skynetapibart:dev-v<Version>'.

.PARAMETER AlternateTag
    Optional custom alternate tag override. Defaults to 'skynetapibart.azurecr.io/skynetapibart/dev:v<Version>'.

.PARAMETER LocalTag
    Optional custom local tag override. Defaults to 'skynetapicore:v<Version>'.

.PARAMETER Port
    Host port mapped to container port 80. Default is 5000.

.PARAMETER ContainerName
    Name of the running Docker container. Default is 'skynetapicore'.

.PARAMETER SkipDotnetBuild
    If specified, skips local dotnet compile check before Docker build.
#>
[CmdletBinding()]
param(
    [string]$Version,
    [ValidateSet("patch", "minor", "major")]
    [string]$Bump = "patch",
    [switch]$NoBump,
    [string]$ImageTag,
    [string]$AlternateTag,
    [string]$LocalTag,
    [int]$Port = 5000,
    [string]$ContainerName = "skynetapicore",
    [switch]$SkipDotnetBuild
)

$ErrorActionPreference = "Stop"

# Determine paths
if ($PSScriptRoot) {
    $ScriptDir = $PSScriptRoot
} elseif ($MyInvocation.MyCommand.Path) {
    $ScriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
} else {
    $ScriptDir = Join-Path (Get-Location) ".agents/skills/skynetapicore-docker/scripts"
}
$SkillRoot = Split-Path -Parent $ScriptDir

# Locate VERSION file
$CandidatePaths = @(
    (Join-Path $SkillRoot "VERSION"),
    (Join-Path (Get-Location) ".agents/skills/skynetapicore-docker/VERSION")
)
$VersionFile = $CandidatePaths | Where-Object { Test-Path $_ } | Select-Object -First 1
if (-not $VersionFile) {
    $VersionFile = $CandidatePaths[0]
}

# Determine current baseline version
$currentVersion = "0.0.2"
if ($VersionFile -and (Test-Path $VersionFile)) {
    $fileContent = (Get-Content $VersionFile -Raw).Trim().TrimStart('v','V')
    if ($fileContent -match '^\d+\.\d+\.\d+$') {
        $currentVersion = $fileContent
    }
}

# Cross-reference existing local docker image tags to avoid regressions
try {
    $dockerTags = docker images "skynetapicore" --format "{{.Tag}}" 2>$null
    foreach ($t in $dockerTags) {
        if ($t -match '^v?(\d+\.\d+\.\d+)$') {
            $matchedTag = $Matches[1]
            $candidate = [version]$matchedTag
            if ($candidate -gt [version]$currentVersion) {
                $currentVersion = $matchedTag
            }
        }
    }
} catch {
    # Ignore docker query errors
}

# Calculate new version
if ($PSBoundParameters.ContainsKey('Version') -and $Version) {
    $resolvedVersion = $Version.Trim().TrimStart('v','V')
    Write-Host "`n[Version] Using explicit version: v$resolvedVersion" -ForegroundColor Magenta
} elseif ($NoBump) {
    $resolvedVersion = $currentVersion
    Write-Host "`n[Version] Rebuilding existing version (-NoBump): v$resolvedVersion" -ForegroundColor Magenta
} else {
    $parts = $currentVersion.Split('.')
    [int]$maj = $parts[0]
    [int]$min = $parts[1]
    [int]$patch = $parts[2]

    switch ($Bump.ToLower()) {
        "major" { $maj++; $min = 0; $patch = 0 }
        "minor" { $min++; $patch = 0 }
        default { $patch++ }
    }
    $resolvedVersion = "$maj.$min.$patch"
    Write-Host "`n[Version] Automatically incremented: v$currentVersion -> v$resolvedVersion (bump: $Bump)" -ForegroundColor Magenta
}

# Save new version to VERSION file
Set-Content -Path $VersionFile -Value $resolvedVersion -NoNewline

# Derive tag strings
$tagSuffix = "v$resolvedVersion"
if (-not $LocalTag) {
    $LocalTag = "skynetapicore:$tagSuffix"
}
if (-not $ImageTag) {
    $ImageTag = "skynetapibart.azurecr.io/skynetapibart:dev-$tagSuffix"
}
if (-not $AlternateTag) {
    $AlternateTag = "skynetapibart.azurecr.io/skynetapibart/dev:$tagSuffix"
}

Write-Host "==========================================================" -ForegroundColor Cyan
Write-Host " SkyNetApiCore Docker Build & Run Workflow ($tagSuffix)" -ForegroundColor Cyan
Write-Host "==========================================================" -ForegroundColor Cyan

# 1. Build .NET Project locally
if (-not $SkipDotnetBuild) {
    Write-Host "`n[Step 1/5] Compiling SkyNetApiCore (Release)..." -ForegroundColor Yellow
    dotnet build SkyNetApiCore/SkyNetApiCore.csproj -c Release
    if ($LASTEXITCODE -ne 0) {
        Write-Error "Dotnet build failed with exit code $LASTEXITCODE"
    }
} else {
    Write-Host "`n[Step 1/5] Skipping local dotnet build." -ForegroundColor Gray
}

# 2. Build Docker Image
Write-Host "`n[Step 2/5] Building Docker image from SkyNetApiCore/Dockerfile..." -ForegroundColor Yellow
Write-Host "  -> Local Tag: $LocalTag"
docker build -f SkyNetApiCore/Dockerfile -t $LocalTag .
if ($LASTEXITCODE -ne 0) {
    Write-Error "Docker build failed with exit code $LASTEXITCODE"
}

# 3. Tag Docker Image
Write-Host "`n[Step 3/5] Tagging image..." -ForegroundColor Yellow
Write-Host "  -> Primary Tag:   $ImageTag"
docker tag $LocalTag $ImageTag

if ($AlternateTag) {
    Write-Host "  -> Alternate Tag: $AlternateTag"
    docker tag $LocalTag $AlternateTag
}

# 4. Recreate Container
Write-Host "`n[Step 4/5] Preparing container '$ContainerName'..." -ForegroundColor Yellow
$existing = docker ps -a -q --filter "name=^/${ContainerName}$"
if ($existing) {
    Write-Host "Stopping and removing existing container '$ContainerName'..." -ForegroundColor Yellow
    docker rm -f $ContainerName | Out-Null
}

Write-Host "Starting container '$ContainerName' on port $Port -> 80..." -ForegroundColor Yellow
docker run -d `
    --name $ContainerName `
    -p "${Port}:80" `
    -e ASPNETCORE_ENVIRONMENT=Development `
    $ImageTag

if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to run container with exit code $LASTEXITCODE"
}

# 5. Verify Container
Write-Host "`n[Step 5/5] Verifying container status..." -ForegroundColor Yellow
Start-Sleep -Seconds 2
docker ps --filter "name=^/${ContainerName}$"

Write-Host "`nRecent container logs:" -ForegroundColor Cyan
docker logs --tail 20 $ContainerName

Write-Host "`n==========================================================" -ForegroundColor Green
Write-Host " SkyNetApiCore ($tagSuffix) container is successfully running!" -ForegroundColor Green
Write-Host " API available at: http://localhost:$Port/api/supplier/hi" -ForegroundColor Green
Write-Host " Swagger UI: http://localhost:$Port/swagger" -ForegroundColor Green
Write-Host "==========================================================" -ForegroundColor Green

