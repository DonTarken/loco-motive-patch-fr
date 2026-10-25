Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"

# Load TSV
$tsvLines = Get-Content "translations\dialogues\prologue_french.tsv" -Encoding UTF8
$tsvEn = New-Object System.Collections.Generic.HashSet[string]
foreach ($l in $tsvLines) {
    $parts = $l -split "`t"
    if ($parts.Count -ge 4 -and $parts[0] -match '^\d+$') {
        # Id, Character, English, French...
        [void]$tsvEn.Add($parts[2].Trim())
    } elseif ($parts.Count -ge 2) {
        [void]$tsvEn.Add($parts[0].Trim())
    }
}
Write-Host "Loaded $($tsvEn.Count) unique English phrases from prologue_french.tsv."

$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll", $readerParams)
$types = $module.Types | Where-Object { $_.Name -eq "RoomInterrogation" -or $_.Name -eq "DialogLamontQuestioning" }

$missing = @()
foreach ($parent in $types) {
    $all = @($parent) + $parent.NestedTypes
    foreach ($t in $all) {
        foreach ($m in $t.Methods) {
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
                                if ($s.Length -gt 1 -and !$s.StartsWith("Speech") -and !$s.StartsWith("Idle") -and !$s.Contains("shake") -and !$s.Contains("=")) {
                                    if (!$tsvEn.Contains($s)) {
                                        # Also find character
                                        $charName = "Narrator/Unknown"
                                        for ($k = $i - 1; $k -ge [Math]::Max(0, $i - 15); $k--) {
                                            if ($instructions[$k].Operand -ne $null -and $instructions[$k].Operand.ToString() -like "*C::get_*") {
                                                $charName = $instructions[$k].Operand.ToString() -replace ".*C::get_([a-zA-Z0-9_]+)\(\).*", '$1'
                                                break
                                            }
                                        }
                                        $missing += [PSCustomObject]@{
                                            Type = $t.Name
                                            Method = $m.Name
                                            Char = $charName
                                            Text = $s
                                        }
                                    }
                                }
                                break
                            }
                        }
                    }
                }
            }
        }
    }
}
Write-Host "Missing count: $($missing.Count)"
$missing | Format-Table -AutoSize
