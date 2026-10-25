Add-Type -Path "D:\Games\Loco Motive\BepInEx\core\Mono.Cecil.dll"

$readerParams = New-Object Mono.Cecil.ReaderParameters
$module = [Mono.Cecil.ModuleDefinition]::ReadModule("D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll", $readerParams)

$targetTypes = @("DialogMissingWill", "DialogLamontQuestioning", "DialogTalkToArista", "DialogTalkToTwins", "DialogTalkToHirsch")

foreach ($tName in $targetTypes) {
    $t = $module.GetType($tName)
    if ($t) {
        Write-Host "`n=== Type: $tName ===" -ForegroundColor Cyan
        # Check nested types (coroutines for options)
        foreach ($nested in $t.NestedTypes) {
            Write-Host "Nested: $($nested.Name)"
            foreach ($m in $nested.Methods) {
                if ($m.HasBody) {
                    foreach ($i in $m.Body.Instructions) {
                        if ($i.OpCode.Name -eq "ldstr") {
                            Write-Host "   ldstr: '$($i.Operand)'"
                        }
                    }
                }
            }
        }
    }
}
