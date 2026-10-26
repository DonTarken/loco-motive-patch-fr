using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class VerifyDeployedGameData {
    static Dictionary<string, string> textByEnglish = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

    static void Main() {
        string dataDir = @"D:\Games\Loco Motive\BepInEx\plugins\LocoMotiveFR_Data";
        if (!Directory.Exists(dataDir)) {
            Console.WriteLine("Data dir not found: " + dataDir);
            return;
        }

        string[] tsvFiles = Directory.GetFiles(dataDir, "*.tsv", SearchOption.AllDirectories);
        Console.WriteLine("Found " + tsvFiles.Length + " TSV files in deployed game data directory.");

        foreach (var file in tsvFiles) {
            LoadTsvFile(file);
        }

        Console.WriteLine(string.Format("Loaded {0} unique entries into memory.", textByEnglish.Count));

        // Test specific user-reported lines:
        string[] testKeys = new string[] {
            // Interactions from user screenshots:
            "Eavesdrop on the conversation",
            "Browse travel pamphlets",
            "Read carriage directions",
            "the carriage directions",
            "He looks busy",
            "the pamphlets",
            "the plant pot",
            "the dining cart",
            "the statue",
            "Take the wooden hanger",
            "Take the mysterious letter",
            // Dialogue options:
            "Could I escape through the door?",
            "I have some questions about the missing hand idol",
            "Aren't you worried about Mr. Liu?",
            "I thought we'd bonded over our shared love of infrastructure!",
            // Items:
            "Examine Don's room keys",
            "Pore over Lady Unterwald's letter",
            "Read today's newspaper",
            // Hotspot shorthand:
            "the billboard",
            "the merch pile",
            "the desk phone"
        };

        Console.WriteLine("\n=== Verification of Key Strings ===");
        int pass = 0;
        foreach (var key in testKeys) {
            string fr;
            if (textByEnglish.TryGetValue(key, out fr) && !string.IsNullOrEmpty(fr)) {
                Console.WriteLine(string.Format(" [OK] \"{0}\" -> \"{1}\"", key, fr));
                pass++;
            } else {
                Console.WriteLine(string.Format(" [FAIL] \"{0}\" -> NOT FOUND", key));
            }
        }

        Console.WriteLine(string.Format("\nResult: {0}/{1} tested keys verified successfully.", pass, testKeys.Length));
    }

    static void LoadTsvFile(string path) {
        string fileName = Path.GetFileName(path);
        if (fileName.Equals("all_engine_strings.tsv", StringComparison.OrdinalIgnoreCase) ||
            fileName.StartsWith("extracted_", StringComparison.OrdinalIgnoreCase) ||
            fileName.StartsWith("unhandled_", StringComparison.OrdinalIgnoreCase) ||
            fileName.StartsWith("unity_", StringComparison.OrdinalIgnoreCase)) {
            return;
        }

        using (var reader = new StreamReader(path, Encoding.UTF8)) {
            string line;
            bool isFirst = true;
            int enCol = 0;
            int frCol = 1;
            int charCol = -1;
            bool hasExplicitHeader = false;

            while ((line = reader.ReadLine()) != null) {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split('\t');
                if (isFirst) {
                    isFirst = false;
                    string firstCol = parts[0].Trim();
                    if (firstCol.Equals("Id", StringComparison.OrdinalIgnoreCase) || firstCol.Equals("ID", StringComparison.OrdinalIgnoreCase)) {
                        hasExplicitHeader = true;
                        charCol = 1;
                        enCol = 2;
                        frCol = 3;
                        continue;
                    } else if (firstCol.Equals("Character", StringComparison.OrdinalIgnoreCase)) {
                        hasExplicitHeader = true;
                        charCol = 0;
                        enCol = 1;
                        frCol = 2;
                        continue;
                    } else if (firstCol.Equals("ItemKey", StringComparison.OrdinalIgnoreCase)) {
                        hasExplicitHeader = true;
                        charCol = -1;
                        enCol = 1;
                        frCol = 2;
                        continue;
                    } else if (firstCol.Equals("English", StringComparison.OrdinalIgnoreCase) || firstCol.Equals("Key", StringComparison.OrdinalIgnoreCase)) {
                        hasExplicitHeader = true;
                        charCol = -1;
                        enCol = 0;
                        frCol = 1;
                        continue;
                    }
                }

                if (!hasExplicitHeader) {
                    int dummyId;
                    if (parts.Length >= 4 && int.TryParse(parts[0].Trim(), out dummyId)) {
                        charCol = 1;
                        enCol = 2;
                        frCol = 3;
                    } else {
                        charCol = -1;
                        enCol = 0;
                        frCol = 1;
                    }
                }

                if (enCol < parts.Length && frCol < parts.Length) {
                    string character = (charCol >= 0 && charCol < parts.Length) ? parts[charCol].Trim() : null;
                    string en = parts[enCol].Trim().Replace(" \\n ", "\n");
                    string fr = parts[frCol].Trim().Replace(" \\n ", "\n");

                    if (!string.IsNullOrEmpty(en) && !string.IsNullOrEmpty(fr)) {
                        textByEnglish[en] = fr;
                        if (!string.IsNullOrEmpty(character)) {
                            textByEnglish[character + "::" + en] = fr;
                        }
                    }
                }
            }
        }
    }
}
