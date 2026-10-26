using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class MergeEngineBatches {
    static void Main() {
        string[] inputs = new string[] {
            @"translations\partitions\engine_b1_french.tsv",
            @"translations\partitions\engine_b2_french.tsv",
            @"translations\partitions\engine_b3_french.tsv"
        };
        string outPath = @"translations\ui\interactions_french.tsv";

        var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        int total = 0;

        using (var sw = new StreamWriter(outPath, false, Encoding.UTF8)) {
            sw.WriteLine("English\tFrench");
            foreach (var inPath in inputs) {
                var lines = File.ReadAllLines(inPath, Encoding.UTF8);
                for (int i = 1; i < lines.Length; i++) {
                    var p = lines[i].Split('\t');
                    if (p.Length < 2) continue;
                    string en = p[0].Trim();
                    string fr = p[1].Trim();

                    if (string.IsNullOrEmpty(en) || string.IsNullOrEmpty(fr)) continue;
                    if (seen.Contains(en)) continue;
                    seen.Add(en);

                    sw.WriteLine(en + "\t" + fr);
                    total++;
                }
            }
        }

        Console.WriteLine("Successfully merged " + total + " unique interaction translations into " + outPath);
    }
}
