$csv = Import-Csv "translations\dialogues\prologue_missing_all.csv"
for ($i = 0; $i -lt [Math]::Min(40, $csv.Count); $i++) {
    $row = $csv[$i]
    Write-Host "$i | [$($row.Character)] $($row.Text)"
}
