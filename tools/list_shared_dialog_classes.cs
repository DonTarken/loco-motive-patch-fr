using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class ListSharedDialogClasses {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\partitions\shared_dialogs.tsv", Encoding.UTF8);
        var counts = new Dictionary<string, int>();
        for (int i = 1; i < lines.Length; i++) {
            var p = lines[i].Split('\t');
            if (p.Length < 6) continue;
            string cls = p[4];
            int idx = cls.IndexOf('+');
            string baseCls = idx > 0 ? cls.Substring(0, idx) : cls;
            if (!counts.ContainsKey(baseCls)) counts[baseCls] = 0;
            counts[baseCls]++;
        }

        foreach (var kv in counts.OrderByDescending(x => x.Value)) {
            Console.WriteLine(string.Format("{0}: {1}", kv.Key, kv.Value));
        }
    }
}
