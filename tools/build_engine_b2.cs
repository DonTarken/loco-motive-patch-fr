using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class BuildEngineB2 {
    static void Main() {
        var map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        // Pantry
        map["Check the eggs"] = "Vérifier les œufs";
        map["Inspect the pickle jars"] = "Inspecter les bocaux de cornichons";
        map["Look at the preserves"] = "Regarder les conserves";
        map["Examine the flour"] = "Examiner la farine";
        map["Is this Lady Unterwald’s Cane?"] = "Est-ce la canne de Lady Unterwald ?";
        map["That’s a large freezer"] = "Voilà un sacré congélateur";

        // ExteriorCarriage / Showdown
        map["Not so fast!"] = "Pas si vite !";
        map["Finale"] = "Finale";

        // UnterwaldLobby
        map["Boys, stop this arguing at once!"] = "Les garçons, cessez de vous disputer immédiatement !";
        map["There's to be no arguing! Not in front of our guest."] = "Pas de dispute ! Pas devant notre invité.";
        map["button"] = "bouton";
        map["Go to the washroom"] = "Aller aux toilettes";
        map["Push the button"] = "Appuyer sur le bouton";
        map["Attempt to open the door"] = "Essayer d'ouvrir la porte";

        // PublisherOffice
        map["Nooooo!"] = "Noooon !";
        map["The board."] = "La roue.";
        map["Gloat at the board"] = "Narguer la roue";
        map["Ah ha ha!"] = "Ah ha ha !";
        map["Oh ho ho!"] = "Oh ho ho !";
        map["It's for you, Herman. Were you expecting a call?"] = "C'est pour toi, Herman. Tu attendais un appel ?";
        map["Shoo! Get out of here!"] = "Ouste ! Du balai !";
        map["Get out of here!"] = "Fichez le camp !";
        map["Get away from here, you winged rodents!"] = "Hors d'ici, rongeurs ailés !";
        map["the billboard"] = "le panneau d'affichage";
        map["the merch pile"] = "la pile de produits dérivés";
        map["the desk phone"] = "le téléphone de bureau";
        map["the board"] = "la roue";
        map["the slot"] = "la fente";
        map["the water cooler"] = "la fontaine à eau";
        map["the paper cups"] = "les gobelets en carton";
        map["the in-tray"] = "le bac à courrier";
        map["the document"] = "le document";
        map["the stationary pot"] = "le pot à crayons";
        map["the packaging"] = "le carton d'emballage";
        map["the windowsill"] = "le rebord de fenêtre";
        map["the pigeon"] = "le pigeon";
        map["the waste paper bin"] = "la corbeille à papier";
        map["the lever"] = "le levier";
        map["the cityscape"] = "le panorama urbain";
        map["the mail"] = "le courrier";
        map["Pick up the prototype doll"] = "Prendre le prototype de poupée";
        map["Grab a paper cup"] = "Prendre un gobelet en carton";
        map["Check for packages"] = "Vérifier les colis";
        map["Swipe the stationary pot"] = "Chiper le pot à crayons";
        map["Take some popcorn"] = "Prendre du pop-corn";
        map["Take the discarded manuscript"] = "Prendre le manuscrit jeté";
        map["Is that a Dirk Chiselton billboard?"] = "C'est un panneau pour Dirk Chiselton ?";
        map["Look at all that Herman merch!"] = "Regardez tous ces produits dérivés Herman !";
        map["Look at the desk phone"] = "Regarder le téléphone de bureau";
        map["Glare at the board"] = "Foudroyer la roue du regard";
        map["Examine the slot"] = "Examiner la fente";
        map["Look at the water cooler"] = "Regarder la fontaine à eau";
        map["Peek at the in-tray"] = "Jeter un œil au bac à courrier";
        map["Look at the document"] = "Regarder le document";
        map["Look at the stationary pot"] = "Regarder le pot à crayons";
        map["Ponder the packaging"] = "Songer à l'emballage";
        map["Look at the windowsill"] = "Regarder le rebord de fenêtre";
        map["It's a pigeon!"] = "C'est un pigeon !";
        map["Look at the waste paper bin"] = "Regarder la corbeille à papier";
        map["That's a big lever"] = "Voilà un grand levier";
        map["Ponder the skyline"] = "Contempler l'horizon de la ville";
        map["Peer at the stacks of mail"] = "Scruter les piles de courrier";

        // HermanExterior
        map["lost will"] = "testament disparu";
        map["Head back inside"] = "Rentrer à l'intérieur";
        map["Look at the will"] = "Regarder le testament";

        // SealedLetter
        map["Pick at the wax seal"] = "Gratter le sceau de cire";
        map["Scrape at the wax seal"] = "Racler le sceau de cire";
        map["seal"] = "sceau";
        map["Break the wax seal"] = "Rompre le sceau de cire";

        // DonCasinoChips
        map["Confiscate the casino chips"] = "Confisquer les jetons de casino";

        // RooftopAccess
        map["With this new footwear, I should be able to slip into my room, unhindered."] = "Avec ces nouvelles chaussures, je devrais pouvoir me faufiler dans ma cabine sans encombre.";
        map["ladder"] = "échelle";
        map["Climb on to the roof"] = "Grimper sur le toit";

        // Cell
        map["toilet bowl"] = "cuvette des toilettes";
        map["toilet flush"] = "chasse d'eau";
        map["opening"] = "ouverture";
        map["cell door"] = "porte de la cellule";
        map["valve"] = "vanne";
        map["toilet"] = "toilettes";
        map["the bed"] = "le lit";
        map["the bed frame"] = "le cadre de lit";
        map["the pillow"] = "l'oreiller";
        map["leaky pipe"] = "tuyau percé";
        map["Flush the toilet"] = "Tirer la chasse d'eau";
        map["Turn the valve"] = "Tourner la vanne";
        map["Pick up the rusty pole"] = "Prendre la barre rouillée";
        map["Look inside the toilet"] = "Regarder au fond de la cuvette";
        map["Look out from the cell"] = "Regarder hors de la cellule";
        map["Attempt the cell door"] = "Essayer la porte de la cellule";
        map["Peek through the bars"] = "Épier à travers les barreaux";
        map["Check the hallway"] = "Vérifier le couloir";
        map["Look at the cell door"] = "Regarder la porte de la cellule";
        map["Climb up to the window"] = "Grimper jusqu'à la fenêtre";
        map["Examine the bed"] = "Examiner le lit";
        map["Examine the bed frame"] = "Examiner le cadre de lit";
        map["Grimace at the bed"] = "Faire la grimace devant le lit";
        map["Check under the pillow"] = "Vérifier sous l'oreiller";
        map["Is that a leaky pipe?"] = "C'est un tuyau qui fuit ?";

        // CellExterior
        map["That's it, bring it back to me!"] = "C'est ça, rapporte-la-moi !";
        map["lockbox"] = "coffret";
        map["chain"] = "chaîne";
        map["cell"] = "cellule";
        map["jail keys"] = "clés de la prison";
        map["Return to the cell"] = "Retourner dans la cellule";
        map["Swipe the jail keys"] = "Chiper les clés de la prison";
        map["Phone the Dirk Chiselton Hotline"] = "Appeler la permanence de Dirk Chiselton";
        map["Check out the locker"] = "Examiner le casier";
        map["Look at the wall chain"] = "Regarder la chaîne murale";
        map["Did somebody drop that?"] = "Quelqu'un a laissé tomber ça ?";

        // StationExterior / GreenRoom / Bathroom
        map["Return to my cell"] = "Retourner dans ma cellule";
        map["Talk to the singer"] = "Parler à la chanteuse";
        map["singer"] = "chanteuse";
        map["Talk to the band members"] = "Parler aux membres du groupe";
        map["bassist"] = "bassiste";
        map["drummer"] = "batteur";
        map["saxophonist"] = "saxophoniste";
        map["He's taking a tumble!"] = "Il fait une mauvaise chute !";
        map["Somebody get the doctor!"] = "Que quelqu'un aille chercher le médecin !";
        map["Leave the green room"] = "Quitter la loge";
        map["Look at the knife"] = "Regarder le couteau";
        map["Auugh!"] = "Aaargh !";
        map["Ow! Ow!"] = "Aïe ! Aïe !";
        map["Ow! My head!"] = "Aïe ! Ma tête !";
        map["ToiletRoll"] = "Papier toilette";
        map["plunger"] = "ventouse";
        map["cupboard"] = "placard";
        map["Take the plunger"] = "Prendre la ventouse";
        map["Open the cupboard"] = "Ouvrir le placard";
        map["Leave the bathroom"] = "Quitter la salle de bains";

        // InlandRevenueHQ
        map["Morning, Phil!"] = "Bonjour, Phil !";
        map["Aagh!"] = "Aaah !";
        map["the vehicle"] = "le véhicule";
        map["motorbike"] = "moto";
        map["fuel tank"] = "réservoir de carburant";
        map["canister"] = "cartouche";
        map["the fuel inlet"] = "l'orifice du réservoir";
        map["the loading bay"] = "la zone de chargement";
        map["wiring kit"] = "kit de câbles";
        map["the overhead pipes"] = "les tuyaux au plafond";
        map["engine block"] = "bloc moteur";
        map["tool cabinet"] = "armoire à outils";
        map["the rubbish pile"] = "le tas d'ordures";
        map["the tool box"] = "la boîte à outils";
        map["the mission board"] = "le tableau des missions";
        map["the food packet"] = "le paquet de vivres";
        map["the notes"] = "les notes";
        map["Push the lever down"] = "Abaisser le levier";
        map["Leave the test yard"] = "Quitter la cour d'essai";
        map["Pick up the fuel tank"] = "Prendre le réservoir de carburant";
        map["Take the canister"] = "Prendre la cartouche";
        map["Pick up Agent M"] = "Prendre l'Agent M";
        map["What a piece of rubbish!"] = "Quel tas de ferraille !";
        map["Check the fuel inlet"] = "Vérifier l'orifice du réservoir";
        map["Check the motorbike"] = "Vérifier la moto";
        map["Look at the mouse"] = "Regarder la souris";
        map["It's the loading bay!"] = "C'est la zone de chargement !";
        map["Look at the wiring kit"] = "Regarder le kit de câbles";
        map["Check out the overhead pipes"] = "Examiner les tuyaux au plafond";
        map["Consider going home"] = "Songer à rentrer chez soi";
        map["Are those missiles?"] = "Sont-ce des missiles ?";
        map["Check the tool cabinet"] = "Vérifier l'armoire à outils";
        map["Check the rubbish pile"] = "Fouiller le tas d'ordures";
        map["Examine the red tool box"] = "Examiner la boîte à outils rouge";
        map["Ponder the mission board"] = "Méditer sur le tableau des missions";
        map["Inspect the food packet"] = "Inspecter le paquet de vivres";
        map["Read the notes"] = "Lire les notes";
        map["folded ladder"] = "échelle repliée";
        map["Look at the folded ladder"] = "Regarder l'échelle repliée";

        // TrainFront
        map["Aiiieeeee!"] = "Aiiieeeee !";
        map["whistle cord"] = "corde du sifflet";
        map["the financial records"] = "les registres comptables";
        map["bullet damage"] = "impacts de balles";
        map["scenery"] = "paysage";
        map["engine room"] = "salle des machines";
        map["levers"] = "leviers";
        map["instruments"] = "instruments";
        map["dials"] = "cadrans";
        map["ashes"] = "cendres";
        map["the firebox"] = "le foyer de la chaudière";
        map["Grab a lump of coal"] = "Prendre un morceau de charbon";
        map["Pull on the whistle cord"] = "Tirer sur la corde du sifflet";
        map["Is this the whistle cord?"] = "Est-ce la corde du sifflet ?";
        map["Examine the financial records"] = "Examiner les registres comptables";
        map["Inspect the bullet holes"] = "Inspecter les impacts de balles";
        map["What a view!"] = "Quelle vue !";
        map["Look towards the engine room"] = "Regarder vers la salle des machines";
        map["Ponder the controls"] = "Examiner les commandes d'un œil songeur";
        map["What do any of these mean?"] = "Qu'est-ce que tout cela signifie ?";
        map["Stare at the dials"] = "Fixer les cadrans";
        map["Examine the burnt up financial records"] = "Examiner les registres comptables calcinés";
        map["Look at the firebox"] = "Regarder le foyer de la chaudière";

        // MansionExterior / MansionLobby
        map["THE END"] = "FIN";
        map["Hmm? I don't see a-"] = "Hmm ? Je ne vois pas d...";
        map["10 Minutes Later..."] = "10 minutes plus tard...";
        map["Hi-yah!"] = "Hi-yah !";
        map["Let me go, you boulder!"] = "Lâche-moi, espèce de brute !";
        map["You're pulling my hair!"] = "Tu me tires les cheveux !";
        map["No, No! Below the belt! Below the belt!"] = "Non, non ! Coup bas ! Coup bas !";
        map["Take this!"] = "Prends ça !";
        map["And one of these!"] = "Et un de ceux-là !";
        map["Grah!"] = "Graaah !";
        map["Stop your squirming!"] = "Arrête de te débattre !";
        map["You're not going anywhere!"] = "Vous n'irez nulle part !";
        map["How's that?"] = "Ça te plaît ?";
        map["Haha!"] = "Haha !";
        map["I can do this all day!"] = "Je peux faire ça toute la journée !";
        map["Hold still!"] = "Ne bougez plus !";
        map["You're just going to hurt yourselves!"] = "Vous allez juste vous faire mal !";
        map["Aieee!"] = "Aïeee !";
        map["rope"] = "corde";
        map["Look at the rope"] = "Regarder la corde";

        // MansionInterior
        map["The order can handle the day-to-day operations. We're here to lend a hand."] = "L'ordre peut gérer les opérations courantes. Nous sommes là pour donner un coup de main.";
        map["Look over the gramophone"] = "Examiner le gramophone";
        map["Inspect the device"] = "Inspecter l'appareil";
        map["It's an old looking notebook."] = "C'est un vieux carnet de notes.";
        map["small safe"] = "petit coffre-fort";
        map["big safe"] = "grand coffre-fort";
        map["pneumatic tube"] = "tube pneumatique";
        map["swords"] = "épées";
        map["bull mask"] = "masque de taureau";
        map["funerary mask"] = "masque funéraire";
        map["mask"] = "masque";
        map["masks"] = "masques";
        map["cigar box"] = "boîte de cigares";
        map["map"] = "carte";
        map["gramophone"] = "gramophone";
        map["vinyl records"] = "disques vinyles";
        map["the machine"] = "la machine";
        map["telescope"] = "télescope";
        map["drinks globe"] = "globe bar";
        map["fireplace"] = "cheminée";
        map["small painting"] = "petit tableau";
        map["newspaper excerpt"] = "coupure de journal";
        map["bookends"] = "serre-livres";
        map["wire reel"] = "bobine de fil";
        map["boiler"] = "chaudière";
        map["poison barrels"] = "barils de poison";
        map["body"] = "corps";
        map["notebook"] = "carnet";
        map["frames"] = "cadres";
        map["globe"] = "globe";
        map["box"] = "boîte";
        map["make-shift grave"] = "tombe de fortune";
        map["Listen to the mechanism"] = "Écouter le mécanisme";
        map["Push the request button"] = "Appuyer sur le bouton d'appel";
        map["Take a vinyl record"] = "Prendre un disque vinyle";
        map["Press the request button"] = "Appuyer sur le bouton d'appel";
        map["Take the wire reel"] = "Prendre la bobine de fil";
        map["Head back to the lobby"] = "Retourner au hall";
        map["Look at the big safe"] = "Regarder le grand coffre-fort";
        map["Study the painting"] = "Étudier le tableau";
        map["Look at the pneumatic tube"] = "Regarder le tube pneumatique";
        map["They look razor sharp!"] = "Elles ont l'air affûtées comme des rasoirs !";
        map["Inspect the bull mask"] = "Inspecter le masque de taureau";
        map["Study the funerary mask"] = "Étudier le masque funéraire";
        map["Ponder the mask"] = "Examiner le masque d'un air songeur";
        map["Look at the masks"] = "Regarder les masques";
        map["Examine the cigar box"] = "Examiner la boîte de cigares";
        map["Check out the map"] = "Regarder la carte";
        map["Admire the painting"] = "Admirer le tableau";
        map["Survey the painting"] = "Observer le tableau";
        map["Examine the vinyl collection"] = "Examiner la collection de disques";
        map["Inspect the machine"] = "Inspecter la machine";
        map["Pine over the telescope"] = "Lorgner sur le télescope";
        map["An actual drinks globe!"] = "Un véritable meuble bar en globe terrestre !";
        map["It’s a roaring fire"] = "C'est un feu de cheminée crépitant";
        map["Ponder the bear rug"] = "Contempler la descente de lit en peau d'ours";
        map["Contemplate the painting"] = "Méditer devant le tableau";
        map["Inspect the painting"] = "Inspecter le tableau";
        map["Examine the painting"] = "Examiner le tableau";
        map["Read the clipping"] = "Lire la coupure de presse";
        map["Review the excerpt"] = "Examiner l'extrait de journal";
        map["Study the books"] = "Étudier les livres";
        map["Examine the bookends"] = "Examiner les serre-livres";
        map["It's a discarded statue"] = "C'est une statue abandonnée";
        map["Warm up near the boiler"] = "Se réchauffer près de la chaudière";
        map["Inspect the poison barrels"] = "Inspecter les barils de poison";
        map["Search the doctor's body"] = "Fouiller le corps du docteur";
        map["Look at the notes"] = "Regarder les notes";
        map["These look opulent!"] = "Cela m'a l'air bien somptueux !";
        map["Ponder the statue"] = "Observer la statue d'un œil songeur";
        map["Check out the globe"] = "Examiner le globe";
        map["It's a dusty looking telescope"] = "C'est un télescope qui prend la poussière";
        map["Peek into the box"] = "Jeter un œil dans la boîte";
        map["Check out the make-shift grave"] = "Observer la tombe de fortune";

        // UnterwaldSafeLocks / DrawerLedger / DianaPhoto / MansionSafeLocks / TestYardEngine
        map["dial"] = "cadran";
        map["voice lock"] = "verrou vocal";
        map["combination lock"] = "serrure à combinaison";
        map["Inspect the voice lock"] = "Inspecter le verrou vocal";
        map["Examine the combination lock"] = "Examiner la serrure à combinaison";
        map["Open the drawer"] = "Ouvrir le tiroir";
        map["accounting ledger"] = "grand livre de comptes";
        map["Take the accounting ledger"] = "Prendre le grand livre de comptes";
        map["Flip the photo"] = "Retourner la photo";
        map["strange lock"] = "serrure étrange";
        map["What is this thing?"] = "Qu'est-ce que c'est que ce truc ?";
        map["Take the rubber tubing"] = "Prendre le tuyau en caoutchouc";

        // Characters
        map["Arthur"] = "Arthur";
        map["Talk to Arthur"] = "Parler à Arthur";
        map["Speak to Diana"] = "Parler à Diana";
        map["Diana"] = "Diana";
        map["the fashionable woman"] = "la femme élégante";
        map["Speak to the fashionable woman"] = "Parler à la femme élégante";
        map["Herman"] = "Herman";
        map["Talk to Herman"] = "Parler à Herman";
        map["Lady Unterwald"] = "Lady Unterwald";
        map["Talk to Lady Unterwald"] = "Parler à Lady Unterwald";
        map["Lamont"] = "Lamont";
        map["Detective Lamont"] = "Inspecteur Lamont";
        map["Talk to Lamont"] = "Parler à Lamont";
        map["Bailey"] = "Bailey";
        map["Detective Bailey"] = "Inspecteur Bailey";
        map["Talk to Bailey"] = "Parler à Bailey";
        map["Elusive Hand"] = "Main Agile";
        map["the elusive hand"] = "la main agile";
        map["He's out cold"] = "Il est assommé";
        map["Bartender"] = "Barman";
        map["the bartender"] = "le barman";
        map["Get the bartender's attention"] = "Attirer l'attention du barman";
        map["Conductor"] = "Contrôleur";
        map["the conductor"] = "le contrôleur";
        map["Talk to the conductor"] = "Parler au contrôleur";
        map["Awful."] = "Affreux.";
        map["Guard"] = "Garde";
        map["the guard"] = "le garde";
        map["Talk to the guard"] = "Parler au garde";
        map["doctor"] = "docteur";
        map["Talk to the doctor"] = "Parler au docteur";
        map["Doctor Hirsch"] = "Docteur Hirsch";
        map["the man"] = "l'homme";
        map["Talk to the moustached gentleman"] = "Parler au monsieur moustachu";
        map["Talk to the annoyed gentleman"] = "Parler au monsieur irrité";
        map["annoyed gentleman"] = "monsieur irrité";
        map["Mr Masson"] = "M. Masson";
        map["the sleeping man"] = "l'homme qui dort";
        map["Wake the sleeping man"] = "Réveiller l'homme qui dort";
        map["Talk to Don"] = "Parler à Don";
        map["Don"] = "Don";
        map["You see, kid? It's that easy."] = "Tu vois, gamin ? C'est aussi simple que ça.";
        map["the slicked back man"] = "l'homme aux cheveux gominés";
        map["Talk to the uncouth slob"] = "Parler à l'individu grossier";
        map["Speak to Susanne"] = "Parler à Susanne";
        map["Susanne"] = "Susanne";
        map["the smoking woman"] = "la fumeuse";
        map["Introduce yourself"] = "Se présenter";
        map["Chat to the monocled gentleman"] = "Bavarder avec le monsieur au monocle";
        map["I think I broke him"] = "Je crois que je l'ai cassé";
        map["Arista"] = "Arista";
        map["the deaf lady"] = "la dame malentendante";
        map["Talk to the deaf lady"] = "Parler à la dame malentendante";
        map["Uhhh."] = "Euuuh.";
        map["Gunter"] = "Gunter";
        map["the twin"] = "le jumeau";
        map["Speak to the twin"] = "Parler au jumeau";
        map["Hagen"] = "Hagen";
        map["the other twin"] = "l'autre jumeau";
        map["Speak to the other twin"] = "Parler à l'autre jumeau";
        map["Waiter"] = "Serveur";
        map["the waiter"] = "le serveur";
        map["Talk to the waiter"] = "Parler au serveur";
        map["Pierre"] = "Pierre";
        map["the artist"] = "l'artiste";
        map["Talk to the artist"] = "Parler à l'artiste";
        map["Jimmy"] = "Jimmy";
        map["Talk to Jimmy"] = "Parler à Jimmy";
        map["It's not possible!"] = "Ce n'est pas possible !";
        map["Bravo !"] = "Bravo !";
        map["Bravo\u00A0!"] = "Bravo !";
        map["Chapeau !"] = "Chapeau !";
        map["Chapeau\u00A0!"] = "Chapeau !";
        map["Bien joué !"] = "Bien joué !";
        map["Bien joué\u00A0!"] = "Bien joué !";
        map["François"] = "François";
        map["the chef"] = "le chef cuisinier";
        map["Talk to the chef"] = "Parler au chef cuisinier";
        map["Remy"] = "Remy";
        map["Antoine"] = "Antoine";
        map["Talk to Ron"] = "Parler à Ron";
        map["Ron"] = "Ron";
        map["Do you need something?"] = "Vous avez besoin de quelque chose ?";
        map["the bar patron"] = "l'habitué du bar";
        map["Talk to the bar patron"] = "Parler à l'habitué du bar";
        map["Isaac"] = "Isaac";
        map["the chatting man"] = "l'homme qui discute";
        map["They look deep in conversation"] = "Ils ont l'air absorbés par leur conversation";
        map["Shelly"] = "Shelly";
        map["the chatting woman"] = "la femme qui discute";
        map["Belle"] = "Belle";
        map["the woman"] = "la femme";
        map["Eavesdrop on the conversation"] = "Écouter la conversation discrètement";
        map["He looks busy"] = "Il a l'air occupé";
        map["Casino Patron"] = "Cliente du casino";
        map["the casino patron"] = "la cliente du casino";
        map["Listen to the highrollers"] = "Écouter les flambeurs";
        map["Bouncer"] = "Videur";
        map["the bouncer"] = "le videur";
        map["Speak to the goon"] = "Parler au gorille";
        map["Talk to the bouncer"] = "Parler au videur";
        map["the band member"] = "le musicien";
        map["Guest"] = "Invité";
        map["the passenger"] = "le passager";
        map["Cashier"] = "Caissière";
        map["the cashier"] = "la caissière";

        Process(@"translations\partitions\engine_b2.tsv", @"translations\partitions\engine_b2_french.tsv", map);
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
                    Console.WriteLine("Missing in engine_b2: [" + en + "]");
                    fr = en;
                }

                sw.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}\t{4}", en, fr, de, srcFile, srcFunc));
            }
        }
        Console.WriteLine(string.Format("Processed {0}: {1} / {2} lines translated",
            Path.GetFileName(outPath), count, lines.Length - 1));
    }
}
