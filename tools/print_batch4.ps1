$csv = Import-Csv "translations\dialogues\prologue_missing_all.csv"
for ($i = 120; $i -lt [Math]::Min(160, $csv.Count); $i++) {
    $row = $csv[$i]
    Write-Host "$i | [$($row.Character)] $($row.Text)"
}
