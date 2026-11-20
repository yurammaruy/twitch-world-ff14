# Twitch World FF14

[English](README.md) · [Português](README.pt-BR.md) · [日本語](README.ja.md) · [Deutsch](README.de.md) · **Français**

<p align="center"><img src="assets/icon.png" width="128" alt="Twitch World FF14"></p>

> Lisez et répondez au chat Twitch dans Final Fantasy XIV — un plugin Dalamud qui s'installe avec un simple lien.

**Twitch World** affiche le chat de n'importe quelle chaîne Twitch *dans* le jeu (dans sa propre fenêtre et/ou dans un onglet du chat de FFXIV, avec la couleur de chacun et les badges MOD / VIP / SUB) et vous laisse répondre sans quitter le jeu. Il arrive **vierge** : aucune chaîne ni compte configurés. Pour les streamers, modérateurs et spectateurs qui jouent à FFXIV.

## Installer avec le seul lien

Pas d'installateur, rien à télécharger, pas de .NET. Vous collez **une adresse** dans Dalamud et installez Twitch World depuis la liste normale des plugins. Les mises à jour arrivent toutes seules. Fonctionne partout où XIVLauncher + Dalamud fonctionnent (Windows, Linux, macOS).

```text
https://raw.githubusercontent.com/yurammaruy/twitch-world-ff14/main/repo.json
```

1. Dans la zone de chat du jeu, tapez `/xlsettings` et appuyez sur Entrée. La fenêtre *Dalamud Settings* s'ouvre.
2. Dans la liste de gauche, cliquez sur **Experimental**.
3. Faites défiler jusqu'à **Custom Plugin Repositories**.
4. Cliquez dans la case de texte vide et collez cette adresse avec **Ctrl + V** :
5. Cliquez sur le bouton **+** à droite. L'adresse apparaît dans la liste.
6. Vérifiez que la petite **case à cocher** à côté de l'adresse est cochée.
7. Cliquez sur **Save and Close** en bas.
8. Tapez `/xlplugins` et appuyez sur Entrée. L'installateur de plugins s'ouvre.
9. Cliquez sur **All Plugins** dans le menu de gauche.
10. Dans la zone de recherche, tapez `Twitch World`.
11. Cliquez sur **Install** et patientez quelques secondes.
12. Trouvez **Twitch World** dans **Installed Plugins** et vérifiez que l'interrupteur est ACTIVÉ. Vous devez voir l'icône, la version et **by Lirou**.
13. Tapez `/tw-chat` dans le chat du jeu. La fenêtre « Twitch World » s'ouvre.

> Astuce : si Ctrl+V ne colle rien, copiez de nouveau l'adresse depuis la zone grise ci-dessus (bouton de copie en haut à droite).

## Jeton Twitch (seulement pour envoyer des messages)

**Le jeton n'est nécessaire que pour ENVOYER des messages.** Pour simplement lire un chat, ni compte ni jeton : passez cette section. Le jeton est un long texte qui fonctionne comme un mot de passe : il permet au plugin d'écrire dans le chat en votre nom. Vous ne donnez jamais votre mot de passe Twitch au plugin.

1. Dans votre navigateur, connectez-vous à Twitch avec le compte avec lequel vous voulez discuter, puis ouvrez **https://twitchtokengenerator.com** (un site connu, qui n'appartient ni à Twitch ni à ce projet).
2. Choisissez **Bot Chat Token** (l'option pour les bots de chat). Si le site n'affiche qu'une liste personnalisée, cochez les autorisations **chat:read** et **chat:edit**. Rien d'autre n'est nécessaire.
3. Cliquez sur le bouton de connexion à Twitch. Une page Twitch demande l'autorisation. Vérifiez que c'est le bon compte et cliquez sur **Authorize** (Autoriser). Résolvez le captcha si demandé.
4. De retour sur le site, un long texte appelé **Access Token** s'affiche (il peut y avoir aussi un *Refresh Token* et un *Client ID*). Copiez **uniquement l'Access Token** (bouton de copie, ou sélection puis Ctrl+C).
5. Dans le jeu, tapez `/tw-chat` et cliquez sur **Config**. … Cliquez sur **Conectar agora** (*Se connecter maintenant*). Le statut passe au VERT : *Conectado a #chaîne como votre_pseudo*.

📖 **[Tutoriel complet du jeton](docs/GUIDE.FR.md#comment-obtenir-votre-jeton-twitch)**

## Fonctionnalités

- Chat Twitch en direct dans une fenêtre **et/ou** dans un onglet du chat du jeu (n'importe quel Linkshell ou Linkshell inter-mondes, de 1 à 8, expliqué dans le guide)
- Couleurs des pseudos Twitch (approchées de la palette du jeu) et badges [STREAMER] [MOD] [VIP] [SUB] [BOT]
- Les messages qui vous mentionnent apparaissent en doré ; les alertes de bots en turquoise
- Le mode lecture seule ne demande **ni compte ni jeton** ; pour écrire : `/tw-chat votre message`
- Bloque les commandes de bot (`/` et `!`), emojis, emotes et liens ; un seul chat à la fois ; **aucun message n'est masqué**
- Guide pas à pas pour débutants en **5 langues** (English, 日本語, Deutsch, Français, Português)

## Important

- Les plugins Dalamud ne sont **pas autorisés** par les conditions d'utilisation de Square Enix. Ce plugin ne fait que lire/écrire du texte et n'automatise rien dans le jeu, mais le risque existe — utilisation à vos risques.
- Projet non officiel. Aucun lien avec Square Enix, Twitch ou Dalamud. « Twitch » et « Final Fantasy » appartiennent à leurs propriétaires.
- Le jeton Twitch (nécessaire seulement pour *envoyer*) est comme un mot de passe. Ne le partagez jamais.

## Aide / bugs

Ouvrez une [Issue](../../issues/new/choose) et décrivez l'étape qui échoue (ne publiez jamais votre jeton Twitch).

---

**Mots-clés :** Final Fantasy XIV, FFXIV, FF14, plugin Dalamud, XIVLauncher, chat Twitch en jeu, overlay chat Twitch, outil de streamer, onglet de chat Linkshell.

MIT License · © 2026 Lirou
