using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class BuildC4 {
    static void Main() {
        string rawPath = @"translations\partitions\chapter4_missing.tsv";
        if (!File.Exists(rawPath)) {
            Console.WriteLine("File not found: " + rawPath);
            return;
        }

        var lines = File.ReadAllLines(rawPath, Encoding.UTF8);
        var map = new Dictionary<string, string>();

        // Bergmann & Lady Unterwald & Ron & Susanne
        map["You're not with the tax office, are you?"] = "Vous n'êtes pas du fisc, n'est-ce pas ?";
        map["Certainly not!"] = "Certainement pas !";
        map["Once the sale goes through, it shouldn't be my concern any longer."] = "Une fois la vente conclue, ce ne sera plus du tout mon problème.";
        map["Assuming everything goes to plan, of course."] = "Si tout se déroule comme prévu, bien entendu.";
        map["No, thank you! I'll best be going."] = "Non, merci ! Je ferais mieux de filer.";
        map["Lady Unterwald?"] = "Lady Unterwald ?";
        map["Are you still here?"] = "Vous êtes toujours là ?";
        map["Sorry, I'm not buying whatever it is you're selling."] = "Désolé, je n'achète rien de ce que vous vendez.";
        map["It's you again!"] = "Encore vous !";
        map["I should probably leave you to it."] = "Je devrais sans doute vous laisser à vos affaires.";

        // Hint hotline
        map["How can I find out the idol gesture?"] = "Comment découvrir le geste de l'idole ?";
        map["Keep an eye out for clues about the gestures Lady Unterwald might make."] = "Guettez les indices sur les gestes habituels de Lady Unterwald.";
        map["I need another hint about the idol gesture."] = "J'ai besoin d'un autre indice sur le geste de l'idole.";
        map["I'd start in The Order Of Idle Hands, does anything look out of place?"] = "Je commencerais par l'Ordre des Mains Inactives. Y a-t-il quelque chose d'inhabituel ?";
        map["There's a painting in The Order Of Idle Hands that seems to have been touched up. I wonder what they're hiding?"] = "Il y a un tableau dans le repaire de l'Ordre qui a l'air d'avoir été retouché. Que peuvent-ils bien dissimuler ?";
        map["You'd need a strong solvent to remove those layers of paint."] = "Il vous faudrait un solvant puissant pour décaper ces couches de peinture.";
        map["The doctor carries surgical spirit in his briefcase, you could try that."] = "Le médecin transporte de l'alcool chirurgical dans sa sacoche, vous pourriez tester ça.";
        map["Pinch a napkin from the bar, apply some surgical spirit to it, and then figure out what's under that painting."] = "Chipez une serviette au bar, imbibez-la d'alcool chirurgical et découvrez ce qui se cache sous cette toile.";
        map["How can I find out the idol engraving?"] = "Comment trouver la gravure de l'idole ?";
        map["Seems like it's got something to do with Lady Unterwald, probably some mushy stuff."] = "On dirait que ça a un rapport avec Lady Unterwald, sûrement une déclaration sentimentale.";
        map["I need another hint about the idol engraving."] = "J'ai besoin d'un autre indice sur la gravure de l'idole.";
        map["Have you checked everything in the lobby outside Lady Unterwald's room?"] = "Avez-vous bien inspecté le vestibule devant la chambre de Lady Unterwald ?";
        map["The model railway in the lobby was dedicated to Lady Unterwald."] = "Le train miniature dans le vestibule a été dédié à Lady Unterwald.";
        map["How can I get Mr Masson to vote in the club?"] = "Comment faire voter M. Masson au club ?";
        map["He's pretty unresponsive after drinking that Rosebud, you'll need to snap him out of his stupor."] = "Il ne réagit plus à grand-chose après son Rosebud. Vous allez devoir le sortir de sa léthargie.";
        map["A shock to his system may temporarily bring him to his senses."] = "Un bon choc thermique ou gustatif pourrait lui faire retrouver ses esprits.";
        map["If Mr Masson drank something potent enough, it may sober him up enough to vote!"] = "Si M. Masson buvait quelque chose d'assez corsé, ça le dégriserait suffisamment pour voter !";
        map["Top up Mr Masson's glass with the spicy soup from the kitchen. I bet that'd get him talking again!"] = "Remplissez le verre de M. Masson avec la soupe pimentée de la cuisine. Ça va lui délier la langue illico !";
        map["I need to get the hearing horn repaired, any ideas?"] = "Je dois faire réparer le cornet acoustique, une idée ?";
        map["Ask the band about the hearing horn, I'm sure they'd be happy to help."] = "Demandez aux musiciens de l'orchestre, ils se feront une joie de vous aider.";
        map["I need to win at the knife game, but he's too good!"] = "Je dois gagner au jeu du couteau, mais il est trop fort !";
        map["Byron is skilled with a knife, but perhaps you could even the playing field."] = "Byron est très agile avec une lame, mais vous pourriez rétablir l'équilibre.";
        map["I need another hint about the knife game."] = "J'ai besoin d'un autre indice sur le jeu du couteau.";
        map["You have the knife, right? It's slippery business, but perhaps you could tamper with it."] = "Vous avez le couteau, n'est-ce pas ? C'est une affaire glissante, mais vous pourriez le saboter.";
        map["If you can loosen Byron's grip on that knife, he'd surely slip up!"] = "Si vous arrivez à faire perdre prise à Byron sur son couteau, il finira bien par gaffer !";
        map["Mix the hand cream with the melted butter to create a slippery concoction. Then apply that to the knife!"] = "Mélangez la crème pour les mains avec le beurre fondu pour faire une pâte bien glissante. Enduisez-en la lame !";
        map["The band repaired the horn for me, now what?"] = "L'orchestre a réparé le cornet, que faire maintenant ?";
        map["Nice work. You should return the hearing horn to Arista now."] = "Beau travail. Vous devriez maintenant rapporter le cornet acoustique à Arista.";
        map["How can I get Arthur out of his room?"] = "Comment puis-je faire sortir Arthur de sa cabine ?";
        map["He's probably neck deep in paperwork, can you tamper with his room to get him out?"] = "Il est sans doute submergé de dossiers. Pouvez-vous saboter quelque chose pour le déloger ?";
        map["I need another hint about distracting Arthur."] = "J'ai besoin d'un autre indice pour distraire Arthur.";
        map["If the lights went out, he'd probably struggle to get anything done."] = "Si les lumières s'éteignaient, il aurait bien du mal à continuer de travailler.";
        map["There's an electrical panel in the sleeper carriage, open that up and see what you can do."] = "Il y a un tableau électrique dans le wagon-lits, ouvrez-le pour voir ce que vous pouvez faire.";
        map["I need to get back into my room, what should I do?"] = "Je dois regagner ma chambre, que faire ?";
        map["If the door isn't an option, then the next best thing would be to get in through the window."] = "Si la porte est inaccessible, la meilleure option reste de passer par la fenêtre.";
        map["I need another hint about getting back in my room."] = "J'ai besoin d'un autre indice pour regagner ma chambre.";
        map["You could climb outside the train, but you wouldn't want to do it without the right footwear!"] = "Vous pourriez escalader le toit du train, mais pas sans les chaussures adéquates !";
        map["You'll need some proper suction to stay on top of the train. Think on your feet, Herman!"] = "Il vous faudra une bonne adhérence pour tenir sur le toit. Soyez réactif, Herman !";
        map["If you could make a set of suction boots, that would provide enough adhesion to safely walk along the carriage roof."] = "Si vous pouviez vous bricoler des bottes à ventouses, elles vous permettraient de marcher sans risque sur le toit des voitures.";
        map["See if you can find a plunger or two. You could use them to whip up a pair of suction boots!"] = "Voyez si vous pouvez dégoter une ou deux ventouses pour fabriquer des bottes adhérentes !";
        map["There's a plunger in the kitchen, and another in the bathroom! You could use them to whip up a pair of suction boots!"] = "Il y a une ventouse dans la cuisine et une autre dans les toilettes ! Vous pourriez vous en servir pour fabriquer des bottes à ventouse !";
        map["I have the plunger boots, what now?"] = "J'ai les bottes à ventouses, et maintenant ?";
        map["Get to the back of the train and climb that ladder!"] = "Filez à l'arrière du convoi et grimpez à cette échelle !";

        // Band Chapter 4
        map["Are you still not performing on stage?"] = "Vous n'êtes toujours pas sur scène ?";
        map["Ah, we'll probably get back up there eventually."] = "Bah, on remontera probablement là-haut à l'occasion.";
        map["I'm still feeling mighty demoralised, personally!"] = "Moi perso, j'ai toujours le moral dans les chaussettes !";
        map["Your true-blue determination was truly inspiring, however."] = "Votre détermination sans faille nous a vraiment inspirés, cela dit.";
        map["Are you saying I managed to inspire you?"] = "Vous voulez dire que j'ai réussi à vous inspirer ?";
        map["Too right! You took that knife like a champ."] = "Tout juste ! Vous avez encaissé ce coup de couteau comme un chef.";
        map["Barely batted an eye before you passed out!"] = "Vous avez à peine cillé avant de tomber dans les pommes !";
        map["Say, I reckon a new song's a-brewing!"] = "Dites, je sens qu'un nouveau morceau est en train de mijoter !";
        map["Yeah, I can feel it!"] = "Ouais, je le sens bien !";
        map["A song about my bravery, you mean?"] = "Une chanson sur ma bravoure, vous voulez dire ?";
        map["Yeah, Nah! Listen fellas, how about ''Butterfinger Blues''?"] = "Euh, non ! Écoutez les gars, que diriez-vous du « Blues des doigts gourds » ?";
        map["That's not bad. I was thinking ''Gutterblade Groove''?"] = "Pas mal. Moi je pensais au « Groove de la lame d'égout » ?";
        map["''Slippin' Steel Symphony''?"] = "La « Symphonie de l'acier glissant » ?";
        map["Yeah! Now you're talking!"] = "Ouais ! Là, vous parlez !";
        map["How's that song coming along?"] = "Comment avance cette chanson ?";
        map["The creative juices are flowing now!"] = "L'inspiration créative tourne à plein régime !";
        map["It definitely has legs, I can see the potential!"] = "Ça tient carrément la route, je vois tout le potentiel !";
        map["Yeah, right! It's gonna be a ripper of a song!"] = "Carrément ! Ça va être un tube d'enfer !";
        map["Where did you learn about Knifey Stab Stab?"] = "Où avez-vous appris à jouer au Pique-doigts ?";
        map["From me ma, of course! We used to play it all the time back home."] = "De ma maman, pardi ! On y jouait tout le temps à la maison.";
        map["It was a riot! A real bonding moment, ya know!"] = "Une vraie rigolade ! Rien de tel pour resserrer les liens familiaux !";
        map["Would you believe that's the first time anyone's got hurt playing 'Knifey Stab Stab'?"] = "Croiriez-vous que c'était la toute première fois que quelqu'un se blessait au Pique-doigts ?";
        map["I do find that hard to believe."] = "J'ai effectivement beaucoup de mal à le croire.";
        map["Nah, yeah! Honest!"] = "Si si, promis juré !";
        map["Just a couple scratches here and there, of course!"] = "Juste deux ou trois égratignures ici et là, évidemment !";
        map["Could you have a look at this horn? It's broken."] = "Pourriez-vous jeter un œil à ce cornet ? Il est cassé.";
        map["Crikey, Is this a hearing aid?"] = "Nom d'un chien, c'est une prothèse auditive ?";
        map["It seems to produce a sound, regardless."] = "Il produit tout de même du son, quoi qu'il en soit.";
        map["Not any more, check out the reed on this! It's knackered mate."] = "Plus maintenant : mate un peu l'anche ! Elle est foutue, mon vieux.";
        map["I reckon you'll need a replacement reed."] = "Il va te falloir une anche de rechange.";
        map["Do you have a spare? It's rather urgent."] = "En auriez-vous une en réserve ? C'est plutôt urgent.";
        map["I've only got the one, and I need it for my sax!"] = "Je n'en ai qu'une seule et j'en ai besoin pour mon saxo !";
        map["Couldn't I just borrow the reed? I'll bring it back!"] = "Ne pourrais-je pas simplement vous l'emprunter ? Je la rapporterai !";
        map["You know it goes in your mouth, right? I don't think so."] = "Tu sais qu'on met ça dans la bouche, pas vrai ? Sûrement pas.";
        map["I tell ya what, how about another round of ‘Knifey, Stab, Stab'?"] = "J'ai une idée : et si on se faisait une autre partie de Pique-doigts ?";
        map["Uhh... I don't think that's such a good ide-"] = "Euh... Je ne crois pas que ce soit une très bonne idé-";
        map["If you can beat me at ‘Knifey, Stab, Stab', we'll hand it over."] = "Si tu arrives à me battre au Pique-doigts, on te la donne.";
        map["Byron, what about my sax? I need it!"] = "Byron, et mon saxophone ? J'en ai besoin !";
        map["The man said it was urgent, and we're not using it right now."] = "Le monsieur a dit que c'était urgent, et on ne joue pas pour l'instant.";
        map["I accept your challenge, let's play Knifey, Stab, Stab!"] = "Je relève le défi ! Jouons au Pique-doigts !";
        map["Good on ya, mate!"] = "Bien joué, l'ami !";
        map["Uh... did you bring the knife back?"] = "Euh... tu as rapporté le couteau au fait ?";
        map["It was embedded in yer hand, last I saw it!"] = "Il était planté dans ta main la dernière fois que je l'ai vu !";
        map["Not to worry, I have it right here!"] = "Ne vous inquiétez pas, je l'ai sur moi !";
        map["I'd like a rematch!"] = "J'exige une revanche !";
        map["Back for more, eh?"] = "Encore de la visite, hein ?";
        map["You must really want that mouthpiece!"] = "Tu y tiens drôlement, à cet embout !";
        map["Fancy another round of Knifey, Stab, Stab?"] = "Ça vous dit une autre manche de Pique-doigts ?";
        map["This guy's a maniac!"] = "Ce type est un grand malade !";
        map["You got what you wanted already!"] = "Tu as déjà obtenu ce que tu voulais !";
        map["We're just going to stick to card games from now on."] = "On va s'en tenir aux jeux de cartes dorénavant.";
        map["Do you have any leads on your missing set list?"] = "Avez-vous des pistes concernant votre liste de morceaux disparue ?";
        map["Not yet, but we'll find them!"] = "Pas encore, mais on finira par trouver le coupable !";
        map["Don't worry, they always return to the scene of the crime."] = "T'inquiète, le criminel revient toujours sur les lieux du crime.";
        map["I'll leave you to your game."] = "Je vous laisse à votre partie.";
        map["See ya around."] = "À plus tard.";
        map["As the reigning champ, I'll go first."] = "En tant que champion en titre, j'ouvre le bal.";
        map["Watch and learn!"] = "Regardez et apprenez !";
        map["Such speed!"] = "Quelle rapidité !";
        map["Incredible control!"] = "Une maîtrise prodigieuse !";
        map["I'd like to see ya beat that!"] = "J'aimerais bien te voir battre ça !";
        map["Alright, here goes nothing."] = "Très bien, à moi de jouer.";
        map["That was even slower than last time!"] = "C'était encore plus lent que la dernière fois !";
        map["Unlucky, mate! Better luck next time."] = "Pas de chance, l'ami ! Plus de veine la prochaine fois.";
        map["If I can't win playing by their rules, it's time to mix things up."] = "Si je ne peux pas gagner en respectant leurs règles, il est temps de brouiller les pistes.";
        map["He's so fast!"] = "Il est si rapide !";
        map["She's a slippery one!"] = "Ça glisse drôlement !";
        map["He's still got everything under cont-"] = "Il garde tout sous contrô-";
        map["Woahh, Nelly!"] = "Wouh là, doucement !";
        map["CRIKEY!"] = "NOM DE DIEU !";
        map["That nearly went through me bleedin' hand!"] = "Ça a failli me transpercer la main, bon sang de bois !";
        map["I think we need to stop playing this game, Byron!"] = "Je crois qu'on doit arrêter de jouer à ce jeu, Byron !";
        map["So...does that mean I win?"] = "Alors... est-ce que ça veut dire que j'ai gagné ?";
        map["You got me on a technicality, but it's fair dinkum."] = "Tu m'as eu sur un coup du sort, mais c'est réglo.";
        map["Fix the man's horn, he's won it fair and square."] = "Répare son cornet, il l'a gagné à la loyale.";
        map["Fine, give it here. I'll replace the reed."] = "Bon, donne-le-moi. Je vais changer l'anche.";
        map["There we go."] = "Et voilà le travail.";
        map["Most appreciated."] = "C'est des plus appréciables.";
        map["Right, I think we should call it quits for now."] = "Bien, je crois qu'on ferait mieux d'en rester là.";

        // Bartender Chapter 4
        map["Did Mr Liu come back in here?"] = "M. Liu est-il revenu par ici ?";
        map["Jian? He was here earlier, but didn't stay long."] = "Jian ? Il était là tout à l'heure, mais il n'est pas resté longtemps.";
        map["Seemed to ask a lot of questions about Lady Unterwald."] = "Il avait l'air de poser un tas de questions sur Lady Unterwald.";
        map["What kind of questions?"] = "Quel genre de questions ?";
        map["Her likes, dislikes, that kind of thing."] = "Ses goûts, ce qu'elle déteste, ce genre de détails.";
        map["Between you and me, I think he's smitten!"] = "Entre vous et moi, je crois qu'il est tombé sous le charme !";
        map["Yeah I saw him, he seemed pretty annoyed."] = "Oui je l'ai vu, il avait l'air passablement énervé.";
        map["He had the doctor in tow, I think he was trying to calm Jian down."] = "Il traînait le docteur avec lui, je crois qu'il essayait de calmer Jian.";
        map["They went down the carriage, towards Lady Unterwald's quarters."] = "Ils sont descendus le long du wagon, en direction des quartiers de Lady Unterwald.";

        // Hirsch & The Order
        map["What can you tell me about the missing idol?"] = "Que pouvez-vous me dire sur l'idole disparue ?";
        map["It's modelled after Lady Unterwald's own hands, I remember that much."] = "Elle est modelée d'après les mains de Lady Unterwald en personne, voilà tout ce dont je me souviens.";
        map["We haven't convened a formal meeting for some time, but I'm sure it'll turn up!"] = "Nous n'avons pas tenu d'assemblée formelle depuis un bail, mais elle finira bien par réapparaître !";
        map["Is there anything else you can tell me about the missing idol?"] = "Y a-t-il autre chose que vous puissiez me confier sur cette idole ?";
        map["Let's see. I remember the idol feeling heavy in my hands."] = "Voyons voir. Je me souviens qu'elle était particulièrement lourde en main.";
        map["There was definitely some weight to it!"] = "Elle pesait assurément son pesant d'or !";
        map["Is this the hand idol you were looking for?"] = "Est-ce bien l'idole que vous cherchiez ?";
        map["I believe that might be it! Hand it over to the fine gentlemen at the table."] = "Je crois bien que c'est elle ! Remettez-la à ces braves messieurs à la table.";
        map["What is this place, exactly?"] = "Quel est cet endroit, exactement ?";
        map["We are... THE ORDER OF IDLE HANDS."] = "Nous sommes... L'ORDRE DES MAINS INACTIVES.";
        map["The name is appropriate. You can't get anything done!"] = "Le nom est bien choisi : vous ne foutez jamais rien !";
        map["Now, now, Mr Liu. We're all trying our best."] = "Allons, allons, monsieur Liu. Nous faisons tous de notre mieux.";
        map["The Order Of Idle Hands?"] = "L'Ordre des Mains Inactives ?";
        map["Think of us as the guiding hand of the Unterwald empire."] = "Considérez-nous comme la main bienveillante qui guide l'empire Unterwald.";
        map["Listen, I don't do cults. Not again, not after last time."] = "Écoutez, je ne trempe pas dans les sectes. Plus jamais, pas après la dernière fois.";
        map["We exist only to protect Lady Unterwald's interests, and actively work to keep things running smoothly."] = "Notre seul but est de veiller aux intérêts de Lady Unterwald et d'assurer la bonne marche des affaires.";
        map["I see. It all seems a bit... theatrical?"] = "Je vois. Tout cela semble un brin... théâtral ?";
        map["Yes, well... admittedly, we might have got a bit carried away."] = "Oui, bon... il est vrai qu'on s'est peut-être un peu laissé emporter.";
        map["What does Lady Unterwald think of the Order?"] = "Qu'en pense Lady Unterwald ?";
        map["We decided it would be best if Lady Unterwald stayed unaware of our activities."] = "Nous avons estimé préférable qu'elle ignore tout de nos agissements.";
        map["Don't you think all this subterfuge risks undermining her?"] = "Ne craignez-vous pas que ces manigances ne finissent par lui nuire ?";
        map["I want to be clear that Lady Unterwald still runs the show, we only wish to point her in the right direction."] = "Qu'il soit bien clair que Lady Unterwald reste seule maîtresse à bord ; nous nous contentons de lui montrer la voie.";
        map["I took a risk bringing you here, detective. I trust that you can be discreet? For all our sakes?"] = "J'ai pris un risque en vous introduisant ici, détective. J'ose espérer que vous saurez tenir votre langue, dans notre intérêt à tous ?";
        map["What's Jian Liu doing here?"] = "Que fabrique Jian Liu par ici ?";
        map["Jian is one of us, or at least he was. I thought he'd left our order some time ago."] = "Jian fait partie des nôtres, ou du moins il en faisait partie. Je croyais qu'il avait quitté nos rangs depuis longtemps.";
        map["Regardless, he's called for a formal meeting and we must abide."] = "Quoi qu'il en soit, il a réclamé une assemblée formelle et nous devons nous y plier.";
        map["Never mind!"] = "Laissez tomber !";
        map["See you around, detective."] = "Au plaisir de vous croiser, détective.";

        // Lady Unterwald Chapter 4
        map["How can I get into Arthur's quarters?"] = "Comment puis-je entrer dans la cabine d'Arthur ?";
        map["Hm, maybe I shouldn't entrust such an important task to you."] = "Hmm, peut-être n'aurais-je pas dû vous confier une tâche d'une telle importance.";
        map["I can do it, I just need a gentle reminder!"] = "Je peux le faire, j'ai simplement besoin d'un petit rappel !";
        map["There's a fusebox in the sleeper carriage. You might be able to lure him out that way!"] = "Il y a une boîte à fusibles dans le wagon-lits. Vous pourriez l'attirer dehors par ce moyen !";
        map["Understood!"] = "Bien compris !";
        map["And try to be discreet, will you? For heaven's sake."] = "Et tâchez d'être discret, bon sang de bois !";
        map["This seems rather underhanded, perhaps we should just come clean?"] = "Tout ceci me paraît bien sournois. Ne devrions-nous pas simplement avouer la vérité ?";
        map["Don't you start getting all soft on me now, detective!"] = "Ne commencez pas à vous dégonfler maintenant, détective !";
        map["It's a temporary measure, we just need to tie up these loose ends."] = "C'est un arrangement provisoire, nous devons juste régler ces quelques détails.";
        map["What about Jian's contact, aren't they going to be suspicious?"] = "Et le contact de Jian, ne va-t-elle pas avoir des soupçons ?";
        map["If you do your job properly, she'll be none the wiser!"] = "Si vous faites votre boulot correctement, elle n'y verra que du feu !";
        map["I'm not so sure about this, Lady Unterwald!"] = "Je n'en suis pas si convaincu, Lady Unterwald !";
        map["You keep your mouth closed about this, Herman!"] = "Vous gardez le silence absolu là-dessus, Herman !";
        map["Whatever your feelings on the matter, we don't know who's listening!"] = "Quels que soient vos états d'âme, nous ignorons qui écoute aux portes !";
        map["It was an accident, you have to believe me!"] = "C'était un pur accident, vous devez me croire !";
        map["Do you think the authorities would find your story believable?"] = "Pensez-vous sincèrement que les autorités goberaient une telle histoire ?";
        map["Hm, perhaps not."] = "Hm, sans doute pas.";
        map["I think I should get on with it."] = "Je crois que je devrais m'y mettre.";
        map["Make sure you get the job done!"] = "Assurez-vous de mener la mission à bien !";

        // Susanne Chapter 4
        map["What's next for Balboa Swing?"] = "Quel est l'avenir pour Balboa Swing ?";
        map["Hmm. I don't put an awful lot of faith in planning, myself."] = "Hmm. Je ne fais pas grand cas des plans d'avenir, personnellement.";
        map["More often than not it seems you'll just end up disappointed."] = "La plupart du temps, on ne récolte que des déceptions.";
        map["I'm happy to keep making hay while the sun shines."] = "Je préfère battre le fer tant qu'il est chaud et vivre au jour le jour.";
        map["Could you have a look at this horn? It's broken."] = "Pourriez-vous examiner ce cornet ? Il est abîmé.";
        map["I wouldn't know anything about that, you'd be better off asking the band."] = "Je n'y connais rien du tout, vous feriez mieux de demander aux musiciens.";
        map["I really need that mouthpiece!"] = "J'ai un besoin impératif de cet embout !";
        map["You're not winning on skill alone, looks like you'll need to elevate your chances!"] = "Tu ne gagneras pas au talent pur, on dirait bien qu'il va falloir forcer un peu la chance !";
        map["Do you think you could put in a good word for me with Beverly Moore?"] = "Pensez-vous pouvoir glisser un mot en ma faveur auprès de Beverly Moore ?";
        map["I can certainly try!"] = "Je peux toujours essayer !";
        map["She's not so easily persuaded, I think she prefers to go with her gut."] = "Elle n'est pas facile à convaincre, elle marche plutôt au coup de cœur.";
        map["Are you going to sing yet?"] = "Allez-vous enfin chanter ?";
        map["I'll sing alright, but I need my boys on stage with me."] = "Je chanterai bien volontiers, mais j'ai besoin de mes musiciens sur scène.";
        map["Sorry Suze, we're still fuming about our missing set list!"] = "Désolé Suze, on est toujours furax pour notre liste de morceaux volée !";
        map["Do you think you'll return to the stage soon?"] = "Pensez-vous remonter sur scène d'ici peu ?";
        map["Sorry Suze, we're still working out this new song!"] = "Désolé Suze, on est encore en train de peaufiner notre nouveau morceau !";

        // Write output TSV
        int count = 0;
        using (var sw = new StreamWriter(@"translations\partitions\c4_french.tsv", false, Encoding.UTF8)) {
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
                    Console.WriteLine("Missing in map: [" + en + "]");
                    fr = en;
                }
                sw.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", p[0], p[1], en, fr, p[4], p[5]));
                if (!string.IsNullOrEmpty(fr)) count++;
            }
        }
        Console.WriteLine(string.Format("Generated c4_french.tsv: {0} lines processed out of {1}", count, lines.Length - 1));
    }
}
