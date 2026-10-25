Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"

$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll", $readerParams)

$type = $module.GetType("DialogLamontQuestioning")
foreach ($m in $type.Methods) {
    if ($m.Name -like "Option*") {
        Write-Host "`n=== Method: $($m.Name) ===" -ForegroundColor Cyan
        foreach ($i in $m.Body.Instructions) {
            if ($i.OpCode.Name -like "*call*" -or $i.OpCode.Name -eq "ldstr") {
                Write-Host "   $($i.OpCode) $($i.Operand)"
            }
        }
    }
}
