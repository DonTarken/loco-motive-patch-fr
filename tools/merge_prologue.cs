using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class Merger {
    static void Main() {
        string jsonPath = @"translations\dialogues\prologue_translations_add.json";
        string csvPath = @"translations\dialogues\prologue_missing_all.csv";
        string tsvPath = @"translations\dialogues\prologue_french.tsv";

        var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        // Simple JSON parser for "key": "value"
        foreach (var line in File.ReadAllLines(jsonPath, Encoding.UTF8)) {
            var trimmed = line.Trim();
            if (trimmed.StartsWith("\"") && trimmed.Contains("\": \"")) {
                int colonIdx = trimmed.IndexOf("\": \"");
                string key = trimmed.Substring(1, colonIdx - 1);
                string val = trimmed.Substring(colonIdx + 4);
                if (val.EndsWith("\",") || val.EndsWith("\"")) {
                    val = val.TrimEnd(',', '"');
                }
                dict[key] = val;
            }
        }

        Console.WriteLine("Loaded " + dict.Count + " translations from JSON.");

        var existing = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var line in File.ReadAllLines(tsvPath, Encoding.UTF8)) {
            var p = line.Split('\t');
            if (p.Length >= 4) {
                existing.Add(p[2].Trim());
            }
        }

        int added = 0;
        using (var sw = new StreamWriter(tsvPath, true, Encoding.UTF8)) {
            foreach (var line in File.ReadAllLines(csvPath, Encoding.UTF8)) {
                if (line.StartsWith("\"Character\"") || line.StartsWith("Character,")) continue;
                // Parse CSV line: Character,Text,Class,Method,Target
                var parts = line.Split(',');
                if (parts.Length >= 2) {
                    string character = parts[0].Trim('"', ' ');
                    string text = parts[1].Trim('"', ' ');
                    string cls = parts.Length > 2 ? parts[2].Trim('"', ' ') : "";
                    string mth = parts.Length > 3 ? parts[3].Trim('"', ' ') : "";

                    if (dict.ContainsKey(text) && !existing.Contains(text)) {
                        existing.Add(text);
                        string fr = dict[text];
                        sw.WriteLine("0\t" + character + "\t" + text + "\t" + fr + "\t" + cls + "\t" + mth);
                        added++;
                    }
                }
            }
        }

        Console.WriteLine("Added " + added + " new dialogues to " + tsvPath);
    }
}
