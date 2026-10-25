using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class DumpInterrogationStrings {
    static void Main() {
        byte[] b = File.ReadAllBytes(@"D:\Games\Loco Motive\Loco Motive_Data\data.unity3d");
        int center = 157208872;
        int start = Math.Max(0, center - 200000);
        int len = Math.Min(b.Length - start, 400000);

        byte[] sub = new byte[len];
        Array.Copy(b, start, sub, 0, len);
        string text = Encoding.UTF8.GetString(sub);

        // Find all strings prefixed with & or general clean strings
        var lines = new HashSet<string>();
        var matches = Regex.Matches(text, @"&(\d+)\s+([A-Za-z0-9][^\x00-\x1F\x7F-\x9F""\<\>]{2,100})");
        foreach (Match m in matches) {
            lines.Add(m.Groups[2].Value.Trim());
        }

        Console.WriteLine("Found & strings near interrogation block: " + lines.Count);
        foreach (var l in lines) {
            Console.WriteLine("  " + l);
        }
    }
}
