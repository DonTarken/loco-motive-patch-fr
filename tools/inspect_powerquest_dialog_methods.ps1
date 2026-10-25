Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"

$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Projects.Plugins.PowerQuest.dll", $readerParams)

$type = $module.GetType("PowerTools.Quest.PowerQuest")
foreach ($m in $type.Methods) {
    if ($m.Name -like "*Dialog*") {
        Write-Host "Method: $($m.FullName)"
        if ($m.HasBody) {
            foreach ($i in $m.Body.Instructions) {
                if ($i.OpCode.Name -like "*ldfld*" -or $i.OpCode.Name -like "*call*") {
                    Write-Host "   $($i.OpCode) $($i.Operand)"
                }
            }
        }
    }
}
