using System;
using System.IO;
using System.Text;

class DumpB3 {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\partitions\engine_b3.tsv", Encoding.UTF8);
        using (var sw = new StreamWriter(@"tools\engine_b3_list.txt", false, Encoding.UTF8)) {
            for (int i = 1; i < lines.Length; i++) {
                var p = lines[i].Split('\t');
                sw.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}\t{4}", i, p[0], p[1], p[2], p[3]));
            }
        }
        Console.WriteLine("Done dumping " + (lines.Length - 1) + " lines.");
    }
}
