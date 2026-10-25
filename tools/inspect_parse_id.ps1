Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"

$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll", $readerParams)

$type = $module.GetType("PowerTools.Quest.SystemText")
$m = $type.Methods | Where-Object { $_.Name -eq "ParseIdFromText" }
Write-Host "Method: $($m.FullName)"
foreach ($i in $m.Body.Instructions) {
    Write-Host "$($i.Offset.ToString('X4')): $($i.OpCode) $($i.Operand)"
}
