using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class AnalyzeOther {
    static void Main() {
        var allLines = File.ReadAllLines(@"translations\dialogues\dialogues_all.tsv");
        var otherClasses = new Dictionary<string, int>();

        for (int i = 1; i < allLines.Length; i++) {
            var parts = allLines[i].Split('\t');
            if (parts.Length < 6) continue;
            string className = parts[4];
            string method = parts[5];
            string combined = className + " " + method;

            bool isSpecific = false;
            if (combined.IndexOf("Prologue", StringComparison.OrdinalIgnoreCase) >= 0 || combined.IndexOf("Intro", StringComparison.OrdinalIgnoreCase) >= 0
                || combined.IndexOf("ChapterOne", StringComparison.OrdinalIgnoreCase) >= 0 || combined.IndexOf("ActOne", StringComparison.OrdinalIgnoreCase) >= 0
                || combined.IndexOf("ChapterTwo", StringComparison.OrdinalIgnoreCase) >= 0 || combined.IndexOf("ActTwo", StringComparison.OrdinalIgnoreCase) >= 0
                || combined.IndexOf("ChapterThree", StringComparison.OrdinalIgnoreCase) >= 0 || combined.IndexOf("ActThree", StringComparison.OrdinalIgnoreCase) >= 0
                || combined.IndexOf("ChapterFour", StringComparison.OrdinalIgnoreCase) >= 0 || combined.IndexOf("ActFour", StringComparison.OrdinalIgnoreCase) >= 0
                || combined.IndexOf("ChapterFive", StringComparison.OrdinalIgnoreCase) >= 0 || combined.IndexOf("ActFive", StringComparison.OrdinalIgnoreCase) >= 0
                || combined.IndexOf("ChapterSix", StringComparison.OrdinalIgnoreCase) >= 0 || combined.IndexOf("ActSix", StringComparison.OrdinalIgnoreCase) >= 0
                || combined.IndexOf("Finale", StringComparison.OrdinalIgnoreCase) >= 0 || combined.IndexOf("DisputeResolution", StringComparison.OrdinalIgnoreCase) >= 0) {
                isSpecific = true;
            }

            if (!isSpecific) {
                string baseClass = className.Split('+')[0];
                if (!otherClasses.ContainsKey(baseClass)) otherClasses[baseClass] = 0;
                otherClasses[baseClass]++;
            }
        }

        Console.WriteLine("Top 35 Classes in 'Other':");
        foreach (var kv in otherClasses.OrderByDescending(x => x.Value).Take(35)) {
            Console.WriteLine(string.Format("  {0,-35} : {1,4} lines", kv.Key, kv.Value));
        }
    }
}
