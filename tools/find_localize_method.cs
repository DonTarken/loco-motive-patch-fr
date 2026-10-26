using System;
using System.IO;
using System.Reflection;

class FindLocalizeMethod {
    static void Main() {
        string dllPath = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll";
        string pqDll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Projects.Plugins.PowerQuest.dll";
        string engineDll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\UnityEngine.CoreModule.dll";

        Assembly.LoadFrom(engineDll);
        Assembly.LoadFrom(pqDll);
        var asm = Assembly.LoadFrom(dllPath);

        foreach (var t in asm.GetTypes()) {
            foreach (var m in t.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)) {
                if (m.Name == "Localize") {
                    Console.WriteLine(t.FullName + "." + m.Name + "(" + string.Join(", ", Array.ConvertAll(m.GetParameters(), p => p.ParameterType.Name)) + ")");
                }
            }
        }
    }
}
