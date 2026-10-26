using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class BuildC1B3 {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\partitions\c1_b3_casino_don.tsv");
        var map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        // --- Cashier ---
        map["Good evening, hun."] = "Bonsoir, mon chou.";
        map["Do you have any winnings?"] = "Vous avez des gains à encaisser ?";
        map["Oh, no I'm not the gambling type."] = "Oh non, je ne suis pas trop du genre joueur.";
        map["Well, bring any chips to me and I'll convert them into cash for you!"] = "Eh bien, apportez-moi vos jetons et je vous les changerai en billets tout neufs !";
        map["As a matter of fact, I do."] = "Justement, il se trouve que oui.";
        map["Great! How much do you want to exchange?"] = "Merveilleux ! Combien voulez-vous échanger ?";
        map["Congratulations again on your big win."] = "Toutes mes félicitations encore pour ce magnifique coup de chance !";
        map["Thanks!"] = "Merci !";
        map["Ejected?"] = "Éjectés ?";
        map["Oh yes, hun. Usually they go straight out the window."] = "Oh oui, mon chou. En général, ils passent directement par la fenêtre.";

        // --- Casino Enforcers ---
        map["Are you ignoring me?"] = "Vous m'ignorez ?";
        map["Hey."] = "Hé.";
        map["Buzz off, kid."] = "Du vent, petit.";
        map["I won't ask nicely again."] = "Je ne le redirai pas gentiment.";
        map["I'd better not anger him further."] = "Je ferais mieux de ne pas l'énerver davantage.";
        map["What did you do with Donny Donato?"] = "Qu'avez-vous fait de Donny Donato ?";
        map["The casino cheat? He's been handled."] = "Le tricheur du casino ? Son cas a été réglé.";
        map["Handled? That sounds ominous."] = "Son cas a été réglé ? C'est plutôt inquiétant dit comme ça.";
        map["What did you really do with Donny? Is he safe?"] = "Qu'avez-vous vraiment fait de Donny ? Est-il sain et sauf ?";
        map["You ask too many questions."] = "Tu poses trop de questions.";
        map["Keep talking like that, maybe you'll find out first-hand."] = "Continue comme ça et tu le découvriras à tes dépens.";
        map["I'd better not."] = "Je ferais mieux d'éviter.";
        map["Hi there."] = "Salut.";
        map["Do you not want to talk to me?"] = "Vous ne voulez pas me parler ?";
        map["Hello again, friend."] = "Rebonjour, l'ami.";
        map["Don't push your luck, pal."] = "Tente pas trop ta chance, l'ami.";
        map["Now I'm starting to get mad."] = "Là, je commence sérieusement à m'énerver.";
        map["Probably best to leave him alone."] = "Le plus sage est de le laisser tranquille.";
        map["Where are you holding Donny Donato?"] = "Où retenez-vous Donny Donato ?";
        map["He won't be a problem for the casino going forward."] = "Il ne posera plus aucun problème au casino à l'avenir.";
        map["Is Donny still aboard the train, at least?"] = "Est-ce qu'au moins Donny est toujours à bord du train ?";
        map["Were you a close associate of this casino cheat?"] = "Tu étais un complice de ce tricheur de bas étage ?";
        map["Are you going to be a problem that needs solving?"] = "Tu vas devenir un problème qu'on doit régler aussi ?";
        map["No, that won't be necessary!"] = "Non non, ce ne sera pas nécessaire !";
        map["I really shouldn't bother them again."] = "Je devrais vraiment arrêter de leur chercher des poux.";
        map["Greetings, Mr Donato."] = "Bien le bonjour, M. Donato.";
        map["Might we ask to have a friendly chat."] = "Pouvons-nous vous demander une petite causerie entre amis ?";
        map["About your most recent gambling activities?"] = "Au sujet de vos récents exploits à la roulette ?";
        map["S-Sure thing."] = "B-Bien sûr, voyons.";
        map["A most unscrupulous individual is gambling with counterfeit chips."] = "Un individu particulièrement indélicat joue avec des jetons contrefaits.";
        map["F-Fake chips?"] = "D-Des faux jetons ?";
        map["We suspect this individual has also taken a creative approach to magnetism."] = "Nous soupçonnons cet individu d'avoir aussi une approche très créative du magnétisme.";
        map["An unsanctioned use of physical phenomena."] = "Une utilisation non autorisée des lois de la physique.";
        map["M-Magnetism?"] = "Du m-magnétisme ?";
        map["The capacity to attract and repulse forces between objects."] = "La capacité d'attirer et de repousser des corps matériels.";
        map["I wouldn't know anything about that."] = "Je n'y connais absolument rien, moi !";
        map["Then allow my associate to demonstrate..."] = "Alors permettez à mon confrère de vous faire une démonstration...";
        map["Hey, who switched off the lights!"] = "Hé, qui a éteint la lumière ?!";

        // --- Don at the Roulette Table & Beating ---
        map["Beat it kid, can't you see I'm on a winning streak?"] = "Du balai petit, tu vois pas que je suis dans une veine d'enfer ?";
        map["Hey, while you're here, you could do me a little favour."] = "Hé, pendant que t'es là, tu pourrais me rendre un petit service.";
        map["You take this note and give it to that dame behind me, will ya?"] = "Prends ce mot et refile-le à la dame derrière moi, d'accord ?";
        map["What is it?"] = "Qu'est-ce que c'est ?";
        map["It's a proposal of sorts, requesting we both make tracks to my suite."] = "C'est une proposition galante pour l'inviter à me rejoindre dans ma suite.";
        map["You get my drift?"] = "Tu vois le genre ?";
        map["I don't like the sound of that."] = "Ça ne me dit rien qui vaille.";
        map["Why is it so damp?"] = "Pourquoi est-il si humide ?";
        map["I soaked it in perfume. You don't know squat about wooing a dame, do ya?"] = "Je l'ai aspergé de parfum. Tu piges rien à l'art de séduire une dame, pas vrai ?";
        map["Gross."] = "Écœurant.";
        map["I wouldn't want him to know that I borrowed it."] = "Je ne voudrais pas qu'il sache que je lui ai emprunté.";
        map["But, maybe I can use this to foil his scheme."] = "Mais je peux peut-être m'en servir pour déjouer sa combine.";
        map["Well, I-"] = "Eh bien, je...";
        map["'Atta boy!"] = "C'est bien, mon petit !";
        map["You just watch and learn now."] = "Regarde bien et prends des notes.";
        map["So, dollface. How about it?"] = "Alors, ma jolie ? Qu'est-ce qu'on dit ?";
        map["I don't write love letters for every broad I see, you know. You should be grateful!"] = "J'écris pas des billets doux à toutes les pépées que je croise, tu sais. Tu devrais être flattée !";
        map["In that case, allow me to show you my gratitude."] = "Dans ce cas, permettez-moi de vous témoigner toute ma gratitude.";
        map["See you around, Arthur."] = "À plus tard, Arthur.";
        map["Ahh, unrequited love."] = "Ahh, l'amour non partagé...";
        map["I'm feeling lucky."] = "Je le sens bien cette fois.";
        map["You said that last time!"] = "C'est ce que tu as dit la dernière fois !";
        map["Trust me, I've got a system."] = "Fais-moi confiance, j'ai une martingale infaillible.";
        map["That's what they all say."] = "C'est ce qu'ils disent tous.";
        map["Who's the suit?"] = "C'est qui ce costard-cravate ?";
        map["You better not be bad luck, mister."] = "Vous avez intérêt à pas nous porter la poisse, monsieur.";
        map["Let's try this one more time."] = "Essayons encore une fois.";
        map["You know, you're starting to feel like bad luck, kid!"] = "Tu sais que tu commences à me porter la guigne, toi ?";
        map["Step away from the table, pronto."] = "Éloigne-toi de la table, et fissa !";
        map["I ain't messing around no more."] = "Finie la rigolade.";
        map["All on red."] = "Tout sur le rouge.";
        map["All on black."] = "Tout sur le noir.";
        map["Bad luck old chap."] = "Pas de chance, mon cher.";
        map["Never mind, at least you tried!"] = "Ne t'en fais pas, au moins tu as essayé !";
        map["Oh dear!"] = "Oh la la !";
        map["That's not possible!"] = "C'est pas possible !";
        map["Uh, excuse me."] = "Euh, pardonnez-moi.";
        map["Eegh!"] = "Aïe !";
        map["Oooh!"] = "Ooh !";
        map["Oww!"] = "Aouch !";
        map["Arghh!"] = "Arghh !";
        map["Alright, sto-"] = "Ça va, arrê-";
        map["Oooh! Ahhh!"] = "Oooh ! Ahhh !";
        map["Ooh! Not the face!!"] = "Ooh ! Pas sur le visage !!";
        map["Ouch."] = "Aïe.";
        map["I guess the house always wins."] = "Le casino est toujours gagnant, à ce qu'on dit.";

        // --- Gossip in Casino ---
        map["I'm afraid the Reuss Express has been slipping in standards for some time now."] = "Le standing du Reuss Express laisse franchement à désirer depuis quelque temps.";
        map["But to have vermin aboard the train, have things really got so bad?"] = "Mais avoir de la vermine à bord... en est-on réellement arrivés là ?";
        map["I'm telling you, it was as big as a house cat!"] = "Je vous jure qu'elle était aussi grosse qu'un chat d'appartement !";
        map["How revolting!"] = "Quelle horreur !";
        map["I heard the Lady took a tumble on stage during her big speech."] = "J'ai entendu dire que la Lady a fait une lourde chute sur scène pendant son discours.";
        map["Oh my, I hope she's not too badly hurt!"] = "Bonté divine, j'espère qu'elle ne s'est pas fait trop mal !";
        map["Hard to tell, they're keeping it all hush-hush."] = "Difficile à dire, ils étouffent complètement l'affaire.";
        map["I heard Lady Unterwald's bumbling attorney lost her will and testament!"] = "Il paraît que son incapable d'avocat a égaré son testament !";
        map["Really? How awful!"] = "Vraiment ? Quel désastre !";
        map["It was quite a sight to behold, apparently."] = "Un spectacle d'anthologie, à ce qu'on m'a raconté.";
        map["He was chasing down the carriage after it!"] = "Il courait comme un dératé dans tout le wagon pour le rattraper !";

        // --- Signs & Observations ---
        map["I imagine it's a fun way to lose all your savings."] = "Une façon ludique de dilapider toutes ses économies, j'imagine.";
        map["You're half right, I'm not having much fun."] = "Vous n'avez qu'à moitié raison : je ne m'amuse pas du tout.";
        map["I'm not sure I know the rules."] = "Je ne suis pas certain de maîtriser les règles.";
        map["Besides, it makes me dizzy."] = "Et puis, ça me donne le tournis.";
        map["I wouldn't want to be the poor sap who has to dust a moving chandelier."] = "Je ne voudrais pas être le pauvre bougre chargé de dépoussiérer un lustre en plein roulis.";
        map["''CHEATING STRICTLY PROHIBITED.''"] = "« TRICHE STRICTEMENT INTERDITE. »";
        map["''THERE IS TO BE NO: CARD-COUNTING, MONEY LAUNDERING, CHEATING THE SYSTEM, WINNING TOO FREQUENTLY, EXPLOITATION OF EVERYDAY ITEMS AND/OR NATURAL PHENOMENA.''"] = "« SONT STRICTEMENT PROSCRITS : LE COMPTAGE DE CARTES, LE BLANCHIMENT D'ARGENT, LE DÉTOURNEMENT DU RÈGLEMENT, LES GAINS TROP FRÉQUENTS ET L'USAGE DE PHÉNOMÈNES PHYSIQUES. »";
        map["''RULE BREAKERS WILL FIND THEMSELVES IMMEDIATELY EJECTED FROM THE PREMISES.''"] = "« TOUT CONTREVENANT SERA IMMÉDIATEMENT RECONDUIT HORS DE L'ÉTABLISSEMENT. »";

        // --- Don Quarters & Bergmann Blackmail ---
        map["That should be all of them."] = "Ça devrait suffire.";
        map["I better find somewhere to hide, and fast!"] = "Je ferais mieux de trouver une cachette, et vite !";
        map["This damn watch must be on the fritz."] = "Cette satanée montre doit être détraquée.";
        map["At this rate I'm gonna run out of chips!"] = "À ce train-là, je vais être à sec de jetons !";
        map["Wait a second..."] = "Attends une seconde...";
        map["No, I've been robbed!"] = "Non ! On m'a dévalisé !";
        map["So this is what it feels like..."] = "Alors c'est ça que ça fait...";
        map["Okay, Don."] = "Très bien, Don.";
        map["The jig is up."] = "La fête est finie.";
        map["I owe a lot of money."] = "Je dois une somme folle.";
        map["No need to panic."] = "Pas de panique.";
        map["I can jump off at the next bend."] = "Je peux sauter en marche au prochain virage.";
        map["Yeah, maybe cross at the border."] = "Ouais, et passer la frontière en loucedé.";
        map["Between the two of us, I'm not the bad guy, y'hear?"] = "Entre nous deux, c'est pas moi le pourri, tu m'entends ?";
        map["Ah, so it's all my fault."] = "Ah, évidemment, c'est de ma faute.";
        map["I suppose in your mind I bankrupted the company? I killed Lady Unterwald?"] = "Dans votre tête, c'est moi qui ai coulé l'entreprise ? C'est moi qui ai tué Lady Unterwald ?";
        map["Don't be so absurd. We're done here."] = "Ne soyez pas ridicule. Nous en avons terminé.";
        map["You're not done until I say so."] = "On n'a pas fini tant que JE ne l'ai pas dit.";
        map["I have a feeling the authorities would find THIS very compelling."] = "J'ai comme l'impression que la police va trouver ÇA très instructif.";
        map["...I killed Lady Unterwald."] = "...J'ai tué Lady Unterwald.";
        map["You've been RECORDING?!"] = "Vous nous avez ENREGISTRÉS ?!";
        map["When you're in my line of work you need a little insurance, y'know? Consider it an incentive to stay in line."] = "Dans mon métier, on a besoin d'une petite assurance-vie, tu vois ? Prends ça comme un encouragement à filer droit.";
        map["Besides, I've got a new scheme in play. I'm telling ya, Bergmann. I won't lose this time!"] = "Et puis, j'ai un nouveau coup en préparation. Je te le dis, Bergmann : je ne peux pas perdre cette fois !";
        map["You better be right."] = "Vous avez intérêt à ne pas vous planter.";
        map["It sounds like Bergmann has fallen in with the wrong crowd."] = "On dirait que Bergmann s'est fourvoyé en mauvaise compagnie.";
        map["I should get my hands on that ledger in Lady Unterwald's quarters."] = "Je devrais mettre la main sur ce registre dans les quartiers de Lady Unterwald.";
        map["I'd better get out the way again."] = "Je ferais bien de me planquer à nouveau.";
        map["Damn thievin' casino."] = "Sale casino de voleurs.";
        map["I'm supposed to be stealin' from them!"] = "C'est MOI qui suis censé les plumer !";
        map["Eh, no matter."] = "Bof, peu importe.";
        map["Still got plenty of chips left."] = "Il me reste un paquet de jetons.";
        map["Should be enough to get my winnings back."] = "Ça devrait suffire pour me refaire.";
        map["And then some!"] = "Et même plus encore !";
        map["There's nothing in there I need."] = "Il n'y a rien là-dedans dont j'aie besoin.";
        map["That's a seriously powerful magnet."] = "C'est un aimant redoutablement puissant.";
        map["Ugh."] = "Pouah.";
        map["A bit garish for my taste, but this is the honeymoon suite."] = "Un peu tapageur à mon goût, mais c'est la suite nuptiale après tout.";
        map["I guess Don's been winning big at the casino."] = "On dirait que Don a amassé un joli pactole au casino.";
        map["I'll bet these look convincing with a lick of paint."] = "Je parie qu'avec un coup de peinture, ils font illusion à la perfection.";
        map["I have no clue what these are for, but I bet Don's up to something shady."] = "Aucune idée de leur usage, mais je parie que Don prépare un coup tordu.";
        map["Don must be using these fraudulent chips to cheat in the casino."] = "Don doit se servir de ces faux jetons pour tricher au casino.";
        map["Don was gambling with fraudulent chips, what a slimeball!"] = "Don jouait avec des jetons contrefaits, quelle crapule !";
        map["There are piles of wooden casino chips in these boxes."] = "Ces boîtes débordent de piles de jetons de casino en bois.";
        map["Seems like Don is stirring up trouble for the casino."] = "On dirait bien que Don cherche des ennuis au casino.";
        map["Bergmann said Don was scamming the casino using magnetism and fake chips."] = "Bergmann a dit que Don arnaquait le casino avec du magnétisme et des faux jetons.";
        map["These are all that's left of Don's gambling scheme."] = "C'est tout ce qu'il reste de la combine de jeu de Don.";
        map["If I seal up these burrows, I'd have a better chance of catching the mouse."] = "Si je bouche ces terriers, j'aurai plus de chances d'attraper la souris.";
        map["A tiny entrance for an unwanted guest."] = "Une minuscule entrée pour une intruse indésirable.";
        map["They've settled into quite a hypnotic pattern."] = "Leurs mouvements dessinent un motif hypnotique.";
        map["You following me, kid?"] = "Tu me suis, petit ?";
        map["Take a hike!"] = "Fiche le camp !";
        map["Where did he get all of those casino chips from?"] = "Où a-t-il bien pu dégoter tous ces jetons de casino ?";
        map["He's always a step ahead."] = "Il a toujours une longueur d'avance.";
        map["I shouldn't open the door while he's in there."] = "Je ne devrais pas ouvrir tant qu'il est à l'intérieur.";
        map["Don? Are you in there?"] = "Don ? Vous êtes là ?";
        map["I could let myself in and leave the keys inside."] = "Je pourrais entrer et déposer les clés à l'intérieur.";
        map["It's room 303."] = "C'est la cabine 303.";

        // --- Additional lines ---
        map["Psst."] = "Psst.";
        map["Over here."] = "Par ici.";
        map["Right this way, sir."] = "Par ici, monsieur.";
        map["Uh, hello?"] = "Euh, bonjour ?";
        map["Oh boy."] = "Oh la la.";
        map["It's ol' clammy hands again."] = "Voilà encore ces vieilles mains moites.";
        map["Sleeper Carriage."] = "Voiture-lits.";
        map["Kitchen Carriage."] = "Voiture-cuisine.";
        map["Kitchen Pantry."] = "Garde-manger.";
        map["Service Carriages."] = "Voitures de service.";
        map["Unterwald Carriages."] = "Voitures Unterwald.";

        // Write output TSV
        int count = 0;
        using (var sw = new StreamWriter(@"translations\partitions\c1_b3_french.tsv", false, Encoding.UTF8)) {
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
        Console.WriteLine(string.Format("Generated c1_b3_french.tsv: {0} lines translated out of {1}", count, lines.Length));
    }
}
