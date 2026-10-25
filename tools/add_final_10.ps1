# Exact 10 remaining lines
$tenLines = @(
    @{ Char="Herman"; En="I'd almost feel sorry for Mr Ackerman, if I didn't suspect he enjoyed this stuff."; Fr="J'aurais presque pitié de M. Ackerman, si je ne soupçonnais pas qu'il prend plaisir à ce genre de choses." },
    @{ Char="Arthur"; En="A portrait of Lady Unterwald in every room, that's the Reuss Express guarantee!"; Fr="Un portrait de Lady Unterwald dans chaque compartiment, voilà la garantie du Reuss Express !" },
    @{ Char="Herman"; En="All too tempting to slip them on, but I need to focus on the task at hand."; Fr="Bien trop tentant de les enfiler, mais je dois me concentrer sur la tâche présente." },
    @{ Char="Arthur"; En="You've got to have access to a trusty typewriter."; Fr="Il faut impérativement avoir accès à une fidèle machine à écrire." },
    @{ Char="Herman"; En="Exactly the sort of attire you'd expect from a paper pushing bureaucrat."; Fr="Exactement le genre de tenue qu'on attend d'un bureaucrate gratte-papier." },
    @{ Char="Lamont"; En="Alright, so that explains how you got on the train. What happened next?"; Fr="Très bien, cela explique comment vous êtes montée à bord. Que s'est-il passé ensuite ?" },
    @{ Char="Diana";  En="I believe you're well aware of what happened next, detective."; Fr="Je crois que vous savez pertinemment ce qui s'est passé ensuite, inspecteur." },
    @{ Char="Diana";  En="I stuck to my orders, and made contact with the informant. Or so I thought..."; Fr="J'ai obéi aux ordres et pris contact avec l'informateur. Du moins, c'est ce que je croyais..." },
    @{ Char="Lamont"; En="There's a lot of string here, Bailey. Are you really going to argue with all this red string?"; Fr="Il y a beaucoup de ficelle rouge ici, Bailey. Tu vas vraiment oser contredire toute cette ficelle rouge ?" },
    @{ Char="Lamont"; En="Besides, they freely admitted to multiple other crimes in their own testimonies!"; Fr="Et puis, ils ont spontanément avoué de multiples autres crimes dans leurs propres dépositions !" }
)

$tsvPath = "translations\dialogues\prologue_french.tsv"
$sb = New-Object System.Text.StringBuilder

foreach ($item in $tenLines) {
    $char = $item.Char
    $en = $item.En
    $fr = $item.Fr
    $newLine = "0`t$char`t$en`t$fr`tManual`tAdded"
    [void]$sb.AppendLine($newLine)
}

[System.IO.File]::AppendAllText($tsvPath, $sb.ToString(), [System.Text.Encoding]::UTF8)
Write-Host "Appended final 10 lines to $tsvPath"
