using System;
using System.IO;
using System.Text;

class CheckLanguages {
    static void Main() {
        // Let's inspect the game assets or check what languages exist
        byte[] b = File.ReadAllBytes(@"D:\Games\Loco Motive\Loco Motive_Data\data.unity3d");
        // Look for "English (UK)"
        int offset = 16784478; // offset of "English (UK)"
        // Let's read backwards to see the array count
        for (int i = offset - 40; i < offset + 120; i++) {
            Console.Write(b[i].ToString("X2") + " ");
        }
        Console.WriteLine();
    }
}
