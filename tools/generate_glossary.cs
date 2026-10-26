using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Mono.Cecil;

class GenerateGlossary {
    static void Main() {
        string dll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll";
        var asm = AssemblyDefinition.ReadAssembly(dll);

        var invClasses = asm.MainModule.Types
            .Where(t => t.Name.StartsWith("Inventory") && t.Name != "Inventory" && t.Name != "InventoryArrow" && t.Name != "InventorySlot")
            .Select(t => t.Name.Substring("Inventory".Length))
            .Distinct()
            .OrderBy(x => x)
            .ToList();

        Console.WriteLine("Unique Inventory Items found in code: " + invClasses.Count);
        
        // Also load items from items_strings.json
        var jsonText = File.ReadAllText(@"translations\items\items_strings.json");
        var matches = Regex.Matches(jsonText, "\"En\":\\s*\"([^\"]+)\"");
        var jsonItems = new HashSet<string>();
        foreach (Match m in matches) jsonItems.Add(m.Groups[1].Value);

        Console.WriteLine("Unique items in items_strings.json: " + jsonItems.Count);

        var allItems = invClasses.Union(jsonItems).OrderBy(x => x).ToList();
        Console.WriteLine("Total combined items: " + allItems.Count);

        using (var sw = new StreamWriter(@"translations\items\glossary_items_raw.tsv")) {
            sw.WriteLine("ItemKey\tEnglishNameSuggested\tFrenchNameSuggested\tCategory");
            foreach (var item in allItems) {
                // Split CamelCase into words
                string spaced = Regex.Replace(item, "([a-z])([A-Z])", "$1 $2");
                sw.WriteLine(string.Format("{0}\t{1}\t\tItem", item, spaced));
            }
        }
        Console.WriteLine("Written to translations\\items\\glossary_items_raw.tsv");
    }
}
