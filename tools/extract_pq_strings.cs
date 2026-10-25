using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class ExtractPowerQuestStrings {
    static void Main() {
        string assetPath = @"D:\Games\Loco Motive\Loco Motive_Data\data.unity3d";
        byte[] bytes = File.ReadAllBytes(assetPath);
        string text = Encoding.UTF8.GetString(bytes);

        // Pattern: & followed by digits, then space, then readable text up to null or control char
        var matches = Regex.Matches(text, @"&(\d+)\s+([A-Za-z0-9][^\x00-\x1F\x7F-\x9F""]{1,200})");
        Console.WriteLine("Total matches found: " + matches.Count);

        var unique = new Dictionary<string, int>();
        foreach (Match m in matches) {
            string content = m.Groups[2].Value.Trim();
            if (content.Length >= 2 && !content.Contains("{") && !content.StartsWith("http")) {
                if (!unique.ContainsKey(content)) {
                    unique[content] = int.Parse(m.Groups[1].Value);
                }
            }
        }

        Console.WriteLine("Unique text entries: " + unique.Count);
        int count = 0;
        foreach (var kvp in unique) {
            if (count < 30) {
                Console.WriteLine("  [" + kvp.Value + "] " + kvp.Key);
                count++;
            }
        }
    }
}
