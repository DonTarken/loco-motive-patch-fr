using System;
using System.IO;
using System.Text;

class SearchHotspotStrings {
    static void Main() {
        string[] searchStrings = new string[] {
            "Eavesdrop on the conversation",
            "Browse travel pamphlets",
            "Read carriage directions",
            "He looks busy"
        };

        Console.WriteLine("=== Searching in translations/ ===");
        foreach (var file in Directory.GetFiles("translations", "*.*", SearchOption.AllDirectories)) {
            try {
                var text = File.ReadAllText(file, Encoding.UTF8);
                foreach (var s in searchStrings) {
                    if (text.IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0) {
                        Console.WriteLine(string.Format("Found '{0}' in {1}", s, file));
                    }
                }
            } catch {}
        }

        Console.WriteLine("\n=== Searching in game Managed DLLs ===");
        string managedDir = @"D:\Games\Loco Motive\Loco Motive_Data\Managed";
        foreach (var file in Directory.GetFiles(managedDir, "*.dll")) {
            try {
                byte[] data = File.ReadAllBytes(file);
                foreach (var s in searchStrings) {
                    if (IndexOf(data, Encoding.UTF8.GetBytes(s)) >= 0) {
                        Console.WriteLine(string.Format("Found '{0}' in DLL {1}", s, Path.GetFileName(file)));
                    }
                }
            } catch {}
        }

        Console.WriteLine("\n=== Searching in game assets / data ===");
        string gameDir = @"D:\Games\Loco Motive\Loco Motive_Data";
        foreach (var file in Directory.GetFiles(gameDir, "*.*")) {
            if (file.EndsWith(".dll") || file.EndsWith(".exe")) continue;
            try {
                byte[] data = File.ReadAllBytes(file);
                foreach (var s in searchStrings) {
                    if (IndexOf(data, Encoding.UTF8.GetBytes(s)) >= 0) {
                        Console.WriteLine(string.Format("Found '{0}' in {1}", s, Path.GetFileName(file)));
                    }
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
