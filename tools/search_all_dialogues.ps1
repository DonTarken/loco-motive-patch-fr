$d = Get-Content -Raw "translations\dialogues\dialogues_all.json" | ConvertFrom-Json
$match = $d | Where-Object { $_.En -like "*approaching a tunnel*" -or $_.En -like "*hope it's one of mine*" }
$match | Format-List
