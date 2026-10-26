using System;
using System.IO;

class ReadB4Part5 {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\partitions\c1_b4_unterwald_quarters.tsv");
        for (int i = 240; i < lines.Length; i++) {
            var parts = lines[i].Split('\t');
            Console.WriteLine(string.Format("{0,3}: {1,-12} | {2}", i, parts[1], parts[2]));
        }
    }
}
