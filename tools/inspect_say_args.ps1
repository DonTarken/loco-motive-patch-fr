Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"

$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll", $readerParams)

$type = $module.GetType("RoomLoungeCarriage/<OnEnterAfterFadePrologueUnterwaldSpeech>d__33")
$m = $type.Methods | Where-Object { $_.Name -eq "MoveNext" }

for ($i = 0; $i -lt $m.Body.Instructions.Count; $i++) {
    $instr = $m.Body.Instructions[$i]
    if ($instr.OpCode.Name -like "*call*" -and $instr.Operand -like "*Say*") {
        $prev1 = $m.Body.Instructions[$i-1]
        $prev2 = $m.Body.Instructions[$i-2]
        Write-Host "Call to $($instr.Operand):"
        Write-Host "   Arg text: $($prev2.OpCode) '$($prev2.Operand)'"
        Write-Host "   Arg int:  $($prev1.OpCode) '$($prev1.Operand)'"
    }
}
