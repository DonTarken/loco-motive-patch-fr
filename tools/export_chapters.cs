using System;
using System.IO;
using System.Collections.Generic;

class ExportChapters {
    static void Main() {
        var allLines = File.ReadAllLines(@"translations\dialogues\dialogues_all.tsv");
        var header = allLines[0];

        var c1 = new List<string> { header };
        var c2 = new List<string> { header };
        var c3 = new List<string> { header };
        var c4 = new List<string> { header };
        var c5 = new List<string> { header };
        var c6 = new List<string> { header };
        var c7 = new List<string> { header };
        var shared = new List<string> { header };

        for (int i = 1; i < allLines.Length; i++) {
            var parts = allLines[i].Split('\t');
            if (parts.Length < 6) continue;
            string cls = parts[4];
            string method = parts[5];
            string combined = cls + " " + method;

            if (combined.IndexOf("ChapterOne", StringComparison.OrdinalIgnoreCase) >= 0 || combined.IndexOf("ActOne", StringComparison.OrdinalIgnoreCase) >= 0) {
                c1.Add(allLines[i]);
            } else if (combined.IndexOf("ChapterTwo", StringComparison.OrdinalIgnoreCase) >= 0 || combined.IndexOf("ActTwo", StringComparison.OrdinalIgnoreCase) >= 0) {
                c2.Add(allLines[i]);
            } else if (combined.IndexOf("ChapterThree", StringComparison.OrdinalIgnoreCase) >= 0 || combined.IndexOf("ActThree", StringComparison.OrdinalIgnoreCase) >= 0) {
                c3.Add(allLines[i]);
            } else if (combined.IndexOf("ChapterFour", StringComparison.OrdinalIgnoreCase) >= 0 || combined.IndexOf("ActFour", StringComparison.OrdinalIgnoreCase) >= 0) {
                c4.Add(allLines[i]);
            } else if (combined.IndexOf("ChapterFive", StringComparison.OrdinalIgnoreCase) >= 0 || combined.IndexOf("ActFive", StringComparison.OrdinalIgnoreCase) >= 0) {
                c5.Add(allLines[i]);
            } else if (combined.IndexOf("ChapterSix", StringComparison.OrdinalIgnoreCase) >= 0 || combined.IndexOf("ActSix", StringComparison.OrdinalIgnoreCase) >= 0) {
                c6.Add(allLines[i]);
            } else if (combined.IndexOf("Finale", StringComparison.OrdinalIgnoreCase) >= 0 || combined.IndexOf("DisputeResolution", StringComparison.OrdinalIgnoreCase) >= 0 || combined.IndexOf("ChapterSeven", StringComparison.OrdinalIgnoreCase) >= 0) {
                c7.Add(allLines[i]);
            } else {
                shared.Add(allLines[i]);
            }
        }

        Directory.CreateDirectory(@"translations\partitions");
        File.WriteAllLines(@"translations\partitions\chapter1_raw.tsv", c1.ToArray());
        File.WriteAllLines(@"translations\partitions\chapter2_raw.tsv", c2.ToArray());
        File.WriteAllLines(@"translations\partitions\chapter3_raw.tsv", c3.ToArray());
        File.WriteAllLines(@"translations\partitions\chapter4_raw.tsv", c4.ToArray());
        File.WriteAllLines(@"translations\partitions\chapter5_raw.tsv", c5.ToArray());
        File.WriteAllLines(@"translations\partitions\chapter6_raw.tsv", c6.ToArray());
        File.WriteAllLines(@"translations\partitions\chapter7_raw.tsv", c7.ToArray());
        File.WriteAllLines(@"translations\partitions\shared_raw.tsv", shared.ToArray());

        Console.WriteLine(string.Format("Exported:\n  Chapter 1: {0}\n  Chapter 2: {1}\n  Chapter 3: {2}\n  Chapter 4: {3}\n  Chapter 5: {4}\n  Chapter 6: {5}\n  Chapter 7: {6}\n  Shared: {7}",
            c1.Count - 1, c2.Count - 1, c3.Count - 1, c4.Count - 1, c5.Count - 1, c6.Count - 1, c7.Count - 1, shared.Count - 1));
    }
}
