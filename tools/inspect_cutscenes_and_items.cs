using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class InspectCutscenesAndItems {
    static void Main() {
        Inspect(@"translations\partitions\shared_cutscenes.tsv");
        Inspect(@"translations\partitions\shared_item_uses.tsv");
    }

    static void Inspect(string path) {
        Console.WriteLine("=== " + Path.GetFileName(path) + " ===");
        if (!File.Exists(path)) return;
        var lines = File.ReadAllLines(path, Encoding.UTF8);
        var unique = new HashSet<string>();
        for (int i = 1; i < lines.Length; i++) {
            var parts = lines[i].Split('\t');
            if (parts.Length > 2) unique.Add(parts[2]);
        }
        Console.WriteLine(string.Format("Total rows: {0}, Unique English: {1}", lines.Length - 1, unique.Count));
        int count = 0;
        foreach (var u in unique) {
            Console.WriteLine(string.Format("- {0}", u));
            count++;
            if (count >= 25) {
                Console.WriteLine("... and " + (unique.Count - count) + " more.");
                break;
            }
        }
    }
}
