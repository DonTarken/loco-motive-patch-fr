using System;
using System.IO;
using System.Text;

class SearchLightSwitch {
    static void Main() {
        byte[] b = File.ReadAllBytes(@"D:\Games\Loco Motive\Loco Motive_Data\data.unity3d");
        string target = "light switch";
        byte[] tb = Encoding.UTF8.GetBytes(target);

        for (int i = 0; i < b.Length - tb.Length; i++) {
            bool match = true;
            for (int j = 0; j < tb.Length; j++) {
                if (b[i + j] != tb[j]) { match = false; break; }
            }
            if (match) {
                int start = Math.Max(0, i - 30);
                int len = Math.Min(b.Length - start, 80);
                string raw = "";
                for (int k = start; k < start + len; k++) {
                    char c = (char)b[k];
                    raw += (c >= 32 && c <= 126) ? c : '.';
                }
                Console.WriteLine("Offset " + i + ": " + raw);
            }
        }
    }
}
