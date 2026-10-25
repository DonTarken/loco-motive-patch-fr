Add-Type -AssemblyName System.Web.Extensions
$js = New-Object System.Web.Script.Serialization.JavaScriptSerializer
$jsonRaw = Get-Content -Raw "translations\dialogues\prologue_translations_add.json" -Encoding UTF8
$dict = $js.Deserialize($jsonRaw, [System.Collections.Generic.Dictionary[string, string]])

$tsvPath = "translations\dialogues\prologue_french.tsv"
$tsvLines = Get-Content $tsvPath -Encoding UTF8 | ForEach-Object {
    $p = $_.Split("`t")
    if ($p.Length -ge 4) { $p[2].Trim() }
}
$tsvSet = New-Object System.Collections.Generic.HashSet[string]([StringComparer]::OrdinalIgnoreCase)
foreach ($t in $tsvLines) { $tsvSet.Add($t) | Out-Null }

$missingCsv = Import-Csv "translations\dialogues\prologue_missing_all.csv"
$added = 0
$linesToAdd = @()

foreach ($row in $missingCsv) {
    $en = $row.Text.Trim()
    if ($dict.ContainsKey($en) -and !$tsvSet.Contains($en)) {
        $tsvSet.Add($en) | Out-Null
        $fr = $dict[$en]
        $char = $row.Character
        $cls = $row.Class
        $mth = $row.Method
        $linesToAdd += "0`t$char`t$en`t$fr`t$cls`t$mth"
        $added++
    }
}

if ($linesToAdd.Count -gt 0) {
    Add-Content -Path $tsvPath -Value $linesToAdd -Encoding UTF8
}

Write-Host "Ajouté $added nouvelles répliques via Import-Csv !" -ForegroundColor Green
$totalCount = (Get-Content $tsvPath).Count
Write-Host "Total de lignes dans $tsvPath : $totalCount"
