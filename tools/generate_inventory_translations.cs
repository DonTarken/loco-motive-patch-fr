using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class Program {
    static void Main() {
        var map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        // --- Unhandled & Rejection lines (Snappy P&C Barks) ---
        map["I can't use that."] = "Ça ne marchera jamais.";
        map["It's nothing interesting."] = "Rien qui vaille le coup d'œil.";
        map["Nothing happened."] = "Pas l'ombre d'un résultat.";
        map["Nah."] = "Pas question.";
        map["Nope."] = "Aucune chance.";
        map["That doesn't work."] = "Ça ne prend pas.";
        map["No."] = "Surtout pas.";
        map["I'm not handing over my ill-gotten gains without a reason!"] = "Hors de question de lâcher mon précieux butin sans une fichue bonne raison !";
        map["I think I'll hang on to this for now."] = "Je ferais mieux de garder ça sous le coude.";
        map["They wouldn't appreciate that."] = "Ils ne trouveraient pas ça très drôle.";
        map["I'd rather keep it."] = "Je préfère le garder bien au chaud.";
        map["What do you make of this?"] = "Qu'est-ce que tu penses de ça ?";
        map["I don't think it's going to get us closer to that train!"] = "Je doute que ça nous rapproche de ce train !";

        // --- Chapter Titles & Cards ---
        map["Adversary Proceeding"] = "Procédure contradictoire";
        map["The Late Lady Unterwald"] = "Feue Lady Unterwald";
        map["Burden of Proof"] = "La charge de la preuve";
        map["The Curious Case Of Mr Liu"] = "Le curieux cas de M. Liu";
        map["Contributory Negligence"] = "Négligence contributive";
        map["Family Division"] = "Affaires de famille";
        map["False Pretences"] = "Faux-semblants";
        map["Dispute Resolution"] = "Règlement du litige";
        map["Hold to Skip"] = "Maintenir pour passer";

        // --- Master Inventory Item Names from Glossary ---
        if (File.Exists(@"translations\glossary_items.tsv")) {
            var gLines = File.ReadAllLines(@"translations\glossary_items.tsv");
            for (int i = 1; i < gLines.Length; i++) {
                var p = gLines[i].Split('\t');
                if (p.Length >= 5) {
                    string enName = p[1].Trim();
                    string frName = p[2].Trim();
                    string useWith = p[3].Trim();
                    string lookAt = p[4].Trim();
                    if (!string.IsNullOrEmpty(enName) && !string.IsNullOrEmpty(frName)) {
                        map[enName] = frName;
                        map["the " + enName] = frName;
                        map["a " + enName] = frName;
                        map["an " + enName] = frName;
                        map["Use " + enName + " with"] = useWith;
                        map["Use " + enName + " with..."] = useWith + "...";
                        map["Look at " + enName] = lookAt;
                    }
                }
            }
        }

        // --- Inventory Items Dialogues ---
        // Accounting Records
        map["I'm sure we'd find a lot of creative accounting in here."] = "Je suis sûr qu'on trouverait pas mal de comptabilité créative là-dedans.";
        
        // Manuscripts
        map["It's a very thick manuscript. Typical overachiever."] = "C'est un manuscrit bien épais. Typique des perfectionnistes zélés.";
        map["It's the manuscript to my latest masterpiece."] = "C'est le manuscrit de mon tout dernier chef-d'œuvre.";
        map["Herman Merman and the Suburban Burden!"] = "Herman Merman et le Fardeau de Banlieue !";
        map["I'll slip my manuscript inside Dirk Chiselton's cover."] = "Je vais glisser mon manuscrit sous la couverture de Dirk Chiselton.";
        map["At first glance, this looks like a Dirk Chiselton manuscript!"] = "Au premier coup d'œil, on dirait un manuscrit de Dirk Chiselton !";
        map["Dirk Chiselton sent over a manuscript?"] = "Dirk Chiselton a envoyé un manuscrit ?";
        map["Sorry, Dirk, I need it more than you do."] = "Désolé, Dirk, j'en ai plus besoin que toi.";
        map["It's weighty. Could be 70,000 words by my estimate."] = "C'est lourd. 70 000 mots d'après mon estimation.";
        map["It’s the romance novel I retrieved from the bin."] = "C'est le roman à l'eau de rose que j'ai repêché dans la corbeille.";
        map["Perhaps I should have left it there."] = "J'aurais peut-être dû le laisser là-bas.";
        map["It’s the cover page I tore from Dirk Chiselton’s manuscript."] = "C'est la page de couverture que j'ai arrachée du manuscrit de Dirk Chiselton.";

        // Agent M (Mouse)
        map["Alright, Agent M. You'll be nice and snug inside this pod."] = "Très bien, Agent M. Tu seras bien au chaud dans cette capsule.";
        map["She's the cutest little agent, ever!"] = "C'est la plus mignonne petite agente de tous les temps !";
        map["I wonder who trained her to be such a kleptomaniac?"] = "Je me demande bien qui l'a dressée à devenir une telle kleptomane ?";
        map["Are you alright in there, little one?"] = "Tout va bien là-dedans, ma petite ?";
        map["She ate all my pocket cheese!"] = "Elle a mangé tout mon fromage de poche !";

        // Anklet Key & Chains (Prologue)
        map["It's the key I used to get out of my chains!"] = "C'est la clé que j'ai utilisée pour me libérer des fers !";
        map["This looks like it might unlock a set of chains."] = "On dirait que ça pourrait ouvrir des fers.";
        map["It's a small key, but I have no idea what it unlocks."] = "C'est une petite clé, mais je n'ai aucune idée de ce qu'elle ouvre.";
        map["This key might unlock those chains!"] = "Cette clé pourrait bien ouvrir ces fers !";
        map["It's an anklet key, primarily used for locking prison chains."] = "C'est une clé de cheville, servant surtout à verrouiller les chaînes de prisonniers.";
        map["It's a set of heavy-duty chains!"] = "C'est un ensemble de fers bien solides !";
        map["It's a heavy-duty set of prison chains!"] = "C'est un jeu de chaînes de prisonnier ultra résistant !";
        map["It's a pile of heavy chains."] = "C'est un tas de lourdes chaînes.";

        // Antidote
        map["Hmm. This syringe has a label marked ‘Antidote'."] = "Hmm. Cette seringue porte une étiquette indiquant « Antidote ».";
        map["It's the antidote I used to revive Dr Hirsch!"] = "C'est l'antidote que j'ai utilisé pour ranimer le Dr Hirsch !";

        // Sketches
        map["I can see the various handshakes in the background of these sketches!"] = "On aperçoit les différentes poignées de main en arrière-plan de ces croquis !";
        map["I'll still need some help to figure out the correct order."] = "J'aurai quand même besoin d'aide pour trouver le bon ordre.";
        map["Perhaps you'd settle for a simple fist bump?"] = "Peut-être qu'un simple check du poing vous conviendrait ?";
        map["If you think I'm still sleeping, you should give me a shake!"] = "Si vous me croyez encore endormi, venez donc me secouer !";
        map["I assure you, these palms, they have a strong grip!"] = "Je vous garantis que ces paumes ont une poigne de fer !";
        map["I've watched your dance of digits, and I handedly approve."] = "J'ai observé votre ballet de phalanges, et j'approuve haut la main !";

        // Cash & Bag
        map["I'm sure I can put Don's winnings to better use."] = "Je suis convaincu que je peux faire un meilleur usage des gains de Don.";

        // Recording & Audio
        map["I'm sure Bergmann will choose his words more carefully in future."] = "Je suis sûr que Bergmann pèsera mieux ses mots à l'avenir.";
        map["Hey, it fits!"] = "Eh, ça rentre parfaitement !";
        map["Nice, that looks like it's worked."] = "Chouette, on dirait que ça a fonctionné.";
        map["Aha, a perfect fit!"] = "Aha, ça s'emboîte à merveille !";
        map["It's just the right size, that was lucky."] = "C'est pile à la bonne taille, quelle chance.";
        map["I don't want to risk recording over Bergmann's reel."] = "Je ne veux pas risquer d'enregistrer par-dessus la bande de Bergmann.";
        map["I'll need another wire reel to record anything new."] = "J'aurai besoin d'une autre bobine de fil pour enregistrer du nouveau contenu.";
        map["It's Don's recording device. It's not much use to me without another wire reel, though."] = "C'est l'enregistreur de Don. Mais il ne m'est pas d'une grande utilité sans une autre bobine de fil.";
        map["We could record something with this if we found another wire reel."] = "On pourrait enregistrer quelque chose avec ça si on trouvait une autre bobine.";
        map["This portable recording device could be useful if it wasn't empty."] = "Cet enregistreur portatif pourrait être utile s'il n'était pas vide.";
        map["Donny was using this device to record Bergmann!"] = "Donny utilisait cet appareil pour enregistrer Bergmann !";
        map["It's loaded up with a fresh wire reel, ready for recording."] = "Il est chargé avec une bobine de fil neuve, prêt à enregistrer.";
        map["I should get one of these to take notes on the fly."] = "Je devrais m'en procurer un pour prendre des notes à la volée.";
        map["It's not as discreet as a phone tap, but it gets the job done."] = "Ce n'est pas aussi discret qu'une écoute téléphonique, mais ça fait le travail.";
        map["I can put this wire reel into a recording device to record something."] = "Je peux insérer cette bobine de fil dans un enregistreur pour enregistrer du son.";
        map["It's an empty wire reel, handy if I need to record something."] = "C'est une bobine de fil vide, pratique si j'ai besoin d'enregistrer.";
        map["Lord Unterwald planned to use this to document his astronomical observations."] = "Lord Unterwald prévoyait d'utiliser ceci pour documenter ses observations astronomiques.";
        map["It's a little dusty, but I'm sure it would still record audio."] = "C'est un peu poussiéreux, mais je suis certain que ça enregistre encore.";
        map["Lady Unterwald recorded her own album of songs!"] = "Lady Unterwald a enregistré son propre album de chansons !";
        map["It's Lady Unterwald's voice, from beyond the grave!"] = "C'est la voix de Lady Unterwald, d'outre-tombe !";
        map["Thank you for calling the Reuss Express onboard service."] = "Merci d'avoir contacté le service de bord du Reuss Express.";
        map["This call may be recorded for training purposes."] = "Cet appel peut être enregistré à des fins de formation.";

        // Cheese & Food
        map["This pocket cheese should be useful, and not just for snacking purposes!"] = "Ce fromage de poche devrait s'avérer utile, et pas seulement pour le grignotage !";
        map["Just one of these peppers would make any dish unbearably hot."] = "Un seul de ces piments rendrait n'importe quel plat atrocement brûlant.";
        map["It's a harmless lemon."] = "C'est un citron tout à fait inoffensif.";
        map["I've concocted the world's spiciest soup."] = "J'ai concocté la soupe la plus épicée du monde.";
        map["It's all of the sugar, and none of the fun!"] = "Tout le sucre, et aucun plaisir !";

        // Suit & Clothes
        map["It's the blue suit jacket that Mr Liu was wearing."] = "C'est la veste de costume bleue que portait M. Liu.";
        map["It's a pair of Lady Unterwald's boots. We happen to have the same shoe size!"] = "C'est une paire de bottes de Lady Unterwald. Il se trouve qu'on fait la même pointure !";
        map["I think I might be onto something here!"] = "Je crois que je tiens une piste intéressante !";
        map["Herman Merman, you've done it again! I should be able to get on the roof with these."] = "Herman Merman, tu as encore frappé ! Je devrais pouvoir monter sur le toit avec ça.";
        map["I've successfully attached a suction cup to one of the boots."] = "J'ai réussi à fixer une ventouse sur l'une des bottes.";
        map["I've assembled a working pair of suction boots!"] = "J'ai assemblé une paire de bottes à ventouses fonctionnelle !";
        map["A classic wooden hanger. The second best kind of hanger, in my opinion!"] = "Un cintre en bois classique. Le deuxième meilleur type de cintre, à mon humble avis !";
        map["Versatile, flexible, durable. The best kind of hanger!"] = "Polyvalent, souple, résistant. Le meilleur type de cintre qui soit !";
        map["That drawer put up a fight, but the hanger still has some life left in it."] = "Ce tiroir ne s'est pas laissé faire, mais le cintre a encore de beaux restes.";

        // Beer, Drinks, Liquids
        map["A bit of experimentation might give this Bud-Lite a bigger kick."] = "Une petite expérimentation pourrait donner un peu plus de piquant à cette Bud-Lite.";
        map["It's already full."] = "C'est déjà plein.";
        map["Now that it's sealed, it makes a pretty cool, if not gross, container!"] = "Maintenant que c'est scellé, ça fait un récipient plutôt chouette, quoique un peu répugnant !";
        map["It's a ''FULL-STOP'' brand recorker. ''The last word in cork plugging.''"] = "C'est un reboucheur de marque « FULL-STOP ». « Le fin mot du bouchonnage. »";
        map["The water and sawdust have combined into a thick, sticky paste."] = "L'eau et la sciure se sont amalgamées en une pâte épaisse et collante.";
        map["I'm not quite sure what this is, but the bottle is neat!"] = "Je ne sais pas trop ce que c'est, mais la bouteille a fière allure !";
        map["It's a vial of enigmatic liquid, I can hear it gently fizzing in my suit jacket pocket."] = "C'est une fiole de liquide énigmatique, je l'entends pétiller doucement dans ma poche.";
        map["I doubt the truth spray is potent enough, but I love the bottle!"] = "Je doute que ce spray de vérité soit assez puissant, mais j'adore le flacon !";
        map["This stuff worked wonders on Bergmann, it just needs a little kick-start to get going."] = "Ce produit a fait des merveilles sur Bergmann, il lui faut juste un petit coup de fouet pour démarrer.";
        map["It's sloshing about with precious fuel!"] = "Il déborde d'un précieux carburant !";
        map["It's empty! That's not much use to me."] = "C'est vide ! Ça ne m'est pas d'une grande utilité.";
        map["I've filled the cup with plenty of drinking water."] = "J'ai rempli le gobelet avec une bonne rasade d'eau potable.";
        map["I'll mix some of this fuel with the gunpowder."] = "Je vais mélanger un peu de ce carburant avec la poudre à canon.";
        map["It's an overpowering blend of cheap perfume, plant life and ethanol!"] = "C'est un mélange foudroyant de parfum bon marché, de sève végétale et d'éthanol !";
        map["It's full of minty fresh mouthwash!"] = "C'est rempli d'un bain de bouche à la menthe bien fraîche !";
        map["I've poured the Bud-Lite in here, but for a stronger kick, I'll need to add a potent alcoholic mixer."] = "J'ai versé la Bud-Lite ici, mais pour un effet plus corsé, il faudra ajouter un mélange alcoolisé bien puissant.";
        map["It's a dangerous concoction of fuel and high octane explosives!"] = "C'est une concoction périlleuse de carburant et d'explosifs à haut indice d'octane !";
        map["The liquid would pour straight through."] = "Le liquide coulerait directement à travers.";
        map["I'm sure there's a good reason why I'd need an old lady's hearing aid."] = "Je suis sûr qu'il y a une excellente raison pour laquelle j'aurais besoin du cornet acoustique d'une vieille dame.";
        map["Although, I can't think of one just yet."] = "Bien que je n'en voie pas encore la raison.";
        map["It’s the horn that Arista instructed me to repair."] = "C'est le cornet qu'Arista m'a demandé de réparer.";
        map["''Rinse after brushing. Contains alcohol, do not ingest solution.''"] = "« Rincer après brossage. Contient de l'alcool, ne pas avaler la solution. »";
        map["I've soaked the napkin in turpentine."] = "J'ai imbibé la serviette de térébenthine.";
        map["It's a powerful cleaning solvent. This stuff would remove pretty much anything!"] = "C'est un solvant de nettoyage très puissant. Ça dissoudrait quasiment n'importe quoi !";

        // Fan & Funnel (Prologue)
        map["Huh, I guess this model is battery powered."] = "Tiens, j'imagine que ce modèle fonctionne sur piles.";
        map["This should make the desk fan significantly more powerful."] = "Ça devrait rendre ce ventilateur de bureau nettement plus puissant.";

        // Newspaper (Prologue)
        map["''IT'S THE END OF THE LINE''"] = "« C'EST LE TERMINUS »";
        map["''The Unterwald empire came to a grisly end last night, when the wealthy heiress was unexpectedly assassinated aboard her own train.''"] = "« L'empire Unterwald a connu une fin tragique hier soir, lorsque la richissime héritière a été assassinée à bord de son propre train. »";
        map["''Three suspects are currently held in custody, awaiting questioning.''"] = "« Trois suspects sont actuellement placés en garde à vue dans l'attente de leur interrogatoire. »";

        // Umbrella (Prologue)
        map["It's bad luck to open an umbrella indoors, but maybe I can find a use for it."] = "Ouvrir un parapluie à l'intérieur porte malheur, mais je pourrais peut-être lui trouver une utilité.";

        // Coffee (Prologue)
        map["It's a steaming hot cup of coffee. It kind of burns!"] = "C'est une tasse de café brûlant. Ça pique un peu les doigts !";
        map["I sshould shpeak to Mr Masson first."] = "Je devrrrais d'aborrrd parler à M. Masson.";

        // Letters & Documents
        map["Lady Unterwald asked me to deliver this to Arthur Ackerman!"] = "Lady Unterwald m'a demandé de remettre ceci à Arthur Ackerman !";
        map["It's the last correspondence I received from Lady Unterwald."] = "C'est la dernière correspondance que j'ai reçue de Lady Unterwald.";
        map["It's a letter from Lady Unterwald, asking me to wear the suit she provided."] = "C'est une lettre de Lady Unterwald, me demandant de porter le costume qu'elle a fourni.";
        map["It's a letter from Lady Unterwald, she'd like to meet in her quarters."] = "C'est une lettre de Lady Unterwald, elle souhaite me rencontrer dans ses quartiers.";
        map["I'm supposed to deliver this letter to Mr Ackerman."] = "Je suis censé remettre cette lettre à M. Ackerman.";
        map["It's an excellent forgery, Donny did a great job!"] = "C'est un faux remarquable, Donny a fait du beau travail !";
        map["I was sure Diana wrote something on this napkin, but it's blank!"] = "J'étais sûr que Diana avait écrit quelque chose sur cette serviette, mais elle est vierge !";
        map["I think there's something here but it's not quite legible."] = "Je crois qu'il y a quelque chose ici, mais ce n'est pas très lisible.";
        map["It's the napkin that I grabbed from the bar."] = "C'est la serviette que j'ai attrapée au bar.";
        map["It's a signed business card from Beverly Moore."] = "C'est une carte de visite signée de Beverly Moore.";
        map["''Moore Or Less - Talent agency to the adequate.''"] = "« Moore ou Moins - L'agence de talents pour les passables. »";
        map["The heat revealed the number 306. How mysterious!"] = "La chaleur a fait apparaître le numéro 306. Quel mystère !";
        map["It's Donny's recipe for a powerful drink."] = "C'est la recette de Donny pour un cocktail particulièrement costaud.";

        // Keys & Locks
        map["Looks like Don booked the honeymoon suite. Room 303!"] = "On dirait que Don a réservé la suite nuptiale. Cabine 303 !";
        map["These must be Herman's keys, Room 304."] = "Ce doivent être les clés d'Herman, cabine 304.";
        map["My own private quarters, room 304."] = "Mes quartiers personnels, cabine 304.";
        map["It's a toy set lock pick. Likely effective against only the weakest of locks."] = "C'est un rossignol de dînette pour enfant. Utile uniquement contre les serrures les plus dérisoires.";
        map["My memory of getting these keys is a little fuzzy."] = "Le souvenir de la façon dont j'ai obtenu ces clés est un peu flou.";

        // Wax & Seals
        map["I think this hardened blob was Lady Unterwald's wax seal."] = "Je pense que ce pâté durci était le sceau en cire de Lady Unterwald.";
        map["The wax has cooled down and hardened."] = "La cire a refroidi et a durci.";
        map["It's a hardened ball of wax."] = "C'est une boule de cire durcie.";
        map["Ooh, that's hot!"] = "Ouh, c'est chaud !";
        map["The wax must have melted from the heat. It looks malleable!"] = "La cire a dû fondre sous l'effet de la chaleur. Elle a l'air malléable !";
        map["It's a wax impression of a fingerprint."] = "C'est une empreinte digitale moulée dans la cire.";
        map["It's a wax impression of Lady Unterwald's fingerprint."] = "C'est l'empreinte digitale de Lady Unterwald moulée dans la cire.";
        map["It's a fingerprint impression made from wax."] = "C'est un moulage d'empreinte digitale en cire.";
        map["It's a wax seal from the Unterwald estate."] = "C'est un sceau de cire du domaine Unterwald.";
        map["This is the last wax seal I'll receive from Lady Unterwald."] = "C'est le tout dernier sceau de cire que je recevrai de Lady Unterwald.";
        map["This seal has been on quite the adventure, eh? I feel strangely attached to it."] = "Ce sceau a vécu une sacrée aventure, hein ? Je m'y sens étrangement attaché.";
        map["It's one of Lady Unterwald's wax seals, malleable and quite soft to the touch."] = "C'est l'un des sceaux de cire de Lady Unterwald, malléable et doux au toucher.";
        map["It's a wax seal, embossed with the emblem of the Wald-Bahn empire."] = "C'est un sceau de cire frappé de l'emblème de l'empire Wald-Bahn.";

        // Tools, Plungers, Canes
        map["It's a kitchen plunger, great for unblocking clogged sinks!"] = "C'est une ventouse de cuisine, idéale pour déboucher les éviers obstrués !";
        map["Probably best not to dwell on the horrors this plunger has seen."] = "Il vaut sans doute mieux ne pas imaginer les horreurs que cette ventouse a traversées.";
        map["It's an odd looking plunger."] = "C'est une ventouse à l'allure étrange.";
        map["It's my trusty prison cell plunger!"] = "C'est ma fidèle ventouse de cellule de prison !";
        map["It's a plunger made from a rusty metal pole."] = "C'est une ventouse bricolée à partir d'une barre de fer rouillée.";
        map["It's the suction cup from a plunger!"] = "C'est la ventouse d'adhérence !";
        map["It's the business end of a plunger."] = "C'est la partie active d'une ventouse.";
        map["It looks like a suction cup to me."] = "On dirait bien une ventouse d'adhérence.";
        map["I'd like to think Lady Unterwald would want me to have this."] = "J'aime à penser que Lady Unterwald aurait souhaité que je l'aie.";
        map["Looks like a rusty metal pole."] = "On dirait une barre de fer rouillée.";
        map["It seems to be some sort of metal pole."] = "Ça ressemble à une sorte de tige en métal.";
        map["A rusty metal pole might be useful in our current circumstances."] = "Une barre en fer rouillée pourrait bien nous être utile dans notre situation.";
        map["It's the rubber tubing I cut from the car."] = "C'est la tubulure en caoutchouc que j'ai découpée sur la voiture.";
        map["It's an official field agent wiring kit!"] = "C'est un kit de câblage officiel d'agent de terrain !";
        map["It's a ''Mega-Stich'' brand heavy duty stapler. This thing can staple through 250 sheets!"] = "C'est une agrafeuse industrielle de marque « Mega-Stitch ». Cet engin peut traverser 250 feuilles d'un coup !";

        // Badges & Photos
        map["For a toy badge, it's quite convincing."] = "Pour un faux insigne, il fait plutôt illusion.";
        map["It's a toy badge, but it should still provide an air of authority."] = "C'est un insigne factice, mais il devrait quand même m'octroyer un brin d'autorité.";
        map["Jian Liu had this in his pocket."] = "Jian Liu avait ça dans sa poche.";
        map["It's a genuine pearl necklace."] = "C'est un authentique collier de perles.";
        map["The craftsmanship of this fountain pen is exquisite!"] = "La confection de ce stylo-plume est tout bonnement exquise !";
        map["It looks harmless enough."] = "Ça a l'air bien inoffensif.";
        map["I can break the tip off this incendiary pencil, to retrieve the gunpowder inside."] = "Je peux casser la mine de ce crayon incendiaire pour en extraire la poudre à canon.";
        map["I should use the one I took before taking another."] = "Je devrais utiliser celui que j'ai pris avant d'en piquer un autre.";
        map["It's a case of explosives, disguised as harmless stationary."] = "C'est un étui d'explosifs déguisé en fournitures de bureau inoffensives.";
        map["It'll cost a fortune to get the smell of cheap perfume out of this jacket."] = "Ça va me coûter une petite fortune pour chasser cette odeur de parfum bon marché de ma veste.";
        map["They smell quite fragrant!"] = "Elles sentent drôlement bon !";

        // Dolls & Toys & Knives
        map["The doll's looking a little scrawny without all that packing sawdust."] = "La poupée a l'air un peu rabougrie sans toute cette sciure de rembourrage.";
        map["This looks very familiar."] = "Ça me rappelle furieusement quelque chose.";
        map["You can withstand the heat with a pair of these oven gloves!"] = "On peut résister à n'importe quelle chaleur avec cette paire de maniques !";
        map["Popcorn isn't just delicious, it doubles as a cheap packing material."] = "Le popcorn n'est pas seulement délicieux, il sert aussi de calage économique.";
        map["It's a paper cup I swiped from the water cooler."] = "C'est un gobelet en carton que j'ai chipé à la fontaine d'eau.";
        map["I placed sawdust in the bottom of the cup."] = "J'ai mis de la sciure au fond du gobelet.";
        map["It's a pile of sawdust I removed from the doll."] = "C'est un tas de sciure que j'ai retiré de la poupée.";
        map["It looks like Don's been practicing poetry."] = "On dirait que Don s'est mis à la poésie.";
        map["There's no way I'm reading that."] = "Hors de question que je lise ça.";
        map["I'm a little too familiar with how sharp this blade is."] = "Je ne connais que trop bien le tranchant affûté de cette lame.";
        map["Now, this is an exciting piece of high-end stationary!"] = "Voilà un superbe accessoire de papeterie haut de gamme !";
        map["This letter opener looks like it'd slice through more than paper."] = "Ce coupe-papier a l'air de pouvoir trancher bien plus que de la simple papeterie.";
        map["I wouldn't trust either of those two with something this sharp."] = "Je ne ferais confiance à aucun de ces deux-là avec un objet aussi coupant.";
        map["The blade is sufficiently lubricated, and rather hard to handle."] = "La lame est abondamment lubrifiée, et plutôt difficile à manier.";
        map["This would surely lubricate anything it touches."] = "Ça lubrifierait à coup sûr n'importe quoi au moindre contact.";
        map["Half a slab of unsalted butter. I think it's slowly melting in my pocket."] = "Une demi-plaquette de beurre doux. J'ai l'impression qu'elle fond lentement dans ma poche.";
        map["It's a highly moisturising hand repair cream. For dry, cracked and injured hands."] = "C'est une crème pour les mains réparatrice et très hydratante. Pour peaux sèches, gercées et abîmées.";

        // Magnets & Roulettes
        map["Owning a magnet this large has its positives and negatives."] = "Posséder un aimant de cette taille a ses côtés positifs et négatifs.";
        map["Don could move this up to three spaces with his watch."] = "Don pouvait déplacer ça jusqu'à trois cases grâce à sa montre.";
        map["That's the magnetic ball Donny used to rig his roulette games!"] = "C'est la bille magnétique que Donny utilisait pour truquer ses parties de roulette !";
        map["It looks like a roulette ball from the casino."] = "On dirait une bille de roulette provenant du casino.";
        map["That's odd, what's a roulette ball doing here?"] = "Étrange, que fait une bille de roulette ici ?";
        map["Hmm, the magnification is very strong!"] = "Hmm, le grossissement est particulièrement puissant !";
        map["I'm rich! Although, are these chips even real?"] = "Je suis riche ! Enfin, ces jetons sont-ils seulement authentiques ?";
        map["It's an idol, no doubt modelled after Lady Unterwald's own hand!"] = "C'est une idole, sans nul doute sculptée d'après la propre main de Lady Unterwald !";
        map["These little pods transport items throughout the whole tube system!"] = "Ces petites capsules transportent des objets à travers tout le réseau pneumatique !";
        map["It's explosive powder I cut from the pencil!"] = "C'est de la poudre explosive que j'ai extraite du crayon !";
        map["It's Dr Phogg's Guide to Invis-Ability!"] = "C'est le Guide de l'Invis-Abilité du Dr Phogg !";
        map["''Apply gentle heat to the paper to reveal messages written in invisible ink.''"] = "« Appliquer une chaleur douce sur le papier pour faire apparaître les messages à l'encre invisible. »";
        map["''Avoid using candles, matches, or any open flames, they might just send your message up in smoke.''"] = "« Éviter les bougies, allumettes ou flammes nues qui réduiraient votre message en cendres. »";
        map["Hmm, maybe I can find what I'm looking for in the kitchen?"] = "Hmm, peut-être trouverai-je ce que je cherche en cuisine ?";

        // Write output TSV
        using (var sw = new StreamWriter(@"translations\dialogues\inventory_french.tsv", false, Encoding.UTF8)) {
            sw.WriteLine("Id\tCharacter\tEnglish\tFrench\tClass\tMethod");
            int id = 9000;
            foreach (var kvp in map) {
                sw.WriteLine(id++ + "\tArthur\t" + kvp.Key + "\t" + kvp.Value + "\tInventory\tOnLookAtInventory");
            }
        }
        Console.WriteLine("Generated inventory_french.tsv with " + map.Count + " entries.");
    }
}
