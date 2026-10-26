using System;
using System.IO;

class ReadB3Part2 {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\partitions\c1_b3_casino_don.tsv");
        for (int i = 60; i < Math.Min(120, lines.Length); i++) {
            var parts = lines[i].Split('\t');
            Console.WriteLine(string.Format("{0,3}: {1,-12} | {2}", i, parts[1], parts[2]));
        }
    }
}
