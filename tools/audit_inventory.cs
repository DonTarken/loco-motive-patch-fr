using System;
using System.IO;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;

class Program {
    static void Main() {
        var asm = AssemblyDefinition.ReadAssembly(@"D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll");
        
        var invTypes = new List<TypeDefinition>();
        foreach (var t in asm.MainModule.Types) {
            if (t.Name.StartsWith("Inventory") && !t.Name.Contains("Panel") && !t.Name.Contains("Gamepad") && !t.Name.Contains("Slot") && !t.Name.Contains("Button")) {
                invTypes.Add(t);
            }
        }
        
        Console.WriteLine("Found " + invTypes.Count + " InventoryItem types.");
        
        // Inspect methods across all inventory types
        var methodNames = new HashSet<string>();
        var itemStrings = new List<string>();
        
        foreach (var t in invTypes) {
            foreach (var m in t.Methods) {
                methodNames.Add(m.Name);
            }
            // Check nested state machines (IEnumerators)
            foreach (var nested in t.NestedTypes) {
                foreach (var m in nested.Methods) {
                    if (m.HasBody) {
                        foreach (var instr in m.Body.Instructions) {
                            if (instr.OpCode == OpCodes.Ldstr && instr.Operand != null) {
                                string s = instr.Operand.ToString().Trim();
                                if (s.Length > 1 && !s.StartsWith("m_") && !s.Contains("/")) {
                                    itemStrings.Add(t.Name + "\t" + nested.Name + "\t" + s);
                                }
                            }
                        }
                    }
                }
            }
        }
        
        Console.WriteLine("Unique methods in Inventory types:");
        foreach (var name in methodNames) {
            Console.WriteLine("  " + name);
        }
        
        Console.WriteLine("\nTotal strings extracted from Inventory items: " + itemStrings.Count);
        File.WriteAllLines(@"translations\dialogues\extracted_inventory_strings.tsv", itemStrings);
    }
}
