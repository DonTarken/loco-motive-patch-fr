using System;
using System.IO;
using System.Reflection;

class FindSettingsType {
    static void Main() {
        string dllPath = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll";
        string pqDll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Projects.Plugins.PowerQuest.dll";
        string engineDll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\UnityEngine.CoreModule.dll";

        Assembly.LoadFrom(engineDll);
        Assembly.LoadFrom(pqDll);
        var asm = Assembly.LoadFrom(dllPath);

        var type = asm.GetType("GuiSettings");
        var m = type.GetMethod("RefreshTextLanguageDisplay", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        var body = m.GetMethodBody();
        byte[] il = body.GetILAsByteArray();

        // Token at offset 0x0B
        int token = BitConverter.ToInt32(il, 0x0C);
        var member = type.Module.ResolveMember(token);
        Console.WriteLine("get_Settings member: " + member.DeclaringType.FullName + "." + member.Name);
        if (member is MethodInfo) {
            Console.WriteLine("Return type: " + ((MethodInfo)member).ReturnType.FullName);
        }
    }
}
