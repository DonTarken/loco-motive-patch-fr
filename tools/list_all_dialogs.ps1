Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"

$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll", $readerParams)

$dialogs = $module.Types | Where-Object { $_.BaseType -ne $null -and $_.BaseType.FullName -like "*DialogTreeScript*" }
Write-Host "All DialogTree scripts:"
foreach ($d in $dialogs) {
    Write-Host "  $($d.Name)"
}
