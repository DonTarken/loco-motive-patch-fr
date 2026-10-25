Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"

$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll", $readerParams)

$calls = @()
foreach ($type in $module.Types) {
    foreach ($m in $type.Methods) {
        if ($m.HasBody) {
            foreach ($instr in $m.Body.Instructions) {
                if ($instr.OpCode.Name -like "*call*" -and $instr.Operand -ne $null) {
                    $opStr = $instr.Operand.ToString()
                    if ($opStr -like "*GetDisplayText*") {
                        $calls += [PSCustomObject]@{
                            Caller = "$($type.Name)::$($m.Name)"
                            Target = $opStr
                        }
                    }
                }
            }
        }
    }
}

Write-Host "Total calls to GetDisplayText: $($calls.Count)"
foreach ($c in $calls | Select-Object -First 10) {
    Write-Host "   $($c.Caller) -> $($c.Target)"
}
