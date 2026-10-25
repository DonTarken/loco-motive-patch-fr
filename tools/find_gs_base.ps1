Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"
$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll", $readerParams)
$t = $module.GetType("GlobalScriptBase`1")
if ($t) { Write-Host "Found GlobalScriptBase`1 in namespace: '$($t.Namespace)'" }
$t2 = $module.Types | Where-Object { $_.Name -like "*GlobalScriptBase*" }
foreach ($x in $t2) { Write-Host "$($x.FullName)" }
