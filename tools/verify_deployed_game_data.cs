using System;
using System.IO;
using System.Collections.Generic;

class VerifyDeployedGameData {
    static void Main() {
        string dir = @"D:\Games\Loco Motive\BepInEx\plugins\LocoMotiveFR_Data";
        if (!Directory.Exists(dir)) {
            Console.WriteLine("Directory does not exist: " + dir);
            return;
        }

        var files = Directory.GetFiles(dir, "*.tsv", SearchOption.AllDirectories);
        var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        Console.WriteLine("=== Verification des fichiers deployes dans le jeu ===");
        Console.WriteLine("Nombre de fichiers TSV trouves : " + files.Length);

        foreach (var f in files) {
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
            Console.WriteLine(string.Format("  {0,-30} : {1,5} entrees valides", Path.GetFileName(f), count));
        }

        Console.WriteLine("\nTotal absolu de cles traduites injectees en jeu : " + dict.Count);
    }
}
