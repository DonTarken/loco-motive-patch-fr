using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class ExtractDialogOptions {
    static void Main() {
        string path = @"D:\Games\Loco Motive\Loco Motive_Data\data.unity3d";
        byte[] bytes = File.ReadAllBytes(path);

        // In Unity assets, strings are usually [length: 4 bytes int32][chars...][aligned to 4 bytes]
        // Let's find all occurrences of "Dialog" or option text patterns
        var options = new HashSet<string>();
        
        // Let's find ASCII/UTF-8 printable strings of length >= 5
        int minLen = 5;
        int maxLen = 300;

        for (int i = 0; i < bytes.Length - 4; i++) {
            int len = BitConverter.ToInt32(bytes, i);
            if (len >= minLen && len <= maxLen && i + 4 + len <= bytes.Length) {
                // Check if all characters are valid printable UTF-8/ASCII
                bool valid = true;
                for (int c = 0; c < len; c++) {
                    byte b = bytes[i + 4 + c];
                    if (b < 32 && b != '\n' && b != '\r' && b != '\t') { valid = false; break; }
                    if (b > 126 && b < 160) { valid = false; break; }
                }
                if (valid) {
                    string str = Encoding.UTF8.GetString(bytes, i + 4, len);
                    // Filter for dialogue-like strings (starts with letter, punctuation, question mark, etc.)
                    if (str.EndsWith("?") || str.EndsWith("!") || str.EndsWith(".") || str.Contains(" ")) {
                        if (!str.Contains("<") && !str.Contains("/") && !str.Contains("\\") && !str.Contains("Shader") && !str.Contains("Texture") && !str.Contains("MonoBehaviour")) {
                            options.Add(str);
                        }
                    }
                }
            }
        }

        Console.WriteLine("Extracted " + options.Count + " candidate strings from data.unity3d.");
        
        // Check for our known 4 options:
        string[] testOptions = new string[] {
            "My hands are clean, I didn't kill Lady Unterwald!",
            "I'm an estate lawyer, my clients have to pass on eventually.",
            "I'm warning you, I'm an ugly crier.",
            "I believe I'm entitled to a phone call?"
        };

        foreach (var t in testOptions) {
            Console.WriteLine("Contains '" + t + "': " + options.Contains(t));
        }

        // Export to file
        File.WriteAllLines(@"translations\dialogues\extracted_from_unity3d.txt", options, Encoding.UTF8);
        Console.WriteLine("Saved to translations\\dialogues\\extracted_from_unity3d.txt");
    }
}
