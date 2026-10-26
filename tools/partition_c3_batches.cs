using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class PartitionC3Batches {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\partitions\chapter3_missing.tsv", Encoding.UTF8);
        var b1 = new List<string>();
        var b2 = new List<string>();
        var b3 = new List<string>();

        // We partition roughly 280 lines each
        int total = lines.Length - 1;
        int chunk = (int)Math.Ceiling(total / 3.0);

        for (int i = 1; i < lines.Length; i++) {
            if (i <= chunk) {
                b1.Add(lines[i]);
            } else if (i <= chunk * 2) {
                b2.Add(lines[i]);
            } else {
                b3.Add(lines[i]);
            }
        }

        WriteBatch(@"translations\partitions\c3_b1_investigation.tsv", b1);
        WriteBatch(@"translations\partitions\c3_b2_inland_handshake.tsv", b2);
        WriteBatch(@"translations\partitions\c3_b3_climax.tsv", b3);

        Console.WriteLine(string.Format("C3 Partitioned: B1={0}, B2={1}, B3={2}", b1.Count, b2.Count, b3.Count));
    }

    static void WriteBatch(string path, List<string> lines) {
        using (var sw = new StreamWriter(path, false, Encoding.UTF8)) {
            sw.WriteLine("Id\tCharacter\tEnglish\tFrench\tClass\tMethod");
            foreach (var l in lines) sw.WriteLine(l);
        }
    }
}
