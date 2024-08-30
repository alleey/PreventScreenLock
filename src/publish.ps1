[CmdletBinding()]
param (
    $version
)

$appName = "PreventScreenLock"
$projDir = "App"

Set-StrictMode -version 2.0
$ErrorActionPreference = "Stop"

# Find MSBuild.
$msBuildPath = & "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe" `
    -latest -requires Microsoft.Component.MSBuild -find MSBuild\**\Bin\MSBuild.exe `
    -prerelease | select-object -first 1
Write-Output "MSBuild: $((Get-Command $msBuildPath).Path)"

# Clean output directory.
$publishDir = "../../clickonce"
$publishUrl = "https://alleey.github.io/preventscreenlock/#/"

$outDir = "$projDir/$publishDir"
if (Test-Path $outDir) {
    Remove-Item -Path $outDir -Recurse
}

# Publish the application.
Push-Location $projDir
try {
    Write-Output "Working directory: $pwd"

    Write-Output "Restoring:"
    dotnet restore App.csproj -r win-x64

    Write-Output "Publishing:"
    $msBuildVerbosityArg = "/v:m"
    if ($env:CI) {
        $msBuildVerbosityArg = ""
    }
    & $msBuildPath /target:publish `
        /p:PublishProfile=Properties/PublishProfiles/ClickOnceProfile.pubxml `
        /p:PublishDir=$publishDir `
        /p:PublishUrl=$publishUrl `
        /p:Configuration=Release `
        $msBuildVerbosityArg App.csproj

    # Measure publish size.
    $publishSize = (Get-ChildItem -Path "$publishDir/Application Files" -Recurse | Measure-Object -Property Length -Sum).Sum / 1Mb
    Write-Output ("Published size: {0:N2} MB" -f $publishSize)
}
finally {
    Pop-Location
}
