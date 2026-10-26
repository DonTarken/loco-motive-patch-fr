using System;
using System.IO;
using System.Reflection;

class DisasmSwitchL {
    static void Main() {
        string dllPath = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Assembly-CSharp.dll";
        string pqDll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\Projects.Plugins.PowerQuest.dll";
        string engineDll = @"D:\Games\Loco Motive\Loco Motive_Data\Managed\UnityEngine.CoreModule.dll";

        Assembly.LoadFrom(engineDll);
        Assembly.LoadFrom(pqDll);
        var asm = Assembly.LoadFrom(dllPath);

        var type = asm.GetType("GuiSettings");
        var m = type.GetMethod("OptTextLanguageL", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        var body = m.GetMethodBody();
        byte[] il = body.GetILAsByteArray();

        int count = BitConverter.ToInt32(il, 0x0D);
        int afterSwitch = 0x0D + 4 + (count * 4);
        Console.WriteLine("Switch count: " + count + ", afterSwitch offset: " + afterSwitch.ToString("X2"));
        for (int i = 0; i < count; i++) {
            int targetOffset = BitConverter.ToInt32(il, 0x11 + (i * 4));
            int dest = afterSwitch + targetOffset;
            Console.WriteLine(string.Format("Case {0} -> offset 0x{1:X2}", i, dest));
        }
    }
}
