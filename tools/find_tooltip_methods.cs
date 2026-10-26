using System;
using System.IO;
using System.Reflection;

class FindTooltipMethods {
    static void Main() {
        string dllPath = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll";
        string pqDll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Projects.Plugins.PowerQuest.dll";
        string engineDll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\UnityEngine.CoreModule.dll";

        Assembly.LoadFrom(engineDll);
        var pqAsm = Assembly.LoadFrom(pqDll);
        var asm = Assembly.LoadFrom(dllPath);

        Console.WriteLine("=== Types in Projects.Plugins.PowerQuest.dll ===");
        foreach (var t in pqAsm.GetTypes()) {
            if (t.Name.Contains("Tooltip") || t.Name.Contains("Cursor") || t.Name.Contains("Hud") || t.Name.Contains("Hover")) {
                Console.WriteLine("Type: " + t.FullName);
                foreach (var m in t.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)) {
                    if (m.DeclaringType == t)
                        Console.WriteLine("  Method: " + m.Name);
                }
            }
        }

        Console.WriteLine("\n=== Types in Assembly-CSharp.dll ===");
        foreach (var t in asm.GetTypes()) {
            if (t.Name.Contains("Tooltip") || t.Name.Contains("Cursor") || t.Name.Contains("Hud") || t.Name.Contains("Hover")) {
                Console.WriteLine("Type: " + t.FullName);
                foreach (var m in t.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)) {
                    if (m.DeclaringType == t)
                        Console.WriteLine("  Method: " + m.Name);
                }
            }
        }
    }
}
