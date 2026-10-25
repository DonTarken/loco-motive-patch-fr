Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"

$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll", $readerParams)

$type = $module.GetType("PowerTools.Quest.SystemText")
$m = $type.Methods | Where-Object { $_.Name -eq "Awake" }
if ($m) {
    Write-Host "SystemText.Awake IL instructions:"
    foreach ($i in $m.Body.Instructions) {
        if ($i.OpCode.Name -eq "ldstr" -or $i.OpCode.Name -like "*call*") {
            Write-Host "   $($i.OpCode) $($i.Operand)"
        }
    }
}
