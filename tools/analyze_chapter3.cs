using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class AnalyzeChapter3 {
    static void Main() {
        var dict = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        string[] existingFiles = new string[] {
            @"translations\dialogues\prologue_french.tsv",
            @"translations\dialogues\chapter1_french.tsv",
            @"translations\dialogues\chapter2_french.tsv",
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

        var c3Lines = File.ReadAllLines(@"translations\partitions\chapter3_raw.tsv", Encoding.UTF8);
        int total = 0;
        int matched = 0;
        var missingLines = new List<string>();
        var missingUnique = new HashSet<string>();

        for (int i = 1; i < c3Lines.Length; i++) {
            var l = c3Lines[i];
            var p = l.Split('\t');
            if (p.Length < 6) continue;
            total++;
            string en = p[2].Trim();
            if (dict.Contains(en)) {
                matched++;
            } else {
                missingLines.Add(l);
                missingUnique.Add(en);
            }
        }

        Console.WriteLine(string.Format("Chapter 3 Total: {0}, Matched: {1}, Missing: {2} ({3} unique)",
            total, matched, missingLines.Count, missingUnique.Count));

        using (var sw = new StreamWriter(@"translations\partitions\chapter3_missing.tsv", false, Encoding.UTF8)) {
            sw.WriteLine("Id\tCharacter\tEnglish\tFrench\tClass\tMethod");
            foreach (var m in missingLines) sw.WriteLine(m);
        }
    }
}
