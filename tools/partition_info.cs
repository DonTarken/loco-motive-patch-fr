using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class PartitionInfo {
    static void Main() {
        var allLines = File.ReadAllLines(@"translations\dialogues\dialogues_all.tsv");
        var chapters = new Dictionary<string, int>();

        for (int i = 1; i < allLines.Length; i++) {
            var parts = allLines[i].Split('\t');
            if (parts.Length < 6) continue;
            string className = parts[4];
            string method = parts[5];
            string combined = className + " " + method;

            string tag = "Other";
            if (combined.IndexOf("Prologue", StringComparison.OrdinalIgnoreCase) >= 0 || combined.IndexOf("Intro", StringComparison.OrdinalIgnoreCase) >= 0) tag = "Prologue";
            else if (combined.IndexOf("ChapterOne", StringComparison.OrdinalIgnoreCase) >= 0 || combined.IndexOf("ActOne", StringComparison.OrdinalIgnoreCase) >= 0) tag = "Chapter 1";
            else if (combined.IndexOf("ChapterTwo", StringComparison.OrdinalIgnoreCase) >= 0 || combined.IndexOf("ActTwo", StringComparison.OrdinalIgnoreCase) >= 0) tag = "Chapter 2";
            else if (combined.IndexOf("ChapterThree", StringComparison.OrdinalIgnoreCase) >= 0 || combined.IndexOf("ActThree", StringComparison.OrdinalIgnoreCase) >= 0) tag = "Chapter 3";
            else if (combined.IndexOf("ChapterFour", StringComparison.OrdinalIgnoreCase) >= 0 || combined.IndexOf("ActFour", StringComparison.OrdinalIgnoreCase) >= 0) tag = "Chapter 4";
            else if (combined.IndexOf("ChapterFive", StringComparison.OrdinalIgnoreCase) >= 0 || combined.IndexOf("ActFive", StringComparison.OrdinalIgnoreCase) >= 0) tag = "Chapter 5";
            else if (combined.IndexOf("ChapterSix", StringComparison.OrdinalIgnoreCase) >= 0 || combined.IndexOf("ActSix", StringComparison.OrdinalIgnoreCase) >= 0) tag = "Chapter 6";
            else if (combined.IndexOf("Finale", StringComparison.OrdinalIgnoreCase) >= 0 || combined.IndexOf("DisputeResolution", StringComparison.OrdinalIgnoreCase) >= 0) tag = "Finale";

            if (!chapters.ContainsKey(tag)) chapters[tag] = 0;
            chapters[tag]++;
        }

        foreach (var kv in chapters.OrderBy(k => k.Key)) {
            Console.WriteLine(string.Format("{0,-15}: {1} lines", kv.Key, kv.Value));
        }
    }
}
