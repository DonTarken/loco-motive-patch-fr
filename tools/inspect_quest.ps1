$asm = [System.Reflection.Assembly]::LoadFrom("D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll")
function Inspect-Type($name) {
    $t = $asm.GetType($name)
    if ($t -eq $null) { Write-Host "Type not found: $name"; return }
    Write-Host "`n=== Type: $name ==="
    Write-Host "-- Fields --"
    $t.GetFields([System.Reflection.BindingFlags]"Public,NonPublic,Instance,Static") | ForEach-Object {
        Write-Host "$($_.Name) : $($_.FieldType.Name)"
    }
    Write-Host "-- Methods --"
    $t.GetMethods([System.Reflection.BindingFlags]"Public,NonPublic,Instance,Static,DeclaredOnly") | ForEach-Object {
        $params = $_.GetParameters() | ForEach-Object { "$($_.ParameterType.Name) $($_.Name)" }
        Write-Host "$($_.Name) ($([string]::Join(', ', $params))) : $($_.ReturnType.Name)"
    }
}

Inspect-Type "GuiTooltips"
Inspect-Type "GuiHoverText"
Inspect-Type "PowerTools.QuestGui.TooltipSlot"
Inspect-Type "PowerTools.QuestGui.TooltipInfo"
Inspect-Type "PowerTools.QuestGui.TooltipPanel"
