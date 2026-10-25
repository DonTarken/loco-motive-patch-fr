Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"

$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Projects.Plugins.PowerQuest.dll", $readerParams)

Write-Host "=== Types in Projects.Plugins.PowerQuest.dll ==="
foreach ($t in $module.Types) {
    if ($t.Name -like "*Dialog*" -or $t.Name -like "*Option*" -or $t.Name -like "*Choice*") {
        Write-Host "Type: $($t.FullName)"
        foreach ($m in $t.Methods) {
            if ($m.IsPublic) {
                Write-Host "   Method: $($m.Name)"
            }
        }
    }
}

$module2 = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll", $readerParams)
Write-Host "`n=== Types in Assembly-CSharp.dll ==="
foreach ($t in $module2.Types) {
    if ($t.Name -like "*Dialog*" -or $t.Name -like "*GuiDialog*" -or $t.Name -like "*Choice*") {
        Write-Host "Type: $($t.FullName)"
        foreach ($m in $t.Methods) {
            if ($m.IsPublic) {
                Write-Host "   Method: $($m.Name)"
            }
        }
    }
}
