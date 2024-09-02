[CmdletBinding()]
param (
    $version
)

$appName = "PreventScreenLock"
$projDir = "src/App"

Set-StrictMode -version 2.0
$ErrorActionPreference = "Stop"

# Find MSBuild.
$msBuildPath = & "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe" `
    -latest -requires Microsoft.Component.MSBuild -find MSBuild\**\Bin\MSBuild.exe `
    -prerelease | select-object -first 1
Write-Output "MSBuild: $((Get-Command $msBuildPath).Path)"

# Clean output directory.
$publishDir = "../../clickonce"
$publishUrl = "https://alleey.github.io/PreventScreenLock/"

$outDir = "$projDir/$publishDir"
if (Test-Path $outDir) {
    Remove-Item -Path $outDir -Recurse
}

# Publish the application.
Push-Location $projDir
try
{
    Write-Output "Working directory: $pwd"

    Write-Output "Restoring:"
    dotnet restore App.csproj -r win-x64

    Write-Output "Publishing:"
    $msBuildVerbosityArg = "/v:m"

    & $msBuildPath /target:publish `
        /p:ApplicationVersion=$version /p:AssemblyVersion=$version /p:FileVersion=$version /p:Version=$version `
        /p:PublishProfile=ClickOnceProfile `
        /p:RuntimeIdentifier=win-x64 /p:PublishSingleFile=true `
        /p:PublishDir=$publishDir `
        /p:PublishUrl=$publishUrl `
        /p:Configuration=Release `
        /p:DebugType=none `
        $msBuildVerbosityArg App.csproj
}
finally
{
    Pop-Location
}

# Copy and update index.html
$publishFolder = "./publish"
$indexFilePath = Join-Path -Path $outDir -ChildPath 'index.html'
$sourceIndexFilePath = Join-Path -Path $publishFolder -ChildPath 'index.html'

if (Test-Path $sourceIndexFilePath) {
    Copy-Item -Path $sourceIndexFilePath -Destination $indexFilePath -Force
    Write-Output "Copied $sourceIndexFilePath to $indexFilePath"

    # Replace {{version}} with the actual version
    (Get-Content -Path $indexFilePath) -replace '{{version}}', $version | Set-Content -Path $indexFilePath
    Write-Output "Replaced {{version}} in $indexFilePath with version $version"
} else {
    Write-Error "Source file $sourceIndexFilePath does not exist"
}
