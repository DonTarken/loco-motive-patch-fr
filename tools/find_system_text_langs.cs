using System;
using System.IO;
using System.Text;

class FindSystemTextLangs {
    static void Main() {
        string managedDir = @"D:\Games\Loco Motive\Loco Motive_Data";
        foreach (var file in Directory.GetFiles(managedDir, "*.*", SearchOption.TopDirectoryOnly)) {
            if (file.EndsWith(".exe") || file.EndsWith(".dll")) continue;
            try {
                byte[] data = File.ReadAllBytes(file);
                int idx = IndexOf(data, Encoding.UTF8.GetBytes("English (UK)"));
                if (idx >= 0) {
                    Console.WriteLine("Found English (UK) in " + Path.GetFileName(file) + " at " + idx);
                    // Print nearby strings
                    int s = Math.Max(0, idx - 50);
                    int e = Math.Min(data.Length, idx + 250);
                    for (int k = s; k < e; k++) {
                        byte b = data[k];
                        if (b >= 32 && b < 127) Console.Write((char)b);
                        else Console.Write(" ");
                    }
                    Console.WriteLine();
                }
            } catch {}
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
