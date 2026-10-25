$toTrans = Import-Csv "translations\dialogues\prologue_lines_to_translate.csv"
$existing = Get-Content "translations\dialogues\prologue_french.tsv" | ForEach-Object {
    $p = $_.Split("`t")
    if ($p.Length -ge 4) { $p[2].Trim() }
}
$existingSet = New-Object System.Collections.Generic.HashSet[string]
foreach ($e in $existing) { $existingSet.Add($e) | Out-Null }

$missing = $toTrans | Where-Object { !$existingSet.Contains($_.Text.Trim()) }
$missing | Export-Csv "translations\dialogues\prologue_missing_all.csv" -NoTypeInformation -Encoding UTF8
Write-Host "Exported $($missing.Count) lines to translations\dialogues\prologue_missing_all.csv"
