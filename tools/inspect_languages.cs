using System;
using System.IO;
using System.Reflection;

class InspectLanguages {
    static void Main() {
        string dllPath = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll";
        string pqDll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Projects.Plugins.PowerQuest.dll";
        string engineDll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\UnityEngine.CoreModule.dll";

        Assembly.LoadFrom(engineDll);
        var pqAsm = Assembly.LoadFrom(pqDll);
        var asm = Assembly.LoadFrom(dllPath);

        var questSettingsType = pqAsm.GetType("PowerTools.Quest.QuestSettings");
        var langDataType = pqAsm.GetType("PowerTools.Quest.QuestSettings+LanguageData");
        if (langDataType != null) {
            Console.WriteLine("LanguageData fields:");
            foreach (var f in langDataType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)) {
                Console.WriteLine("  " + f.Name + " (" + f.FieldType.Name + ")");
            }
        }
        var m_languagesField = questSettingsType.GetField("m_languages", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        if (m_languagesField != null) {
            Console.WriteLine("Found m_languages field of type " + m_languagesField.FieldType.Name);
        }
    }
}
