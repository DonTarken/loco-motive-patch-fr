using System;
using System.IO;
using System.Reflection;

class InspectGuiSettings {
    static void Main() {
        string dllPath = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll";
        string pqDll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Projects.Plugins.PowerQuest.dll";
        string engineDll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\UnityEngine.CoreModule.dll";

        Assembly.LoadFrom(engineDll);
        Assembly.LoadFrom(pqDll);
        var asm = Assembly.LoadFrom(dllPath);

        var type = asm.GetType("GuiSettings");
        if (type != null) {
            Console.WriteLine("Found GuiSettings:");
            foreach (var m in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)) {
                if (m.Name.Contains("Language") || m.Name.Contains("OptText")) {
                    Console.WriteLine("  Method: " + m.Name);
                }
            }
        }

        var pqAsm = Assembly.LoadFrom(pqDll);
        var pqType = pqAsm.GetType("PowerTools.Quest.PowerQuest");
        var questSettingsType = pqAsm.GetType("PowerTools.Quest.QuestSettings");
        if (questSettingsType != null) {
            Console.WriteLine("Found QuestSettings fields/props:");
            foreach (var prop in questSettingsType.GetProperties()) {
                if (prop.Name.Contains("Language")) {
                    Console.WriteLine("  Prop: " + prop.Name + " (" + prop.PropertyType.Name + ")");
                }
            }
            foreach (var field in questSettingsType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)) {
                if (field.Name.Contains("Language") || field.Name.Contains("language")) {
                    Console.WriteLine("  Field: " + field.Name + " (" + field.FieldType.Name + ")");
                }
            }
        }
    }
}
