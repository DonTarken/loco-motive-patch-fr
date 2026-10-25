Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"

$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll", $readerParams)

$type = $module.GetType("GuiDialogTreeComponent")
$m = $type.Methods | Where-Object { $_.Name -eq "UpdateItems" }

for ($i = 0; $i -lt $m.Body.Instructions.Count; $i++) {
    $instr = $m.Body.Instructions[$i]
    if ($instr.OpCode.Name -like "*call*" -and $instr.Operand -like "*Localize*") {
        Write-Host "Instruction: $($instr.Offset.ToString('X4')) $($instr.OpCode) $($instr.Operand)"
        for ($k = [Math]::Max(0, $i - 8); $k -le [Math]::Min($m.Body.Instructions.Count - 1, $i + 6); $k++) {
            $in = $m.Body.Instructions[$k]
            Write-Host "   $($in.Offset.ToString('X4')): $($in.OpCode) $($in.Operand)"
        }
    }
}
