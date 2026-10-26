using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class InspectSystemTextStructure {
    static void Main() {
        byte[] b = File.ReadAllBytes(@"D:\Games\Loco Motive\Loco Motive_Data\data.unity3d");
        
        // Find "m_lipSyncExtendedShapes" or "English (UK)"
        byte[] pattern = Encoding.UTF8.GetBytes("English (UK)");
        int offset = -1;
        for (int i = 0; i < b.Length - pattern.Length; i++) {
            bool match = true;
            for (int j = 0; j < pattern.Length; j++) {
                if (b[i+j] != pattern[j]) { match = false; break; }
            }
            if (match) { offset = i; break; }
        }

        Console.WriteLine("Offset of 'English (UK)': " + offset);
        if (offset < 0) return;

        // In Unity serialized format, let's see what is right before and after
        int start = Math.Max(0, offset - 200);
        int len = 800;
        Console.WriteLine("\nHex dump around offset:");
        for (int i = 0; i < len; i += 32) {
            int cur = start + i;
            if (cur >= b.Length) break;
            Console.Write(cur.ToString("X8") + "  ");
            int sub = Math.Min(32, b.Length - cur);
            string hex = "";
            string ascii = "";
            for (int j = 0; j < sub; j++) {
                byte val = b[cur + j];
                hex += val.ToString("X2") + " ";
                ascii += (val >= 32 && val <= 126) ? (char)val : '.';
            }
            Console.WriteLine(hex.PadRight(32 * 3) + " " + ascii);
        }
    }
}
