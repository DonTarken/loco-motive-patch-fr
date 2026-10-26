using System;
using System.IO;
using System.Reflection;

class FindInAllDlls {
    static void Main() {
        string dir = @"D:\Games\Loco Motive\Loco Motive_Data\Managed";
        foreach (var dll in Directory.GetFiles(dir, "*.dll")) {
            try {
                var asm = Assembly.LoadFrom(dll);
                foreach (var t in asm.GetTypes()) {
                    if (t.Name.Contains("LanguageData")) {
                        Console.WriteLine("Found " + t.FullName + " in " + Path.GetFileName(dll));
                        foreach (var f in t.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)) {
                            Console.WriteLine("  " + f.Name + " (" + f.FieldType.Name + ")");
                        }
                    }
                }
            } catch {}
        }
    }
}
