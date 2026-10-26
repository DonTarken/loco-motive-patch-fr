using System;
using System.IO;

class ReadC2B2 {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\partitions\c2_b2_herman_board.tsv");
        for (int i = 0; i < lines.Length; i++) {
            var parts = lines[i].Split('\t');
            Console.WriteLine(string.Format("{0,2}: {1,-12} | {2}", i, parts[1], parts[2]));
        }
    }
}
