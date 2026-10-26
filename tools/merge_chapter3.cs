using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class MergeChapter3 {
    static void Main() {
        string rawPath = @"translations\partitions\chapter3_raw.tsv";
        if (!File.Exists(rawPath)) {
            Console.WriteLine("Raw file not found: " + rawPath);
            return;
        }

        var translations = new Dictionary<string, string>();

        string[] existingFiles = new string[] {
            @"translations\dialogues\prologue_french.tsv",
            @"translations\dialogues\chapter1_french.tsv",
            @"translations\dialogues\chapter2_french.tsv",
            @"translations\dialogues\inventory_french.tsv",
            @"translations\partitions\c3_b1_french.tsv",
            @"translations\partitions\c3_b2_french.tsv",
            @"translations\partitions\c3_b3_french.tsv"
        };

        foreach (var file in existingFiles) {
            if (!File.Exists(file)) continue;
            var lines = File.ReadAllLines(file, Encoding.UTF8);
            for (int i = 1; i < lines.Length; i++) {
                var p = lines[i].Split('\t');
                if (p.Length >= 4) {
                    string en = p[2].Trim();
                    string fr = p[3].Trim();
                    if (!string.IsNullOrEmpty(fr)) {
                        translations[en] = fr;
                    }
                }
            }
        }

        Console.WriteLine(string.Format("Loaded {0} unique translations from batches and dialogues.", translations.Count));

        var rawLines = File.ReadAllLines(rawPath, Encoding.UTF8);
        int total = 0;
        int translated = 0;
        var missing = new List<string>();

        using (var sw = new StreamWriter(@"translations\dialogues\chapter3_french.tsv", false, Encoding.UTF8)) {
            sw.WriteLine("Id\tCharacter\tEnglish\tFrench\tClass\tMethod");
            for (int i = 1; i < rawLines.Length; i++) {
                var line = rawLines[i];
                var p = line.Split('\t');
                if (p.Length < 6) continue;
                total++;
                string id = p[0];
                string character = p[1];
                string en = p[2].Trim();
                string cls = p[4];
                string method = p[5];

                string fr = "";
                if (translations.ContainsKey(en)) {
                    fr = translations[en];
                    translated++;
                } else {
                    missing.Add(line);
                    fr = en;
                }

                sw.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", id, character, en, fr, cls, method));
            }
        }

        Console.WriteLine(string.Format("Chapter 3 Merged: {0} / {1} translated ({2:F1}%)",
            translated, total, (double)translated / total * 100.0));

        if (missing.Count > 0) {
            Console.WriteLine(string.Format("Missing lines in Chapter 3: {0}", missing.Count));
            using (var sw = new StreamWriter(@"translations\partitions\chapter3_still_missing.tsv", false, Encoding.UTF8)) {
                sw.WriteLine("Id\tCharacter\tEnglish\tFrench\tClass\tMethod");
                foreach (var m in missing) sw.WriteLine(m);
            }
        }
    }
}
