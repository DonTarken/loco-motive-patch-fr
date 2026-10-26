using System;
using System.IO;
using System.Text;

class DumpAllLanguages {
    static void Main() {
        string path = @"D:\Games\Loco Motive\Loco Motive_Data\data.unity3d";
        byte[] data = File.ReadAllBytes(path);

        // Let's find "English (UK)" and dump 500 bytes before and after
        int idx = 16784450;
        for (int i = idx - 100; i < idx + 400; i += 16) {
            Console.Write(string.Format("{0:X8}: ", i));
            for (int j = 0; j < 16 && (i + j) < data.Length; j++) {
                Console.Write(data[i + j].ToString("X2") + " ");
            }
            Console.Write(" | ");
            for (int j = 0; j < 16 && (i + j) < data.Length; j++) {
                char c = (char)data[i + j];
                Console.Write(c >= 32 && c < 127 ? c : '.');
            }
            Console.WriteLine();
        }
    }
}
