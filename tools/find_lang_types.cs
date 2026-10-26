using System;
using System.IO;
using System.Reflection;

class FindLangTypes {
    static void Main() {
        string pqDll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Projects.Plugins.PowerQuest.dll";
        string engineDll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\UnityEngine.CoreModule.dll";

        Assembly.LoadFrom(engineDll);
        var pqAsm = Assembly.LoadFrom(pqDll);

        foreach (var t in pqAsm.GetTypes()) {
            if (t.Name.Contains("Language")) {
                Console.WriteLine("Type: " + t.FullName);
                foreach (var f in t.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)) {
                    Console.WriteLine("  " + f.Name + " (" + f.FieldType.Name + ")");
                }
            }
        }
    }
}
