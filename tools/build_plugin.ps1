$csc = "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe"
$outDll = "patch\bin\LocoMotiveFR.dll"
$src = "patch\src\LocoMotiveFR.cs"
$managed = "D:\Games\Loco Motive\Loco Motive_Data\Managed"
$core = "patch\BepInEx_base\BepInEx\core"

$refs = @(
    "$core\BepInEx.dll",
    "$core\0Harmony.dll",
    "$managed\UnityEngine.dll",
    "$managed\UnityEngine.CoreModule.dll",
    "$managed\UnityEngine.InputLegacyModule.dll",
    "$managed\UnityEngine.UI.dll",
    "$managed\Unity.TextMeshPro.dll",
    "$managed\Assembly-CSharp.dll",
    "$managed\Projects.Plugins.PowerQuest.dll"
)

$args = @(
    "/target:library",
    "/out:$outDll",
    "/optimize+",
    "/nologo"
)
foreach ($r in $refs) {
    $args += "/reference:$r"
}
$args += $src

Write-Host "Compilation de $src vers $outDll..." -ForegroundColor Cyan
& $csc $args
if ($LASTEXITCODE -eq 0) {
    Write-Host "Compilation réussie !" -ForegroundColor Green
} else {
    Write-Error "Échec de la compilation."
}
