using System;
using System.IO;
using System.Text;

class DumpLang {
    static void Main() {
        byte[] b = File.ReadAllBytes(@"D:\Games\Loco Motive\Loco Motive_Data\data.unity3d");
        int offset = 16784478;
        int start = offset - 100;
        int len = 400;
        for (int i = 0; i < len; i += 16) {
            Console.Write((start + i).ToString("X8") + "  ");
            for (int j = 0; j < 16; j++) {
                if (i + j < len) Console.Write(b[start + i + j].ToString("X2") + " ");
                else Console.Write("   ");
            }
            Console.Write(" ");
            for (int j = 0; j < 16; j++) {
                if (i + j < len) {
                    char c = (char)b[start + i + j];
                    Console.Write((c >= 32 && c <= 126) ? c : '.');
                }
            }
            Console.WriteLine();
        }
    }
}
