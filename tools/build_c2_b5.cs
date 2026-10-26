using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class BuildC2B5 {
    static void Main() {
        string rawPath = @"translations\partitions\c2_b5_rooms_passengers.tsv";
        if (!File.Exists(rawPath)) {
            Console.WriteLine("File not found: " + rawPath);
            return;
        }

        var lines = File.ReadAllLines(rawPath, Encoding.UTF8);
        var map = new Dictionary<string, string>();

        // April & Bartender & Cashier & Enforcers
        map["Hello, April."] = "Bonjour, April.";
        map["What do you need, Diana?"] = "De quoi as-tu besoin, Diana ?";
        map["How can I help, Diana?"] = "Comment puis-je t'aider, Diana ?";
        map["What can I get you to drink, ma'am?"] = "Que puis-je vous servir à boire, madame ?";
        map["Nothing for me, thank you, just passing through!"] = "Rien pour moi, merci, je ne faisais que passer !";
        map["You got any chips to cash in, ma'am?"] = "Avez-vous des jetons à encaisser, madame ?";
        map["Oh, no, thank you. I don't have any chips."] = "Oh, non, merci. Je n'ai pas de jetons.";
        map["Not the gambling type, aye? I get it!"] = "Pas du genre joueuse, hein ? Je comprends !";
        map["Excuse me."] = "Pardonnez-moi.";
        map["My mistake!"] = "Au temps pour moi !";
        map["Greetings!"] = "Salutations !";

        // Don
        map["You're the detective that's been hired to case the joint, right?"] = "Vous êtes le détective engagé pour sonder les lieux, pas vrai ?";
        map["Listen, I wanted to offer you my services. Just let me know if you're interested, okay?"] = "Écoutez, je voulais vous proposer mes services. Faites-moi signe si ça vous intéresse, d'accord ?";
        map["Ready to tell me what do you need that forgery for?"] = "Prêt à me dire à quoi doit vous servir ce faux ?";
        map["Well look who's back, ready to hear about that favour?"] = "Tiens, regardez qui voilà ! Prêt à entendre parler de ce petit service ?";
        map["So, how is that favour progressing?"] = "Alors, comment avance notre petit arrangement ?";
        map["I'm glad we could assist each other today."] = "Ravi qu'on ait pu s'entraider aujourd'hui.";
        map["Hey, beautiful! I haven't seen you around here before."] = "Hé, jolie poupée ! Je ne t'avais jamais vue dans le coin.";
        map["Ohh... I've been keeping to myself, that's all!"] = "Oh... je suis d'un naturel réservé, c'est tout !";
        map["Say, you look like a well-read broad. If you're into poetry, maybe we could g-"] = "Dis-moi, tu m'as l'air d'une fille cultivée. Si tu aimes la poésie, on pourrait peut-être s-";
        map["Pfft! I'll still be here when you change your mind, lady!"] = "Pfft ! Je serai toujours là quand tu changeras d'avis, ma belle !";
        map["Is this what you were looking for?"] = "C'est bien ce que vous cherchiez ?";
        map["Ha-ha, that's it! I can't believe you actually pulled it off!"] = "Ha-ha, c'est ça ! Je n'arrive pas à croire que vous ayez réussi le coup !";
        map["I'm not gonna lie, I underestimated you. A deal is a deal, so... take this!"] = "Je ne vais pas vous mentir, je vous avais sous-estimé. Un marché est un marché, alors... prenez ça !";

        // Gunter & Hagen & Twins rescue
        map["Hm, what do we have here?"] = "Hm, qu'avons-nous là ?";
        map["We're waiting to be seated, because someone forgot to make a dinner reservation."] = "On attend d'être placés, parce que quelqu'un a oublié de réserver pour le dîner.";
        map["I thought you were going to do it."] = "Je croyais que c'était toi qui devais t'en occuper.";
        map["What scent are you wearing? It smells so familiar!"] = "Quel parfum portez-vous ? Cette odeur m'est tellement familière !";
        map["That would be telling, darling."] = "Ce serait trahir un secret, très cher.";
        map["Where did you get that coat? You remind me of..."] = "Où avez-vous trouvé ce manteau ? Vous me rappelez...";
        map["It was a gift!"] = "C'était un cadeau !";
        map["I can't believe you talked me into this, you blockhead!"] = "Je n'arrive pas à croire que tu m'aies embarqué là-dedans, espèce de crétin !";
        map["I was sure it was this way!"] = "J'étais sûr que c'était par là !";
        map["Get out of there, both of you! It's not designed to support your weight."] = "Sortez de là, tous les deux ! Ce n'est pas conçu pour supporter votre poids.";
        map["Hey!"] = "Hé !";
        map["It's Gunter who can't stop snacking."] = "C'est Gunter qui n'arrête pas de grignoter.";
        map["At least I know about portion control!"] = "Moi au moins, je sais modérer mes portions !";
        map["ENOUGH!"] = "ASSEZ !";
        map["But mother, we found the entrance to Lady Unterwald's office!"] = "Mais mère, nous avons trouvé l'entrée du bureau de Lady Unterwald !";
        map["You did?!"] = "Vraiment ?!";
        map["Were you able to hear anything?"] = "Avez-vous réussi à entendre quelque chose ?";
        map["It sounds like arguing, but it's too muffled."] = "On dirait une dispute, mais c'est trop étouffé.";
        map["Maybe you could squeeze through, Herman?"] = "Peut-être pourriez-vous vous faufiler, Herman ?";
        map["Uhh, I don't know about th-"] = "Euh, je ne sais pas trop si c'est-";
        map["Great idea, mummy!"] = "Excellente idée, maman !";
        map["Yes, yes! I know. It's all coming together. Quickly now!"] = "Oui, oui ! Je sais. Tout se goupille à merveille. Plus vite que ça !";
        map["I don't thi-"] = "Je ne croi-";

        // Harold & Edna & Mary
        map["I heard the detective on the Unterwald case disappeared, vanished into thin air!"] = "J'ai entendu dire que le détective sur l'affaire Unterwald a disparu, volatilisé dans la nature !";
        map["Perhaps it's a cunning ploy of some sort, to lure out the killer?"] = "C'est peut-être un stratagème ingénieux pour faire sortir le meurtrier du bois ?";
        map["Well, maybe the killer already got to him."] = "Eh bien, le tueur a peut-être déjà eu sa peau.";
        map["What if he was the killer all along, and he's just covering his tracks!"] = "Et s'il était le tueur depuis le début, et qu'il effaçait simplement ses traces !";
        map["Now that'd be a twist! But I believe it's been done before."] = "Voilà qui serait un sacré rebondissement ! Mais je crois que ça a déjà été fait.";

        // Hirsch
        map["Herman Merman! It is truly an honour."] = "Herman Merman ! C'est véritablement un honneur.";
        map["Doctor Hirsch, at your service! I'm Lady Unterwald's personal physician."] = "Docteur Hirsch, à votre service ! Je suis le médecin personnel de Lady Unterwald.";
        map["Y-You know who I am?"] = "V-Vous savez qui je suis ?";
        map["Of course! I could hardly believe THE Herman Merman was bleeding on ME!"] = "Évidemment ! J'avais peine à croire que LE Herman Merman saignait sur MES vêtements !";
        map["Herman Merman!"] = "Herman Merman !";
        map["It was an honour to watch a master at work, I knew you'd locate that idol!"] = "Ce fut un honneur de voir un maître à l'œuvre, je savais que vous localiseriez cette idole !";
        map["I've read all the stories of your cases, you know!"] = "J'ai dévoré tous les récits de vos enquêtes, vous savez !";
        map["Yes, Herman?"] = "Oui, Herman ?";
        map["We heard some crashing and bashing, is everything okay?"] = "On a entendu un vacarme épouvantable, tout va bien ?";
        map["Do I need to perform a physical examina-"] = "Dois-je procéder à un examen physiq-";
        map["No, that won't be necessary, I assure you everything is fine!"] = "Non, ce ne sera pas nécessaire, je vous assure que tout va pour le mieux !";
        map["Doctor Hirsch?"] = "Docteur Hirsch ?";
        map["Yes, ma'am?"] = "Oui, madame ?";
        map["It's me, Herman. I'm in disguise!"] = "C'est moi, Herman. Je suis incognito !";
        map["Good heavens! Where did you go? Are you close to finding the killer?"] = "Grands dieux ! Où étiez-vous passé ? Êtes-vous sur le point de démasquer l'assassin ?";
        map["I'll explain later, just pretend you didn't see me."] = "Je vous expliquerai plus tard, faites comme si vous ne m'aviez pas vu.";
        map["I saw nothing, Herman. I just hope you know what you're doing."] = "Je n'ai rien vu, Herman. J'espère seulement que vous savez ce que vous faites.";
        map["Don't tell anyone you saw me!"] = "Ne dites à personne que vous m'avez vu !";

        // Pierre & Ron & Shelly & Susanne
        map["Oh là là! You are truly a work of art, Mademoiselle."] = "Oh là là ! Vous êtes un véritable chef-d'œuvre, Mademoiselle.";
        map["You simply must allow me to paint you!"] = "Vous devez absolument me laisser faire votre portrait !";
        map["Heavens, you'll make me blush!"] = "Bonté divine, vous allez me faire rougir !";
        map["It is decided! You shall be my next muse, just say the word."] = "C'est décidé ! Vous serez ma prochaine muse, il suffit d'un mot.";
        map["Maybe another time."] = "Une autre fois, peut-être.";
        map["How can I help you, monsieur?"] = "Que puis-je faire pour vous, monsieur ?";
        map["The name's Ron, why not sit and share a drink with me?"] = "Moi c'est Ron. Pourquoi ne pas vous asseoir et partager un verre avec moi ?";
        map["Charmed, I'm sure, but I have pressing matters to attend to."] = "Enchantée, sans doute, mais j'ai des affaires urgentes à régler.";
        map["I hear you, ma'am. Ron will be right here if you change your mind."] = "Bien reçu, madame. Ron reste pile ici si jamais vous changiez d'avis.";
        map["They look like they're deep in conversation."] = "Ils ont l'air plongés dans une intense conversation.";
        map["Herman Merman, that's quite the costume change. Where'd you get the coat?"] = "Herman Merman, voilà un sacré changement de garde-robe. Où as-tu dégoté ce manteau ?";
        map["Wh- how did you see through my disguise so easily?"] = "Co... comment as-tu percé mon déguisement si facilement ?";
        map["Your hand, dummy. You're still sporting that stab wound from our little knife game."] = "Ta main, crétin. Tu as toujours la trace du coup de canif de notre petit jeu du couteau.";
        map["How observant... You'd make an excellent detective, you know."] = "Quel sens de l'observation... Tu ferais une excellente détective, tu sais.";
        map["Yeah, but it'd be too easy, where's the fun in that?"] = "Ouais, mais ce serait bien trop facile. Où serait le plaisir ?";

        // Arthur & Diana
        map["There's something written on this napkin, right?"] = "Il y a quelque chose d'écrit sur cette serviette, non ?";
        map["Do I really need to say it?"] = "Ai-je vraiment besoin de le confirmer ?";
        map["Yes, there's something written on that napkin."] = "Oui, il y a bien quelque chose d'écrit sur cette serviette.";
        map["You said Lady Unterwald's death wasn't part of the plan?"] = "Vous disiez que la mort de Lady Unterwald ne faisait pas partie du plan ?";
        map["Did I say that? I must have misspoke."] = "J'ai dit ça ? J'ai dû fourcher.";
        map["What plan are you talking about?"] = "De quel plan parlez-vous ?";
        map["That's classified, I'm afraid. These lips are sealed."] = "C'est secret défense, j'en ai peur. Mes lèvres sont scellées.";
        map["Classified?"] = "Secret défense ?";
        map["Where are we supposed to be rendezvousing again?"] = "Où sommes-nous censés nous retrouver, déjà ?";
        map["Trust me, you have all the information you need."] = "Faites-moi confiance, vous avez déjà tous les éléments en main.";
        map["Never mind, I'll be on my way."] = "Tant pis, je reprends ma route.";
        map["I'll be seeing you."] = "À plus tard.";

        // Waiter & Masson
        map["I've always wanted to join a secret society!"] = "J'ai toujours rêvé de faire partie d'une société secrète !";
        map["What's it like being in The Order Of Idle Hands?"] = "À quoi ressemble la vie au sein de l'Ordre des Mains Inactives ?";
        map["All too familiar, I'm afraid."] = "Beaucoup trop banale, j'en ai peur.";
        map["There's ceremonial robes and subterfuge."] = "Il y a des robes de cérémonie et des faux-semblants.";
        map["But at the end of the day, I'm still serving drinks and nibbles."] = "Mais au bout du compte, je passe mes journées à servir des verres et des amuse-gueules.";
        map["Ah, but I'll bet those appetisers are from an equally secret menu?"] = "Ah, mais je parie que ces hors-d'œuvre proviennent d'un menu tout aussi clandestin ?";
        map["I couldn't possibly say, sir."] = "Je ne saurais me prononcer, monsieur.";
        map["Don't worry, your secret is safe with me!"] = "Ne craignez rien, votre secret est bien gardé avec moi !";
        map["Indeed. I believe the kitchen is up and running again."] = "Tout à fait. Les cuisines ont repris leur service, me semble-t-il.";
        map["Did you know the kitchen has a mouse problem?"] = "Saviez-vous que la cuisine est infestée par une souris ?";
        map["I've heard the rumours, but no need to worry. It's poppycock!"] = "J'ai eu vent des rumeurs, mais aucune inquiétude. C'est du pur délire !";
        map["I saw it! They tell me it's even been stealing valuables!"] = "Je l'ai vue de mes yeux ! On m'a dit qu'elle dérobait même des objets de valeur !";
        map["Forgive me if I find that hard to believe."] = "Pardonnez-moi si j'éprouve quelque peine à y croire.";
        map["It's true, there's a mouse in the kitchen!"] = "C'est la pure vérité, il y a une souris dans les cuisines !";
        map["Wanna see the mouse again?"] = "Vous voulez revoir la souris ?";
        map["Have you seen a doctor's briefcase around here?"] = "Auriez-vous aperçu la sacoche d'un médecin par ici ?";
        map["A briefcase? I'm afraid not."] = "Une sacoche ? J'en ai bien peur que non.";
        map["Mr Masson may have seen it, you could try asking him."] = "M. Masson l'a peut-être vue passer, vous pourriez essayer de lui poser la question.";
        map["What's the matter with Mr Masson?"] = "Qu'arrive-t-il à M. Masson ?";
        map["The doctor suspected a highly acute case of alcohol poisoning."] = "Le docteur a diagnostiqué un coma éthylique carabiné.";
        map["What has Mr Masson been drinking?"] = "Qu'est-ce que M. Masson a bien pu boire ?";
        map["It's a nigh lethal combination of ethanol, cocktail perfume and assorted petal leaf."] = "C'est un mélange quasi létal d'éthanol pur, de parfum à cocktail et de pétales de fleurs assortis.";
        map["All mixed to perfection within a single, large container."] = "Le tout mélangé à la perfection au sein d'un seul et unique grand récipient.";
        map["Does this drink have a name?"] = "Cette mixture porte-t-elle un nom ?";
        map["Rose buuuud."] = "Rose buuuud...";
        map["Indeed. Mr Masson refers to it as the Rosebud."] = "Tout à fait. M. Masson la baptise le Rosebud.";
        map["MMmwwaah!"] = "MMmwwaah !";
        map["How do I get one of those Rosebuds?"] = "Comment puis-je me procurer un de ces Rosebuds ?";
        map["Mr Masson has become quite fond of them. He may be holding the last one."] = "M. Masson en est devenu particulièrement friand. Il tient sans doute le tout dernier.";
        map["However, you could check with the barman to be sure."] = "Toutefois, vous pourriez vérifier auprès du barman pour en avoir le cœur net.";
        map["Alright!"] = "Très bien !";
        map["Remind me again, what's in a Rosebud?"] = "Rappelez-moi ce qu'il y a dans un Rosebud ?";
        map["Of course!"] = "Bien entendu !";
        map["I'd best be going."] = "Je ferais mieux d'y aller.";

        // Inventory look
        map["It's Doctor Hirsch's medical bag."] = "C'est la sacoche médicale du docteur Hirsch.";

        // Casino Carriage Hotspots & Chatter
        map["What's going on back there?"] = "Que se passe-t-il là-derrière ?";
        map["Are you sure there's nothing going on back there?"] = "Vous êtes certain qu'il ne se passe rien là-derrière ?";
        map["Nothing you need to know about."] = "Rien qui vous regarde.";
        map["Anyone else caught sight of that suave businessman aboard?"] = "Quelqu'un d'autre a repéré ce séduisant homme d'affaires à bord ?";
        map["No, pray tell."] = "Non, raconte.";
        map["He goes by Jian. I heard he was a property magnate!"] = "Il se prénomme Jian. J'ai ouï dire que c'était un magnat de l'immobilier !";
        map["No, no. Apparently he's an oil man."] = "Non, non. Paraît-il qu'il est dans le pétrole.";
        map["Well, consider my interest thoroughly piqued!"] = "Eh bien, ma curiosité est piquée au vif !";
        map["Did you see that drunkard being dragged out of the dining carriage?"] = "Tu as vu cet ivrogne qu'on a traîné hors du wagon-restaurant ?";
        map["I suppose some people just can't handle their liquor!"] = "Certains ne savent décidément pas tenir leur alcool !";
        map["Good thing the doctor was on hand to help."] = "Heureusement que le médecin était là pour intervenir.";
        map["Hold on, there's a doctor aboard? Is he single?"] = "Attends, il y a un médecin à bord ? Il est célibataire ?";
        map["You'd better call him over, I can feel the vapours coming on!"] = "Fais-le vite venir, je sens que mes vapeurs me reprennent !";
        map["I wouldn't hold out hope, Evelyn. He seems quite attached to Lady Unterwald."] = "Ne te berce pas d'illusions, Evelyn. Il a l'air très dévoué à Lady Unterwald.";
        map["Follows her around all day like he's her pet, bless him."] = "Il la suit toute la journée comme son petit toutou, le pauvre.";
        map["Does anyone ever make money on those things?"] = "Quelqu'un a déjà gagné un sou à ce genre d'engins ?";
        map["Don't you go jinxing me, I was on a winning streak!"] = "Ne venez pas me porter la poisse, j'étais en pleine veine !";
        map["How are those slots treating you now?"] = "Alors, comment vous traitent ces bandits manchots, maintenant ?";
        map["Poorly."] = "Très mal.";
        map["Thanks a lot, Mister!"] = "Merci beaucoup, monsieur !";
        map["I wouldn't waste my coin on these games of chance."] = "Je ne gaspillerais pas mes deniers dans ces jeux de hasard.";
        map["I'm a writer, I don't have money to burn!"] = "Je suis écrivain, je n'ai pas d'argent à jeter par les fenêtres !";
        map["Lady Unterwald certainly knows how to make an impression."] = "Lady Unterwald sait assurément en mettre plein la vue.";
        map["Who'd risk all that?"] = "Qui risquerait tout ça ?";
        map["I'm sensing you're not the gambling type!"] = "Je sens que vous n'avez pas l'âme d'un flambeur !";

        // Dining Carriage Hotspots
        map["The water is undulating quite hypnotically with the train's motion."] = "L'eau ondoie de façon presque hypnotique au rythme du train.";
        map["When life gives you lemons, there's plenty to be bitter about."] = "Quand la vie vous donne des citrons, il y a de quoi être amer.";
        map["What's in these?"] = "Qu'y a-t-il là-dedans ?";
        map["That's ''Express Reserve'' whiskey, would you like one?"] = "C'est du whisky « Express Reserve », vous en voulez un ?";
        map["No, thanks, I've got to stay sharp!"] = "Non merci, je dois garder les idées claires !";
        map["I don't find these napkins particularly note-worthy."] = "Je ne trouve pas ces serviettes particulièrement remarquables.";
        map["Couldn't hurt to take a napkin, I suppose."] = "Ça ne peut pas faire de mal d'en prendre une, j'imagine.";
        map["I don't think I'll need another one."] = "Je ne pense pas en avoir besoin d'une autre.";
        map["I don't think I will."] = "Je préfère m'abstenir.";

        // Don's Quarters
        map["Hmm, the signature is definitely cursive..."] = "Hmm, la signature est indiscutablement en cursive...";
        map["Aghhh!"] = "Aaaah !";
        map["Geez, relax! That's just Nibbles. She's my associate."] = "Doucement, détendez-vous ! C'est juste Grignote. Mon associée.";
        map["Associate? It's a dirty rat!"] = "Une associée ? Mais c'est un sale rat d'égout !";
        map["Nibbles is a mouse, you dummy. And even if she were a rat, she'd be very good at keeping her trap shut..."] = "Grignote est une souris, imbécile. Et même si c'était un rat, elle saurait très bien tenir sa langue...";
        map["You wouldn't squeal on me, would you Nibbles?"] = "Tu ne cafterais pas sur moi, pas vrai, Grignote ?";
        map["Besides, she's got a real nose for valuables."] = "Et puis, elle a un pif incroyable pour dénicher les trucs de valeur.";
        map["Just today, she sniffed out this pearl necklace from some rich dame, hah!"] = "Pas plus tard qu'aujourd'hui, elle a reniflé ce collier de perles sur une bourgeoise, ah !";
        map["Oyster pearls kinda creep me out, though. Not a big fan of the ocean, personally."] = "Les perles d'huîtres me foutent la trouille, cela dit. Je ne suis pas très porté sur l'océan.";
        map["Look, can you forge that signature or not?"] = "Écoutez, vous pouvez imiter cette signature, oui ou non ?";
        map["Yeah, this should be pretty easy. Just tell me, what do you need it for?"] = "Ouais, ça devrait être du gâteau. Dites-moi juste à quoi elle doit vous servir.";
        map["It's the magnet I secured for Donny."] = "C'est l'aimant que j'ai récupéré pour Donny.";
        map["I can't imagine what he'd need it for, though."] = "Je n'ose imaginer ce qu'il compte en faire, cela dit.";
        map["That's for me to know, and you to not find out."] = "C'est à moi de le savoir, et à vous de ne pas chercher à comprendre.";
        map["How long has this been here?"] = "Depuis combien de temps cette assiette traîne-t-elle là ?";
        map["Not sure, but I know that dish didn't have mushrooms when I ate it."] = "Pas sûr, mais je sais que ce plat n'avait pas de champignons quand je l'ai entamé.";
        map["Ughh."] = "Pouah.";
        map["Why the honeymoon suite, exactly?"] = "Pourquoi la suite nuptiale, au juste ?";
        map["I enjoy my privacy. Nobody's gonna risk walking in on some honeymooners."] = "J'aime ma tranquillité. Personne ne risquerait de déranger des tourtereaux en lune de miel.";
        map["A friend of yours?"] = "Une amie à vous ?";
        map["It's for my gynaecomastia, alright?"] = "C'est pour ma gynécomastie, d'accord ?";
        map["I need the additional support, not that it's any of your business."] = "J'ai besoin de maintien supplémentaire, non pas que ça vous regarde.";
        map["What's the occasion?"] = "Quelle est l'occasion ?";
        map["You need an occasion to enjoy the finer things?"] = "Faut-il une occasion spéciale pour savourer les bonnes choses ?";
        map["Is this part of your next hustle?"] = "Cela fait partie de votre prochaine arnaque ?";
        map["You ask a lot of questions, you know that?"] = "Vous posez beaucoup de questions, vous savez ?";
        map["Are you looking to get implicated?"] = "Vous tenez vraiment à être mouillé ?";
        map["This must be how Donny's pet accomplice moves about the train."] = "C'est sûrement par là que la complice à quatre pattes de Donny se déplace dans le train.";
        map["It's just a pile of ball bearings."] = "Ce n'est qu'un tas de billes métalliques.";
        map["You just wait till I magnetise them."] = "Attendez un peu que je les aie aimantées.";
        map["Hey, no touching!"] = "Hé, pas touche !";

        // Lounge Carriage Interruption
        map["Well, that's a twist."] = "En voilà un rebondissement.";
        map["YOU!"] = "VOUS !";
        map["It took me hours, but I finally clawed my way out of that case!"] = "Il m'a fallu des heures, mais j'ai fini par m'extraire de cet étui à coups de griffes !";
        map["Mr Liu! Where have you been?"] = "M. Liu ! Où étiez-vous passé ?";
        map["Thought you could get away with it, did you?"] = "Vous pensiez pouvoir vous en tirer à si bon compte, hein ?";
        map["What the hell did I do?"] = "Qu'est-ce que j'ai fait, moi, bon sang ?";
        map["Not you, idiot. This imposter is walking around in my suit!"] = "Pas toi, crétin. Cet imposteur se balade dans mon costume !";
        map["I am?"] = "Moi ?";
        map["And where is his accomplice, that bumbling detective?"] = "Et où est son complice, ce détective de pacotille ?";
        map["I'm afraid he vanished without a trace. We'll likely never see him again!"] = "J'ai bien peur qu'il se soit évaporé sans laisser de traces. On ne le reverra probablement plus !";
        map["AAAAAHHHH!"] = "AAAAAAHHHH !";
        map["My goodness, that woman needs our assistance!"] = "Bonté du ciel, cette femme requiert notre aide !";
        map["Don't worry, I've got her!"] = "Ne t'inquiète pas, je la tiens !";
        map["No, I've got her!"] = "Non, c'est moi qui la tiens !";
        map["You're interfering with my heroic rescue!"] = "Tu gâches mon sauvetage héroïque !";
        map["*Gasp*"] = "*Halètement*";
        map["Now that's a twist."] = "En voilà un autre rebondissement.";
        map["Herman Merman, how kind of you to rejoin us."] = "Herman Merman, quelle bonté à vous de vous joindre à nous.";
        map["Now, what are we going to do with you?"] = "À présent, que va-t-on faire de votre cas ?";
        map["Oh, look!"] = "Oh, regardez !";
        map["Another tunnel."] = "Encore un conduit.";

        // Lounge Carriage Hotspots
        map["I'm not sure if I'm in need of a boot polish right now."] = "Je ne suis pas sûr d'avoir besoin d'un cirage pour l'instant.";
        map["Somebody on staff must have made a grave omission."] = "Quelqu'un parmi le personnel a commis un oubli impardonnable.";
        map["These shelves don't seem to be carrying any of my works."] = "Ces étagères ne semblent comporter aucun de mes ouvrages.";
        map["I think it's best if I left the singing to the professionals."] = "Je ferais mieux de laisser le chant aux artistes chevronnés.";
        map["Alas, if only I knew how to tickle those ivories."] = "Hélas, si seulement je savais taquiner l'ivoire.";
        map["This must be the entrance to the backstage area. "] = "Ce doit être l'accès aux coulisses.";
        map["This must be the entrance to the backstage area."] = "Ce doit être l'accès aux coulisses.";
        map["The door is bolted shut, I'm not getting through there."] = "La porte est verrouillée à double tour, impossible de passer.";
        map["It's the VIP guest list for the Green Room, but my name is notably absent."] = "C'est la liste VIP pour le foyer des artistes, mais mon nom en est curieusement absent.";
        map["Don't they know who I am?"] = "Ignorent-ils qui je suis ?";
        map["It's the guest list for the Green Room, with one notable amendment."] = "C'est la liste VIP pour le foyer des artistes, avec une modification de taille.";
        map["Herman Merman, VIP!"] = "Herman Merman, VIP !";

        // Sleeper Carriage Hotspots
        map["Sorry, wrong room!"] = "Pardon, mauvaise chambre !";
        map["It's full of baggage."] = "C'est rempli de bagages.";
        map["It's a luggage cart for transporting various baggage."] = "C'est un chariot à bagages destiné au transport des malles.";
        map["I'm not in need of a pamphlet to dictate my travel plans."] = "Je n'ai nullement besoin d'un prospectus pour me dicter mon itinéraire.";
        map["Ah, I believe this is Lord Unterwald."] = "Ah, je présume qu'il s'agit de Lord Unterwald.";
        map["The late husband of Lady Unterwald."] = "Le défunt époux de Lady Unterwald.";
        map["It's a bust of Lady Unterwald, there's a small engraving at the base."] = "C'est un buste de Lady Unterwald, il y a une petite gravure sur le socle.";
        map["There's something written here, but it's too small to make out."] = "Il y a quelque chose d'écrit ici, mais c'est trop petit pour être lu.";

        // Storage Room Flashback & Hotspots
        map["Our records show that you were in the luggage storage room when the murder took place?"] = "D'après nos registres, vous étiez dans le fourgon à bagages au moment du crime ?";
        map["That's right. Arthur came running in to tell me there'd been a murder."] = "C'est exact. Arthur est arrivé en trombe pour m'annoncer qu'un meurtre avait été commis.";
        map["They needed a detective, after all. I was happy to step up!"] = "Après tout, ils avaient besoin d'un détective. J'ai répondu présent sans hésiter !";
        map["I dread to imagine what vicious creature was responsible for this."] = "Je tremble à l'idée du monstre féroce capable d'un tel ravage.";
        map["I think lifting this would kill me."] = "Je crois que soulever ceci suffirait à me terrasser.";
        map["I'm not in need of any new undergarments."] = "Je n'ai nul besoin de sous-vêtements de rechange.";
        map["Let's hope it stays that way."] = "Espérons que ça reste ainsi.";
        map["This is why I always prefer to travel light."] = "Voilà pourquoi je préfère toujours voyager léger.";
        map["It looks fairly impenetrable."] = "Ce verrou paraît inviolable.";

        // Unterwald Carriage Flashback / Meeting
        map["How long would you say you were hiding in that wardrobe, Herman?"] = "Combien de temps diriez-vous être resté caché dans cette penderie, Herman ?";
        map["It's hard to say, I was busy weighing up my options, considering my next moves."] = "Difficile à dire, j'étais fort occupé à peser le pour et le contre, à planifier mes manœuvres.";
        map["That's Herman. He sounded terrified!"] = "C'est Herman. Il avait l'air terrifié !";
        map["Do you think he's wrapped up in Lady Unterwald's death?"] = "Pensez-vous qu'il soit mêlé à la mort de Lady Unterwald ?";
        map["I can't say for sure, but I think it's time we found out."] = "Je ne saurais l'affirmer, mais je crois qu'il est temps d'en avoir le cœur net.";
        map["They can't know about Jian, Herman. Keep it together!"] = "Ils ne doivent rien savoir pour Jian, Herman. Tiens bon !";
        map["Think, Herman... Think!"] = "Réfléchis, Herman... Réfléchis !";
        map["Herman Merman, Master of Disguise!"] = "Herman Merman, maître du déguisement !";
        map["Herman Merman, we meet at last. Welcome aboard the Reuss Express!"] = "Herman Merman, nous nous rencontrons enfin. Bienvenue à bord du Reuss Express !";
        map["Please accept my apologies for the unusual manner of your arrival."] = "Veuillez accepter mes excuses pour les circonstances singulières de votre venue.";
        map["As I'm sure you can understand, a certain amount of discretion was required."] = "Comme vous le comprendrez aisément, un minimum de discrétion s'imposait.";
        map["Forgive me, you must be wondering what it is you're doing here, aboard my train."] = "Pardonnez-moi, vous devez vous demander ce que vous faites ici, à bord de mon train.";
        map["Oh ho ho ho! My goodness, no!"] = "Oh ho ho ho ! Grands dieux, non !";
        map["A world-famous detective running amok on my train? Everyone would be losing their minds before supper!"] = "Un détective de renommée mondiale arpentant mon train ? Tout le monde paniquerait avant le dîner !";
        map["I hear you're writing your next novel? I felt you could adequately mask your activities as a working novelist."] = "On m'a dit que vous rédigiez votre prochain roman ? Vous pourrez fort bien masquer vos investigations sous couvert de recherches littéraires.";
        map["To the average passenger, you'd simply be researching your next story."] = "Pour le passager lambda, vous vous documentez simplement pour votre prochaine intrigue.";
        map["Do you think you could do that, Herman? Keep a low profile, not cause a scene?"] = "Pensez-vous en être capable, Herman ? Rester discret, sans provoquer d'esclandre ?";
        map["I could always call Dirk Chiselton. It wouldn't be as clean, but-"] = "Je pourrais toujours faire appel à Dirk Chiselton. Ce serait moins propre, mais-";
        map["Lady Unterwald!"] = "Lady Unterwald !";
        map["Away, back into the case with you!"] = "Filez, retournez dans votre étui !";
        map["Lady Unterwald, please forgive me if I am intruding."] = "Lady Unterwald, pardonnez-moi si je vous importune.";
        map["Not at all, Mr Liu. What a pleasure it is to see you again!"] = "Pas le moins du monde, M. Liu. Quel plaisir de vous revoir !";
        map["Please, I must insist you call me Jian."] = "Je vous en prie, appelez-moi Jian.";
        map["Here, I brought you something."] = "Tenez, je vous ai apporté un présent.";
        map["Not quite. It's a chilli plant, a particularly fiery variety."] = "Pas tout à fait. C'est un plant de piment d'une variété particulièrement ardente.";
        map["It reminded me of you, my lady."] = "Il m'a fait penser à vous, milady.";
        map["My goodness, Jian! You'll turn me bright red."] = "Bonté divine, Jian ! Vous allez me faire rougir comme une pivoine.";
        map["But I know you didn't come all this way just to flatter me."] = "Mais je sais bien que vous n'avez pas fait tout ce chemin rien que pour me flatter.";
        map["Indeed. I was wondering if you'd given any more thought to my proposal?"] = "En effet. Je me demandais si vous aviez mûri ma proposition ?";
        map["If you're considering selling your legacy, I want you to know that it'll be in good hands."] = "Si vous songez à céder votre empire, sachez qu'il sera entre de bonnes mains.";
        map["Look Jian, I-"] = "Écoutez Jian, je-";
        map["You need more time to consider, of course."] = "Il vous faut davantage de temps pour réfléchir, naturellement.";
        map["There are still a few more hours before the speech. I'll leave you to weigh your options."] = "Il reste encore quelques heures avant le discours. Je vous laisse peser le pour et le contre.";
        map["You're most kind, thank you, Jian."] = "Vous êtes fort aimable, merci, Jian.";
        map["Alright, you can come out."] = "Très bien, vous pouvez sortir.";
        map["This is why you're here, Herman. I need you to keep an eye on Mr Liu for me."] = "Voilà la raison de votre présence, Herman. J'ai besoin que vous surveilliez M. Liu pour moi.";
        map["At the very least, I suspect he doesn't have my full interests at heart."] = "À tout le moins, je le soupçonne de ne pas défendre mes intérêts avec la plus grande dévotion.";
        map["There's also the question of my family, who will undoubtedly be sticking their noses into my business."] = "Il y a aussi ma famille, qui ne manquera pas de fourrer son nez dans mes affaires.";
        map["I've got them sufficiently shaking in their boots ahead of my speech, but keep an eye out for any trouble, will you?"] = "Je les ai fait trembler dans leurs bottes à l'approche de mon discours, mais ouvrez l'œil en cas d'incident, voulez-vous ?";
        map["I've secured a suite for you onboard, Room 304."] = "Je vous ai réservé une suite à bord, la cabine 304.";
        map["Just let me know if you find anything untoward."] = "Faites-moi signe au moindre élément suspect.";
        map["Get to it then, detective."] = "À vous de jouer, détective.";
        map["I understand your concerns, Lady Unterwald. But I really must press you for an answer!"] = "Je comprends vos réticences, Lady Unterwald. Mais je dois absolument obtenir une réponse !";
        map["I refuse to be rushed into a decision, Jian."] = "Je refuse de prendre une décision dans la précipitation, Jian.";
        map["I know this must be difficult, but the Unterwald empire would be safe in my hands."] = "Je sais que le choix est délicat, mais l'empire Unterwald serait à l'abri entre mes mains.";
        map["Is that what you think?"] = "C'est ce que vous vous imaginez ?";
        map["You'd rather entrust your legacy to those incompetent nephews of yours?"] = "Vous préféreriez confier votre héritage à vos bons à rien de neveux ?";
        map["Your scheming sister-in-law? You know she wants the estate for herself."] = "À votre intrigante de belle-sœur ? Vous savez pertinemment qu'elle convoite la propriété.";
        map["Just listen to that, your empire is crumbling around you!"] = "Écoutez un peu : votre empire est en train de s'effondrer sous vos yeux !";
        map["You must reconsider!"] = "Vous devez reconsidérer la question !";
        map["You think I'd sell to some oil baron who's just looking to buy out his competition?"] = "Vous croyez vraiment que je vendrais à un baron du pétrole uniquement désireux de racheter la concurrence ?";
        map["Over my dead body, Jian!"] = "Il faudra me passer sur le corps, Jian !";
        map["You think a solution is going to just drop out of the sky?"] = "Vous croyez qu'une solution va vous tomber du ciel ?";
        map["Is he dead?"] = "Est-il mort ?";
        map["He's not moving!"] = "Il ne bouge plus !";
        map["What's that in his hand?"] = "Qu'est-ce qu'il tient dans sa main ?";
        map["I can't leave now, this is important."] = "Je ne peux pas partir maintenant, c'est capital.";
        map["''Board Reuss Express. Await further instructions from contact.''"] = "« Embarquer à bord du Reuss Express. Attendre de nouvelles instructions du contact. »";
        map["So... this was Jian's plan all along."] = "Ainsi... c'était ça, le plan de Jian depuis le début.";
        map["If he couldn't buy you out, he was going to inform on you?"] = "S'il ne parvenait pas à vous racheter, il comptait vous dénoncer ?";
        map["It seems so. But we have bigger problems now."] = "On dirait bien. Mais nous avons un problème bien plus urgent sur les bras.";
        map["This lady is still expecting to meet her informant."] = "Cette dame s'attend toujours à rencontrer son informateur.";
        map["I see. As long as she meets someone matching this description..."] = "Je vois. Tant qu'elle rencontre quelqu'un correspondant à ce signalement...";
        map["She won't be any the wiser."] = "Elle n'y verra que du feu.";
        map["Help me with the body, Herman."] = "Aidez-moi avec le corps, Herman.";
        map["We'll hide Mr Liu away until we can figure out our next steps."] = "Nous allons planquer M. Liu le temps de décider de la marche à suivre.";
        map["We'll need to seal it, just in case we have people snooping around."] = "Il faudra bien sceller l'étui, au cas où des curieux viendraient fouiner.";
        map["There, I've managed to staple it shut!"] = "Et voilà, j'ai réussi à l'agrafer solidement !";
        map["What should we do now?"] = "Qu'est-ce qu'on fait maintenant ?";
        map["We'll need to get this suit to Mr Ackerman, my estate attorney."] = "Nous devons faire parvenir ce costume à M. Ackerman, mon notaire.";
        map["Knowing Arthur, he'll have locked himself in his quarters. No doubt poring over some legal mumbo jumbo!"] = "Connaissant Arthur, il se sera calfeutré dans sa cabine, plongé jusqu'au cou dans son jargon juridique !";
        map["First you'll need to lure him out, you might have some luck with the fusebox in the sleeper carriage."] = "Il vous faudra d'abord le faire sortir. Vous aurez peut-être plus de chance en coupant le disjoncteur du wagon-lits.";
        map["The fusebox..."] = "La boîte à fusibles...";
        map["He might need some persuading, but this letter should suffice. Try to be discreet, will you?"] = "Il aura sans doute besoin d'être convaincu, mais cette lettre devrait suffire. Tâchez d'être discret, voulez-vous ?";
        map["I'll do my best, Lady Unterwald!"] = "Je ferai de mon mieux, Lady Unterwald !";
        map["Yes, that's exactly what I'm afraid of!"] = "Oui, c'est précisément ce qui m'effraie !";

        // Unterwald Carriage Hotspots & Books
        map["It's a BUREAU-BOY™ briefcase."] = "C'est une mallette BUREAU-BOY™.";
        map["Herman, please leave that alone!"] = "Herman, ne touchez pas à ça !";
        map["That's for my estate lawyer, so don't you be touching it!"] = "C'est destiné à mon notaire, alors pas touche !";
        map["It's a series of self-help guides on running an empire."] = "C'est une collection de manuels pratiques pour diriger un empire commercial.";
        map["''How To Buy Friends And Influence People''"] = "« Comment acheter des amis et influencer les gens »";
        map["''The Art Of Not Giving A Damn: An Intuitive Approach To Capitalism''"] = "« L'art subtil de s'en balancer : une approche intuitive du capitalisme »";
        map["''Rich Dad, Rich Mum: A Guide To Generational Wealth''"] = "« Père riche, mère riche : guide de la fortune générationnelle »";
        map["Not the most comfortable mode of transport."] = "Pas le moyen de transport le plus confortable qui soit.";
        map["Oh, come now! I made sure there were plenty of air holes!"] = "Oh, allons ! J'ai pourtant veillé à percer de généreux trous d'aération !";
        map["What's with all the bouquets?"] = "À quoi riment tous ces bouquets ?";
        map["That's none of your business!"] = "Cela ne vous regarde pas !";
        map["They're a clumsy attempt at flattery, that's what!"] = "C'est une grossière tentative de séduction, voilà tout !";
        map["It was a gift from Mr Liu."] = "C'était un cadeau de M. Liu.";
        map["Well, he can take it back!"] = "Eh bien, il peut le remballer !";
        map["You think I have the constitution at my age to be playing with fire?"] = "Vous croyez vraiment qu'à mon âge, j'ai la santé pour jouer avec le feu ?";
        map["I'm not a fan of balloons, I find them to be incredibly grating."] = "Je n'aime pas les ballons, je trouve leur couinement prodigieusement agaçant.";
        map["Me neither, dear!"] = "Moi non plus, mon cher !";
        map["I'm glad we have that in common."] = "Ravit de voir qu'au moins, nous partageons ce point.";
        map["These coats are positively stunning!"] = "Ces manteaux sont tout bonnement somptueux !";
        map["I'd better not catch you running around in my clothes, dear!"] = "Je ferais mieux de ne pas vous surprendre à déambuler dans mes robes, mon cher !";
        map["Petals on the bed, Lady Unterwald?"] = "Des pétales sur le lit, Lady Unterwald ?";
        map["These bouquets are wilting, that's all!"] = "Ces bouquets perdent leurs fleurs, voilà tout !";
        map["I don't believe in all that ''quiet tap technology'' nonsense..."] = "Je n'accorde aucun crédit à ces fadaises de « frappe silencieuse »...";
        map["You know what they say, ''If it's not clacking, you're sure to be slacking!''"] = "Comme on dit chez nous : « Si ça ne claque pas, c'est que tu glandes ! »";
        map["Who says that?"] = "Qui dit ça ?";
        map["People! People say that!"] = "Les gens ! C'est ce que disent les gens !";
        map["There's a card here from Mr Liu."] = "Il y a un mot doux de M. Liu.";
        map["I'm afraid he's been trying to win me over for some time."] = "J'ai bien peur qu'il tente de me faire la cour depuis un certain temps.";
        map["The drawer seems to be stuck."] = "Le tiroir semble coincé.";
        map["Now I can slip back to my quarters unnoticed."] = "À présent, je peux regagner ma cabine sans éveiller les soupçons.";
        map["Isn't that right, Lady Unterwald?"] = "N'est-ce pas, Lady Unterwald ?";
        map["Oh, yes! Everything is in order!"] = "Oh, oui ! Tout est en ordre !";
        map["Isn't that right, Jian?"] = "Pas vrai, Jian ?";
        map["Yes, it's all fine!"] = "Oui, tout baigne !";
        map["Are you sure, Jian? Perhaps we should assist?"] = "Tu es sûr, Jian ? Peut-être devrions-nous vous prêter main-forte ?";
        map["NO, stay away!"] = "NON, restez où vous êtes !";
        map["Well, alright!"] = "Eh bien, soit !";
        map["There, you have it. Everything's fine, see?"] = "Voilà, vous voyez bien. Tout va très bien !";

        // Write output TSV
        int count = 0;
        using (var sw = new StreamWriter(@"translations\partitions\c2_b5_french.tsv", false, Encoding.UTF8)) {
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
        Console.WriteLine(string.Format("Generated c2_b5_french.tsv: {0} lines processed out of {1}", count, lines.Length));
    }
}
