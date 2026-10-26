using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class MergeShared {
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
            if (!File.Exists(pf)) {
                Console.WriteLine("Warning: missing partition file " + pf);
                continue;
            }
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
        string outPath = @"translations\dialogues\shared_french.tsv";
        int translatedCount = 0;
        int missingCount = 0;

        using (var sw = new StreamWriter(outPath, false, new UTF8Encoding(false))) {
            sw.WriteLine("Id\tCharacter\tEnglish\tFrench\tClass\tMethod");
            for (int i = 1; i < rawLines.Length; i++) {
                var l = rawLines[i];
                var p = l.Split('\t');
                if (p.Length < 6) continue;
                string id = p[0].Trim();
                string ch = p[1].Trim();
                string en = p[2].Trim();
                string cls = p[4].Trim();
                string meth = p[5].Trim();

                string key = cls + "\t" + meth + "\t" + en;
                string fr = "";

                if (partitionMap.ContainsKey(key)) {
                    fr = partitionMap[key];
                } else if (textFallback.ContainsKey(en)) {
                    fr = textFallback[en];
                }

                if (string.IsNullOrEmpty(fr)) {
                    missingCount++;
                    Console.WriteLine(string.Format("Missing: [{0}] in {1}.{2}", en, cls, meth));
                    fr = en;
                } else {
                    translatedCount++;
                }

                sw.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", id, ch, en, fr, cls, meth));
            }
        }

        Console.WriteLine(string.Format("\nDone! Written to {0}", outPath));
        Console.WriteLine(string.Format("Translated: {0} / {1} ({2:P1})", translatedCount, rawLines.Length - 1, (double)translatedCount / (rawLines.Length - 1)));
        Console.WriteLine(string.Format("Missing: {0}", missingCount));
    }
}
