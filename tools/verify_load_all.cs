using System;
using System.IO;
using System.Collections.Generic;

class VerifyLoadAll {
    static void Main() {
        var dir = @"translations";
        var tsvFiles = Directory.GetFiles(dir, "*.tsv", SearchOption.AllDirectories);
        var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        Console.WriteLine("Files found: " + tsvFiles.Length);
        foreach (var f in tsvFiles) {
            // Ignore raw/partitions
            if (f.Contains("partitions") || f.Contains("raw") || f.Contains("missing") || f.Contains("dialogues_all")) continue;

            int count = 0;
            foreach (var line in File.ReadAllLines(f)) {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var parts = line.Split('\t');
                if (parts.Length == 2) {
                    string en = parts[0].Trim();
                    string fr = parts[1].Trim();
                    if (!string.IsNullOrEmpty(en) && !string.IsNullOrEmpty(fr)) {
                        dict[en] = fr;
                        count++;
                    }
                } else if (parts.Length >= 4) {
                    if (parts[0] == "Id" && parts[2] == "English") continue;
                    string en = parts[2].Trim();
                    string fr = parts[3].Trim();
                    if (!string.IsNullOrEmpty(en) && !string.IsNullOrEmpty(fr)) {
                        dict[en] = fr;
                        count++;
                    }
                }
            }
            Console.WriteLine(string.Format("  {0,-35} : {1,5} entries", Path.GetFileName(f), count));
        }

        Console.WriteLine("\nTotal unique translated keys loaded across project: " + dict.Count);
    }
}
