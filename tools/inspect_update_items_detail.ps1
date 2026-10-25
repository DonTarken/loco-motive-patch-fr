Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"

$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll", $readerParams)

$type = $module.GetType("GuiDialogTreeComponent")
$m = $type.Methods | Where-Object { $_.Name -eq "UpdateItems" }

for ($i = 0; $i -lt $m.Body.Instructions.Count; $i++) {
    $instr = $m.Body.Instructions[$i]
    if ($instr.Offset -ge 0x01B0 -and $instr.Offset -le 0x0240) {
        Write-Host "$($instr.Offset.ToString('X4')): $($instr.OpCode) $($instr.Operand)"
    }
}
