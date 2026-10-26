using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class BuildC2B1 {
    static void Main() {
        var lines = File.ReadAllLines(@"translations\partitions\c2_b1_hintline.tsv");
        var map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        map["I'm not sure what I should be doing next."] = "Je ne sais pas trop ce que je devrais faire maintenant.";
        map["The doctor seemed pretty upset about what happened. Where did he go?"] = "Le docteur avait l'air très secoué par ce qui s'est passé. Où est-il parti ?";
        map["I need another hint, what should be doing?"] = "J'ai besoin d'un autre indice, que dois-je faire ?";
        map["Bergmann said the doctor was looking for you, did he say where he went?"] = "Bergmann a dit que le docteur vous cherchait. Vous a-t-il dit où il se rendait ?";
        map["Head back to Lady Unterwald's quarters, you'll find the doctor there!"] = "Retournez dans les quartiers de Lady Unterwald, le docteur s'y trouve !";
        map["I need a hint about one of the safe mechanisms."] = "J'ai besoin d'un indice sur l'un des mécanismes du coffre.";
        map["Which one did you have in mind?"] = "Auquel pensez-vous en particulier ?";
        map["I need a hint about the combination lock."] = "J'ai besoin d'un indice sur la serrure à combinaison.";
        map["If I had to remember a six-digit number, I'd pick something personal, so there'd be no way to forget it."] = "Si je devais retenir un code à six chiffres, je choisirais quelque chose de très personnel pour ne jamais l'oublier.";
        map["I need another hint about the combination lock."] = "J'ai besoin d'un autre indice sur le code du coffre.";
        map["If it's a six-digit number, chances are it's a date. Most people would pick something memorable, like a birthday."] = "Si c'est un code à six chiffres, il y a de fortes chances que ce soit une date. La plupart des gens choisissent leur date de naissance.";
        map["Lady Unterwald's medical records would likely contain her date of birth, if you can get your hands on them."] = "Le dossier médical de Lady Unterwald contient sûrement sa date de naissance, si vous parvenez à mettre la main dessus.";
        map["I need a hint about the voice lock."] = "J'ai besoin d'un indice sur la serrure vocale.";
        map["You'd need a recording of Lady Unterwald, but that may be difficult."] = "Il vous faudrait un enregistrement de la voix de Lady Unterwald, mais cela risque d'être corsé.";
        map["I need another hint about the voice lock."] = "J'ai besoin d'un autre indice sur la serrure vocale.";
        map["Didn't another passenger have a way to record voices?"] = "Un autre passager n'avait-il pas un appareil pour enregistrer des voix ?";
        map["What happened to them?"] = "Que lui est-il arrivé ?";
        map["Don had a recording device, right? Maybe he dropped it during the brawl."] = "Don avait un magnétophone, non ? Il l'a peut-être laissé tomber pendant la bagarre.";
        map["That recording device isn't much good without a blank tape, I'm sure one will turn up sooner or later."] = "Cet enregistreur n'est pas d'une grande utilité sans bande vierge. Une finira bien par apparaître.";
        map["High-tech problems often have high-tech solutions, have another look around."] = "Aux problèmes de pointe, les solutions de pointe. Cherchez encore un peu.";
        map["That recording device isn't much good without a blank tape, know anybody that might have a spare?"] = "Cet enregistreur a besoin d'une bande vierge. Connaissez-vous quelqu'un qui en aurait une sous la main ?";
        map["Diana has a bunch of gadgets, perhaps she has a blank reel you could borrow?"] = "Diana a toute une panoplie de gadgets. Elle a peut-être une bobine vierge à vous dépanner ?";
        map["You're all set, you just need a recording of Lady Unterwald's voice. Be ready with that device of yours."] = "Vous êtes paré. Il ne vous manque plus que la voix de Lady Unterwald. Tenez-vous prêt avec votre appareil.";
        map["Listen out for Lady Unterwald's voice. It might be closer than you think."] = "Ouvrez grand les oreilles. La voix de Lady Unterwald est peut-être plus proche que vous ne le pensez.";
        map["What about the automated message from Lady Unterwald when you use the phone? Have you tried recording that?"] = "Et le message enregistré de Lady Unterwald au téléphone ? Avez-vous essayé de l'enregistrer ?";
        map["Actually, I wanted to ask about something else."] = "En fait, je voulais poser une question sur autre chose.";
        map["Alright! Ask away!"] = "Très bien ! Je vous écoute !";
        map["How do I get behind that curtain?"] = "Comment passer derrière ce rideau ?";
        map["You'll need to perform the secret handshake, but it all happens so fast!"] = "Il faut exécuter la poignée de main secrète, mais tout va tellement vite !";
        map["I need another hint to get behind that curtain!"] = "J'ai besoin d'un autre indice pour passer derrière le rideau !";
        map["Is there a way to capture that handshake? You'd better be quick about it!"] = "Y a-t-il un moyen de capturer cette poignée de main ? Il va falloir faire très vite !";
        map["There's a passenger on the train who captures things at speed. Maybe they can help?"] = "Il y a un passager à bord qui capture les choses à la vitesse de l'éclair. Il peut peut-être vous aider ?";
        map["I recorded the handshake, now what?"] = "J'ai les dessins de la poignée de main, et maintenant ?";
        map["Someone aboard that train knows what goes on behind the curtain. Ask around!"] = "Quelqu'un à bord sait ce qui se trame derrière ce rideau. Renseignez-vous !";
        map["I need another hint about these sketches!"] = "J'ai besoin d'un autre indice sur ces croquis !";
        map["You'll need someone familiar with the handshake to identify those sketches."] = "Il vous faut quelqu'un qui connaît bien cette poignée de main pour décrypter ces croquis.";
        map["The doctor might be willing to assist you if you can convince him!"] = "Le docteur pourrait vous venir en aide si vous arrivez à le convaincre !";
        map["The doctor told me the phrases, now what?"] = "Le docteur m'a donné les phrases, que faire ensuite ?";
        map["Head back to the curtain and show that guy who's boss!"] = "Retournez au rideau et montrez à ce type de quel bois vous vous chauffez !";
        map["How can I get information out of Mr Masson?"] = "Comment tirer des vers du nez de M. Masson ?";
        map["It seems like he's either too drunk, or you're too sober."] = "On dirait que soit il est trop soûl, soit vous êtes trop sobre.";
        map["I need another hint to get Mr Masson talking."] = "J'ai besoin d'un autre indice pour faire parler M. Masson.";
        map["What's Mr Masson been drinking? Perhaps you can ask around."] = "Qu'est-ce que M. Masson a bien pu boire ? Demandez autour de vous.";
        map["Try to learn what Mr Masson is drinking, have you asked the waiter?"] = "Découvrez ce que boit M. Masson. Avez-vous interrogé le serveur ?";
        map["What's Mr Masson been drinking? Perhaps you need to get on his level."] = "Qu'a bu M. Masson ? Peut-être devez-vous vous hisser à son niveau d'ébriété.";
        map["You could recreate what Mr Masson is drinking, have you asked the barman?"] = "Vous pourriez recréer le cocktail de M. Masson. Avez-vous demandé au barman ?";
        map["I need to make my Bud-Lite more powerful."] = "Je dois corser ma Bud-Lite.";
        map["Maybe you can combine it with something else to create a more potent version?"] = "Peut-être pourriez-vous la mélanger à un autre produit pour en faire une version plus corsée ?";
        map["I need another hint to make my Bud-Lite more powerful!"] = "J'ai besoin d'un autre indice pour corser ma bière !";
        map["Maybe you can combine it with something else, was there anything potent in your room?"] = "Y avait-il quelque chose de fort dans votre chambre avec quoi la mélanger ?";
        map["I'd combine it with something else, do you have anything potent on you?"] = "Mélangez-la à quelque chose d'autre. Avez-vous un produit alcoolisé sur vous ?";
        map["Can you combine the mouthwash in your room with the Bud-Lite?"] = "Avez-vous essayé d'ajouter le bain de bouche de votre chambre à la Bud-Lite ?";
        map["Try adding some of that mouthwash you have, that'd kick it up a notch!"] = "Versez un peu de ce bain de bouche, ça va lui donner un sacré coup de fouet !";
        map["I need a mixing container for the Rosebud."] = "Il me faut un récipient pour mélanger le Rosebud.";
        map["You might need something large and unconventional to mix those ingredients in."] = "Il vous faudra un contenant assez grand et insolite pour touiller ces ingrédients.";
        map["I need another hint about finding the container."] = "J'ai besoin d'un autre indice pour trouver le récipient.";
        map["Someone on board might have a suitable goblet, if you can distract them for long enough."] = "Quelqu'un à bord a peut-être un calice improvisé, si vous le distrayez assez longtemps.";
        map["I bet Arista's hearing horn could hold a lot of liquid! Try creating a diversion, and don't get caught in the act!"] = "Je parie que le cornet acoustique d'Arista ferait un formidable verre ! Faites diversion sans vous faire pincer !";
        map["I have a potential mixing container, but I'm unsure of the next move."] = "J'ai un récipient potentiel, mais je ne sais pas quoi en faire.";
        map["You might need to modify the container to hold liquid."] = "Vous devrez sans doute adapter ce récipient pour qu'il retienne le liquide.";
        map["I need another hint about using the container."] = "J'ai besoin d'un autre indice sur l'utilisation du récipient.";
        map["You should find something to plug up the end of that container."] = "Vous devriez trouver de quoi boucher l'extrémité de ce récipient.";
        map["The bartender has a corking device that might do the trick, perhaps you could ask to borrow it?"] = "Le barman a une boucheuse qui ferait l'affaire. Vous pourriez lui emprunter ?";
        map["That corking device you have might do the trick, give it a go!"] = "Cette boucheuse que vous avez devrait faire l'affaire, tentez le coup !";
        map["I've made the Rosebud, what should I do?"] = "J'ai préparé le Rosebud, que dois-je faire ?";
        map["Stop stalling for time, you need to drink up, kid!"] = "Arrêtez d'hésiter, cul sec, l'ami !";
        map["How do I get into the luggage room?"] = "Comment entrer dans le fourgon à bagages ?";
        map["The luggage room? You'll probably need to use the right item to get in there."] = "Le fourgon à bagages ? Il vous faudra le bon passe-partout pour entrer.";
        map["I need another hint about accessing the luggage room."] = "J'ai besoin d'un autre indice sur l'accès au fourgon à bagages.";
        map["Perhaps you already hold the key to that question?"] = "Peut-être avez-vous déjà la clé de cette énigme sur vous ?";
        map["You have a set of keys, have you tried those on the door?"] = "Vous avez un trousseau de clés, les avez-vous essayées sur la porte ?";
        map["I need help opening this briefcase."] = "J'ai besoin d'aide pour ouvrir cette mallette.";
        map["I doubt you'll manage to unlock it, some brute-force might be the better option."] = "Je doute que vous puissiez crocheter la serrure, la force brute semble tout indiquée.";
        map["I need another hint about opening the briefcase."] = "J'ai besoin d'un autre indice pour forcer la mallette.";
        map["A passenger might be able to help. Although sometimes two heads are better than one!"] = "Un passager pourrait vous aider. Quoique deux têtes valent parfois mieux qu'une !";
        map["Those twins will argue over anything, I'd hate for that briefcase to come between them."] = "Ces jumeaux se disputent pour un rien. Ce serait dommage que cette mallette s'interpose entre eux.";
        map["I've been given this blank napkin, what gives?"] = "On m'a donné cette serviette vierge, c'est une blague ?";
        map["Listen, kid, nobody's handing out blank napkins. I'd look into figuring out what's on there."] = "Écoutez, personne ne donne de serviette blanche pour rien. Trouvez ce qui y est caché.";
        map["I need another hint about the napkin."] = "J'ai besoin d'un autre indice sur la serviette.";
        map["Someone on board might know how to decode hidden messages, have you asked around?"] = "Quelqu'un à bord sait peut-être comment décoder les messages secrets. Avez-vous demandé ?";
        map["The Order Of Idle Hands might know something about decoding messages, I'd start there."] = "L'Ordre des Mains Oisives doit en savoir un rayon sur les codes secrets. Commencez par là.";
        map["I need that guide book, but Jared won't let me at it!"] = "Il me faut ce guide, mais Jared refuse de me le prêter !";
        map["Perhaps you could trade the book for another."] = "Peut-être pourriez-vous échanger ce livre contre un autre.";
        map["I need another hint about getting the book."] = "J'ai besoin d'un autre indice pour récupérer le livre.";
        map["He'd notice if you stole it, perhaps you can swap the book for another."] = "Il remarquerait un vol. Vous devriez plutôt faire un échange discret.";
        map["You'll need to swap the guide book with Don's book of poems. Just make sure Jared isn't looking!"] = "Échangez le guide contre le recueil de poèmes de Don. Assurez-vous que Jared regarde ailleurs !";
        map["I need to access the kitchen, but the chefs won't let me in!"] = "Je dois entrer en cuisine, mais les chefs me barrent l'accès !";
        map["Well, you ain't getting past them. I'd wait 'em out, I'm sure they'll be done soon."] = "Vous ne passerez pas en force. Prenez votre mal en patience, ils auront bientôt fini.";
        map["I need another hint about the kitchen."] = "J'ai besoin d'un autre indice sur la cuisine.";
        map["Personally, I'd pursue some other lines of enquiry, and try again later."] = "Personnellement, je suivrais d'autres pistes avant de revenir tenter ma chance.";
        map["Just wait 'em out, no use trying to brute force your way in!"] = "Attendez simplement. Inutile de tenter de forcer le passage !";
        map["How do I capture that thieving mouse?"] = "Comment attraper cette souris voleuse ?";
        map["How does that mouse move around the train? Maybe you can limit its movements."] = "Comment cette souris se déplace-t-elle ? Vous devriez limiter ses mouvements.";
        map["I need another hint about catching that mouse."] = "J'ai besoin d'un autre indice pour piéger la souris.";
        map["There's a fair number of holes for that mouse to slip through, you'll need to find a way to narrow those down."] = "Il y a un paquet de terriers par où elle peut filer. Vous devez boucher ses sorties.";
        map["You'll need to block off any escape routes, do you have anything that can plug a hole?"] = "Bloquez toutes ses voies de fuite. Avez-vous de quoi boucher un trou ?";
        map["You've blocked off the escape routes, but you'll need some bait to lure it out."] = "Les sorties sont condamnées, mais il vous faut un appât pour la faire sortir.";
        map["I need another hint about the mouse."] = "J'ai besoin d'un autre indice sur la souris.";
        map["All that thievery must be hungry work. With the right food, you could bait it out."] = "Tous ces cambriolages creusent l'estomac. Avec la bonne nourriture, vous pourrez l'attirer.";
        map["No mouse can resist the sweet allure of cheese. I bet there's some already stored away in the kitchen pantry."] = "Aucune souris ne résiste à l'appel du fromage. Il doit y en avoir dans le garde-manger.";
        map["How can I capture that thieving mouse?"] = "Comment capturer cette souris chapardeuse ?";
        map["You probably don't want to grab it with your bare hands. Find some protection!"] = "Vous n'avez pas envie de la choper à mains nues. Trouvez une protection !";
        map["You probably don't want to grab it with your bare hands. Do you have anything that can provide you with protection?"] = "Évitez les mains nues. Avez-vous de quoi vous protéger ?";
        map["You shouldn't use your bare hands. You should secure yourself a pair of gloves."] = "Pas à mains nues. Dénichez-vous une bonne paire de gants.";
        map["You shouldn't use your bare hands. Do you have any gloves to hand?"] = "Pas à mains nues. Avez-vous des gants sous la main ?";
        map["Check the kitchen for oven gloves, they should protect against any biting or scratching."] = "Cherchez des maniques en cuisine, elles vous éviteront morsures et griffures.";
        map["Those oven gloves should protect against any biting or scratching."] = "Ces maniques de cuisine vous protégeront des morsures et des griffures.";
        map["I've managed to capture the mouse, what's next?"] = "J'ai capturé la souris, et maintenant ?";
        map["Have you told the chefs you've solved their mouse problem? I'm sure they'd be relieved."] = "Avez-vous annoncé aux chefs que leur problème était réglé ? Ils vont pousser un ouf de soulagement.";
        map["I've decoded the napkin, what should I do now?"] = "J'ai décodé la serviette, que faire à présent ?";
        map["That number's gotta mean something. Have you taken another look around?"] = "Ce numéro doit vouloir dire quelque chose. Avez-vous inspecté les lieux ?";
        map["Is it possible that the number matches a room number?"] = "Ce numéro ne correspondrait-il pas à un numéro de cabine ?";
        map["Heating the napkin revealed a room number, right?"] = "Chauffer la serviette a fait apparaître un numéro de cabine, non ?";
        map["Try sliding that napkin under the door."] = "Essayez de glisser cette serviette sous la porte.";
        map["How do I get into Herman's room?"] = "Comment entrer dans la chambre d'Herman ?";
        map["Herman's room? Using the right item will be key to getting in there!"] = "La cabine d'Herman ? La bonne clé sera le sésame pour y pénétrer !";
        map["I need another hint about accessing Herman's room."] = "J'ai besoin d'un autre indice pour entrer dans la chambre d'Herman.";
        map["I've located the will, but I can't reach it!"] = "J'ai localisé le testament, mais je ne peux pas l'atteindre !";
        map["I don't think you'll be able to reach it with your bare hands!"] = "Vous n'y arriverez pas avec vos bras seuls !";
        map["I need another hint about getting the will."] = "J'ai besoin d'un autre indice pour récupérer le testament.";
        map["You might be able to fashion something to give you better reach."] = "Vous pourriez fabriquer une perche pour allonger votre portée.";
        map["You can fashion a rudimentary hook with Lady Unterwald's walking stick and a bit of metal wire."] = "Bricolez un crochet de fortune avec la canne de Lady Unterwald et du fil de fer.";
        map["You need something to secure that metal hook in place, got anything on you?"] = "Il vous faut fixer solidement ce crochet. Avez-vous de quoi le maintenir ?";
        map["Don't you have surgical tape on you? Use that to reinforce that hook you've made."] = "N'avez-vous pas du ruban chirurgical sur vous ? Utilisez-le pour consolider votre crochet.";

        // Write output TSV
        int count = 0;
        using (var sw = new StreamWriter(@"translations\partitions\c2_b1_french.tsv", false, Encoding.UTF8)) {
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
        Console.WriteLine(string.Format("Generated c2_b1_french.tsv: {0} lines translated out of {1}", count, lines.Length));
    }
}
