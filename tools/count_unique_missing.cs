using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

class CountUniqueMissing {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\missing_engine_strings.tsv", Encoding.UTF8);
        var map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        for (int i = 1; i < lines.Length; i++) {
            var p = lines[i].Split('\t');
            if (p.Length < 4) continue;
            string en = p[2].Trim();
            string de = p[3].Trim();
            if (!string.IsNullOrEmpty(en)) {
                map[en] = de;
            }
        }

        Console.WriteLine("Total unique missing English strings: " + map.Count);
    }
}
