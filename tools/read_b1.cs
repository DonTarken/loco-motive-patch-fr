using System;
using System.IO;

class ReadB1 {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\partitions\c1_b1_handshake.tsv");
        for (int i = 0; i < Math.Min(40, lines.Length); i++) {
            var parts = lines[i].Split('\t');
            Console.WriteLine(string.Format("{0,-12} | {1}", parts[1], parts[2]));
        }
    }
}
