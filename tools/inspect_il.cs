using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;

class InspectIL {
    static void Main() {
        string dllPath = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll";
        string pqDll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Projects.Plugins.PowerQuest.dll";
        string engineDll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\UnityEngine.CoreModule.dll";

        Assembly.LoadFrom(engineDll);
        Assembly.LoadFrom(pqDll);
        var asm = Assembly.LoadFrom(dllPath);

        var type = asm.GetType("GuiSettings");
        PrintMethod(type, "RefreshTextLanguageDisplay");
        PrintMethod(type, "OptTextLanguageL");
        PrintMethod(type, "OptTextLanguageR");
    }

    static void PrintMethod(Type type, string name) {
        Console.WriteLine("\n=== Method: " + name + " ===");
        var m = type.GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        if (m == null) {
            Console.WriteLine("Method not found.");
            return;
        }
        var body = m.GetMethodBody();
        if (body == null) {
            Console.WriteLine("No body.");
            return;
        }
        byte[] il = body.GetILAsByteArray();
        Console.WriteLine("IL bytes length: " + il.Length);
        // Print tokens / instructions
        for (int i = 0; i < il.Length; i++) {
            Console.Write(il[i].ToString("X2") + " ");
        }
        Console.WriteLine();
    }
}
