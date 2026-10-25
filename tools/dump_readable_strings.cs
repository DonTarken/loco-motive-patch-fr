using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class DumpReadableStrings {
    static void Main() {
        byte[] b = File.ReadAllBytes(@"D:\Games\Loco Motive\Loco Motive_Data\data.unity3d");
        int center = 157208872;
        int start = Math.Max(0, center - 100000);
        int end = Math.Min(b.Length, center + 100000);

        var list = new List<string>();
        int curStart = -1;
        for (int i = start; i < end; i++) {
            byte c = b[i];
            if ((c >= 32 && c <= 126)) {
                if (curStart == -1) curStart = i;
            } else {
                if (curStart != -1) {
                    int len = i - curStart;
                    if (len >= 3) {
                        string s = Encoding.ASCII.GetString(b, curStart, len);
                        list.Add(s);
                    }
                    curStart = -1;
                }
            }
        }

        Console.WriteLine("Total readable strings found: " + list.Count);
        using (var sw = new StreamWriter(@"translations\dialogues\room_interrogation_raw_strings.txt", false, Encoding.UTF8)) {
            foreach (var s in list) {
                // Filter out obviously binary garbage
                if (s.Contains(" ") || s.StartsWith("&") || s.StartsWith("Prop") || s.StartsWith("Hotspot")) {
                    sw.WriteLine(s);
                }
            }
        }
        Console.WriteLine("Saved to translations\\dialogues\\room_interrogation_raw_strings.txt");
    }
}
