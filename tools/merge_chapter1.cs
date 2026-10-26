using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class MergeChapter1 {
    static void Main() {
        var rawLines = File.ReadAllLines(@"translations\partitions\chapter1_raw.tsv");
        var translations = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        // Load pre-existing translations
        Action<string> loadTsv = (p) => {
            if (!File.Exists(p)) return;
            foreach (var l in File.ReadAllLines(p)) {
                if (string.IsNullOrWhiteSpace(l)) continue;
                var parts = l.Split('\t');
                if (parts.Length == 2) translations[parts[0].Trim()] = parts[1].Trim();
                else if (parts.Length >= 4 && parts[0] != "Id") {
                    string en = parts[2].Trim();
                    string fr = parts[3].Trim();
                    if (!string.IsNullOrEmpty(en) && !string.IsNullOrEmpty(fr))
                        translations[en] = fr;
                }
            }
        };

        loadTsv(@"translations\dialogues\prologue_french.tsv");
        loadTsv(@"translations\dialogues\inventory_french.tsv");
        loadTsv(@"translations\dialogues\test_intro_fr.tsv");
        loadTsv(@"translations\ui\ui_french.tsv");

        // Load the 4 batches
        loadTsv(@"translations\partitions\c1_b1_french.tsv");
        loadTsv(@"translations\partitions\c1_b2_french.tsv");
        loadTsv(@"translations\partitions\c1_b3_french.tsv");
        loadTsv(@"translations\partitions\c1_b4_french.tsv");

        int total = 0;
        int translated = 0;
        using (var sw = new StreamWriter(@"translations\dialogues\chapter1_french.tsv", false, Encoding.UTF8)) {
            sw.WriteLine(rawLines[0]); // Header
            for (int i = 1; i < rawLines.Length; i++) {
                var parts = rawLines[i].Split('\t');
                if (parts.Length < 6) continue;
                total++;
                string en = parts[2].Trim();
                string fr = "";
                if (translations.ContainsKey(en)) {
                    fr = translations[en];
                    translated++;
                } else {
                    fr = en;
                }
                sw.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", parts[0], parts[1], en, fr, parts[4], parts[5]));
            }
        }

        Console.WriteLine(string.Format("Chapter 1 Merged: {0} / {1} lines translated ({2:P1})",
            translated, total, (double)translated / total));
    }
}
