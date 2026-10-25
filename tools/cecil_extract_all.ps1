Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"

$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll", $readerParams)

$found = @()
$seen = New-Object System.Collections.Generic.HashSet[string]

foreach ($type in $module.Types) {
    # Check type and nested types
    $typesToCheck = New-Object System.Collections.Generic.List[Mono.Cecil.TypeDefinition]
    $typesToCheck.Add($type)
    foreach ($nested in $type.NestedTypes) {
        $typesToCheck.Add($nested)
    }

    foreach ($t in $typesToCheck) {
        foreach ($m in $t.Methods) {
            if (!$m.HasBody) { continue }
            $instructions = $m.Body.Instructions
            for ($i = 0; $i -lt $instructions.Count; $i++) {
                $instr = $instructions[$i]
                if ($instr.OpCode.Name -like "*call*" -and $instr.Operand -ne $null) {
                    $opName = $instr.Operand.ToString()
                    if ($opName -like "*::Say*" -or $opName -like "*::SayBG*" -or $opName -like "*::SayNoSkip*" -or $opName -like "*::Display*") {
                        # Look back for ldstr
                        $text = $null
                        $charName = "Narrator/Unknown"
                        
                        # Find previous ldstr within 10 instructions
                        for ($j = $i - 1; $j -ge [Math]::Max(0, $i - 12); $j--) {
                            $prev = $instructions[$j]
                            if ($prev.OpCode.Name -eq "ldstr" -and $prev.Operand -ne $null) {
                                $s = $prev.Operand.ToString()
                                # Ignore animation names, audio names, tags
                                if ($s.Length -gt 1 -and !$s.StartsWith("Speech") -and !$s.StartsWith("Idle") -and !$s.Contains("shake") -and !$s.Contains("=")) {
                                    $text = $s
                                    break
                                }
                            }
                        }

                        # Check if character is identifiable
                        for ($j = $i - 1; $j -ge [Math]::Max(0, $i - 15); $j--) {
                            $prev = $instructions[$j]
                            if ($prev.Operand -ne $null -and $prev.Operand.ToString() -like "*C::get_*") {
                                $charName = $prev.Operand.ToString() -replace ".*C::get_([a-zA-Z0-9_]+)\(\).*", '$1'
                                break
                            }
                        }

                        if ($text -ne $null) {
                            $key = "$charName:::$text"
                            if (!$seen.Contains($key)) {
                                $seen.Add($key) | Out-Null
                                $found += [PSCustomObject]@{
                                    Character = $charName
                                    Text = $text
                                    Class = $t.FullName
                                    Method = $m.Name
                                    Target = $opName
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

Write-Host "Total dialogue calls extracted via Cecil: $($found.Count)"
$prologueCalls = $found | Where-Object { 
    $_.Class -like "*Prologue*" -or 
    $_.Class -like "*LoungeCarriage*" -or 
    $_.Class -like "*ArthurQuarters*" -or 
    $_.Class -like "*UnterwaldCarriage*" -or 
    $_.Class -like "*IntroCarriage*" -or 
    $_.Class -like "*Interrogation*"
}
Write-Host "Prologue dialogue calls: $($prologueCalls.Count)"

$prologueCalls | Export-Csv -Path "translations\dialogues\prologue_cecil_extracted.csv" -NoTypeInformation -Encoding UTF8
Write-Host "Exported to translations\dialogues\prologue_cecil_extracted.csv"
