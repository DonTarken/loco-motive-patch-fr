$asm = [System.Reflection.Assembly]::LoadFrom('D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll')
$type = $asm.GetType('PowerTools.Quest.SystemText')
$methods = $type.GetMethods([System.Reflection.BindingFlags]'Public,NonPublic,Instance,Static') | Where-Object { $_.Name -eq 'GetDisplayText' }
foreach ($m in $methods) {
    Write-Host "Method: $($m.ToString())"
    $body = $m.GetMethodBody()
    if ($body) {
        Write-Host "IL length: $($body.GetILAsByteArray().Length)"
    }
}
