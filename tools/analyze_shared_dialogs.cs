using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class AnalyzeSharedDialogs {
    static void Main() {
        string path = @"translations\partitions\shared_dialogs.tsv";
        if (!File.Exists(path)) {
            Console.WriteLine("File not found: " + path);
            return;
        }
        var lines = File.ReadAllLines(path, Encoding.UTF8);
        var chars = new Dictionary<string, int>();
        var methods = new Dictionary<string, int>();
        var uniqueEn = new HashSet<string>();

        for (int i = 1; i < lines.Length; i++) {
            var p = lines[i].Split('\t');
            if (p.Length < 6) continue;
            string ch = p[1];
            string en = p[2];
            string cls = p[4];
            string meth = p[5];

            uniqueEn.Add(en);
            if (!chars.ContainsKey(ch)) chars[ch] = 0;
            chars[ch]++;

            string cm = cls + "." + meth;
            if (!methods.ContainsKey(cm)) methods[cm] = 0;
            methods[cm]++;
        }

        Console.WriteLine(string.Format("Total lines: {0}, Unique English: {1}", lines.Length - 1, uniqueEn.Count));
        Console.WriteLine("\n--- Characters ---");
        foreach (var kvp in chars) {
            Console.WriteLine(string.Format("{0}: {1}", kvp.Key, kvp.Value));
        }
        Console.WriteLine(string.Format("\n--- Methods ({0} distinct) ---", methods.Count));
        int count = 0;
        foreach (var kvp in methods) {
            Console.WriteLine(string.Format("{0}: {1}", kvp.Key, kvp.Value));
            count++;
            if (count > 25) {
                Console.WriteLine("... and " + (methods.Count - count) + " more.");
                break;
            }
        }
    }
}
