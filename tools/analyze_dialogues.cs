using System;
using System.IO;
using System.Collections.Generic;

class Program {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\dialogues\dialogues_all.tsv");
        var uniqueTexts = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var charCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        var classCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        
        int translatedCount = 0;
        for (int i = 1; i < lines.Length; i++) {
            var parts = lines[i].Split('\t');
            if (parts.Length < 3) continue;
            string chr = parts[1].Trim();
            string en = parts[2].Trim();
            string fr = parts.Length > 3 ? parts[3].Trim() : "";
            string cls = parts.Length > 4 ? parts[4].Trim() : "";
            
            uniqueTexts.Add(en);
            if (!string.IsNullOrEmpty(fr)) translatedCount++;
            
            if (!charCounts.ContainsKey(chr)) charCounts[chr] = 0;
            charCounts[chr]++;
            
            // extract base class name
            int plusIdx = cls.IndexOf('+');
            string baseCls = plusIdx > 0 ? cls.Substring(0, plusIdx) : cls;
            if (!classCounts.ContainsKey(baseCls)) classCounts[baseCls] = 0;
            classCounts[baseCls]++;
        }
        
        Console.WriteLine("Total lines in dialogues_all.tsv: " + (lines.Length - 1));
        Console.WriteLine("Unique English texts: " + uniqueTexts.Count);
        Console.WriteLine("Already translated in this file: " + translatedCount);
        
        Console.WriteLine("\nTop characters:");
        var topChars = new List<KeyValuePair<string, int>>(charCounts);
        topChars.Sort((a, b) => b.Value.CompareTo(a.Value));
        for (int i = 0; i < Math.Min(15, topChars.Count); i++) {
            Console.WriteLine("  " + topChars[i].Key + " : " + topChars[i].Value);
        }
        
        Console.WriteLine("\nTop classes:");
        var topClasses = new List<KeyValuePair<string, int>>(classCounts);
        topClasses.Sort((a, b) => b.Value.CompareTo(a.Value));
        for (int i = 0; i < Math.Min(15, topClasses.Count); i++) {
            Console.WriteLine("  " + topClasses[i].Key + " : " + topClasses[i].Value);
        }
    }
}
