# Encoding: UTF-8
$linesToAdd = @(
    # Option 1
    @{ Char="Lamont"; En="I've got bad news for you, kid."; Fr="J'ai une mauvaise nouvelle pour vous, mon garçon." },
    @{ Char="Lamont"; En="Just take a look at those clammy, murderous hands!"; Fr="Regardez-moi un peu ces mains moites d'assassin !" },
    @{ Char="Arthur"; En="Clammy?"; Fr="Moites ?" },
    @{ Char="Lamont"; En="Those are textbook murder mittens, worst case I've ever seen."; Fr="C'est un cas d'école de paluches de criminel, le pire que j'aie jamais vu." },
    
    # Option 2
    @{ Char="Lamont"; En="And how many more have to die on your watch, before that lust for murder is satiated?"; Fr="Et combien d'autres devront mourir sous votre garde avant que cette soif de sang ne soit étanchée ?" },
    
    # Option 3
    @{ Char="Lamont"; En="Yet unable to shed a single tear for your client."; Fr="Et pourtant incapable de verser la moindre larme pour votre cliente." },
    @{ Char="Lamont"; En="A sweet old lady, tragically cut down in her prime!"; Fr="Une adorable vieille dame, tragiquement fauchée dans la fleur de l'âge !" },
    @{ Char="Arthur"; En="She was eighty-nine years old!"; Fr="Elle avait quatre-vingt-neuf ans !" },
    
    # Option 4
    @{ Char="Lamont"; En="Don't you try and wriggle out of this one with your fancy lawyer talk!"; Fr="N'essayez pas de vous défiler avec votre baratin d'homme de loi !" },
    
    # Props Interrogation
    @{ Char="Arthur"; En="I just need to reach a little further!"; Fr="Je dois juste tendre le bras un tout petit peu plus loin !" },
    @{ Char="Arthur"; En="If only I could reach a little further!"; Fr="Si seulement je pouvais tendre le bras un peu plus loin !" },
    @{ Char="Arthur"; En="''IT'S THE END OF THE LINE''"; Fr="« TERMINUS TOUT LE MONDE DESCEND »" },
    @{ Char="Arthur"; En="''The Unterwald empire came to a grisly end last night, when the wealthy heiress was unexpectedly assassinated aboard her own train.''"; Fr="« L'empire Unterwald a connu une fin macabre hier soir, lorsque la richissime héritière a été assassinée à bord de son propre train. »" },
    @{ Char="Arthur"; En="''Three suspects are currently held in custody, awaiting questioning.''"; Fr="« Trois suspects sont actuellement placés en garde à vue, dans l'attente de leur interrogatoire. »" },
    
    # Arthur's Quarters (Act One)
    @{ Char="Arthur"; En="I've got all the classics."; Fr="J'ai tous les grands classiques." },
    @{ Char="Arthur"; En="''The Art of Law''"; Fr="« L'Art du Droit »" },
    @{ Char="Arthur"; En="''Letters Of The Law''"; Fr="« L'Esprit des Lois »" },
    @{ Char="Arthur"; En="Even ''Coleslaw!''"; Fr="Et même « Coleslaw ! »" },
    @{ Char="Arthur"; En="Although that one's just a collection of recipes."; Fr="Bien que celui-ci ne soit qu'un recueil de recettes de salades." },
    @{ Char="Arthur"; En="It's a stack of files regarding Lady Unterwald's estate."; Fr="C'est une pile de dossiers concernant la succession de Lady Unterwald." },
    @{ Char="Arthur"; En="Each one needs checking over before receiving that sweet stamp of approval."; Fr="Chacun d'eux doit être scrupuleusement vérifié avant de recevoir le doux tampon officiel." },
    @{ Char="Arthur"; En="This baby can hold up to 1500 case files!"; Fr="Ce petit bijou peut contenir jusqu'à 1500 dossiers juridiques !" },
    @{ Char="Arthur"; En="1550 if I only pack two pairs of socks."; Fr="1550 si je n'emporte que deux paires de chaussettes." },
    @{ Char="Arthur"; En="A portrait of Lady Unterwald in every room, that's the Reuss Express promise."; Fr="Un portrait de Lady Unterwald dans chaque compartiment, voilà la promesse du Reuss Express." },
    @{ Char="Arthur"; En="Lady Unterwald's eyes follow me around the room."; Fr="Les yeux de Lady Unterwald me suivent partout dans la pièce." },
    @{ Char="Arthur"; En="It's giving me the heebie-jeebies!"; Fr="Ça me donne carrément la chair de poule !" },
    @{ Char="Arthur"; En="What's better than comfy slippers, a tall glass of milk..."; Fr="Qu'y a-t-il de meilleur que de confortables pantoufles, un grand verre de lait..." },
    @{ Char="Arthur"; En="and an even taller stack of paperwork?"; Fr="et une pile de paperasse encore plus haute ?" },
    @{ Char="Arthur"; En="One of my only stipulations for travelling long distances."; Fr="L'une de mes rares exigences pour les voyages au long cours." },
    @{ Char="Arthur"; En="You've got to have access to a trusty typewriter."; Fr="Avoir impérativement accès à une fidèle machine à écrire." },
    
    # Herman in Arthur's Quarters (Act Two)
    @{ Char="Herman"; En="It's a collection of legal books."; Fr="C'est une collection d'ouvrages juridiques." },
    @{ Char="Herman"; En="There's one here titled ''Coleslaw!'' but I think that's a recipe book."; Fr="Il y en a un intitulé « Coleslaw ! », mais j'ai bien l'impression que c'est un livre de recettes." },
    @{ Char="Herman"; En="I'd almost feel sorry for Mr Ackerman, if I didn't suspect him of murdering Lady Unterwald."; Fr="J'aurais presque de la peine pour M. Ackerman, si je ne le soupçonnais pas d'avoir assassiné Lady Unterwald." },
    @{ Char="Herman"; En="It looks neatly organised."; Fr="Ça a l'air impeccablement rangé." },
    @{ Char="Herman"; En="I wish Lady Unterwald hadn't dragged me into this mess."; Fr="Si seulement Lady Unterwald ne m'avait pas entraîné dans ce pétrin." },
    @{ Char="Herman"; En="It's almost as if Lady Unterwald is staring right through me."; Fr="C'est presque comme si Lady Unterwald lisait en moi à travers ce tableau." },
    @{ Char="Herman"; En="All too tempting to slip them on, but I need to focus on the case!"; Fr="Bien trop tentant de les enfiler, mais je dois me concentrer sur l'enquête !" },
    @{ Char="Herman"; En="I wouldn't mind writing my next novella on one of these."; Fr="Je ne serais pas contre écrire mon prochain roman sur un engin pareil." },
    @{ Char="Herman"; En="Exactly the sort of attire you'd expect from a paper pushing lawyer."; Fr="Exactement le genre de costume qu'on attend d'un gratte-papier des tribunaux." },
    @{ Char="Herman"; En="This was supposed to be your big break, Herman!"; Fr="C'était censé être ton heure de gloire, Herman !" },
    @{ Char="Herman"; En="Now you're hiding bodies and breaking into people's rooms?"; Fr="Et voilà que tu caches des cadavres et que tu forces des compartiments privés ?" },
    @{ Char="Herman"; En="How did it come to this?"; Fr="Comment as-tu pu en arriver là ?" },
    @{ Char="Herman"; En="It's quite soothing, all things considered."; Fr="C'est plutôt apaisant, tout bien considéré." },
    @{ Char="Herman"; En="Hmm, I'd rather not draw attention to myself."; Fr="Hmm, je préfère ne pas attirer l'attention sur moi." },
    @{ Char="Herman"; En="I'm not here to rifle through Mr Ackerman's unmentionables."; Fr="Je ne suis pas venu ici pour fouiller dans les sous-vêtements de M. Ackerman." },
    @{ Char="Herman"; En="I'm not sure that I need to look at the plumbing."; Fr="Je doute d'avoir besoin de jeter un œil à la tuyauterie." },
    @{ Char="Herman"; En="Sturdy enough to hold a jacket, but not my interest."; Fr="Assez solide pour porter une veste, mais pas pour retenir mon attention." },
    @{ Char="Herman"; En="Must be the strong stuff, it's full of Ethanol."; Fr="Ça doit être du costaud, c'est bourré d'éthanol." },
    @{ Char="Herman"; En="I'm sure Mr Ackerman spends a great deal of time under this lamp."; Fr="Je suis persuadé que M. Ackerman passe un temps considérable sous cette lampe." },
    
    # Interrogation cutscenes for subsequent acts
    @{ Char="Bailey"; En="Can you tell us your earliest memory from that day, Herman?"; Fr="Pouvez-vous nous raconter votre tout premier souvenir de cette journée, Herman ?" },
    @{ Char="Herman"; En="Let me think..."; Fr="Laissez-moi réfléchir..." },
    @{ Char="Herman"; En="I believe it all began at my publishers office, I'd just pitched my latest novel, you see."; Fr="Je crois que tout a commencé au bureau de mon éditeur, je venais de présenter mon dernier polar, vous voyez." },
    @{ Char="Herman"; En="It was going down an absolute storm!"; Fr="Le succès était absolument fulgurant !" },
    @{ Char="Diana";  En="*Sigh*"; Fr="*Soupir*" },
    @{ Char="Lamont"; En="Alright, so that explains how you got on the train..."; Fr="Très bien, ça explique donc comment vous êtes montée à bord du train..." },
    @{ Char="Diana";  En="I believe you're well aware of what happened next..."; Fr="Je crois que vous savez parfaitement ce qui s'est passé ensuite..." },
    @{ Char="Lamont"; En="Indulge us."; Fr="Faites-nous le plaisir de nous rafraîchir la mémoire." },
    @{ Char="Diana";  En="Well, it all got a bit complicated."; Fr="Eh bien, les choses se sont un peu compliquées." },
    @{ Char="Diana";  En="I stuck to my orders, and made contact with the informant."; Fr="J'ai respecté mes ordres et pris contact avec l'informateur." },
    @{ Char="Bailey"; En="Are we sure any of them actually did it, Lamont?"; Fr="Est-on vraiment certains que l'un d'eux est le meurtrier, Lamont ?" },
    @{ Char="Lamont"; En="There's a lot of string here, Bailey. Are you really going to doubt the yarn?"; Fr="Il y a beaucoup de ficelle rouge ici, Bailey. Tu vas vraiment douter de la pelote ?" },
    @{ Char="Lamont"; En="Besides, they freely admitted to multiple other crimes!"; Fr="Et puis, ils ont spontanément avoué de multiples autres crimes !" },
    @{ Char="Bailey"; En="I suppose, we-"; Fr="J'imagine, mais nous..." },
    @{ Char="Bailey"; En="What's that noise?"; Fr="Quel est ce bruit ?" },
    @{ Char="Lamont"; En="No, they can't be..."; Fr="Non, ça ne peut pas être..." },
    @{ Char="Lamont"; En="The prisoners!"; Fr="Les prisonniers !" },
    @{ Char="Jimmy";  En="I'm in."; Fr="Je suis à l'intérieur." },
    @{ Char="April";  En="Good work, Agent. You know what you have to do."; Fr="Beau travail, Agent. Vous savez ce qu'il vous reste à faire." },
    @{ Char="April";  En="Leave no trace."; Fr="Ne laissez aucune trace." },
    @{ Char="Jimmy";  En="Yes, Ma'am."; Fr="Bien, Madame." }
)

$tsvPath = "translations\dialogues\prologue_french.tsv"
$existing = Get-Content $tsvPath -Encoding UTF8

$sb = New-Object System.Text.StringBuilder
foreach ($l in $existing) {
    [void]$sb.AppendLine($l)
}

$addedCount = 0
foreach ($item in $linesToAdd) {
    # Check if already present
    $en = $item.En
    $fr = $item.Fr
    $char = $item.Char
    $pattern = [regex]::Escape($en)
    if ($existing -match $pattern) {
        Write-Host "Already present: $en"
    } else {
        $newLine = "0`t$char`t$en`t$fr`tManual`tAdded"
        [void]$sb.AppendLine($newLine)
        $addedCount++
        Write-Host "Added: $en -> $fr"
    }
}

[System.IO.File]::WriteAllText($tsvPath, $sb.ToString(), [System.Text.Encoding]::UTF8)
Write-Host "Done! Added $addedCount lines to $tsvPath"
