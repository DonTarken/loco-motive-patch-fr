# Appending UI, Tutorial, and Interaction lines to ui_french.tsv
$uiTsv = "translations\ui\ui_french.tsv"
$existing = Get-Content $uiTsv -Encoding UTF8
$existingKeys = New-Object System.Collections.Generic.HashSet[string]
foreach ($line in $existing) {
    $p = $line -split "`t"
    if ($p.Count -ge 1) { [void]$existingKeys.Add($p[0].Trim()) }
}

$newLines = @(
    # Pause Menu & Confirmation Prompts
    @("PAUSED", "PAUSE"),
    @("CONTINUE", "CONTINUER"),
    @("SAVE GAME", "SAUVEGARDER"),
    @("LOAD GAME", "CHARGER"),
    @("SETTINGS", "PARAMÈTRES"),
    @("QUIT TO TITLE", "QUITTER VERS LE TITRE"),
    @("ALERT!", "ATTENTION !"),
    @("All unsaved progress will be lost, do you want to continue?", "Toute progression non sauvegardée sera perdue, voulez-vous continuer ?"),
    @("There is already a save file in this slot, would you like to overwrite it?", "Un fichier de sauvegarde existe déjà sur cet emplacement, voulez-vous l'écraser ?"),
    @("YES, CONTINUE", "OUI, CONTINUER"),
    @("NO, GO BACK", "NON, RETOUR"),
    @("EMPTY", "VIDE"),
    @("Autosave", "Sauvegarde auto"),
    @("Select", "Sélectionner"),
    @("Back", "Retour"),

    # Tutorial Tooltips
    @("Click {0} to move Arthur in any direction.", "Cliquez sur {0} pour déplacer Arthur dans n'importe quelle direction."),
    @("Use {0} to move Arthur in any direction.", "Utilisez {0} pour déplacer Arthur dans n'importe quelle direction."),
    @("Tap on the ground to walk.", "Touchez le sol pour vous déplacer."),
    @("Click {0} to interact with an object, or {1} to examine it.", "Cliquez sur {0} pour interagir avec un objet, ou sur {1} pour l'examiner."),
    @("Tap {0} to interact with an object, if there are multiple objects, tap one to choose it.", "Touchez {0} pour interagir avec un objet, ou choisissez parmi les objets affichés."),
    @("Hold down {0} to highlight interactable objects.", "Maintenez {0} enfoncé pour afficher les objets interactifs."),
    @("Use {0} to toggle highlighting interactable objects.", "Utilisez {0} pour activer ou désactiver la surbrillance des objets interactifs."),
    @("Use {0} {1} or {2} to cycle through the different objects around you.", "Utilisez {0}, {1} ou {2} pour passer d'un objet interactif à l'autre."),
    @("Drag finger across screen to find objects, then release to interact.", "Glissez votre doigt sur l'écran pour repérer les objets, puis relâchez pour interagir."),
    @("Click {0} to open your inventory and look at the item you've picked up.", "Cliquez sur {0} pour ouvrir votre inventaire et examiner l'objet ramassé."),
    @("Press {0} to open your inventory and look at the item you've picked up.", "Appuyez sur {0} pour ouvrir votre inventaire et examiner l'objet ramassé."),
    @("Tap {0} to open your inventory and look at the item you've picked up.", "Touchez {0} pour ouvrir votre inventaire et examiner l'objet ramassé."),
    @("Use an inventory item on another item to combine them.", "Utilisez un objet d'inventaire sur un autre pour les combiner."),
    @("Click {0} to walk.\nHold {1} to run to an object or area.", "Cliquez sur {0} pour marcher.\nMaintenez {1} pour courir vers un objet ou un endroit."),
    @("Use {0} to walk.\nHold down {1} or {2} to run.", "Utilisez {0} pour marcher.\nMaintenez {1} ou {2} pour courir."),
    @("Tap {0} to walk.\nHold down {1} or {2} to run.", "Touchez {0} pour marcher.\nMaintenez {1} ou {2} pour courir."),
    @("Click {0} or {1} to switch between Arthur and Diana.", "Cliquez sur {0} ou {1} pour basculer entre Arthur et Diana."),
    @("Use {0} and {1} to switch between Arthur and Diana.", "Utilisez {0} et {1} pour basculer entre Arthur et Diana."),
    @("Tap {0} or {1} to switch between Arthur and Diana.", "Touchez {0} ou {1} pour basculer entre Arthur et Diana."),
    @("Click {0}, {1} or {2} to switch between Arthur, Herman and Diana.", "Cliquez sur {0}, {1} ou {2} pour basculer entre Arthur, Herman et Diana."),
    @("Use {0} or {1} to switch between Arthur, Herman and Diana.", "Utilisez {0} ou {1} pour basculer entre Arthur, Herman et Diana."),
    @("Tap {0}, {1} or {2} to switch between Arthur, Herman and Diana.", "Touchez {0}, {1} ou {2} pour basculer entre Arthur, Herman et Diana."),
    @("Use {0} on {1}", "Utiliser {0} sur {1}"),
    @("Give {0} to {1}", "Donner {0} à {1}"),

    # Hotspots & Interactions (Room Interrogation)
    @("Check out the list of suspects", "Examiner la liste des suspects"),
    @("It's full of trash, as I suspected", "C'est plein de détritus, comme je m'en doutais"),
    @("evidence board", "tableau des suspects"),
    @("Look at the suspect board", "Observer le tableau des suspects"),
    @("bin", "corbeille"),
    @("Search the bin", "Fouiller la corbeille"),
    @("desk", "bureau"),
    @("Rifle through documents", "Fouiller les documents"),
    @("This box is full of neatly organised paperwork.", "Cette boîte est pleine de paperasse soigneusement rangée."),
    @("ashtray", "cendrier"),
    @("It's full of cigarette butts.", "C'est plein de mégots de cigarette."),
    @("light switch", "interrupteur"),
    @("Flip light switch", "Actionner l'interrupteur"),
    @("Inspect light switch", "Inspecter l'interrupteur"),
    @("recording machine", "magnétophone"),
    @("Is this thing recording me?", "Ce machin est en train de m'enregistrer ?"),
    @("newspaper clipping", "coupure de journal"),
    @("Check out the newspaper clipping", "Lire la coupure de journal"),
    @("certificate", "certificat"),
    @("Read the certificate", "Lire le certificat"),
    @("door", "porte"),
    @("Try the door", "Essayer la porte"),
    @("They sound distracted", "Ils ont l'air occupés"),
    @("keys", "clés"),
    @("'Borrow' keys", "« Emprunter » les clés"),
    @("Borrow keys", "Emprunter les clés"),
    @("Those keys are my ticket to freedom", "Ces clés sont mon billet pour la liberté"),
    @("So close, and yet so far!", "Si près, et pourtant si loin !"),
    @("coatstand", "porte-manteau"),
    @("toppled coatrack", "porte-manteau renversé"),
    @("Inspect the coatrack", "Inspecter le porte-manteau"),
    @("fan", "ventilateur"),
    @("Turn on fan", "Allumer le ventilateur"),
    @("Enjoy the cool breeze", "Profiter de la brise fraîche"),
    @("phone", "téléphone"),
    @("Call for help", "Appeler à l'aide"),
    @("Inspect the phone", "Inspecter le téléphone"),
    @("newspaper", "journal"),
    @("Pick up the newspaper", "Ramasser le journal"),
    @("It's today's news!", "Les nouvelles du jour !"),
    @("photo", "photo"),
    @("Look at the photo", "Regarder la photo"),
    @("trophy", "trophée"),
    @("Read plaque", "Lire la plaque"),
    @("umbrella", "parapluie"),
    @("Grab umbrella", "Prendre le parapluie"),
    @("Inspect umbrella", "Inspecter le parapluie"),
    @("window", "fenêtre"),
    @("Gaze out window", "Regarder par la fenêtre"),
    @("Maybe I could escape through the window", "Peut-être pourrais-je m'échapper par la fenêtre"),
    @("Inspect the lamp", "Inspecter la lampe"),
    @("lamp", "lampe"),
    @("desk lamp", "lampe de bureau"),
    @("Browse books", "Feuilleter les livres"),
    @("Inspect books", "Examiner les livres"),
    @("books", "livres"),

    # Early Train Rooms (Intro Carriage & Arthur's Quarters) Interactions
    @("Dining Carriage", "Wagon-restaurant"),
    @("Casino Carriage", "Wagon-casino"),
    @("Lounge Area", "Salon"),
    @("dining cart", "chariot repas"),
    @("statue", "statue"),
    @("pamphlets", "brochures"),
    @("typewriter", "machine à écrire"),
    @("luggage", "valise"),
    @("slippers", "pantoufles"),
    @("mirror", "miroir"),
    @("sink", "lavabo")
)

$sb = New-Object System.Text.StringBuilder
foreach ($l in $existing) {
    [void]$sb.AppendLine($l)
}

$added = 0
foreach ($item in $newLines) {
    $en = $item[0]
    $fr = $item[1]
    if (!$existingKeys.Contains($en)) {
        [void]$sb.AppendLine("$en`t$fr")
        $existingKeys.Add($en)
        $added++
    }
}

[System.IO.File]::WriteAllText($uiTsv, $sb.ToString(), [System.Text.Encoding]::UTF8)
Write-Host "Done! Added $added new UI/Interaction lines to $uiTsv"
