using System;
using System.IO;
using System.Collections.Generic;

class AnalyzeC1 {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\partitions\chapter1_raw.tsv");
        var unique = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        for (int i = 1; i < lines.Length; i++) {
            var parts = lines[i].Split('\t');
            if (parts.Length >= 3) unique.Add(parts[2].Trim());
        }
        Console.WriteLine("Chapter 1 total lines: " + (lines.Length - 1) + ", unique: " + unique.Count);
    }
}
