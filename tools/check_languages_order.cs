using System;
using System.IO;
using System.Reflection;

class CheckLanguagesOrder {
    static void Main() {
        string dllPath = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll";
        string pqDll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Projects.Plugins.PowerQuest.dll";
        string engineDll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\UnityEngine.CoreModule.dll";

        Assembly.LoadFrom(engineDll);
        Assembly.LoadFrom(pqDll);
        var asm = Assembly.LoadFrom(dllPath);

        var pqType = asm.GetType("PowerTools.Quest.SystemText");
        var module = pqType.Module;

        var m = pqType.GetMethod("GetLanguageData", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(int) }, null);
        if (m == null) m = pqType.GetMethod("GetLanguageData", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        if (m != null) {
            Console.WriteLine("Found GetLanguageData:");
            Disasm(m, module);
        }
    }

    static void Disasm(MethodInfo m, Module module) {
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
