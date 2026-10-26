using System;
using System.IO;
using System.Collections.Generic;

class Program {
    static HashSet<string> translated = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

    static void LoadTsv(string path) {
        if (!File.Exists(path)) return;
        foreach (var line in File.ReadAllLines(path)) {
            if (string.IsNullOrWhiteSpace(line)) continue;
            var parts = line.Split('\t');
            if (parts.Length >= 4) {
                translated.Add(parts[2].Trim());
            } else if (parts.Length >= 2) {
                translated.Add(parts[0].Trim());
            }
        }
    }

    static void Main() {
        LoadTsv(@"translations\dialogues\prologue_french.tsv");
        LoadTsv(@"translations\ui\ui_french.tsv");
        LoadTsv(@"translations\dialogues\test_intro_fr.tsv");
        
        Console.WriteLine("Loaded " + translated.Count + " translated keys.");
        
        // Check unhandled lines
        var missingUnhandled = new List<string>();
        foreach (var line in File.ReadAllLines(@"translations\dialogues\unhandled_strings.tsv")) {
            var parts = line.Split('\t');
            if (parts.Length >= 2) {
                string s = parts[1].Trim();
                if (s.Length > 1 && !translated.Contains(s) && !s.StartsWith("unhandled") && s != "Title") {
                    missingUnhandled.Add(parts[0] + "\t" + s);
                }
            }
        }
        
        Console.WriteLine("\n=== Missing Unhandled Lines: " + missingUnhandled.Count + " ===");
        foreach (var s in missingUnhandled) Console.WriteLine("  " + s);
        
        // Check inventory lines
        var missingInventory = new List<string>();
        foreach (var line in File.ReadAllLines(@"translations\dialogues\extracted_inventory_strings.tsv")) {
            var parts = line.Split('\t');
            if (parts.Length >= 3) {
                string s = parts[2].Trim();
                if (s.Length > 1 && !translated.Contains(s) && !s.StartsWith("Use") && !s.StartsWith("Reveal") && !s.StartsWith("Disguised") && !s.StartsWith("Mixing") && !s.StartsWith("FaceCamera") && !s.StartsWith("ActTwo") && !s.StartsWith("puzzle_") && !s.StartsWith("Mouth") && !s.StartsWith("Talk") && !s.StartsWith("Inventory") && !s.StartsWith("OnTake")) {
                    missingInventory.Add(parts[0] + "\t" + parts[1] + "\t" + s);
                }
            }
        }
        
        Console.WriteLine("\n=== Missing Inventory Lines: " + missingInventory.Count + " ===");
        File.WriteAllLines(@"translations\dialogues\missing_inventory_lines.tsv", missingInventory.ToArray());
        Console.WriteLine("Saved missing inventory lines to translations\\dialogues\\missing_inventory_lines.tsv");
        
        // Let's filter ones relevant to Prologue & Chapter 1
        string[] prologueItems = new string[] { 
            "Newspaper", "Fan", "Umbrella", "AnkletKey", "Chains", "FunnelFan", 
            "Coffee", "Tea", "LetterToArthur", "BlueSuit", "Keys" 
        };
        Console.WriteLine("\n--- Missing Prologue/Early Inventory Lines ---");
        foreach (var s in missingInventory) {
            foreach (var item in prologueItems) {
                if (s.StartsWith("Inventory" + item + "\t")) {
                    Console.WriteLine("  " + s);
                    break;
                }
            }
        }
    }
}
