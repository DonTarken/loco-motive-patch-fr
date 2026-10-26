using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class PolishPrologue {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\dialogues\prologue_french.tsv");
        var fixes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
            { "Rangez cela, Arthur.", "Rangez-moi ça, Arthur." },
            { "En fait, cela me suffit amplement.", "En fait, ça me suffit amplement." },
            { "Très bien, cela explique comment vous êtes montée à bord. Que s'est-il passé ensuite ?", "Très bien, voilà qui explique comment vous êtes montée à bord. Que s'est-il passé ensuite ?" },
            { "Je ne peux pas partir maintenant, j'ai une mission à accomplir !", "Hors de question de filer maintenant, j'ai une mission à boucler !" },
            { "Je ne peux pas retourner là-dedans, c'est trop humiliant !", "Pas moyen que je remette les pieds là-dedans, la honte absolue !" }
        };

        int modified = 0;
        for (int i = 0; i < lines.Length; i++) {
            foreach (var kvp in fixes) {
                if (lines[i].Contains(kvp.Key)) {
                    lines[i] = lines[i].Replace(kvp.Key, kvp.Value);
                    modified++;
                }
            }
        }

        File.WriteAllLines(@"translations\dialogues\prologue_french.tsv", lines, Encoding.UTF8);
        Console.WriteLine("Polished prologue_french.tsv with " + modified + " updates.");
    }
}
