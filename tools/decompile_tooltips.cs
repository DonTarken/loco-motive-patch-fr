using System;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;

class Program {
    static void Main() {
        var asm = AssemblyDefinition.ReadAssembly(@"D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll");
        var t = asm.MainModule.GetType("GuiTooltips");
        foreach (var m in t.Methods) {
            Console.WriteLine("=== Method " + m.Name + " ===");
            if (m.HasBody) {
                foreach (var instr in m.Body.Instructions) {
                    if (instr.OpCode == OpCodes.Call || instr.OpCode == OpCodes.Callvirt || instr.OpCode == OpCodes.Ldstr) {
                        Console.WriteLine("  " + instr.OpCode + " " + instr.Operand);
                    }
                }
            }
        }
    }
}
