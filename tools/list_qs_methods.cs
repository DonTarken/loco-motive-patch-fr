using System;
using System.IO;
using System.Reflection;

class ListQsMethods {
    static void Main() {
        string pqDll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Projects.Plugins.PowerQuest.dll";
        string engineDll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\UnityEngine.CoreModule.dll";

        Assembly.LoadFrom(engineDll);
        var pqAsm = Assembly.LoadFrom(pqDll);

        var qsType = pqAsm.GetType("PowerTools.Quest.QuestSettings");
        foreach (var m in qsType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)) {
            if (m.Name.Contains("Lang")) {
                Console.WriteLine("Method: " + m.Name);
            }
        }
        foreach (var p in qsType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)) {
            if (p.Name.Contains("Lang")) {
                Console.WriteLine("Property: " + p.Name + " (" + p.PropertyType.FullName + ")");
            }
        }
    }
}
