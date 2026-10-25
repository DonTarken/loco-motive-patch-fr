Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"

$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll", $readerParams)

$type = $module.GetType("PowerTools.Quest.PowerQuest")
if ($type) {
    Write-Host "Found in Assembly-CSharp.dll!"
    foreach ($m in $type.Methods) {
        if ($m.Name -like "*Dialog*") {
            Write-Host "Method: $($m.FullName)"
        }
    }
}
