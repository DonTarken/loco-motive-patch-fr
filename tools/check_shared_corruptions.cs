using System;
using System.IO;
using System.Text;

class CheckSharedCorruptions {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\dialogues\shared_french.tsv", Encoding.UTF8);
        int corruptCount = 0;
        for (int i = 1; i < lines.Length; i++) {
            var p = lines[i].Split('\t');
            if (p.Length < 4) continue;
            string id = p[0];
            string ch = p[1];
            string en = p[2].Trim();
            string fr = p[3].Trim();

            // Compare simple signs: question in EN but not in FR, exclamation, length difference of 5x, etc.
            bool enQ = en.EndsWith("?");
            bool frQ = fr.EndsWith("?");
            bool enEx = en.EndsWith("!");
            bool frEx = fr.EndsWith("!");

            if ((enQ && !frQ && en.Length > 10) || (!enQ && frQ && en.Length > 10) ||
                (en.Length < 15 && fr.Length > 60) || (en.Length > 80 && fr.Length < 20)) {
                corruptCount++;
                if (corruptCount <= 20) {
                    Console.WriteLine(string.Format("L{0} [{1}] EN: [{2}] -> FR: [{3}]", i, id, en, fr));
                }
            }
        }
        Console.WriteLine("\nTotal suspicious corruptions in shared_french.tsv: " + corruptCount);
    }
}
