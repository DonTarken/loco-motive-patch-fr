Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"

$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll", $readerParams)

$type = $module.GetType("PowerTools.Quest.DialogOption")
Write-Host "=== PowerTools.Quest.DialogOption ===" -ForegroundColor Cyan
foreach ($m in $type.Methods) {
    if ($m.Name -like "*get_Text*" -or $m.Name -like "*get_Desc*" -or $m.Name -like "*set_Text*") {
        Write-Host "Method: $($m.FullName)"
        foreach ($i in $m.Body.Instructions) {
            Write-Host "   $($i.OpCode) $($i.Operand)"
        }
    }
}

$type2 = $module.GetType("DialogOptionComponent")
Write-Host "`n=== DialogOptionComponent ===" -ForegroundColor Cyan
foreach ($m in $type2.Methods) {
    Write-Host "Method: $($m.FullName)"
    if ($m.HasBody) {
        foreach ($i in $m.Body.Instructions) {
            if ($i.OpCode.Name -like "*call*" -or $i.OpCode.Name -eq "ldstr") {
                Write-Host "   $($i.OpCode) $($i.Operand)"
            }
        }
    }
}
