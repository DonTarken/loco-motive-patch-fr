using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class PartitionChapter3 {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\partitions\chapter3_missing.tsv", Encoding.UTF8);
        var charCounts = new Dictionary<string, int>();
        var classCounts = new Dictionary<string, int>();

        for (int i = 1; i < lines.Length; i++) {
            var p = lines[i].Split('\t');
            if (p.Length < 6) continue;
            string ch = p[1];
            string cls = p[4];
            if (!charCounts.ContainsKey(ch)) charCounts[ch] = 0;
            charCounts[ch]++;
            if (!classCounts.ContainsKey(cls)) classCounts[cls] = 0;
            classCounts[cls]++;
        }

        Console.WriteLine("Characters in Chapter 3:");
        foreach (var kv in charCounts.OrderByDescending(x => x.Value)) {
            Console.WriteLine(string.Format("  {0}: {1}", kv.Key, kv.Value));
        }

        Console.WriteLine("\nTop Classes in Chapter 3:");
        foreach (var kv in classCounts.OrderByDescending(x => x.Value).Take(15)) {
            Console.WriteLine(string.Format("  {0}: {1}", kv.Key, kv.Value));
        }
    }
}
