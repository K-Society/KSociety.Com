# Based on http://nuts4.net/post/automated-download-and-installation-of-visual-studio-extensions-via-powershell

param([String] $PackageName)
 
$ErrorActionPreference = "Stop"
 
$baseProtocol = "https:"
$baseHostName = "github.com/wixtoolset/VisualStudioExtension/releases/download/v1.0.0.12"
 
$Uri = "$($baseProtocol)//$($baseHostName)/$($PackageName)"
$VsixLocation = "$($env:Temp)\$([guid]::NewGuid()).vsix"
 
$VSInstallDir = "C:\Program Files (x86)\Microsoft Visual Studio\Installer\resources\app\ServiceHub\Services\Microsoft.VisualStudio.Setup.Service"
 
if (-Not $VSInstallDir) {
  Write-Error "Visual Studio InstallDir registry key missing"
  Exit 1
}
 
Write-Host "Grabbing VSIX extension at $($Uri)"
$HTML = Invoke-WebRequest -Uri $Uri -OutFile $VsixLocation -UseBasicParsing -SessionVariable session
 
Write-Host "Attempting to download $($PackageName)..."
 
if (-Not (Test-Path $VsixLocation)) {
  Write-Error "Downloaded VSIX file could not be located"
  Exit 1
}
Write-Host "VSInstallDir is $($VSInstallDir)"
Write-Host "VsixLocation is $($VsixLocation)"
Write-Host "Installing $($PackageName)..."
Start-Process -Filepath "$($VSInstallDir)\VSIXInstaller" -ArgumentList "/q /a $($VsixLocation)" -Wait
 
Write-Host "Cleanup..."
rm $VsixLocation
 
Write-Host "Installation of $($PackageName) complete!"