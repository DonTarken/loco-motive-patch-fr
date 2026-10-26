using System;
using System.IO;
using System.Collections.Generic;

class SplitC2Batches {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\partitions\chapter2_missing.tsv");
        var b1 = new List<string>();
        var b2 = new List<string>();
        var b3 = new List<string>();
        var b4 = new List<string>();

        foreach (var l in lines) {
            var parts = l.Split('\t');
            if (parts.Length < 6) continue;
            string cls = parts[4];
            if (cls.Contains("HintLine")) {
                b1.Add(l);
            } else if (cls.Contains("Publisher") || cls.Contains("Board") || (parts[1] == "Herman" && (cls.Contains("Herman") || cls.Contains("Mansion") || cls.Contains("Office")))) {
                b2.Add(l);
            } else if (cls.Contains("JianLiu") || cls.Contains("Chiselton") || cls.Contains("Masson") || cls.Contains("Artist") || cls.Contains("Arista") || cls.Contains("Lamont") || cls.Contains("Bailey")) {
                b3.Add(l);
            } else {
                b4.Add(l);
            }
        }

        File.WriteAllLines(@"translations\partitions\c2_b1_hintline.tsv", b1.ToArray());
        File.WriteAllLines(@"translations\partitions\c2_b2_herman_board.tsv", b2.ToArray());
        File.WriteAllLines(@"translations\partitions\c2_b3_interrogations.tsv", b3.ToArray());
        File.WriteAllLines(@"translations\partitions\c2_b4_scenes.tsv", b4.ToArray());

        Console.WriteLine(string.Format("C2 Batches created:\n  B1 Hintline: {0}\n  B2 Herman/Board: {1}\n  B3 Interrogations: {2}\n  B4 Scenes: {3}\n  Total: {4}",
            b1.Count, b2.Count, b3.Count, b4.Count, b1.Count + b2.Count + b3.Count + b4.Count));
    }
}
