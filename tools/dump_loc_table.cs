using System;
using System.IO;
using System.Text;

class DumpLocTable {
    static void Main() {
        byte[] b = File.ReadAllBytes(@"D:\Games\Loco Motive\Loco Motive_Data\data.unity3d");
        int offset = 16914717;
        int start = Math.Max(0, offset - 500);
        int len = 4000;

        for (int i = 0; i < len; i += 32) {
            int cur = start + i;
            if (cur >= b.Length) break;
            Console.Write(cur.ToString("X8") + "  ");
            int subLen = Math.Min(32, b.Length - cur);
            string s = "";
            for (int j = 0; j < subLen; j++) {
                char c = (char)b[cur + j];
                s += (c >= 32 && c <= 126) ? c : '.';
            }
            Console.WriteLine(s);
        }
    }
}
