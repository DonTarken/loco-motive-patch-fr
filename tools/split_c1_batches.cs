using System;
using System.IO;
using System.Collections.Generic;

class SplitC1Batches {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\partitions\chapter1_missing.tsv");
        var b1 = new List<string>();
        var b2 = new List<string>();
        var b3 = new List<string>();
        var b4 = new List<string>();

        foreach (var l in lines) {
            var parts = l.Split('\t');
            if (parts.Length < 6) continue;
            string cls = parts[4];
            if (cls.Contains("Handshake") || cls.Contains("Brother") || cls.Contains("Gretchen") || cls.Contains("Artist")) {
                b1.Add(l);
            } else if (cls.Contains("Dining") || cls.Contains("Bartender") || cls.Contains("Masson") || cls.Contains("Waiter") || cls.Contains("Kitchen") || cls.Contains("Chef") || cls.Contains("Pierre")) {
                b2.Add(l);
            } else if (cls.Contains("Casino") || cls.Contains("Don") || cls.Contains("Cashier") || cls.Contains("Enforcer") || cls.Contains("Harold") || cls.Contains("Mary") || cls.Contains("Edna")) {
                b3.Add(l);
            } else {
                b4.Add(l);
            }
        }

        File.WriteAllLines(@"translations\partitions\c1_b1_handshake.tsv", b1.ToArray());
        File.WriteAllLines(@"translations\partitions\c1_b2_dining_kitchen.tsv", b2.ToArray());
        File.WriteAllLines(@"translations\partitions\c1_b3_casino_don.tsv", b3.ToArray());
        File.WriteAllLines(@"translations\partitions\c1_b4_unterwald_quarters.tsv", b4.ToArray());

        Console.WriteLine(string.Format("Batches created:\n  B1 Handshake: {0}\n  B2 Dining/Kitchen: {1}\n  B3 Casino/Don: {2}\n  B4 Unterwald/Quarters: {3}\n  Total: {4}",
            b1.Count, b2.Count, b3.Count, b4.Count, b1.Count + b2.Count + b3.Count + b4.Count));
    }
}
