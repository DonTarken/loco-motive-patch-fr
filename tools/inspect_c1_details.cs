using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class InspectC1Details {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\partitions\chapter1_raw.tsv");
        var byChar = new Dictionary<string, List<string>>();
        for (int i = 1; i < lines.Length; i++) {
            var parts = lines[i].Split('\t');
            if (parts.Length < 4) continue;
            string ch = parts[1];
            string en = parts[2];
            if (!byChar.ContainsKey(ch)) byChar[ch] = new List<string>();
            byChar[ch].Add(en);
        }

        Console.WriteLine("Chapter 1 Characters breakdown:");
        foreach (var kv in byChar.OrderByDescending(x => x.Value.Count)) {
            Console.WriteLine(string.Format("  {0,-15} : {1,4} lines", kv.Key, kv.Value.Count));
        }
    }
}
