using System;
using System.IO;
using System.Reflection;

class InspectQuestSettingsInAsm {
    static void Main() {
        string dllPath = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll";
        string pqDll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Projects.Plugins.PowerQuest.dll";
        string engineDll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\UnityEngine.CoreModule.dll";

        Assembly.LoadFrom(engineDll);
        Assembly.LoadFrom(pqDll);
        var asm = Assembly.LoadFrom(dllPath);

        var qsType = asm.GetType("PowerTools.Quest.QuestSettings");
        Console.WriteLine("Found QuestSettings in Assembly-CSharp.dll:");
        foreach (var p in qsType.GetProperties()) {
            if (p.Name.Contains("Lang")) {
                Console.WriteLine("Property: " + p.Name + " (" + p.PropertyType.FullName + ")");
            }
        }
        foreach (var m in qsType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)) {
            if (m.Name.Contains("Lang")) {
                Console.WriteLine("Method: " + m.Name);
            }
        }
        foreach (var f in qsType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)) {
            if (f.Name.Contains("lang") || f.Name.Contains("Lang")) {
                Console.WriteLine("Field: " + f.Name + " (" + f.FieldType.FullName + ")");
            }
        }
    }
}
