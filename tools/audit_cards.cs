using System;
using Mono.Cecil;
using Mono.Cecil.Cil;

class Program {
    static void Main() {
        var asm = AssemblyDefinition.ReadAssembly(@"D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll");
        var hs = asm.MainModule.GetType("GuiHoldSkipCutscene");
        foreach (var m in hs.Methods) {
            if (m.Name == "OnShow" && m.HasBody) {
                foreach (var instr in m.Body.Instructions) {
                    Console.WriteLine("  " + instr.OpCode + " " + instr.Operand);
                }
            }
        }
    }
}
