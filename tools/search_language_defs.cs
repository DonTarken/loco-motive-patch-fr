using System;
using System.IO;
using System.Text;

class SearchLanguageDefs {
    static void Main() {
        string path = @"D:\Games\Loco Motive\Loco Motive_Data\data.unity3d";
        byte[] data = File.ReadAllBytes(path);

        // Search for "English" or "Deutsch"
        string[] search = new string[] { "English (UK)", "English (US)", "Deutsch", "German" };
        foreach (var s in search) {
            byte[] pattern = Encoding.UTF8.GetBytes(s);
            int idx = IndexOf(data, pattern);
            Console.WriteLine(string.Format("'{0}': index {1}", s, idx));
            if (idx >= 0) {
                int start = Math.Max(0, idx - 40);
                int len = Math.Min(data.Length - start, 120);
                Console.WriteLine("  Context: " + Encoding.ASCII.GetString(data, start, len));
            }
        }
    }

    static int IndexOf(byte[] src, byte[] pattern) {
        for (int i = 0; i <= src.Length - pattern.Length; i++) {
            bool match = true;
            for (int j = 0; j < pattern.Length; j++) {
                if (src[i + j] != pattern[j]) { match = false; break; }
            }
            if (match) return i;
        }
        return -1;
    }
}
