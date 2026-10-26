using System;
using Mono.Cecil;

class Program {
    static void Main() {
        var asm = AssemblyDefinition.ReadAssembly(@"D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll");
        var pq = asm.MainModule.GetType("PowerTools.Quest.PowerQuest");
        Console.WriteLine("=== Methods in PowerQuest for MouseOver ===");
        foreach (var m in pq.Methods) {
            if (m.Name.Contains("MouseOver") || m.Name.Contains("InteractDescription")) {
                Console.WriteLine("  " + m.Name + " : " + m.ReturnType.FullName);
            }
        }
    }
}
