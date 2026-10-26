using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class BuildSharedCutscenes {
    static void Main() {
        var map = new Dictionary<string, string>();

        // CloseupArthurDevice
        map["Please, I just need more time!"] = "De grâce, j'ai juste besoin d'un peu plus de temps !";
        map["We had an agreement, Herman."] = "Nous avions un accord, Herman.";
        map["I don't want to have to call off our deal."] = "Je n'aimerais pas avoir à annuler notre contrat.";
        map["It's not my fault!"] = "Ce n'est pas de ma faute !";
        map["You'll just have to figure it out! We believe in you."] = "Débrouillez-vous comme vous voulez ! Nous croyons en vous.";
        map["I have to go! It's not safe here!"] = "Je dois filer ! Cet endroit n'est pas sûr !";

        // CloseupChiseltonEntrance
        map["The name's Dirk Chiselton, and you're under arrest!"] = "Mon nom est Dirk Chiselton, et vous êtes en état d'arrestation !";

        // CloseupDianaRadio
        map["April, I've made contact with the informant."] = "April, le contact avec l'indicateur est établi.";
        map["I'm afraid we've hit a bit of a snag. Lady Unterwald was murdered."] = "Hélas, nous avons un fâcheux contretemps. Lady Unterwald a été assassinée.";
        map["Not only that, our informant isn't as sharp as our intelligence had me believe."] = "Et pour couronner le tout, notre indicateur est loin d'être aussi brillant que nos renseignements l'affirmaient.";
        map["Murdered? Diana, you need to get out of there."] = "Assassinée ? Diana, tu dois déguerpir de là sur-le-champ.";
        map["Not yet, you know I need to do this!"] = "Pas encore, tu sais bien que je dois mener cette mission à bien !";
        map["Diana, it's your first mission in the field!"] = "Diana, c'est ta toute première mission sur le terrain !";
        map["Please! You aren't equipped to face a killer."] = "Je t'en prie ! Tu n'es pas armée pour affronter un tueur.";
        map["I can still salvage this mission."] = "Je peux encore sauver cette mission.";

        // CloseupHeatingNapkin
        map["Wait, I see something!"] = "Attendez, je vois quelque chose !";

        // CloseupHermanDisguised
        map["Ho ho! You've outdone yourself this time, old chap."] = "Ho ho ! Tu t'es surpassé cette fois-ci, mon vieux.";

        // CloseupHermanPose
        map["Acclaimed novelist? Detective extraordinaire?"] = "Romancier de renom ? Détective hors pair ?";

        // CloseupMiniRecorder
        map["It's all my fault..."] = "Tout est de ma faute...";
        map["...I bankrupted the company."] = "...J'ai mis l'entreprise sur la paille.";

        // CloseupOriginalWill
        map["Lady Unterwald was right, the original will is here!"] = "Lady Unterwald avait raison, l'authentique testament se trouve bien ici !";

        // GlobalScript Drunk & Item
        map["What do you think of this?"] = "Que pensez-vous de cela ?";
        map["Whatschup?"] = "Quoi d'neuf ?";
        map["Greetingschh."] = "Sssalutationsch...";
        map["Howsschit going?"] = "Comment cha va-t-y ?";
        map["Can I asshk you a queshhtion?"] = "J'peux vous poser une queshtion ?";

        // GuiMedicalRecords
        map["Is that Lady Unterwald's date of birth?"] = "Serait-ce la date de naissance de Lady Unterwald ?";
        map["She certainly had a good run."] = "Elle a drôlement bien profité de la vie.";

        // GuiSetList
        map["It's the set list for the band, Balboa Swing."] = "C'est le programme des morceaux du groupe Balboa Swing.";
        map["The songs are to be played in the following order."] = "Les morceaux doivent être joués dans l'ordre suivant.";
        map["Railroad Rhythm."] = "Railroad Rhythm.";
        map["Whistle Stop Swing."] = "Whistle Stop Swing.";
        map["Boxcar Boogie."] = "Boxcar Boogie.";
        map["My Love is on the Line."] = "My Love is on the Line.";
        map["Freight Train Blues."] = "Freight Train Blues.";

        // RoomBathroom
        map["Gah!"] = "Gah !";
        map["I'm stuck!"] = "Je suis coincé !";
        map["The vent narrows too much, we can't get through."] = "Le conduit se rétrécit trop, impossible de passer.";
        map["I'll just add this to my collection."] = "Je vais simplement ajouter ceci à ma collection.";
        map["I'm sure they won't mind me taking this."] = "Je suis certain qu'on ne m'en voudra pas d'emprunter cela.";
        map["There's nothing in there to flush."] = "Il n'y a rien à évacuer là-dedans.";

        // RoomCasinoCarriage
        map["You! Where have you been!"] = "Vous ! Où étiez-vous passé !";
        map["I'm sorry?"] = "Pardon ?";
        map["You said you're a detective, right?"] = "Vous disiez être détective, n'est-ce pas ?";
        map["I said I'm a novelist, I write detective novels."] = "J'ai dit que j'étais romancier, j'écris des romans policiers.";
        map["That's close enough! I need your assistance, detective novelist!"] = "C'est bonnet blanc et blanc bonnet ! J'ai besoin de votre aide, romancier détective !";
        map["What's the problem?"] = "Quel est le problème ?";
        map["It's my boys!"] = "Ce sont mes petits protégés !";
        map["I sent them to eavesdro- I mean, repair that ventilation system!"] = "Je les ai envoyés pour écouter aux por... enfin, pour réparer ce système de ventilation !";
        map["They haven't come back."] = "Ils ne sont toujours pas revenus.";
        map["They're stuck inside the ducts?"] = "Ils sont coincés dans les conduits ?";
        map["I could direct them back with my horn, but I blew it out last time."] = "Je pourrais les guider vers la sortie avec mon cornet, mais il a rendu l'âme la dernière fois.";
        map["I should've known they'd get lost in there."] = "J'aurais dû me douter qu'ils se perdraient là-dedans.";
        map["You need me to fix your hearing horn?"] = "Vous voulez que je répare votre cornet acoustique ?";
        map["They're always blowing into their brass instruments, they'll know what to do!"] = "Ils n'arrêtent pas de souffler dans leurs cuivres, ils sauront quoi faire !";
        map["Doesn't this thing go in your ear? I'm not su-"] = "Cet engin ne se met-il pas dans votre oreille ? Je ne suis pas sû...-";
        map["I'll see what I can do?"] = "Je verrai ce que je peux faire ?";
        map["Perfect! Come find me when you're done."] = "Parfait ! Retrouvez-moi quand vous aurez terminé.";
        map["It's kind of making me dizzy."] = "Ça me donne un peu le tournis.";

        // RoomCell
        map["That did the job!"] = "Ça a fait l'affaire !";
        map["Psst! Is that you, kid?"] = "Psst ! C'est toi, fiston ?";
        map["Don, is that you?"] = "Don, c'est vous ?";
        map["Hah, I knew your voice sounded familiar!"] = "Hah, je savais bien que cette voix m'était familière !";
        map["Don't tell me those casino goons got you too, huh?"] = "Ne me dis pas que les gorilles du casino t'ont coincé toi aussi ?";
        map["Argh, who is doing that obnoxious clicking?"] = "Argh, qui est responsable de cet abominable cliquetis ?";
        map["I can barely hear myself think!"] = "Je m'entends à peine penser !";
        map["It won't budge!"] = "Ça ne veut pas bouger !";
        map["I think that's reversed the flow of the water!"] = "Je crois que ça a inversé le sens du courant d'eau !";
        map["There's nothing in there to flush. That'd be a waste of water!"] = "Il n'y a rien à évacuer. Ce serait du pur gaspillage d'eau !";
        map["I've already sent something towards Diana's cell."] = "J'ai déjà expédié quelque chose vers la cellule de Diana.";
        map["Something's coming your way, Diana!"] = "Quelque chose arrive vers toi, Diana !";
        map["Over to you, Diana!"] = "À toi de jouer, Diana !";
        map["I've sent something your way, Diana!"] = "Je t'ai envoyé un truc, Diana !";
        map["Hmm, I'm not sure that I'd trust Don with that item."] = "Hmm, je ne suis pas certain de pouvoir confier cet objet à Don.";
        map["I probably shouldn't send that Don's way."] = "Je devrais sans doute éviter d'envoyer ça à Don.";
        map["I'm not sure Don would get much use out of that."] = "Pas sûr que Don puisse en tirer grand-chose.";
        map["Can Don be trusted with this? Probably not."] = "Peut-on faire confiance à Don avec ceci ? Probablement pas.";
        map["I've already sent something to Don's cell."] = "J'ai déjà envoyé quelque chose dans la cellule de Don.";
        map["I already sent an item Donny's way!"] = "J'ai déjà expédié un objet à Donny !";
        map["Time to reunite Donny with an old friend!"] = "Il est temps de réunir Donny et une vieille connaissance !";
        map["I sent something your way, Don."] = "Je vous ai envoyé quelque chose, Don.";
        map["Alright, let's see what we got here..."] = "Bien, voyons un peu ce qu'on a là...";
        map["Ha ha! You're a miracle worker, kid!"] = "Ha ha ! Tu es un faiseur de miracles, fiston !";
        map["I'll still need one of you to distract that bozo outside, though."] = "Il me faudra quand même que l'un de vous fasse diversion auprès du clampin dehors.";
        map["There's nothing to flush."] = "Il n'y a rien à tirer.";
        map["That would be a waste of water."] = "Ce serait du gaspillage d'eau.";
        map["There's no use flushing, the bowl is empty."] = "Inutile de tirer la chasse, la cuvette est vide.";
        map["I've already sent something to Herman's cell."] = "J'ai déjà envoyé quelque chose vers la cellule d'Herman.";
        map["Herman already has an item waiting for him."] = "Herman a déjà un objet qui l'attend.";
        map["Something coming your way, Herman!"] = "Un paquet en approche, Herman !";
        map["Heads up, Herman!"] = "Attention là-dessous, Herman !";
        map["I'm sending something your way, Herman!"] = "Je t'envoie quelque chose, Herman !";
        map["I've already sent something to Arthur's cell."] = "J'ai déjà envoyé quelque chose vers la cellule d'Arthur.";
        map["Arthur already has an item waiting for him."] = "Arthur a déjà un objet qui l'attend.";
        map["I've sent something your way, Arthur!"] = "Je t'ai envoyé un objet, Arthur !";
        map["Heads up, Arthur!"] = "Attention là-dessous, Arthur !";
        map["Keep an eye out, Arthur! Something is coming your way!"] = "Ouvre l'œil, Arthur ! Quelque chose arrive par le conduit !";
        map["Hmm. There's a set of chains stuck down there."] = "Hmm. Il y a un jeu de chaînes coincé tout au fond.";
        map["I can't get the blockage free with my bare hands."] = "Impossible de débloquer ça à mains nues.";
        map["I'll flush when there's something worth flushing!"] = "Je tirerai la chasse quand il y aura quelque chose qui en vaut la peine !";
        map["The bowl is empty, it's not worth flushing."] = "La cuvette est vide, inutile d'actionner la chasse.";
        map["Hmm, that item didn't seem to move."] = "Hmm, cet objet ne semble pas avoir bougé.";
        map["No luck, the item didn't budge!"] = "Pas de chance, l'objet n'a pas bougé d'un millimètre !";
        map["It didn't move. The water must be flowing the wrong direction."] = "Rien n'a bougé. L'eau doit s'écouler dans la mauvaise direction.";
        map["I've already sent an item Diana's way."] = "J'ai déjà expédié un objet en direction de Diana.";
        map["Diana already has something waiting for her."] = "Diana a déjà quelque chose qui l'attend.";
        map["Item coming your way, Diana!"] = "Un objet arrive vers toi, Diana !";

        // RoomCellExterior
        map["Your call is being forwarded to the Dirk Chiselton Hotline, please hold."] = "Votre appel est transféré vers la ligne directe de Dirk Chiselton, veuillez patienter.";
        map["What do ya need?"] = "Qu'est-ce qu'il te faut ?";

        // RoomDianaPhoto
        map["It's a photograph of a woman..."] = "C'est la photographie d'une femme...";
        map["Wait, there's something scrawled on the back."] = "Attendez, il y a une note griffonnée au dos.";
        map["''Informant. Wear blue suit with red rosette for identification.''"] = "« Indicateur. Porter un costume bleu avec une cocarde rouge pour être reconnu. »";

        // RoomDianaQuarters
        map["Good work, Arthur. I knew this wouldn't be a wasted trip."] = "Beau travail, Arthur. Je savais que ce voyage ne serait pas vain.";
        map["See if you can find out any more information."] = "Voyez si vous pouvez dégoter d'autres informations.";
        map["I'll continue to monitor the situation from here."] = "Je continuerai à surveiller la situation depuis ma cabine.";
        map["What are these for?"] = "À quoi servent-elles ?";
        map["They're blank reels for the wire recorder."] = "Ce sont des bobines vierges pour l'enregistreur à fil.";
        map["Mind if I take one?"] = "Ça vous ennuie si j'en prends une ?";
        map["I need to know I can trust you, Arthur."] = "J'ai besoin de savoir si je peux vous faire confiance, Arthur.";
        map["Have you managed to find anything?"] = "Avez-vous réussi à mettre la main sur quelque chose ?";
        map["Sure, go ahead."] = "Bien sûr, servez-vous.";
        map["Whee!"] = "Youpi !";

        // RoomDiningCarriage
        map["Uh-oh!"] = "Oh-oh !";
        map["Itsh moved towardss the sshleeper carriagess."] = "Cha ss'est envolé verss les wagonss-litss.";
        map["If I could jussht get it back, i'm schure it'd hold sschome answerss."] = "Ssi j'pouvais jusste le rattraper, chuis ssûr qu'il donnerait dess réponsess.";
        map["I'd have some of that coffee, if I were you."] = "Je prendrais bien un peu de ce café, à votre place.";
        map["I'll jusht have a sship."] = "J'vais jusste en boire une petite gorgée.";
        map["Ooh, that's shtrongg!"] = "Ouh là, c'est drôlement corssé !";
        map["Don dropped his keys in the commotion."] = "Don a laissé tomber son trousseau de clés dans la bousculade.";
        map["I really should return them to him."] = "Je devrais vraiment le lui rendre.";
        map["No, I can't lose it again!"] = "Non, je ne peux pas le perdre à nouveau !";
        map["It's moved towards the sleeper carriages."] = "Il est parti en direction des voitures-lits.";
        map["If I can get that will back, it might hold some answers."] = "Si je parviens à récupérer ce testament, il pourrait m'apporter des réponses.";
        map["What's this?"] = "Qu'est-ce que c'est ?";
        map["It's a recorker."] = "C'est une reboucheuse.";
        map["It reseals opened bottles."] = "Ça permet de reboucher les bouteilles entamées.";
        map["Can I borrow it?"] = "Puis-je vous l'emprunter ?";
        map["I guess."] = "J'imagine que oui.";
        map["Ah! This must be what Don was looking for."] = "Ah ! C'est sans doute ce que cherchait Don.";
        map["I'll just take one."] = "Je vais simplement en prendre un.";

        // RoomDonCasinoChips & Quarters
        map["That's a lot of contraband."] = "Voilà qui fait un sacré paquet de contrebande.";
        map["Yoink!"] = "Et hop !";
        map["Oh, I guess he's not in here."] = "Oh, je suppose qu'il n'est pas là.";
        map["This is where Donny put his gambling scheme into motion."] = "C'est ici que Donny a orchestré saCombine de jeu.";
        map["Donny?"] = "Donny ?";
        map["Hmm. Those goons from the casino must have taken him away."] = "Hmm. Ces brutes du casino ont dû l'emmener de force.";
        map["No time for that!"] = "Pas le temps pour ça !";
        map["No time for that now!"] = "Pas le temps de m'occuper de ça maintenant !";
        map["I don't have much time!"] = "Je n'ai que très peu de temps !";
        map["That won't help me."] = "Ça ne me sera d'aucun secours.";
        map["I won't fit in there!"] = "Je ne rentrerai jamais là-dedans !";
        map["I really should check that drawer before leaving."] = "Je devrais impérativement fouiller ce tiroir avant de partir.";
        map["Uh oh, someone's coming!"] = "Oh oh, quelqu'un arrive !";
        map["He'll see me if I leave, I need to hide."] = "Il me verra si je sors, je dois me cacher.";
        map["Hmm, I probably shouldn't steal this unless I really need it."] = "Hmm, je ferais mieux de ne pas chiper ça à moins d'une absolue nécessité.";
        map["I'm sure Don won't mind if I borrow this."] = "Je suis certain que Don ne m'en voudra pas de lui emprunter.";
        map["Looks like I'll need another wire reel to record anything new."] = "On dirait qu'il me faut une autre bobine de fil pour enregistrer quoi que ce soit d'autre.";
        map["The secret panel was right around here."] = "Le panneau secret se trouvait juste par ici.";
        map["Aha! Let's take a look."] = "Aha ! Jetons un œil.";
        map["There's no way I'm getting in that bed."] = "Hors de question que je me mette dans ce lit.";
        map["Don left his poetry book behind, I should keep it safe for him."] = "Don a oublié son recueil de poésie, je ferais bien de le lui garder au chaud.";

        // RoomExteriorCarriage
        map["Time's up!"] = "Le temps est écoulé !";
        map["Goodbye Mr Ackerman."] = "Adieu, monsieur Ackerman.";
        map["What on earth are you doing?"] = "Mais que diable êtes-vous en train de faire ?";

        // RoomGreenRoom
        map["He's back!"] = "Le revoilà !";
        map["There he is!"] = "Ah, le voilà !";
        map["Back for more are ya?"] = "De retour pour en reprendre une couche, hein ?";
        map["Hey, get over here."] = "Hé, viens par ici.";
        map["How's the paw holding up? All good?"] = "Comment va la papatte ? Tout roule ?";
        map["A little sore, but fine, all things considered!"] = "Un peu endolorie, mais tout va bien, tout bien considéré !";
        map["I worked wonders to get back here, I can't leave now!"] = "J'ai remué ciel et terre pour revenir ici, je ne vais pas repartir maintenant !";
        map["Hm. I should see if the band has answers before I make my exit."] = "Hm. Je devrais vérifier si les musiciens ont des réponses avant de m'éclipser.";
        map["Are you leaving already?"] = "Tu t'en vas déjà ?";
        map["I'm afraid I have other lines of enquiry."] = "J'ai bien peur d'avoir d'autres pistes à explorer.";
        map["Nah! Why don't you play one round of 'Knifey, Stab, Stab' with us?"] = "Mais non ! Pourquoi tu ne ferais pas une partie du jeu du couteau avec nous ?";
        map["Come on, we haven't had a new player in a while!"] = "Allez, on n'a pas eu de nouveau joueur depuis un bail !";
        map["Go onnnn!"] = "Allez, viens quoi !";
        map["Fine. What sort of game is it?"] = "Soit. De quel genre de jeu s'agit-il ?";
        map["Here, I'll go first."] = "Regarde, je commence.";
        map["Fine. What sort of card game is it?"] = "Très bien. De quel genre de jeu de cartes s'agit-il ?";
        map["Card game?"] = "Jeu de cartes ?";
        map["You're playing with the big boys, now! You better watch and learn!"] = "Tu joues dans la cour des grands, maintenant ! Ouvre bien les yeux et apprends !";
        map["Haha, not a scratch on me!"] = "Haha, pas la moindre égratignure !";
        map["Alright, show us what you've got."] = "À toi de jouer, montre-nous ce que tu as dans le ventre.";
        map["Ah. I think I've changed my mind."] = "Ah. J'ai bien l'impression d'avoir changé d'avis.";
        map["Naah, go on. Just give it a try!"] = "Mais non, lance-toi. Tente ta chance !";
        map["So far, so good."] = "Jusqu'ici, tout va bien.";
        map["You're a natural!"] = "Tu as ça dans le sang !";
        map["It's easier than it looks!"] = "C'est bien plus facile qu'il n'y paraît !";
        map["Blimey, it's gone in like a hot knife through butter!"] = "Nom d'un chien, c'est rentré comme dans du beurre !";
        map["Is that... blood?"] = "Est-ce là... du sang ?";
        map["I'm feeling a little woozy."] = "Je me sens un tantinet patraque.";

        // RoomHandshakeClub
        map["I'd like to initiate another emergency vote!"] = "J'aimerais lancer un nouveau vote d'urgence !";
        map["Once again, I must stress the time-sensitive nature of our decision!"] = "Une fois de plus, je me dois d'insister sur le caractère éminemment urgent de notre décision !";
        map["Very good, all those in favour?"] = "Très bien, que ceux qui sont pour se manifestent ?";
        map["Aye!"] = "Pour !";
        map["And all those against?"] = "Et tous ceux qui sont contre ?";
        map["Nay!"] = "Contre !";
        map["W-Whhm?"] = "G-Grmbl ?";
        map["Well, that provided no more clarity than our previous vote."] = "Eh bien, cela ne nous éclaire pas plus que le vote précédent.";
        map["Aiyeeeee!"] = "Aiyeeeee !";
        map["The ayes have it!"] = "Les pour l'emportent !";
        map["It seems we have come to an agreement."] = "Il semble que nous soyons parvenus à un accord.";
        map["Sorry, Jian. We'll do things by the book here."] = "Désolé, Jian. Nous ferons les choses selon les règles établies.";
        map["I've tried things your way, but it is clear my efforts here have been fruitless."] = "J'ai essayé votre méthode, mais il est clair que mes efforts sont restés vains.";
        map["I see now that I must take matters into my own hands!"] = "Je comprends à présent que je dois prendre les choses en main personnellement !";
        map["Well, that sounded ominous."] = "Eh bien, voilà qui sonnait plutôt inquiétant.";
        map["My word, I'll catch up with him before he does anything rash!"] = "Bonté divine, je vais le rattraper avant qu'il ne commette l'irréparable !";
        map["I sshould ask Mr Masson if he's scheeen that briefcashhe."] = "J'devrais d'mander à M'sieur Masson s'il a vu chette mallette.";
        map["It's a corked up mouse burrow."] = "C'est un terrier de souris hermétiquement bouché.";

        // RoomHermanExterior & Quarters
        map["It's Lady Unterwald's will, it must have travelled down the carriages!"] = "C'est le testament de Lady Unterwald, il a dû dériver le long des wagons !";
        map["Aha! I've got you this time!"] = "Aha ! Je te tiens cette fois !";
        map["No! Don't you dare!"] = "Non ! Ne fais pas ça !";
        map["I don't think I should open another window after last time. Not without good reason."] = "Je ne devrais pas ouvrir une autre fenêtre après ce qui s'est passé. Pas sans une excellente raison.";
        map["What happened last time?"] = "Que s'est-il passé la dernière fois ?";
        map["I don't want to talk about it."] = "Je préfère ne pas en parler.";
        map["I think... it's working!"] = "Je crois que... ça marche !";
        map["What's with all the wriggling?"] = "Pourquoi tous ces gigotements ?";
        map["You weren't trying to escape, were you?"] = "Tu n'essayais pas de te faire la malle, au moins ?";
        map["No, of course not!"] = "Non, bien sûr que non !";
        map["Good, because that would be very bad for us!"] = "Tant mieux, parce que ça barderait sérieusement pour notre matricule !";

        // RoomInlandRevenueHQ
        map["Someone left out one of those pneumatic tube pods."] = "Quelqu'un a laissé traîner l'une de ces capsules pour tube pneumatique.";
        map["This could come in handy!"] = "Ça pourrait s'avérer utile !";
        map["You might not be perfect, but I'll take any help I can get!"] = "Tu n'es peut-être pas parfait, mais je prends toute l'aide qui se présente !";
        map["You're coming with me, Agent M!"] = "Tu viens avec moi, Agent M !";
        map["Haha! Listen to this kitty roar!"] = "Haha ! Écoute un peu rugir le moteur !";
        map["Ladies! What on earth are you doing!?"] = "Mesdemoiselles ! Que diable fabriquez-vous là ?!";
        map["Apologies, Mr Stamp. Our mission awaits!"] = "Toutes nos excuses, monsieur Stamp. Notre devoir nous appelle !";
        map["Don't you dare, Diana Osterhagen!"] = "N'osez même pas y songer, Diana Osterhagen !";
        map["P-Please, think of the paperwork involved!"] = "J-Je vous en supplie, songez à la montagne de paperasse !";
        map["See you later, Phil!"] = "À plus tard, Phil !";
        map["*Groans*"] = "*Gémissement*";
        map["I'm going to be in a lot of trouble."] = "Je vais m'attirer les pires ennuis du monde.";
        map["Hrmm-hmm."] = "Hrmm-hmm.";
        map["Thank you for calling Inland Revenue support. Your call is being forwarded to the hint department, please hold."] = "Merci d'avoir contacté l'assistance du fisc. Votre appel est transféré au service des indices, ne quittez pas.";
        map["We have a hint department?"] = "Nous avons un service des indices ?";
        map["Nothing happened. I must be missing something."] = "Rien ne s'est produit. Il doit me manquer un élément.";
        map["Ready for a little adventure, Agent M?"] = "Prêt pour une petite aventure, Agent M ?";
        map["Psst! Agent M, grab me one of those wiring kits!"] = "Psst ! Agent M, attrape-moi un de ces kits de câblage !";
        map["A little more to the left!"] = "Encore un tout petit peu sur la gauche !";
        map["That's it! Bring it over here!"] = "C'est ça ! Rapporte-le par ici !";
        map["Come to Diana!"] = "Viens voir Diana !";

        // RoomKitchenCarriage
        map["They won't mind if I borrow these."] = "Ils ne m'en voudront pas si je leur emprunte ceci.";
        map["Leave that tap alone!"] = "Laissez ce robinet tranquille !";
        map["Is that necessary, inspector?"] = "Est-ce bien nécessaire, inspecteur ?";
        map["I'm just checking the taps."] = "Je ne fais que vérifier les robinets.";
        map["They won't mind if I borrow this."] = "On ne m'en voudra pas d'emprunter ceci.";
        map["I'm not going to touch this while the grill is on."] = "Je ne vais pas toucher à ça pendant que le grill est allumé.";
        map["Does anyone else smell gas?"] = "Est-ce que quelqu'un d'autre sent le gaz ?";
        map["I was just checking the valve. All seems to be in working order!"] = "Je vérifiais simplement la vanne. Tout semble en parfait état de marche !";
        map["Hey, leave that alone!"] = "Hé, pas touche à ça !";
        map["I'm sure they won't miss a plunger."] = "Une ventouse de moins ne leur manquera certainement pas.";
        map["Mon dieu, get away from there!"] = "Mon Dieu, éloignez-vous de là !";
        map["Inspector! Do not touch that."] = "Inspecteur ! Ne touchez pas à cela.";
        map["Please, inspector! She is sensitive!"] = "De grâce, inspecteur ! Elle est hypersensible !";
        map["Mon dieu ! Leave Fiammetta alone!"] = "Mon Dieu ! Laissez Fiammetta tranquille !";
        map["I told you not to touch her, inspector!"] = "Je vous avais dit de ne pas la toucher, inspecteur !";
        map["Fiammetta won't like that!"] = "Fiammetta ne va pas du tout apprécier !";

        // RoomLoungeCarriage
        map["*Gasp!*"] = "*Halètement !*";
        map["She's right there!"] = "Elle est juste là !";
        map["It's moved towards the dining carriage."] = "Il est parti en direction de la voiture-restaurant.";
        map["It's the set list for the band."] = "C'est la liste des morceaux pour le groupe.";
        map["I'm sure they won't mind me borrowing it."] = "Je suis sûr que ça ne les dérangera pas si je l'emprunte.";
        map["I might be able to swipe it."] = "Je pourrais peut-être la chiper en douce.";
        map["The guest list stays on that wall, buddy."] = "La liste des invités reste affichée sur cette cloison, mon pote.";
        map["Don't even think about it!"] = "N'y songe même pas !";

        // RoomMansionInterior
        map["Sorry, George. I need this more than you do."] = "Désolé, George. J'en ai bien plus besoin que vous.";
        map["The system is empty at the moment."] = "Le système est vide pour le moment.";
        map["There's a package ready to be requested, I'll take it."] = "Un paquet est disponible sur demande, je le prends.";
        map["Drat, it's empty!"] = "Flûte, c'est vide !";
        map["I'll just request the inbound package!"] = "Je vais simplement réclamer le paquet en attente !";
        map["''Ode To Lemon Cake''"] = "« Ode au gâteau au citron »";
        map["Huh. I think Lady Unterwald recorded herself on this vinyl!"] = "Tiens donc. Je crois que Lady Unterwald s'est enregistrée sur ce disque vinyle !";
        map["Let's give this a listen, shall we?"] = "Écoutons un peu ce que ça donne, d'accord ?";
        map["Six..."] = "Six...";
        map["That's a click on three..."] = "Voilà un clic sur le trois...";
        map["Almost there..."] = "On y est presque...";
        map["I think I got it!"] = "Je crois que je tiens le bon bout !";
        map["Huh. That was almost too easy!"] = "Tiens. C'était presque trop facile !";
        map["Oh, blast."] = "Oh, misère.";
        map["I don't want to be caught by those ghastly twins."] = "Je ne tiens pas à me faire pincer par ces effroyables jumeaux.";
        map["Better keep my distance."] = "Mieux vaut garder mes distances.";
        map["Nothing happened, it must be empty."] = "Rien ne s'est passé, il doit être vide.";
        map["Aha, what do we have here?"] = "Aha, qu'avons-nous là ?";
        map["Success!"] = "Victoire !";
        map["Requesting item... there we go!"] = "Demande d'envoi de l'objet en cours... et voilà !";
        map["It's so hot, I'm melting over here!"] = "Il fait si chaud, je suis en train de fondre sur place !";
        map["Make a break for the door, boys!"] = "Foncez vers la sortie, les garçons !";

        // RoomMotorbikeExterior
        map["You'd better think of something, quick!"] = "Tu ferais bien de trouver une idée, et vite !";
        map["I don't know how long I can keep this up!"] = "Je ne tiendrai pas cette cadence indéfiniment !";
        map["Come on, just a little bit closer!"] = "Allez, encore un tout petit effort pour se rapprocher !";
        map["You definitely have a plan, right?"] = "Tu as un plan en tête, dis-moi que oui ?";
        map["We're already at maximum speed!"] = "Nous sommes déjà à pleine vitesse !";
        map["We'll need to boost our speed somehow!"] = "Il va falloir booster notre allure d'une manière ou d'une autre !";

        // RoomPantry
        map["I best be off!"] = "Je ferais mieux de lever le camp !";
        map["What's this doing here?"] = "Qu'est-ce que cela fabrique ici ?";
        map["Can't catch a mouse without cheese."] = "On n'attrape pas de souris sans fromage.";

        // RoomPublisherOffice
        map["Hey, hands off!"] = "Hé, bas les pattes !";
        map["I'll just grab a cup of water."] = "Je vais simplement prendre un gobelet d'eau.";
        map["Waste not, want not!"] = "Il n'y a pas de petites économies !";
        map["Allow me to pitch my latest manuscript, I think you'll be pleasantly surprised!"] = "Permettez-moi de vous présenter mon dernier manuscrit, je crois que vous serez agréablement surpris !";
        map["We'll be the judge of that."] = "C'est nous qui en jugerons.";
        map["Now this is more like it, Herman!"] = "Ah, voilà qui commence à ressembler à quelque chose, Herman !";
        map["Herman Merman, dare I say it? I'm impressed!"] = "Herman Merman, osé-je le dire ? Je suis impressionné !";
        map["He's rough and daring, but he has a soft, caring side. Well done, Herman!"] = "Il est rude et intrépide, mais doté d'un cœur d'or et plein de tendresse. Chapeau bas, Herman !";
        map["This may even compare to Chiselton's best work, no doubt about it!"] = "Cela pourrait bien rivaliser avec les meilleurs opus de Chiselton, aucun doute là-dessus !";
        map["Now that's what I'm talking about, a classic silly Herman adventure!"] = "Ah, c'est exactement ce que j'espérais, une bonne vieille aventure loufoque à la Herman !";
        map["The narrative is a little pedestrian at first, but then it really digs its hooks in!"] = "L'intrigue démarre timidement, mais elle finit par nous ferrer sans pitié !";
        map["Are you sure we can't check with the board, just in case?"] = "Êtes-vous certaine qu'on ne devrait pas consulter le conseil d'administration, juste au cas où ?";
        map["ARRRRRGGGGHHHH!"] = "ARRRRRGGGGHHHH !";
        map["I think those were noises of approval? I really can't tell!"] = "Je suppose que c'étaient des râles d'approbation ? Difficile à dire !";
        map["Alright, we've got something here. Let's make it happen, Herman!"] = "Très bien, nous tenons une pépite. Concrétisons cette affaire, Herman !";
        map["What do you need from us, Herman?"] = "De quoi avez-vous besoin de notre part, Herman ?";
        map["I was wondering if I could get paid in advance?"] = "Je me demandais si je pouvais toucher une avance sur droits ?";
        map["You didn't tell me he was funny!"] = "Vous ne m'aviez pas dit qu'il avait de l'humour !";
        map["One moment, Herman."] = "Un instant, Herman.";
        map["I don't believe so."] = "Je ne crois pas, non.";
        map["Oh! Indeed?"] = "Oh ! Vraiment ?";
        map["Of course! Thank you for the opportunity, Lady Unterwald!"] = "Bien évidemment ! Merci pour cette opportunité, Lady Unterwald !";
        map["Ladies and Gentlemen, it appears I have a train to catch."] = "Mesdames et messieurs, il semblerait bien que j'aie un train à prendre.";
        map["But you shall have your story!"] = "Mais vous aurez votre histoire !";
        map["Yuck, too much romance for my taste!"] = "Pouah, beaucoup trop d'eau de rose à mon goût !";
        map["Oh, another one of your wacky adventures, Herman?"] = "Oh, encore une de vos aventures farfelues, Herman ?";
        map["Here, Florence. What do you think?"] = "Tenez, Florence. Qu'en pensez-vous ?";
        map["Oof, too many explosions for my tastes!"] = "Ouf, bien trop d'explosions à mon goût !";
        map["Yep, this looks like yet another silly Herman adventure."] = "Ouaip, ça m'a tout l'air d'une autre aventure saugrenue signée Herman.";
        map["What say you, Thomas?"] = "Qu'en dites-vous, Thomas ?";
        map["My word, this is a lot more violent than your usual stuff, Herman."] = "Bonté divine, c'est nettement plus violent que vos écrits habituels, Herman.";
        map["I think I preferred the classic silly Herman adventures!"] = "Je crois que je préférais vos histoires gentiment idiotes d'antan !";
        map["Ew, it's too lovey-dovey for me."] = "Beurk, c'est bien trop mielleux pour moi.";
        map["Sorry, Herman, we don't think this script is a good fit for us right now."] = "Désolé, Herman, nous ne pensons pas que ce manuscrit corresponde à notre ligne éditoriale actuelle.";
        map["If you have anything else you'd like to pitch, we'd be happy to hear it!"] = "Si vous avez d'autres projets à nous soumettre, nous serions ravis de les étudier !";
        map["Take this back, and give it another go."] = "Reprenez cela, et remettez-vous à l'ouvrage.";
        map["I already have some packing popcorn."] = "J'ai déjà du maïs soufflé de calage.";
        map["I'll just take a handful."] = "Je vais simplement en prendre une poignée.";
        map["It's where all the incoming mail eventually ends up."] = "C'est là que tout le courrier entrant finit par atterrir.";

        // RoomRooftopAccess & Escape
        map["I don't think that would be a good idea."] = "Je ne pense pas que ce soit une idée très judicieuse.";
        map["There's no way I'm getting up there, I'll lose my footing!"] = "Hors de question que je monte là-haut, je vais perdre pied !";
        map["Run, Arthur!"] = "Fuyez, Arthur !";
        map["What happened?"] = "Que s'est-il passé ?";

        // RoomSleeperCarriage
        map["Hm, he must have left."] = "Hm, il a dû partir.";
        map["Is someone in there?"] = "Il y a quelqu'un là-dedans ?";
        map["Hm, I guess not."] = "Hm, visiblement non.";

        // RoomUnterwaldCarriage
        map["Ah, that's better. I feel myself again."] = "Ah, voilà qui va mieux. Je me sens revivre.";
        map["You might just be the most useful person here, Arthur. It's good to know I can rely on you."] = "Tu es peut-être la personne la plus serviable de ce train, Arthur. C'est rassurant de pouvoir compter sur toi.";
        map["Now, it's time to gather the family. This old lady's got a speech to make!"] = "À présent, réunissons la famille. Cette vieille dame a un discours à prononcer !";
        map["Oh no."] = "Oh non.";
        map["Arthur, leave that alone."] = "Arthur, ne touche pas à cela.";
        map["YOU? We were supposed to make contact hours ago!"] = "VOUS ? Nous devions prendre contact il y a des heures de cela !";
        map["Wh-who are you?"] = "Qu-qui êtes-vous ?";
        map["Where's my suit? Better yet, where is that meddling detective?"] = "Où est mon costume ? Et d'ailleurs, où est passé cet insupportable détective d'opérette ?";
        map["Did Lady Unterwald put you up to this?"] = "C'est Lady Unterwald qui vous a poussée à faire ça ?";
        map["I'm afraid she's dead. How long have you been in there?"] = "J'ai bien peur qu'elle ne soit morte. Depuis combien de temps étiez-vous enfermé là-dedans ?";
        map["What?!"] = "Quoi ?!";
        map["There's a will reading taking place in the lounge right now."] = "Une lecture de testament a lieu dans le salon en ce moment même.";
        map["I must stop this at once!"] = "Je dois empêcher cette mascarade immédiatement !";
        map["The document speaks for itself Arista, this was clearly Lady Unterwald's last wish."] = "Le document parle de lui-même, Arista. C'était de toute évidence la dernière volonté de Lady Unterwald.";
        map["Really, doctor? You don't believe a trained attorney could have forged one of these documents?"] = "Vraiment, docteur ? Vous pensez qu'un juriste chevronné n'aurait pas été capable de contrefaire un tel acte ?";
        map["If Arthur takes over the estate, that means we can't sell it?"] = "Si Arthur hérite du domaine, cela signifie que nous ne pourrons pas le vendre ?";
        map["That's right. No sale means no money for us."] = "Exactement. Pas de vente, pas un rond pour nous.";
        map["You're making rather large assumptions, Arista. We don't know if that's the case."] = "Vous tirez des conclusions un peu hâtives, Arista. Rien ne dit que ce soit le cas.";
        map["What I do know is that some of us have quite expensive hobbies, isn't that right, Bergmann?"] = "Ce que je sais pertinemment, c'est que certains d'entre nous ont des passe-temps fort coûteux, n'est-ce pas, Bergmann ?";
        map["Well-I... I... But what course of action can we take?"] = "Eh bien... je... Mais quelle mesure pouvons-nous bien adopter ?";
        map["I believe I have a solution that would benefit everyone. If you'll allow me?"] = "Je crois avoir une solution qui profitera à tout le monde. Si vous me le permettez ?";
        map["Well, I believe that solves our problem quite effectively."] = "Eh bien, voilà qui règle notre problème avec une redoutable efficacité.";
        map["Jian! That's completely-"] = "Jian ! C'est tout bonnement...";
        map["Look around you, Bergmann. This room is filled with documents purporting to be Lady Unterwald's last wishes."] = "Regardez autour de vous, Bergmann. Cette pièce regorge de paperasses prétendant être les dernières volontés de Lady Unterwald.";
        map["Who's to say we can't use one with slightly more favourable terms?"] = "Qui nous empêche d'en utiliser une aux termes légèrement plus avantageux ?";
        map["This is ridiculous, the order won't stand for this!"] = "C'est inadmissible, notre confrérie ne tolérera jamais cela !";
        map["The order will no longer be an issue, doctor."] = "La confrérie ne sera plus un problème, cher docteur.";
        map["You could say I've ''handled'' the situation? Haha."] = "On pourrait dire que j'ai « pris les choses en main », aha !";
        map["What have you done, Jian!"] = "Qu'avez-vous fait, Jian !";
        map["*ACHOO*"] = "*ATCHOUM*";
        map["Bless you!"] = "À vos souhaits !";
        map["Hello, everyone."] = "Bonjour tout le monde.";
        map["Who are you supposed to be?"] = "Et vous, vous êtes censée être qui ?";
        map["You're from the t-tax office? Excuse me, I have some urgent business to attend to!"] = "Vous venez du... du fisc ?! Veuillez m'excuser, j'ai une affaire de la plus haute urgence à régler !";
        map["What's going on, Jian? She's heard everything!"] = "Qu'est-ce qui se passe, Jian ? Elle a tout entendu !";
        map["Quiet, Arista. I have everything under control."] = "Silence, Arista. J'ai la situation bien en main.";
        map["She's a spy, you idiot!"] = "C'est une espionne, triple buse !";
        map["Boys! Tie her up with the others."] = "Les garçons ! Ligotez-la avec les autres.";

        // RoomUnterwaldLobby & SafeLocks
        map["It's a working model replica of the Reuss Express!"] = "C'est une fidèle réplique miniature en état de marche du Reuss Express !";
        map["That's it!"] = "C'est ça !";
        map["Just one more locking mechanism to get through!"] = "Plus qu'un seul mécanisme de verrouillage à déjouer !";
        map["It's going to be tricky to replicate Lady Unterwald's voice, given the circumstances."] = "Ça va être coton d'imiter la voix de Lady Unterwald, vu les circonstances.";
        map["There are two locking mechanisms here."] = "Il y a deux mécanismes de verrouillage ici.";
        map["There's a combination lock, looks like I'll need to put in a six-digit number."] = "Il y a une serrure à combinaison, on dirait que je dois entrer un code à six chiffres.";
        map["And this looks like a listening device. Could this lock be voice activated?"] = "Et cela ressemble à un dispositif d'écoute. Ce verrou pourrait-il être à commande vocale ?";

        // RoomVentilation
        map["You hear that?"] = "Tu as entendu ça ?";
        map["Quickly, it came from this direction!"] = "Vite, c'est venu de ce côté !";
        map["That's what I've been saying!"] = "C'est bien ce que je n'arrête pas de dire !";

        // Missing cutscenes additions
        map["I've already sent something to Diana's cell."] = "J'ai déjà envoyé quelque chose vers la cellule de Diana.";
        map["Heads up, Diana!"] = "Attention là-dessous, Diana !";
        map["Is that Bergmann?"] = "Est-ce Bergmann ?";
        map["I just filled that hatch with explosives!"] = "Je viens de bourrer cette trappe d'explosifs !";
        map["How long do we have?"] = "Combien de temps avons-nous ?";
        map["I'm guessing about fifteen seconds or so!"] = "Une quinzaine de secondes, je dirais !";
        map["Ah."] = "Ah.";
        map["I can't see anything without the light."] = "Impossible d'y voir goutte sans lumière.";
        map["Dear Arthur, please report to me at your earliest convenience."] = "« Cher Arthur, veuillez me rejoindre dès que possible. »";
        map["I have further amendments to make to my estate before the big announcement tonight."] = "« J'ai d'autres amendements à apporter à ma succession avant la grande annonce de ce soir. »";
        map["Eh, I'll read the rest of this later."] = "Bah, je lirai la suite plus tard.";
        map["Looks like Don is heading this way."] = "On dirait que Don se dirige par ici.";
        map["They seemed pretty annoyed. I'll come back later."] = "Ils avaient l'air passablement agacés. Je repasserai plus tard.";
        map["I've made it to the sleeper carriage. If I can get to my quarters..."] = "Je suis arrivé à la voiture-lits. Si je pouvais gagner mes quartiers...";
        map["It's locked, what do you think?"] = "C'est fermé à clé, tu en dis quoi ?";
        map["We could break down the door, or wait here."] = "On pourrait défoncer la porte, ou attendre ici.";
        map["See if that snooping detective comes crawling back."] = "Pour voir si ce fouineur de détective ramène sa fraise.";
        map["Oh, good evening, ma'am!"] = "Oh, bonsoir, madame !";
        map["G-Good evening."] = "B-Bonsoir.";
        map["I was just passing by."] = "Je ne faisais que passer.";
        map["There's nothing untoward going on here."] = "Il ne se passe rien d'anormal par ici.";
        map["We seem to have misplaced our keys, that's all!"] = "Nous semblons avoir égaré nos clés, c'est tout !";
        map["I can't risk getting to my quarters the usual way, I'll have to find another route!"] = "Je ne peux pas risquer d'entrer dans ma cabine par la voie normale, je dois trouver un autre chemin !";
        map["That letter sounded important."] = "Cette lettre avait l'air importante.";
        map["I'd better change out of this suit."] = "Je ferais mieux d'enlever ce costume.";
        map["I'm under orders."] = "J'obéis aux ordres.";
        map["Lady Unterwald? You're alive?"] = "Lady Unterwald ? Vous êtes vivante ?";
        map["Oh, it's just a recording."] = "Oh, ce n'est qu'un enregistrement.";
        map["Welcome to the Dirk Chiselton Hotline!"] = "Bienvenue sur la ligne directe de Dirk Chiselton !";
        map["Stuck on a puzzle or don't know what to do? Consult with the best detective in town, Dirk Chiselton!"] = "Bloqué sur une énigme ou à court d'idées ? Consultez le meilleur détective de la ville, Dirk Chiselton !";
        map["I can provide you with hints and clues, depending on how far along in the case you are."] = "Je peux vous fournir des tuyaux et des indices selon l'avancement de votre enquête.";
        map["If you can't find the hint you're looking for, you probably don't need to solve that puzzle right now."] = "Si vous ne trouvez pas l'indice cherché, c'est sans doute que cette énigme n'est pas encore d'actualité.";
        map["Just hang up when you're done, alright?"] = "Raccrochez simplement quand vous avez fini, d'accord ?";
        map["It sounds like they're talking to themselves out loud."] = "On dirait qu'ils parlent tout seuls à voix haute.";
        map["How peculiar."] = "Comme c'est curieux.";
        map["If I pull at this wiring, it should cut power to the rooms."] = "Si je tire sur ce câblage, cela devrait couper le courant dans les cabines.";
        map["Woah, who turned out the lights!"] = "Hé là, qui a éteint la lumière ?!";
        map["Damn, looks like I've lost power to the room."] = "Mince alors, on dirait que je n'ai plus d'électricité dans la pièce.";
        map["I should probably take a break, anyway."] = "Je ferais sans doute bien de faire une pause, de toute façon.";
        map["Aha! ''Property of Doctor Hirsch''."] = "Aha ! « Propriété du docteur Hirsch ».";
        map["I'll hang on to this for now."] = "Je vais garder ceci pour l'instant.";
        map["I don't think the Doctor will let me look inside if I return it straight away."] = "Je doute que le docteur me laisse fouiller dedans si je le lui rends tout de suite.";
        map["Looks like it's locked though."] = "On dirait pourtant que c'est verrouillé.";
        map["I'll need to find some way to open it."] = "Il va falloir que je trouve un moyen de l'ouvrir.";
        map["I can't pick it up with my bare hands, it might bite me."] = "Impossible de l'attraper à mains nues, ça pourrait me mordre.";
        map["Oh, so close!"] = "Oh, à un cheveu près !";
        map["Blast! The engine's been ripped out!"] = "Misère ! Le moteur a été arraché !";
        map["I'll just have to work with these other parts."] = "Je vais devoir composer avec ces autres pièces.";
        map["It's firmly attached. I can't pull it out with my bare hands."] = "C'est solidement fixé. Impossible de l'arracher à mains nues.";
        map["I'm gonna explode!"] = "Je vais exploser !";
        map["You need to pace yourself, Lamont!"] = "Tu devrais modérer ton appétit, Lamont !";
        map["It's a picnic, not an all-you-can-eat buffet!"] = "C'est un pique-nique, pas un buffet à volonté !";
        map["Still! It's nice to get away every once in a while, Bailey!"] = "N'empêche ! Ça fait du bien de s'aérer de temps en temps, Bailey !";
        map["Do you hear that?"] = "Tu as entendu ce bruit ?";
        map["Hear what? That's probably just my stomach growling."] = "Entendu quoi ? C'est sûrement mon estomac qui gargouille.";
        map["Ahh. Just breathe it all in!"] = "Ahh. Respire à pleins poumons !";
        map["There's nothing like the peaceful sound of-"] = "Rien ne vaut le calme enchanteur de...";
        map["Sigh..."] = "*Soupir...*";
        map["I'll get the car started."] = "Je vais démarrer la voiture.";
        map["It all started on the Reuss Express."] = "Tout a commencé à bord du Reuss Express.";
        map["Why do you persist in living?"] = "Pourquoi vous obstinez-vous à rester en vie ?";
        map["Can we not just talk about this?"] = "Ne pourrions-nous pas simplement en discuter ?";
        map["Now, stay still!"] = "Et maintenant, ne bougez plus d'un pouce !";
        map["Eep!"] = "Hiii !";
        map["I hope Diana is having better luck than me!"] = "J'espère que Diana a plus de chance que moi !";
        map["I already have a lump of coal."] = "J'ai déjà un morceau de charbon.";
        map["I didn't realise there were so many tunnels on this line!"] = "Je ne m'étais pas rendu compte qu'il y avait autant de tunnels sur cette voie !";
        map["Hey! Over here!"] = "Hé ! Par ici !";
        map["Take your best shot, old man!"] = "Essaie un peu de me viser, le vieux !";
        map["You have terrible aim!"] = "Vous visez comme un pied !";
        map["You missed!"] = "Raté !";
        map["Wha?"] = "Hein ?";
        map["Tunnel!"] = "Tunnel !";
        map["Aha!"] = "Aha !";
        map["You'll have to do better than that!"] = "Il va falloir faire bien mieux que ça !";
        map["Now, where was I?"] = "Bon, où en étais-je déjà ?";
        map["It can't be!"] = "Impossible !";
        map["Huh, I guess I AM a tunnel head!"] = "Tiens donc, je suppose que je SUIS un fana de tunnels après tout !";
        map["Quickly, Arthur! We need to stop this train!"] = "Vite, Arthur ! Nous devons stopper ce train !";
        map["I'm right behind you!"] = "Je vous suis de près !";
        map["Now, how do I do that, exactly? This wasn't part of my training!"] = "Maintenant, comment faire exactement ? Ça ne faisait pas partie de ma formation !";
        map["I'm on my way!"] = "J'arrive !";
        map["What is it, Herman?"] = "Qu'y a-t-il, Herman ?";
        map["Go away!"] = "Fichez le camp !";

        Process(@"translations\partitions\shared_cutscenes.tsv", @"translations\partitions\shared_cutscenes_french.tsv", map);
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
                    Console.WriteLine("Missing in shared_cutscenes: [" + en + "]");
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
