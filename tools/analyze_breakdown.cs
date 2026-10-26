using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class AnalyzeBreakdown {
    static void Main() {
        var existing = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        
        Action<string> loadTsv = (path) => {
            if (!File.Exists(path)) return;
            foreach (var line in File.ReadAllLines(path)) {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var parts = line.Split('\t');
                if (parts.Length == 2) {
                    if (!string.IsNullOrWhiteSpace(parts[0]) && !string.IsNullOrWhiteSpace(parts[1]))
                        existing[parts[0].Trim()] = parts[1].Trim();
                } else if (parts.Length >= 4) {
                    if (parts[0] == "Id" && parts[2] == "English") continue;
                    string en = parts[2].Trim();
                    string fr = parts[3].Trim();
                    if (!string.IsNullOrWhiteSpace(en) && !string.IsNullOrWhiteSpace(fr)) {
                        existing[en] = fr;
                    }
                }
            }
        };

        loadTsv(@"translations\dialogues\prologue_french.tsv");
        loadTsv(@"translations\dialogues\inventory_french.tsv");
        loadTsv(@"translations\dialogues\test_intro_fr.tsv");
        loadTsv(@"translations\ui\ui_french.tsv");
        loadTsv(@"translations\dialogues\chapter1_french.tsv");

        Console.WriteLine("Total unique translated entries correctly parsed: " + existing.Count);

        // Read dialogues_all.tsv
        var allLines = File.ReadAllLines(@"translations\dialogues\dialogues_all.tsv");
        
        int total = 0;
        int alreadyCovered = 0;
        var classCount = new Dictionary<string, int>();
        var classUncovered = new Dictionary<string, int>();

        for (int i = 1; i < allLines.Length; i++) {
            var parts = allLines[i].Split('\t');
            if (parts.Length < 3) continue;
            total++;
            string en = parts[2].Trim();
            string className = parts.Length > 4 ? parts[4] : "Unknown";
            
            string cleanClass = className.Split('+')[0];

            if (!classCount.ContainsKey(cleanClass)) classCount[cleanClass] = 0;
            classCount[cleanClass]++;

            if (existing.ContainsKey(en)) {
                alreadyCovered++;
            } else {
                if (!classUncovered.ContainsKey(cleanClass)) classUncovered[cleanClass] = 0;
                classUncovered[cleanClass]++;
            }
        }

        Console.WriteLine(string.Format("Dialogues total: {0}, Already covered: {1}, Remaining to translate: {2}", 
            total, alreadyCovered, total - alreadyCovered));

        Console.WriteLine("\nTop 30 Classes with remaining lines to translate:");
        var top = classUncovered.OrderByDescending(kv => kv.Value).Take(30);
        foreach (var kv in top) {
            Console.WriteLine(string.Format("  {0,-35} : {1,4} remaining (out of {2})", 
                kv.Key, kv.Value, classCount[kv.Key]));
        }
    }
}
