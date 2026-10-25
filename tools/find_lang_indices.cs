using System;
using System.IO;
using System.Text;

class FindLangIndices {
    static void Main() {
        string path = @"D:\Games\Loco Motive\Loco Motive_Data\data.unity3d";
        byte[] bytes = File.ReadAllBytes(path);

        string[] targets = new string[] { "English (UK)", "English (US)", "Deutsch", "German" };
        foreach (var t in targets) {
            byte[] b = Encoding.UTF8.GetBytes(t);
            for (int i = 0; i < bytes.Length - b.Length; i++) {
                bool match = true;
                for (int j = 0; j < b.Length; j++) {
                    if (bytes[i + j] != b[j]) { match = false; break; }
                }
                if (match) {
                    Console.WriteLine("Target '" + t + "' at offset " + i);
                    int start = Math.Max(0, i - 40);
                    int len = Math.Min(bytes.Length - start, 120);
                    Console.WriteLine("Context: " + Encoding.ASCII.GetString(bytes, start, len));
                }
            }
        }
    }
}
