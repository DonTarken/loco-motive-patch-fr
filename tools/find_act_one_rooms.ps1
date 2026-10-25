Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"

$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll", $readerParams)

$actOneRooms = @()
foreach ($t in $module.Types) {
    if ($t.BaseType -ne $null -and $t.BaseType.FullName -like "*RoomScript*") {
        # Check methods in $t and nested types
        $all = @($t) + $t.NestedTypes
        $hasActOne = $false
        foreach ($sub in $all) {
            foreach ($m in $sub.Methods) {
                if ($m.Name -like "*ActOne*") {
                    $hasActOne = $true
                    break
                }
            }
            if ($hasActOne) { break }
        }
        if ($hasActOne) {
            $actOneRooms += $t.Name
        }
    }
}

Write-Host "Rooms with ActOne methods: $($actOneRooms.Count)"
$actOneRooms | ForEach-Object { Write-Host "  $_" }
