using System;
using System.IO;
using System.Reflection;

class DecompileQsGetLanguages {
    static void Main() {
        string dllPath = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll";
        string pqDll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Projects.Plugins.PowerQuest.dll";
        string engineDll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\UnityEngine.CoreModule.dll";

        Assembly.LoadFrom(engineDll);
        Assembly.LoadFrom(pqDll);
        var asm = Assembly.LoadFrom(dllPath);

        var qsType = asm.GetType("PowerTools.Quest.QuestSettings");
        var module = qsType.Module;

        Disasm(qsType.GetMethod("GetLanguages"), module);
        Disasm(qsType.GetMethod("get_LanguageData"), module);
        Disasm(qsType.GetMethod("set_LanguageId"), module);
    }

    static void Disasm(MethodInfo m, Module module) {
        Console.WriteLine("\n=== Disasm: " + m.Name + " ===");
        var body = m.GetMethodBody();
        byte[] il = body.GetILAsByteArray();
        for (int i = 0; i < il.Length; i++) {
            byte b = il[i];
            if (b == 0x72) {
                int token = BitConverter.ToInt32(il, i + 1);
                string s = module.ResolveString(token);
                Console.WriteLine(string.Format("  {0:X4}: ldstr \"{1}\"", i, s));
                i += 4;
            } else if (b == 0x28 || b == 0x6F) {
                int token = BitConverter.ToInt32(il, i + 1);
                MemberInfo mi = null;
                try { mi = module.ResolveMember(token); } catch {}
                Console.WriteLine(string.Format("  {0:X4}: {1} {2}", i, (b == 0x28 ? "call" : "callvirt"), mi != null ? mi.Name : token.ToString("X8")));
                i += 4;
            } else if (b == 0x7B || b == 0x7E) {
                int token = BitConverter.ToInt32(il, i + 1);
                MemberInfo mi = null;
                try { mi = module.ResolveMember(token); } catch {}
                Console.WriteLine(string.Format("  {0:X4}: ldfld {1}", i, mi != null ? mi.Name : token.ToString("X8")));
                i += 4;
            } else {
                Console.WriteLine(string.Format("  {0:X4}: {1:X2}", i, b));
            }
        }
    }
}
