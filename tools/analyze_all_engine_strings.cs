using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

class AnalyzeAllEngineStrings {
    static void Main() {
        string path = @"D:\Games\Loco Motive\BepInEx\plugins\LocoMotiveFR_Data\all_engine_strings.tsv";
        var lines = File.ReadAllLines(path, Encoding.UTF8);

        var sourceFiles = new Dictionary<string, int>();
        var sourceFunctions = new Dictionary<string, int>();
        var characters = new Dictionary<string, int>();

        for (int i = 1; i < lines.Length; i++) {
            var p = lines[i].Split('\t');
            if (p.Length < 5) continue;
            string ch = p[1];
            string srcFile = p[2];
            string srcFunc = p[3];

            if (!sourceFiles.ContainsKey(srcFile)) sourceFiles[srcFile] = 0;
            sourceFiles[srcFile]++;

            if (!sourceFunctions.ContainsKey(srcFunc)) sourceFunctions[srcFunc] = 0;
            sourceFunctions[srcFunc]++;

            if (!string.IsNullOrEmpty(ch)) {
                if (!characters.ContainsKey(ch)) characters[ch] = 0;
                characters[ch]++;
            }
        }

        Console.WriteLine("Total lines: " + (lines.Length - 1));
        Console.WriteLine("\nTop Source Functions:");
        foreach (var kv in sourceFunctions) {
            if (kv.Value > 10) Console.WriteLine(string.Format("  {0,-35} : {1,5}", kv.Key, kv.Value));
        }

        Console.WriteLine("\nTop Source Files:");
        int printed = 0;
        foreach (var kv in sourceFiles) {
            if (printed++ < 25) Console.WriteLine(string.Format("  {0,-35} : {1,5}", kv.Key, kv.Value));
        }
    }
}
