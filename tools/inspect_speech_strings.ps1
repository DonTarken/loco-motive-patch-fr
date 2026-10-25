Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"

$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll", $readerParams)

$type = $module.GetType("RoomLoungeCarriage/<OnEnterAfterFadePrologueUnterwaldSpeech>d__33")
Write-Host "Type: $($type.FullName)"
$m = $type.Methods | Where-Object { $_.Name -eq "MoveNext" }

foreach ($instr in $m.Body.Instructions) {
    if ($instr.OpCode.Name -eq "ldstr") {
        Write-Host "ldstr: '$($instr.Operand)'"
    } elseif ($instr.OpCode.Name -like "*call*" -and $instr.Operand -like "*Say*") {
        Write-Host "CALL: $($instr.Operand)"
    }
}
