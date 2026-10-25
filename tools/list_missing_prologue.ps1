$toTrans = Import-Csv "translations\dialogues\prologue_lines_to_translate.csv"
$existing = Get-Content "translations\dialogues\prologue_french.tsv" | ForEach-Object {
    $p = $_.Split("`t")
    if ($p.Length -ge 4) { $p[2].Trim() }
}
$existingSet = New-Object System.Collections.Generic.HashSet[string]
foreach ($e in $existing) { $existingSet.Add($e) | Out-Null }

$missing = $toTrans | Where-Object { !$existingSet.Contains($_.Text.Trim()) }
Write-Host "Total missing in prologue_french.tsv: $($missing.Count)"
$missing | Select-Object -First 30 Character, Text | Format-Table -Wrap -AutoSize
