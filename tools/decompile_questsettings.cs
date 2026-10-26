using System;
using System.IO;
using System.Reflection;

class DecompileQuestSettings {
    static void Main() {
        string pqDll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Projects.Plugins.PowerQuest.dll";
        string engineDll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\UnityEngine.CoreModule.dll";

        Assembly.LoadFrom(engineDll);
        var pqAsm = Assembly.LoadFrom(pqDll);

        var qsType = pqAsm.GetType("PowerTools.Quest.QuestSettings");
        var mGet = qsType.GetMethod("get_LanguageData", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        if (mGet != null) {
            Console.WriteLine("Found get_LanguageData:");
            var body = mGet.GetMethodBody();
            byte[] il = body.GetILAsByteArray();
            for (int i = 0; i < il.Length; i++) {
                Console.Write(il[i].ToString("X2") + " ");
            }
            Console.WriteLine();
        }

        var mSetLang = qsType.GetMethod("set_LanguageId", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        if (mSetLang != null) {
            Console.WriteLine("Found set_LanguageId:");
            var body = mSetLang.GetMethodBody();
            byte[] il = body.GetILAsByteArray();
            for (int i = 0; i < il.Length; i++) {
                Console.Write(il[i].ToString("X2") + " ");
            }
            Console.WriteLine();
        }
    }
}
