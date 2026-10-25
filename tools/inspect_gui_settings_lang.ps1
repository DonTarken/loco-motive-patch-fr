Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"

$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll", $readerParams)

$type = $module.GetType("GuiSettings")
Write-Host "=== GuiSettings Language methods ===" -ForegroundColor Cyan
foreach ($m in $type.Methods) {
    if ($m.Name -like "*Language*" -or $m.Name -like "*Text*") {
        Write-Host "Method: $($m.FullName)"
        if ($m.HasBody) {
            foreach ($i in $m.Body.Instructions) {
                if ($i.OpCode.Name -like "*call*" -or $i.OpCode.Name -like "*ldfld*" -or $i.OpCode.Name -like "*stfld*") {
                    Write-Host "   $($i.OpCode) $($i.Operand)"
                }
            }
        }
    }
}
