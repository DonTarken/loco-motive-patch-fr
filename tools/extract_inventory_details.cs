using System;
using System.IO;
using System.Linq;
using Mono.Cecil;

class Program {
    static void Main() {
        string dll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll";
        var asm = AssemblyDefinition.ReadAssembly(dll);
        
        // Also search for classes named Inventory*
        var allInv = asm.MainModule.Types.Where(t => t.Name.StartsWith("Inventory")).ToList();
        Console.WriteLine("Classes starting with Inventory: " + allInv.Count);
        foreach (var t in allInv.Take(25)) {
            Console.WriteLine(t.Name);
        }
    }
}
