using System;
using System.IO;
using System.Reflection;

class ListSystemTextFields {
    static void Main() {
        string dllPath = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll";
        string engineDll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\UnityEngine.CoreModule.dll";

        Assembly.LoadFrom(engineDll);
        var asm = Assembly.LoadFrom(dllPath);

        var type = asm.GetType("PowerTools.Quest.SystemText");
        Console.WriteLine("=== SystemText Fields ===");
        foreach (var f in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)) {
            Console.WriteLine(string.Format("  {0} : {1}", f.Name, f.FieldType.FullName));
        }
    }
}
