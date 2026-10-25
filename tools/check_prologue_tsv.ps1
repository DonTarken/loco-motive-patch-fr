$lines = Get-Content "translations\dialogues\prologue_french.tsv"
$items = @()
foreach ($l in $lines) {
    $p = $l.Split("`t")
    if ($p.Length -ge 4) {
        $items += [PSCustomObject]@{
            Id = $p[0].Trim()
            Char = $p[1].Trim()
            En = $p[2].Trim()
            Fr = $p[3].Trim()
        }
    }
}

$grouped = $items | Group-Object Id | Where-Object { $_.Count -gt 1 }
Write-Host "In prologue_french.tsv: $($items.Count) lines total."
Write-Host "Duplicate IDs in prologue_french.tsv: $($grouped.Count)"
foreach ($g in $grouped) {
    Write-Host "`nID $($g.Name) appears $($g.Count) times:"
    foreach ($it in $g.Group) {
        Write-Host "   [$($it.Char)]: En='$($it.En)' -> Fr='$($it.Fr)'"
    }
}
