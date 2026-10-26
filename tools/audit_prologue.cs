using System;
using System.IO;

class AuditPrologue {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\dialogues\prologue_french.tsv");
        Console.WriteLine("Lines in prologue_french.tsv: " + lines.Length);
        int audited = 0;
        foreach (var l in lines) {
            if (string.IsNullOrWhiteSpace(l)) continue;
            var parts = l.Split('\t');
            string en = parts.Length >= 4 ? parts[2] : (parts.Length == 2 ? parts[0] : "");
            string fr = parts.Length >= 4 ? parts[3] : (parts.Length == 2 ? parts[1] : "");
            
            // Check for known literalisms
            if (fr.Contains("ne peux pas") || fr.Contains("ne puis") || fr.Contains("cela") || fr.Contains("chose") || fr.Contains("faire cela")) {
                Console.WriteLine(string.Format("LITERAL? EN: {0}\n        FR: {1}\n", en, fr));
                audited++;
            }
        }
        Console.WriteLine("Audit flagged entries: " + audited);
    }
}
