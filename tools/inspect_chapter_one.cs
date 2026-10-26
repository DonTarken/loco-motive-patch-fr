using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class InspectChapterOne {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\dialogues\dialogues_all.tsv");
        int count = 0;
        for (int i = 1; i < lines.Length; i++) {
            var parts = lines[i].Split('\t');
            if (parts.Length < 6) continue;
            string method = parts[5];
            string cls = parts[4];
            if (cls.Contains("ChapterOne") || cls.Contains("ActOne") || method.Contains("ChapterOne") || method.Contains("ActOne")) {
                if (count < 30) {
                    Console.WriteLine(string.Format("{0,-12} | {1,-30} | {2}", parts[1], cls.Split('+')[0], parts[2]));
                }
                count++;
            }
        }
        Console.WriteLine("\nTotal Chapter/Act One lines: " + count);
    }
}
