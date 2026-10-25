using System;
using System.IO;
using System.Text;

class DumpOffset {
    static void Main() {
        string path = @"D:\Games\Loco Motive\Loco Motive_Data\data.unity3d";
        using (var fs = File.OpenRead(path)) {
            fs.Seek(18864046 - 20, SeekOrigin.Begin);
            byte[] buf = new byte[300];
            fs.Read(buf, 0, buf.Length);
            for (int i = 0; i < buf.Length; i++) {
                Console.Write(buf[i].ToString("X2") + " ");
                if ((i + 1) % 16 == 0) Console.WriteLine();
            }
            Console.WriteLine("\nASCII:\n" + Encoding.ASCII.GetString(buf));
        }
    }
}
