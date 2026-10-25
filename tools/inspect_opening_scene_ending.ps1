Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"

$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll", $readerParams)

$t = $module.Types | Where-Object { $_.Name -eq "DialogOpeningSceneEnding" }
$types = @($t) + $t.NestedTypes

Write-Host "DialogOpeningSceneEnding methods and strings:"
foreach ($type in $types) {
    foreach ($m in $type.Methods) {
        if (!$m.HasBody) { continue }
        $instructions = $m.Body.Instructions
        for ($i = 0; $i -lt $instructions.Count; $i++) {
            $instr = $instructions[$i]
            if ($instr.OpCode.Name -like "*call*" -and $instr.Operand -ne $null) {
                $op = $instr.Operand.ToString()
                if ($op -like "*::Say*" -or $op -like "*::Display*") {
                    for ($j = $i - 1; $j -ge [Math]::Max(0, $i - 10); $j--) {
                        if ($instructions[$j].OpCode.Name -eq "ldstr" -and $instructions[$j].Operand -ne $null) {
                            $s = $instructions[$j].Operand.ToString().Trim()
                            Write-Host "  in $($type.Name)::$($m.Name): `"$s`""
                            break
                        }
                    }
                }
            }
        }
    }
}
