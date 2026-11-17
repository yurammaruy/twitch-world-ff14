# Twitch World FF14 · Installer avec le lien GitHub – guide complet

[English](INSTALL_GITHUB.EN.md) · [Português](INSTALL_GITHUB.PT.md) · [日本語](INSTALL_GITHUB.JA.md) · [Deutsch](INSTALL_GITHUB.DE.md) · **Français**

**Installation :** [📦 avec l'installateur (.exe)](../README.fr.md) · **🔗 avec le lien GitHub (cette page)**

> Pas d'installateur, rien à télécharger, pas de .NET. Vous collez **une adresse** dans Dalamud et installez Twitch World depuis la liste normale des plugins. Les mises à jour arrivent toutes seules. Fonctionne partout où XIVLauncher + Dalamud fonctionnent (Windows, Linux, macOS).

## Avant de commencer

- Final Fantasy XIV lancé au moins une fois via **XIVLauncher avec Dalamud activé** (si vous utilisez déjà des plugins, c'est bon).
- Une connexion Internet.
- Si vous avez déjà installé Twitch World avec le `.exe`, faites d'abord l'**étape 0**.

## Important

- Les plugins Dalamud ne sont **pas autorisés** par les conditions d'utilisation de Square Enix. Ce plugin ne fait que lire/écrire du texte et n'automatise rien dans le jeu, mais le risque existe. Utilisation à vos risques.
- Projet non officiel, sans lien avec Square Enix, Twitch ou Dalamud.
- Un « jeton » (Partie C) est comme un mot de passe. Ne le montrez à personne.
- Dalamud l'indiquera comme *dépôt tiers*. C'est normal : le code source est lisible par tous dans ce projet GitHub.

## Étape 0 – Seulement si vous avez utilisé le .exe

1. Tapez `/xlsettings`, appuyez sur Entrée et cliquez sur **Experimental**.
2. Dans **Dev Plugin Locations**, cliquez sur la corbeille à côté du chemin de `TwitchWorld.dll`.
3. Cliquez sur **Save and Close**. Fermez le jeu et relancez-le.
4. (Vous pourrez supprimer le dossier `C:\Twitch World FF14` plus tard. Vos paramètres sont conservés.)

## Partie A – Ajouter le lien GitHub dans Dalamud (une seule fois)

1. Dans la zone de chat du jeu, tapez `/xlsettings` et appuyez sur Entrée. La fenêtre *Dalamud Settings* s'ouvre.
2. Dans la liste de gauche, cliquez sur **Experimental**.
3. Faites défiler jusqu'à **Custom Plugin Repositories**.
4. Cliquez dans la case de texte vide et collez cette adresse avec **Ctrl + V** :

   ```text
   https://raw.githubusercontent.com/yurammaruy/twitch-world-ff14/main/repo.json
   ```

5. Cliquez sur le bouton **+** à droite. L'adresse apparaît dans la liste.
6. Vérifiez que la petite **case à cocher** à côté de l'adresse est cochée.
7. Cliquez sur **Save and Close** en bas.

> Astuce : si Ctrl+V ne colle rien, copiez de nouveau l'adresse depuis la zone grise ci-dessus (bouton de copie en haut à droite).

## Partie B – Installer le plugin depuis la liste (une seule fois)

1. Tapez `/xlplugins` et appuyez sur Entrée. L'installateur de plugins s'ouvre.
2. Cliquez sur **All Plugins** dans le menu de gauche.
3. Dans la zone de recherche, tapez `Twitch World`.
4. Cliquez sur **Install** et patientez quelques secondes.
5. Trouvez **Twitch World** dans **Installed Plugins** et vérifiez que l'interrupteur est ACTIVÉ. Vous devez voir l'icône, la version et **by Lirou**.
6. Tapez `/tw-chat` dans le chat du jeu. La fenêtre « Twitch World » s'ouvre.

> C'est fait : le plugin est installé. Choisissez maintenant le chat à lire (Partie C).

## Parties C, D et commandes (identiques à la version avec installateur)

```text
---------------------------------------------------------------------
 6. PARTIE C - SE CONNECTER AU CHAT D'UNE CHAÎNE TWITCH
---------------------------------------------------------------------
Le plugin est livré VIERGE : aucune chaîne ni aucun compte configuré.

Mots que vous verrez à l'écran du plugin (il est en portugais) :
   Config ......................... Paramètres
   Conectar / Conectar agora ...... Connecter / Connecter maintenant
   Reconectar ..................... Reconnecter
   Desconectar .................... Déconnecter
   Só ler as mensagens do chat .... Seulement lire les messages du chat
   Ler e também enviar mensagens .. Lire et aussi envoyer des messages
   Canal reconhecido .............. Chaîne reconnue
   Conectado a #canal ............. Connecté à #chaîne

  1. Dans la fenêtre « Twitch World », cliquez sur  Config.

  2. Dans  « 1) Link do chat (ou só o nome do canal) »  écrivez la
     chaîne. Toutes ces formes fonctionnent :
        https://www.twitch.tv/nomdelachaine
        https://dashboard.twitch.tv/popout/u/nomdelachaine/stream-manager/chat
        nomdelachaine
     En dessous doit apparaître, en vert :
        « Canal reconhecido: nomdelachaine ».

  3. Dans  « 2) O que você quer fazer? »  choisissez UNE option :
        ( ) Só ler as mensagens do chat   (lecture seule)
              -> le plus simple. AUCUN compte et AUCUN token requis.
        ( ) Ler e também enviar mensagens (/tw-chat)   (lire et envoyer)
              -> nécessite l'étape 4.

  4. (UNIQUEMENT si vous avez choisi d'envoyer des messages) Obtenez
     un token Twitch :
        a) Ouvrez dans votre navigateur :  https://twitchtokengenerator.com
           (un site tiers bien connu).
        b) Choisissez l'option  « Bot Chat Token ».
        c) Cochez les autorisations  chat:read  et  chat:edit  puis
           autorisez avec VOTRE compte Twitch.
        d) Copiez l'  « Access Token »  (un long texte).
        e) Dans le plugin, remplissez :
             « Seu nome de usuário da Twitch » = le nom de votre compte
             « Token de acesso » = le token copié (Ctrl+V)
     RAPPEL : le token est comme un mot de passe. Ne le montrez à
     personne.

  5. Cliquez sur  « Conectar agora ».  Le statut doit passer au VERT :
        Conectado a #nomdelachaine

  6. (Facultatif) Cochez  « Conectar automaticamente ao abrir o jogo »
     (se connecter automatiquement au lancement du jeu).

Les messages apparaissent dans la fenêtre « Twitch World ».


---------------------------------------------------------------------
 7. PARTIE D - UTILISER : LES DEUX FAÇONS
---------------------------------------------------------------------

=== FAÇON 1 : DANS LA FENÊTRE DU PLUGIN ===
  * Tapez  /tw-chat  (sans texte) pour ouvrir ou fermer la fenêtre.
  * Déplacez la fenêtre et tirez sur ses coins pour la redimensionner.
  * Si vous avez choisi « Ler e também enviar », écrivez dans la zone
    du bas et appuyez sur Entrée. Ici, inutile de taper /tw-chat.

=== FAÇON 2 : DANS LE CHAT DU JEU (dans un onglet) ===
Le jeu ne permet pas à un plugin de créer des onglets tout seul. Vous
en créez donc un et vous lui indiquez quel « canal » de chat afficher.
À faire une seule fois :

  1. CRÉER L'ONGLET : dans la fenêtre de chat du jeu, cliquez sur le
     bouton  +  à côté des onglets et nommez-le  Twitch.

  2. DANS LE PLUGIN (/tw-chat > Config) :
        - cochez  « Mostrar as mensagens no chat do jogo (só você vê) »
          (afficher les messages dans le chat du jeu, vous seul les
          voyez)
        - sous « Canal usado no chat do jogo » gardez  « Linkshell [8]
          (recomendado) ».

  3. DANS LE JEU, choisissez le canal affiché par chaque onglet :
        - ouvrez  Character Configuration > Log Window Settings >
          Log Filters.  (Dans le jeu, les noms s'affichent dans la
          langue de votre jeu ; repérez le numéro [8].)
        - sélectionnez l'onglet  « Twitch »,  puis le sous-onglet
          « Chat ».
        - COCHEZ uniquement  « Linkshell [8] »  (décochez le reste de
          cet onglet).
        - sélectionnez ensuite l'onglet  « General »  (et les autres si
          vous le souhaitez) et DÉCOCHEZ  « Linkshell [8] »,  pour que
          les messages n'apparaissent pas à deux endroits.

  4. Les messages apparaissent dans l'onglet Twitch ainsi :
        [BADGES] Nom disse: message
     Vous SEUL voyez cela. Personne d'autre dans le jeu.

  Pour ENVOYER, tapez dans le chat du jeu :
        /tw-chat votre message
  (Astuce : créez une macro avec des phrases toutes faites, p. ex.
  /tw-chat merci !)

COULEURS ET BADGES (dans /tw-chat > Config > « Cores e destaques do
chat ») :
  * chaque personne apparaît dans la couleur qu'elle a choisie sur
    Twitch. Dans le chat du jeu, la couleur est APPROXIMATIVE (le jeu
    a peu de couleurs).
  * badges avant le nom : [STREAMER] [MOD] [VIP] [SUB] [BOT]
  * les messages qui vous mentionnent s'affichent en DORÉ
  * les messages de bots (alertes de followers, raids...) s'affichent
    en turquoise
  * aucun message n'est masqué.

---------------------------------------------------------------------
 8. COMMANDES
---------------------------------------------------------------------
   /tw-chat                    ouvre ou ferme la fenêtre
   /tw-chat votre message      envoie le message au chat Twitch
   /xlplugins                  gestionnaire de plugins Dalamud
   /xlsettings                 paramètres de Dalamud
```

## Problèmes courants (installation par lien)

**« Twitch World » n'apparaît pas dans All Plugins**  
Vérifiez que l'adresse est collée en entier et que la case est cochée (Partie A, étapes 5–7). Cliquez sur **Save and Close** puis rouvrez `/xlplugins`. Sinon, redémarrez le jeu.

**L'adresse donne « 404 » ou Dalamud signale une erreur de dépôt**  
La publication n'est peut-être pas terminée (le premier build prend quelques minutes) ou le projet est privé. Réessayez plus tard ou ouvrez une Issue.

**Deux « Twitch World » apparaissent ou le plugin ne s'active pas**  
L'ancienne copie du `.exe` est encore enregistrée comme *plugin de développement*. Faites l'**étape 0**, redémarrez le jeu et réinstallez.

**L'icône est un « ? »**  
Désactivez puis réactivez le plugin, ou redémarrez le jeu.

**Le plugin ne marche plus après un patch du jeu**  
Dalamud se met à jour après les patchs ; attendez la mise à jour du plugin (dans *Updates* de `/xlplugins`). Si cela persiste, ouvrez une Issue sur GitHub.

**Autre chose**  
Ouvrez une Issue dans ce projet GitHub et décrivez l'étape qui échoue. Ne publiez jamais votre jeton Twitch.

## Mettre à jour, effacer les paramètres et désinstaller

- **Mise à jour :** automatique. Ouvrez `/xlplugins` → **Installed Plugins** → **Update** quand une nouvelle version s'affiche.
- **Effacer les paramètres** (chaîne, pseudo, jeton) : jeu fermé, supprimez `%APPDATA%\XIVLauncher\pluginConfigs\TwitchWorld.json` (collez-le dans la barre d'adresse de l'Explorateur).
- **Désinstaller :** `/xlplugins` → **Installed Plugins** → Twitch World → **Delete**. Puis `/xlsettings` → Experimental → supprimez l'adresse sous Custom Plugin Repositories (corbeille) → Save and Close.
- Si vous avez utilisé un jeton, révoquez l'accès de l'application sur le site de Twitch (Paramètres → Connexions).

---

Unofficial · MIT License · © 2026 Lirou
