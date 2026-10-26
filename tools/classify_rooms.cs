using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class ClassifyRooms {
    static void Main() {
        var allLines = File.ReadAllLines(@"translations\dialogues\dialogues_all.tsv");
        var classes = new Dictionary<string, int>();

        for (int i = 1; i < allLines.Length; i++) {
            var parts = allLines[i].Split('\t');
            if (parts.Length < 6) continue;
            string cls = parts[4].Split('+')[0];
            if (!classes.ContainsKey(cls)) classes[cls] = 0;
            classes[cls]++;
        }

        Console.WriteLine("Total unique classes: " + classes.Count);
        foreach (var kv in classes.OrderByDescending(x => x.Value)) {
            Console.WriteLine(string.Format("{0,-40} : {1,4} lines", kv.Key, kv.Value));
        }
    }
}
