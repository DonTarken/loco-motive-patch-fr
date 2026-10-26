using System;
using System.IO;
using System.Text;

class SearchSubstrings {
    static void Main() {
        string path = @"D:\Games\Loco Motive\Loco Motive_Data\data.unity3d";
        string[] targets = new string[] { "pamphlet", "carriage direction", "looks busy", "Eavesdrop", "eavesdrop" };
        
        using (var fs = File.OpenRead(path)) {
            byte[] buffer = new byte[1024 * 1024 * 16];
            long totalRead = 0;
            int bytesRead;

            while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0) {
                foreach (var targetStr in targets) {
                    byte[] target = Encoding.UTF8.GetBytes(targetStr);
                    for (int i = 0; i < bytesRead - target.Length; i++) {
                        bool match = true;
                        for (int j = 0; j < target.Length; j++) {
                            if (buffer[i + j] != target[j]) { match = false; break; }
                        }
                        if (match) {
                            long matchPos = totalRead + i;
                            Console.WriteLine(string.Format("Match '{0}' at offset {1}", targetStr, matchPos));
                            int start = Math.Max(0, i - 80);
                            int len = Math.Min(bytesRead - start, 300);
                            for (int k = start; k < start + len; k++) {
                                byte b = buffer[k];
                                if (b >= 32 && b <= 126) Console.Write((char)b);
                                else Console.Write(".");
                            }
                            Console.WriteLine("\n---");
                        }
                    }
                }
                totalRead += bytesRead;
            }
        }
    }
}
