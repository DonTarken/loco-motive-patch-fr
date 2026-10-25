$asm = [System.Reflection.Assembly]::LoadFrom('D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll')
$type = $asm.GetType('PowerTools.Quest.SystemText')
$m = $type.GetMethod('GetDisplayText', [System.Reflection.BindingFlags]'Public,NonPublic,Instance')
$bytes = $m.GetMethodBody().GetILAsByteArray()

Write-Host "GetDisplayText IL bytes:"
$instructions = @()
for ($i = 0; $i -lt $bytes.Length; $i++) {
    # Print basic info
}
Write-Host "Method parameters:"
foreach ($p in $m.GetParameters()) {
    Write-Host "   $($p.ParameterType.Name) $($p.Name)"
}
