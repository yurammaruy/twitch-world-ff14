# Twitch World FF14

[English](README.md) · [Português](README.pt-BR.md) · [日本語](README.ja.md) · [Deutsch](README.de.md) · **Français**

**Installation :** 📦 avec l'installateur (.exe) – ci-dessous · 🔗 **[avec le lien GitHub – guide complet](docs/INSTALL_GITHUB.FR.md)**

<p align="center"><img src="assets/icon.png" width="128" alt="Twitch World FF14"></p>

> Lisez et répondez au chat Twitch dans Final Fantasy XIV — un plugin Dalamud avec installateur en un seul fichier pour les non-programmeurs.

**Twitch World** affiche le chat de n'importe quelle chaîne Twitch *dans* le jeu (dans sa propre fenêtre et/ou dans un onglet du chat de FFXIV, avec la couleur de chacun et les badges MOD / VIP / SUB) et vous laisse répondre sans quitter le jeu. Il arrive **vierge** : aucune chaîne ni compte configurés. Pour les streamers, modérateurs et spectateurs qui jouent à FFXIV.

## Téléchargement

**[⬇ Télécharger l'installateur (dernière version)](../../releases/tag/v1.0.0)**

## Fonctionnalités

- Chat Twitch en direct dans une fenêtre **et/ou** dans un onglet du chat du jeu (astuce Linkshell [8], expliquée dans le guide)
- Couleurs des pseudos Twitch (approchées de la palette du jeu) et badges [STREAMER] [MOD] [VIP] [SUB] [BOT]
- Les messages qui vous mentionnent apparaissent en doré ; les alertes de bots en turquoise
- Le mode lecture seule ne demande **ni compte ni jeton** ; pour écrire : `/tw-chat votre message`
- Bloque les commandes de bot (`/` et `!`), emojis, emotes et liens ; un seul chat à la fois ; **aucun message n'est masqué**
- Installateur pour débutants en **5 langues** (English, 日本語, Deutsch, Français, Português) avec guide pas à pas

## Installation rapide (Windows 10/11)

1. Téléchargez **TwitchWorldFF14-Setup.exe** depuis la [dernière version](../../releases/tag/v1.0.0) (section *Assets*).
2. Fermez FFXIV. Double-cliquez sur le fichier. Si Windows affiche la fenêtre bleue *« Windows a protégé votre ordinateur »* : **Informations complémentaires → Exécuter quand même**.
3. Choisissez la langue, confirmez et attendez `[6/6]` (la première fois, .NET est téléchargé, ~250 Mo).
4. Dans le jeu : `/xlsettings` → **Experimental** → **Dev Plugin Locations** → collez (Ctrl+V ; le chemin est déjà copié) → **+** → **Save and Close**.
5. `/xlplugins` → **Dev Tools** → **Installed Dev Plugins** → activez **Twitch World** → tapez `/tw-chat`.

## Guide complet pas à pas

📖 **[Français – full step-by-step guide](docs/GUIDE.FR.md)** · [English](docs/GUIDE.EN.md) · [Português (Brasil)](docs/GUIDE.PT.md) · [日本語](docs/GUIDE.JA.md) · [Deutsch](docs/GUIDE.DE.md)

## Important

- Les plugins Dalamud ne sont **pas autorisés** par les conditions d'utilisation de Square Enix. Ce plugin ne fait que lire/écrire du texte et n'automatise rien dans le jeu, mais le risque existe — utilisation à vos risques.
- Projet non officiel. Aucun lien avec Square Enix, Twitch ou Dalamud. « Twitch » et « Final Fantasy » appartiennent à leurs propriétaires.
- L'installateur n'est **pas signé numériquement** : Windows/antivirus peuvent avertir. Tout le code source est dans ce dépôt et chaque version indique la somme SHA-256. Ne téléchargez que depuis cette page.
- Le jeton Twitch (nécessaire seulement pour *envoyer*) est comme un mot de passe. Ne le partagez jamais.

## Aide / bugs

Ouvrez une [Issue](../../issues/new/choose) (joignez `install-log.txt`, jamais votre jeton).

---

**Mots-clés :** Final Fantasy XIV, FFXIV, FF14, plugin Dalamud, XIVLauncher, chat Twitch en jeu, overlay chat Twitch, outil de streamer, onglet de chat Linkshell.

MIT License · © 2026 Lirou
