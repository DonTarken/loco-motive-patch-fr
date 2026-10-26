using System;
using System.IO;
using System.Text;

class ParseSystemTextInUnity {
    static void Main() {
        string path = @"D:\Games\Loco Motive\Loco Motive_Data\data.unity3d";
        byte[] data = File.ReadAllBytes(path);

        // Find "English (UK)" at 16784478
        // Let's print each string around here
        int start = 16784400;
        int end = 16784650;
        int i = start;
        while (i < end) {
            // Find printable ASCII string
            if (data[i] >= 32 && data[i] <= 126) {
                int s = i;
                while (i < end && data[i] >= 32 && data[i] <= 126) i++;
                int len = i - s;
                if (len >= 2) {
                    Console.WriteLine(string.Format("Offset {0:X8}: \"{1}\"", s, Encoding.UTF8.GetString(data, s, len)));
                }
            } else {
                i++;
            }
        }
    }
}
