using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

class InspectMissingEngineStrings {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\missing_engine_strings.tsv", Encoding.UTF8);

        Console.WriteLine("Total missing lines in missing_engine_strings.tsv: " + (lines.Length - 1));

        var byFunc = new Dictionary<string, List<string>>();
        for (int i = 1; i < lines.Length; i++) {
            var p = lines[i].Split('\t');
            if (p.Length < 4) continue;
            string srcFile = p[0];
            string srcFunc = p[1];
            string en = p[2];
            string de = p[3];

            if (!byFunc.ContainsKey(srcFunc)) byFunc[srcFunc] = new List<string>();
            string item = string.Format("{0,-30} | {1,-35} | {2}", en, de, srcFile);
            if (!byFunc[srcFunc].Contains(item)) byFunc[srcFunc].Add(item);
        }

        foreach (var kv in byFunc) {
            Console.WriteLine(string.Format("\n=== Category: {0} ({1} items) ===", kv.Key, kv.Value.Count));
            for (int i = 0; i < Math.Min(5, kv.Value.Count); i++) {
                Console.WriteLine("  " + kv.Value[i]);
            }
        }
    }
}
