using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class BuildC3B3 {
    static void Main() {
        string rawPath = @"translations\partitions\c3_b3_climax.tsv";
        if (!File.Exists(rawPath)) {
            Console.WriteLine("File not found: " + rawPath);
            return;
        }

        var lines = File.ReadAllLines(rawPath, Encoding.UTF8);
        var map = new Dictionary<string, string>();

        // Jian Liu Exterior Train Showdown
        map["Wait! I... I have questions!"] = "Attendez ! J'ai... j'ai des questions !";
        map["Questions?"] = "Des questions ?";
        map["What questions could you possibly have? I already spelled it out for you!"] = "Quelles questions pourriez-vous bien avoir ? Je vous ai déjà tout expliqué noir sur blanc !";

        // Handshake Club Gramophone scene
        map["Jian did what?! This is a grave betrayal of The Order!"] = "Jian a fait quoi ?! C'est une haute trahison envers l'Ordre !";
        map["I'm afraid so. I think it's time we heard what Lady Unterwald has to say for herself."] = "J'en ai bien peur. Je crois qu'il est temps d'écouter ce que Lady Unterwald a elle-même à nous dire.";
        map["I managed to obtain this recording from Lady Unterwald's safe. I believe it may contain her final instructions."] = "J'ai réussi à récupérer cet enregistrement dans le coffre de Lady Unterwald. Je pense qu'il contient ses ultimes volontés.";
        map["Sister Gretchen, fetch the gramophone!"] = "Sœur Gretchen, apportez le gramophone !";
        map["OOooOOooh! I speak to you now, from beyond the grave!"] = "Ooooouuuuuh ! Je m'adresse à vous depuis l'au-delà !";
        map["Who dares to wake me from my eternal slumber?"] = "Qui ose me réveiller de mon sommeil éternel ?";
        map["We're sorry, Lady Unterwald!"] = "Pardonnez-nous, Lady Unterwald !";
        map["Forgive us, we failed you!"] = "Pardonnez-nous, nous vous avons fait défaut !";
        map["Oh ho-ho! I'm just kidding around."] = "Oh ho ho ! Je plaisante, voyons.";
        map["Although if you're listening to this recording, that means I've kicked the bucket."] = "Quoique... si vous écoutez ceci, c'est que j'ai bel et bien cassé ma pipe.";
        map["I assume things have predictably descended into chaos, otherwise you wouldn't be seeking my guidance here."] = "J'imagine que la situation a tourné au vinaigre, sans quoi vous ne viendriez pas chercher mes conseils posthumes.";
        map["For general business enquiries, select track one."] = "Pour les requêtes commerciales générales, choisissez la piste un.";
        map["If you have an accounting question, select track two."] = "Pour toute question d'ordre comptable, choisissez la piste deux.";
        map["If you're seeking guidance on my last will and testament, select track three."] = "Pour des instructions sur mon testament, choisissez la piste trois.";
        map["For anything else, select track four."] = "Pour toute autre doléance, choisissez la piste quatre.";
        map["Ooh, she mentioned the will! Track three, pick track three!"] = "Ooh, elle a parlé du testament ! Piste trois, lancez la piste trois !";
        map["So, you've got a question about my last will and testament."] = "Ainsi, vous avez une question relative à mes dernières volontés.";
        map["Did somebody tear it to shreds in dramatic fashion? Accidentally submerge the documents in water? Set fire to the whole bloody lot, I'm guessing?"] = "Quelqu'un l'a-t-il déchiré avec fracas ? Trempé par mégarde dans l'eau ? Ou carrément réduit en cendres, si je ne m'abuse ?";
        map["I always said it'd ruffle some feathers, oh-ho ho!"] = "J'ai toujours dit que ça allait en faire piailler plus d'un, oh ho ho !";
        map["If my estate attorney is indisposed, or you're listening to this yourself, Arthur..."] = "Si mon notaire est indisposé, ou si c'est toi-même qui m'écoutes, Arthur...";
        map["I've always retained a copy of my will and testament at the Unterwald family mansion. You'll find your answers there!"] = "J'ai toujours conservé un double de mon testament au manoir familial des Unterwald. C'est là-bas que vous trouverez vos réponses !";
        map["The mansion, of course!"] = "Le manoir, évidemment !";
        map["I shall inform Herman Merman at once!"] = "Je m'en vais prévenir Herman Merman sur-le-champ !";
        map["Wasn't he being detained?"] = "N'était-il pas en état d'arrestation ?";
        map["You underestimate the man."] = "Vous sous-estimez cet homme.";
        map["I suspect he's already free from his bonds and taking matters into his own hands!"] = "Je le soupçonne d'avoir déjà brisé ses chaînes pour prendre les choses en main !";

        // Herman Quarters / Interrogation / Explosion
        map["If her attorney hadn't retrieved that missing will, we'd have never uncovered the truth."] = "Si son notaire n'avait pas récupéré ce testament disparu, nous n'aurions jamais découvert le fin mot de l'histoire.";
        map["What truth would that be?"] = "Et quelle était cette vérité ?";
        map["Go on, Diana. What happened after you and Mr Ackerman recovered the will?"] = "Poursuivez, Diana. Que s'est-il passé après que vous et M. Ackerman avez remis la main sur l'acte ?";
        map["The family insisted on an impromptu reading of the will, which distracted everyone long enough for me to poke around..."] = "La famille a exigé une lecture immédiate du testament, ce qui a fait diversion assez longtemps pour que je puisse fouiner...";
        map["Ugh, my head... What's going on?"] = "Argh, ma tête... Que se passe-t-il ?";
        map["Oh, for goodness' sake."] = "Oh, par tous les diables.";
        map["I came to rescue you two, of course!"] = "Je suis venue vous sauver tous les deux, voyons !";
        map["Well, that's just splendid. I feel safer already!"] = "Eh bien, voilà qui est splendide. Je me sens déjà tellement plus en sécurité !";
        map["Listen, we'll need to work together to get out of here."] = "Écoutez, nous devrons faire équipe pour nous tirer de ce pétrin.";
        map["How about you, Arthur?"] = "Et toi, Arthur ?";
        map["I can assure you, I'm not here to steal anyone's inheritance!"] = "Je vous assure que je ne suis pas ici pour voler l'héritage de qui que ce soit !";
        map["That's exactly what someone trying to steal our inheritance would say!"] = "C'est précisément ce que dirait quelqu'un qui veut piquer notre héritage !";
        map["We challenge you to another rematch!"] = "On exige une revanche immédiate !";
        map["Please, no!"] = "Pitié, non !";
        map["What the hell are you doing? Where are the prisoners?"] = "Qu'est-ce que vous fabriquez ? Où sont passés les prisonniers ?";
        map["Huh?"] = "Hein ?";
        map["Imbeciles! Must I do everything myself?"] = "Imbéciles ! Faut-il donc que je fasse tout moi-même ?";
        map["Excuse me, but I have to ask."] = "Pardonnez-moi, mais je dois vous poser la question.";
        map["Why is everything shaking?"] = "Pourquoi tout tremble autour de nous ?";
        map["Take a look out the window, Gunter."] = "Regarde par la fenêtre, Gunter.";
        map["See if you can tell what's going on."] = "Regarde si tu arrives à comprendre ce qui se passe.";
        map["It looks like..."] = "On dirait que...";
        map["Oh my..."] = "Oh mon Dieu...";
        map["Well? What is it?"] = "Alors ? Qu'est-ce qu'il y a ?";
        map["I think the train's about to..."] = "Je crois que le train est sur le point de...";
        map["I think it's about to..."] = "Je crois qu'il va...";
        map["About to what? Spit it out!"] = "Sur le point de quoi ? Crache le morceau !";
        map["I think-"] = "Je crois-";
        map["I don't think that's going to be much use."] = "Je ne pense pas que ce soit d'une grande utilité.";
        map["Agent M!"] = "Agent M !";
        map["You know each other?"] = "Vous vous connaissez ?";
        map["She's my assigned field agent!"] = "C'est l'agent de terrain qui m'a été assigné !";
        map["I'll explain later!"] = "Je vous expliquerai plus tard !";
        map["Here, let me untie your binds!"] = "Attendez, laissez-moi défaire vos liens !";
        map["I'm free!"] = "Je suis libre !";
        map["Okay, move out!"] = "En route, on bouge !";
        map["This seems like a bad idea."] = "Ça me paraît être une très mauvaise idée.";
        map["Focus. We need to get out of here!"] = "Restons concentrés. Nous devons déguerpir d'ici !";
        map["The twins really made a mess of all those papers."] = "Les jumeaux ont fichu un sacré bazar dans tous ces papiers.";
        map["If I wasn't preoccupied, I'd feel the urge to neatly organise it!"] = "Si je n'étais pas aussi occupé, je me ferais un devoir de tout classer méticuleusement !";
        map["No time for that now, Arthur."] = "Pas le temps pour ça, Arthur.";
        map["I can't really see them from here."] = "Je ne les distingue pas très bien d'ici.";

        // Inland Revenue HQ Flashback
        map["My first mission in the field, I can hardly believe it!"] = "Ma toute première mission sur le terrain, j'ai peine à y croire !";
        map["There's so much to remember, so much that can go wrong. I feel like I'm sweating buckets."] = "Tant de choses à retenir, tant de risques que ça tourne mal... J'ai des sueurs froides rien que d'y penser.";
        map["I'm nervous, April. Was this a mistake?"] = "Je stresse, April. Est-ce que c'était une erreur ?";
        map["Hey, you've earned this. Don't you forget that."] = "Hé, tu as mérité cette place. Ne l'oublie jamais.";
        map["Besides, didn't you want the chance to show those losers in Accounting how it gets done?"] = "Et puis, ne voulais-tu pas montrer à ces ronds-de-cuir de la compta comment on fait le job ?";
        map["You're right. It just doesn't feel real to me yet."] = "Tu as raison. C'est juste que je ne réalise pas encore tout à fait.";
        map["You're too used to being underestimated and ignored by a bunch of relics in their stuffy suits."] = "Tu t'es trop habituée à être sous-estimée par ces vieux débris engoncés dans leurs costumes amidonnés.";
        map["Pretty much anyone with a modicum of power, if you think about it."] = "Par quiconque détient une once de pouvoir, en vérité.";
        map["Now they want to put me on a mission, in the field? I'm not sure that it makes sense."] = "Et maintenant, ils m'envoient en mission sur le terrain ? Ça n'a pas beaucoup de sens.";
        map["Talking of stuffy suits, here comes one now."] = "En parlant de costume amidonné, en voilà justement un.";
        map["Ladies, how are we this fine morning?"] = "Mesdames, comment vous portez-vous en cette radieuse matinée ?";
        map["April Benelli, as you very well know, my name is not ‘Phil'."] = "April Benelli, vous savez parfaitement que mon prénom n'est pas « Phil ».";
        map["If you insist on addressing me by name, it's Sir Philately Stamp."] = "Si vous tenez à vous adresser à moi, c'est Sir Philately Stamp.";
        map["Yes, Sir Philately Stamp, Sorry Sir!"] = "Bien, Sir Philately Stamp, pardonnez-moi Monsieur !";
        map["*Sigh* Let's just dispense with the pleasantries shall we?"] = "*Soupir* Si nous passions les amabilités d'usage, voulez-vous ?";
        map["Diana, there's no easy way to say this..."] = "Diana, il n'y a pas quatre chemins pour le dire...";
        map["You're off the mission."] = "Vous êtes démise de cette mission.";
        map["Oh, I stand corrected! There was an easy way to say it!"] = "Oh, je me rétracte ! Finalement, c'était très simple à formuler !";
        map["Word came from up top, we're to shut down this whole unit."] = "L'ordre vient d'en haut : nous devons démanteler toute cette cellule.";
        map["But, why?"] = "Mais enfin, pourquoi ?";
        map["Oh, the usual. Something about a bloated budget, the numbers not adding up."] = "Oh, les raisons habituelles. Budget excessif, bilans qui ne cadrent pas.";
        map["Accounting is ironically quite unaccountable when it comes to things like answering questions."] = "La comptabilité refuse ironiquement de rendre des comptes quand on lui pose des questions.";
        map["Sorry to be the bearer of bad news. If you came here looking for mission gadgets, or to requisition a vehicle; I'm afraid we already relocated anything useful."] = "Navré d'être l'oiseau de mauvais augure. Si vous cherchiez des gadgets d'espionnage ou un véhicule, nous avons déjà réaffecté tout ce qui pouvait être utile.";
        map["Now, I best be off. This red tape isn't going to put itself up!"] = "Sur ce, je file. Cette paperasse administrative ne va pas s'empiler toute seule !";
        map["Oh, April, this was my best shot at getting into the field. I'm just so tired of being a civil servant."] = "Oh April, c'était ma seule chance d'aller sur le terrain. J'en ai tellement marre de jouer les fonctionnaires.";
        map["Is that right? Well, I'm tired of being civil."] = "Ah oui ? Eh bien moi, j'en ai marre d'être courtoise.";
        map["Come on, we're getting you on that train!"] = "Allez, viens, on va te faire monter à bord de ce train !";
        map["If they won't let you join the party, we'll crash it in style!"] = "S'ils refusent de t'inviter à la fête, on va s'incruster avec panache !";
        map["This bike could be our ride out of here, Diana!"] = "Cette moto pourrait bien être notre billet de sortie, Diana !";
        map["It's a little beaten up, but it should still be salvageable."] = "Elle est un peu esquintée, mais on peut encore la rafistoler.";
        map["What do you think?"] = "Qu'est-ce que tu en dis ?";
        map["Brilliant! I'll take a look around."] = "Génial ! Je vais faire le tour de la pièce.";
        map["If we get this bike working, I'll drive us right out of here!"] = "Si on remet ce bolide en état, je nous emmène dare-dare !";

        // Mansion Interior Will Reading & Safe Unlocking
        map["Ladies and gentlemen, we are gathered here today to mourn the passing of our dear, Lady Unterwald."] = "Mesdames et messieurs, nous sommes réunis ce jour pour pleurer la disparition de notre chère Lady Unterwald.";
        map["Struck down by her scheming attorney, a meddling detective and a train-wrecking saboteur."] = "Fauchée par son notaire véreux, un détective fouineur et une saboteuse de trains.";
        map["At least we can take some comfort in knowing that those three are securely behind bars."] = "Nous pouvons au moins trouver réconfort en sachant que ces trois fripouilles sont bien sous les verrous.";
        map["Thank you, Arista."] = "Merci, Arista.";
        map["I have, in my possession, the last known copy of Lady Unterwald's Last Will & Testament."] = "J'ai en ma possession la dernière copie répertoriée du testament de Lady Unterwald.";
        map["Arista must have provided the executor with a fake copy of the will."] = "Arista a forcément remis une fausse copie du testament à l'exécuteur.";
        map["Lady Unterwald said that a copy of her genuine will is kept here, I have to find it before the reading finishes!"] = "Lady Unterwald a dit qu'un double du vrai testament est ici. Je dois le trouver avant la fin de la lecture !";
        map["Incredible, it worked!"] = "Incroyable, ça a marché !";
        map["We need to get this to the executor and confront the family at once!"] = "Nous devons donner cela à l'exécuteur et confondre la famille sans tarder !";
        map["Leave my entire estate to my dear sister-in-law, Arista Gudrun."] = "...lègue l'intégralité de mes biens à ma chère belle-sœur, Arista Gudrun.";
        map["Ha ha, yes!"] = "Ha ha, oui !";
        map["Alright, Mr Liu. It's time to honour our agreement."] = "Bien, M. Liu. L'heure est venue d'honorer notre accord.";
        map["I hope you can still hold a pen?"] = "J'espère que vous avez encore la force de tenir une plume ?";
        map["Mmmpfff."] = "Mmmpfff.";
        map["Stop the reading at once!"] = "Interrompez cette lecture sur-le-champ !";
        map["You three again? What are you doing here?"] = "Encore vous trois ? Qu'est-ce que vous fichez ici ?";
        map["What's all this?"] = "Qu'est-ce que cela signifie ?";
        map["That document is a fake! We have the genuine copy right here!"] = "Ce document est un faux grossier ! Nous avons le véritable testament ici présent !";
        map["Mmmph!! Mmmmf!"] = "Mmmph !! Mmmmf !";
        map["Ladies and gentlemen, this looks to be genuine."] = "Mesdames et messieurs, cet acte paraît parfaitement authentique.";
        map["However, we should postpone the reading until I can evaluate the authenticity."] = "Toutefois, nous devons ajourner la lecture le temps que j'en examine la validité.";
        map["Well done, Arthur. We owe you a great debt."] = "Bien joué, Arthur. Nous avons une dette immense envers vous.";
        map["I suppose you'll be running the estate now that you own the place?"] = "J'imagine que vous allez administrer le domaine maintenant que vous en êtes propriétaire ?";
        map["Oh, I hadn't even thought about that."] = "Oh, je n'y avais même pas encore songé.";
        map["It can be more of an advisory role, you know."] = "Vous pourriez vous contenter d'un rôle consultatif, vous savez.";
        map["Say, Arthur. I don't suppose you'd be interested in a job?"] = "Dis-moi, Arthur. Ça ne te dirait pas un vrai travail ?";
        map["You want me to work for Inland Revenue?"] = "Tu veux que je travaille pour le fisc ?";
        map["I'm afraid it'd be a strictly bureaucratic position, for now."] = "Ce serait un poste purement bureaucratique, pour l'instant.";
        map["The amount of paperwork generated from this mission alone will keep us occupied for months."] = "La masse de formulaires engendrée par cette seule mission va nous occuper pendant des mois entiers.";
        map["We'd need a professional lackey to sort through this mess."] = "Il nous faudrait un gratte-papier émérite pour débroussailler tout ce bazar.";
        map["You said there'd be paperwork, and bureaucracy?"] = "Vous avez dit paperasse et bureaucratie ?";
        map["Oh yes, stacks of it, I'm afraid."] = "Oh oui, des piles entières, j'en ai bien peur.";
        map["And you'd have to be comfortable wearing the uniform, of course."] = "Et il vous faudrait porter l'uniforme officiel, naturellement.";
        map["There's a uniform?"] = "Il y a un uniforme ?";
        map["That's right, but it's perhaps a little unadventurous for your taste."] = "Tout à fait, mais c'est peut-être un peu trop austère à votre goût.";
        map["I'll take it!"] = "J'accepte !";
        map["There's one more locking mechanism to get through."] = "Il reste un dernier mécanisme de verrouillage à franchir.";
        map["This looks like another voice activated lock."] = "On dirait une autre serrure à commande vocale.";
        map["Is it expecting a fingerprint of some sort?"] = "Attend-elle une sorte d'empreinte digitale ?";

        // Arista Confession under Truth Serum
        map["Wha-! What was that!"] = "Qu- ! Qu'est-ce que c'était que ça !";
        map["I feel so strange."] = "Je me sens si bizarre.";
        map["Everyone, listen to me!"] = "Tout le monde, écoutez-moi !";
        map["I said, listen to m-"] = "J'ai dit : écoutez-m-";
        map["It's over, Arista. There's no getting out of this one."] = "C'est terminé, Arista. Vous ne vous en tirerez pas cette fois.";
        map["WHAAAAAA?"] = "QUOOOOOOOI ?";
        map["Doctor Hirsch? I killed you! You should be dead!"] = "Docteur Hirsch ? Mais je vous ai tué ! Vous devriez être mort !";
        map["Wait, did I say that out loud?"] = "Attendez... j'ai dit ça à voix haute ?";
        map["What's happening?"] = "Que m'arrive-t-il ?";
        map["Looks like someone got a strong dose of truth serum."] = "On dirait que quelqu'un a reçu une généreuse dose de sérum de vérité.";
        map["Ladies and gentlemen, I'm afraid an attempt was made on my life with this poison dart."] = "Mesdames et messieurs, j'ai le regret de vous annoncer qu'on a attenté à mes jours à l'aide de cette fléchette empoisonnée.";
        map["Why didn't it work?"] = "Pourquoi n'a-t-elle pas fonctionné ?";
        map["It was no different to the one I used to kill your dear Lady Unterwald!"] = "Elle était pourtant identique à celle dont je me suis servie pour supprimer votre chère Lady Unterwald !";
        map["Mother?"] = "Mère ?";
        map["Mmphh?!"] = "Mmphh ?!";
        map["Why couldn't she just sell the estate? We'd have all been rich instead of living in her shadow!"] = "Pourquoi refusait-elle de vendre ce fichu domaine ? Nous aurions tous été riches au lieu de croupir dans son ombre !";
        map["You treasonous goat!"] = "Espèce de traîtresse galeuse !";
        map["What have you done to me?"] = "Qu'avez-vous fait de moi ?";
        map["Why did I say that?"] = "Pourquoi ai-je avoué tout ça ?";
        map["What did you do, mother?"] = "Qu'as-tu fait, mère ?";
        map["Seize her!"] = "Arrêtez-la !";
        map["I think it's time to leave, boys. Help your dear mother escape!"] = "Je crois qu'il est temps de mettre les bouts, les garçons. Aidez votre chère mère à fuir !";
        map["Let's leave him here for now, my arms are getting tired."] = "Laissons-le là pour l'instant, mes bras commencent à fatiguer.";
        map["I should check on the doctor, but keep my distance from those ghastly twins."] = "Je devrais m'assurer de l'état du médecin, tout en restant à distance de ces abominables jumeaux.";
        map["I should look around for clues."] = "Je devrais chercher des indices.";

        // Mansion Lobby Scene (Hirsch poisoned)
        map["Did we get here first?"] = "Sommes-nous arrivés les premiers ?";
        map["Where is everybody?"] = "Où est tout le monde ?";
        map["And you're quite sure, Doctor Hirsch?"] = "Et vous en êtes parfaitement certain, docteur Hirsch ?";
        map["Uh oh, they're heading this way."] = "Oh oh, ils viennent par ici.";
        map["Indeed. We believe the murder weapon was fired as a projectile."] = "Tout à fait. Nous pensons que l'arme du crime a été tirée comme un projectile.";
        map["Hide!"] = "Planquez-vous !";
        map["Well, this is quite the development."] = "Eh bien, voilà une découverte de taille.";
        map["That's not all, Arista."] = "Ce n'est pas tout, Arista.";
        map["Oh, what's that? There's more?"] = "Ah bon ? Il y a autre chose ?";
        map["The dart, it was tipped with some sort of poison."] = "La fléchette... Sa pointe était enduite d'une sorte de poison.";
        map["Did I hear you right? Did you say poison?"] = "Ai-je bien entendu ? Vous avez dit du poison ?";
        map["Even if the dart hadn't hit an artery, I'm afraid Lady Unterwald's death was inevitable."] = "Même si la fléchette n'avait pas perforé une artère, la mort de Lady Unterwald était inéluctable.";
        map["The killer wasn't leaving it to chance, then."] = "L'assassin ne laissait donc rien au hasard.";
        map["Tell me, who else knows about this?"] = "Dites-moi, qui d'autre est au courant ?";
        map["I will consult with the rest of the order this evening."] = "Je consulterai les autres membres de l'Ordre ce soir.";
        map["I wanted to bring my findings to family members first, out of courtesy. "] = "J'ai tenu à présenter mes conclusions à la famille en premier lieu, par courtoisie.";
        map["I wanted to bring my findings to family members first, out of courtesy."] = "J'ai tenu à présenter mes conclusions à la famille en premier lieu, par courtoisie.";
        map["Of course. My dear sister would have appreciated that."] = "Bien sûr. Ma tendre sœur aurait apprécié cette délicatesse.";
        map["Thank you for bringing this to my attention, doctor."] = "Merci de m'en avoir informée, docteur.";
        map["Oh, would you turn around and tell me what that is over there, dear?"] = "Oh, pourriez-vous vous retourner pour me dire ce qui traîne là-bas, cher ami ?";
        map["Ackkk!"] = "Aaaaack !";
        map["Oh my, Doctor Hirsch!"] = "Mon Dieu, docteur Hirsch !";
        map["I'm afraid the poor doctor has taken a tumble, Gunter!"] = "J'ai bien peur que le pauvre docteur n'ait fait une vilaine chute, Gunter !";
        map["We need to move quickly. Take him to the basement, the both of you!"] = "Faisons vite. Portez-le au sous-sol, tous les deux !";
        map["Come to the lounge when you're finished, the executor is about to read Lady Unterwald's will."] = "Rejoignez-moi au salon quand vous aurez terminé : l'exécuteur testamentaire va procéder à la lecture.";
        map["Is this about our inheritance, mother?"] = "C'est au sujet de notre héritage, mère ?";
        map["I intend to sell the estate over to Mr Liu, as soon as we gain control of the assets."] = "J'ai l'intention de céder le domaine à M. Liu dès que nous aurons la mainmise sur le patrimoine.";
        map["He may have broken every bone in his body, but I'm sure he can manage a signature."] = "Il a beau avoir tous les os brisés, il sera bien capable d'apposer une signature.";
        map["Yes, mother!"] = "Bien, mère !";
        map["They're gone, the coast is clear."] = "Ils sont partis, la voie est libre.";
        map["Doctor Hirsch revealed the killer to us, but at what cost?"] = "Le docteur Hirsch nous a désigné le coupable, mais à quel prix ?";
        map["What a twist. My novel is going to be a real page turner."] = "Quel coup de théâtre ! Mon livre va être un vrai succès de librairie.";
        map["We need to focus on finding the original will and testament."] = "Concentrons-nous sur la recherche du testament original.";
        map["We can't let them benefit from that fraudulent copy."] = "Hors de question de les laisser profiter de cette imitation frauduleuse.";
        map["Arthur, you head to the library room."] = "Arthur, file dans la bibliothèque.";
        map["Alright! I can catch up on some light reading."] = "Compris ! Je pourrai en profiter pour faire un brin de lecture.";
        map["I'll check in on Lady Unterwald's private study."] = "Je vais fouiller le bureau privé de Lady Unterwald.";
        map["Herman, you check out the basement."] = "Herman, va voir ce qui se trame au sous-sol.";
        map["I get the murder basement? Are you trying to get me killed?"] = "Moi j'hérite du sous-sol de l'angoisse ? Vous voulez ma mort ou quoi ?";
        map["We can use the pneumatic tube system to send each other any clues we find."] = "Nous pouvons utiliser les tubes pneumatiques pour nous transmettre les indices.";
        map["That's definitely more refined than the prison tube system."] = "C'est nettement plus raffiné que la tuyauterie de la prison.";

        // Finale & Epilogue
        map["Oh good, I'm not too late to the party!"] = "Merveilleux, j'arrive pile à temps pour la fête !";
        map["Who the hell are you?"] = "Qui diable êtes-vous ?";
        map["Stop him, boys!"] = "Arrêtez-le, les garçons !";
        map["We won't let you near our mother!"] = "On ne te laissera pas approcher de notre mère !";
        map["You'll have to go through us first!"] = "Il faudra nous passer sur le corps d'abord !";
        map["That suits me just fine."] = "Ça tombe très bien, c'est mon rayon.";
        map["Allow me to introduce you to hammer and chisel!"] = "Laissez-moi vous présenter mon marteau et mon burin !";
        map["Isn't that Dirk Chiselton fighting the twins?"] = "C'est bien Dirk Chiselton qui castagne les jumeaux ?";
        map["Oh no. Why'd it have to be Chiselton?"] = "Oh non. Pourquoi fallait-il que ce soit Chiselton ?";
        map["Looks like we got here just in time, Chiselton."] = "On dirait qu'on arrive juste à temps, Chiselton.";
        map["How'd you figure it out?"] = "Comment as-tu découvert le pot aux roses ?";
        map["Those three laid a lot of the groundwork. I just put the pieces together."] = "Ces trois-là ont déblayé le terrain. Je n'ai fait qu'assembler les pièces du puzzle.";
        map["Well, we'd better get these three back to the station."] = "Bon, on ferait bien d'embarquer ces trois coquins au commissariat.";
        map["You can't arrest me, I'm innocent!"] = "Vous ne pouvez pas m'arrêter, je suis innocent !";
        map["And rich! You can't put rich people in handcuffs!"] = "Et riche ! On ne passe pas les menottes aux gens fortunés !";
        map["Shut up, both of you!"] = "Fermez-la, tous les deux !";
        map["Come on, let's go!"] = "En route, tout le monde !";
        map["That was some fine detective work, Herman."] = "C'était du travail d'enquête remarquable, Herman.";
        map["It was?"] = "Vraiment ?";
        map["Listen, Herman, I've got a case that's been bugging me for a while."] = "Écoute, Herman, j'ai une affaire sur les bras qui me taraude depuis un bail.";
        map["Wouldn't mind another pair of eyes on it, if you're interested?"] = "Je ne refuserais pas une autre paire d'yeux dessus, si ça te tente ?";
        map["You're suggesting we form some sort of crime fighting detective duo?"] = "Tu es en train de me proposer de former un duo d'enquêteurs de choc ?";
        map["Yeah, something like that. Are you in?"] = "Ouais, dans ce genre-là. Tu en es ?";
        map["It's all I've ever wanted!"] = "C'est tout ce dont j'ai toujours rêvé !";
        map["Well, Diana..."] = "Eh bien, Diana...";
        map["You disrespected my orders, stole a bunch of classified gadgets, and blew up an express train."] = "Vous avez bafoué mes ordres, dérobé des gadgets classés secret défense et fait dérailler un train de luxe.";
        map["However, I can't argue with results."] = "Toutefois, je ne saurais contester les résultats.";
        map["Congratulations, field agent."] = "Toutes mes félicitations, agent de terrain.";
        map["I've got the job? I'm a field agent!"] = "J'ai le poste ? Je suis officiellement agent de terrain !";
        map["I knew you could do it, Diana!"] = "Je savais que tu y arriverais, Diana !";
        map["There's the train!"] = "Voilà le train !";
        map["Can you get us any closer?"] = "Tu peux nous rapprocher encore un peu ?";
        map["I'll try!"] = "Je vais essayer !";
        map["Damn it, this is as fast as we can go!"] = "Bon sang, c'est la vitesse maximale !";
        map["We're too far away!"] = "Nous sommes trop loin !";
        map["Diana, think of something quick, or we're going to miss the train!"] = "Diana, trouve une idée vite, sinon on va rater le train !";
        map["On it!"] = "Je m'en charge !";

        // Station Exterior & Jailbreak
        map["Who's out there? Reveal yourself!"] = "Qui est là ? Montrez-vous !";
        map["Is Diana there?"] = "Diana est avec vous ?";
        map["You know Diana?"] = "Vous connaissez Diana ?";
        map["Keep your voice down!"] = "Baissez d'un ton !";
        map["Who are you?"] = "Qui êtes-vous ?";
        map["Listen, I'm from the Inland Revenue Secret Service!"] = "Écoutez-moi : je fais partie des services secrets du fisc !";
        map["Is this about my self assessment? You people are relentless!"] = "C'est encore pour ma déclaration de revenus ? Vous êtes impitoyables !";
        map["I'm not here about your taxes, idiot! I'm trying to break you out."] = "Je ne viens pas pour vos impôts, crétin ! J'essaie de vous faire évader.";
        map["A jailbreak? Are you mad?"] = "Une évasion ? Vous avez perdu la tête ?";
        map["What about my reputation? I'd be branded an escaped fugitive!"] = "Et ma réputation, vous y pensez ? Je serais traqué comme un fugitif en cavale !";
        map["On the other hand, it would definitely give a boost to my book sales."] = "D'un autre côté, cela doperait sans nul doute les ventes de mes romans.";
        map["Listen, Herbert! Stop daydreaming and pay attention!"] = "Écoute-moi bien, Herbert ! Arrête de rêvasser et ouvre grand tes oreilles !";
        map["We need to get you three to Lady Unterwald's mansion!"] = "Nous devons impérativement vous amener au manoir de Lady Unterwald !";
        map["The mansion?"] = "Le manoir ?";
        map["The family are preparing a second will reading!"] = "La famille prépare une seconde lecture du testament !";
        map["I suppose it would be an opportunity to clear my name."] = "J'imagine que ce serait l'occasion rêvée de laver mon honneur.";
        map["Then there's no time to waste!"] = "Alors il n'y a pas une minute à perdre !";
        map["Do you have anything in your cells that could bend those bars?"] = "Avez-vous quoi que ce soit dans vos cellules pour tordre ces barreaux ?";
        map["Nothing immediate comes to mind. I'll have to think about it."] = "Rien d'immédiat ne me vient à l'esprit. Il va falloir que je réfléchisse.";
        map["You might want to stand away from the wall!"] = "Vous feriez bien de vous éloigner du mur !";
        map["Hey! Stop escaping, you ruddy delinquents!"] = "Hé ! Arrêtez de vous évader, sales voyous !";
        map["Thanks for breaking me out of the joint."] = "Merci de m'avoir sorti du trou.";
        map["Are you sure you don't want to come with us?"] = "Tu es sûr de ne pas vouloir venir avec nous ?";
        map["It's been a blast, but ol' Donny's got to fend for himself, y'know?"] = "C'était bien marrant, mais le vieux Donny doit tracer sa route en solo, pigé ?";
        map["Hey, you give those crooks a beating for ol' Don, ya hear me?"] = "Hé, flanquez une bonne raclée à ces pourritures de ma part, compris ?";
        map["Good luck to ya guys!"] = "Bonne chance à vous, les amis !";
        map["Hop on, everyone."] = "Grimpez tous, allez !";
        map["Where are we going?"] = "Où va-t-on ?";
        map["We need to get to that mansion!"] = "Nous devons atteindre ce manoir !";
        map["I was sure Lady Unterwald was deliberately trying to evade scrutiny of her finances."] = "J'étais persuadée que Lady Unterwald tentait délibérément de dissimuler ses finances.";
        map["Why bury mountains of contradictory paperwork in her hidden safe?"] = "Pourquoi cacher des montagnes de documents contradictoires dans son coffre ?";
        map["Someone must be trapped inside!"] = "Quelqu'un doit être enfermé à l'intérieur !";
        map["LET ME OUT!"] = "OUVREZ-MOI !";
        map["IS ANYONE THERE?"] = "IL Y A QUELQU'UN ?";
        map["HELP!"] = "À L'AIDE !";

        // Write output TSV
        int count = 0;
        using (var sw = new StreamWriter(@"translations\partitions\c3_b3_french.tsv", false, Encoding.UTF8)) {
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
        Console.WriteLine(string.Format("Generated c3_b3_french.tsv: {0} lines processed out of {1}", count, lines.Length - 1));
    }
}
