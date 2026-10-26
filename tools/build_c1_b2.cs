using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class BuildC1B2 {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\partitions\c1_b2_dining_kitchen.tsv");
        var map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        // --- Bartender & Arthur drunk ---
        map["Hey! You're looking a little worse for wear there, pal."] = "Hé là ! Vous m'avez l'air dans un sale état, l'ami.";
        map["I'm ferfectly pine, I asshure you."] = "Je me porrrte à marrveille, je vous asschure.";
        map["Here's a coffee, on the house."] = "Tenez, un bon café noir. C'est offert par la maison.";
        map["Thanksh!"] = "Merrrci !";
        map["Evening, Barkeep!"] = "Bonsoir, barman !";
        map["What'll it be?"] = "Qu'est-ce que ce sera ?";
        map["That's the plant fibres, and the floral essence, accounted for."] = "Voilà les fibres végétales et l'essence florale au complet.";
        map["Everything I need to make a Rosebud."] = "Tout ce qu'il me faut pour préparer un Rosebud.";
        map["Now, I can't legally give you the real deal if you're anywhere under 200lbs."] = "Légalement, je ne peux pas vous servir l'original si vous faites moins de 90 kilos.";
        map["Your liver would give in."] = "Votre foie n'y survivrait pas.";
        map["So what can you give me?"] = "Alors, qu'est-ce que vous pouvez me servir ?";
        map["I'll make you a Bud-Lite."] = "Je vais vous concocter une Bud-Lite.";
        map["It has all of the flavour of the Rosebud."] = "Elle a tout l'arôme du Rosebud.";
        map["But you'll still be able to..."] = "Mais vous serez encore capable de...";
        map["you know..."] = "vous voyez...";
        map["Form sentences?"] = "Formuler des phrases ?";
        map["Precisely."] = "Précisément.";
        map["It's delicious!"] = "C'est délicieux !";
        map["Enjoy!"] = "Santé !";
        map["I might be able to make it stronger with some experimentation."] = "Je pourrais peut-être la corser un peu avec quelques expériences.";
        map["And something to mix it all up in."] = "Et un récipient pour touiller le tout.";

        // --- Don at the dining table ---
        map["The name's Donnola, kid."] = "Mon nom est Donnola, petit.";
        map["But most people call me Don, or Donny. You get my gist?"] = "Mais la plupart m'appellent Don, ou Donny. Tu piges le topo ?";
        map["That's a nice suit. So what's your deal, you some sort of tycoon or something?"] = "Joli costard. C'est quoi ton rayon, t'es une sorte de magnat de la finance ou quoi ?";
        map["Well, not really. You see, there's this old lady who told me to put it on, and I-"] = "Eh bien, pas tout à fait. Voyez-vous, c'est une vieille dame qui m'a ordonné de l'enfiler, et je...";
        map["Let me stop you there, I don't think I wanna know more."] = "Arrête-toi là, je préfère pas en savoir plus.";
        map["Besides, you're killing my vibe with that sweet patootie over there, you dig?"] = "En plus, tu me casses mon coup avec la ravissante poupée là-bas, tu piges ?";
        map["You delivered my proposal yet, kid?"] = "T'as remis ma proposition, petit ?";
        map["Oh, not yet."] = "Oh, pas encore.";
        map["You gotta give it to the dame behind me, ya dig?"] = "Faut que tu la donnes à la dame derrière moi, tu piges ?";
        map["Ehh, I'll talk to him later."] = "Euh, je lui parlerai plus tard.";
        map["Come back when you've handed over that note."] = "Reviens quand t'auras refilé ce mot.";

        // --- Masson & Arthur drunk bickering ---
        map["Mmm-wah?"] = "Mmm-ouah ?";
        map["Mr Masson?"] = "M. Masson ?";
        map["Muahh, I see you're enjoying my shignature drink?"] = "Mouah, je vois que vous appréciez mon cockschail signature ?";
        map["Good man!"] = "Bravo mon brave !";
        map["Ah, so you've finally schobered up?"] = "Ah, vous avez enfin desschoulé ?";
        map["Muah, of coursshe I haven't!"] = "Mouah, bien schûr que non !";
        map["Don't you see? We're the ssschame amount of drunk."] = "Vous ne voyez pas ? Nous sommes au mêêême niveau d'ébriété.";
        map["Ohhh. I guess that makes sschense?"] = "Ohhh. J'imagine que ça a du sschsens ?";
        map["What do you want, my dear boy?"] = "Que désirez-vous, mon cher petit ?";
        map["Thanks for the help, Mr Masson."] = "Merci pour votre aide, M. Masson.";
        map["MmEmAAw! *Hic*"] = "MmEmAAw ! *Hips*";
        map["t *Hic*"] = "*Hips*";
        map["I should leave him to rest."] = "Je devrais le laisser se reposer.";
        map["I'm sorry for your loss."] = "Je suis désolé pour votre perte.";
        map["Monsieur, I've lost everything!"] = "Monsieur, j'ai tout perdu !";
        map["You must have been very close."] = "Vous deviez être très proches.";
        map["No, it's not that..."] = "Non, ce n'est pas ça...";
        map["She owed me so much money!"] = "Elle me devait tellement d'argent !";
        map["I was going to get paid after the speech."] = "Je devais être payé juste après le discours.";
        map["Oh."] = "Oh.";
        map["There, there."] = "Là, là, du calme.";
        map["Not now, Monsieur. Can't you see I'm with my latest muse?"] = "Pas maintenant, Monsieur. Vous ne voyez pas que je suis avec ma toute nouvelle muse ?";
        map["Oh, Pierre, you do know how to flatter me."] = "Oh, Pierre, vous savez si bien flatter une femme.";

        // --- Waiter Dialogues ---
        map["Where can I get a drink?"] = "Où puis-je prendre un verre ?";
        map["You'll have to enquire at the bar, sir."] = "Il faudra vous adresser au bar, monsieur.";
        map["What's this I'm hearing about a rodent problem?"] = "Qu'est-ce que j'entends au sujet d'un problème de rongeurs ?";
        map["Nothing to concern yourself with, sir."] = "Rien d'inquiétant, monsieur.";
        map["Some of the passengers are complaining about missing valuables."] = "Certains passagers se plaignent de disparitions d'objets de valeur.";
        map["They believe a common rodent to be stealing from them."] = "Ils pensent qu'un vulgaire rongeur est en train de les détrousser.";
        map["So there isn't a rodent sneaking around stealing jewellery?"] = "Il n'y a donc aucun rongeur qui rôde pour voler des bijoux ?";
        map["The Reuss Express is vermin free, I assure you."] = "Le Reuss Express est exempt de toute vermine, je vous l'assure.";
        map["I suspect certain passengers have merely been careless with their valuables."] = "Je soupçonne certains passagers d'avoir simplement été négligents avec leurs biens précieux.";
        map["Is it too late to order from the kitchen?"] = "Est-il trop tard pour commander en cuisine ?";
        map["I'm afraid the kitchen is temporarily closed for repairs."] = "J'ai bien peur que la cuisine soit temporairement fermée pour maintenance.";
        map["What repairs are taking place in the kitchen?"] = "Quels genres de réparations ont lieu en cuisine ?";
        map["Ah, there's nothing to be concerned about."] = "Ah, rien qui ne doive vous tracasser.";
        map["I believe the kitchen staff encountered an overzealous health inspector."] = "Il semble que le personnel ait eu affaire à un inspecteur d'hygiène un peu trop zélé.";
        map["Do you know when the kitchen will reopen?"] = "Savez-vous quand la cuisine rouvrira ?";
        map["I'm sure things will be up and running again shortly."] = "Tout rentrera dans l'ordre d'ici peu, j'en suis convaincu.";
        map["Just as soon as the kitchen staff have regained their composure."] = "Dès que les cuisiniers auront retrouvé leur calme olympien.";
        map["Did you see anything during Lady Unterwald's speech?"] = "Avez-vous vu quelque chose pendant le discours de Lady Unterwald ?";
        map["Apart from a traumatic event I shall never recover from?"] = "Hormis un drame traumatisant dont je ne me remettrai jamais ?";
        map["Yes, of course. Did you see anything suspicious?"] = "Oui, bien sûr. Avez-vous remarqué quelque chose de suspect ?";
        map["We were all thrown into darkness, as you well know."] = "Nous étions tous plongés dans l'obscurité, comme vous le savez.";
        map["If you're asking me to identify a suspect, I can't help you."] = "Si vous me demandez d'identifier un suspect, j'en suis bien incapable.";
        map["I'll see you around!"] = "À plus tard !";

        // --- Arthur monologue & Investigation ---
        map["I need to find out who killed Lady Unterwald, or I could be the next one to vanish!"] = "Je dois découvrir qui a tué Lady Unterwald, ou je serai le prochain à disparaître !";
        map["I'll need to talk to the other passengers, maybe they saw something."] = "Je dois interroger les autres passagers, ils ont peut-être vu quelque chose.";
        map["Lady Unterwald's quarters could hold some clues."] = "Les quartiers de Lady Unterwald pourraient receler des indices.";
        map["Thanks for dealing with Don, Arthur."] = "Merci d'avoir géré le cas de Don, Arthur.";
        map["I know you didn't have to help me, considering the circumstances."] = "Je sais que vous n'étiez pas tenu de m'aider, vu les circonstances.";
        map["I still have a responsibility to the estate, and Don was gambling estate funds."] = "J'ai toujours une responsabilité envers le domaine, et Don jouait l'argent de la succession.";
        map["Quite right, quite right."] = "Tout à fait exact, vous avez raison.";
        map["One last thing, I believe the doctor was looking to speak with you."] = "Une dernière chose : je crois que le docteur cherchait à vous parler.";
        map["They were?"] = "Vraiment ?";
        map["Indeed. I believe he's just about managed to pull himself together."] = "En effet. Il a enfin réussi à reprendre un peu ses esprits.";
        map["You'll find him in Lady Unterwald's quarters, no doubt combing over her personal effects."] = "Vous le trouverez dans les quartiers de Lady Unterwald, sans doute en train d'éplucher ses effets personnels.";
        map["Alright, I'll check up on him."] = "D'accord, je vais aller voir comment il va.";
        map["I'll be in the lounge if you need me."] = "Je serai au salon si vous avez besoin de moi.";

        // --- Diana whispering ---
        map["Psst! We need to talk."] = "Psst ! Il faut qu'on parle.";
        map["Psst, over here!"] = "Psst, par ici !";
        map["Psst, get over here!"] = "Psst, viens par là !";
        map["Hey! Come this way."] = "Hé ! Viens par là.";

        // --- Dining props ---
        map["There's a satisfying undulation to the water's motion."] = "Les ondulations de l'eau ont un mouvement curieusement apaisant.";
        map["Are these lemons free?"] = "Ces citrons sont gratuits ?";
        map["Do you actually want the lemons?"] = "Vous voulez vraiment ces citrons ?";
        map["Hm, I might do."] = "Hmm, c'est bien possible.";
        map["They're filled with nondescript types of brown liquid."] = "Elles sont remplies d'un liquide brunâtre non identifié.";
        map["I'm not sure who'd drink these willingly."] = "Je me demande bien qui boirait ça de son plein gré.";
        map["They're an acquired taste."] = "C'est une saveur qui s'apprivoise.";
        map["Ladder hemstitch, mitered corners, 100% white linen."] = "Jour échelle, coins en onglet, 100 % pur lin blanc.";
        map["These are some high-end cocktail napkins!"] = "Voilà des serviettes de cocktail de grand standing !";
        map["You should expect nothing less on the Reuss Express."] = "On n'en attend pas moins à bord du Reuss Express.";
        map["''Please wait to be seated.''"] = "« Veuillez attendre qu'on vous place. »";
        map["Hm."] = "Hmm.";
        map["I guess it's more of a suggestion."] = "J'imagine que c'est une simple suggestion.";

        // --- Kitchen Carriage & The 3 Chefs ---
        map["Oh, my beauty, what have they done to you?"] = "Oh, ma merveille, que t'ont-ils fait ?";
        map["Oui ?"] = "Oui ?";
        map["Hello again, attorney."] = "Rebonjour, l'avocat.";
        map["Don't sneak up on me like that!"] = "Ne me surprenez pas comme ça !";
        map["Ahh! You gave me a fright!"] = "Ahh ! Vous m'avez fait une de ces peurs !";
        map["How can I help?"] = "En quoi puis-je vous aider ?";
        map["Quoi! What are you doing in here?"] = "Quoi ! Qu'est-ce que vous fabriquez ici ?";
        map["Not another health inspector, we hope?"] = "Pas encore un inspecteur d'hygiène, grand Dieu ?";
        map["I'm not sure I can handle another inspection!"] = "Je ne survivrai pas à un autre contrôle !";
        map["No, I'm an attorney."] = "Non, je suis avocat.";
        map["Zut! That's even worse!"] = "Zut ! C'est encore pire !";
        map["So much worse!"] = "Tellement pire !";
        map["What happened here?"] = "Qu'est-ce qui s'est passé ici ?";
        map["Can't you see the kitchen is off limits right now?"] = "Vous ne voyez pas que l'accès aux cuisines est strictement interdit ?";
        map["Come back when we've cleaned up!"] = "Revenez quand on aura fini de nettoyer !";
        map["You again?"] = "Encore vous ?";
        map["Zut! The attorney has returned."] = "Zut ! L'avocat est de retour.";
        map["Try this soup, it's a fresh batch."] = "Goûtez cette soupe, elle sort tout juste de la marmite.";
        map["This is a kitchen, not a cabaret!"] = "Ici c'est une cuisine, pas un cabaret !";
        map["We've only just tidied up!"] = "On vient à peine de ranger !";
        map["You call this helping?"] = "Vous appelez ça donner un coup de main ?";
        map["Take your business elsewhere!"] = "Allez voir ailleurs si nous y sommes !";
        map["Is there a reason you keep wandering in here, attorney?"] = "Y a-t-il une raison à vos allées et venues incessantes, l'avocat ?";
        map["Uh, well, no, not really."] = "Euh, non, pas vraiment.";
        map["You again? Just who are you anyway?"] = "Encore vous ? Mais qui êtes-vous à la fin ?";
        map["Just what is it you want, attorney?"] = "Que voulez-vous donc, l'avocat ?";
        map["Do you think I could heat up this napkin?"] = "Pensez-vous que je pourrais faire chauffer cette serviette ?";
        map["Quoi ? You want to cook a napkin?"] = "Quoi ? Vous voulez faire cuire une serviette ?";
        map["I think there's a hidden message in here!"] = "Je crois qu'elle renferme un message secret !";
        map["He's gone mad!"] = "Il a perdu la tête !";
        map["Not now, attorney! We're in no mood to entertain your wild ideas!"] = "Pas maintenant, l'avocat ! Nous ne sommes pas d'humeur à écouter vos délires !";
        map["Are you sure everything is okay?"] = "Vous êtes sûrs que tout va bien ?";
        map["We have everything under control!"] = "La situation est sous contrôle !";
        map["Alright, attorney. We may have a little rodent problem."] = "Très bien, l'avocat. Nous avons peut-être un minuscule problème de rongeur.";
        map["I've never seen a thief like it!"] = "Je n'ai jamais vu un voleur pareil !";
        map["This is no ordinary rodent. This foul creature must have received formal training!"] = "Ce n'est pas un rongeur ordinaire. Cette immonde créature a forcément suivi un entraînement militaire !";
        map["Your mouse is a master thief?"] = "Votre souris est un monte-en-l'air professionnel ?";
        map["Oui, pretty much anything it gets its grubby paws on!"] = "Oui ! Elle dérobe tout ce qui lui passe sous ses sales petites pattes !";
        map["Admit it, François. We can't go on like this, we need professional help!"] = "Admets-le, François. Nous ne pouvons plus continuer ainsi, il nous faut un professionnel !";
        map["I can't work under these conditions!"] = "Je refuse de cuisiner dans de telles conditions !";
        map["Yes, I suppose you are right."] = "Oui, tu as sans doute raison.";
        map["Attorney, I propose a trade."] = "L'avocat, je vous propose un marché.";
        map["I'm listening."] = "Je vous écoute.";
        map["You catch that creature for us, and we'll let you cook your little napkin."] = "Attrapez cette bestiole, et nous vous laisserons cuire votre précieuse serviette.";
        map["Him?!"] = "Lui ?!";
        map["What would you have me do, Antoine?"] = "Et que veux-tu que je fasse d'autre, Antoine ?";
        map["First that dreadful inspection, and now a rodent running amok in our kitchen?"] = "D'abord ce maudit contrôle sanitaire, et maintenant un rongeur qui sème la zizanie aux fourneaux ?";
        map["If word of this gets out, we'll be fired by sunrise."] = "Si cela s'ébruite, nous serons renvoyés avant le lever du soleil.";
        map["Then what will you and your precious grill do then? Hm?"] = "Et que deviendrez-vous, toi et ton précieux gril, hein ?";
        map["What do you say, attorney?"] = "Qu'en dites-vous, l'avocat ?";
        map["I'm sure I could figure something out, how hard could it be?"] = "Je devrais pouvoir m'en sortir. Ça ne doit pas être si sorcier, si ?";
        map["It won't be so simple. That little thief is a professional."] = "Ce ne sera pas si simple. Ce petit chapardeur est un as du cambriolage.";
        map["We've heard it scratching in the pantry, I'd start your hunt there."] = "Nous l'avons entendue gratter dans le garde-manger. C'est là que je commencerais ma battue.";
        map["I won't let you down!"] = "Vous pouvez compter sur moi !";
        map["You probably need to throw these away."] = "Vous devriez probablement jeter ça.";
        map["Don't look in there."] = "Ne regardez pas là-dedans.";
        map["Something smells good! Mind if I have a taste?"] = "Ça sent divinement bon ! Je peux goûter ?";
        map["Don't do it!"] = "N'y touchez pas !";
        map["Get away from there!"] = "Éloignez-vous de là !";
        map["Okay, okay!"] = "D'accord, d'accord !";
        map["Hmm, I'd better not."] = "Hmm, je ferais mieux de m'abstenir.";
        map["They have everything a good kitchen needs."] = "Il y a tout ce dont une grande cuisine a besoin.";

        // Write output TSV
        int count = 0;
        using (var sw = new StreamWriter(@"translations\partitions\c1_b2_french.tsv", false, Encoding.UTF8)) {
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
        Console.WriteLine(string.Format("Generated c1_b2_french.tsv: {0} lines translated out of {1}", count, lines.Length));
    }
}
