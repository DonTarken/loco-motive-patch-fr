using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class BuildC2B3 {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\partitions\c2_b3_interrogations.tsv");
        var map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        // --- Arista & The Twins ---
        map["You have to help me! My boys are lost in the ventilation system!"] = "Vous devez m'aider ! Mes garçons sont égarés dans les conduits d'aération !";
        map["I could direct them back with my horn, but I'd need some sort of mouthpiece!"] = "Je pourrais les guider avec mon cornet, mais il me faudrait un embout !";
        map["Doesn't that thing go in your ear?"] = "Cet engin n'est-il pas censé aller dans votre oreille ?";
        map["Hurry! My boys have no sense of direction!"] = "Faites vite ! Mes garçons n'ont aucun sens de l'orientation !";
        map["Have you repaired my horn yet?"] = "Avez-vous enfin réparé mon cornet ?";
        map["Oi you! What's going on in there?"] = "Hé, vous là-bas ! Que se passe-t-il là-dedans ?";
        map["There was a mishap with the ventilation system, but it's all fine now!"] = "Il y a eu un léger incident dans la ventilation, mais tout est rentré dans l'ordre !";
        map["Now, if you'll excuse me..."] = "À présent, si vous voulez bien m'excuser...";
        map["What a wonderful coat. You know, my sister had one just like it!"] = "Quel manteau ravissant. Vous savez, ma sœur avait exactement le même !";
        map["Oh my! It sounds like she had exquisite taste."] = "Bonté divine ! On dirait qu'elle avait un goût exquis.";
        map["Indeed."] = "En effet.";
        map["Did they stop talking? I can't hear them!"] = "Ils ont arrêté de parler ? Je n'entends plus rien !";
        map["Why are you so heavy?"] = "Pourquoi es-tu aussi lourd ?";
        map["I can't hear what's going on with you two yapping!"] = "Je n'entends rien avec vos piaillements continuels !";
        map["I'm not sure I can hold on much longer!"] = "Je ne sais pas si je vais tenir plus longtemps !";
        map["What are they saying, mummy?"] = "Qu'est-ce qu'ils racontent, maman ?";
        map["I'm slipping!"] = "Je glisse !";
        map["Steady yourselves!"] = "Tenez-vous bien !";
        map["You're gonna drop me!"] = "Tu vas me faire tomber !";
        map["Steady!"] = "Du calme !";
        map["I don't believe we've had the privilege?"] = "Je ne crois pas que nous ayons eu le privilège des présentations ?";
        map["Lady Arista Gudrun, a pleasure to meet you."] = "Lady Arista Gudrun, enchantée de faire votre connaissance.";
        map["And these are my boys..."] = "Et voici mes chers fils...";
        map["Hagen Gudrun, a pleasure to meet you!"] = "Hagen Gudrun, tout le plaisir est pour moi !";
        map["That's not right, you blithering idiot."] = "Mais non, triple buse !";
        map["It's not?"] = "Ah bon ?";
        map["You're Gunter, and he's Hagen!"] = "Toi tu es Gunter, et lui c'est Hagen !";
        map["Since when?!"] = "Depuis quand ?!";
        map["I can't believe you'd steal my name, you fish-eyed freak!"] = "Je rêve ! Tu voles mon prénom, face de mérou !";
        map["Spineless weasel!"] = "Espèce de mollusque sans vertèbres !";
        map["Bootless haggard!"] = "Sombre débris avarié !";
        map["Tottering codpiece!"] = "Vieille braguette vacillante !";
        map["Oh, now you've gone and done it! I've broken the mouthpiece."] = "Oh, voilà ce qui arrive ! Vous m'avez fait casser l'embout !";
        map["I'm confused, who are you again?"] = "Je suis un peu perdu, qui êtes-vous déjà ?";
        map["Gunter Gudrun, Underground Operational Executive."] = "Gunter Gudrun, Directeur Exécutif des Opérations Souterraines.";
        map["Hagen Gudrun, Overground Operational Executive."] = "Hagen Gudrun, Directeur Exécutif des Opérations Terrestres.";
        map["Why does his title get to be longer?"] = "Pourquoi son titre est plus long que le mien ?";
        map["Quiet!"] = "Silence !";

        // --- Herman & Rosebud & Waiter ---
        map["Mr Liu?"] = "M. Liu ?";
        map["I suspect the Rosebud could put an elephant to sleep."] = "J'ai bien peur que ce Rosebud puisse endormir un éléphant.";
        map["I shouldn't inflict further torment upon the man, unless absolutely necessary."] = "Je ne devrais pas lui infliger d'autres supplices, sauf en cas d'absolue nécessité.";
        map["May I get you something to drink?"] = "Puis-je vous servir quelque chose à boire ?";
        map["No, that won't be necessary."] = "Non, ce ne sera pas nécessaire.";
        map["Then perhaps I can interest you in some appetisers, while you decide?"] = "Peut-être puis-je vous tenter avec des amuse-bouches le temps de choisir ?";
        map["No, I'm not interested in mediocrity."] = "Non, la médiocrité ne m'intéresse pas.";
        map["A main dish, then? Our soup of the day comes highly recommended."] = "Un plat principal alors ? Notre potage du jour est chaudement recommandé.";
        map["Soup? Do I look like someone who would be caught dead ordering soup?"] = "De la soupe ? Ai-je l'air de quelqu'un qui se commettrait à commander de la soupe ?";
        map["That's just idiotic, if you'll forgive me for saying so."] = "C'est purement grotesque, si vous me passez l'expression.";
        map["These dishes are so mundane. Uninspired, don't you think?"] = "Ces mets sont si banals. Dénués d'inspiration, vous ne trouvez pas ?";
        map["Do you have anything that actually requires skill and creativity to prepare?"] = "Avez-vous un plat dont la préparation requiert un minimum de talent et de créativité ?";
        map["If you'll allow me to check with the kitchen, I'll see if they can prepare something to your liking?"] = "Si vous me permettez de voir en cuisine, je m'assurerai qu'ils préparent quelque chose à votre goût ?";
        map["Yes, always."] = "Oui, comme toujours.";
        map["Yes? What is it you want?"] = "Oui ? Que me voulez-vous ?";

        // --- Pierre the Artist ---
        map["Are you waiting for someone?"] = "Vous attendez quelqu'un ?";
        map["What does it look like I'm doing, detective?"] = "À quoi ai-je l'air d'être occupé, détective ?";
        map["Loitering?"] = "À faire les cent pas ?";
        map["I'm waiting on the shoe shine girl."] = "J'attends la jeune cireuse de chaussures.";
        map["Shoe shine girl?"] = "La cireuse de chaussures ?";
        map["Oui, I need to look my best for Lady Unterwald this evening."] = "Oui, je me dois d'être sur mon trente-et-un pour Lady Unterwald ce soir.";
        map["Alas, that girl is far too preoccupied with her toys right now."] = "Hélas, cette enfant est bien trop absorbée par ses jouets pour l'instant.";
        map["The shoe shine girl is too preoccupied with her toy set?"] = "La cireuse est trop absorbée par sa dînette ?";
        map["Do you currently observe my shoes being shined?"] = "Voyez-vous mes souliers en train d'être lustrés à l'heure qu'il est ?";
        map["Then you have your answer, detective!"] = "Alors vous avez votre réponse, détective !";
        map["How could a paying customer possibly compete with the Dirk Chiselton Deducing Kit?"] = "Comment un client fortuné pourrait-il rivaliser avec la Mallette de Déduction Dirk Chiselton ?";
        map["What's this about a Dirk Chiselton Deducing Kit?"] = "Qu'est-ce que c'est que cette Mallette de Déduction Dirk Chiselton ?";
        map["All I know is it's currently preventing me from getting my shoes polished."] = "Tout ce que je sais, c'est qu'elle m'empêche d'avoir des chaussures impeccables.";
        map["Blast! My publishers assured me the Dirk line was still in the prototyping phase."] = "Malédiction ! Mes éditeurs m'avaient juré que la gamme Dirk n'était qu'en phase de prototype.";
        map["Oui, I was waiting for the shoe shine girl to finish her break."] = "Oui, j'attendais que la cireuse termine sa pause.";
        map["Since you gave her that manuscript, she hasn't looked up once!"] = "Depuis que vous lui avez refilé ce manuscrit, elle n'a pas levé le nez de la page !";
        map["Still waiting to get those shoes shined?"] = "Toujours en train d'attendre votre cirage de chaussures ?";
        map["Oh, I'm still waiting, monsieur."] = "Oh oui, j'attends toujours, monsieur.";
        map["Something tells me you're some sort of artist."] = "Quelque chose me dit que vous êtes une sorte d'artiste.";
        map["Tell me, what gave it away?"] = "Dites-moi, qu'est-ce qui m'a trahi ?";
        map["The assorted paints and paintbrushes?"] = "L'assortiment de tubes de gouache et de pinceaux ?";
        map["My paint stained overalls?"] = "Ma salopette maculée de peinture multicolore ?";
        map["It was the beret, wasn't it?"] = "C'était le béret, n'est-ce pas ?";
        map["Ah, I'm afraid a detective never reveals their secrets."] = "Ah, un grand détective ne livre jamais ses secrets.";
        map["That's magicians, isn't it?"] = "Ça, c'est les magiciens, non ?";
        map["It can be two things!"] = "Ça peut être les deux à la fois !";
        map["How's business in the art world?"] = "Comment vont les affaires dans le monde des arts ?";
        map["Lady Unterwald has been kind enough to provide me with a steady stream of work."] = "Lady Unterwald a eu l'amabilité de m'assurer un flot ininterrompu de commandes.";
        map["As it happens, I'm preparing to capture her portrait this very evening!"] = "Justement, je m'apprête à peindre son portrait ce soir même !";
        map["You're on the Unterwald payroll?"] = "Vous êtes salarié d'Unterwald ?";
        map["I wish! Every artist would jump at the chance for a steady paycheque!"] = "Si seulement ! Tout artiste donnerait un bras pour un chèque de paie régulier !";
        map["Alas, our agreement is more... commissions based."] = "Hélas, notre accord fonctionne plutôt... à la commande.";
        map["Do you have a preferred artistic medium?"] = "Avez-vous un support de prédilection ?";
        map["I prefer the canvas, but these hands have also sculpted many things."] = "Je préfère la toile, mais ces mains ont également sculpté bien des merveilles.";
        map["If you take the time to look around, you'll find many of my pieces aboard this train."] = "En ouvrant l'œil, vous remarquerez un grand nombre de mes créations à bord de ce train.";
        map["Of course, I'm not always at liberty to discuss them."] = "Évidemment, je ne suis pas toujours en mesure d'en divulguer les détails.";
        map["Are you enjoying the band?"] = "Vous appréciez l'orchestre ?";
        map["You know, they painstakingly arrange their songs for their live shows?"] = "Saviez-vous qu'ils arrangent méticuleusement chacun de leurs morceaux pour leurs concerts ?";
        map["That's certainly intriguing."] = "C'est tout à fait fascinant.";
        map["No, that kind of dedication to the performance?"] = "Non, un tel dévouement à la scène ?";
        map["It's art!"] = "C'est de l'art à l'état pur !";
        map["What happened to Balboa Swing?"] = "Qu'est-il arrivé à Balboa Swing ?";
        map["I've never seen them walk off the stage during a set before."] = "Je ne les avais jamais vus quitter la scène au beau milieu d'un morceau.";
        map["Balboa Swing strives for perfection, something must have thrown them off."] = "Balboa Swing vise la perfection absolue. Quelque chose a dû les perturber.";
        map["I have to go now."] = "Je dois filer maintenant.";

        // --- Jian Liu ---
        map["I'm afraid the whereabouts of this idol eludes me; I don't recall seeing it before."] = "J'ignore où se trouve cette idole. Je ne me rappelle pas l'avoir vue.";
        map["You should know I think this whole thing is completely absurd, if that's any consolation."] = "Sachez que je trouve toute cette mascarade parfaitement ridicule, si cela peut vous consoler.";
        map["Not particularly."] = "Pas particulièrement.";
        map["Good news, I located that hand idol you were looking for!"] = "Bonne nouvelle, j'ai mis la main sur cette idole en forme de main !";
        map["You have? Then we might finally get our meeting underway!"] = "Vraiment ? Alors notre rendez-vous va enfin pouvoir commencer !";
        map["What's going on with you and Lady Unterwald?"] = "Que se passe-t-il exactement entre vous et Lady Unterwald ?";
        map["It is my intention to take ownership of the Unterwald empire."] = "J'ai l'intention de racheter l'empire Unterwald.";
        map["I believe this is in everyone's interest, including Lady Unterwald."] = "J'estime que c'est dans l'intérêt de tous, y compris de Lady Unterwald.";
        map["How would selling the business benefit Lady Unterwald?"] = "En quoi vendre son entreprise avantagerait-il Lady Unterwald ?";
        map["It's my understanding that the Unterwald empire is suffering from financial difficulties."] = "D'après mes informations, l'empire Unterwald traverse de graves turbulences financières.";
        map["I'll reveal more once our meeting begins, but I'd be more than willing to take it off her hands."] = "J'en dévoilerai davantage lors de notre entrevue, mais je suis prêt à lui racheter l'affaire sans tarder.";
        map["So, it's purely all business with you and Lady Unterwald?"] = "C'est donc strictement une affaire d'affaires entre vous deux ?";
        map["Well-I... I-"] = "Eh bien... je...";
        map["I assure you, that's none of your concern."] = "Je vous garantis que cela ne vous regarde en rien.";
        map["Am I to understand you're a member of the Order of Idle Hands?"] = "Dois-je en déduire que vous faites partie de l'Ordre des Mains Oisives ?";
        map["It's true, I was once an active member of the order."] = "C'est exact, j'ai été un membre actif de l'Ordre jadis.";
        map["I thought we were doing necessary work, but it soon devolved into secret handshakes, and petty rituals."] = "Je croyais notre cause noble, mais cela a vite dégénéré en poignées de main ridicules et rituels puérils.";
        map["Eventually, all this bureaucracy seemed to prevent anything from being achieved."] = "Au bout du compte, toute cette bureaucratie étouffait la moindre tentative d'action concrète.";
        map["I assume the bureaucracy hasn't improved?"] = "J'imagine que la bureaucratie ne s'est pas arrangée depuis ?";
        map["No, it's worse."] = "Non, c'est encore pire.";
        map["That's all I need to know right now!"] = "C'est tout ce que j'avais besoin de savoir pour le moment !";
        map["Sure."] = "Bien entendu.";

        // --- Lamont & Bailey Interrogation ---
        map["You know, my memory of that evening is a little hazy!"] = "Vous savez, mes souvenirs de cette soirée sont un peu flous !";
        map["That's probably to be expected, you all took quite the beating."] = "C'est prévisible, vu la raclée magistrale que vous avez tous reçue.";
        map["Is that why my arm is in a cast?"] = "C'est pour cela que j'ai le bras dans le plâtre ?";
        map["It's okay, let's just start small."] = "Tout doux, reprenons depuis le début.";
        map["Don't you think I should speak to an attorney?"] = "Ne devrais-je pas m'entretenir avec un avocat ?";
        map["You hear that, Bailey? The man wants to speak to an attorney!"] = "Tu entends ça, Bailey ? Monsieur réclame un avocat !";
        map["Brave man, especially after all the legal trouble Mr Ackerman has landed you in."] = "Bien courageux, surtout après tous les pétrins juridiques dans lesquels M. Ackerman vous a fourré.";
        map["Hmm. I suppose it couldn't hurt to regale you with a new Herman tale."] = "Hmm. J'imagine que cela ne ferait pas de mal de vous régaler d'une nouvelle aventure d'Herman.";
        map["Atta boy!"] = "Voilà un brave garçon !";
        map["And I'd have complete immunity, right?"] = "Et je bénéficie d'une immunité totale, pas vrai ?";
        map["What would you need immunity from?"] = "Une immunité contre quoi exactement ?";
        map["There may have been some collateral damage during my endeavours."] = "Il y a pu y avoir quelques dommages collatéraux lors de mes investigations.";
        map["I'm sure we could come to some sort of arrangement."] = "Je suis convaincu que nous pourrons trouver un arrangement.";
        map["So long as you start talking."] = "Tant que vous commencez à parler.";
        map["Anything for an adoring fan!"] = "Tout pour un admirateur fervent !";
        map["I knew we could count on you!"] = "Je savais qu'on pouvait compter sur vous !";

        // --- Masson & Herman in Dining Carriage ---
        map["I noticed you were having trouble ordering."] = "J'ai remarqué que vous aviez du mal à commander.";
        map["And if I was? Forgive me, but that's none of your business."] = "Et si c'était le cas ? Pardonnez-moi, mais cela ne vous regarde en rien.";
        map["Do you consider yourself a curator of sustenance?"] = "Vous vous prenez pour un expert gastronomique ?";
        map["Well, I-I"] = "Eh bien, je...";
        map["Ah, spare me your stuttering!"] = "Épargnez-moi vos bégaiements !";
        map["Tell me, for how long am I to endure your incessant hovering?"] = "Combien de temps vais-je devoir endurer votre présence importune ?";
        map["Perhaps you'd care for a drink while you wait?"] = "Peut-être prendriez-vous un verre en attendant ?";
        map["What is this? Are you employed here, or are you just another busybody?"] = "Qu'est-ce que c'est que ça ? Vous travaillez ici, ou vous n'êtes qu'un importun de plus ?";
        map["No, I'll have a drink with my meal."] = "Non, je prendrai mon verre avec mon repas.";
        map["What brings you aboard the Reuss Express?"] = "Qu'est-ce qui vous amène à bord du Reuss Express ?";
        map["Business, although it's all been for naught."] = "Les affaires. Bien que tout cela n'ait servi à rien.";
        map["A gentleman's agreement used to mean something, you know!"] = "La parole d'honneur d'un gentleman avait une valeur autrefois !";
        map["Your business was cancelled?"] = "Votre rendez-vous d'affaires a été annulé ?";
        map["Let's just say there was a disagreement between parties."] = "Disons simplement qu'il y a eu un litige entre les parties.";
        map["We agreed on a price, and the other party chose to renege on the deal."] = "Nous avions convenu d'un prix, et l'autre partie a renié sa signature.";
        map["Amateurs, I'm surrounded by amateurs!"] = "Des amateurs, je suis cerné par des amateurs !";
        map["Are you familiar with the Unterwald family?"] = "Connaissez-vous la famille Unterwald ?";
        map["Yes, I'm familiar with them. They're not my cup of tea."] = "Oui, je les connais. Ils ne sont guère ma tasse de thé.";
        map["I heard the family has run the Unterwald empire into the ground, and now they're looking for a quick way out."] = "J'ai entendu dire qu'ils ont ruiné l'empire Unterwald et cherchent désormais une porte de sortie en vitesse.";
        map["Lady Unterwald must have gone senile in recent years, entrusting those fools with even a modicum of power!"] = "Lady Unterwald a dû sombrer dans la sénilité pour confier la moindre parcelle de pouvoir à ces incapables !";
        map["Don't even get me started on those nephews of hers. Awful! Just deeply dumb."] = "Ne me lancez pas sur ses neveux. Effroyables ! D'une bêtise crasse.";
        map["You're not a fan of the Unterwalds, but you ride the Reuss Express?"] = "Vous n'êtes pas fan des Unterwald, mais vous voyagez sur leur train ?";
        map["You seem to be confusing business with pleasure."] = "Vous confondez manifestement les affaires avec le plaisir.";
        map["This is purely a means to an end for me."] = "Pour moi, ce n'est qu'un simple moyen de parvenir à mes fins.";
        map["Even so, a man has to eat, does he not?"] = "Quoi qu'il en soit, il faut bien qu'un homme dîne, n'est-ce pas ?";
        map["Indeed, that would be for the best."] = "En effet, ce serait préférable.";
        map["I'm afraid you have something that I need."] = "J'ai bien peur que vous ne déteniez un objet dont j'ai impérativement besoin.";
        map["And what is it that you think I have?"] = "Et qu'est-ce que je serais censé avoir selon vous ?";
        map["I don't know what it is, but I think you know..."] = "J'ignore de quoi il s'agit, mais je sais que vous le savez...";
        map["Do you know how ridiculous that sounds?"] = "Avez-vous conscience du ridicule de vos propos ?";
        map["Yes, I hear it now."] = "Oui, je l'entends à présent.";
        map["The item you possess, it belongs to Donny Donato."] = "L'objet que vous possédez appartient à Donny Donato.";
        map["Ah, and that coward sent you to do his bidding?"] = "Ah, et ce lâche vous a envoyé faire ses basses besognes ?";
        map["Are you supposed to be his muscle? You're practically skin and bones!"] = "Vous êtes censé être son homme de main ? Mais vous n'avez que la peau sur les os !";
        map["I'm merely an interested party."] = "Je suis simplement une partie intéressée.";
        map["I'm sorry to say I've named my price, and you won't convince me otherwise."] = "J'ai fixé mon prix, et rien au monde ne me fera changer d'avis.";
        map["If it's a question of price, I'm willing to negotiate!"] = "Si ce n'est qu'une affaire de prix, je suis prêt à négocier !";
        map["Trust me, it's more than you could afford."] = "Croyez-moi, vous n'avez pas les reins assez solides.";
        map["Don't waste our time."] = "Ne nous faites pas perdre notre temps.";
        map["Are you an acquaintance of Donny Donato?"] = "Êtes-vous une connaissance de Donny Donato ?";
        map["Don't bore me by talking about that man, he sets my teeth on edge."] = "Ne m'ennuyez pas avec cet individu, il me donne des aigreurs d'estomac.";
        map["What's your history with Donny?"] = "Quel est votre contentieux avec Donny ?";
        map["He's an arrogant bully, that's what. A selfish, self-serving sleazeball!"] = "C'est une brute arrogante. Une crapule égoïste et sans scrupules !";
        map["I see. It would be fair to say there's some bad blood between you?"] = "Je vois. On peut dire qu'il y a de l'eau dans le gaz entre vous deux ?";
        map["I don't know what he's promised you, but you should never trust a gangster."] = "J'ignore ce qu'il vous a promis, mais on ne fait jamais confiance à un truand.";
        map["No, I've already left my fate in that waiter's hands."] = "Non, j'ai déjà confié mon sort entre les mains de ce serveur.";
        map["Who knows what foul concoction awaits me in that kitchen."] = "Dieu seul sait quelle infâme mixture me mijotent ces fourneaux.";
        map["I suppose I have no choice. Begone!"] = "Je suppose que je n'ai guère le choix. Disparaissez !";
        map["I apologise, sir, but the kitchen is closed due to an incident."] = "Toutes mes excuses, monsieur, mais les cuisines sont fermées en raison d'un incident.";
        map["I suppose it was too much to ask for a meal with a hint of imagination?"] = "J'imagine que c'était trop demander que d'avoir un repas avec un zeste d'imagination ?";
        map["Would you care to order a drink instead?"] = "Désireriez-vous commander un verre à la place ?";
        map["Name?"] = "Votre nom ?";
        map["Jian Liu."] = "Jian Liu.";
        map["Please go right ahead, Mr Liu."] = "Je vous en prie, entrez, M. Liu.";

        // Write output TSV
        int count = 0;
        using (var sw = new StreamWriter(@"translations\partitions\c2_b3_french.tsv", false, Encoding.UTF8)) {
            sw.WriteLine("Id\tCharacter\tEnglish\tFrench\tClass\tMethod");
            foreach (var l in lines) {
                var p = l.Split('\t');
                if (p.Length < 6) continue;
                string en = p[2].Trim();
                string fr = "";
                if (map.ContainsKey(en)) {
                    fr = map[en];
                } else {
                    Console.WriteLine("Missing in map: [" + en + "]");
                    fr = en;
                }
                sw.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", p[0], p[1], en, fr, p[4], p[5]));
                if (!string.IsNullOrEmpty(fr) && fr != en) count++;
            }
        }
        Console.WriteLine(string.Format("Generated c2_b3_french.tsv: {0} lines translated out of {1}", count, lines.Length));
    }
}
