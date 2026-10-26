using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class AuditFullQuality {
    static void Main() {
        string[] files = new string[] {
            @"translations\glossary_items.tsv",
            @"translations\ui\ui_french.tsv",
            @"translations\dialogues\inventory_french.tsv",
            @"translations\dialogues\prologue_french.tsv",
            @"translations\dialogues\chapter1_french.tsv",
            @"translations\dialogues\chapter2_french.tsv",
            @"translations\dialogues\chapter3_french.tsv",
            @"translations\dialogues\chapter4_french.tsv",
            @"translations\dialogues\chapter5_french.tsv",
            @"translations\dialogues\chapter6_french.tsv",
            @"translations\dialogues\chapter7_french.tsv",
            @"translations\dialogues\shared_french.tsv"
        };

        int totalEntries = 0;
        int emptyFrench = 0;
        int untranslatedSuspects = 0;
        int tagMismatches = 0;

        // Common names / words that are identical in English and French
        var allowedIdentical = new HashSet<string>(StringComparer.OrdinalIgnoreCase) {
            "Arthur", "Diana", "Herman", "Cecil", "Frank", "Thomas", "Florence", "Renshaw",
            "Diana Ackerman", "Arthur Ackerman", "Herman Merman", "Lady Unterwald", "Unterwald",
            "Dirk Chiselton", "Dr. Flint", "Inspector Rose", "Madame Rose", "Mademoiselle",
            "Pardon ?", "Pardon", "Non", "Oui", "Chut !", "Chut...", "Chut", "...", "…",
            "Mmh ?", "Mmh", "Hmm", "Hmm...", "Hmm ?", "Ah !", "Ah", "Oh !", "Oh", "Eh bien !",
            "STOP !", "STOP", "Bravo !", "Bravo", "Silence !", "Silence", "Contact !", "Contact",
            "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "OK", "Ok", "Non !", "Oui !",
            "Rosebud", "Capitaine", "Garde", "Barman", "Dirk", "Vicky", "Eileen", "Tante Unterwald"
        };

        foreach (var file in files) {
            if (!File.Exists(file)) {
                Console.WriteLine("Missing file: " + file);
                continue;
            }

            var lines = File.ReadAllLines(file, Encoding.UTF8);
            for (int i = 0; i < lines.Length; i++) {
                var line = lines[i];
                if (string.IsNullOrWhiteSpace(line)) continue;
                if (i == 0 && (line.StartsWith("Id\t") || line.StartsWith("English\t"))) continue;

                var parts = line.Split('\t');
                string en = "";
                string fr = "";

                if (parts.Length == 2) {
                    en = parts[0].Trim();
                    fr = parts[1].Trim();
                } else if (parts.Length >= 4) {
                    en = parts[2].Trim();
                    fr = parts[3].Trim();
                } else {
                    continue;
                }

                totalEntries++;

                if (string.IsNullOrEmpty(fr)) {
                    emptyFrench++;
                    Console.WriteLine(string.Format("[EMPTY] {0} L{1}: {2}", Path.GetFileName(file), i + 1, en));
                    continue;
                }

                // Check identical
                if (string.Equals(en, fr, StringComparison.OrdinalIgnoreCase) && en.Length > 3 && !allowedIdentical.Contains(en)) {
                    // Check if it's multiple words or sentences
                    if (en.Contains(" ") || en.EndsWith(".") || en.EndsWith("!") || en.EndsWith("?")) {
                        untranslatedSuspects++;
                        Console.WriteLine(string.Format("[IDENTICAL] {0} L{1}: [{2}] -> [{3}]", Path.GetFileName(file), i + 1, en, fr));
                    }
                }

                // Check tags: {0}, {1}, <color=...>, <sprite=...>
                var enVars = Regex.Matches(en, @"\{[0-9]+\}");
                var frVars = Regex.Matches(fr, @"\{[0-9]+\}");
                if (enVars.Count != frVars.Count) {
                    tagMismatches++;
                    Console.WriteLine(string.Format("[TAG VAR MISMATCH] {0} L{1}: EN={2} vs FR={3}", Path.GetFileName(file), i + 1, en, fr));
                }

                var enSprites = Regex.Matches(en, @"<sprite=[0-9]+>");
                var frSprites = Regex.Matches(fr, @"<sprite=[0-9]+>");
                if (enSprites.Count != frSprites.Count) {
                    tagMismatches++;
                    Console.WriteLine(string.Format("[SPRITE TAG MISMATCH] {0} L{1}: EN={2} vs FR={3}", Path.GetFileName(file), i + 1, en, fr));
                }
            }
        }

        Console.WriteLine("\n=== AUDIT SUMMARY ===");
        Console.WriteLine("Total Entries Checked: " + totalEntries);
        Console.WriteLine("Empty French: " + emptyFrench);
        Console.WriteLine("Untranslated Suspects: " + untranslatedSuspects);
        Console.WriteLine("Tag/Variable Mismatches: " + tagMismatches);
    }
}
