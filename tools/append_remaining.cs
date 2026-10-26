using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class AppendRemaining {
    static void Main() {
        var map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        // Names & interjections
        map["Lady Unterwald."] = "Lady Unterwald.";
        map["Hmm."] = "Hmm.";
        map["Hmm..."] = "Hmm...";
        map["Mmmh."] = "Mmmh.";
        map["Hrmm."] = "Hrmm.";
        map["Hrmm-hmm."] = "Hrmm-hmm.";
        map["Hrm-hmm."] = "Hrm-hmm.";
        map["Hrmph."] = "Hrmpf.";
        map["Mmmpfff."] = "Mmmpfff.";
        map["Oh."] = "Oh.";
        map["Ohhh."] = "Ohhh.";
        map["Ohhhh."] = "Ohhhh.";
        map["Ah."] = "Ah.";
        map["Psst."] = "Psst.";
        map["Mm-hmm."] = "Mm-hmm.";
        map["Mm-hm."] = "Mm-hm.";
        map["Mmff."] = "Mmff.";
        map["AAAAARGHHHHH."] = "AAAAARGHHHHH.";
        map["BLAAAARRRGGHH."] = "BLAAAARRRGGHH.";
        map["Ha HA hA"] = "Ha HA hA";
        map["Six..."] = "Six...";
        map["Rose..."] = "Rose...";
        map["bud."] = "...bud.";
        map["Jian Liu."] = "Jian Liu.";
        map["Arthur Ackerman."] = "Arthur Ackerman.";
        map["Susanne Goldschmidt."] = "Susanne Goldschmidt.";
        map["Antoine Cassoulet."] = "Antoine Cassoulet.";
        map["Diana."] = "Diana.";
        map["Herman..."] = "Herman...";
        map["Oui ?"] = "Oui ?";
        map["Non mais, et puis quoi encore !"] = "Non mais, et puis quoi encore !";
        map["Dépêchez-vous !"] = "Dépêchez-vous !";
        map["Entremétier ?"] = "Entremétier ?";
        map["Excellent."] = "Excellent.";

        // Song titles
        map["Railroad Rhythm."] = "Rythme ferroviaire.";
        map["Whistle Stop Swing."] = "Swing des gares.";
        map["Boxcar Boogie."] = "Boogie des wagons.";
        map["My Love is on the Line."] = "Mon amour est sur les rails.";
        map["Freight Train Blues."] = "Le blues du train de marchandises.";

        // Multiline strings
        map["Prepare to board the Reuss Express for a 20-minute\ntimed demo of this murder mystery comedy adventure."] = "Préparez-vous à monter à bord du Reuss Express pour une démo\nchronométrée de 20 minutes de cette comédie policière.";
        map["Prepare to board the Reuss Express for an exclusive\ndemo of this murder mystery comedy adventure. \n"] = "Préparez-vous à monter à bord du Reuss Express pour une démo\nexclusive de cette comédie policière.\n";
        map["Three playable characters in a\nfeature-length story!"] = "Trois personnages jouables dans une\ngrande histoire passionnante !";
        map["Click {0} to walk.\nHold {1} to run to an object or area."] = "Cliquez sur {0} pour marcher.\nMaintenez {1} pour courir vers un objet ou une zone.";
        map["Use {0} to walk.\nHold down {1} or {2} to run."] = "Utilisez {0} pour marcher.\nMaintenez {1} ou {2} pour courir.";
        map["Tap {0} to walk.\nHold down {1} or {2} to run."] = "Touchez {0} pour marcher.\nMaintenez {1} ou {2} pour courir.";

        string path = @"translations\ui\interactions_french.tsv";
        using (var sw = new StreamWriter(path, true, Encoding.UTF8)) {
            foreach (var kvp in map) {
                sw.WriteLine(kvp.Key.Replace("\n", " \\n ") + "\t" + kvp.Value.Replace("\n", " \\n "));
            }
        }
        Console.WriteLine("Appended " + map.Count + " entries to " + path);
    }
}
