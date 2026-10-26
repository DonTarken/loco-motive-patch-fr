using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class VerifyCoverage {
    static void Main() {
        var textByEnglish = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        // 1. Load glossary
        LoadGlossary(@"translations\glossary_items.tsv", textByEnglish);

        // 2. Load 2-col UI & interactions
        LoadTwoCol(@"translations\ui\ui_french.tsv", textByEnglish);
        LoadTwoCol(@"translations\ui\interactions_french.tsv", textByEnglish);

        // 3. Load dialogue files
        string[] dialogues = new string[] {
            @"translations\dialogues\inventory_french.tsv",
            @"translations\dialogues\prologue_french.tsv",
            @"translations\dialogues\chapter1_french.tsv",
            @"translations\dialogues\chapter2_french.tsv",
            @"translations\dialogues\chapter3_french.tsv",
            @"translations\dialogues\chapter4_french.tsv",
            @"translations\dialogues\chapter5_french.tsv",
            @"translations\dialogues\chapter6_french.tsv",
            @"translations\dialogues\chapter7_french.tsv",
            @"translations\dialogues\shared_french.tsv"
        };
        foreach (var d in dialogues) {
            LoadDialogue(d, textByEnglish);
        }

        Console.WriteLine(string.Format("Total loaded entries in dictionary: {0}", textByEnglish.Count));

        // 4. Test against all_engine_strings.tsv
        string engineDump = @"D:\Games\Loco Motive\BepInEx\plugins\LocoMotiveFR_Data\all_engine_strings.tsv";
        if (!File.Exists(engineDump)) {
            Console.WriteLine("Engine dump not found at: " + engineDump);
            return;
        }

        var lines = File.ReadAllLines(engineDump, Encoding.UTF8);
        int matched = 0;
        int missing = 0;
        var missingList = new List<string>();

        for (int i = 1; i < lines.Length; i++) {
            var parts = lines[i].Split('\t');
            if (parts.Length < 5) continue;
            string character = parts[1].Trim();
            string en = parts[4].Trim().Replace(" \\n ", "\n");

            if (string.IsNullOrEmpty(en)) continue;

            string fr = null;
            if (!string.IsNullOrEmpty(character)) {
                textByEnglish.TryGetValue(character + "::" + en, out fr);
            }
            if (string.IsNullOrEmpty(fr)) {
                textByEnglish.TryGetValue(en, out fr);
            }
            if (string.IsNullOrEmpty(fr)) {
                textByEnglish.TryGetValue(en.Trim(), out fr);
            }

            if (fr != null && fr.Length > 0) {
                matched++;
            } else {
                missing++;
                missingList.Add(string.Format("{0}\t{1}\t{2}\t{3}\t{4}",
                    en, character, parts[2], parts[3], parts.Length > 5 ? parts[5] : ""));
            }
        }

        File.WriteAllLines(@"tools\all_missing_coverage.tsv", missingList.ToArray(), Encoding.UTF8);

        Console.WriteLine(string.Format("Coverage: {0} matched / {1} missing ({2:P2})",
            matched, missing, (double)matched / (matched + missing)));

        if (missingList.Count > 0) {
            Console.WriteLine("\nFirst few missing items:");
            foreach (var m in missingList) {
                Console.WriteLine(" - " + m);
            }
        }
    }

    static void LoadGlossary(string path, Dictionary<string, string> dict) {
        if (!File.Exists(path)) return;
        var lines = File.ReadAllLines(path, Encoding.UTF8);
        for (int i = 1; i < lines.Length; i++) {
            var p = lines[i].Split('\t');
            if (p.Length >= 3) {
                string en = p[1].Trim();
                string fr = p[2].Trim();
                if (!string.IsNullOrEmpty(en) && !string.IsNullOrEmpty(fr)) {
                    dict[en] = fr;
                }
            }
        }
    }

    static void LoadTwoCol(string path, Dictionary<string, string> dict) {
        if (!File.Exists(path)) return;
        var lines = File.ReadAllLines(path, Encoding.UTF8);
        for (int i = 0; i < lines.Length; i++) {
            var p = lines[i].Split('\t');
            if (p.Length >= 2) {
                string en = p[0].Trim().Replace(" \\n ", "\n");
                string fr = p[1].Trim().Replace(" \\n ", "\n");
                if (i == 0 && (en.Equals("English", StringComparison.OrdinalIgnoreCase) || en.Equals("Key", StringComparison.OrdinalIgnoreCase))) continue;
                if (!string.IsNullOrEmpty(en) && !string.IsNullOrEmpty(fr)) {
                    dict[en] = fr;
                }
            }
        }
    }

    static void LoadDialogue(string path, Dictionary<string, string> dict) {
        if (!File.Exists(path)) return;
        var lines = File.ReadAllLines(path, Encoding.UTF8);
        for (int i = 1; i < lines.Length; i++) {
            var p = lines[i].Split('\t');
            if (p.Length >= 4) {
                string character = p[1].Trim();
                string en = p[2].Trim().Replace(" \\n ", "\n");
                string fr = p[3].Trim().Replace(" \\n ", "\n");
                if (!string.IsNullOrEmpty(en) && !string.IsNullOrEmpty(fr) && fr != en) {
                    dict[en] = fr;
                    if (!string.IsNullOrEmpty(character)) {
                        dict[character + "::" + en] = fr;
                    }
                }
            }
        }
    }
}
