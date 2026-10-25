Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"

$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll", $readerParams)

foreach ($t in $module.Types) {
    if ($t.IsEnum -and ($t.Name -like "*Chapter*" -or $t.Name -like "*Act*" -or $t.Name -like "*Part*")) {
        Write-Host "Enum: $($t.FullName)"
        foreach ($f in $t.Fields) {
            if ($f.IsStatic) {
                Write-Host "   $($f.Name) = $($f.Constant)"
            }
        }
    }
}
