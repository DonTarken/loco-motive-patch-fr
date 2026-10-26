using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

class ParseSystemTextUnity {
    static void Main() {
        byte[] b = File.ReadAllBytes(@"D:\Games\Loco Motive\Loco Motive_Data\data.unity3d");
        int offset = 16784478;
        Console.WriteLine("File length: " + b.Length);
        
        int start = 16750000;
        int end = Math.Min(b.Length, 25000000);
        
        var strings = new List<string>();
        int count = 0;
        
        for (int i = start; i < end - 4; i++) {
            int len = BitConverter.ToInt32(b, i);
            if (len >= 3 && len <= 300 && i + 4 + len <= end) {
                bool valid = true;
                for (int c = 0; c < len; c++) {
                    byte cb = b[i + 4 + c];
                    if (cb < 32 && cb != '\n' && cb != '\r' && cb != '\t') { valid = false; break; }
                    if (cb > 126 && cb < 160) { valid = false; break; }
                }
                if (valid) {
                    string s = Encoding.UTF8.GetString(b, i + 4, len);
                    if (s.Contains(" ") || s.EndsWith(".") || s.EndsWith("!") || s.EndsWith("?")) {
                        strings.Add(s);
                        count++;
                        i += 4 + len - 1;
                    }
                }
            }
        }
        
        Console.WriteLine(string.Format("Found {0} strings between {1} and {2}", count, start, end));
        foreach (var s in strings.Take(30)) {
            Console.WriteLine("  " + s);
        }
    }
}
