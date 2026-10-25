using System;
using System.IO;
using System.Text;

class SearchGameFiles {
    static void Main() {
        string gameDir = @"D:\Games\Loco Motive";
        string[] targets = new string[] {
            "Check out the list of suspects",
            "It's full of trash",
            "Click {0} to move Arthur in any direction",
            "Click {0} to interact with an object",
            "PAUSED",
            "SAVE GAME"
        };

        var files = Directory.GetFiles(gameDir, "*.*", SearchOption.AllDirectories);
        foreach (var file in files) {
            if (file.EndsWith(".exe") || file.EndsWith(".dll") || file.EndsWith(".assets") || file.EndsWith(".unity3d") || file.EndsWith(".resS")) {
                try {
                    byte[] b = File.ReadAllBytes(file);
                    foreach (var t in targets) {
                        byte[] tb = Encoding.UTF8.GetBytes(t);
                        int found = IndexOf(b, tb);
                        if (found >= 0) {
                            Console.WriteLine("Found '" + t + "' in " + Path.GetFileName(file) + " at offset " + found);
                        }
                    }
                } catch {}
            }
        }
    }

    static int IndexOf(byte[] src, byte[] pattern) {
        int max = src.Length - pattern.Length;
        for (int i = 0; i <= max; i++) {
            bool match = true;
            for (int j = 0; j < pattern.Length; j++) {
                if (src[i + j] != pattern[j]) { match = false; break; }
            }
            if (match) return i;
        }
        return -1;
    }
}
