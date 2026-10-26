using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

class MatchEngineStrings {
    static void Main() {
        string enginePath = @"D:\Games\Loco Motive\BepInEx\plugins\LocoMotiveFR_Data\all_engine_strings.tsv";
        var lines = File.ReadAllLines(enginePath, Encoding.UTF8);

        // Load existing clean translations
        var textToFr = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        string[] sourceFiles = new string[] {
            @"translations\glossary_items.tsv",
            @"translations\ui\ui_french.tsv",
            @"translations\dialogues\inventory_french.tsv",
            @"translations\dialogues\prologue_french.tsv",
            @"translations\dialogues\chapter1_french.tsv",
            @"translations\dialogues\chapter2_french.tsv",
            @"translations\dialogues\chapter3_french.tsv",
            @"translations\dialogues\chapter4_french.tsv",
            @"translations\dialogues\chapter5_french.tsv",
            @"translations\dialogues\chapter6_french.tsv",
            @"translations\dialogues\chapter7_french.tsv",
            @"translations\partitions\shared_room_looks_french.tsv",
            @"translations\partitions\shared_char_interactions_french.tsv",
            @"translations\partitions\shared_cutscenes_french.tsv",
            @"translations\partitions\shared_item_uses_french.tsv",
            @"translations\partitions\sd_b1_french.tsv",
            @"translations\partitions\sd_b2_french.tsv",
            @"translations\partitions\sd_b3_french.tsv",
            @"translations\partitions\sd_b4_french.tsv"
        };

        foreach (var f in sourceFiles) {
            if (!File.Exists(f)) continue;
            foreach (var l in File.ReadAllLines(f, Encoding.UTF8)) {
                var p = l.Split('\t');
                if (p.Length >= 4) {
                    if (p[0] == "Id" && p[2] == "English") continue;
                    string en = p[2].Trim();
                    string fr = p[3].Trim();
                    if (!string.IsNullOrEmpty(en) && !string.IsNullOrEmpty(fr)) {
                        textToFr[en] = fr;
                    }
                } else if (p.Length == 2) {
                    string en = p[0].Trim();
                    string fr = p[1].Trim();
                    if (!string.IsNullOrEmpty(en) && !string.IsNullOrEmpty(fr)) {
                        textToFr[en] = fr;
                    }
                }
            }
        }

        Console.WriteLine("Clean translations loaded in dictionary: " + textToFr.Count);

        int total = 0;
        int matched = 0;
        int missing = 0;
        var missingByFunc = new Dictionary<string, List<string>>();

        for (int i = 1; i < lines.Length; i++) {
            var p = lines[i].Split('\t');
            if (p.Length < 5) continue;
            total++;
            string en = p[4].Trim().Replace(" \\n ", "\n");
            string srcFunc = p[3];

            if (string.IsNullOrEmpty(en)) continue;

            if (textToFr.ContainsKey(en)) {
                matched++;
            } else {
                missing++;
                if (!missingByFunc.ContainsKey(srcFunc)) missingByFunc[srcFunc] = new List<string>();
                if (!missingByFunc[srcFunc].Contains(en)) missingByFunc[srcFunc].Add(en);
            }
        }

        Console.WriteLine(string.Format("Engine Total: {0}, Matched: {1} ({2:P1}), Missing: {3}",
            total, matched, (double)matched / total, missing));

        Console.WriteLine("\nMissing by Source Function (unique strings):");
        foreach (var kv in missingByFunc) {
            Console.WriteLine(string.Format("  {0,-35} : {1,4} unique missing", kv.Key, kv.Value.Count));
        }

        // Write missing strings to file for analysis
        using (var sw = new StreamWriter(@"translations\missing_engine_strings.tsv", false, Encoding.UTF8)) {
            sw.WriteLine("SourceFile\tSourceFunction\tEnglish\tGerman");
            for (int i = 1; i < lines.Length; i++) {
                var p = lines[i].Split('\t');
                if (p.Length < 6) continue;
                string en = p[4].Trim();
                if (string.IsNullOrEmpty(en)) continue;
                if (!textToFr.ContainsKey(en)) {
                    sw.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}", p[2], p[3], en, p[5]));
                }
            }
        }
    }
}
