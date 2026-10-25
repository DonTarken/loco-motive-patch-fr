Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"

$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Projects.Plugins.PowerQuest.dll", $readerParams)

$type = $module.GetType("PowerTools.Quest.PowerQuest")
Write-Host "Fields in PowerQuest related to Dialog:"
foreach ($f in $type.Fields) {
    if ($f.FieldType.Name -like "*Dialog*" -or $f.Name -like "*dialog*") {
        Write-Host "   $($f.FieldType.FullName) $($f.Name)"
    }
}
