param(
    [string]$GameDir = "D:\Games\Loco Motive"
)

$ErrorActionPreference = "Stop"

Write-Host "=== Déploiement du Patch FR dans Loco Motive ===" -ForegroundColor Cyan
Write-Host "Dossier cible : $GameDir"

if (!(Test-Path "$GameDir\Loco Motive.exe")) {
    Write-Error "Le jeu n'a pas été trouvé dans $GameDir"
}

# 1. Copie des fichiers de base BepInEx
Write-Host "1. Installation du runtime BepInEx..." -ForegroundColor Yellow
Copy-Item -Path "patch\BepInEx_base\winhttp.dll" -Destination $GameDir -Force
Copy-Item -Path "patch\BepInEx_base\doorstop_config.ini" -Destination $GameDir -Force

$destBepInEx = Join-Path $GameDir "BepInEx"
if (!(Test-Path $destBepInEx)) { New-Item -ItemType Directory -Path $destBepInEx -Force | Out-Null }
Copy-Item -Path "patch\BepInEx_base\BepInEx\core" -Destination $destBepInEx -Recurse -Force

# 2. Copie du plugin compilé LocoMotiveFR.dll
Write-Host "2. Installation du plugin LocoMotiveFR.dll..." -ForegroundColor Yellow
$destPlugins = Join-Path $destBepInEx "plugins"
if (!(Test-Path $destPlugins)) { New-Item -ItemType Directory -Path $destPlugins -Force | Out-Null }
Copy-Item -Path "patch\bin\LocoMotiveFR.dll" -Destination $destPlugins -Force

# 3. Copie des fichiers de données de traduction (LocoMotiveFR_Data)
Write-Host "3. Installation des données de traduction..." -ForegroundColor Yellow
$destData = Join-Path $destPlugins "LocoMotiveFR_Data"
if (!(Test-Path $destData)) { New-Item -ItemType Directory -Path $destData -Force | Out-Null }

# Copier tous les fichiers .tsv de translations vers LocoMotiveFR_Data
Get-ChildItem -Path "translations" -Filter "*.tsv" -Recurse | ForEach-Object {
    Copy-Item -Path $_.FullName -Destination $destData -Force
    Write-Host "   -> Copié : $($_.Name)" -ForegroundColor Gray
}

Write-Host "`n=== Déploiement terminé avec succès ! ===" -ForegroundColor Green
Write-Host "Vous pouvez lancer le jeu depuis 'D:\Games\Loco Motive\Loco Motive.exe'."
Write-Host "En jeu, la touche F5 rechargera instantanément les traductions depuis BepInEx\plugins\LocoMotiveFR_Data."
