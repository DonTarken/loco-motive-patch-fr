using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

class ExtractItemDescriptions {
    static void Main() {
        // Search in data.unity3d or resources.assets for inventory item definitions
        var files = Directory.GetFiles(@"D:\Games\Loco Motive\Loco Motive_Data", "*.assets")
            .Concat(new[] { @"D:\Games\Loco Motive\Loco Motive_Data\data.unity3d" });

        var foundItems = new Dictionary<string, string>();

        foreach (var file in files) {
            byte[] bytes = File.ReadAllBytes(file);
            string text = Encoding.UTF8.GetString(bytes);

            // Pattern for PowerQuest inventory item ScriptableObject
            // Often has m_description or m_scriptName
            // Let's search for "Inventory" followed by item name
            var matches = Regex.Matches(text, "Inventory([A-Z][a-zA-Z0-9]+)");
            foreach (Match m in matches) {
                string name = m.Groups[1].Value;
                if (!foundItems.ContainsKey(name)) {
                    foundItems[name] = file;
                }
            }
        }

        Console.WriteLine("Found inventory item names in assets: " + foundItems.Count);
        foreach (var k in foundItems.Keys.Take(30)) {
            Console.WriteLine("  " + k);
        }
    }
}
