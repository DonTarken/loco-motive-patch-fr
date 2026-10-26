using System;
using System.IO;
using System.Collections.Generic;

class DumpC1Lines {
    static void Main(string[] args) {
        string targetClass = args.Length > 0 ? args[0] : "CharacterArista";
        var lines = File.ReadAllLines(@"translations\partitions\chapter1_raw.tsv");
        for (int i = 1; i < lines.Length; i++) {
            var parts = lines[i].Split('\t');
            if (parts.Length < 6) continue;
            string cls = parts[4].Split('+')[0];
            if (cls.IndexOf(targetClass, StringComparison.OrdinalIgnoreCase) >= 0) {
                Console.WriteLine(string.Format("{0}\t{1}\t{2}", parts[0], parts[1], parts[2]));
            }
        }
    }
}
