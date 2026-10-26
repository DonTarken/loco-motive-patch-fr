using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class BuildC5C6C7 {
    static void Main() {
        var map = new Dictionary<string, string>();

        // --- CHAPTER 5 ---
        map["Morning, Sir!"] = "Bonjour, Monsieur !";
        map["Diana."] = "Diana.";
        map["I need to refuel the motorbike, any ideas?"] = "Je dois faire le plein de la moto, une idée ?";
        map["Have another look around, there's probably something you haven't spotted."] = "Regardez bien autour de vous, il y a sûrement un détail qui vous a échappé.";
        map["I need another hint about refuelling the bike."] = "J'ai besoin d'un autre indice sur le ravitaillement de la moto.";
        map["You might be able to find a container for storing fuel nearby."] = "Vous pourriez peut-être dénicher un récipient pour stocker du carburant à proximité.";
        map["There's an empty fuel canister near the pneumatic station, I'd start there."] = "Il y a un bidon d'essence vide près de la station pneumatique, je commencerais par là.";
        map["I've got the fuel canister, but it's empty. What now?"] = "J'ai le bidon d'essence, mais il est vide. Et maintenant ?";
        map["Well, you'll need to get fuel from somewhere."] = "Eh bien, il va falloir trouver du carburant quelque part.";
        map["You should inspect the other vehicles, see if there's any fuel left over."] = "Vous devriez inspecter les autres véhicules, voir s'il ne reste pas un fond d'essence.";
        map["That rubber tubing looks useful, but it's stuck."] = "Ce tuyau en caoutchouc a l'air bien utile, mais il est coincé.";
        map["You might be able to remove it, with the right tool."] = "Vous pourriez peut-être le détacher avec le bon outil.";
        map["I need another hint about the rubber tubing."] = "J'ai besoin d'un autre indice sur le tuyau en caoutchouc.";
        map["You'll need something sharp to cut that tubing out."] = "Il vous faudra un objet tranchant pour sectionner ce tuyau.";
        map["That wiring kit looks sharp, have you asked the quartermaster about it?"] = "Ce kit de câblage a l'air bien coupant, avez-vous interrogé la fourrière à ce sujet ?";
        map["The quartermaster won't let me have the wiring kit, what now?"] = "L'intendante refuse de me céder le kit de câblage, que faire ?";
        map["That might be a dead end, she's not going to bend the rules. What else can you see?"] = "C'est une impasse, elle ne dérogera pas au règlement. Que voyez-vous d'autre ?";
        map["I need another hint, what should I do?"] = "J'ai besoin d'un autre indice, que dois-je faire ?";
        map["If the quartermaster won't give you that item, maybe you can take it!"] = "Si l'intendante refuse de vous le donner, vous pourriez peut-être le subtiliser !";
        map["There's a cage on that desk, have you had a peek inside yet?"] = "Il y a une cage sur ce bureau, avez-vous déjà jeté un coup d'œil à l'intérieur ?";
        map["I've located Agent M, she's a miniature thief!"] = "J'ai localisé l'Agent M : c'est une petite voleuse hors pair !";
        map["A thief might come in handy! What else can you find?"] = "Une voleuse pourrait s'avérer fort utile ! Que pouvez-vous trouver d'autre ?";
        map["With the right equipment, I'm sure you can get Agent M to help you."] = "Avec le bon équipement, je suis convaincu que l'Agent M acceptera de vous aider.";
        map["There's a pile of discarded pneumatic containers, why not take one?"] = "Il y a une pile de capsules pneumatiques usagées, pourquoi ne pas en prendre une ?";
        map["What should I do with this pneumatic container?"] = "Que dois-je faire de cette capsule pneumatique ?";
        map["You can put something in there and send it to the quartermaster's booth!"] = "Vous pouvez y glisser quelque chose et l'expédier au guichet de l'intendante !";
        map["I need another hint about the pneumatic container."] = "J'ai besoin d'un autre indice sur la capsule pneumatique.";
        map["You'll want to send something to that booth, but what?"] = "Vous voudrez envoyer quelque chose vers ce guichet, mais quoi ?";
        map["You can send Agent M through the pipes directly to that quartermaster's booth!"] = "Vous pouvez propulser l'Agent M dans les tuyaux directement vers le guichet de l'intendante !";
        map["Do you know how the pneumatic station works?"] = "Savez-vous comment fonctionne la station pneumatique ?";
        map["Those levers should control where the package ends up, try different combinations and see where it goes."] = "Ces leviers contrôlent la destination du colis. Essayez plusieurs combinaisons pour voir où il atterrit.";
        map["I need another hint about the pneumatic station."] = "J'ai besoin d'un autre indice sur la station pneumatique.";
        map["Have a closer look at the pipes, can you see a pattern?"] = "Examinez les tuyaux de plus près, remarquez-vous une logique ?";
        map["The levers and pipes have symbols on them, match those symbols and you're all set!"] = "Les leviers et les tuyaux portent des symboles. Faites-les correspondre et le tour est joué !";
        map["I've got the wiring kit, what should I do now?"] = "J'ai le kit de câblage, que dois-je faire maintenant ?";
        map["I'd be careful with that, it looks pretty sharp, useful for slicing through stuff though."] = "Soyez prudente, c'est très tranchant. Mais fort utile pour couper des trucs en deux.";
        map["I need another hint about the wiring kit."] = "J'ai besoin d'un autre indice sur le kit de câblage.";
        map["You can use the wiring kit to snip off the rubber tubing in the car."] = "Vous pouvez vous servir du kit de câblage pour sectionner le tuyau en caoutchouc dans la voiture.";
        map["I've got the rubber tubing, what should I do now?"] = "J'ai le tuyau en caoutchouc, que faire à présent ?";
        map["That rubber tubing should help you refuel!"] = "Ce tuyau en caoutchouc devrait vous aider à faire le plein !";
        map["With the right equipment, you could use that tube to help syphon fuel."] = "Avec le bon équipement, vous pourriez utiliser ce tuyau pour siphonner du carburant.";
        map["If you combine that rubber tubing with the fuel canister, I bet you could make an effective syphoning tool."] = "Si vous combinez ce tuyau avec le bidon d'essence, je parie que vous obtiendrez un parfait siphon.";
        map["I've made the syphon kit, what's next?"] = "J'ai fabriqué le kit de siphonnage, quelle est la suite ?";
        map["That other vehicle might have some leftover fuel."] = "L'autre véhicule contient peut-être encore du carburant.";
        map["I need another hint about syphoning the fuel."] = "J'ai besoin d'un autre indice sur le siphonnage d'essence.";
        map["You should try to syphon the fuel from that vehicle."] = "Vous devriez tenter de siphonner l'essence de ce véhicule.";
        map["I need another hint about syphoning fuel."] = "J'ai besoin d'un autre indice sur le siphonnage du carburant.";
        map["That vehicle might have some fuel left over, try syphoning it out of the fuel inlet. "] = "Ce véhicule a peut-être du carburant en réserve, essayez de le pomper par la trappe à essence.";
        map["That vehicle might have some fuel left over, try syphoning it out of the fuel inlet."] = "Ce véhicule a peut-être du carburant en réserve, essayez de le pomper par la trappe à essence.";
        map["I need to fix the faulty wiring on the motorbike."] = "Je dois réparer le câblage défectueux de la moto.";
        map["You've got a wiring kit, don't you? Try using that."] = "Vous avez un kit de câblage, n'est-ce pas ? Essayez de vous en servir.";
        map["The bike is fixed, what should I do now?"] = "La moto est réparée, que dois-je faire maintenant ?";
        map["Nothing left to do but ride out of there in style!"] = "Il ne vous reste plus qu'à prendre la route avec panache !";
        map["Good luck on your mission, agent!"] = "Bonne chance pour votre mission, agent !";
        map["Well, I'm not officially an a-"] = "Eh bien, je ne suis pas officiellement un a-";
        map["Oh, he's gone."] = "Oh, il a raccroché.";
        map["I've got it from here, thanks."] = "Je prends les choses en main d'ici, merci.";

        // --- CHAPTER 6 ---
        map["One of the other inmates has an item I need!"] = "L'un des autres détenus a un objet dont j'ai besoin !";
        map["There's likely something that connects your cells, take a look around."] = "Il y a sûrement un conduit reliant vos cellules, regardez bien autour de vous.";
        map["I need another hint about trading items."] = "J'ai besoin d'un autre indice sur le troc d'objets.";
        map["What about using the plumbing system? It's not ideal, but it'd probably work!"] = "Et si vous passiez par la tuyauterie ? Ce n'est pas très ragoutant, mais ça marchera sûrement !";
        map["You can send items to each other by flushing them through the plumbing system."] = "Vous pouvez vous faire passer des objets en tirant la chasse d'eau dans les canalisations.";
        map["The water is flowing the wrong way, what gives?"] = "L'eau coule dans le mauvais sens, pourquoi donc ?";
        map["There should be a way to adjust the flow direction, do you see anything?"] = "Il doit y avoir un moyen d'inverser le sens du courant, vous voyez quelque chose ?";
        map["I'll bet one of you has something that can reverse the flow direction."] = "Je parie que l'un de vous possède un moyen d'inverser le flux.";
        map["Arthur can reverse the flow with that valve in his cell, give it a try!"] = "Arthur peut inverser l'écoulement grâce à la vanne dans sa cellule, essayez voir !";
        map["They confiscated our possessions, what now?"] = "Ils ont confisqué nos affaires, que faire ?";
        map["If you want those items back, you'll need to find out where they're stashed."] = "Si vous voulez récupérer vos biens, vous devez trouver où ils ont été planqués.";
        map["I need another hint about getting our stuff back."] = "J'ai besoin d'un autre indice pour récupérer nos affaires.";
        map["Those items are in a lockbox, does anyone have anything that would extend their reach?"] = "Ces objets sont dans un coffret. Quelqu'un a-t-il de quoi rallonger sa portée ?";
        map["Arthur's umbrella could extend their reach. I'd try and use that to open the lockbox."] = "Le parapluie d'Arthur pourrait lui servir de rallonge. J'essaierais de l'utiliser pour ouvrir le coffret.";
        map["We need that magnetic ball, but it's just out of reach!"] = "Nous avons besoin de cette bille aimantée, mais elle est hors de portée !";
        map["I'm sure one of you has something that'd be attracted to it."] = "Je suis sûr que l'un de vous a quelque chose qui pourrait l'attirer.";
        map["I need another hint about the magnetic ball."] = "J'ai besoin d'un autre indice sur la bille aimantée.";
        map["It's a shiny object, it might even look valuable to some!"] = "C'est un objet brillant, ça pourrait même passer pour un trésor aux yeux de certains !";
        map["Isn't that mouse attracted to shiny objects? It could grab that ball for you."] = "Cette souris n'est-elle pas friande de babioles brillantes ? Elle pourrait aller la chercher pour vous.";
        map["We've got the magnetic ball, now what?"] = "On a la bille aimantée, quelle est la suite ?";
        map["Perhaps it's time to reunite that ball with its original owner?"] = "Il est peut-être temps de rendre cette bille à son légitime propriétaire ?";
        map["I need something to wrap around these bars."] = "J'ai besoin de quelque chose à enrouler autour de ces barreaux.";
        map["Trying to create some leverage, aye? It'd need to be strong enough to take the pressure."] = "Vous cherchez à faire levier, hein ? Il faudra quelque chose d'assez résistant pour encaisser la tension.";
        map["I need another hint about the jail bars!"] = "J'ai besoin d'un autre indice sur les barreaux de la cellule !";
        map["For the right leverage, you'll need something strong, but flexible."] = "Pour obtenir un bon bras de levier, il vous faut quelque chose de robuste, mais souple.";
        map["I need another hint about the jail bars."] = "J'ai besoin d'un autre indice sur les barreaux.";
        map["Perhaps those metal chains would work?"] = "Peut-être que ces chaînes métalliques feraient l'affaire ?";
        map["Diana found a chain, but it's locked to itself."] = "Diana a trouvé une chaîne, mais elle est cadenassée sur elle-même.";
        map["You're not getting that chain off the wall without a key!"] = "Vous ne décrocherez pas cette chaîne du mur sans une clé !";
        map["I need another hint about unlocking the chain."] = "J'ai besoin d'un autre indice pour déverrouiller la chaîne.";
        map["Didn't one of you have a key for that kind of chain?"] = "L'un de vous n'avait-il pas une clé pour ce modèle de chaîne ?";
        map["Arthur found a key to escape his chains, he may still have it!"] = "Arthur a trouvé une clé pour se libérer de ses fers, il l'a peut-être encore sur lui !";
        map["We need to create a distraction, any ideas?"] = "Nous devons faire diversion, une idée ?";
        map["Perhaps you can make some noise?"] = "Peut-être pourriez-vous faire du boucan ?";
        map["I need another hint about the distraction."] = "J'ai besoin d'un autre indice pour la diversion.";
        map["If you flushed something heavy, it'd probably make a loud enough noise!"] = "Si vous évacuiez quelque chose de lourd par les toilettes, ça ferait un vacarme suffisant !";
        map["Flushing those chains could cause quite the distraction. Give that a try!"] = "Tirer la chasse sur ces chaînes ferait une diversion parfaite. Essayez donc !";
        map["That chain is stuck in the toilet, any ideas?"] = "La chaîne est coincée dans la cuvette, une idée ?";
        map["You got anything on you that might create a vacuum?"] = "Avez-vous sur vous de quoi faire ventouse ?";
        map["I need another hint about retrieving the chain."] = "J'ai besoin d'un autre indice pour récupérer la chaîne.";
        map["You'll need to provide suction, if only you had a plunger!"] = "Il vous faut une aspiration digne de ce nom. Si seulement vous aviez une ventouse !";
        map["Those boots still have suction cups on the bottom, right? You should be able to remove them."] = "Ces bottes ont toujours des ventouses dessous, non ? Vous devriez pouvoir les détacher.";
        map["You could remove the suction cups with the letter opener!"] = "Vous pourriez décoller les ventouses à l'aide de l'ouvre-lettres !";
        map["I can't get any leverage with this suction cup."] = "Je n'ai aucune prise avec cette ventouse seule.";
        map["You'd need a handle in order to get the right leverage."] = "Il vous faudrait un manche pour obtenir une vraie prise.";
        map["I need another hint about the suction cup."] = "J'ai besoin d'un autre indice sur la ventouse.";
        map["There must be something that could work as a make-shift handle?"] = "Il y a sûrement un objet pouvant faire office de manche de fortune ?";
        map["You could combine the pole with the suction cup to fashion a make-shift plunger!"] = "Vous pourriez combiner la tringle avec la ventouse pour confectionner un déboucheur improvisé !";
        map["I've retrieved the chains, what next?"] = "J'ai repêché les chaînes, et maintenant ?";
        map["I'd wrap those chains around those bars and make a break for freedom!"] = "Enroulez ces chaînes autour des barreaux et faites route vers la liberté !";

        // --- CHAPTER 7 ---
        map["Somebody else has an item I need!"] = "Quelqu'un d'autre a un objet dont j'ai besoin !";
        map["The mansion has a pneumatic tube system, right? Place items in there and the others will be able to collect them!"] = "Le manoir dispose d'un réseau pneumatique, non ? Placez les objets dedans et les autres pourront les réceptionner !";
        map["I think Doctor Hirsch is dead, what do we do?"] = "Je crois que le docteur Hirsch est mort, que fait-on ?";
        map["You should check the body, see if they had anything important on them."] = "Vous devriez fouiller le corps pour voir s'il portait des objets utiles.";
        map["I need another hint about Doctor Hirsch!"] = "J'ai besoin d'un autre indice sur le docteur Hirsch !";
        map["Are you sure they're dead?"] = "Êtes-vous certain qu'il est mort ?";
        map["There may be hope for the doctor yet!"] = "Il y a peut-être encore un espoir pour le bon docteur !";
        map["You should be able to revive him with the right equipment."] = "Vous devriez pouvoir le réanimer avec le matériel approprié.";
        map["Any ideas as to where an old lady would keep her will?"] = "Une idée de l'endroit où une vieille dame cacherait son testament ?";
        map["I'd bet it's hidden away, have you checked everywhere?"] = "Je parie qu'il est bien dissimulé. Avez-vous regardé partout ?";
        map["I need another hint about finding the will."] = "J'ai besoin d'un autre indice pour trouver le testament.";
        map["Lady Unterwald would have kept it somewhere safe, I'm sure."] = "Lady Unterwald l'aura mis en lieu sûr, à n'en pas douter.";
        map["Lady Unterwald likely secured the will in a hidden safe. See if you can track it down."] = "Lady Unterwald l'a très certainement enfermé dans un coffre dérobé. Voyez si vous pouvez le localiser.";
        map["Check behind paintings, that's where I'd keep a safe!"] = "Regardez derrière les tableaux, c'est là que je planquerais un coffre !";
        map["I've found the safe, how do I open it?"] = "J'ai trouvé le coffre, comment l'ouvrir ?";
        map["If you could listen more closely to the contact points, I'm confident you could get that safe open in no time."] = "Si vous pouviez tendre l'oreille près des goupilles, je suis sûr que vous l'ouvririez en deux temps trois mouvements.";
        map["I need another hint about opening the safe."] = "J'ai besoin d'un autre indice pour ouvrir le coffre.";
        map["I need a hint about the fingerprint lock."] = "J'ai besoin d'un indice sur la serrure à empreintes digitales.";
        map["I need another hint about the fingerprint lock."] = "J'ai besoin d'un autre indice sur la serrure à empreintes.";
        map["Maybe there's something that could replicate Lady Unterwald's hand?"] = "Peut-être existe-t-il quelque chose capable de reproduire la main de Lady Unterwald ?";
        map["Perhaps Lady Unterwald left her prints somewhere."] = "Peut-être que Lady Unterwald a laissé ses empreintes quelque part.";
        map["That statue in the basement, it's based on Lady Unterwald, right?"] = "Cette statue au sous-sol est bien modelée d'après Lady Unterwald, non ?";
        map["Perhaps you can make an impression of the statue's hand?"] = "Peut-être pourriez-vous faire une empreinte de la main de la statue ?";
        map["Arthur still has that wax seal. Melt it down and see if you can make an impression!"] = "Arthur a toujours ce sceau de cire. Faites-le fondre pour voir si vous pouvez mouler une empreinte !";
        map["You used a recording of Lady Unterwald before. That trick might work again!"] = "Vous avez déjà utilisé un enregistrement de Lady Unterwald par le passé. L'astuce pourrait encore fonctionner !";
        map["There's a gramophone in the library, that could be useful."] = "Il y a un gramophone dans la bibliothèque, ça pourrait servir.";
        map["Have you looked through the library's vinyl collection?"] = "Avez-vous fouillé la collection de disques vinyles de la bibliothèque ?";
        map["Does anyone have an item that can record voices?"] = "Quelqu'un possède-t-il un appareil capable d'enregistrer les voix ?";
        map["No problem."] = "Pas de problème.";
        map["The boiler isn't hot enough, what should I do?"] = "La chaudière n'est pas assez chaude, que faire ?";
        map["You'll probably have to help it along a bit. Got anything on you?"] = "Il va falloir lui donner un coup de pouce. Vous avez quelque chose sur vous ?";
        map["I need another hint about the boiler."] = "J'ai besoin d'un autre indice sur la chaudière.";
        map["What have you got on you? Anything particularly reactive to heat?"] = "Qu'avez-vous sur vous ? Quelque chose de particulièrement inflammable ?";
        map["That truth serum certainly went up before, maybe it's reactive to heat?"] = "Ce sérum de vérité a bien flambé tout à l'heure, peut-être qu'il réagit fortement à la chaleur ?";
        map["Feed that truth serum into the boiler, and I bet it'll start pumping out some real heat!"] = "Versez ce sérum de vérité dans la chaudière, et elle se mettra à cracher des flammes d'enfer !";
        map["Are we really letting those three go?"] = "Est-ce qu'on va vraiment relâcher ces trois-là dans la nature ?";
        map["How'd you mean?"] = "Qu'est-ce que tu veux dire ?";
        map["They may not have murdered Lady Unterwald, but they committed so many other crimes!"] = "Ils n'ont peut-être pas assassiné Lady Unterwald, mais ils ont commis une ribambelle d'autres crimes !";
        map["You forget we've got them on record, confessing to the lot!"] = "Tu oublies qu'on a leurs aveux enregistrés pour l'intégralité du tableau !";
        map["Hah! Have a little faith, Bailey. We were always one step ahead."] = "Ha ! Aie un peu foi en nous, Bailey. Nous avons toujours eu une longueur d'avance.";

        ProcessBatch(@"translations\partitions\chapter5_missing.tsv", @"translations\partitions\c5_french.tsv", map);
        ProcessBatch(@"translations\partitions\chapter6_missing.tsv", @"translations\partitions\c6_french.tsv", map);
        ProcessBatch(@"translations\partitions\chapter7_missing.tsv", @"translations\partitions\c7_french.tsv", map);
    }

    static void ProcessBatch(string inPath, string outPath, Dictionary<string, string> map) {
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
                    Console.WriteLine("Missing in " + Path.GetFileName(inPath) + ": [" + en + "]");
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
