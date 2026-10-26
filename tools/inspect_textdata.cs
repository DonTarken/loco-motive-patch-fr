using System;
using System.IO;
using System.Linq;
using Mono.Cecil;

class InspectTextData {
    static void Main() {
        string dll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll";
        var asm = AssemblyDefinition.ReadAssembly(dll);
        
        var t = asm.MainModule.Types.FirstOrDefault(x => x.FullName == "PowerTools.Quest.TextData");
        if (t == null) {
            Console.WriteLine("TextData not found");
            return;
        }

        Console.WriteLine("Type: " + t.FullName);
        foreach (var f in t.Fields) {
            Console.WriteLine("Field: " + f.FieldType.FullName + " " + f.Name);
        }
    }
}
