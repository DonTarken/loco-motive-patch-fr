using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class InspectC2Details {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\partitions\chapter2_raw.tsv");
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
        loadTsv(@"translations\dialogues\chapter1_french.tsv");

        var missing = new List<string>();
        var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var byChar = new Dictionary<string, int>();

        for (int i = 1; i < lines.Length; i++) {
            var parts = lines[i].Split('\t');
            if (parts.Length < 6) continue;
            string ch = parts[1];
            string en = parts[2].Trim();
            if (!existing.Contains(en) && !seen.Contains(en)) {
                seen.Add(en);
                missing.Add(lines[i]);
                if (!byChar.ContainsKey(ch)) byChar[ch] = 0;
                byChar[ch]++;
            }
        }

        Console.WriteLine(string.Format("Chapter 2 Total: {0}, Unique missing: {1}", lines.Length - 1, missing.Count));
        Console.WriteLine("\nCharacters with missing lines:");
        foreach (var kv in byChar.OrderByDescending(x => x.Value)) {
            Console.WriteLine(string.Format("  {0,-15} : {1,4} lines", kv.Key, kv.Value));
        }

        File.WriteAllLines(@"translations\partitions\chapter2_missing.tsv", missing.ToArray());
    }
}
