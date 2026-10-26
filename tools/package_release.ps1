param(
    [string]$Version = "1.0.0"
)

$ErrorActionPreference = "Stop"

Write-Host "=== Création de l'archive de Release pour Loco Motive Patch FR (v$Version) ===" -ForegroundColor Cyan

# 1. Vérifier et recompiler le plugin
Write-Host "1. Compilation de la dernière version du plugin..." -ForegroundColor Yellow
& powershell -ExecutionPolicy Bypass -File "$PSScriptRoot\..\patch\build_plugin.ps1"

# 2. Préparer le dossier de staging
$distDir = "$PSScriptRoot\..\dist"
$stageDir = "$distDir\staging"
$zipName = "LocoMotive_Patch_FR_v$Version.zip"
$zipPath = "$distDir\$zipName"

if (Test-Path $stageDir) {
    Remove-Item -Path $stageDir -Recurse -Force
}
New-Item -ItemType Directory -Path $stageDir -Force | Out-Null

# 3. Copier les fichiers du runtime BepInEx
Write-Host "2. Préparation des fichiers BepInEx..." -ForegroundColor Yellow
Copy-Item "$PSScriptRoot\..\patch\BepInEx_base\winhttp.dll" -Destination $stageDir -Force
Copy-Item "$PSScriptRoot\..\patch\BepInEx_base\doorstop_config.ini" -Destination $stageDir -Force

$stageBepInEx = "$stageDir\BepInEx"
New-Item -ItemType Directory -Path "$stageBepInEx\core" -Force | Out-Null
Copy-Item "$PSScriptRoot\..\patch\BepInEx_base\BepInEx\core\*" -Destination "$stageBepInEx\core" -Recurse -Force

# 4. Copier le plugin compilé
$stagePlugins = "$stageBepInEx\plugins"
New-Item -ItemType Directory -Path $stagePlugins -Force | Out-Null
Copy-Item "$PSScriptRoot\..\patch\bin\LocoMotiveFR.dll" -Destination $stagePlugins -Force

# 5. Copier les fichiers de données canoniques
$stageData = "$stagePlugins\LocoMotiveFR_Data"
New-Item -ItemType Directory -Path $stageData -Force | Out-Null

$canonicalFiles = [ordered]@{
    "glossary_items.tsv" = "$PSScriptRoot\..\translations\glossary_items.tsv"
    "ui_french.tsv" = "$PSScriptRoot\..\translations\ui\ui_french.tsv"
    "interactions_french.tsv" = "$PSScriptRoot\..\translations\ui\interactions_french.tsv"
    "inventory_french.tsv" = "$PSScriptRoot\..\translations\dialogues\inventory_french.tsv"
    "prologue_french.tsv" = "$PSScriptRoot\..\translations\dialogues\prologue_french.tsv"
    "chapter1_french.tsv" = "$PSScriptRoot\..\translations\dialogues\chapter1_french.tsv"
    "chapter2_french.tsv" = "$PSScriptRoot\..\translations\dialogues\chapter2_french.tsv"
    "chapter3_french.tsv" = "$PSScriptRoot\..\translations\dialogues\chapter3_french.tsv"
    "chapter4_french.tsv" = "$PSScriptRoot\..\translations\dialogues\chapter4_french.tsv"
    "chapter5_french.tsv" = "$PSScriptRoot\..\translations\dialogues\chapter5_french.tsv"
    "chapter6_french.tsv" = "$PSScriptRoot\..\translations\dialogues\chapter6_french.tsv"
    "chapter7_french.tsv" = "$PSScriptRoot\..\translations\dialogues\chapter7_french.tsv"
    "shared_french.tsv" = "$PSScriptRoot\..\translations\dialogues\shared_french.tsv"
}

foreach ($item in $canonicalFiles.GetEnumerator()) {
    $src = $item.Value
    if (Test-Path $src) {
        Copy-Item -Path $src -Destination "$stageData\$($item.Key)" -Force
    } else {
        Write-Error "Fichier manquant : $src"
    }
}

# 6. Ajouter le fichier LISEZ-MOI d'installation
$readmeContent = @"
=============================================================
 LOCO MOTIVE - PATCH DE TRADUCTION FRANÇAISE (v$Version)
 Projet communautaire indépendant par DonTarken & Antigravity
=============================================================

--- INSTALLATION FACILE (1 MINUTE) ---

1. Ouvrez le dossier où le jeu est installé :
   * Sur Steam : Clic droit sur 'Loco Motive' dans votre bibliothèque > 'Gérer' > 'Parcourir les fichiers locaux'.
   * Sur GOG : Clic droit sur le jeu dans GOG Galaxy > 'Gérer l'installation' > 'Afficher le dossier'.

2. Copiez l'intégralité du contenu de ce fichier ZIP (les fichiers winhttp.dll, doorstop_config.ini et le dossier BepInEx)
   directement dans le dossier du jeu (au même endroit que 'Loco Motive.exe').

3. Lancez le jeu normalement !
   Allez dans : Paramètres > Langue du texte, puis sélectionnez 'Français'.

--- STEAM DECK / LINUX ---
Dans les options de lancement Steam du jeu, ajoutez la commande suivante :
WINEDLLOVERRIDES="winhttp=n,b" %command%

--- COMMANDES UTILES EN JEU ---
* F5 : Recharge instantanément les textes modifiés sans redémarrer le jeu.

--- SIGNALER UN PROBLÈME OU UNE COQUILLE ---
Rendez-vous sur la page GitHub du projet :
https://github.com/DonTarken/loco-motive-patch-fr/issues

Bon voyage à bord du Reuss Express !
"@

Set-Content -Path "$stageDir\LISEZ-MOI.txt" -Value $readmeContent -Encoding UTF8

# 7. Création de l'archive ZIP
Write-Host "3. Compression de l'archive $zipName..." -ForegroundColor Yellow
if (Test-Path $zipPath) {
    Remove-Item $zipPath -Force
}

Add-Type -AssemblyName System.IO.Compression.FileSystem
[System.IO.Compression.ZipFile]::CreateFromDirectory($stageDir, $zipPath, [System.IO.Compression.CompressionLevel]::Optimal, $false)

# Nettoyage du staging
Remove-Item -Path $stageDir -Recurse -Force

$zipSize = (Get-Item $zipPath).Length
Write-Host "`n=== Archive prête pour GitHub Releases ! ===" -ForegroundColor Green
Write-Host "Fichier créé : $zipPath ($([Math]::Round($zipSize / 1MB, 2)) Mo)"
