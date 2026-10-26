using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class Program {
    static void Main() {
        byte[] b = File.ReadAllBytes(@"D:\Games\Loco Motive\Loco Motive_Data\data.unity3d");
        
        string[] sampleItems = new string[] { 
            "AnkletKey", "Newspaper", "Fan", "Umbrella", "Chains", "FunnelFan", 
            "Coffee", "LetterToArthur", "BlueSuit", "Keys" 
        };
        
        foreach (var item in sampleItems) {
            byte[] target = Encoding.UTF8.GetBytes(item);
            Console.WriteLine("\n=== Searching for " + item + " ===");
            int count = 0;
            for (int i = 0; i < b.Length - target.Length && count < 2; i++) {
                bool match = true;
                for (int j = 0; j < target.Length; j++) {
                    if (b[i + j] != target[j]) { match = false; break; }
                }
                if (match) {
                    count++;
                    int start = Math.Max(0, i - 100);
                    int end = Math.Min(b.Length, i + 300);
                    var sb = new StringBuilder();
                    for (int k = start; k < end; k++) {
                        if (b[k] >= 32 && b[k] <= 126) sb.Append((char)b[k]);
                        else {
                            if (sb.Length >= 3 && !sb.ToString().Contains("UnityEngine") && !sb.ToString().Contains("GameObject")) {
                                Console.WriteLine("  " + sb.ToString());
                            }
                            sb.Length = 0;
                        }
                    }
                }
            }
        }
    }
}
