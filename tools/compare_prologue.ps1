$cecil = Import-Csv "translations\dialogues\prologue_cecil_extracted.csv"
$tsv = Get-Content "translations\dialogues\prologue_french.tsv" | ForEach-Object {
    $p = $_.Split("`t")
    if ($p.Length -ge 4) { $p[2].Trim() }
}
$tsvSet = New-Object System.Collections.Generic.HashSet[string]
foreach ($t in $tsv) { $tsvSet.Add($t) | Out-Null }

Write-Host "Cecil lines in prologue scenes: $($cecil.Count)"
Write-Host "TSV lines currently translated: $($tsvSet.Count)"

$missing = @()
foreach ($c in $cecil) {
    if (!$tsvSet.Contains($c.Text.Trim())) {
        $missing += $c
    }
}

Write-Host "Lines in prologue scenes missing from TSV: $($missing.Count)"
Write-Host "`nSample missing lines:"
$missing | Select-Object -First 25 Character, Class, Text | Format-Table -Wrap -AutoSize
