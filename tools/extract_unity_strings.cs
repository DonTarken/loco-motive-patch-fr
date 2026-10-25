using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class ExtractUnityStrings {
    static void Main() {
        string assetPath = @"D:\Games\Loco Motive\Loco Motive_Data\data.unity3d";
        byte[] b = File.ReadAllBytes(assetPath);

        var list = new Dictionary<int, string>();
        for (int i = 0; i < b.Length - 10; i++) {
            // Check if b[i] == '&'
            if (b[i] == (byte)'&') {
                // Check if preceded by 4-byte length
                if (i >= 4) {
                    int len = BitConverter.ToInt32(b, i - 4);
                    if (len >= 4 && len <= 500 && i + len <= b.Length) {
                        // Check if characters after & are digits followed by space
                        int k = i + 1;
                        while (k < i + len && b[k] >= '0' && b[k] <= '9') k++;
                        if (k > i + 1 && k < i + len && b[k] == ' ') {
                            // Extract full string
                            string raw = Encoding.UTF8.GetString(b, i, len);
                            int spaceIdx = raw.IndexOf(' ');
                            int id;
                            if (int.TryParse(raw.Substring(1, spaceIdx - 1), out id)) {
                                string content = raw.Substring(spaceIdx + 1).Trim();
                                if (!list.ContainsKey(id)) {
                                    list[id] = content;
                                }
                            }
                        }
                    }
                }
            }
        }

        Console.WriteLine("Total PowerQuest strings extracted with &ID: " + list.Count);
        // Sort by id
        var sorted = new List<KeyValuePair<int, string>>(list);
        sorted.Sort((x, y) => x.Key.CompareTo(y.Key));

        using (var sw = new StreamWriter(@"translations\dialogues\extracted_pq_all.tsv", false, Encoding.UTF8)) {
            sw.WriteLine("Id\tEnglish");
            foreach (var kvp in sorted) {
                sw.WriteLine(kvp.Key + "\t" + kvp.Value);
            }
        }
        Console.WriteLine("Saved to translations\\dialogues\\extracted_pq_all.tsv");

        // Print some examples
        int count = 0;
        foreach (var kvp in sorted) {
            if (count < 25) {
                Console.WriteLine("  [" + kvp.Key + "] " + kvp.Value);
                count++;
            }
        }
    }
}
