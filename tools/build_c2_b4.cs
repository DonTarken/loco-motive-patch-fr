using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class BuildC2B4 {
    static void Main() {
        string rawPath = @"translations\partitions\c2_b4_handshake_chefs.tsv";
        if (!File.Exists(rawPath)) {
            Console.WriteLine("File not found: " + rawPath);
            return;
        }

        var lines = File.ReadAllLines(rawPath, Encoding.UTF8);
        var map = new Dictionary<string, string>();

        // Handshake Club - Brian
        map["Brian, isn't it?"] = "Brian, c'est bien ça ?";
        map["What's it to you, Outsider?"] = "Qu'est-ce que ça peut vous faire, l'Intrus ?";
        map["Outsider?"] = "L'Intrus ?";
        map["Did you gain entry to our sanctum honourably, with the five-fingered handshake of formality?"] = "Avez-vous pénétré dans notre sanctuaire avec honneur, en accomplissant la poignée de main protocolaire à cinq doigts ?";
        map["I think I was unconscious when the doctor dragged me in here."] = "Je crois bien que j'étais inconscient quand le docteur m'a traîné ici.";
        map["Well, that makes you an outsider!"] = "Eh bien, cela fait de vous un intrus !";
        map["Hello, Brian"] = "Bonjour, Brian.";
        map["Yes, Outsider?"] = "Oui, l'Intrus ?";
        map["What are all these idols for, anyway?"] = "À quoi servent toutes ces idoles, au juste ?";
        map["Each one of these idols has a purpose, we use them to keep things orderly."] = "Chacune de ces idoles a un rôle précis. Nous les utilisons pour maintenir l'ordre.";
        map["We have strict protocols, and we follow the rules here, something an outsider like you wouldn't know about, of course."] = "Nous avons des protocoles stricts et nous respectons les règles ici. Ce qu'un intrus comme vous ne saurait comprendre, évidemment.";
        map["What's all this talk of a handshake?"] = "Pourquoi tout le monde parle de cette poignée de main ?";
        map["You don't know about the handshake?"] = "Vous ignorez tout de la poignée de main ?";
        map["What is the point of me guarding that curtain all day, if they're going to let people in who don't even know about the handshake?"] = "À quoi bon passer mes journées à monter la garde devant ce rideau si on laisse entrer des gens qui ne connaissent même pas la poignée de main ?";
        map["If you taught me the handshake, would I still be an outsider?"] = "Si vous m'appreniez la poignée de main, est-ce que je serais toujours un intrus ?";
        map["Well, the handshake gets changed every few hours. Besides, you're here now."] = "Eh bien, la poignée de main change toutes les deux heures. Et puis, vous êtes déjà là.";
        map["Are you sure you don't want to teach me the handshake?"] = "Vous êtes sûr de ne pas vouloir me l'enseigner ?";
        map["They'll just change it in a few hours, I'd rather not waste my time."] = "Ils vont la changer d'ici peu, je préfère ne pas perdre mon temps.";
        map["I heard you're the Keeper Of Idols? I need a specific one."] = "J'ai cru comprendre que vous étiez le Gardien des Idoles ? J'en cherche une bien précise.";
        map["Look, there are a lot of idols back here."] = "Écoutez, il y a un paquet d'idoles là-derrière.";
        map["If you can narrow it down, I might be able to find what you're looking for."] = "Si vous pouvez être plus précis, je pourrai peut-être trouver ce que vous cherchez.";
        map["Any luck finding that idol? I'm still looking for it."] = "Du nouveau pour cette idole ? Je la cherche toujours.";
        map["Like I said, we've got a lot of idols back here."] = "Comme je l'ai dit, on a énormément d'idoles là-derrière.";
        map["I'm surprised you haven't sided with Mr Liu."] = "Je m'étonne que vous n'ayez pas pris le parti de M. Liu.";
        map["Really? I don't think it's all that surprising."] = "Vraiment ? Je ne trouve pas cela si surprenant.";
        map["I don't agree with his methodology, simple as that."] = "Je désapprouve sa méthodologie, c'est aussi simple que cela.";
        map["Besides, he left The Order! He doesn't get to dictate the rules to us now."] = "Et puis, il a quitté l'Ordre ! Il n'a plus aucun droit de nous dicter sa loi.";
        map["Mr Liu seemed fairly upset back there."] = "M. Liu avait l'air plutôt contrarié tout à l'heure.";
        map["Ah, I wouldn't read too much into it."] = "Bah, je n'y prêterais pas trop attention.";
        map["You're not concerned?"] = "Ça ne vous inquiète pas ?";
        map["He's probably just gone off to sulk somewhere."] = "Il est sans doute juste parti bouder dans son coin.";
        map["I have to go."] = "Je dois filer.";
        map["I'll be keeping an eye on you, Outsider."] = "Je garde un œil sur vous, l'Intrus.";
        map["That's all the help I need right now."] = "C'est tout ce dont j'ai besoin pour l'instant.";

        // Handshake Club - Jared
        map["Jared, is it?"] = "Jared, n'est-ce pas ?";
        map["Brother Jared, Custodian of the Silken Palms."] = "Frère Jared, Gardien des Paumes Soyeuses.";
        map["I'm entitled to a little respect around here, thank you very much."] = "J'ai droit à un minimum de respect ici, je vous signale.";
        map["What does a Custodian of the Silken Palms do?"] = "En quoi consiste la charge d'un Gardien des Paumes Soyeuses ?";
        map["It's my job, nay, my sacred duty to ensure that all members' hands are thoroughly moisturised."] = "C'est mon travail, que dis-je, mon devoir sacré de veiller à ce que les mains de chaque membre soient parfaitement hydratées.";
        map["I wish I could unhear that information."] = "J'aimerais tellement pouvoir effacer cette information de ma mémoire.";
        map["As you can tell, it's not a duty I take lightly. Nothing but moist palms, all round!"] = "Comme vous le voyez, c'est une mission que je prends très au sérieux. Que des paumes bien moites, partout !";
        map["Please, stop saying moist."] = "De grâce, arrêtez d'utiliser le mot « moite ».";
        map["How'd you get roped into joining this secret society?"] = "Comment vous êtes-vous retrouvé embrigadé dans cette société secrète ?";
        map["I was in it originally to help keep the company on track, you know?"] = "À l'origine, j'ai rejoint pour aider l'entreprise à garder le cap, vous voyez ?";
        map["But over time, we got a bit hung up on the ‘helping hands' theme."] = "Mais avec le temps, on s'est un peu trop focalisés sur le concept des « mains tendues ».";
        map["You're saying it all got rather heavy-handed."] = "Vous voulez dire que vous avez eu la main lourde.";
        map["Exactly! Next thing I know, we're talking secret handshakes, the best hand creams, cuticle care... the works!"] = "Exactement ! Et sans crier gare, on en est venus aux poignées de main secrètes, aux meilleures crèmes hydratantes, aux cuticules... la totale !";
        map["I'm way too far down this rabbit hole to climb out now."] = "Je suis tombé bien trop profondément dans cet engrenage pour en ressortir.";
        map["I have some questions about the hand idol."] = "J'ai quelques questions à propos de l'idole en forme de main.";
        map["Of course, I'll try to help as best I can."] = "Bien sûr, je ferai de mon mieux pour vous éclairer.";
        map["Do you remember what the idol was made of?"] = "Vous souvenez-vous du matériau dans lequel l'idole est faite ?";
        map["Oh, you mean the Lady Unterwald idol?"] = "Oh, vous parlez de l'idole de Lady Unterwald ?";
        map["Well, it was definitely silver. Or was it solid gold?"] = "Eh bien, c'était de l'argent, c'est sûr. Ou alors de l'or massif ?";
        map["Oh dear, it's been too long, I'm afraid!"] = "Grand Dieu, cela fait bien trop longtemps, j'en ai peur !";
        map["Can you recall what gesture the idol was making?"] = "Vous rappelez-vous quel geste faisait la main ?";
        map["Well, it was certainly a hand gesture..."] = "Eh bien, c'était indubitablement un geste de la main...";
        map["Can you recall any specifics?"] = "Pouvez-vous être un tout petit peu plus précis ?";
        map["Sorry, pal. If you moisturise enough hands, they all kind of blur together!"] = "Désolé, l'ami. Quand on hydrate autant de mains que moi, elles finissent toutes par se ressembler !";
        map["Was there a quote on the idol?"] = "Y avait-il une citation gravée sur l'idole ?";
        map["A quote? Yes, there was definitely something sentimental about it."] = "Une citation ? Oui, il y avait indéniablement une formule sentimentale.";
        map["Sorry I couldn't be more helpful."] = "Désolé de ne pas pouvoir vous aider davantage.";
        map["What's Mr Liu so impatient about?"] = "Pourquoi M. Liu est-il si impatient ?";
        map["Oh, don't mind him. He just expects everything to go his way all the time!"] = "Oh, ne faites pas attention. Il exige toujours que tout tourne autour de sa personne !";
        map["Jian is a man of action, but we have processes in place for a reason!"] = "Jian est un homme d'action, mais nos procédures existent pour une bonne raison !";
        map["I thought Jian raised some rather urgent points."] = "Jian a pourtant soulevé des points plutôt urgents.";
        map["I agree, but we can't go barrelling in there and meddling with Lady Unterwald's affairs."] = "Je suis d'accord, mais on ne peut pas débarquer comme des brutes et fourrer notre nez dans les affaires de Lady Unterwald.";
        map["It's much better to take a deliberate, more thought out approach."] = "Il est bien plus sage d'adopter une démarche mesurée et réfléchie.";
        map["It seems the voting has stalled. Any ideas?"] = "Le vote semble dans l'impasse. Une suggestion ?";
        map["We'll need a coherent answer out of Mr Masson in order to break the deadlock."] = "Il nous faudra une réponse cohérente de M. Masson pour débloquer la situation.";
        map["Perhaps you can persuade him in some way?"] = "Peut-être pourriez-vous trouver un moyen de le convaincre ?";
        map["Talk to you later, I have to go..."] = "On se reparle plus tard, je dois m'en aller...";

        // Handshake Club - Leader & Gretchen
        map["Ah, our latest recruit. Putting yourself to good use?"] = "Ah, notre dernière recrue ! Vous vous rendez utile ?";
        map["What do you think of the place? Pretty cool, huh?"] = "Alors, que pensez-vous de cet endroit ? Pas mal, hein ?";
        map["The name's Gretchen. I'm in charge of all the itinerary!"] = "Moi c'est Gretchen. Je gère l'intégralité du planning !";
        map["What can you tell me about the Keeper of Many Idols?"] = "Que pouvez-vous me dire sur le Gardien des Idoles ?";
        map["Brother Brian? He has a good eye for detail."] = "Frère Brian ? Il a un sens aigu du détail.";
        map["We put him on security most nights, he seems to enjoy it."] = "On le met à la sécurité la plupart des soirs, il a l'air d'apprécier.";
        map["We like to keep him busy, you see."] = "On aime bien l'occuper, voyez-vous.";
        map["How'd you end up as the leader of a secret society?"] = "Comment vous êtes-vous retrouvé à la tête d'une société secrète ?";
        map["Same as all the other secret societies. We took a vote!"] = "Comme dans toutes les sociétés secrètes : on a voté !";
        map["Fire away!"] = "Je vous écoute !";
        map["Hmm, let me think."] = "Hmm, laissez-moi réfléchir.";
        map["Some sort of metal, was it? No, that's not right."] = "Une sorte de métal, n'est-ce pas ? Non, ce n'est pas ça.";
        map["You know, the same guy who made the idol also sculpted the Unterwald busts."] = "Vous savez, le même type qui a fabriqué l'idole a aussi sculpté les bustes Unterwald.";
        map["You mean the statues I've seen around the train?"] = "Vous voulez parler des statues réparties dans le train ?";
        map["I wouldn't be surprised if they used the same material!"] = "Ça ne m'étonnerait pas du tout qu'ils aient utilisé le même matériau !";
        map["Ah, I remember it being a majestic pose."] = "Ah, je me souviens d'une posture majestueuse.";
        map["I always thought it captured Lady Unterwald perfectly."] = "J'ai toujours trouvé qu'elle incarnait parfaitement Lady Unterwald.";
        map["I don't suppose you remember the quote on the idol?"] = "J'imagine que vous ne vous rappelez pas de la citation sur l'idole ?";
        map["Hmm, I think it was something sappy. Was it something about family?"] = "Hmm, je crois que c'était un truc à l'eau de rose. Quelque chose sur la famille ?";
        map["Very well, anything else?"] = "Très bien, autre chose ?";
        map["Aren't you worried about Mr Liu?"] = "M. Liu ne vous inquiète pas ?";
        map["He did seem pretty irate, I hope he doesn't do anything rash."] = "Il avait l'air passablement furieux, j'espère qu'il ne commettra pas d'imprudence.";
        map["I should be leaving now."] = "Je devrais m'en aller.";
        map["Farewell!"] = "Adieu !";

        // Sister Gretchen
        map["You need an itinerary? What does that entail?"] = "Vous avez besoin d'un planning ? Qu'est-ce que cela implique ?";
        map["Oh my goodness, what doesn't it entail?"] = "Bonté divine, qu'est-ce que ça n'implique pas !";
        map["There's the two-hour all-hands meeting on the candles, somebody's got to maintain the weekly rota for the plumping up of the sofa cushions, and I didn't even mention the five-fingered handshake of formality."] = "Il y a la réunion générale de deux heures sur les bougies, le tableau de roulement hebdomadaire pour regonfler les coussins du canapé, et je ne vous parle même pas de la poignée de main protocolaire à cinq doigts.";
        map["We change that twice daily, you know!"] = "On la change deux fois par jour, je vous ferais dire !";
        map["So, wait a second. You just spend all your time in meetings?"] = "Attendez une seconde... Vous passez littéralement tout votre temps en réunion ?";
        map["You really think we should just light up a bunch of candles without having a long meeting about it beforehand?"] = "Vous croyez sincèrement qu'on peut allumer des bougies sans une longue concertation préalable ?";
        map["Has everyone rolled up their sleeves? What's the consistency of the wax? Are we absolutely sure there's nothing flammable nearby?"] = "Tout le monde a-t-il retroussé ses manches ? Quelle est la consistance de la cire ? A-t-on la certitude qu'aucun objet inflammable ne traîne à proximité ?";
        map["How'd you end up in the Order of Idle Hands?"] = "Comment avez-vous atterri dans l'Ordre des Mains Inactives ?";
        map["Honestly, when I got here, there was no structure at all. I mostly joined out of pity."] = "Honnêtement, à mon arrivée, il n'y avait aucune organisation. J'ai surtout rejoint par pitié.";
        map["I've got a production background, so if there's a chart or a spreadsheet involved, sign me up!"] = "J'ai un passé dans la gestion de production, alors dès qu'il y a un tableau ou un graphique, je réponds présente !";
        map["I also double as the fire marshal, can't be too careful around all these open flames!"] = "Et je fais aussi office d'officier de sécurité incendie. On n'est jamais trop prudent avec toutes ces flammes nues !";
        map["Indeed!"] = "En effet !";
        map["Mr Liu seems quite irate at The Order. What happened?"] = "M. Liu semble très remonté contre l'Ordre. Que s'est-il passé ?";
        map["Oh, he's probably just stewing over the sandwiches we'd bring in for lunch."] = "Oh, il rumine sûrement encore à propos des sandwichs qu'on apportait pour le déjeuner.";
        map["You know, those mini sandwiches with the crusts cut off?"] = "Vous savez, ces petits canapés dont on a coupé la croûte ?";
        map["He couldn't stand them!"] = "Il ne pouvait pas les encadrer !";
        map["Mr Liu disagreed with you over sandwiches?"] = "M. Liu a rompu les ponts à cause de sandwichs ?";
        map["It's not like I made them personally, but you should have heard him!"] = "Ce n'est pas comme si je les avais préparés moi-même, mais vous auriez dû l'entendre !";
        map["“It ruins the structural integrity of the sandwich, Gretchen!”"] = "« Ça détruit l'intégrité structurelle du sandwich, Gretchen ! »";
        map["“That's where all the flavour and texture is, Gretchen!”"] = "« C'est là que résident toute la saveur et la texture, Gretchen ! »";
        map["It was all downhill from there, really."] = "Après ça, tout est parti à vau-l'eau.";
        map["I have some questions about the missing hand idol."] = "J'ai quelques questions au sujet de l'idole en forme de main manquante.";
        map["Hmm, the idol..."] = "Hmm, l'idole...";
        map["The Unterwald idol was pretty fancy, but I couldn't tell you what it was made of."] = "L'idole d'Unterwald était assez chic, mais incapable de vous dire en quoi elle était faite.";
        map["I don't remember it being an offensive gesture. Does that help?"] = "Je me souviens que ce n'était pas un geste obscène. Ça vous aide ?";
        map["I suppose it narrows it down."] = "J'imagine que ça réduit les possibilités.";
        map["There was! It was something involving the Unterwalds."] = "Oui, il y en avait une ! Quelque chose en rapport avec les Unterwald.";
        map["Why aren't you voting for direct action?"] = "Pourquoi ne votez-vous pas pour une action directe ?";
        map["We can't go rushing around, meddling in Lady Unterwald's affairs!"] = "On ne peut pas foncer tête baissée et s'ingérer dans les affaires de Lady Unterwald !";
        map["There are long-established, extremely slow processes we must abide by."] = "Il y a des processus historiques d'une lenteur exquise auxquels nous devons nous conformer.";
        map["Is the vote still deadlocked?"] = "Le scrutin est toujours bloqué ?";
        map["Rules are rules, we can't do anything until everyone here has cast their vote."] = "Le règlement est formel : rien ne bougera tant que tout le monde n'aura pas voté.";
        map["But we can call another vote at any time?"] = "Mais on peut relancer un vote à tout moment ?";
        map["Of course, anyone present can request another vote."] = "Évidemment, n'importe quel membre présent peut réclamer un nouveau scrutin.";
        map["You'll just need to ask the leader."] = "Il vous suffit de vous adresser au dirigeant.";
        map["I should go."] = "Je devrais y aller.";

        // Handshake Club Scene (Injured Herman waking up)
        map["Hold on, gentlemen, I think he's coming round."] = "Un instant, messieurs, je crois qu'il reprend connaissance.";
        map["Wh-what happened?"] = "Qu... que s'est-il passé ?";
        map["His Hand!"] = "Sa main !";
        map["Poor thing!"] = "Mon pauvre ami !";
        map["Not to worry, though! I brought you to the experts. We managed to get you all patched up."] = "Ne vous en faites pas ! Je vous ai amené chez des spécialistes. On a réussi à vous rafistoler.";
        map["Here, take this hand cream. It's the good stuff. Loosens any cramps right up."] = "Tenez, prenez cette crème pour les mains. De la première qualité. Ça détend n'importe quelle crampe.";
        map["It also moisturises!"] = "Et ça hydrate, en plus !";
        map["Where am I?"] = "Où suis-je ?";
        map["No need to fret, Herman. You're in safe hands here."] = "Pas d'inquiétude, Herman. Vous êtes entre de bonnes mains.";
        map["Although the members need their table back, there's a meeting starting soon."] = "Même si les membres ont besoin de récupérer leur table, une réunion commence bientôt.";
        map["Everyone, our meeting can now commence!"] = "Tout le monde, notre assemblée peut commencer !";
        map["At last! I have much to discuss with you."] = "Enfin ! J'ai beaucoup de choses à vous dire.";
        map["Hold on, where's the hand idol?"] = "Une minute, où est l'idole de main ?";
        map["You know, the hand idol we use to signify that it's our turn to speak!"] = "Vous savez, l'idole qui indique à qui le tour de prendre la parole !";
        map["SILENCE!"] = "SILENCE !";
        map["Sorry! I'm getting ahead of myself."] = "Pardon ! Je m'emballe.";
        map["Brother Jared speaks the truth. We cannot proceed without the hand idol."] = "Frère Jared dit vrai. Nous ne pouvons délibérer sans l'idole de main.";
        map["It's bound to turn up somewhere, it couldn't have gone far!"] = "Elle va forcément réapparaître, elle n'a pas pu s'envoler !";
        map["I really must insist we press on. This issue with Lady Unterwald, it cannot wait!"] = "J'insiste vigoureusement pour que nous avancions. Cette histoire avec Lady Unterwald ne peut pas attendre !";
        map["We must be patient, Jian. The hand works in mysterious ways."] = "Soyons patients, Jian. Les voies de la main sont impénétrables.";
        map["That's right."] = "Parfaitement.";
        map["So, you're all going to sit here and do nothing?"] = "Alors vous allez tous rester assis là à vous tourner les pouces ?";
        map["You know, I'm quite good at finding things. I may be able to assist?"] = "Vous savez, je suis plutôt doué pour retrouver les objets égarés. Je pourrais vous aider ?";
        map["Yes, that would be most appreciated!"] = "Oui, ce serait des plus appréciables !";
        map["Oh! We could ask the Keeper of Many Idols!"] = "Oh ! Nous pourrions demander au Gardien des Idoles !";
        map["That's a grand idea!"] = "Quelle excellente idée !";
        map["Are you there, Keeper Of Many Idols?"] = "Es-tu là, Gardien des Idoles ?";
        map["KEEPER OF MANY IDOLS? Are you there?"] = "GARDIEN DES IDOLES ? Es-tu là ?";
        map["BRIAN!"] = "BRIAN !";
        map["Yes?"] = "Oui ?";
        map["I shall enquire with Brian, the Keeper Of Many Idols."] = "Je m'en vais interroger Brian, le Gardien des Idoles.";
        map["This is the work of that meddling murine, no question."] = "C'est l'œuvre de ce satané rongeur, aucun doute là-dessus.";

        // Kitchen carriage - Antoine
        map["AAAAAAAAAAAAUUGGHH!"] = "AAAAAAAAAAAAAAARGH !";
        map["Fiammetta, what have you done!"] = "Fiammetta, qu'as-tu fait !";
        map["*gurgle*"] = "*glouglou*";
        map["Any tips on catching that mouse?"] = "Un conseil pour attraper cette souris ?";
        map["It won't be easy, attorney. That little devil has shortcuts everywhere."] = "Ce ne sera pas une mince affaire, l'avocat. Ce petit démon a des passages secrets partout.";
        map["We tried to plug them all up, but there's too many!"] = "On a essayé de tous les boucher, mais il y en a trop !";
        map["Good news, I've apprehended that mouse!"] = "Bonne nouvelle, j'ai coffré cette souris !";
        map["What should I do with this mouse?"] = "Que dois-je faire de cette souris ?";
        map["Give it here, attorney."] = "Donnez-la-moi, l'avocat.";
        map["No one lays a whisker on Fiametta without facing consequences!"] = "Personne ne touche à un cheveu de Fiammetta sans en payer le prix !";
        map["Hmm I think I'll hang onto her for now."] = "Hmm, je crois que je vais la garder avec moi pour le moment.";
        map["It's your funeral, attorney."] = "C'est vous qui voyez, l'avocat.";
        map["Any chance of a tour of the kitchen?"] = "Une chance d'avoir une visite guidée des fourneaux ?";
        map["A tour? I'm afraid a tour of the kitchen will have to wait."] = "Une visite ? J'ai bien peur que la visite des cuisines doive attendre.";
        map["The timing right now? It's not ideal."] = "Le timing actuel ? Pas franchement idéal.";
        map["Oh, that's okay."] = "Oh, ce n'est rien.";
        map["Ahh, you twist my arm, attorney. Of course, I'll give you a tour!"] = "Ah, vous me prenez par les sentiments, l'avocat. Bien sûr que je vais vous faire faire le tour du propriétaire !";
        map["Come closer, and I will show you the star of the show. Fiametta!"] = "Approchez, et je vous présenterai la star des lieux : Fiammetta !";
        map["You should tell me all about Fiametta!"] = "Racontez-moi tout sur Fiammetta !";
        map["You really want to know?"] = "Vous voulez vraiment savoir ?";
        map["No, I'm not sure that you can handle it."] = "Non, je ne suis pas certain que vous ayez les reins assez solides.";
        map["I can handle it, give me the full spiel on Fiametta!"] = "Je gère, dites-moi tout sur Fiammetta !";
        map["Okay, well, you asked for it."] = "Très bien, c'est vous qui l'avez voulu.";
        map["Allow me to introduce you to Fiametta, referred to by her manufacturers as the Easy Chef 500. She comes forged in cast iron steel..."] = "Permettez-moi de vous présenter Fiammetta, désignée par ses fabricants sous le nom d'Easy Chef 500. Forgée dans un acier en fonte pure...";
        map["Fiametta has not one, but two baking ovens! A broiler drawer that's ideal for browning the tops of casseroles, caramelising your meats, or even roasting your vegetables. But that's not all!"] = "Fiammetta ne possède pas un, mais bien deux fours de cuisson ! Un tiroir gril idéal pour gratiner les soufflés, caraméliser les rôtis ou rissoler vos légumes. Mais ce n'est pas tout !";
        map["It's not?!"] = "Ce n'est pas tout ?!";
        map["We're not talking your standard dual cook-top burners, we're not even talking four. Fiametta has six cook-top burners, an upper warming compartment that keeps optimum temperatures for your soups and sauces, and if that wasn't enough, a lower storage drawer for your additional kitchenware."] = "On ne parle pas de vos vulgaires réchauds doubles, ni même de quatre feux. Fiammetta dispose de six brûleurs, d'un chauffe-plat supérieur maintenant vos potages et réductions à température idéale, et cerise sur le gâteau, d'un tiroir inférieur pour la batterie de casseroles.";
        map["Wow!"] = "Impressionnant !";
        map["I assume you've heard about Lady Unterwald?"] = "J'imagine que vous êtes au courant pour Lady Unterwald ?";
        map["Ah, attorney, c'est une tragédie !"] = "Ah, l'avocat, c'est une tragédie !";
        map["It's terrible! We even had to throw away perfectly good ingredients to fit her in the pantry."] = "C'est affreux ! On a même dû jeter d'excellents ingrédients pour lui faire de la place dans le garde-manger.";
        map["Excuse me?"] = "Pardon ?";
        map["You heard me. Don't go snooping around in the freezer, or you'll give yourself a scare."] = "Vous m'avez très bien entendu. N'allez pas fouiner dans la chambre froide, vous risqueriez d'avoir une sacrée frousse.";
        map["Are you saying Lady Unterwald is stored in your freezer?"] = "Êtes-vous en train de me dire que la dépouille de Lady Unterwald est dans votre congélateur ?";
        map["Lady Unterwald needs to be on ice until the authorities can reach us."] = "Lady Unterwald doit rester au frais jusqu'à ce que les autorités puissent nous rejoindre.";
        map["There was no other alternative, attorney!"] = "Il n'y avait aucune autre solution, l'avocat !";
        map["I don't think Lady Unterwald would have approved of your storage methods."] = "Je ne pense pas que Lady Unterwald aurait apprécié vos méthodes de conservation.";
        map["Would you prefer Lady Unterwald to lay where she fell, in front of her paying passengers?"] = "Auriez-vous préféré qu'on la laisse pourrir là où elle est tombée, sous les yeux des passagers de première classe ?";
        map["When you consider the alternative, this is a more dignified resting place, no?"] = "Quand on y songe, c'est un repos éternel bien plus digne, non ?";
        map["I suppose so."] = "J'imagine, oui.";
        map["I should get back to finding that mouse."] = "Je devrais me remettre à la recherche de cette souris.";
        map["Good luck, attorney."] = "Bonne chance, l'avocat.";
        map["I need to go now."] = "Je dois m'en aller.";

        // Kitchen carriage - Francois
        map["Non mais, et puis quoi encore !"] = "Non mais, et puis quoi encore !";
        map["Quoi ! What is it you want? As you can see, we're very busy here."] = "Quoi ! Qu'est-ce que vous voulez ? Vous voyez bien qu'on est débordés, ici !";
        map["Back again? C'est une honte !"] = "Encore vous ? C'est une honte !";
        map["Did you say you had an inspection earlier?"] = "Vous avez parlé d'une inspection tout à l'heure ?";
        map["The health department sent a puny little drone to inspect our premises."] = "Les services sanitaires ont dépêché un minuscule rond-de-cuir pour inspecter nos cuisines.";
        map["If there's anything I detest more than rodents, it's health inspectors."] = "S'il y a bien une chose que j'abhorre encore plus que la vermine, ce sont les inspecteurs de l'hygiène.";
        map["Strutting about as if they rule the roost, they are the real pests!"] = "Se pavanant comme des coqs de basse-cour... Les vrais nuisibles, ce sont eux !";
        map["You mentioned the mouse only steals valuables?"] = "Vous disiez que la souris ne dérobe que les objets de valeur ?";
        map["Indeed, we're down to our last cheese knife."] = "Tout à fait, nous en sommes réduits à notre tout dernier couteau à fromage.";
        map["It's also found a way into our pantry, there must be tunnels everywhere."] = "Elle a aussi dégoté un accès au garde-manger. Il doit y avoir des galeries partout.";
        map["Where do you think that mouse came from, anyway?"] = "D'où peut bien provenir cette souris, à votre avis ?";
        map["It's not uncommon for rodents to sneak aboard a departing train."] = "Il n'est pas rare que des rongeurs montent clandestinement à bord au départ.";
        map["But that mouse? That little devil came from the gates of hell!"] = "Mais cette souris-là ? Ce petit démon a émergé tout droit des portes de l'enfer !";
        map["Tell me more about your rodent problem."] = "Dites-m'en plus sur votre problème de rongeur.";
        map["That creature is no ordinary rodent, it's pure evil."] = "Cette créature n'a rien d'un rongeur ordinaire, c'est l'incarnation du mal.";
        map["Calm down, Remy. Our attorney is on the case!"] = "Du calme, Rémy. Notre avocat est sur le coup !";
        map["Any advice on nabbing that mouse?"] = "Un conseil avisé pour coincer cette bête ?";
        map["I'd try to trap it in an enclosed space."] = "J'essaierais de la piéger dans un espace confiné.";
        map["It won't be so simple, though. That little thief is a professional."] = "Ce ne sera pas de la tarte, cela dit. Cette voleuse est une véritable professionnelle.";
        map["Mind if I have a poke around your kitchen?"] = "Ça vous ennuie si je jette un coup d'œil dans votre cuisine ?";
        map["Poke around?"] = "Jeter un coup d'œil ?";
        map["You may have free rein of the kitchen, but there is to be no poking!"] = "Vous pouvez vous déplacer librement, mais interdiction formelle de trifouiller !";
        map["Good luck, attorney. We're counting on you."] = "Bonne chance, l'avocat. Nous comptons sur vous.";
        map["I'll leave you to it."] = "Je vous laisse travailler.";
        map["Merci, attorney."] = "Merci, l'avocat.";

        // Kitchen carriage - Remy
        map["C-Crawling, scratching, n-n-nibbling!"] = "C-Ça grouille, ça griffe, ç-ç-ça grignote !";
        map["It c-came right for me!"] = "Elle a f-foncé droit sur moi !";
        map["I can't stand their b-beady little eyes!"] = "Je n-ne supporte pas leurs petits yeux globuleux !";
        map["Don't let it n-near me!"] = "Ne la laissez pas m-m'approcher !";
        map["Those t-teeth!"] = "Ces d-dents !";
        map["Ahh! I c-can't get it out of my mind!"] = "Aaah ! Impossible de m-me l'enlever de la tête !";
        map["T-Their worm-like tail. It was h-horrible!"] = "L-Leur queue de ver de terre... C'était h-horrible !";
        map["We're in the middle of dinner prep. What is it?"] = "On est en plein coup de feu pour le dîner. Qu'y a-t-il ?";
        map["Pour qui tu te prends ! What is it you want?"] = "Pour qui tu te prends ! Qu'est-ce que vous voulez ?";
        map["Pardon?"] = "Pardon ?";
        map["He says you're pushing your luck! What is it you want?"] = "Il dit que vous poussez le bouchon un peu loin ! Qu'est-ce que vous voulez ?";
        map["It's out there... watching us, plotting its next attack."] = "Elle est là dehors... à nous guetter, à fomenter sa prochaine attaque.";
        map["What's making you so jittery?"] = "Qu'est-ce qui vous rend aussi fébrile ?";
        map["That creature is out there... watching us, plotting its next attack."] = "Cette créature est dehors... à nous observer, à préparer son prochain assaut.";
        map["Ugh, the mere thought of it makes my skin crawl!"] = "Pouah, rien que d'y penser, j'en ai la chair de poule !";
        map["I'll bet that mouse is just as scared of you, as you are of it!"] = "Je parie que cette souris a tout aussi peur de vous que vous d'elle !";
        map["Please don't say that word! You're making me itch!"] = "Pitié, ne prononcez pas ce mot ! Ça me gratte partout !";
        map["Are you feeling a bit more at ease now?"] = "Vous vous sentez un peu plus rasséréné maintenant ?";
        map["Knowing that vile beast is safely contained is a big weight off my mind."] = "Savoir cette vile créature hors d'état de nuire m'enlève un poids gigantesque.";
        map["I cannot thank you enough, attorney."] = "Je ne saurais trop vous remercier, l'avocat.";
        map["Any advice for capturing that mouse?"] = "Un conseil pour mettre la main sur cette souris ?";
        map["D-don't try to touch it with your bare hands, they c-can be extremely vicious."] = "N-N'essayez surtout pas de l'attraper à mains nues, elles p-peuvent être particulièrement féroces.";
        map["Beware of the bite, got it."] = "Gare aux morsures, bien reçu.";
        map["Ugh, you just reminded me of those horrible gnawing teeth."] = "Beurk, vous venez de me rappeler ces atroces incisives acérées.";
        map["I'm feeling nauseous just thinking about it!"] = "J'en ai des hauts-le-cœur rien que d'y penser !";
        map["I don't care what you do, as long as you keep it far away from me!"] = "Faites ce que vous voulez, pourvu que vous la gardiez le plus loin possible de moi !";
        map["Tell me, what's your role in the kitchen?"] = "Dites-moi, quel est votre rôle dans ces cuisines ?";
        map["As the Entremétier, it's my job to prepare the entrées."] = "En tant qu'entremétier, c'est à moi qu'incombe la préparation des entrées.";
        map["Between you and me, I think I was only hired to help François with his palate problem."] = "Entre nous, je crois bien que je n'ai été embauché que pour pallier le problème de palais de François.";
        map["There's a problem with the head chef's palate?"] = "Le chef de cuisine a un problème de palais ?";
        map["Oui, I'm afraid his taste is as dull as dishwater!"] = "Oui, j'ai bien peur que ses papilles soient aussi fades que de l'eau de vaisselle !";
        map["Don't speak a word of this to anyone, I'm afraid he's quite sensitive about it."] = "N'en soufflez mot à personne, il est d'une susceptibilité maladive à ce sujet.";
        map["You taste all the food before it leaves the kitchen?"] = "Vous goûtez tous les plats avant qu'ils ne partent en salle ?";
        map["I'm supposed to, but how can I taste anything with that rodent running around?"] = "C'est ce qui est prévu, mais comment voulez-vous goûter quoi que ce soit avec ce nuisible qui galope partout ?";
        map["I can't be expected to work under these conditions!"] = "On ne peut pas exiger de moi que je travaille dans de telles conditions !";
        map["They've got you shucking oysters, huh?"] = "Ils vous ont collé à l'écaillage des huîtres, hein ?";
        map["I don't mind it!"] = "Ça ne me dérange pas !";
        map["Have you tried oysters before? They're a delicacy, no?"] = "Avez-vous déjà goûté aux huîtres ? C'est un mets raffiné, non ?";
        map["Turns out my stomach has a delicacy, so I think I'll give them a miss going forward."] = "Il s'avère que c'est mon estomac qui est raffiné, alors je m'en passerai volontiers à l'avenir.";
        map["I'd better get back to it."] = "Je ferais mieux d'y retourner.";
        map["Please hurry, I can't take much more of this."] = "De grâce, dépêchez-vous, je n'en peux plus.";
        map["I'll leave you to your work."] = "Je vous laisse à vos occupations.";
        map["Merci!"] = "Merci !";

        // Hotspots
        map["It smells like onion soup."] = "Ça sent la soupe à l'oignon.";
        map["That's a well stocked spice rack!"] = "Voilà un râtelier à épices bien garni !";

        // Write output TSV
        int count = 0;
        using (var sw = new StreamWriter(@"translations\partitions\c2_b4_french.tsv", false, Encoding.UTF8)) {
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
                if (!string.IsNullOrEmpty(fr)) count++;
            }
        }
        Console.WriteLine(string.Format("Generated c2_b4_french.tsv: {0} lines processed out of {1}", count, lines.Length));
    }
}
