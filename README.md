# Loco Motive — Patch de Traduction Française Intégrale (100%)

Ce projet a pour objectif la traduction intégrale en français du jeu d'aventure point-and-click **Loco Motive** (développé par *Robust Games* et édité par *Chucklefish*).

---

## 🚂 Présentation

*Loco Motive* est un jeu d'enquête humoristique hommage aux classiques du point-and-click des années 90 et aux romans policiers à huis clos (Agatha Christie). N'ayant pas bénéficié d'une traduction officielle en français, ce projet propose :
- Une **extraction exhaustive (100%)** de l'ensemble des textes du jeu (dialogues, options de dialogue, inventaire, descriptions d'objets, menus, indices).
- Une **adaptation soignée de l'humour, des jeux de mots et du ton d'époque** des protagonistes (Arthur Ackerman, Herman Merman, Diana Osterhagen).
- Un **patch technique non-destructif** garantissant la prise en charge complète des accents français (`é, è, ê, à, ç, œ, « »`) avec un temps de lecture adapté.
- Un **installeur 1-clic** simple pour toutes les versions (GOG, Steam).

---

## 📂 Structure du Répertoire

- `tools/` : Scripts d'extraction, de parsing et de synchronisation des textes du jeu.
- `translations/` : Fichiers sources de traduction (dialogues, interface, objets, glossaire).
  - `translations/dialogues/` : Lignes de dialogue classées par chapitres / scènes / personnages.
  - `translations/ui/` : Menus, options, astuces et tutoriels.
  - `translations/items/` : Objets d'inventaire et descriptions de hotspots.
  - `translations/glossary.json` : Glossaire terminologique et choix d'adaptation.
- `patch/` : Code source et configuration du moteur d'injection.
- `dist/` : Fichiers finaux prêts à l'installation pour les joueurs.

---

## 🛠️ Spécifications Techniques

- **Moteur :** Unity 2021.3 (Mono x64).
- **Framework narratif :** PowerQuest (`PowerTools.Quest.SystemText`).
- **Rendu typographique :** TextMeshPro (`QuestTextPro` / SDF).
- **Format de travail :** JSON & TSV bilingues (Anglais original / Français adapté / Contexte).

---

## ⚖️ Licence & Remerciements

- Projet communautaire bénévole à but non lucratif.
- Merci aux pionniers de la communauté de traduction francophone des jeux d'aventure (*Planète Aventure*).
- *Loco Motive* est la propriété exclusive de Robust Games et Chucklefish.
