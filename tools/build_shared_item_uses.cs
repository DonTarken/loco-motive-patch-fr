using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class BuildSharedItemUses {
    static void Main() {
        var map = new Dictionary<string, string>();

        // CharacterApril
        map["Hey, there's a bunch of gadgets in here!"] = "Hé, il y a un tas de gadgets là-dedans !";
        map["Where'd you get these?"] = "Où as-tu dégoté tout ça ?";
        map["Don't get too excited, they're prototypes I found in the yard!"] = "Ne t'emballe pas trop vite, ce sont des prototypes récupérés dans la cour !";
        map["I swiped them for you, but they're probably half broken!"] = "Je les ai chipés pour toi, mais ils sont sans doute à moitié fichus !";
        map["What's this for?"] = "À quoi ça sert ?";
        map["I swiped that spray from the yard, although it's probably not potent enough!"] = "J'ai fauché ce spray dans la cour, mais il n'est sans doute pas assez concentré !";
        map["Either way, it's not going to get us closer to that train!"] = "De toute façon, ce n'est pas ça qui va nous rapprocher du train !";
        map["Is this a set of incendiary pencils?"] = "Serait-ce un assortiment de crayons incendiaires ?";
        map["Yes, so you should be careful!"] = "Oui, alors fais bien attention !";
        map["Just remember that you're literally handling explosives!"] = "Rappelle-toi que tu manipules littéralement des explosifs !";
        map["Would this explosive pencil give us a boost?"] = "Ce crayon explosif pourrait-il nous donner un coup d'accélérateur ?";
        map["They're full of explosive powder! It could potentially work!"] = "Ils sont bourrés de poudre explosive ! Ça pourrait théoriquement marcher !";
        map["I've got the explosive powder!"] = "J'ai récupéré la poudre explosive !";
        map["Nice work, but you'll need to get it into the bike!"] = "Beau boulot, mais il va falloir l'injecter dans la moto !";

        // CharacterArista
        map["She probably couldn't even read it."] = "Elle ne pourrait probablement même pas le lire.";
        map["Oi!"] = "Hé ho !";
        map["I might be deaf..."] = "Je suis peut-être sourde...";
        map["but I'm certainly not blind."] = "mais je ne suis certainement pas aveugle.";
        map["Well, not with the glasses anyway..."] = "Enfin, pas avec mes bésicles en tout cas...";
        map["I think I should keep it."] = "Je pense que je ferais mieux de le garder.";
        map["She probably won't want it back now that I've sealed it."] = "Elle ne voudra sans doute plus le récupérer maintenant que je l'ai rebouché.";
        map["Am I supposed to be impressed?"] = "Je suis censée être impressionnée ?";
        map["Here! I've had your hearing horn repaired."] = "Tenez ! J'ai fait réparer votre cornet acoustique.";
        map["Bravo! Come, we must act quickly!"] = "Bravo ! Venez, nous devons agir sans tarder !";
        map["My boys must be so scared, and it's almost their nap time!"] = "Mes garçons doivent être terrorisés, et c'est bientôt l'heure de leur sieste !";
        map["They get cranky if they don't have their nap!"] = "Ils sont d'une humeur massacrante quand ils ratent leur sieste !";

        // CharacterBartender
        map["Would you like this?"] = "Est-ce que ceci vous intéresserait ?";
        map["No, sir. I assure you, my breath is fresh enough already."] = "Non, monsieur. Je vous assure que mon haleine est déjà bien assez fraîche.";
        map["I found these loose petals."] = "J'ai trouvé ces pétales éparpillés.";
        map["Think you could use them to make a Rosebud?"] = "Pensez-vous pouvoir les utiliser pour concocter un Rosebud ?";
        map["Sure, that should be close enough to the real deal."] = "Bien sûr, ça fera parfaitement illusion.";
        map["I'm still missing that cocktail perfume, though."] = "Il me manque toujours le parfum à cocktail, cela dit.";
        map["Would you like these?"] = "Voulez-vous ceux-ci ?";
        map["You can keep hold of those, sir."] = "Vous pouvez les garder, monsieur.";
        map["This letter is positively dripping with perfume!"] = "Cette lettre dégouline littéralement de parfum !";
        map["Think you could use this to make a Rosebud?"] = "Pensez-vous pouvoir utiliser cela pour préparer un Rosebud ?";
        map["Ehh, sure. We can give it a shot!"] = "Euh, bien sûr. On peut toujours tenter le coup !";
        map["I'm still missing the rose petals, though."] = "Il me manque encore les pétales de rose, néanmoins.";
        map["You can keep it."] = "Vous pouvez la garder.";
        map["Just so you know, that doesn't count as ID."] = "Pour votre gouverne, cela ne fait pas office de pièce d'identité.";
        map["Do you take special requests?"] = "Prenez-vous les commandes spéciales ?";
        map["Interesting, I've never heard of this one before. Let's give it a shot."] = "Intéressant, je n'avais encore jamais entendu parler de celui-là. Essayons.";
        map["One Rosebud, coming up!"] = "Un Rosebud, un !";
        map["I believe my guest is ready for his drink now."] = "Je crois que mon invité est fin prêt pour son breuvage.";
        map["Which table, sir?"] = "Quelle table, monsieur ?";
        map["The large, angry gentleman over there. You can't miss him."] = "Le grand monsieur furibond là-bas. Vous ne pouvez pas le rater.";
        map["Ah, I'm familiar."] = "Ah, je vois très bien de qui il s'agit.";
        map["Good evening, sir. One of your fellow passengers has kindly ordered a drink for you."] = "Bonsoir, monsieur. L'un de vos compagnons de voyage a eu l'amabilité de vous commander un verre.";
        map["No, thank you. I won't have anything until I've ordered my meal."] = "Non merci. Je n'avalerai rien tant que je n'aurai pas commandé mon repas.";
        map["Very good, sir. I'll leave it at the bar for you."] = "Parfaitement, monsieur. Je le laisse au bar à votre disposition.";
        map["Yes, yes. Just leave me be."] = "Oui, oui. Laissez-moi tranquille.";
        map["Fine, if I can't have a meal, I might as well have a drink."] = "Soit, si je ne peux pas dîner, autant boire un coup.";
        map["Enjoy, Sir."] = "Santé, monsieur.";
        map["Well, here's to a new libation."] = "Eh bien, trinquons à cette nouvelle potion.";
        map["Rose..."] = "Rose...";
        map["bud."] = "bud.";

        // CharacterBergmann
        map["Concerning this ledger..."] = "À propos de ce registre de comptes...";
        map["Arthur, I admit I made a mistake by manipulating those financial records."] = "Arthur, je reconnais avoir commis une erreur en falsifiant ces bilans financiers.";
        map["I only did it under pressure from Donny Donato!"] = "Je n'ai agi ainsi que sous la contrainte exercée par Donny Donato !";
        map["I believe he's using magnetism to alter the outcome of the roulette table."] = "Je suis persuadé qu'il utilise le magnétisme pour fausser le résultat de la roulette.";
        map["I'll make this right as soon as he's no longer a threat, I assure you!"] = "Je rectifierai tout cela dès qu'il aura cessé de nuire, croyez-moi !";
        map["What do you make of this, Bergmann? I found it in Don's quarters."] = "Que pensez-vous de cela, Bergmann ? Je l'ai trouvé dans la cabine de Don.";
        map["It's as I feared, Don is using magnetism to cheat at roulette."] = "C'est bien ce que je redoutais, Don use du magnétisme pour tricher à la roulette.";
        map["Perhaps you can use that magnet to foil Don's scheme in some way?"] = "Peut-être pourriez-vous employer cet aimant pour déjouer le plan de Don d'une manière ou d'une autre ?";
        map["Sorry, lad."] = "Désolé, jeune homme.";
        map["Not a clue what you just said."] = "Pas la moindre idée de ce que tu viens de baragouiner.";
        map["Salacious!"] = "Croustillant !";
        map["Positively titillating!"] = "Absolument émoustillant !";
        map["Smells a bit weird though..."] = "L'odeur est un peu singulière, cela dit...";

        // CharacterBrotherBrian & Jared
        map["Did you really just flash your badge at me?"] = "Tu viens sérieusement de brandir ton badge sous mon nez ?";
        map["Cool badge. Not as cool as this cloak, though."] = "Chouette badge. Mais pas aussi classe que cette toge.";
        map["What does your secret society make of this?"] = "Que pense votre société secrète de ceci ?";
        map["Well, it's definitely a napkin."] = "Eh bien, c'est indubitablement une serviette.";
        map["Does your book say anything about hidden messages on napkins?"] = "Votre grimoire mentionne-t-il les messages dissimulés sur les serviettes ?";
        map["I'm sure there's a chapter in here on hidden messages."] = "Je suis certain qu'il y a un chapitre là-dedans sur les messages codés.";
        map["I haven't got to that part yet."] = "Je ne suis pas encore arrivé à cette page.";
        map["Let's do a book swap! Would you like this book on poetry?"] = "Faisons un échange de bouquins ! Voudriez-vous ce recueil de poésie ?";
        map["I think I'll stick with mine, thanks."] = "Je préfère garder le mien, merci.";

        // CharacterByron & Cashier
        map["What are you supposed to be, some kind of copper?"] = "T'es censé être quoi au juste, une espèce de flic ?";
        map["No thanks."] = "Non merci.";
        map["Can I exchange some chips?"] = "Puis-je échanger quelques jetons ?";
        map["Of course! How many do you want to exchange?"] = "Bien sûr ! Combien souhaitez-vous en échanger ?";

        // Chefs (Francois, Antoine, Remy)
        map["Gentlemen, I have captured your thief."] = "Messieurs, j'ai capturé votre voleur.";
        map["Our nightmare is over."] = "Notre cauchemar a enfin pris fin.";
        map["La cuisine is now open for business, avocat."] = "La cuisine rouvre ses portes, monsieur l'avocat.";
        map["Feel free to look around."] = "Faites comme chez vous, regardez partout.";
        map["Take anything you need, mon ami."] = "Prenez tout ce dont vous avez besoin, mon ami.";
        map["How can you be scared of this cute little face?"] = "Comment peut-on avoir peur d'une bouille aussi mignonne ?";
        map["That's not funny, don't do that again!"] = "Ce n'est pas drôle du tout, ne refais plus jamais ça !";
        map["You know, I think you'd be friends if you just got to know each other!"] = "Vous savez, je suis sûr que vous seriez amis si vous preniez le temps de faire connaissance !";
        map["KEEP IT AWAY! IT'S EVERY MAN FOR HIMSELF!"] = "ÉLOIGNEZ CETTE HORREUR ! SAUVE QUI PEUT !";
        map["Stop that!"] = "Arrêtez ça !";
        map["This little mouse has a heart of gold!"] = "Cette petite souris a un cœur d'or !";
        map["NO! I'M TOO YOUNG TO DIE!"] = "NON ! JE SUIS TROP JEUNE POUR MOURIR !";
        map["Knock it off!"] = "Ça suffit maintenant !";

        // Conductor & Diana & Don
        map["You should keep this, sir."] = "Vous devriez conserver ceci, monsieur.";
        map["I think you dropped this?"] = "Je crois que vous avez fait tomber cela ?";
        map["He wouldn't like that."] = "Il n'apprécierait pas du tout.";
        map["Here, take it."] = "Tenez, prenez.";
        map["A response already? Someone is eager."] = "Déjà une réponse ? En voilà une qui ne perd pas de temps.";
        map["Wait a stinking minute, this is the same filthy note I gave you!"] = "Attends un peu, bon sang, c'est le même torchon que je t'ai donné tout à l'heure !";
        map["I'll tell him the bad news later."] = "Je lui annoncerai la mauvaise nouvelle plus tard.";
        map["Lady Unterwald is waiting for me!"] = "Lady Unterwald m'attend !";
        map["I better not, he'd be very upset."] = "Mieux vaut éviter, il le prendrait très mal.";
        map["Very convincing, but I'd recognise my own handiwork anywhere."] = "Très convaincant, mais je reconnaîtrais mon propre ouvrage entre mille.";
        map["Do you think you could forge the handwriting on this business card?"] = "Pensez-vous pouvoir imiter l'écriture sur cette carte de visite ?";
        map["Let me take a look-see. Step into my office!"] = "Fais voir un peu. Bienvenue dans mon bureau !";

        // ElusiveHand & Guard
        map["Take a look at this."] = "Jetez un œil à ceci.";
        map["It's not that kind of club, sir."] = "Ce n'est pas ce genre de club, monsieur.";
        map["I have a letter from the late Lady Unterwald, right here!"] = "J'ai ici même une lettre de feue Lady Unterwald !";
        map["Mm-hmm. This all looks to be in order."] = "Mm-hmm. Tout cela semble parfaitement en règle.";
        map["So I can go in?"] = "Je peux donc entrer ?";
        map["I'm afraid not, sir."] = "J'ai bien peur que non, monsieur.";
        map["Lady Unterwald has passed on, after all."] = "Lady Unterwald a passé l'arme à gauche, après tout.";
        map["Looks like you have a secret admirer!"] = "On dirait bien que vous avez une admiratrice secrète !";
        map["A secret admirer? Let me take a look at that."] = "Une admiratrice secrète ? Faites voir ça d'un peu plus près.";
        map["This is..."] = "C'est...";
        map["Explicit, I know."] = "Très suggestif, je sais.";
        map["And the scent!"] = "Et cette odeur !";
        map["It's so-"] = "C'est si...";
        map["Alluring!"] = "Envoûtant !";
        map["Wait, this note is perfumed?!"] = "Attendez, cette lettre est parfumée ?!";
        map["I believe so!"] = "Il semblerait bien, oui !";
        map["Are you alright?"] = "Tout va bien ?";
        map["Weren't you listening? I'm terribly allergic to fragrance!"] = "Vous n'écoutiez pas ? Je suis affreusement allergique aux parfums !";
        map["You've gone beet red."] = "Vous êtes devenu rouge comme une pivoine.";
        map["I'm terribly allergic to fragrance!"] = "Je suis affreusement allergique au parfum !";
        map["You've gone all red."] = "Vous êtes tout rouge.";
        map["I have? I need to find a doctor, right away!"] = "Vraiment ? Je dois trouver un médecin, immédiatement !";
        map["Don't go in there while I'm gone, Mr Ackerman!"] = "Ne vous avisez pas d'entrer pendant mon absence, monsieur Ackerman !";
        map["I wouldn't dream of it."] = "Je n'oserais même pas en rêve.";
        map["This note is a potential biohazard. I wouldn't want it to fall into the wrong hands."] = "Cette lettre est un véritable danger biologique. Je ne voudrais pas qu'elle tombe entre de mauvaises mains.";

        // Gunter & Hagen Briefcase
        map["Say..."] = "Dites...";
        map["Do either of you know anyone who could open this briefcase?"] = "Est-ce que l'un de vous connaîtrait quelqu'un capable de forcer cette mallette ?";
        map["I'll give it a shot!"] = "Je peux tenter le coup !";
        map["Let me try first."] = "Laisse-moi essayer d'abord.";
        map["No, I'm going first!"] = "Non, c'est moi qui commence !";
        map["He clearly asked me."] = "C'est à moi qu'il a demandé, c'était clair.";
        map["I'm the best person for the job."] = "Je suis le plus qualifié pour ça.";
        map["The second best person for the job."] = "Le deuxième plus qualifié, oui.";
        map["You won't be saying that when I open it."] = "Tu feras moins le malin quand je l'aurai ouverte.";
        map["Because I'd have already opened it!"] = "Parce que je l'aurai déjà ouverte avant toi !";
        map["It's mine!"] = "Elle est à moi !";
        map["Mine!"] = "À moi !";
        map["Mine!!"] = "À moi !!";
        map["Well now look what you did!"] = "Eh bien, regarde un peu ce que tu as fait !";
        map["It wasn't me!"] = "Ce n'est pas moi !";
        map["Was too!"] = "Si, c'est toi !";
        map["I think my work here is done."] = "Je crois que mon travail ici est terminé.";
        map["These medical records show Lady Unterwald's date of birth!"] = "Ce dossier médical indique la date de naissance de Lady Unterwald !";
        map["I'd have never guessed!"] = "Je ne l'aurais jamais deviné !";
        map["Would you like this love note?"] = "Voudriez-vous cette lettre d'amour ?";
        map["How flattering!"] = "Comme c'est flatteur !";
        map["No, he offered it to me!"] = "Non, c'est à moi qu'il l'a proposée !";
        map["Well that's ridiculous, I'm clearly the more handsome twin."] = "C'est ridicule, je suis visiblement le plus beau des deux jumeaux.";
        map["Well, I'm the tallest!"] = "Et moi, je suis le plus grand !";
        map["Barely!"] = "À peine !";
        map["If you're taller it's maybe by a single pixel!"] = "Si tu es plus grand, c'est tout au plus d'un malheureux pixel !";
        map["You know what, never mind..."] = "Vous savez quoi, laissez tomber...";
        map["Just hand over the keys? I don't think that would be a good idea."] = "Leur donner simplement les clés ? Je ne pense pas que ce soit une idée judicieuse.";

        // HandshakeLeader & Herman & Hirsch
        map["There's a time and a place for that, Herman. And it's not here."] = "Il y a un temps et un lieu pour cela, Herman. Et nous n'y sommes pas.";
        map["A fan letter? How grand!"] = "Une lettre d'admirateur ? Quel honneur !";
        map["Can't take it I'm afraid."] = "Je ne peux pas l'accepter, hélas.";
        map["That perfume is strong enough to bring me out in a rash."] = "Ce parfum est assez capiteux pour me donner de l'urticaire.";
        map["Here, I managed to capture the current handshake pattern."] = "Tenez, j'ai réussi à reproduire la séquence de la poignée de main.";
        map["You did?"] = "Vraiment ?";
        map["I just need some help with the phrases."] = "J'ai juste besoin d'un coup de main pour les répliques.";
        map["Aha, of course dear boy."] = "Aha, bien entendu, mon garçon.";
        map["And remember, you didn't hear it from me."] = "Et souvenez-vous, vous ne tenez pas ça de moi.";
        map["Thanks again!"] = "Merci encore !";
        map["Herman Merman waved his badge at me? I can die happy!"] = "Herman Merman a brandi son badge devant moi ? Je peux mourir en paix !";
        map["Let's take a little look, shall we?"] = "Jetons un coup d'œil, voulez-vous ?";
        map["Here, I'll write it down for you."] = "Tenez, je vous le mets par écrit.";
        map["Professionally?"] = "Sur le plan professionnel ?";
        map["I'd recommend wearing gloves when handling anything so potent."] = "Je vous conseille de porter des gants pour manipuler une substance aussi forte.";
        map["I believe that might be it! Hand it over to those seated at the table."] = "Je crois bien que c'est cela ! Remettez-la aux convives assis à table.";

        // JianLiu & Kid
        map["I should pick my moment."] = "Je devrais choisir le bon moment.";
        map["I've found the hand idol you were looking for."] = "J'ai trouvé l'idole de main que vous cherchiez.";
        map["You have? Then you must consult with the leader, they'll be able to verify it."] = "Vraiment ? Dans ce cas, présentez-la au dirigeant, il pourra l'authentifier.";
        map["Can I trade your Detective Kit for this Herman doll?"] = "Puis-je échanger ta panoplie de détective contre cette poupée Herman ?";
        map["What's a Herman doll?"] = "C'est quoi, une poupée Herman ?";
        map["Well, it's me! I have my own merchandise!"] = "Eh bien, c'est moi ! J'ai mes propres produits dérivés !";
        map["So why does it look like that?"] = "Et pourquoi elle a cette tête-là alors ?";
        map["Ah, it may have lost some stuffing, but it's still good!"] = "Ah, elle a peut-être perdu un peu de rembourrage, mais elle reste formidable !";
        map["Ehh. No, thanks."] = "Euh... Non merci.";
        map["Can I interest you in this?"] = "Est-ce que ceci pourrait t'intéresser ?";
        map["I don't get mail, what am I gonna do with a letter opener?"] = "Je ne reçois pas de courrier, qu'est-ce que tu veux que je fiche d'un coupe-papier ?";
        map["Office stationery? I don't work in an office, mister."] = "Des fournitures de bureau ? Je ne bosse pas dans un bureau, m'sieur.";
        map["Can I trade your Detective Kit for this Herman manuscript?"] = "Puis-je troquer ta panoplie de détective contre ce manuscrit d'Herman ?";
        map["Nobody's gonna want to read that guff, Mister."] = "Personne ne va vouloir lire ce baratin, m'sieur.";
        map["Now, if you got your hands on a Dirk Chiselton script, then maybe we could talk!"] = "Par contre, si tu mettais la main sur un texte de Dirk Chiselton, là on pourrait causer !";
        map["May I interest you with this unreleased Chiselton script cover?"] = "Puis-je éveiller ton intérêt avec cette couverture inédite d'un roman de Chiselton ?";
        map["Woah! Are you serious right now?"] = "Ouah ! Tu es sérieux là ?";
        map["I am indeed."] = "Tout à fait sérieux.";
        map["This is neat, but where's the rest?"] = "C'est chouette, mais où est le reste ?";
        map["It's all I was able to procure for the time being."] = "C'est tout ce que j'ai pu me procurer pour le moment.";
        map["That's a shame. If you had the complete script, I'd trade you in a heartbeat!"] = "C'est dommage. Si tu avais le manuscrit complet, j'échangerais sans hésiter !";
        map["Thanks anyway, though."] = "Merci quand même.";
        map["Would you like to read the next Detective Chiselton novel early?"] = "Aimerais-tu lire en avant-première le prochain roman de l'inspecteur Chiselton ?";
        map["Wait, are you serious? I gotta see it, show me!"] = "Attends, tu es sérieux ? Je dois voir ça, montre-moi !";
        map["No way, this hasn't even been announced!"] = "Pas possible, il n'a même pas encore été annoncé !";
        map["So, you're happy to trade?"] = "Alors, partant pour un échange ?";
        map["Oh, yeah! This is way better!"] = "Carrément ! C'est mille fois mieux !";
        map["That's the badge I gave you, dummy."] = "C'est le badge que je t'ai filé, ballot.";

        // LadyUnterwald & Masson
        map["Yes, yes. You're a big, strapping detective, Herman."] = "Oui, oui. Vous êtes un grand et vaillant détective, Herman.";
        map["Just what we need, another self-absorbed authority figure."] = "Exactement ce dont nous avions besoin, une autre figure d'autorité imbue d'elle-même.";
        map["Maybe this is strong enough to sober you up?"] = "Peut-être que ceci sera assez fort pour vous dégriser ?";
        map["Ha HA hA"] = "Ha HA hA";
        map["NNccIceeE *Hic* Trrry!"] = "Jjj-oli... *hips* eessssai !";
        map["I don't want to get him any more inebriated."] = "Je ne veux pas le rendre encore plus ivre qu'il ne l'est déjà.";
        map["This should get you talking again."] = "Ceci devrait vous délier la langue.";

        // Maurice & Pierre
        map["Most... exquisite, sir."] = "Tout à fait... exquis, monsieur.";
        map["Oh please! That doesn't prove anything."] = "Je vous en prie ! Cela ne prouve rien du tout.";
        map["You could've brought that rodent from home!"] = "Vous auriez très bien pu apporter ce rongeur de chez vous !";
        map["Excellent, sir."] = "Excellent, monsieur.";
        map["I assure you, I've done nothing wrong!"] = "Je vous assure que je n'ai rien fait de mal !";
        map["Are you interested in doing some work for hire?"] = "Seriez-vous intéressé par une commande artistique ?";
        map["Bravo, Monsieur."] = "Bravo, monsieur.";
        map["What is it that you wish to capture? The human condition?"] = "Que souhaitez-vous immortaliser ? La condition humaine ?";
        map["Ah, not exactly."] = "Ah, pas exactement.";
        map["Would this bag of cash be enough for a commission?"] = "Ce sac d'argent serait-il suffisant pour une commande ?";
        map["Monsieur, I shall draw you like one of my French bulldogs!"] = "Monsieur, je vous dessinerai comme l'un de mes bouledogues français !";
        map["I mean, I may be interested in taking on a small commission."] = "À la réflexion, je serais peut-être disposé à accepter une petite commande.";
        map["For the right price, of course."] = "Au juste prix, naturellement.";
        map["Would you accept these casino chips as payment?"] = "Accepteriez-vous ces jetons de casino en paiement ?";
        map["Afraid not, I need a cash payment."] = "Hélas non, il me faut un règlement en espèces.";
        map["Very... good."] = "Très... bien.";

        // Publishers & Ron & Sister Gretchen & Susanne
        map["Can I offer you a refreshing cup of water?"] = "Puis-je vous offrir un gobelet d'eau rafraîchissant ?";
        map["I've had quite enough, thanks."] = "J'en ai bien assez eu, merci.";
        map["I have a manuscript I'd like to pitch."] = "J'ai un manuscrit que j'aimerais vous présenter.";
        map["That's great, Herman. Just put it in the inbox and we'll take a look at it at some point."] = "C'est formidable, Herman. Déposez-le dans le bac de réception et nous y jetterons un œil un jour ou l'autre.";
        map["No, thank you, Herman."] = "Non merci, Herman.";
        map["That's quite alright, Hermie."] = "C'est bon, sans façon, Hermie.";
        map["Keep that thing away from me."] = "Gardez cette horreur loin de moi.";
        map["Mm-hmm. That sure is a badge."] = "Mm-hmm. C'est bel et bien un badge.";
        map["Ooh, maybe we should get badges?"] = "Ooh, on devrait peut-être se faire faire des badges ?";
        map["Nice badge, but that's not enough to get you in here."] = "Joli badge, mais ce n'est pas suffisant pour entrer ici.";
        map["I've been asked to give you this."] = "On m'a demandé de vous remettre ceci.";
        map["Is this from the twit that's been making eyes at me all evening?"] = "Est-ce de la part de l'ahuri qui me fait les yeux doux depuis le début de la soirée ?";
        map["I'd sooner jump out this carriage window than rendezvous with that rotten egg."] = "Je préférerais sauter par la fenêtre du train plutôt que de frayer avec cet olibrius.";
        map["It's scented, at least!"] = "C'est parfumé, au moins !";
        map["Well, it certainly stinks of desperation."] = "Eh bien, ça empeste surtout le désespoir.";
        map["Are you sure you can't accept that note?"] = "Êtes-vous absolument sûre de ne pas vouloir accepter ce mot ?";
        map["I told you I don't want anything from that rotten egg."] = "Je vous ai dit que je ne voulais rien de cet oiseau-là.";
        map["It stinks of desperation."] = "Ça empeste le désespoir.";
        map["I think that's just the perfume."] = "Je crois que c'est juste le parfum.";
        map["A blank napkin?"] = "Une serviette vierge ?";
        map["You can keep it."] = "Vous pouvez la garder.";
        map["That's real smooth, detective."] = "C'est du grand art, l'inspecteur.";

        // Casino Roulette & Toilet Interactions
        map["I lost?!"] = "J'ai perdu ?!";
        map["How?"] = "Comment ça ?";
        map["Wait right here, pal!"] = "Bouge pas de là, toi !";
        map["I should see where he goes."] = "Je devrais voir où il va.";
        map["I'm pretty sure these are fraudulent chips."] = "Je suis pratiquement certain que ce sont de faux jetons.";
        map["I think that's too big to send."] = "Je crois que c'est trop gros pour passer.";
        map["It's no use, I'll need to send a smaller item."] = "Inutile d'insister, je dois envoyer un objet plus petit.";
        map["That's not going to fit!"] = "Ça ne rentrera jamais !";
        map["I'll just place that here."] = "Je vais poser ça là.";
        map["This is probably waterproof."] = "C'est probablement étanche.";
        map["Here we go!"] = "C'est parti !";
        map["Here goes nothing!"] = "Qui ne tente rien n'a rien !";
        map["There's already something in there."] = "Il y a déjà quelque chose là-dedans.";
        map["There's something floating in there already."] = "Il y a déjà un objet qui flotte là-dedans.";
        map["I don't want to overcrowd the bowl."] = "Je ne veux pas engorger la cuvette.";
        map["I might cause a blockage if I flush two items."] = "Je risque de provoquer un bouchon si j'évacue deux objets en même temps.";
        map["That's not going to fit."] = "Ça ne passera pas.";
        map["I'll never fit that in there!"] = "Je n'arriverai jamais à faire rentrer ça là-dedans !";
        map["That's too big to send."] = "C'est bien trop volumineux pour l'expédier.";
        map["I could flush these chains, but they'd make an awfully loud racket."] = "Je pourrais évacuer ces chaînes, mais elles feraient un vacarme assourdissant.";
        map["It'll be too loud. That intern would come running over to investigate."] = "Ce sera trop bruyant. Ce stagiaire accourrait immédiatement voir ce qui se passe.";
        map["I'll just put this in here."] = "Je vais simplement mettre ça là-dedans.";
        map["It's not elegant, but it works."] = "Ce n'est pas très élégant, mais c'est efficace.";
        map["I didn't think I'd be doing this on my first mission."] = "Je ne pensais pas faire ce genre de choses pour ma première mission.";
        map["Hopefully this survives the trip!"] = "Espérons que ça survive au voyage !";
        map["I don't want to risk a blockage, better get that item out first."] = "Je ne veux pas risquer d'obstruer le conduit, mieux vaut retirer l'objet présent d'abord.";
        map["I should retrieve the item in the bowl first."] = "Je devrais d'abord récupérer l'objet coincé dans la cuvette.";
        map["That won't fit in there."] = "Ça ne rentrera pas là-dedans.";
        map["Ah, that's too big to send through."] = "Ah, c'est trop volumineux pour être expédié par là.";
        map["I'll need to send something smaller."] = "Il me faudra envoyer quelque chose de plus réduit.";
        map["Come on, plunger, don't fail me now!"] = "Allez, ventouse, ne me lâche pas maintenant !";
        map["Plunge! Plunge!"] = "Pompe ! Pompe !";
        map["I think it's working!"] = "Je crois que ça fonctionne !";
        map["I'll just drop this right here."] = "Je vais déposer ça ici.";
        map["Here goes..."] = "C'est parti...";
        map["Safe travels!"] = "Bon voyage !";
        map["Seems there's already an item in there."] = "On dirait qu'il y a déjà un objet là-dedans.";
        map["The bowl is already filled to capacity."] = "La cuvette est déjà saturée.";

        // Lemon & Mouse Hole in Don's Quarters
        map["it up first."] = "ça d'abord.";
        map["That won't be improved by lemons."] = "Des citrons n'arrangeront rien à l'affaire.";
        map["Hey, the cork fits perfectly!"] = "Tiens, le bouchon s'adapte à la perfection !";
        map["I should cork up any mouse holes I find. There's bound to be more!"] = "Je devrais boucher tous les trous de souris que je croise. Il doit y en avoir d'autres !";
        map["I think that was the last one."] = "Je crois que c'était le dernier trou.";
        map["That's another mouse burrow plugged up."] = "Et voilà un autre terrier de souris colmaté.";
        map["I'll just break a small piece off."] = "Je vais simplement en détacher un petit morceau.";
        map["It doesn't seem interested in the cheese."] = "Elle n'a pas l'air intéressée par le fromage.";
        map["Wouldn't want it to spoil."] = "Ce serait dommage que ça s'abîme.";
        map["That won't work."] = "Ça ne marchera pas.";

        // Handshake Club Hand Idol & Emergency Vote
        map["You have? Let me have a look."] = "Vraiment ? Faites-moi voir ça.";
        map["Yes, I remember now! This is the one!"] = "Oui, je m'en souviens à présent ! C'est bien elle !";
        map["Good news, everyone! We can finally get down to business."] = "Bonne nouvelle, tout le monde ! Nous pouvons enfin passer aux choses sérieuses.";
        map["Jian, would you care to begin?"] = "Jian, voulez-vous bien commencer ?";
        map["Finally!"] = "Enfin !";
        map["Ladies and gentlemen."] = "Mesdames et messieurs.";
        map["I'm afraid time is of the essence. We cannot procrastinate while Lady Unterwald's estate hangs in the balance."] = "Le temps presse, hélas. Nous ne pouvons tergiverser alors que la succession de Lady Unterwald ne tient qu'à un fil.";
        map["It is known that Lady Unterwald has driven her own family mad with paranoia, to the point where they openly conspire against her."] = "Il est notoire que Lady Unterwald a rendu sa propre famille folle de paranoïa, au point qu'ils complotent ouvertement contre elle.";
        map["It has come to my attention that the Unterwald estate is approaching insolvency."] = "J'ai appris de source sûre que le domaine Unterwald frôle la banqueroute.";
        map["I have offered to buy Lady Unterwald out, but she rebuffs me at every turn. I need to know I have the support of this order to do what needs to be done."] = "J'ai proposé de racheter les parts de Lady Unterwald, mais elle me repousse à chaque fois. J'ai besoin du soutien indéfectible de cet ordre pour faire ce qui s'impose.";
        map["This is all grave news, Jian. But as you know, we only offer a nudge in the right direction, we are not here to force Lady Unterwald's hand."] = "Ce sont de bien sombres nouvelles, Jian. Mais comme vous le savez, nous nous contentons de suggérer la bonne direction, nous ne sommes pas là pour forcer la main de Lady Unterwald.";
        map["Lady Unterwald is compromised. If we do not move swiftly, there won't be an empire to preserve!"] = "Lady Unterwald a perdu la tête. Si nous n'agissons pas promptement, il ne restera bientôt plus d'empire à préserver !";
        map["I propose we deliberate on this information, and put forth a proposal in the coming weeks."] = "Je propose que nous délibérions sur ces faits et soumettions une proposition dans les prochaines semaines.";
        map["W-What?"] = "Q-Quoi ?";
        map["Aye?"] = "Pour ?";
        map["Nay! Nay, I say! We must act now!"] = "Contre ! Je vote contre ! Il faut agir dès maintenant !";
        map["Well, I believe the Ayes have it."] = "Eh bien, je crois que les pour l'emportent.";
        map["He's not even a member of the order!"] = "Il ne fait même pas partie de notre ordre !";
        map["Irrelevant, Jian. The rules state that everyone present can cast a vote."] = "C'est sans importance, Jian. Les statuts stipulent que chaque personne présente peut prendre part au vote.";
        map["Well, what about the drunkard? Does he not get a say?"] = "Et cet ivrogne, alors ? N'a-t-il pas son mot à dire lui aussi ?";
        map["Your decision isn't final until everyone has cast their vote."] = "Votre décision ne sera pas entérinée tant que chacun n'aura pas voté.";
        map["Ah... Yes, I suppose you're right."] = "Ah... Oui, j'imagine que vous avez raison.";
        map["Mr Masson! What say you?"] = "Monsieur Masson ! Quel est votre verdict ?";
        map["Was that for or against?"] = "Était-ce pour ou contre ?";
        map["I couldn't tell."] = "Impossible à savoir.";
        map["Well then, I'm afraid we're deadlocked until our friend here can cast his vote."] = "Dès lors, nous sommes dans l'impasse jusqu'à ce que notre cher ami puisse exprimer son suffrage.";
        map["Once again, your petty rules prevent you from achieving anything!"] = "Une fois de plus, vos règles mesquines vous empêchent d'accomplir quoi que ce soit !";
        map["Another mouse burrow successfully corked."] = "Un autre terrier de souris bouché avec succès.";
        map["Didn't take it."] = "Elle n'a pas mordu.";
        map["I thought they loved cheese."] = "Je croyais pourtant que les souris raffolaient du fromage.";
        map["Do you think the waiter's palms look dry?"] = "Trouvez-vous que les paumes du garçon ont l'air sèches ?";
        map["What! Where?"] = "Quoi ! Où ça ?";
        map["The waiter's palms have ample moisture, I can assure you."] = "Les paumes du garçon bénéficient d'une humidité exemplaire, je vous l'assure.";
        map["Sorry, I must have been mistaken."] = "Pardonnez-moi, j'ai dû me tromper.";
        map["That won't do much if the paint has already dried."] = "Ça ne servira à rien si la peinture est déjà sèche.";
        map["I'll need something to apply this with."] = "Il me faudra quelque chose pour appliquer ce produit.";
        map["Let's see what secrets lie underneath this painting."] = "Voyons un peu quels secrets se cachent sous cette toile.";
        map["Uh oh... It's looking a little smeary."] = "Oh oh... Ça a l'air de baver un peu.";
        map["I should be able to fix it."] = "Je devrais être en mesure d'arranger ça.";
        map["Oh?"] = "Oh ?";
        map["Aha! In this version of the painting, Lady Unterwald is performing a hand gesture!"] = "Aha ! Dans cette version du tableau, Lady Unterwald esquisse un geste de la main !";
        map["It might be the same one I'm looking for!"] = "C'est peut-être le signe que je recherche !";

        // Herman Exterior & HQ Motorbike
        map["The cane would give me the reach, but I'll still need something to hook on to."] = "La canne me donnerait l'allonge nécessaire, mais il me manque encore de quoi l'accrocher.";
        map["Alright, here goes nothing!"] = "Allez, qui ne tente rien n'a rien !";
        map["I'll just pop this in here."] = "Je vais simplement glisser ceci là-dedans.";
        map["Hopefully they haven't emptied the tank yet."] = "Espérons qu'ils n'aient pas encore vidangé le réservoir.";
        map["A little snip, here..."] = "Un petit coup de ciseau par ici...";
        map["Cross this wire over here..."] = "On croise ce fil par-là...";
        map["There, I've fixed the faulty wiring!"] = "Et voilà, j'ai réparé le faux contact !";
        map["I've already rewired the bike."] = "J'ai déjà refait le câblage de la moto.";
        map["Alright, time to fuel up!"] = "Parfait, c'est l'heure de faire le plein !";
        map["It's already filled with fuel."] = "Elle est déjà remplie d'essence.";
        map["Here goes nothing..."] = "Allons-y, advienne que pourra...";
        map["Splugh! There's definitely fuel in there, or something that tastes like it."] = "Pouah ! C'est bien du carburant, ou du moins quelque chose qui en a le goût infâme.";
        map["It's working!"] = "Ça fonctionne !";
        map["Okay! I've got myself a full can of fuel to work with."] = "Super ! Me voilà avec un bidon d'essence plein à ras bord.";
        map["There's no fuel left in the tank."] = "Il n'y a plus une goutte de carburant dans le réservoir.";
        map["Don't want anything getting out of there."] = "Pas question que quoi que ce soit s'échappe de là.";
        map["Hmm. No dice."] = "Hmm. Chou blanc.";
        map["Maybe it's on a diet."] = "Elle doit être au régime.";
        map["I hope I'm right about this."] = "J'espère ne pas me tromper là-dessus.";
        map["306. What could that mean?"] = "306. Qu'est-ce que cela peut bien signifier ?";
        map["Let's reunite these pearls, shall we?"] = "Ressoudons ces perles, voulez-vous ?";
        map["This should add a bit of flair to the kitchen."] = "Voilà qui devrait ajouter un brin de piquant en cuisine.";
        map["I'll have to be quick."] = "Il va falloir faire vite.";
        map["Hey, no touching the list!"] = "Hé, pas touche à la liste !";

        // Pneumatic tubes in Mansion
        map["Nice, it fits!"] = "Chouette, ça rentre parfaitement !";
        map["That's ready to be requested now."] = "C'est prêt à être réclamé maintenant.";
        map["Arthur or Herman can request that item now."] = "Arthur ou Herman peuvent réclamer cet objet à présent.";
        map["There we go, ready to be requested."] = "Et voilà, prêt pour l'envoi.";
        map["There's already something in the system."] = "Il y a déjà un envoi en cours dans le réseau.";
        map["I should check for deliveries first."] = "Je devrais d'abord vérifier les réceptions.";
        map["There's an item in here. I should retrieve it."] = "Il y a un objet ici. Je devrais le récupérer.";

        // Statues & Poison & Boilers in Mansion
        map["That's money she could have left to me in her will!"] = "C'est de l'argent qu'elle aurait pu me léguer dans son testament !";
        map["You won't be getting anything if we're late!"] = "Tu ne toucheras rien du tout si nous arrivons en retard !";
        map["They'll have taken all the good stuff already, we'll be left with the scraps!"] = "Ils auront déjà tout raflé et il ne nous restera que les miettes !";
        map["Is that how it works? C-can they really do that?"] = "C'est comme ça que ça marche ? P-peuvent-ils vraiment faire ça ?";
        map["Well, I'm not waiting around to find out, come on!"] = "Eh bien, je ne vais pas attendre pour le savoir, viens !";
        map["Agh! I hate how life-like these statues are. Whatever was Auntie thinking?"] = "Agh ! Je déteste le réalisme de ces statues. Mais qu'est-ce qui a bien pu passer par la tête de tantine ?";
        map["It has to be one of Pierre's creations."] = "C'est forcément une œuvre de Pierre.";
        map["Just look at the detailing. He even carved in her fingerprints!"] = "Regarde un peu les détails. Il a même gravé ses empreintes digitales !";
        map["Let's get out of here. It's giving me the creeps!"] = "Fichons le camp d'ici. Ça me donne la chair de poule !";
        map["Mein Gott!"] = "Mein Gott !";
        map["Doctor! Are you quite alright?"] = "Docteur ! Vous allez bien ?";
        map["Herman? How did you get here?"] = "Herman ? Comment êtes-vous arrivé ici ?";
        map["Why does my neck hurt so much?"] = "Pourquoi mon cou me fait-il si horriblement mal ?";
        map["You landed on it."] = "Vous avez atterri dessus.";
        map["Of course, that mad woman tried to dart me!"] = "Bien sûr, cette folle a tenté de m'abattre avec une fléchette !";
        map["How did you know to use the adrenaline shot?"] = "Comment avez-vous su qu'il fallait m'injecter cette dose d'adrénaline ?";
        map["I was grasping at straws."] = "J'agissais au petit bonheur la chance.";
        map["No, that was the intuition of an extraordinary detective!"] = "Non, c'était l'intuition prodigieuse d'un détective hors pair !";
        map["You did it, Herman!"] = "Vous avez réussi, Herman !";
        map["I did?"] = "Vraiment ?";
        map["You're right... I did!"] = "Vous avez raison... J'ai réussi !";
        map["I suspect the poison in this dart will be the very same used on Lady Unterwald."] = "Je soupçonne le poison sur cette fléchette d'être exactement le même que celui utilisé contre Lady Unterwald.";
        map["So it was Arista, all along!"] = "C'était donc Arista depuis le tout début !";
        map["That's right, but this may not be enough evidence. We'd need a confession!"] = "Tout à fait, mais cela pourrait ne pas suffire comme preuve. Il nous faudrait des aveux !";
        map["I don't think she's the confessing type."] = "Je ne crois pas qu'elle soit du genre à passer à table facilement.";
        map["Maybe there's a way to make her talk."] = "Il existe peut-être un moyen de la faire parler.";
        map["If we can get a confession, it should be enough to clear your names."] = "Si nous obtenons des aveux, cela devrait amplement suffire à laver vos noms.";
        map["The wax is too hard, I'll need to get it more malleable."] = "La cire est trop dure, je vais devoir la rendre plus malléable.";
        map["Damn, it's not kicking out enough heat to melt the wax."] = "Mince, la chaudière ne dégage pas assez de chaleur pour faire fondre la cire.";
        map["Hm, there's not much here. I might as well add the rest of this."] = "Hm, il n'y a pas grand-chose. Autant ajouter le reste de cette mixture.";
        map["Oh, ho, ho! This stuff is potent!"] = "Oh, ho, ho ! Ce truc est diablement puissant !";
        map["That doesn't sound good, I hope the pipes can handle that much pressure."] = "Ce bruit n'augure rien de bon, j'espère que la tuyauterie résistera à cette pression.";
        map["It's already melted, but hardening fast."] = "Elle a fondu, mais elle durcit à toute vitesse.";
        map["Okay, that's ready to be requested."] = "D'accord, c'est prêt pour la demande d'envoi.";
        map["That should fit in there."] = "Ça devrait tenir là-dedans.";
        map["I should request that package first."] = "Je devrais d'abord réceptionner ce paquet.";
        map["The system is full already."] = "Le réseau est déjà saturé.";
        map["It's already full up."] = "C'est déjà plein à craquer.";
        map["I'll save you, Chiselton!"] = "Je te sauverai, Chiselton !";
        map["I hope this works!"] = "J'espère que ça va marcher !";
        map["I'll play Lady Unterwald's voice near the lock."] = "Je vais faire jouer la voix de Lady Unterwald près du verrou.";
        map["This wax imprint could fool the mechanism."] = "Cette empreinte de cire pourrait duper le mécanisme.";
        map["There! I've managed to create a wax impression."] = "Ça y est ! J'ai réussi à prendre une empreinte dans la cire.";

        // Motorbike Chase & Publishers Board
        map["I'm not thirsty."] = "Je n'ai pas soif.";
        map["I refuse to grant Dirk the satisfaction of having this approved."] = "Je refuse d'offrir à Dirk la satisfaction de voir son texte validé.";
        map["INSUFFICIENT DRAMATIC ENTRANCES."] = "ENTRÉES DRAMATIQUES INSUFFISANTES.";
        map["ROMANTIC TENSION LEVELS BELOW ACCEPTABLE THRESHOLD."] = "NIVEAU DE TENSION ROMANTIQUE SOUS LE SEUIL ADMISSIBLE.";
        map["KISSING SCENES LACK SPARK, CONSIDER ADDING EXPLOSIONS."] = "LES SCÈNES DE BAISERS MANQUENT D'ÉTINCELLES, AJOUTER DES EXPLOSIONS.";
        map["LIQUID DETECTED IN SCRIPT INPUT DEVICE."] = "LIQUIDE DÉTECTÉ DANS LA FENTE D'INSERTION DU MANUSCRIT.";
        map["ATTEMPTING SELF-CLEANING PROCESS."] = "TENTATIVE DE PROCÉDURE D'AUTO-NETTOYAGE.";
        map["SELF-CLEANING PROCESS COMPLETED SUCCESSFULLY."] = "PROCÉDURE D'AUTO-NETTOYAGE ACHEVÉE AVEC SUCCÈS.";
        map["SABOTAGE ATTEMPT DENIED."] = "TENTATIVE DE SABOTAGE MISE EN ÉCHEC.";
        map["Drat, I'll have to do better than that."] = "Flûte, il va falloir faire mieux que ça.";
        map["FOREIGN OBJECT DETECTED IN SCRIPT INPUT DEVICE."] = "CORPS ÉTRANGER DÉTECTÉ DANS LA FENTE D'INSERTION DU MANUSCRIT.";
        map["SELF-CLEANING PROCESS FAILED."] = "ÉCHEC DE LA PROCÉDURE D'AUTO-NETTOYAGE.";
        map["Excuse me, the board doesn't seem to be taking any more submissions."] = "Pardonnez-moi, mais la machine n'a plus l'air d'accepter les manuscrits.";
        map["How unusual, I've never seen the board do that before."] = "Comme c'est curieux, je n'avais encore jamais vu le jury réagir ainsi.";
        map["Herman, were you able to submit your manuscript beforehand?"] = "Herman, aviez-vous pu insérer votre manuscrit avant l'incident ?";
        map["Indeed, I did!"] = "Tout à fait, oui !";
        map["Very well. Let's see whether the underlying data supports you!"] = "Très bien. Voyons si les données statistiques corroborent vos dires !";
        map["I think the board approves? I can't tell!"] = "Je crois que le jury valide ? Impossible à dire !";
        map["Pull the lever again!"] = "Actionnez le levier à nouveau !";
        map["BLAAAARRRGGHH."] = "BLAAAARRRGGHH.";
        map["It's no use. The board is completely fried!"] = "Inutile d'insister. La machine est totalement grillée !";
        map["But without the board, we'd have to.."] = "Mais sans le jury mécanique, il nous faudrait...";
        map["You couldn't possibly mean.."] = "Vous n'insinuez tout de même pas que...";
        map["I'm afraid so. We're going to have to go with our gut on this one."] = "J'en ai bien peur. Nous allons devoir faire confiance à notre propre jugement.";
        map["NO! There must be some other way!"] = "NON ! Il doit bien y avoir une autre solution !";
        map["How can we possibly decide without the empirical data?"] = "Comment pouvons-nous trancher sans données empiriques ?";
        map["Let us deliberate."] = "Délibérons.";
        map["Here you go, my fine feathered fellow."] = "Tiens, prends ça, mon brave volatile.";
        map["The inbox tray is already full."] = "Le bac de réception est déjà plein.";
        map["They won't look at any manuscripts manually whilst that board is still active."] = "Ils refuseront de lire le moindre manuscrit manuellement tant que cette machine sera en fonction.";

        // Sleeper Carriage & Safe & Endgame
        map["Room 306. I'll slide the note underneath the door."] = "Chambre 306. Je vais glisser le mot sous la porte.";
        map["It's locked."] = "C'est fermé à clé.";
        map["There's no tape in the recorder."] = "Il n'y a pas de fil dans l'enregistreur.";
        map["I now have a voice recording of Lady Unterwald."] = "J'ai désormais un enregistrement de la voix de Lady Unterwald.";
        map["This lockpick probably only has one use, I want to make sure I'm using it wisely."] = "Ce rossignol n'a sans doute qu'un seul usage, je veux m'assurer de l'utiliser à bon escient.";
        map["Let's see what we've got in here."] = "Voyons un peu ce qu'on a là-dedans.";
        map["''Dedicated to my beloved wife, my dear Junebug''"] = "« Dédié à mon épouse bien-aimée, ma chère Libellule »";
        map["''Yours forever, George.''"] = "« À toi pour toujours, George. »";
        map["That's not a hole I can seal up."] = "Ce n'est pas un trou que je peux reboucher.";
        map["That was quick!"] = "C'était du rapide !";
        map["That'll work for the bait."] = "Ça fera un appât parfait.";
        map["But I should block off any other escape routes first."] = "Mais je devrais d'abord bloquer les autres issues de secours.";
        map["Sorry little buddy, but your crime spree is over."] = "Désolé mon bonhomme, mais ta folie criminelle s'arrête ici.";
        map["There's bound to be some stolen property in the burrow."] = "Il y a forcément du butin volé dans ce terrier.";
        map["I should hang on to these or he'll probably think that I stole them."] = "Je devrais les garder, sinon il croira sans doute que c'est moi qui les ai volés.";
        map["There! I managed to cut out a long length of the rubber tube."] = "Ça y est ! J'ai réussi à découper une bonne longueur de tube en caoutchouc.";
        map["Are you alright, Bergmann?"] = "Vous allez bien, Bergmann ?";
        map["N-No, I'm not alright! I'm feeling a little peculiar, truth be told."] = "N-Non, je ne vais pas bien ! Je me sens un peu bizarre, à vrai dire.";
        map["Maybe this stuff will get him talking."] = "Peut-être que cette substance va le faire parler.";
        map["Goodness! That's burning very effectively!"] = "Bonté divine ! Ça brûle avec une redoutable intensité !";
        map["Eugh! What's all this smoke!"] = "Beurk ! D'où vient toute cette fumée ?!";
        map["*Cough*"] = "*Tousse*";
        map["Okay Bergmann, it's time to go!"] = "Très bien Bergmann, il est l'heure de lever le camp !";
        map["Wha-?"] = "Quoi... ?";
        map["Heavens above! I don't like the sound of that!"] = "Grand Dieu ! Je n'aime pas du tout le bruit que ça fait !";
        map["It's too thick to slide between the gap, but I bet a wire hanger would work."] = "C'est trop épais pour se glisser dans la fente, mais un cintre métallique ferait l'affaire.";
        map["That doesn't need corking."] = "Ça n'a pas besoin d'être rebouché.";
        map["I need to slide something thin and wiry between the gap."] = "Je dois glisser quelque chose de fin et métallique dans l'interstice.";
        map["That's not going to help get it unstuck."] = "Ce n'est pas ça qui va aider à le décoincer.";
        map["There could be key information in here, but I can't just throw paperwork at it!"] = "Il pourrait y avoir des renseignements capitaux là-dedans, mais je ne peux pas me contenter de lui balancer de la paperasse !";
        map["That's not going to help get it open."] = "Ce n'est pas comme ça que je vais réussir à l'ouvrir.";
        map["This might help loosen his grip."] = "Ceci pourrait aider à desserrer sa poigne.";
        map["Let's see if the lock responds to Lady Unterwald's voice recording."] = "Voyons si le verrou réagit à l'enregistrement vocal de Lady Unterwald.";
        map["It worked!"] = "Ça a marché !";
        map["I need a six-digit combination. It's probably something personal."] = "Il me faut une combinaison à six chiffres. C'est probablement un détail intime.";

        // Remaining additions
        map["There's something in there already."] = "Il y a déjà quelque chose là-dedans.";
        map["I might be able to get into the lockbox."] = "Je pourrais peut-être ouvrir la boîte cadenassée.";
        map["Just give it a little whack with the ol' umbrella!"] = "Juste un bon coup avec le vieux pépin !";
        map["Uh-oh!"] = "Oh-oh !";
        map["How'd you get that?"] = "Comment as-tu obtenu ça ?";
        map["Oh this? I found it in my cell!"] = "Oh ça ? Je l'ai trouvé dans ma cellule !";
        map["Sorry, but I've got to confiscate it!"] = "Désolé, mais je dois le confisquer !";
        map["You know, it looks kinda like Lamont's umbrella!"] = "Tu sais, ça ressemble drôlement au parapluie de Lamont !";
        map["I'm sure we just have the same great taste in rain protection."] = "Je suis sûr que nous partageons simplement le même goût exquis en matière de protection contre la pluie.";
        map["I've got to lock it away, just in case you were planning a daring escape, ha ha!"] = "Je dois le mettre sous clé, au cas où tu préparerais une évasion spectaculaire, ha ha !";
        map["That's perfectly understandable!"] = "C'est parfaitement compréhensible !";
        map["Huh, looks like Jimmy dropped something from the lockbox."] = "Tiens, on dirait que Jimmy a fait tomber quelque chose de la boîte.";
        map["Hey, Agent M! You see that shiny ball over there?"] = "Hé, Agent M ! Tu vois cette boule brillante là-bas ?";
        map["I bet it's valuable!"] = "Je parie qu'elle a de la valeur !";
        map["There's a good field agent! I knew you could do it!"] = "C'est un bon agent de terrain, ça ! Je savais que tu y arriverais !";
        map["This key should unlock these chains!"] = "Cette clé devrait ouvrir ces chaînes !";
        map["I should pick it up first."] = "Je devrais le ramasser d'abord.";
        map["All those in favour?"] = "Tous ceux qui sont pour ?";
        map["Aye!"] = "Pour !";
        map["And all those against?"] = "Et tous ceux qui sont contre ?";
        map["W-Whhm?"] = "G-Grmbl ?";
        map["There's something in here already."] = "Il y a déjà quelque chose là-dedans.";
        map["Hmm, there's something in here."] = "Hmm, il y a quelque chose là-dedans.";
        map["Okay, that's in the system."] = "Bien, c'est entré dans le réseau.";
        map["Alright, that can be requested."] = "Parfait, l'envoi peut être demandé.";
        map["Diana or Herman should be able to request that now."] = "Diana ou Herman devraient pouvoir réclamer cet objet à présent.";
        map["There we are, ready to be requested!"] = "Et voilà, prêt pour l'expédition !";
        map["It can only take one item at a time."] = "Le système ne peut acheminer qu'un seul objet à la fois.";
        map["I think there's something in there already."] = "Je crois qu'il y a déjà quelque chose là-dedans.";
        map["There's nothing to record."] = "Il n'y a rien à enregistrer.";
        map["I should be able to capture Lady Unterwald's voice with this!"] = "Je devrais pouvoir enregistrer la voix de Lady Unterwald avec ceci !";
        map["I'll need another wire reel to record anything."] = "Il me faudra une autre bobine de fil pour enregistrer quoi que ce soit.";
        map["I should put the wire reel in a recording device first."] = "Je devrais d'abord insérer la bobine de fil dans un appareil d'enregistrement.";
        map["I don't think that's going to open it."] = "Je ne crois pas que ça va l'ouvrir.";
        map["Apologies, doctor."] = "Toutes mes excuses, docteur.";
        map["Isn't it your turn yet?"] = "Ce n'est pas encore ton tour ?";
        map["What's the matter, Gunter? I thought you loved digging holes!"] = "Qu'est-ce qu'il y a, Gunter ? Je croyais que tu adorais creuser des trous !";
        map["Can't we do this later? I really don't want to miss the execution!"] = "On ne peut pas faire ça plus tard ? Je ne veux vraiment pas rater l'exécution !";
        map["The executor, you imbecile!"] = "L'exécuteur testamentaire, imbécile !";
        map["Why did Auntie waste all that money on your so-called education?"] = "Pourquoi tantine a-t-elle gaspillé tout cet argent pour ta prétendue éducation ?";
        map["I'll just place this right here."] = "Je vais poser ça juste ici.";
        map["Success!"] = "Victoire !";
        map["Check it out, I've made a canister of high octane fuel!"] = "Regarde un peu, j'ai fabriqué un bidon de carburant à haut indice d'octane !";
        map["I never underestimated you for a second!"] = "Je n'ai pas douté de toi une seule seconde !";
        map["What are you waiting for? Pour it in!"] = "Qu'est-ce que tu attends ? Verse-le !";
        map["Alright! Here goes nothing..."] = "Très bien ! C'est parti, advienne que pourra...";
        map["Hold on tight!"] = "Accroche-toi bien !";
        map["I don't know how long we can maintain this boost!"] = "Je ne sais pas combien de temps on va tenir cette allure !";
        map["You're going to have to jump, Diana!"] = "Tu vas devoir sauter, Diana !";
        map["I made it!"] = "J'ai réussi !";
        map["Woo-hoo!"] = "Youhou !";
        map["Hey, run your objectives by me one last time!"] = "Hé, rappelle-moi tes objectifs une dernière fois !";
        map["I've got to make contact with the informant!"] = "Je dois entrer en contact avec l'indicateur !";
        map["That's right!"] = "Exactement !";
        map["I should listen in for any incriminating conversations!"] = "Je dois écouter aux portes pour surprendre des conversations compromettantes !";
        map["And above all else?"] = "Et par-dessus tout ?";
        map["Stay out of trouble!"] = "Ne pas m'attirer d'ennuis !";
        map["That's it!"] = "C'est ça !";
        map["Good luck, Diana!"] = "Bonne chance, Diana !";
        map["I'll contact you when I'm ready for extraction."] = "Je te contacterai dès que je serai prête pour l'extraction.";
        map["Come on, Agent M. It's you and me, against the world!"] = "Allez, Agent M. C'est toi et moi contre le reste du monde !";
        map["Hey! Get back here!"] = "Hé ! Reviens ici !";
        map["Huh, this is looking like a solo mission after all."] = "Tiens donc, on dirait bien que c'est une mission en solo après tout.";
        map["Oh, so close!"] = "Oh, si près du but !";
        map["Arthur, leave that alone."] = "Arthur, ne touche pas à cela.";
        map["Just one more locking mechanism to get through!"] = "Plus qu'un seul mécanisme de verrouillage à déjouer !";

        Process(@"translations\partitions\shared_item_uses.tsv", @"translations\partitions\shared_item_uses_french.tsv", map);
    }

    static void Process(string inPath, string outPath, Dictionary<string, string> map) {
        if (!File.Exists(inPath)) return;
        var lines = File.ReadAllLines(inPath, Encoding.UTF8);
        int count = 0;
        using (var sw = new StreamWriter(outPath, false, Encoding.UTF8)) {
            sw.WriteLine("Id\tCharacter\tEnglish\tFrench\tClass\tMethod");
            for (int i = 1; i < lines.Length; i++) {
                var l = lines[i];
                var p = l.Split('\t');
                if (p.Length < 6) continue;
                string en = p[2].Trim();
                string fr = "";
                if (map.ContainsKey(en)) {
                    fr = map[en];
                } else {
                    Console.WriteLine("Missing in shared_item_uses: [" + en + "]");
                    fr = en;
                }
                sw.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", p[0], p[1], en, fr, p[4], p[5]));
                if (!string.IsNullOrEmpty(fr)) count++;
            }
        }
        Console.WriteLine(string.Format("Processed {0}: {1} lines translated out of {2}",
            Path.GetFileName(outPath), count, lines.Length - 1));
    }
}
