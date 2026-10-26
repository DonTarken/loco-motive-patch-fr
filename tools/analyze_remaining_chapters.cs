using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class AnalyzeRemaining {
    static void Main() {
        var dict = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        string[] existingFiles = new string[] {
            @"translations\dialogues\prologue_french.tsv",
            @"translations\dialogues\chapter1_french.tsv",
            @"translations\dialogues\chapter2_french.tsv",
            @"translations\dialogues\chapter3_french.tsv",
            @"translations\dialogues\inventory_french.tsv",
            @"translations\glossary_items.tsv"
        };
        foreach (var f in existingFiles) {
            if (!File.Exists(f)) continue;
            var lines = File.ReadAllLines(f, Encoding.UTF8);
            foreach (var l in lines) {
                var p = l.Split('\t');
                if (p.Length >= 4 && !string.IsNullOrEmpty(p[3])) {
                    dict.Add(p[2].Trim());
                }
            }
        }

        string[] chapters = new string[] {
            @"translations\partitions\chapter4_raw.tsv",
            @"translations\partitions\chapter5_raw.tsv",
            @"translations\partitions\chapter6_raw.tsv",
            @"translations\partitions\chapter7_raw.tsv"
        };

        foreach (var chPath in chapters) {
            if (!File.Exists(chPath)) continue;
            var chLines = File.ReadAllLines(chPath, Encoding.UTF8);
            int total = 0;
            int matched = 0;
            var missing = new List<string>();

            for (int i = 1; i < chLines.Length; i++) {
                var p = chLines[i].Split('\t');
                if (p.Length < 6) continue;
                total++;
                string en = p[2].Trim();
                if (dict.Contains(en)) {
                    matched++;
                } else {
                    missing.Add(chLines[i]);
                }
            }

            Console.WriteLine(string.Format("{0}: Total={1}, Matched={2}, Missing={3}",
                Path.GetFileName(chPath), total, matched, missing.Count));

            string outMissing = chPath.Replace("_raw.tsv", "_missing.tsv");
            using (var sw = new StreamWriter(outMissing, false, Encoding.UTF8)) {
                sw.WriteLine("Id\tCharacter\tEnglish\tFrench\tClass\tMethod");
                foreach (var m in missing) sw.WriteLine(m);
            }
        }
    }
}
