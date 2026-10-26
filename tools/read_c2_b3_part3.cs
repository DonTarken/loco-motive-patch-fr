using System;
using System.IO;

class ReadC2B3Part3 {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\partitions\c2_b3_interrogations.tsv");
        for (int i = 120; i < lines.Length; i++) {
            var parts = lines[i].Split('\t');
            Console.WriteLine(string.Format("{0,3}: {1,-12} | {2}", i, parts[1], parts[2]));
        }
    }
}
