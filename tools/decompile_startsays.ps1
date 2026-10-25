Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"

$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll", $readerParams)
$charType = $module.GetType("PowerTools.Quest.Character")

foreach ($m in $charType.Methods) {
    if ($m.Name -eq "StartSay" -or $m.Name -eq "StartSayNoSkip") {
        Write-Host "`n=== Method: $($m.FullName) ===" -ForegroundColor Cyan
        foreach ($instr in $m.Body.Instructions) {
            if ($instr.OpCode.Name -like "*call*" -or $instr.OpCode.Name -like "*ldarg*") {
                Write-Host "$($instr.Offset.ToString('X4')): $($instr.OpCode) $($instr.Operand)"
            }
        }
    }
}
