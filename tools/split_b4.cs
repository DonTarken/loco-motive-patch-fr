using System;
using System.IO;
using System.Collections.Generic;

class SplitB4 {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\partitions\c2_b4_scenes.tsv");
        var b4a = new List<string>();
        var b4b = new List<string>();

        foreach (var l in lines) {
            var parts = l.Split('\t');
            if (parts.Length < 6) continue;
            string cls = parts[4];
            if (cls.Contains("Handshake") || cls.Contains("Brother") || cls.Contains("Gretchen") || cls.Contains("Chef") || cls.Contains("Kitchen")) {
                b4a.Add(l);
            } else {
                b4b.Add(l);
            }
        }

        File.WriteAllLines(@"translations\partitions\c2_b4_handshake_chefs.tsv", b4a.ToArray());
        File.WriteAllLines(@"translations\partitions\c2_b5_rooms_passengers.tsv", b4b.ToArray());
        Console.WriteLine(string.Format("Split into B4 Handshake/Chefs: {0}, B5 Rooms/Passengers: {1}", b4a.Count, b4b.Count));
    }
}
