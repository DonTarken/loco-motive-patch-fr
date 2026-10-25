param(
    [string]$GamePath = "D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll",
    [string]$OutputDir = "$PSScriptRoot\..\translations"
)

$ErrorActionPreference = "Stop"

Write-Host "=== Extraction des dialogues de Loco Motive ===" -ForegroundColor Cyan
Write-Host "Fichier cible : $GamePath"

$code = @'
using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

public class Extractor {
    public class DialogueEntry {
        public int Id { get; set; }
        public string En { get; set; }
        public string Fr { get; set; }
        public string Character { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
    }

    public static List<DialogueEntry> Extract(string dllPath) {
        var results = new List<DialogueEntry>();
        var seen = new HashSet<string>();
        var asm = Assembly.LoadFrom(dllPath);
        var mod = asm.ManifestModule;

        foreach (var type in asm.GetTypes()) {
            foreach (var m in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly)) {
                var body = m.GetMethodBody();
                if (body == null) continue;
                var il = body.GetILAsByteArray();
                
                string lastLdstr = null;
                int? lastInt = null;
                string lastChar = null;

                for (int i = 0; i < il.Length; i++) {
                    byte op = il[i];

                    // ldstr (0x72)
                    if (op == 0x72 && i + 4 < il.Length) {
                        int token = BitConverter.ToInt32(il, i + 1);
                        try {
                            lastLdstr = mod.ResolveString(token);
                        } catch {}
                        i += 4;
                        continue;
                    }

                    // ldc.i4 constants
                    if (op >= 0x16 && op <= 0x1E) {
                        lastInt = op - 0x16;
                        continue;
                    }
                    if (op == 0x1F && i + 1 < il.Length) {
                        lastInt = (sbyte)il[i + 1];
                        i += 1;
                        continue;
                    }
                    if (op == 0x20 && i + 4 < il.Length) {
                        lastInt = BitConverter.ToInt32(il, i + 1);
                        i += 4;
                        continue;
                    }

                    // call / callvirt
                    if ((op == 0x28 || op == 0x6F) && i + 4 < il.Length) {
                        int token = BitConverter.ToInt32(il, i + 1);
                        try {
                            var called = mod.ResolveMethod(token);
                            if (called != null) {
                                if (called.Name.StartsWith("get_") && called.DeclaringType != null && called.DeclaringType.Name == "C") {
                                    lastChar = called.Name.Substring(4);
                                }
                                if (called.Name == "Say" && !string.IsNullOrEmpty(lastLdstr) && lastInt.HasValue) {
                                    string key = lastInt.Value.ToString() + ":::" + lastLdstr;
                                    if (!seen.Contains(key)) {
                                        seen.Add(key);
                                        results.Add(new DialogueEntry {
                                            Id = lastInt.Value,
                                            En = lastLdstr,
                                            Fr = "",
                                            Character = lastChar ?? "Narrator/Unknown",
                                            ClassName = type.FullName,
                                            MethodName = m.Name
                                        });
                                    }
                                }
                            }
                        } catch {}
                        i += 4;
                        continue;
                    }
                }
            }
        }
        return results;
    }
}
'@

Add-Type -TypeDefinition $code -Language CSharp
$dialogues = [Extractor]::Extract($GamePath)

Write-Host "Total répliques uniques extraites : $($dialogues.Count)" -ForegroundColor Green

# Statistiques par personnage
$charStats = $dialogues | Group-Object Character | Sort-Object Count -Descending | Select-Object Name, Count

Write-Host "`nTop 10 personnages par nombre de répliques :" -ForegroundColor Yellow
$charStats | Select-Object -First 10 | Format-Table -AutoSize

# Sauvegarde des fichiers
$outAllJson = Join-Path $OutputDir "dialogues\dialogues_all.json"
$dialogues | ConvertTo-Json -Depth 5 | Set-Content -Path $outAllJson -Encoding UTF8
Write-Host "Master dialogues sauvegardé : $outAllJson" -ForegroundColor Cyan

# Sauvegarde d'un fichier TSV facile à éditer ou traduire
$outAllTsv = Join-Path $OutputDir "dialogues\dialogues_all.tsv"
$tsvLines = @("Id`tCharacter`tEnglish`tFrench`tClass`tMethod")
foreach ($d in $dialogues) {
    $cleanEn = $d.En -replace "`t", " " -replace "`r`n", " \n " -replace "`n", " \n "
    $tsvLines += "$($d.Id)`t$($d.Character)`t$cleanEn`t`t$($d.ClassName)`t$($d.MethodName)"
}
$tsvLines | Set-Content -Path $outAllTsv -Encoding UTF8
Write-Host "Fichier TSV sauvegardé : $outAllTsv" -ForegroundColor Cyan

# Sauvegarde des stats
$stats = @{
    TotalLines = $dialogues.Count
    Characters = $charStats
    ExtractedAt = (Get-Date).ToString("o")
}
$stats | ConvertTo-Json -Depth 5 | Set-Content -Path (Join-Path $OutputDir "dialogues\stats.json") -Encoding UTF8
Write-Host "Extraction terminée avec succès !" -ForegroundColor Green
