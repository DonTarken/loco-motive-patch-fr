Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"

$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Projects.Plugins.PowerQuest.dll", $readerParams)

$type = $module.GetType("PowerTools.Quest.QuestSettings")
$m = $type.Methods | Where-Object { $_.Name -eq "get_LanguageData" }
if ($m) {
    Write-Host "`n=== Method: QuestSettings::get_LanguageData ===" -ForegroundColor Cyan
    foreach ($i in $m.Body.Instructions) {
        Write-Host "$($i.Offset.ToString('X4')): $($i.OpCode) $($i.Operand)"
    }
}
