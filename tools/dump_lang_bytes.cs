using System;
using System.IO;
using System.Text;

class DumpLangBytes {
    static void Main() {
        string path = @"D:\Games\Loco Motive\Loco Motive_Data\data.unity3d";
        byte[] data = File.ReadAllBytes(path);
        int start = 16784450;
        int len = 200;
        for (int i = 0; i < len; i += 16) {
            Console.Write(string.Format("{0:X8}: ", start + i));
            for (int j = 0; j < 16 && (i + j) < len; j++) {
                Console.Write(data[start + i + j].ToString("X2") + " ");
            }
            Console.Write(" | ");
            for (int j = 0; j < 16 && (i + j) < len; j++) {
                char c = (char)data[start + i + j];
                Console.Write(c >= 32 && c < 127 ? c : '.');
            }
            Console.WriteLine();
        }
    }
}
