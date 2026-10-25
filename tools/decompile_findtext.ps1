Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"

$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll", $readerParams)
$sysText = $module.GetType("PowerTools.Quest.SystemText")

$m = $sysText.Methods | Where-Object { $_.Name -eq "FindTextDataInternal" }
Write-Host "=== Method: $($m.FullName) ===" -ForegroundColor Cyan
foreach ($instr in $m.Body.Instructions) {
    Write-Host "$($instr.Offset.ToString('X4')): $($instr.OpCode) $($instr.Operand)"
}
