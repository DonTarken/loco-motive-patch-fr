using System;
using System.IO;
using System.Text;

class DumpHotspotContext {
    static void Main() {
        string path = @"D:\Games\Loco Motive\Loco Motive_Data\data.unity3d";
        byte[] data = File.ReadAllBytes(path);

        Dump(data, 18706600, 200, "Match 18706600 (Eavesdrop)");
        Dump(data, 159905000, 300, "Match 159905000 (Carriage / Pamphlet)");
    }

    static void Dump(byte[] data, int start, int len, string label) {
        Console.WriteLine("\n=== " + label + " ===");
        for (int i = start; i < start + len && i < data.Length; i += 16) {
            Console.Write(string.Format("{0:X8}: ", i));
            for (int j = 0; j < 16 && (i + j) < data.Length; j++) {
                Console.Write(data[i + j].ToString("X2") + " ");
            }
            Console.Write(" | ");
            for (int j = 0; j < 16 && (i + j) < data.Length; j++) {
                char c = (char)data[i + j];
                Console.Write(c >= 32 && c <= 126 ? c : '.');
            }
            Console.WriteLine();
        }
    }
}
