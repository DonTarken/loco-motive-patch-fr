$dialogues = Get-Content -Raw "translations\dialogues\dialogues_all.json" | ConvertFrom-Json
Write-Host "Total dialogues: $($dialogues.Count)"
$ids = $dialogues | ForEach-Object { $_.Id }
$uniqueIds = $ids | Select-Object -Unique
Write-Host "Unique IDs: $($uniqueIds.Count)"

$grouped = $dialogues | Group-Object Id | Where-Object { $_.Count -gt 1 }
Write-Host "IDs with duplicates: $($grouped.Count)"
foreach ($g in $grouped | Select-Object -First 10) {
    Write-Host "ID $($g.Name) appears $($g.Count) times:"
    foreach ($item in $g.Group | Select-Object -First 3) {
        Write-Host "   - [$($item.Character)] ($($item.ClassName)): $($item.En)"
    }
}
