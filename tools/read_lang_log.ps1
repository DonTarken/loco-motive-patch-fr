$log = Get-Content 'D:\Games\Loco Motive\BepInEx\LogOutput.log'
$log | Select-String -Pattern "Language|Langue|OptText" | Select-Object -Last 20
