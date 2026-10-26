using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class DumpPartitionForTranslation {
    static void Main(string[] args) {
        if (args.Length < 1) {
            Console.WriteLine("Usage: dump.exe <path_to_tsv>");
            return;
        }
        string path = args[0];
        if (!File.Exists(path)) return;
        var lines = File.ReadAllLines(path, Encoding.UTF8);
        
        // Group by Class.Method
        var groups = new Dictionary<string, List<string[]>>();
        for (int i = 1; i < lines.Length; i++) {
            var p = lines[i].Split('\t');
            if (p.Length < 6) continue;
            string key = p[4] + "." + p[5];
            if (!groups.ContainsKey(key)) groups[key] = new List<string[]>();
            groups[key].Add(p);
        }

        string outTxt = Path.ChangeExtension(path, ".dump.txt");
        using (var sw = new StreamWriter(outTxt, false, Encoding.UTF8)) {
            foreach (var kvp in groups) {
                sw.WriteLine("// ===== " + kvp.Key + " (" + kvp.Value.Count + " lines) =====");
                foreach (var row in kvp.Value) {
                    string charName = row[1];
                    string en = row[2];
                    sw.WriteLine(string.Format("map[\"{0}\"] = \"\"; // Char: {1}", en.Replace("\"", "\\\""), charName));
                }
                sw.WriteLine();
            }
        }
        Console.WriteLine("Wrote " + outTxt + " with " + groups.Count + " groups.");
    }
}
