using System;
using System.IO;
using System.Collections.Generic;

class Program {
    static void Main() {
        string dir = @"D:\Games\Loco Motive\BepInEx\plugins\LocoMotiveFR_Data";
        var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var file in Directory.GetFiles(dir, "*.tsv")) {
            int lines = 0;
            foreach (var line in File.ReadAllLines(file)) {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var parts = line.Split('\t');
                if (parts.Length >= 4 && !string.IsNullOrEmpty(parts[2])) {
                    dict[parts[2].Trim()] = parts[3].Trim();
                    lines++;
                } else if (parts.Length >= 2 && !string.IsNullOrEmpty(parts[0])) {
                    dict[parts[0].Trim()] = parts[1].Trim();
                    lines++;
                }
            }
            Console.WriteLine(Path.GetFileName(file) + " : " + lines + " entries");
        }
        Console.WriteLine("\nTotal unique translated keys loaded: " + dict.Count);
    }
}
