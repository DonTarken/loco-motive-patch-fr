$lines = Get-Content "translations\dialogues\prologue_french.tsv"
$emptyEn = 0
$total = 0
foreach ($l in $lines) {
    $p = $l.Split("`t")
    if ($p.Length -ge 4) {
        $total++
        if ([string]::IsNullOrWhiteSpace($p[2])) {
            $emptyEn++
        }
    }
}
Write-Host "Total lines: $total, Empty English: $emptyEn"
