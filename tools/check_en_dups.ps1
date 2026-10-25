$dialogues = Get-Content -Raw "translations\dialogues\dialogues_all.json" | ConvertFrom-Json
$grouped = $dialogues | Group-Object En | Where-Object { $_.Count -gt 1 }
Write-Host "Total unique En with duplicates: $($grouped.Count)"
foreach ($g in $grouped | Select-Object -First 10) {
    Write-Host "Text '$($g.Name)' appears $($g.Count) times"
}
