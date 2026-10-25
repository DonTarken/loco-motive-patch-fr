Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"

$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll", $readerParams)

$type = $module.GetType("GlobalScript")
if (!$type) { $type = $module.GetType("QuestGlobalScript") }
if (!$type) { 
    $type = $module.Types | Where-Object { $_.Name -like "*Global*" } | Select-Object -First 1 
}

if ($type) {
    Write-Host "Found: $($type.FullName)"
    foreach ($f in $type.Fields) {
        Write-Host "   Field: $($f.FieldType.Name) $($f.Name)"
    }
}
