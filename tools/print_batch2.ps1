$csv = Import-Csv "translations\dialogues\prologue_missing_all.csv"
for ($i = 40; $i -lt [Math]::Min(80, $csv.Count); $i++) {
    $row = $csv[$i]
    Write-Host "$i | [$($row.Character)] $($row.Text)"
}
