using System;
using System.IO;

class ReadC2B1 {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\partitions\c2_b1_hintline.tsv");
        for (int i = 0; i < Math.Min(40, lines.Length); i++) {
            var parts = lines[i].Split('\t');
            Console.WriteLine(string.Format("{0,-10} | {1}", parts[1], parts[2]));
        }
    }
}
