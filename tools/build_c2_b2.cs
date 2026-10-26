using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class BuildC2B2 {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\partitions\c2_b2_herman_board.tsv");
        var map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        map["Just a little further..."] = "Encore un tout petit effort...";
        map["Herman, you genius, is that the missing will?"] = "Herman, espèce de génie, ne serait-ce pas le testament égaré ?";
        map["If I can grab hold of it, we'll be one step closer to solving this thing!"] = "Si je réussis à l'attraper, nous aurons fait un pas de géant vers la résolution du mystère !";
        map["Oh my god!"] = "Bonté divine !";
        map["That sneaky little rat stole my keys!"] = "Ce maudit rat sournois a chipé mes clés !";
        map["Just wait until I get my hands on them!"] = "Attends un peu que je mette la main dessus !";
        map["Thank you, Herman, what an interesting pitch."] = "Merci Herman, quelle présentation fort intéressante.";
        map["And what a title!"] = "Et quel titre marquant !";
        map["And we just think it's so brave of you to come here and pitch us another crime novel."] = "Et nous trouvons cela tellement courageux de venir nous présenter un autre roman policier.";
        map["Especially considering the current landscape."] = "Surtout compte tenu du marché actuel.";
        map["Thank you! But what do you mean?"] = "Merci ! Mais que voulez-vous dire par là ?";
        map["Well, there's no easy way to say this..."] = "Eh bien, il n'y a pas de façon délicate de vous l'annoncer...";
        map["The data indicates a sharp decline in your particular brand of fiction."] = "Les chiffres indiquent une chute vertigineuse pour votre genre particulier de fiction.";
        map["We've also run into some problems with your branding deals."] = "Nous rencontrons aussi de sérieux déboires avec vos produits dérivés.";
        map["Surely not the Herman Merman dolls? You assured me they'd be a hit!"] = "Pas les poupées Herman Merman tout de même ? Vous m'aviez garanti un carton absolu !";
        map["I'm afraid so, Herman."] = "J'en ai bien peur, Herman.";
        map["We can't even give these away!"] = "On n'arrive même pas à les donner gratuitement !";
        map["Stop that! I don't like it!"] = "Arrêtez ça ! Ça ne me plaît pas du tout !";
        map["Well, what do you suggest we do?"] = "Alors, que suggérez-vous qu'on fasse ?";
        map["Not to worry."] = "Ne vous en faites pas.";
        map["We're already prototyping an exciting line of Dirk Chiselton products!"] = "Nous concevons déjà les prototypes d'une formidable gamme de produits Dirk Chiselton !";
        map["Ahem! This is just a prototype, of course."] = "Ahem ! Ce n'est qu'un prototype, évidemment.";
        map["Very much still in the early development phase."] = "Nous n'en sommes qu'aux balbutiements du développement.";
        map["So that's it then, I've been replaced?"] = "C'est donc ça ? On m'a déjà remplacé ?";
        map["Nobody said you're being replaced, Herman."] = "Personne n'a dit que vous étiez remplacé, Herman.";
        map["We're simply... How do we say this?"] = "Nous sommes simplement... comment dire cela diplomatiquement ?";
        map["Exploring new avenues!"] = "En train d'explorer de nouvelles voies !";
        map["Yes, that's it!"] = "Oui, c'est exactement ça !";
        map["I do feel you're making a big mistake here."] = "J'ai la nette impression que vous commettez une grossière erreur.";
        map["Herman Merman And The Suburban Burden is a goldmine!"] = "Herman Merman et le Fardeau de Banlieue est une véritable mine d'or !";
        map["I'm afraid it's ultimately out of our hands, Herman."] = "Hélas, cela ne dépend plus de nous, Herman.";
        map["But if you feel strongly about this idea, we could always petition the board."] = "Mais si vous y tenez tant, nous pouvons toujours soumettre votre idée au Conseil.";
        map["The board?"] = "Le Conseil ?";
        map["PITCH TO ME, IF YOU DARE!"] = "PRÉSENTE TON PROJET, SI TU L'OSES !";
        map["BEHOLD!"] = "REGARDEZ ET TREMBLEZ !";
        map["I ALONE CONTROL THE MEANS OF PRODUCTION!"] = "MOI SEUL CONTRÔLE LES MOYENS DE PRODUCTION !";
        map["Go ahead, Herman."] = "Allez-y, Herman.";
        map["Just place your manuscript into the slot, and we'll give the ol' algorithm a spin!"] = "Insérez simplement votre manuscrit dans la fente, et laissons tourner le vieil algorithme !";
        map["DETERMINING MARKET VALUE."] = "ÉVALUATION DE LA VALEUR MARCHANDE EN COURS.";
        map["UNAPPEALING PROTAGONIST."] = "PROTAGONISTE DÉPOURVU DE CHARISME.";
        map["MARGINS BELOW THRESHOLD."] = "MARGES INFÉRIEURES AU SEUIL DE RENTABILITÉ.";
        map["UNSATISFACTORY TARGET DEMOGRAPHIC."] = "CIBLE DÉMOGRAPHIQUE DÉFAVORABLE.";
        map["MANUSCRIPT DENIED."] = "MANUSCRIT REJETÉ.";
        map["Ah. Well, there you have it!"] = "Ah. Eh bien, voilà qui est clair !";
        map["We all really enjoyed your pitch, but the board doesn't seem to agree."] = "Nous avons tous adoré votre projet, mais le Conseil ne semble pas de cet avis.";
        map["If you have anything else to pitch, we'd be glad to hear it, though!"] = "Si vous avez une autre idée à nous soumettre, nous serions ravis de l'écouter !";
        map["DON'T QUIT YOUR DAY JOB."] = "NE DÉMISSIONNE PAS DE TON VRAI TRAVAIL.";
        map["Wait, you want me to pitch something else?"] = "Attendez, vous voulez que je vous propose autre chose ?";
        map["You're a valued client, Herman!"] = "Vous êtes un auteur précieux pour nous, Herman !";
        map["Just let us know when you're ready."] = "Faites-nous signe dès que vous êtes prêt.";
        map["Alright, Herman, we can certainly check with you know who..."] = "Très bien, Herman, nous pouvons toujours vérifier avec vous-savez-qui...";
        map["AAAAARGHHHHH."] = "AAAAARGHHHHH.";
        map["Ah. I'm afraid they're quite insistent that you deliver."] = "Ah. J'ai bien peur qu'ils insistent lourdement pour que vous livriez la marchandise.";
        map["If there's anything we can do to help, just let us know!"] = "Si nous pouvons faire quoi que ce soit pour vous aider, faites-le nous savoir !";
        map["Wait, where are my keys? Blast!"] = "Attendez, où sont mes clés ? Bon sang de bois !";
        map["I'm locked out without my room keys."] = "Je suis enfermé dehors sans les clés de ma cabine.";
        map["Who knows what sinister plotting they're doing in there?"] = "Qui sait quelles machinations diaboliques ils fomentent là-dedans ?";
        map["Oh nothing, darling."] = "Oh rien du tout, mon trésor.";
        map["Lady Unterwald, what is the meaning of this?"] = "Lady Unterwald, que signifie tout cela ?";
        map["Indeed?"] = "Vraiment ?";
        map["I assumed you required the services of a world-famous detective?"] = "Je supposais que vous aviez besoin des services d'un détective de renommée mondiale ?";
        map["I'll do it! Herman Merman never backs away from a case!"] = "Je m'en charge ! Jamais Herman Merman ne recule devant une affaire !";
        map["You think Mr Liu has an ulterior motive?"] = "Vous pensez que M. Liu a une idée derrière la tête ?";
        map["I'll certainly do my best, Lady Unterwald!"] = "Je ferai de mon mieux, Lady Unterwald !";
        map["Of course, Herman Merman won't let you down!"] = "Bien sûr, Herman Merman ne vous décevra pas !";

        // Write output TSV
        int count = 0;
        using (var sw = new StreamWriter(@"translations\partitions\c2_b2_french.tsv", false, Encoding.UTF8)) {
            sw.WriteLine("Id\tCharacter\tEnglish\tFrench\tClass\tMethod");
            foreach (var l in lines) {
                var p = l.Split('\t');
                if (p.Length < 6) continue;
                string en = p[2].Trim();
                string fr = "";
                if (map.ContainsKey(en)) {
                    fr = map[en];
                } else {
                    fr = en;
                }
                sw.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", p[0], p[1], en, fr, p[4], p[5]));
                if (!string.IsNullOrEmpty(fr) && fr != en) count++;
            }
        }
        Console.WriteLine(string.Format("Generated c2_b2_french.tsv: {0} lines translated out of {1}", count, lines.Length));
    }
}
