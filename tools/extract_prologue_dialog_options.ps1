Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"

$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll", $readerParams)

$targetTypes = @("DialogLamontQuestioning", "DialogMissingWill", "DialogTalkToArista", "DialogTalkToTwins", "DialogTalkToHirsch", "DialogOpeningSceneEnding")

$optionsFound = @()

foreach ($tName in $targetTypes) {
    $t = $module.GetType($tName)
    if ($t) {
        foreach ($nested in $t.NestedTypes) {
            if ($nested.Name -like "*Option*") {
                foreach ($m in $nested.Methods) {
                    if ($m.HasBody) {
                        # Find first spoken ldstr (typically the player's choice text)
                        for ($i = 0; $i -lt $m.Body.Instructions.Count; $i++) {
                            $instr = $m.Body.Instructions[$i]
                            if ($instr.OpCode.Name -eq "ldstr" -and $instr.Operand -ne $null) {
                                $s = $instr.Operand.ToString()
                                if ($s.Length -gt 1 -and !$s.StartsWith("Speech") -and !$s.StartsWith("Idle") -and !$s.Contains("=") -and !$s.Contains("/") -and !$s.StartsWith("Loop") -and !$s.StartsWith("Take") -and !$s.StartsWith("Chair") -and !$s.StartsWith("Lamont")) {
                                    $optionsFound += [PSCustomObject]@{
                                        Dialog = $tName
                                        OptionMethod = $nested.Name
                                        Text = $s
                                    }
                                    break # Only take the first line (the player prompt)
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

Write-Host "Found $($optionsFound.Count) option prompts:"
$optionsFound | Format-Table -Wrap -AutoSize
$optionsFound | Export-Csv "translations\dialogues\prologue_dialog_options.csv" -NoTypeInformation -Encoding UTF8
