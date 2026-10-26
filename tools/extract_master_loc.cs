using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class ExtractMasterLocTable {
    static void Main() {
        byte[] b = File.ReadAllBytes(@"D:\Games\Loco Motive\Loco Motive_Data\data.unity3d");

        // The loc table is between offset 16000000 and 18000000
        int start = 16700000;
        int end = 17500000;

        // In Unity serialized TextData:
        // m_string (length + string)
        // m_translations (array of length + strings)
        // Let's find every string of length 3 to 200 where characters are ASCII printable
        var entries = new List<string>();
        for (int i = start; i < end - 4; i++) {
            int len = BitConverter.ToInt32(b, i);
            if (len >= 3 && len <= 200 && i + 4 + len <= end) {
                // Check if all bytes are printable
                bool isAscii = true;
                for (int j = 0; j < len; j++) {
                    byte c = b[i + 4 + j];
                    if (c < 32 || c > 126) { isAscii = false; break; }
                }
                if (isAscii) {
                    string s = Encoding.ASCII.GetString(b, i + 4, len);
                    // Filter meaningful strings (spaces, English words)
                    if (s.Contains(" ") && !s.Contains("Assembly") && !s.Contains("UnityEngine") && !s.Contains("PowerTools")) {
                        entries.Add(s);
                        i += 4 + len - 1; // skip ahead
                    }
                }
            }
        }

        Console.WriteLine("Extracted " + entries.Count + " strings from master loc table chunk.");
        var unique = new HashSet<string>(entries);
        using (var sw = new StreamWriter(@"translations\dialogues\master_loc_strings.tsv", false, Encoding.UTF8)) {
            foreach (var s in unique) {
                sw.WriteLine(s);
            }
        }
        Console.WriteLine("Saved to translations\\dialogues\\master_loc_strings.tsv");

        // Let's filter ones matching RoomInterrogation props
        string[] keywords = new string[] { "switch", "lamp", "desk", "trash", "bin", "ashtray", "door", "key", "coat", "fan", "phone", "paper", "photo", "trophy", "umbrella", "window", "book", "board" };
        Console.WriteLine("\nInterrogation matches:");
        foreach (var s in unique) {
            foreach (var kw in keywords) {
                if (s.IndexOf(kw, StringComparison.OrdinalIgnoreCase) >= 0) {
                    Console.WriteLine("  " + s);
                    break;
                }
            }
        }
    }
}
