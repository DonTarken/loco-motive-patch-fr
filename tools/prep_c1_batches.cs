using System;
using System.IO;
using System.Collections.Generic;

class PrepC1Batches {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\partitions\chapter1_raw.tsv");
        var existing = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        // Load existing translations
        Action<string> loadTsv = (p) => {
            if (!File.Exists(p)) return;
            foreach (var l in File.ReadAllLines(p)) {
                if (string.IsNullOrWhiteSpace(l)) continue;
                var parts = l.Split('\t');
                if (parts.Length == 2) existing[parts[0].Trim()] = parts[1].Trim();
                else if (parts.Length >= 4 && parts[0] != "Id") existing[parts[2].Trim()] = parts[3].Trim();
            }
        };

        loadTsv(@"translations\dialogues\prologue_french.tsv");
        loadTsv(@"translations\dialogues\inventory_french.tsv");
        loadTsv(@"translations\dialogues\test_intro_fr.tsv");
        loadTsv(@"translations\ui\ui_french.tsv");

        var missing = new List<string>();
        var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        for (int i = 1; i < lines.Length; i++) {
            var parts = lines[i].Split('\t');
            if (parts.Length < 6) continue;
            string en = parts[2].Trim();
            if (!existing.ContainsKey(en) && !seen.Contains(en)) {
                seen.Add(en);
                missing.Add(lines[i]);
            }
        }

        Console.WriteLine("Unique lines in Chapter 1 still needing translation: " + missing.Count);
        File.WriteAllLines(@"translations\partitions\chapter1_missing.tsv", missing.ToArray());
        Console.WriteLine("Saved to translations\\partitions\\chapter1_missing.tsv");
    }
}
