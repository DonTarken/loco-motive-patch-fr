using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class BuildEngineB1 {
    static void Main() {
        var map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        // Room- Interrogation
        map["Could I escape through the door?"] = "Pourrais-je m'échapper par la porte ?";
        map["coatrack"] = "porte-manteau";
        map["recording device"] = "enregistreur";
        map["'Borrow'' the desk fan"] = "« Emprunter » le ventilateur";
        map["Rifle through the books"] = "Fouiller les livres";
        map["They sound distracted out there"] = "Ils ont l'air distraits dehors";
        map["Enjoy the breeze"] = "Profiter de la brise";
        map["I could call for help?"] = "Je pourrais appeler à l'aide ?";
        map["It's today's newspaper"] = "C'est le journal d'aujourd'hui";
        map["Those keys are my ticket to freedom!"] = "Ces clés sont mon ticket pour la liberté !";
        map["It's full of trash, as I suspected"] = "C'est plein de détritus, comme je m'en doutais";
        map["Inspect the toppled coatrack"] = "Inspecter le porte-manteau renversé";
        map["Gaze at the umbrella"] = "Regarder le parapluie";
        map["So close, and yet so far!"] = "Si près, et pourtant si loin !";
        map["This box is full of documents"] = "Cette boîte est pleine de documents";
        map["Check out the list of suspects"] = "Consulter la liste des suspects";
        map["Maybe I could escape through the window?"] = "Peut-être pourrais-je m'enfuir par la fenêtre ?";
        map["Is this thing recording me?"] = "Cet engin est-il en train de m'enregistrer ?";

        // Room- IntroCarriage
        map["the pamphlets"] = "les dépliants";
        map["the plant pot"] = "le pot de fleur";
        map["the carriage directions"] = "le plan des voitures";
        map["the statue"] = "la statue";
        map["the dining cart"] = "le chariot repas";
        map["Return to my quarters"] = "Retourner dans ma cabine";
        map["Browse travel pamphlets"] = "Consulter les dépliants touristiques";
        map["Peruse the dining cart"] = "Examiner le chariot repas";
        map["Inspect the plant pot"] = "Inspecter le pot de fleur";
        map["Read carriage directions"] = "Lire le plan des voitures";
        map["Admire statue"] = "Admirer la statue";

        // Room- ArthurQuarters
        map["files"] = "dossiers";
        map["portrait"] = "portrait";
        map["picture"] = "tableau";
        map["letter"] = "lettre";
        map["flashy suit"] = "costume tape-à-l'œil";
        map["Look Outside"] = "Regarder dehors";
        map["plain suits"] = "costumes sobres";
        map["lightswitch"] = "interrupteur";
        map["drawers"] = "tiroirs";
        map["sink cupboard"] = "meuble sous évier";
        map["Take the wooden hanger"] = "Prendre le cintre en bois";
        map["Take the mysterious letter"] = "Prendre la lettre mystérieuse";
        map["It's time to suit up!"] = "C'est l'heure de se mettre sur son trente-et-un !";
        map["Leave the room"] = "Quitter la cabine";
        map["Take a long, hard look in the mirror"] = "Se regarder attentivement dans la glace";
        map["Open the drawers"] = "Ouvrir les tiroirs";
        map["Peek inside the cupboard"] = "Jeter un œil dans le meuble";
        map["Take the mouthwash"] = "Prendre le bain de bouche";
        map["Late night reading materials"] = "Lectures tardives";
        map["A fresh bundle of files!"] = "Une nouvelle liasse de dossiers !";
        map["It's my cosy desk lamp"] = "C'est ma lampe de bureau favorite";
        map["Neatly packed luggage"] = "Bagages soigneusement rangés";
        map["It's a tiny portrait of Lady Unterwald"] = "C'est un petit portrait de Lady Unterwald";
        map["Look closely at the picture frame"] = "Observer attentivement le cadre";
        map["Incredibly fluffy slippers"] = "Des pantoufles incroyablement moelleuses";
        map["Trusty typewriter"] = "Fidèle machine à écrire";
        map["Look at the wooden hanger"] = "Regarder le cintre en bois";
        map["Stare reluctantly at the suit jacket"] = "Lorgner la veste de costume avec réticence";
        map["Classic suit jackets"] = "Vestes de costume classiques";
        map["Stare at the quietly dripping sink"] = "Observer le lavabo qui goutte doucement";
        map["Examine the mouthwash"] = "Examiner le bain de bouche";

        // Room- HermanQuarters
        map["I won't blink this time!"] = "Cette fois, je ne cillerai pas !";
        map["We'll need to distract them somehow, Arthur."] = "Il faudra faire diversion d'une manière ou d'une autre, Arthur.";
        map["Was that a blink? No..."] = "C'était un battement de paupière ? Non...";
        map["We can do this, it's two versus one!"] = "On va y arriver, deux contre un !";
        map["Concentrate..."] = "Concentration...";
        map["My eyes are starting to water!"] = "Mes yeux commencent à piquer !";
        map["Mustn't... blink."] = "Ne... pas... ciller.";
        map["My eyeballs are burning!"] = "Mes yeux me brûlent !";
        map["It's been a while now. He's got to blink at some point!"] = "Ça dure depuis trop longtemps. Il finira bien par cligner des yeux !";
        map["Damn, I blinked!"] = "Zut, j'ai cligné !";
        map["Me too!"] = "Moi aussi !";
        map["We demand a rematch, Herman!"] = "On exige une revanche, Herman !";
        map["That last round was just a warm-up."] = "Ce dernier round n'était qu'un échauffement.";
        map["crumpled paper"] = "papier froissé";
        map["tightly wound ropes"] = "cordes serrées";
        map["manuscripts"] = "manuscrits";
        map["novels"] = "romans";
        map["messy papers"] = "papiers en pagaille";
        map["Return to the sleeper carriage"] = "Retourner dans la voiture-lits";
        map["Slide open the window"] = "Faire coulisser la fenêtre";
        map["Pick up the crumpled paper"] = "Ramasser le papier froissé";
        map["Attempt to wriggle free"] = "Tenter de se tortiller pour se libérer";
        map["Inspect the clothes chest"] = "Inspecter la malle à vêtements";
        map["Critique the typewriter"] = "Passer la machine à écrire au crible";
        map["Read the manuscripts"] = "Lire les manuscrits";
        map["It’s a stack of Herman’s novels"] = "C'est une pile de romans signés Herman";
        map["Ponder the messy papers"] = "Méditer sur ces papiers en désordre";
        map["Glance at the books"] = "Jeter un coup d'œil aux livres";
        map["Could that be freedom?"] = "Serait-ce la liberté ?";
        map["A possible escape route!"] = "Une échappatoire potentielle !";
        map["Is that all he brought with him?"] = "C'est tout ce qu'il a apporté avec lui ?";
        map["Examine the manuscripts"] = "Examiner les manuscrits";

        // Room- DonQuarters
        map["Chat to Bergmann"] = "Bavarder avec Bergmann";
        map["Bergmann"] = "Bergmann";
        map["Mouse Burrow with Cheese Crumbs"] = "Trou de souris garni de miettes de fromage";
        map["Hide under the covers"] = "Se cacher sous les couvertures";
        map["Hide in the closet"] = "Se cacher dans le placard";
        map["Hide under the sink"] = "Se cacher sous l'évier";
        map["Slide the closet door"] = "Faire coulisser la porte du placard";
        map["Look inside the cupboard"] = "Regarder à l'intérieur du meuble";
        map["That's one big magnet!"] = "C'est un sacrément gros aimant !";
        map["hanger"] = "cintre";
        map["mouse burrow"] = "trou de souris";
        map["corked mouse burrow"] = "trou de souris bouché";
        map["secret panel"] = "panneau secret";
        map["closet door"] = "porte du placard";
        map["bed"] = "lit";
        map["fraudulent chips"] = "jetons truqués";
        map["suitcase"] = "valise";
        map["book of poetry"] = "recueil de poésie";
        map["unmentionables"] = "sous-vêtements";
        map["dirty plate"] = "assiette sale";
        map["champagne bucket"] = "seau à champagne";
        map["ball bearings"] = "billes de roulement";
        map["Pocket the wire hanger"] = "Empocher le cintre en fil de fer";
        map["Back to the Sleeper Carriage"] = "Retourner à la voiture-lits";
        map["Acquire the magnet"] = "Récupérer l'aimant";
        map["Pick up the magnetic ball"] = "Ramasser la boule magnétique";
        map["Take the device"] = "Prendre l'appareil";
        map["Feel around for the secret panel"] = "Tâter les murs en quête du panneau secret";
        map["Grab the book of poetry"] = "Prendre le recueil de poèmes";
        map["That's a huge magnet!"] = "C'est un aimant gigantesque !";
        map["Don dropped his recorder!"] = "Don a fait tomber son enregistreur !";
        map["It's a mouse burrow!"] = "C'est un trou de souris !";
        map["It's perfectly sealed!"] = "C'est parfaitement bouché !";
        map["Inspect the secret panel"] = "Inspecter le panneau secret";
        map["Contemplate the heart shaped bed"] = "Contempler ce lit en forme de cœur";
        map["Are these wooden casino chips?"] = "Sont-ce des jetons de casino en bois ?";
        map["Judge the disorderly packing style"] = "Juger sévèrement cette valise mal rangée";
        map["Grimace at the book of poetry"] = "Grimacer devant le recueil de poésie";
        map["Acknowledge the unmentionables"] = "Prendre note des sous-vêtements";
        map["What a slob!"] = "Quel souillon !";
        map["This champagne looks expensive"] = "Ce champagne a l'air hors de prix";
        map["A tray of ball bearings?"] = "Un plateau de billes en métal ?";

        // Room- DianaQuarters
        map["wire reel stack"] = "pile de bobines de fil";
        map["confusing machine"] = "machine déconcertante";
        map["closet"] = "placard";
        map["panel"] = "panneau";
        map["radio panel"] = "panneau radio";
        map["wire recorder"] = "magnétophone à fil";
        map["wires"] = "fils";
        map["Ask about the wire reel stack"] = "Se renseigner sur la pile de bobines";
        map["Adjust the lamp"] = "Régler la lampe";
        map["What is any of this stuff?"] = "Qu'est-ce que tout ce bric-à-brac ?";
        map["Open the closet"] = "Ouvrir le placard";
        map["The panel is covered in dials and gauges!"] = "Le panneau est constellé de cadrans et de jauges !";
        map["Play with the radio panel"] = "Tripoter le panneau radio";
        map["It’s a wire recorder!"] = "C'est un magnétophone à fil !";
        map["Complain about the wires"] = "Se plaindre de ces satanés câbles";

        // Room- SleeperCarriage
        map["Try harder!"] = "Fais un effort !";
        map["Come on out, detective!"] = "Sors de là, détective !";
        map["He has to be in there!"] = "Il est forcément là-dedans !";
        map["It's no use. It's locked!"] = "C'est inutile. C'est fermé à clé !";
        map["You couldn't find a spare set of keys?"] = "Tu n'as pas trouvé de double des clés ?";
        map["We just want to have a chat, Herman!"] = "On veut juste discuter, Herman !";
        map["You can't hide in there forever, detective!"] = "Tu ne pourras pas te terrer là-dedans éternellement !";
        map["Keep listening"] = "Continuer d'écouter";
        map["the Dining Carriage"] = "le wagon-restaurant";
        map["the Kitchen Carriage"] = "le wagon-cuisine";
        map["the door sign"] = "la plaque de porte";
        map["the luggage cart"] = "le chariot à bagages";
        map["the telephone"] = "le téléphone";
        map["plaque"] = "plaque";
        map["fusebox"] = "boîte à fusibles";
        map["the wiring"] = "le câblage";
        map["Politely knock"] = "Frapper poliment";
        map["Hesitantly knock"] = "Frapper avec hésitation";
        map["Cautiously knock"] = "Frapper prudemment";
        map["Go to the Dining Carriage"] = "Aller au wagon-restaurant";
        map["Go to the Kitchen Carriage"] = "Aller au wagon-cuisine";
        map["Call the onboard service"] = "Appeler le service de bord";
        map["Tentatively knock"] = "Frapper timidement";
        map["To Don's Quarters"] = "Vers la cabine de Don";
        map["Disconnect the wiring"] = "Débrancher le câblage";
        map["Inspect room number"] = "Inspecter le numéro de cabine";
        map["Glance at the door sign"] = "Jeter un œil à la plaque de porte";
        map["Ooh, fancy!"] = "Oh, très chic !";
        map["Look at the fusebox"] = "Regarder la boîte à fusibles";

        // Room- DiningCarriage
        map["Meet up with Lady Unterwald"] = "Rejoindre Lady Unterwald";
        map["Some Time Later..."] = "Quelque temps plus tard...";
        map["No line cutting!"] = "On ne coupe pas la file !";
        map["Psst!"] = "Psst !";
        map["Hey kid!"] = "Hé, p'tit gars !";
        map["water pitcher"] = "pichet d'eau";
        map["sign"] = "panneau";
        map["will"] = "testament";
        map["napkins"] = "serviettes";
        map["glasses"] = "verres";
        map["lemons"] = "citrons";
        map["half-eaten meal"] = "repas entamé";
        map["bottles"] = "bouteilles";
        map["the sunset"] = "le coucher de soleil";
        map["briefcase"] = "mallette";
        map["Grab Don's room keys"] = "Prendre les clés de cabine de Don";
        map["Go to the Sleeper Carriage"] = "Aller à la voiture-lits";
        map["Go to the Casino Carriage"] = "Aller au wagon-casino";
        map["Grab the missing will!"] = "S'emparer du testament disparu !";
        map["Ask about the corking device"] = "Se renseigner sur la boucheuse";
        map["Take a napkin"] = "Prendre une serviette";
        map["Take a lemon"] = "Prendre un citron";
        map["Pick up the magnet"] = "Prendre l'aimant";
        map["Rummage through the briefcase"] = "Fouiller la mallette";
        map["Look at the water pitcher"] = "Regarder le pichet d'eau";
        map["Read the sign"] = "Lire le panneau";
        map["Examine the box of napkins"] = "Examiner la boîte de serviettes";
        map["Peer over the tray of drinks"] = "Jeter un œil au plateau de boissons";
        map["Ask about the lemons"] = "Demander des citrons";
        map["What was he eating?"] = "Qu'est-ce qu'il mangeait ?";
        map["Inspect the bottles"] = "Inspecter les bouteilles";
        map["Stare directly into the sunset"] = "Contempler le soleil couchant";
        map["Look at the briefcase"] = "Regarder la mallette";

        // Room- CasinoCarriage
        map["Watch Don play roulette"] = "Regarder Don jouer à la roulette";
        map["Put it all on, uhh..."] = "Tout sur le... euh...";
        map["Let's put everything on..."] = "Mettons le paquet sur...";
        map["I want everything on..."] = "Je mise tout sur...";
        map["How about we put it all on..."] = "Et si on mettait tout sur...";
        map["Red."] = "Rouge.";
        map["Black."] = "Noir.";
        map["Things are coming up green for Donny!"] = "Tout roule pour le petit Donny !";
        map["Yow! I love it!"] = "Youhou ! J'adore ça !";
        map["Woo! Money in the bag, baby!"] = "Dans la poche, bébé !";
        map["Oh yeah! I won!"] = "Oh oui ! J'ai gagné !";
        map["I won!"] = "J'ai gagné !";
        map["curtain"] = "rideau";
        map["roulette table"] = "table de roulette";
        map["slot machine"] = "machine à sous";
        map["chandelier"] = "lustre";
        map["notice"] = "avis";
        map["casino patrons"] = "clients du casino";
        map["flurry of hands"] = "mêlée de mains";
        map["Talk to the hidden figure"] = "Parler à la silhouette dissimulée";
        map["Go to Lounge Carriage"] = "Aller au wagon-salon";
        map["Chat to the casino patrons"] = "Bavarder avec les clients du casino";
        map["What's behind this curtain?"] = "Qu'y a-t-il derrière ce rideau ?";
        map["Inspect the roulette table"] = "Inspecter la table de roulette";
        map["It's loud and annoying"] = "C'est bruyant et agaçant";
        map["It's a dazzling crystal chandelier"] = "C'est un somptueux lustre en cristal";
        map["Read the polite notice"] = "Lire l'avis de courtoisie";
        map["Look at the large magnet"] = "Regarder le gros aimant";
        map["It's a flurry of hands!"] = "Quelle pagaille de poignées de main !";

        // Room- LoungeCarriage
        map["Meanwhile..."] = "Pendant ce temps...";
        map["WOooOOoooOOOOooo"] = "Tchoo-tchoooo !";
        map["Aieeeeee!"] = "Aieeeeee !";
        map["Arthur Ackerman."] = "Arthur Ackerman.";
        map["YOU?!"] = "VOUS ?!";
        map["Huh?!"] = "Hein ?!";
        map["Wha-!"] = "Qu- !";
        map["That's enough bickering, boys!"] = "Ça suffit les chamailleries, les garçons !";
        map["Haven't we suffered enough?"] = "N'avons-nous pas assez souffert ?";
        map["Sorry, mother."] = "Pardon, Mère.";
        map["guest list"] = "liste des invités";
        map["bottle of turpentine"] = "bouteille de térébenthine";
        map["table"] = "table";
        map["piano"] = "piano";
        map["backstage door"] = "porte des coulisses";
        map["microphone"] = "microphone";
        map["blood stain"] = "tache de sang";
        map["confetti"] = "confettis";
        map["shoeshine seats"] = "sièges de cireur";
        map["bookshelf"] = "étagère à livres";
        map["Go to Lady Unterwald's quarters"] = "Aller dans les quartiers de Lady Unterwald";
        map["Snatch the hearing horn"] = "Chipper le cornet acoustique";
        map["Hurriedly grab the will"] = "Saisir le testament en toute hâte";
        map["Swipe the set list"] = "Embarquer la liste des morceaux";
        map["Grab the guest list"] = "Prendre la liste des invités";
        map["Go to the green room"] = "Aller dans le salon d'honneur";
        map["Pick up the bottle of turpentine"] = "Prendre la bouteille de térébenthine";
        map["Look at the hearing horn"] = "Regarder le cornet acoustique";
        map["Read the guest list"] = "Lire la liste des invités";
        map["Look at the table"] = "Regarder la table";
        map["Admire the Piano"] = "Admirer le piano";
        map["Peer into the Green Room"] = "Jeter un coup d'œil dans le salon";
        map["Grab the Microphone"] = "Saisir le micro";
        map["It’s a dried up blood stain"] = "C'est une tache de sang séché";
        map["Look at the confetti"] = "Regarder les confettis";
        map["Take a seat"] = "S'asseoir";
        map["Inspect the bookshelf"] = "Inspecter l'étagère";

        // Room- HandshakeClub
        map["THE ORDER OF IDLE HANDS."] = "L'ORDRE DES MAINS OISIVES.";
        map["Take it easy there, Herman. You had a bit of a nasty hand injury."] = "Doucement, Herman. Tu as eu une vilaine blessure à la main.";
        map["Jian?"] = "Jian ?";
        map["Brother Jared"] = "Frère Jared";
        map["Talk to Brother Jared"] = "Parler à Frère Jared";
        map["smudge"] = "bavure";
        map["painting"] = "peinture";
        map["book"] = "livre";
        map["A corked up mouse hole"] = "Un trou de souris bouché par un bouchon";
        map["Is that a smudge?"] = "Serait-ce une bavure ?";
        map["Look at the gesture"] = "Observer la poignée de main";
        map["Ask about the book"] = "Se renseigner sur le livre";

        // Room- StorageRoom
        map["Are you sure you haven't just misplaced your room keys, sir?"] = "Êtes-vous certain de ne pas avoir simplement égaré vos clés, monsieur ?";
        map["No sir, you've been very cl-"] = "Non monsieur, vous avez été très c-";
        map["I smell a rat, and I'm going to sniff them out, if my name isn't-"] = "Je sens une arnaque, et je vais tirer ça au clair ou je ne m'appelle pas...";
        map["Attempt to grab the mouse"] = "Tenter d'attraper la souris";
        map["fence"] = "grillage";
        map["Cheese"] = "Fromage";
        map["large crate"] = "grosse caisse";
        map["the padlock"] = "le cadenas";
        map["gate"] = "grille";
        map["ladder pull"] = "crochet d'échelle";
        map["spray bottle"] = "flacon pulvérisateur";
        map["heavy chest"] = "coffre lourd";
        map["briefcases"] = "mallettes";
        map["the darkness"] = "l'obscurité";
        map["Is that the doctor's briefcase?"] = "Est-ce la mallette du docteur ?";
        map["Leave the luggage storage"] = "Sortir du local à bagages";
        map["Quickly apprehend the mouse"] = "Capturer prestement la souris";
        map["Open the gate"] = "Ouvrir la grille";
        map["Take the ladder pull"] = "Prendre le crochet d'échelle";
        map["Pick up the spray bottle"] = "Ramasser le vaporisateur";
        map["Inspect the briefcase"] = "Inspecter la mallette";
        map["Examine the chewed up fence"] = "Examiner le grillage rongé";
        map["Look at the cheese"] = "Regarder le fromage";
        map["Examine the large crate"] = "Examiner la grosse caisse";
        map["Tug on the padlock"] = "Tirer sur le cadenas";
        map["Explore the chest"] = "Fouiller le coffre";
        map["Look through the briefcases"] = "Inspecter les mallettes";
        map["Peer into the darkness"] = "Scruter l'obscurité";

        // Room- UnterwaldCarriage
        map["Another bouquet? You certainly know how to flatter an old gal."] = "Encore un bouquet ? Vous savez décidément parler aux dames.";
        map["room key"] = "clé de cabine";
        map["Examine room key"] = "Examiner la clé de cabine";
        map["No, Jian. We don't have a deal. I've made up my mind!"] = "Non, Jian. Marché conclu, un point c'est tout. Ma décision est prise !";
        map["AauGHh!"] = "AauGHh !";
        map["Coerce Herman out of the wardrobe"] = "Inciter Herman à sortir de la penderie";
        map["Do we really believe that Lady Unterwald left her entire estate to that no-name attorney?"] = "Croyez-vous sérieusement que Lady Unterwald ait légué toute sa fortune à ce gratte-papier inconnu ?";
        map["Arthur had access to Lady Unterwald and her legal paperwork. It's a troubling thought, I must say."] = "Arthur avait un accès privilégié à Lady Unterwald et à ses dossiers juridiques. C'est troublant, je dois dire.";
        map["instrument case"] = "étui d'instrument";
        map["gift basket"] = "panier garni";
        map["chilli plant"] = "plant de piment";
        map["balloon"] = "ballon";
        map["wardrobe"] = "penderie";
        map["rug"] = "tapis";
        map["drawer"] = "tiroir";
        map["petal leaf"] = "pétale";
        map["hatch"] = "trappe";
        map["greetings card"] = "carte de vœux";
        map["safe"] = "coffre-fort";
        map["Mr Liu"] = "M. Liu";
        map["Take a chilli pepper"] = "Cueillir un piment";
        map["Roll up the rug"] = "Enrouler le tapis";
        map["Rifle through the drawer"] = "Fouiller le tiroir";
        map["Pick up the petal leaf"] = "Ramasser le pétale";
        map["Examine the locks"] = "Examiner les serrures";
        map["Examine the briefcase"] = "Examiner la mallette";
        map["Look over the books"] = "Examiner les livres";
        map["This instrument case is huge!"] = "Cet étui d'instrument est gigantesque !";
        map["Check out the retirement gift"] = "Regarder le cadeau de départ en retraite";
        map["Check out the chilli plant"] = "Examiner le plant de piment";
        map["Enjoy the balloons"] = "Admirer les ballons";
        map["It's a real life walk-in wardrobe!"] = "C'est un véritable dressing dans le train !";
        map["Was this moved recently?"] = "A-t-on déplacé ceci récemment ?";
        map["Ask about the rose petals"] = "Poser des questions sur les pétales de rose";
        map["Stare in awe at the floor hatch"] = "Regarder la trappe au sol avec stupeur";
        map["It's the same model as mine!"] = "C'est le même modèle que le mien !";
        map["Read the greetings card"] = "Lire la carte de vœux";
        map["I hope I didn't spoil the portrait"] = "J'espère ne pas avoir abîmé le portrait";
        map["Ponder the safe"] = "Observer le coffre-fort d'un air songeur";
        map["Look at Mr Liu"] = "Regarder M. Liu";

        // Room- KitchenCarriage
        map["Taste the soup"] = "Goûter la soupe";
        map["suspicious soup"] = "soupe suspecte";
        map["corked burrow"] = "trou bouché";
        map["pans"] = "casseroles";
        map["stovetop"] = "plaques de cuisson";
        map["tap"] = "robinet";
        map["gas valve"] = "vanne de gaz";
        map["sink plunger"] = "ventouse";
        map["oyster sack"] = "sac d'huîtres";
        map["stockpot"] = "marmite";
        map["knobs"] = "boutons";
        map["spice rack"] = "étagère à épices";
        map["discarded gas canister"] = "bonbonne de gaz abandonnée";
        map["Swipe the oven gloves"] = "Subtiliser les gants de cuisine";
        map["Grab the butter"] = "Prendre le beurre";
        map["Use the tap"] = "Ouvrir le robinet";
        map["Increase the gas flow"] = "Augmenter le débit de gaz";
        map["Grab the sink plunger"] = "Prendre la ventouse";
        map["Turn off the grill"] = "Éteindre le gril";
        map["Go to the exterior carriage"] = "Sortir sur la passerelle extérieure";
        map["To Kitchen Pantry"] = "Vers le garde-manger";
        map["It's a house for a mouse"] = "C'est un logis pour rongeur";
        map["Glance at the pans"] = "Jeter un coup d'œil aux casseroles";
        map["That's a fancy stovetop"] = "Voilà des fourneaux haut de gamme";
        map["When was this last cleaned?"] = "Quand cela a-t-il été récuré pour la dernière fois ?";
        map["Look at the oyster sack"] = "Regarder le sac d'huîtres";
        map["What’s cooking?"] = "Qu'est-ce qui mijote là-dedans ?";
        map["Examine the spice rack"] = "Examiner les épices";
        map["It’s a discarded gas canister"] = "C'est une bonbonne de gaz usagée";
        map["This must be the pantry"] = "Ce doit être le garde-manger";

        // Room- Pantry
        map["cheese wheel"] = "meule de fromage";
        map["baguettes"] = "baguettes";
        map["the eggs"] = "les œufs";
        map["pickle jars"] = "bocaux de cornichons";
        map["preserves"] = "conserves";
        map["flour"] = "farine";
        map["Lady Unterwald’s Cane"] = "Canne de Lady Unterwald";
        map["freezer"] = "congélateur";
        map["Leave the pantry"] = "Sortir du garde-manger";
        map["Break off a piece"] = "En casser un morceau";
        map["Grab the walking cane"] = "Prendre la canne";
        map["Investigate the cheese wheel"] = "Examiner la meule de fromage";
        map["Gaze at the baguettes"] = "Regarder les baguettes de pain";

        Process(@"translations\partitions\engine_b1.tsv", @"translations\partitions\engine_b1_french.tsv", map);
    }

    static void Process(string inPath, string outPath, Dictionary<string, string> map) {
        var lines = File.ReadAllLines(inPath, Encoding.UTF8);
        int count = 0;
        using (var sw = new StreamWriter(outPath, false, Encoding.UTF8)) {
            sw.WriteLine("English\tFrench\tGerman\tSampleSourceFile\tSampleSourceFunction");
            for (int i = 1; i < lines.Length; i++) {
                var p = lines[i].Split('\t');
                if (p.Length < 4) continue;
                string en = p[0].Trim();
                string de = p[1].Trim();
                string srcFile = p[2].Trim();
                string srcFunc = p[3].Trim();
                string fr = "";

                if (map.ContainsKey(en)) {
                    fr = map[en];
                    count++;
                } else {
                    Console.WriteLine("Missing in engine_b1: [" + en + "]");
                    fr = en;
                }

                sw.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}\t{4}", en, fr, de, srcFile, srcFunc));
            }
        }
        Console.WriteLine(string.Format("Processed {0}: {1} / {2} lines translated",
            Path.GetFileName(outPath), count, lines.Length - 1));
    }
}
