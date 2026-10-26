using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

class ExtractAllDialogOptions {
    static void Main() {
        // Search in data.unity3d and all .assets
        var allFiles = Directory.GetFiles(@"D:\Games\Loco Motive\Loco Motive_Data", "*.assets")
            .Concat(new[] { @"D:\Games\Loco Motive\Loco Motive_Data\data.unity3d" });

        var candidateStrings = new HashSet<string>();

        foreach (var file in allFiles) {
            byte[] bytes = File.ReadAllBytes(file);
            for (int i = 0; i < bytes.Length - 4; i++) {
                int len = BitConverter.ToInt32(bytes, i);
                if (len >= 6 && len <= 250 && i + 4 + len <= bytes.Length) {
                    bool valid = true;
                    for (int c = 0; c < len; c++) {
                        byte b = bytes[i + 4 + c];
                        if (b < 32 && b != '\n' && b != '\r' && b != '\t') { valid = false; break; }
                        if (b > 126 && b < 160) { valid = false; break; }
                    }
                    if (valid) {
                        string s = Encoding.UTF8.GetString(bytes, i + 4, len).Trim();
                        // Filter out technical strings
                        if (s.Contains(" ") && !s.Contains("<") && !s.Contains("/") && !s.Contains("\\") 
                            && !s.Contains("Shader") && !s.Contains("Texture") && !s.Contains("MonoBehaviour")
                            && !s.Contains("UnityEngine") && !s.Contains("Transform") && !s.Contains("System.")
                            && !s.StartsWith("m_") && !s.Contains(".dll") && !s.Contains(".prefab")) {
                            candidateStrings.Add(s);
                        }
                    }
                }
            }
        }

        Console.WriteLine("Total candidate strings extracted: " + candidateStrings.Count);
        File.WriteAllLines(@"translations\dialogues\all_asset_strings.txt", candidateStrings.OrderBy(x => x).ToArray(), Encoding.UTF8);
        Console.WriteLine("Written to translations\\dialogues\\all_asset_strings.txt");
    }
}
