using System;
using System.IO;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;

class InspectSystemTextFull {
    static void Main() {
        string dll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll";
        var asm = AssemblyDefinition.ReadAssembly(dll);
        
        var t = asm.MainModule.Types.FirstOrDefault(x => x.FullName == "PowerTools.Quest.SystemText");
        if (t == null) {
            Console.WriteLine("SystemText not found");
            return;
        }

        Console.WriteLine("Type: " + t.FullName);
        foreach (var f in t.Fields) {
            Console.WriteLine("Field: " + f.FieldType.FullName + " " + f.Name);
        }

        foreach (var m in t.Methods) {
            Console.WriteLine("Method: " + m.Name + " (" + m.Parameters.Count + " params)");
            if (m.Name == "Awake" || m.Name == "Initialize" || m.Name == "Load" || m.Name == "Import" || m.Name.Contains("Text")) {
                Console.WriteLine("  -- Body of " + m.Name + ":");
                if (m.HasBody) {
                    foreach (var instr in m.Body.Instructions.Take(30)) {
                        Console.WriteLine("     " + instr.OpCode + " " + (instr.Operand != null ? instr.Operand.ToString() : ""));
                    }
                }
            }
        }
    }
}
