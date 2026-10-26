using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

class TestFixShared {
    static void Main() {
        // Map from partition files by key: Class + "\t" + Method + "\t" + English
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

        // Also load textFallback from base files (prologue, chapters)
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
        int matched = 0;
        int missing = 0;

        for (int i = 1; i < rawLines.Length; i++) {
            var p = rawLines[i].Split('\t');
            if (p.Length < 6) continue;
            string en = p[2].Trim();
            string cls = p[4].Trim();
            string meth = p[5].Trim();

            string key = cls + "\t" + meth + "\t" + en;
            string fr = null;
            if (partitionMap.ContainsKey(key)) {
                fr = partitionMap[key];
            } else if (textFallback.ContainsKey(en)) {
                fr = textFallback[en];
            }

            if (!string.IsNullOrEmpty(fr)) {
                matched++;
            } else {
                missing++;
            }
        }

        Console.WriteLine(string.Format("Raw total: {0}, Matched: {1}, Missing: {2}", rawLines.Length - 1, matched, missing));
    }
}
