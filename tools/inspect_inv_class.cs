using System;
using System.IO;
using System.Linq;
using Mono.Cecil;

class InspectInvClass {
    static void Main() {
        string dll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll";
        var asm = AssemblyDefinition.ReadAssembly(dll);
        
        var invType = asm.MainModule.Types.FirstOrDefault(t => t.FullName == "PowerTools.Quest.Inventory");
        if (invType != null) {
            Console.WriteLine("PowerTools.Quest.Inventory found:");
            foreach (var f in invType.Fields) {
                Console.WriteLine("  F: " + f.FieldType.Name + " " + f.Name);
            }
            foreach (var p in invType.Properties) {
                Console.WriteLine("  P: " + p.PropertyType.Name + " " + p.Name);
            }
        }

        // Also check if there's an enum or helper for inventory items
        var itemEnum = asm.MainModule.Types.FirstOrDefault(t => t.Name == "EInventory" || t.Name == "EInventoryItem" || t.Name.Contains("InventoryItem"));
        if (itemEnum != null) {
            Console.WriteLine("Enum found: " + itemEnum.FullName);
        }
    }
}
