Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"

$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll", $readerParams)

$dialogs = @()
foreach ($t in $module.Types) {
    if ($t.BaseType -ne $null -and $t.BaseType.FullName -like "*DialogTreeScript*") {
        $dialogs += $t
    }
}

Write-Host "Total DialogTreeScript classes: $($dialogs.Count)"
foreach ($d in $dialogs) {
    Write-Host "   $($d.Name)"
}
