using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

class ExportUniqueMissingEngine {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\missing_engine_strings.tsv", Encoding.UTF8);
        var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        using (var sw = new StreamWriter(@"translations\unique_missing_engine.tsv", false, Encoding.UTF8)) {
            sw.WriteLine("English\tGerman\tSampleSourceFile\tSampleSourceFunction");
            for (int i = 1; i < lines.Length; i++) {
                var p = lines[i].Split('\t');
                if (p.Length < 4) continue;
                string srcFile = p[0];
                string srcFunc = p[1];
                string en = p[2].Trim();
                string de = p[3].Trim();

                if (string.IsNullOrEmpty(en)) continue;
                if (!seen.Contains(en)) {
                    seen.Add(en);
                    sw.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}", en, de, srcFile, srcFunc));
                }
            }
        }

        Console.WriteLine("Exported unique missing engine strings: " + seen.Count);
    }
}
