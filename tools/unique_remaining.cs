using System;
using System.IO;
using System.Collections.Generic;

class UniqueRemaining {
    static void Main() {
        var existing = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        Action<string> loadTsv = (p) => {
            if (!File.Exists(p)) return;
            foreach (var l in File.ReadAllLines(p)) {
                if (string.IsNullOrWhiteSpace(l)) continue;
                var parts = l.Split('\t');
                if (parts.Length == 2) existing.Add(parts[0].Trim());
                else if (parts.Length >= 4 && parts[0] != "Id") existing.Add(parts[2].Trim());
            }
        };

        loadTsv(@"translations\dialogues\prologue_french.tsv");
        loadTsv(@"translations\dialogues\inventory_french.tsv");
        loadTsv(@"translations\dialogues\test_intro_fr.tsv");
        loadTsv(@"translations\ui\ui_french.tsv");

        var allLines = File.ReadAllLines(@"translations\dialogues\dialogues_all.tsv");
        var remainingUnique = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        for (int i = 1; i < allLines.Length; i++) {
            var parts = allLines[i].Split('\t');
            if (parts.Length < 3) continue;
            string en = parts[2].Trim();
            if (!existing.Contains(en)) {
                remainingUnique.Add(en);
            }
        }

        Console.WriteLine("Remaining UNIQUE English dialogue lines to translate: " + remainingUnique.Count);
    }
}
