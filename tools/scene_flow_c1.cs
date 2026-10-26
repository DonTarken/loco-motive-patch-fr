using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class SceneFlowC1 {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\partitions\chapter1_raw.tsv");
        var scenes = new Dictionary<string, List<string>>();

        for (int i = 1; i < lines.Length; i++) {
            var parts = lines[i].Split('\t');
            if (parts.Length < 6) continue;
            string scene = parts[4].Split('+')[0] + "::" + parts[5];
            if (!scenes.ContainsKey(scene)) scenes[scene] = new List<string>();
            scenes[scene].Add(string.Format("{0,-12}: {1}", parts[1], parts[2]));
        }

        Console.WriteLine("Total scenes in Chapter 1: " + scenes.Count);
        foreach (var kv in scenes.Take(20)) {
            Console.WriteLine("\n=== Scene: " + kv.Key + " (" + kv.Value.Count + " lines) ===");
            foreach (var l in kv.Value.Take(5)) {
                Console.WriteLine("  " + l);
            }
        }
    }
}
