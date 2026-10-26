using System;
using System.IO;
using System.Text;

class DumpBatchRange {
    static void Main(string[] args) {
        if (args.Length < 3) {
            Console.WriteLine("Usage: DumpBatchRange <file> <start> <count>");
            return;
        }
        string file = args[0];
        int start = int.Parse(args[1]);
        int count = int.Parse(args[2]);

        var lines = File.ReadAllLines(file, Encoding.UTF8);
        for (int i = start; i < start + count && i < lines.Length; i++) {
            Console.WriteLine(string.Format("{0,3}: {1}", i, lines[i]));
        }
    }
}
