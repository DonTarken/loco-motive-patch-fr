$dllPath = "D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll"
Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"

$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule($dllPath, $readerParams)

$found = @()
foreach ($t in $module.Types) {
    foreach ($m in $t.Methods) {
        if ($m.HasBody) {
            foreach ($i in $m.Body.Instructions) {
                if ($i.OpCode.Name -eq "ldstr" -and $i.Operand -ne $null) {
                    $s = $i.Operand.ToString()
                    if ($s -like "*hands are clean*" -or $s -like "*ugly crier*" -or $s -like "*entitled to a phone call*") {
                        $found += [PSCustomObject]@{
                            Type = $t.FullName
                            Method = $m.Name
                            String = $s
                        }
                    }
                }
            }
        }
    }
}

Write-Host "Found in Assembly-CSharp.dll: $($found.Count)"
$found | Format-Table -AutoSize
