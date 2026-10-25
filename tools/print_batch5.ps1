$csv = Import-Csv "translations\dialogues\prologue_missing_all.csv"
for ($i = 160; $i -lt $csv.Count; $i++) {
    $row = $csv[$i]
    Write-Host "$i | [$($row.Character)] $($row.Text)"
}
