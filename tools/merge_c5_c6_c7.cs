using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class MergeC5C6C7 {
    static void Main() {
        var translations = new Dictionary<string, string>();

        string[] existingFiles = new string[] {
            @"translations\dialogues\prologue_french.tsv",
            @"translations\dialogues\chapter1_french.tsv",
            @"translations\dialogues\chapter2_french.tsv",
            @"translations\dialogues\chapter3_french.tsv",
            @"translations\dialogues\chapter4_french.tsv",
            @"translations\dialogues\inventory_french.tsv",
            @"translations\partitions\c5_french.tsv",
            @"translations\partitions\c6_french.tsv",
            @"translations\partitions\c7_french.tsv"
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

        Console.WriteLine(string.Format("Loaded {0} unique translations.", translations.Count));

        MergeChapter(5, @"translations\partitions\chapter5_raw.tsv", @"translations\dialogues\chapter5_french.tsv", translations);
        MergeChapter(6, @"translations\partitions\chapter6_raw.tsv", @"translations\dialogues\chapter6_french.tsv", translations);
        MergeChapter(7, @"translations\partitions\chapter7_raw.tsv", @"translations\dialogues\chapter7_french.tsv", translations);
    }

    static void MergeChapter(int num, string rawPath, string outPath, Dictionary<string, string> dict) {
        if (!File.Exists(rawPath)) return;
        var rawLines = File.ReadAllLines(rawPath, Encoding.UTF8);
        int total = 0;
        int translated = 0;

        using (var sw = new StreamWriter(outPath, false, Encoding.UTF8)) {
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
                if (dict.ContainsKey(en)) {
                    fr = dict[en];
                    translated++;
                } else {
                    Console.WriteLine(string.Format("C{0} Missing: [{1}]", num, en));
                    fr = en;
                }

                sw.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", id, character, en, fr, cls, method));
            }
        }

        Console.WriteLine(string.Format("Chapter {0} Merged: {1} / {2} translated ({3:F1}%)",
            num, translated, total, (double)translated / total * 100.0));
    }
}
