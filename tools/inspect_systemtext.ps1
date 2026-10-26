$asm = [System.Reflection.Assembly]::LoadFrom("D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll")
$t = $asm.GetType("PowerTools.Quest.SystemText")
Write-Host "=== Fields in SystemText ==="
$t.GetFields([System.Reflection.BindingFlags]"Public,NonPublic,Instance,Static") | ForEach-Object {
    Write-Host "$($_.Name) : $($_.FieldType.FullName)"
}
Write-Host "=== Methods in SystemText ==="
$t.GetMethods([System.Reflection.BindingFlags]"Public,NonPublic,Instance,Static") | ForEach-Object {
    Write-Host "$($_.Name) ($([string]::Join(', ', ($_.GetParameters() | ForEach-Object { $_.ParameterType.Name + ' ' + $_.Name })))) : $($_.ReturnType.Name)"
}
