$tsvLines = Get-Content "translations\dialogues\prologue_french.tsv" -Encoding UTF8 | ForEach-Object {
    $p = $_.Split("`t")
    if ($p.Length -ge 4) { $p[2].Trim() }
}
$tsvSet = New-Object System.Collections.Generic.HashSet[string]([StringComparer]::OrdinalIgnoreCase)
foreach ($t in $tsvLines) { $tsvSet.Add($t) | Out-Null }

$missingCsv = Import-Csv "translations\dialogues\prologue_missing_all.csv"
$stillMissing = @()
foreach ($m in $missingCsv) {
    if (!$tsvSet.Contains($m.Text.Trim())) {
        $stillMissing += $m
    }
}

Write-Host "Total in TSV: $($tsvSet.Count)"
Write-Host "Still missing from prologue_missing_all.csv: $($stillMissing.Count)"
foreach ($s in $stillMissing | Select-Object -First 20) {
    Write-Host "   - [$($s.Character)] $($s.Text)"
}
