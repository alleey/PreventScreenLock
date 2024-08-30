[CmdletBinding()]
param (
    $version
)

$appName = "PreventScreenLock"
$projDir = "App"

Set-StrictMode -version 2.0
$ErrorActionPreference = "Stop"

# Clean output directory.
$publishDir = "../../clickonce"
$publishUrl = "https://alleey.github.io/preventscreenlock/#/"

$outDir = "$projDir/$publishDir"
if (Test-Path $outDir) {
    Remove-Item -Path $outDir -Recurse
}

# Publish the application.
Push-Location $projDir
try
{
    Write-Output "Working directory: $pwd"
    Write-Output "Publishing:"
    dotnet publish App.csproj `
        --configuration Release `
        --output $publishDir `
        -p:PublishProfile=Properties\PublishProfiles\ClickOnceProfile.pubxml `
        -p:PublishUrl=$publishUrl `
        -p:DebugType=none `
}
finally
{
    Pop-Location
}
