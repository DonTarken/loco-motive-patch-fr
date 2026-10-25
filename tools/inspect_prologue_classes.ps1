$lines = Import-Csv "translations\dialogues\prologue_cecil_extracted.csv"
Write-Host "Classes in prologue:"
$lines | Group-Object Class | Sort-Object Count -Descending | Select-Object -First 20 Name, Count | Format-Table -AutoSize
