$csv = Import-Csv "translations\dialogues\prologue_missing_all.csv"
for ($i = 80; $i -lt [Math]::Min(120, $csv.Count); $i++) {
    $row = $csv[$i]
    Write-Host "$i | [$($row.Character)] $($row.Text)"
}
