$jsonRaw = Get-Content -Raw "translations\dialogues\prologue_translations_add.json" -Encoding UTF8
$dict = $jsonRaw | ConvertFrom-Json

$missingCsv = Import-Csv "translations\dialogues\prologue_missing_all.csv"
$tsvPath = "translations\dialogues\prologue_french.tsv"

$existing = Get-Content $tsvPath -Encoding UTF8 | ForEach-Object {
    $p = $_.Split("`t")
    if ($p.Length -ge 4) { $p[2].Trim() }
}
$existingSet = New-Object System.Collections.Generic.HashSet[string]
foreach ($e in $existing) { $existingSet.Add($e) | Out-Null }

$added = 0
$linesToAdd = @()

foreach ($row in $missingCsv) {
    $en = $row.Text.Trim()
    if ($dict.PSObject.Properties[$en] -ne $null) {
        $fr = $dict.PSObject.Properties[$en].Value
        if (!$existingSet.Contains($en)) {
            $existingSet.Add($en) | Out-Null
            $char = $row.Character
            $cls = $row.Class
            $mth = $row.Method
            $linesToAdd += "0`t$char`t$en`t$fr`t$cls`t$mth"
            $added++
        }
    }
}

if ($linesToAdd.Count -gt 0) {
    Add-Content -Path $tsvPath -Value $linesToAdd -Encoding UTF8
}

Write-Host "Ajouté $added nouvelles répliques à $tsvPath !" -ForegroundColor Green
$totalCount = (Get-Content $tsvPath).Count
Write-Host "Total de lignes dans $tsvPath : $totalCount"
