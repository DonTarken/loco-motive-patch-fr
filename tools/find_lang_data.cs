using System;
using System.IO;
using System.Text;

class Test {
    static void Main() {
        string[] assetFiles = Directory.GetFiles(@"D:\Games\Loco Motive\Loco Motive_Data", "*.*");
        foreach (var file in assetFiles) {
            byte[] b = File.ReadAllBytes(file);
            byte[] target = Encoding.UTF8.GetBytes("English (UK)");
            for (int i = 0; i < b.Length - 500; i++) {
                bool found = true;
                for (int j = 0; j < target.Length; j++) {
                    if (b[i+j] != target[j]) { found = false; break; }
                }
                if (found) {
                    Console.WriteLine("Found in " + Path.GetFileName(file) + " at " + i);
                    int start = Math.Max(0, i - 100);
                    int end = Math.Min(b.Length, i + 300);
                    string s = "";
                    for (int k = start; k < end; k++) {
                        char c = (char)b[k];
                        if (c >= 32 && c <= 126) s += c;
                        else s += '.';
                    }
                    Console.WriteLine(s);
                }
            }
        }
    }
}
