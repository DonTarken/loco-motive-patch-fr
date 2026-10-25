Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"

$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll", $readerParams)

$type = $module.Types | Where-Object { $_.Name -eq "ePrologueProgression" }
Write-Host "Enum: $($type.FullName)"
foreach ($f in $type.Fields) {
    if ($f.IsStatic) {
        Write-Host "   $($f.Name) = $($f.Constant)"
    }
}
