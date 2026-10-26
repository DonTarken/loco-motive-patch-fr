using System;
using System.IO;
using System.Linq;
using Mono.Cecil;

class List129Items {
    static void Main() {
        string dll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll";
        var asm = AssemblyDefinition.ReadAssembly(dll);

        var invClasses = asm.MainModule.Types
            .Where(t => t.Name.StartsWith("Inventory") && t.Name != "Inventory" && t.Name != "InventoryArrow" && t.Name != "InventorySlot")
            .Select(t => t.Name.Substring("Inventory".Length))
            .Distinct()
            .OrderBy(x => x)
            .ToList();

        foreach (var item in invClasses) {
            Console.WriteLine(item);
        }
    }
}
