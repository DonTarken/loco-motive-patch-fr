Get-ChildItem -Path "D:\Games\Loco Motive\Loco Motive_Data" -File | ForEach-Object {
    $m = Select-String -Path $_.FullName -Pattern "My hands are clean" -SimpleMatch -Quiet
    if ($m) {
        Write-Host "Found in: $($_.Name) ($($_.FullName))"
    }
}
