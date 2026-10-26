using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class PartitionSharedDialogs {
    static void Main() {
        string inPath = @"translations\partitions\shared_dialogs.tsv";
        if (!File.Exists(inPath)) return;
        var lines = File.ReadAllLines(inPath, Encoding.UTF8);
        int total = lines.Length - 1;

        // Let's divide into 4 parts:
        // Part 1: lines 1 to 410
        // Part 2: lines 411 to 820
        // Part 3: lines 821 to 1230
        // Part 4: lines 1231 to total

        WritePart(lines, 1, 410, @"translations\partitions\sd_b1.tsv");
        WritePart(lines, 411, 820, @"translations\partitions\sd_b2.tsv");
        WritePart(lines, 821, 1230, @"translations\partitions\sd_b3.tsv");
        WritePart(lines, 1231, total, @"translations\partitions\sd_b4.tsv");
    }

    static void WritePart(string[] lines, int start, int end, string outPath) {
        if (end > lines.Length - 1) end = lines.Length - 1;
        using (var sw = new StreamWriter(outPath, false, Encoding.UTF8)) {
            sw.WriteLine(lines[0]);
            for (int i = start; i <= end; i++) {
                sw.WriteLine(lines[i]);
            }
        }
        Console.WriteLine(string.Format("Wrote {0}: {1} lines ({2} to {3})",
            Path.GetFileName(outPath), end - start + 1, start, end));
    }
}
