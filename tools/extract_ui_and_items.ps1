param(
    [string]$GamePath = "D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll",
    [string]$OutputDir = "$PSScriptRoot\..\translations"
)

$ErrorActionPreference = "Stop"

Write-Host "=== Extraction des chaînes UI et Objets de Loco Motive ===" -ForegroundColor Cyan

$code = @'
using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

public class UiItemExtractor {
    public class TextEntry {
        public string En { get; set; }
        public string Fr { get; set; }
        public string Category { get; set; }
        public string Source { get; set; }
    }

    public static List<TextEntry> ExtractUI(string dllPath) {
        var results = new List<TextEntry>();
        var seen = new HashSet<string>();
        var asm = Assembly.LoadFrom(dllPath);
        var mod = asm.ManifestModule;

        foreach (var type in asm.GetTypes()) {
            bool isUI = type.FullName.StartsWith("Gui") || type.FullName.StartsWith("PowerTools.Quest.Gui") || type.FullName.StartsWith("PowerTools.Quest.QuestSettings");
            bool isItem = type.FullName.StartsWith("Inventory") || type.FullName.StartsWith("Item");

            if (!isUI && !isItem) continue;

            string cat = isUI ? "UI" : "Item";

            foreach (var m in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly)) {
                var body = m.GetMethodBody();
                if (body == null) continue;
                var il = body.GetILAsByteArray();

                for (int i = 0; i < il.Length; i++) {
                    if (il[i] == 0x72 && i + 4 < il.Length) {
                        int token = BitConverter.ToInt32(il, i + 1);
                        try {
                            string s = mod.ResolveString(token);
                            if (!string.IsNullOrEmpty(s)) {
                                string trimmed = s.Trim();
                                // Filter out internal engine identifiers (starts with Btn, Img, Con, Lbl, or internal names)
                                if (trimmed.Length >= 2 && !seen.Contains(trimmed)) {
                                    bool isProbableText = trimmed.Contains(" ") || (!trimmed.StartsWith("Btn") && !trimmed.StartsWith("Img") && !trimmed.StartsWith("Con") && !trimmed.StartsWith("Lbl") && !trimmed.StartsWith("m_") && !trimmed.StartsWith("anim_"));
                                    if (isProbableText && !trimmed.Contains(".prefab") && !trimmed.Contains(".png") && !trimmed.Contains(".wav") && !trimmed.Contains(".ogg")) {
                                        seen.Add(trimmed);
                                        results.Add(new TextEntry {
                                            En = trimmed,
                                            Fr = "",
                                            Category = cat,
                                            Source = type.Name + "." + m.Name
                                        });
                                    }
                                }
                            }
                        } catch {}
                        i += 4;
                    }
                }
            }
        }
        return results;
    }
}
'@

Add-Type -TypeDefinition $code -Language CSharp
$entries = [UiItemExtractor]::ExtractUI($GamePath)

$uiEntries = $entries | Where-Object { $_.Category -eq "UI" }
$itemEntries = $entries | Where-Object { $_.Category -eq "Item" }

Write-Host "Chaînes UI trouvées : $($uiEntries.Count)" -ForegroundColor Green
Write-Host "Chaînes Items trouvées : $($itemEntries.Count)" -ForegroundColor Green

# Sauvegarde
$uiJson = Join-Path $OutputDir "ui\ui_strings.json"
$uiEntries | ConvertTo-Json -Depth 5 | Set-Content -Path $uiJson -Encoding UTF8

$itemJson = Join-Path $OutputDir "items\items_strings.json"
$itemEntries | ConvertTo-Json -Depth 5 | Set-Content -Path $itemJson -Encoding UTF8

Write-Host "Fichiers UI et Items sauvegardés avec succès !" -ForegroundColor Cyan
