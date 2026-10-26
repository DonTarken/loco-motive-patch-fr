param(
    [string]$GameDir = "D:\Games\Loco Motive"
)

$ErrorActionPreference = "Stop"

Write-Host "=== Déploiement du Patch FR dans Loco Motive ===" -ForegroundColor Cyan
Write-Host "Dossier cible : $GameDir"

if (!(Test-Path "$GameDir\Loco Motive.exe")) {
    Write-Error "Le jeu n'a pas été trouvé dans $GameDir"
}

# 1. Copie des fichiers de base BepInEx si nécessaire
if (!(Test-Path "$GameDir\winhttp.dll")) {
    Write-Host "1. Installation du runtime BepInEx..." -ForegroundColor Yellow
    Copy-Item -Path "patch\BepInEx_base\winhttp.dll" -Destination $GameDir -Force
    Copy-Item -Path "patch\BepInEx_base\doorstop_config.ini" -Destination $GameDir -Force
}

$destBepInEx = Join-Path $GameDir "BepInEx"
if (!(Test-Path $destBepInEx)) { New-Item -ItemType Directory -Path $destBepInEx -Force | Out-Null }
if (!(Test-Path "$destBepInEx\core")) {
    Copy-Item -Path "patch\BepInEx_base\BepInEx\core" -Destination $destBepInEx -Recurse -Force
}

# 2. Copie du plugin compilé LocoMotiveFR.dll
Write-Host "2. Installation du plugin LocoMotiveFR.dll..." -ForegroundColor Yellow
$destPlugins = Join-Path $destBepInEx "plugins"
if (!(Test-Path $destPlugins)) { New-Item -ItemType Directory -Path $destPlugins -Force | Out-Null }
Copy-Item -Path "patch\bin\LocoMotiveFR.dll" -Destination $destPlugins -Force

# 3. Copie des fichiers de données de traduction (LocoMotiveFR_Data)
Write-Host "3. Installation des données de traduction..." -ForegroundColor Yellow
$destData = Join-Path $destPlugins "LocoMotiveFR_Data"
if (Test-Path $destData) {
    Remove-Item -Path "$destData\*" -Recurse -Force -ErrorAction SilentlyContinue
} else {
    New-Item -ItemType Directory -Path $destData -Force | Out-Null
}

# Fichiers canoniques du projet à déployer
$canonicalFiles = @(
    "translations\glossary_items.tsv",
    "translations\ui\ui_french.tsv",
    "translations\dialogues\inventory_french.tsv",
    "translations\dialogues\prologue_french.tsv",
    "translations\dialogues\chapter1_french.tsv",
    "translations\dialogues\chapter2_french.tsv",
    "translations\dialogues\chapter3_french.tsv",
    "translations\dialogues\chapter4_french.tsv",
    "translations\dialogues\chapter5_french.tsv",
    "translations\dialogues\chapter6_french.tsv",
    "translations\dialogues\chapter7_french.tsv",
    "translations\dialogues\shared_french.tsv",
    "translations\dialogues\extracted_id_strings.tsv",
    "translations\dialogues\extracted_pq_all.tsv",
    "translations\dialogues\unhandled_strings.tsv",
    "translations\dialogues\unity_exact_ids.tsv"
)

foreach ($relPath in $canonicalFiles) {
    if (Test-Path $relPath) {
        Copy-Item -Path $relPath -Destination $destData -Force
        $size = (Get-Item $relPath).Length
        Write-Host "   -> Déployé : $(Split-Path $relPath -Leaf) ($size octets)" -ForegroundColor Green
    } else {
        Write-Warning "Fichier manquant : $relPath"
    }
}

Write-Host "`n=== Déploiement terminé avec succès ! ===" -ForegroundColor Green
Write-Host "Vous pouvez lancer le jeu depuis 'D:\Games\Loco Motive\Loco Motive.exe'."
Write-Host "En jeu, la touche F5 rechargera instantanément les traductions depuis BepInEx\plugins\LocoMotiveFR_Data."
