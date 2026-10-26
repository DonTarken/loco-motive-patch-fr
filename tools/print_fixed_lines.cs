using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

class PrintFixedLines {
    static void Main() {
        var partitionMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        var textFallback = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        string[] partitionFiles = new string[] {
            @"translations\partitions\shared_room_looks_french.tsv",
            @"translations\partitions\shared_char_interactions_french.tsv",
            @"translations\partitions\shared_cutscenes_french.tsv",
            @"translations\partitions\shared_item_uses_french.tsv",
            @"translations\partitions\sd_b1_french.tsv",
            @"translations\partitions\sd_b2_french.tsv",
            @"translations\partitions\sd_b3_french.tsv",
            @"translations\partitions\sd_b4_french.tsv"
        };

        foreach (var pf in partitionFiles) {
            var lines = File.ReadAllLines(pf, Encoding.UTF8);
            for (int i = 1; i < lines.Length; i++) {
                var p = lines[i].Split('\t');
                if (p.Length < 6) continue;
                string en = p[2].Trim();
                string fr = p[3].Trim();
                string cls = p[4].Trim();
                string meth = p[5].Trim();

                if (!string.IsNullOrEmpty(fr)) {
                    string key = cls + "\t" + meth + "\t" + en;
                    partitionMap[key] = fr;
                    textFallback[en] = fr;
                }
            }
        }

        string[] baseFiles = new string[] {
            @"translations\dialogues\prologue_french.tsv",
            @"translations\dialogues\chapter1_french.tsv",
            @"translations\dialogues\chapter2_french.tsv",
            @"translations\dialogues\chapter3_french.tsv",
            @"translations\dialogues\chapter4_french.tsv",
            @"translations\dialogues\chapter5_french.tsv",
            @"translations\dialogues\chapter6_french.tsv",
            @"translations\dialogues\chapter7_french.tsv",
            @"translations\dialogues\inventory_french.tsv",
            @"translations\glossary_items.tsv"
        };

        foreach (var f in baseFiles) {
            if (!File.Exists(f)) continue;
            foreach (var l in File.ReadAllLines(f, Encoding.UTF8)) {
                var p = l.Split('\t');
                if (p.Length >= 4) {
                    if (p[0] == "Id" && p[2] == "English") continue;
                    string en = p[2].Trim();
                    string fr = p[3].Trim();
                    if (!string.IsNullOrEmpty(en) && !string.IsNullOrEmpty(fr) && !textFallback.ContainsKey(en)) {
                        textFallback[en] = fr;
                    }
                }
            }
        }

        var rawLines = File.ReadAllLines(@"translations\partitions\shared_raw.tsv", Encoding.UTF8);
        int[] checkIndices = new int[] { 3, 22, 24, 31, 50, 71, 81, 449, 466 };

        foreach (var idx in checkIndices) {
            var p = rawLines[idx].Split('\t');
            string en = p[2].Trim();
            string cls = p[4].Trim();
            string meth = p[5].Trim();
            string key = cls + "\t" + meth + "\t" + en;
            string fr = partitionMap.ContainsKey(key) ? partitionMap[key] : textFallback[en];
            Console.WriteLine(string.Format("L{0} [{1}] EN: [{2}] -> FR: [{3}]", idx, p[0], en, fr));
        }
    }
}
