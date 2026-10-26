using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

class InspectItems {
    static void Main() {
        var text = File.ReadAllText(@"translations\items\items_strings.json");
        var matches = Regex.Matches(text, "\"En\":\\s*\"([^\"]+)\"");
        Console.WriteLine("Total En items in json: " + matches.Count);
        var unique = new HashSet<string>();
        foreach (Match m in matches) {
            unique.Add(m.Groups[1].Value);
        }
        Console.WriteLine("Unique item En keys: " + unique.Count);
        foreach (var s in unique.Take(30)) {
            Console.WriteLine("  " + s);
        }
    }
}
