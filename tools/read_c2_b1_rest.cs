using System;
using System.IO;

class ReadC2B1Rest {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\partitions\c2_b1_hintline.tsv");
        for (int i = 40; i < lines.Length; i++) {
            var parts = lines[i].Split('\t');
            Console.WriteLine(string.Format("{0,3}: {1,-10} | {2}", i, parts[1], parts[2]));
        }
    }
}
