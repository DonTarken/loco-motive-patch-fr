using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class CategorizeShared {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\partitions\shared_missing.tsv", Encoding.UTF8);

        var dialogs = new List<string>();
        var itemUses = new List<string>();
        var roomLooks = new List<string>();
        var characterInteractions = new List<string>();
        var other = new List<string>();

        for (int i = 1; i < lines.Length; i++) {
            var l = lines[i];
            var p = l.Split('\t');
            if (p.Length < 6) continue;
            string cls = p[4];
            if (cls.StartsWith("Dialog")) {
                dialogs.Add(l);
            } else if (cls.Contains("OnUseInv")) {
                itemUses.Add(l);
            } else if (cls.Contains("OnLookAt")) {
                roomLooks.Add(l);
            } else if (cls.StartsWith("Character")) {
                characterInteractions.Add(l);
            } else {
                other.Add(l);
            }
        }

        Console.WriteLine(string.Format("Dialogs: {0}", dialogs.Count));
        Console.WriteLine(string.Format("Item Uses (OnUseInv): {0}", itemUses.Count));
        Console.WriteLine(string.Format("Room Looks (OnLookAt): {0}", roomLooks.Count));
        Console.WriteLine(string.Format("Character Interactions: {0}", characterInteractions.Count));
        Console.WriteLine(string.Format("Other (Cutscenes/Room interactions): {0}", other.Count));

        WriteFile(@"translations\partitions\shared_dialogs.tsv", dialogs);
        WriteFile(@"translations\partitions\shared_item_uses.tsv", itemUses);
        WriteFile(@"translations\partitions\shared_room_looks.tsv", roomLooks);
        WriteFile(@"translations\partitions\shared_char_interactions.tsv", characterInteractions);
        WriteFile(@"translations\partitions\shared_cutscenes.tsv", other);
    }

    static void WriteFile(string path, List<string> lines) {
        using (var sw = new StreamWriter(path, false, Encoding.UTF8)) {
            sw.WriteLine("Id\tCharacter\tEnglish\tFrench\tClass\tMethod");
            foreach (var l in lines) sw.WriteLine(l);
        }
    }
}
