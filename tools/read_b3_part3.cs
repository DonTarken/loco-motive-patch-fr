using System;
using System.IO;

class ReadB3Part3 {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\partitions\c1_b3_casino_don.tsv");
        for (int i = 120; i < lines.Length; i++) {
            var parts = lines[i].Split('\t');
            Console.WriteLine(string.Format("{0,3}: {1,-12} | {2}", i, parts[1], parts[2]));
        }
    }
}
