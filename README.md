# 🚂 Loco Motive — Patch de Traduction Française (Bêta Ouverte)

[![Version](https://img.shields.io/badge/Version-v1.0.0--beta-blue.svg)](https://github.com/DonTarken/loco-motive-patch-fr/releases)
[![Statut](https://img.shields.io/badge/Statut-B%C3%AAta%20Ouverte%20%7C%20Playtest%20en%20cours-orange.svg)](https://github.com/DonTarken/loco-motive-patch-fr/issues)
[![Couverture](https://img.shields.io/badge/Textes%20traduits-100%25-brightgreen.svg)]()
[![Plateformes](https://img.shields.io/badge/Plateformes-Windows%20%7C%20Steam%20Deck%20(Proton)-purple.svg)]()
[![Compatibilité](https://img.shields.io/badge/Compatibilit%C3%A9-Steam%20%7C%20GOG-lightgrey.svg)]()

Ce projet propose un patch de localisation intégrale en français pour le jeu d'aventure point-and-click **Loco Motive**, développé par *Robust Games* et édité par *Chucklefish*.

> [!IMPORTANT]
> **📢 Projet en cours — Bêta Publique & Playtest Communautaire**  
> L'intégralité des textes du jeu (100 % des dialogues, interactions, menus et inventaire) a été traduite et le jeu est jouable du début à la fin en français.  
> Le projet est actuellement en **phase de relecture et de playtest en conditions réelles**. Vos retours sont essentiels pour peaufiner les répliques, corriger les éventuelles coquilles ou ajuster les tournures d'humour !

---

## 🎯 Contenu du Patch

* **100 % des textes traduits** : dialogues, cinématiques, choix de répliques, inventaire, indices, descriptions de survols d'objets (hotspots), objectifs de quêtes et interfaces.
* **Localisation soignée pour le Point & Click** : adaptation respectueuse de l'humour britannique des années 1930, des calembours, des énigmes textuelles et des répliques sarcastiques des trois protagonistes (*Arthur Ackerman*, *Herman Merman*, *Diana Osterhagen*).
* **Intégration directe dans les options du jeu** : le français apparaît nativement dans le menu *Paramètres > Langue du texte*, aux côtés de l'anglais et de l'allemand.
* **Rechargement à chaud (Touche F5)** : possibilité de rafraîchir instantanément les fichiers de textes en plein jeu sans devoir relancer la partie.

---

## 📥 Téléchargement

Rendez-vous dans la section des versions publiées :  
👉 **[Télécharger le dernier patch (Fichier ZIP)](https://github.com/DonTarken/loco-motive-patch-fr/releases/latest)**

---

## 🛠️ Tutoriel d'Installation

### 🖥️ Sur Windows (Steam ou GOG)

1. **Téléchargez** l'archive `LocoMotive_Patch_FR_vX.X.X.zip` depuis le lien ci-dessus.
2. **Accédez au dossier de votre jeu** :
   * **Steam** : Dans votre bibliothèque, faites un clic droit sur *Loco Motive* > *Gérer* > *Parcourir les fichiers locaux*.
   * **GOG Galaxy** : Clic droit sur le jeu > *Gérer l'installation* > *Afficher le dossier*.
3. **Extrayez tout le contenu du fichier ZIP** directement dans ce dossier (au même niveau que le fichier exécutable `Loco Motive.exe`).  
   *(Vous devez y voir apparaître les fichiers `winhttp.dll`, `doorstop_config.ini` et le dossier `BepInEx`).*
4. **Lancez le jeu normalement**, rendez-vous dans **Paramètres > Langue du texte**, puis sélectionnez **Français**.

---

### 🎮 Sur Steam Deck / Linux (Proton)

1. Suivez les mêmes étapes d'extraction dans le dossier du jeu en mode Bureau.
2. Dans Steam, ouvrez les **Propriétés** de *Loco Motive*.
3. Dans la section **Général > Options de lancement**, copiez-collez la commande suivante :
   ```bash
   WINEDLLOVERRIDES="winhttp=n,b" %command%
   ```
4. Lancez le jeu et activez le français dans les options.

---

## 🗑️ Désinstallation

Le patch est totalement non-destructif et ne modifie aucun fichier original du jeu.  
Pour le désinstaller, supprimez simplement du dossier du jeu :
* Le dossier `BepInEx`
* Le fichier `winhttp.dll`
* Le fichier `doorstop_config.ini`

---

## 💬 Retours, signalement de coquilles et bugs

Votre aide est précieuse pour peaufiner la traduction ! Si vous repérez :
* Un texte manquant ou resté en anglais
* Une faute d'orthographe ou une maladresse de formulation
* Une incohérence dans une énigme ou un nom d'objet
* Un problème technique

👉 **[Ouvrir un ticket sur GitHub Issues](https://github.com/DonTarken/loco-motive-patch-fr/issues/new/choose)**  
*(Des formulaires guidés sont disponibles pour vous faciliter la tâche, avec possibilité de joindre une capture d'écran).*

---

## ⚖️ Mentions légales

* Ce patch est un projet bénévole réalisé par des passionnés pour la communauté francophone.
* *Loco Motive* est une marque et une œuvre développée par **Robust Games** et publiée par **Chucklefish**. Tous droits réservés.
