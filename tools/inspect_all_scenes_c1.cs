using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class InspectAllScenesC1 {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\partitions\chapter1_raw.tsv");
        var scenes = new Dictionary<string, int>();

        for (int i = 1; i < lines.Length; i++) {
            var parts = lines[i].Split('\t');
            if (parts.Length < 6) continue;
            string scene = parts[4].Split('+')[0];
            if (!scenes.ContainsKey(scene)) scenes[scene] = 0;
            scenes[scene]++;
        }

        Console.WriteLine("All Room/Dialog classes in Chapter 1 (" + scenes.Count + "):");
        foreach (var kv in scenes.OrderByDescending(x => x.Value)) {
            Console.WriteLine(string.Format("  {0,-35} : {1,4} lines", kv.Key, kv.Value));
        }
    }
}
