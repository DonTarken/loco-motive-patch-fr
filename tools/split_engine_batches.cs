using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

class SplitEngineBatches {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\unique_missing_engine.tsv", Encoding.UTF8);

        WriteBatch(@"translations\partitions\engine_b1.tsv", lines, 1, 400);
        WriteBatch(@"translations\partitions\engine_b2.tsv", lines, 401, 800);
        WriteBatch(@"translations\partitions\engine_b3.tsv", lines, 801, lines.Length - 1);

        Console.WriteLine("Done splitting engine batches.");
    }

    static void WriteBatch(string path, string[] lines, int start, int end) {
        using (var sw = new StreamWriter(path, false, Encoding.UTF8)) {
            sw.WriteLine(lines[0]);
            for (int i = start; i <= end && i < lines.Length; i++) {
                sw.WriteLine(lines[i]);
            }
        }
        Console.WriteLine(string.Format("Wrote {0}: {1} lines", Path.GetFileName(path), Math.Min(end, lines.Length - 1) - start + 1));
    }
}
