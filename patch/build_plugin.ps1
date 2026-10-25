param(
    [string]$GameManagedDir = "D:\Games\Loco Motive\Loco Motive_Data\Managed",
    [string]$OutDir = "$PSScriptRoot\bin"
)

$ErrorActionPreference = "Stop"

Write-Host "=== Compilation du plugin LocoMotiveFR.dll ===" -ForegroundColor Cyan

$csc = "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe"
if (!(Test-Path $OutDir)) { New-Item -ItemType Directory -Path $OutDir -Force | Out-Null }

$refs = @(
    "$PSScriptRoot\BepInEx_base\BepInEx\core\BepInEx.dll",
    "$PSScriptRoot\BepInEx_base\BepInEx\core\0Harmony.dll",
    "$GameManagedDir\UnityEngine.dll",
    "$GameManagedDir\UnityEngine.CoreModule.dll",
    "$GameManagedDir\UnityEngine.UI.dll",
    "$GameManagedDir\UnityEngine.IMGUIModule.dll",
    "$GameManagedDir\UnityEngine.InputLegacyModule.dll",
    "$GameManagedDir\Unity.TextMeshPro.dll",
    "$GameManagedDir\Projects.Plugins.PowerQuest.dll",
    "$GameManagedDir\Assembly-CSharp.dll"
)

$refArgs = ($refs | ForEach-Object { "/r:`"$_`"" }) -join " "
$outFile = Join-Path $OutDir "LocoMotiveFR.dll"
$srcFile = Join-Path $PSScriptRoot "src\LocoMotiveFR.cs"

$cmd = "& `"$csc`" /t:library /optimize+ /out:`"$outFile`" $refArgs `"$srcFile`""
Invoke-Expression $cmd

if (Test-Path $outFile) {
    Write-Host "Compilation réussie : $outFile ($((Get-Item $outFile).Length) octets)" -ForegroundColor Green
} else {
    Write-Error "Échec de la compilation."
}
