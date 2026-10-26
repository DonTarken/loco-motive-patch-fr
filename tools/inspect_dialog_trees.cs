using System;
using System.IO;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Collections.Generic;

class InspectDialogTrees {
    static void Main() {
        string dll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll";
        var asm = AssemblyDefinition.ReadAssembly(dll);

        var dialogTypes = asm.MainModule.Types
            .Where(t => t.BaseType != null && t.BaseType.Name.Contains("Dialog"))
            .ToList();

        Console.WriteLine("Types inheriting from Dialog*: " + dialogTypes.Count);
        foreach (var t in dialogTypes) {
            Console.WriteLine("  " + t.Name + " (base: " + t.BaseType.Name + ")");
        }

        // Also search for all types whose name starts with Dialog
        var allDialogClasses = asm.MainModule.Types.Where(t => t.Name.StartsWith("Dialog")).ToList();
        Console.WriteLine("\nAll classes starting with 'Dialog': " + allDialogClasses.Count);
        foreach (var t in allDialogClasses) {
            Console.WriteLine("  " + t.Name);
        }
    }
}
