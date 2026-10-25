using System;
using System.IO;
using System.Text;

class SearchData {
    static void Main() {
        string path = @"D:\Games\Loco Motive\Loco Motive_Data\data.unity3d";
        byte[] target = Encoding.UTF8.GetBytes("My hands are clean");
        
        using (var fs = File.OpenRead(path)) {
            byte[] buffer = new byte[1024 * 1024 * 16]; // 16MB chunks
            long totalRead = 0;
            int bytesRead;

            while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0) {
                for (int i = 0; i < bytesRead - target.Length; i++) {
                    bool match = true;
                    for (int j = 0; j < target.Length; j++) {
                        if (buffer[i + j] != target[j]) { match = false; break; }
                    }
                    if (match) {
                        long matchPos = totalRead + i;
                        Console.WriteLine("Match found at offset " + matchPos);
                        int start = Math.Max(0, i - 200);
                        int len = Math.Min(bytesRead - start, 1500);
                        string context = Encoding.UTF8.GetString(buffer, start, len);
                        Console.WriteLine("Context:\n" + context);
                    }
                }
                totalRead += bytesRead;
            }
        }
    }
}
