using System;
using System.IO;

class ReadB1Range {
    static void Main(string[] args) {
        int start = args.Length > 0 ? int.Parse(args[0]) : 40;
        int count = args.Length > 1 ? int.Parse(args[1]) : 40;
        var lines = File.ReadAllLines(@"translations\partitions\c1_b1_handshake.tsv");
        for (int i = start; i < Math.Min(start + count, lines.Length); i++) {
            var parts = lines[i].Split('\t');
            Console.WriteLine(string.Format("{0,3}: {1,-12} | {2}", i, parts[1], parts[2]));
        }
    }
}
