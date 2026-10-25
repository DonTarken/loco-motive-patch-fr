using System;
using System.IO;
using System.Text;

class SearchLang {
    static void Main() {
        string path = @"D:\Games\Loco Motive\Loco Motive_Data\data.unity3d";
        byte[] target = Encoding.UTF8.GetBytes("English (UK)");
        
        using (var fs = File.OpenRead(path)) {
            byte[] buffer = new byte[1024 * 1024 * 16];
            long totalRead = 0;
            int bytesRead;

            while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0) {
                for (int i = 0; i < bytesRead - target.Length; i++) {
                    bool match = true;
                    for (int j = 0; j < target.Length; j++) {
                        if (buffer[i + j] != target[j]) { match = false; break; }
                    }
                    if (match) {
                        Console.WriteLine("Found at offset " + (totalRead + i));
                        int start = Math.Max(0, i - 100);
                        int len = Math.Min(bytesRead - start, 400);
                        Console.WriteLine("Context:\n" + Encoding.UTF8.GetString(buffer, start, len));
                    }
                }
                totalRead += bytesRead;
            }
        }
    }
}
