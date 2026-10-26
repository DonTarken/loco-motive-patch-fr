using System;
using System.IO;

class CheckMissingB3 {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\partitions\c1_b3_french.tsv");
        for (int i = 1; i < lines.Length; i++) {
            var parts = lines[i].Split('\t');
            if (parts.Length >= 4 && parts[2] == parts[3]) {
                Console.WriteLine("Missing: " + parts[1] + " | " + parts[2]);
            }
        }
    }
}
