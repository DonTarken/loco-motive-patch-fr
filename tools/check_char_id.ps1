$dialogues = Get-Content -Raw "translations\dialogues\dialogues_all.json" | ConvertFrom-Json
$grouped = $dialogues | Group-Object { "$($_.Character):$($_.Id)" } | Where-Object { $_.Count -gt 1 }
Write-Host "Total unique (Character, Id) pairs with duplicates: $($grouped.Count)"
foreach ($g in $grouped | Select-Object -First 10) {
    Write-Host "Key $($g.Name) appears $($g.Count) times:"
    foreach ($item in $g.Group | Select-Object -First 3) {
        Write-Host "   - ($($item.ClassName)): $($item.En)"
    }
}
