# Twitch World FF14 · Français

[← back](../README.md)

```text
=====================================================================
 TWITCH WORLD FF14 - Guide d'installation (Français)
 Créé par Lirou
=====================================================================

Autres langues dans ce dossier (Docs) : README_PT.txt (Português) |
README_EN.txt (English) | README_JA.txt (日本語) | README_DE.txt (Deutsch)

Le plugin lui-même est en portugais. Seul ce guide existe en plusieurs
langues. Un petit glossaire des mots affichés par le plugin se trouve
dans la partie C.


---------------------------------------------------------------------
 1. QU'EST-CE QUE TWITCH WORLD
---------------------------------------------------------------------
Un plugin Dalamud qui affiche le chat de n'importe quelle chaîne
Twitch DANS Final Fantasy XIV et, si vous le souhaitez, vous permet de
répondre sans quitter le jeu.

Il y a DEUX façons de voir le chat (vous pouvez utiliser les deux en
même temps) :
  * FENÊTRE : une petite fenêtre du plugin que vous pouvez déplacer à
    l'écran.
  * ONGLET DU CHAT DU JEU : les messages apparaissent dans un onglet du
    chat de FF14 lui-même, avec la couleur de chaque personne et des
    badges MOD, VIP, etc.

Ce que le plugin NE laisse PAS passer (règles fixes) :
  * les messages qui commencent par / ou ! (commandes de bots)
  * les emojis, les emotes et les liens
  * plus d'un chat connecté à la fois


---------------------------------------------------------------------
 2. AVANT DE COMMENCER (vérifiez cette liste)
---------------------------------------------------------------------
[ ] Un PC sous Windows 10 ou 11 avec Internet.
[ ] Final Fantasy XIV installé et lancé via XIVLauncher avec Dalamud
    activé (si vous utilisez déjà des plugins, c'est le cas).
[ ] Vous avez lancé le jeu via XIVLauncher au moins UNE fois.
[ ] Environ 600 Mo libres sur le disque C: et 5 à 15 minutes de
    patience.
[ ] Le jeu FERMÉ pendant l'installation (partie A).

Vous n'avez PAS besoin de compte Twitch pour simplement LIRE le chat.
Il n'en faut un que pour ENVOYER des messages.


---------------------------------------------------------------------
 3. AVERTISSEMENTS IMPORTANTS
---------------------------------------------------------------------
* Les plugins Dalamud ne sont PAS autorisés par les conditions
  d'utilisation de Square Enix. Ce plugin ne fait que lire et écrire du
  texte et n'automatise rien dans le jeu, mais le risque lié à
  l'usage de plugins existe. Utilisation à vos risques et périls.
* Le « token » Twitch (partie C) fonctionne comme un MOT DE PASSE. Ne
  le montrez et ne l'envoyez à personne. Il est enregistré en clair
  sur votre PC.
* Ce plugin n'est PAS officiel et n'a aucun lien avec Square Enix,
  Twitch ou Dalamud.
* Le programme d'installation n'a pas de signature numérique payante.
  Windows (et certains antivirus) peut donc s'en méfier. Voir la
  partie A.


---------------------------------------------------------------------
 4. PARTIE A - INSTALLER (sur l'ordinateur, jeu fermé)
---------------------------------------------------------------------
  1. Faites un DOUBLE-CLIC sur le fichier  TwitchWorldFF14-Setup.exe

  2. Si une fenêtre BLEUE « Windows a protégé votre ordinateur »
     apparaît :
        - cliquez sur  « Informations complémentaires »
        - puis sur le bouton  « Exécuter quand même »
     (Cela s'affiche pour tout nouveau programme sans signature
     numérique payante. Si VOTRE antivirus le bloque, ne l'autorisez que
     si vous avez téléchargé ce fichier depuis la page officielle du projet
     sur GitHub (onglet Releases).)

  3. Une fenêtre noire s'ouvre. Tapez le numéro de votre langue et
     appuyez sur Entrée. Exemple : 4 puis Entrée pour le français.

  4. Une boîte demande « Voulez-vous continuer ? ». Cliquez sur OUI.

  5. PATIENTEZ. La fenêtre noire affiche l'avancement de [1/6] à
     [6/6]. NE la fermez PAS. La première fois, elle télécharge .NET
     (environ 250 Mo), ce qui peut prendre plusieurs minutes. Si elle
     semble bloquée, attendez : elle travaille.

  6. À la fin, le message « Tout est prêt ! » apparaît et :
        - ce guide s'ouvre dans le Bloc-notes ;
        - deux raccourcis apparaissent sur votre Bureau :
            « Twitch World FF14 »  (ouvre le dossier)
            « Twitch World FF14 - Guide »  (ouvre ce guide)
        - le CHEMIN du plugin est COPIÉ automatiquement (vous le
          collerez dans le jeu à la partie B).

Le programme a été installé dans le dossier :   C:\Twitch World FF14

Si un message d'erreur apparaît, voyez la section 9 (Problèmes
courants).


---------------------------------------------------------------------
 5. PARTIE B - ACTIVER LE PLUGIN DANS LE JEU (une seule fois)
---------------------------------------------------------------------
  1. Lancez Final Fantasy XIV via XIVLauncher et connectez-vous avec
     votre personnage.

  2. Dans la zone de chat du jeu, tapez :   /xlsettings   puis
     appuyez sur Entrée. La fenêtre « Dalamud Settings » s'ouvre.

  3. Dans la liste de gauche, cliquez sur  « Experimental ».

  4. Faites défiler jusqu'à  « Dev Plugin Locations ».

  5. Cliquez dans la zone de texte vide de cette section et COLLEZ le
     chemin avec  Ctrl + V.  Il doit apparaître exactement ainsi :

        C:\Twitch World FF14\Source\bin\Release\TwitchWorld.dll

     (Si rien n'a été collé, tapez soigneusement le chemin ci-dessus.)

  6. Cliquez sur le bouton  +  à côté de la zone. Le chemin est ajouté
     à la liste.

  7. Cliquez sur  « Save and Close »  en bas.

  8. Tapez   /xlplugins   puis appuyez sur Entrée.

  9. Dans le menu de gauche, cliquez sur  « Dev Tools »  puis sur
     « Installed Dev Plugins ».

 10. Trouvez  « Twitch World »  et vérifiez que son interrupteur est
     ACTIVÉ (allumé). Vous devez voir l'icône Twitch World, « v1.0.0.0 »
     et « by Lirou ».

 11. Tapez   /tw-chat   dans le chat du jeu. La fenêtre « Twitch World »
     s'ouvre.

Terminé ! Le plugin est installé. Il ne reste qu'à choisir quel chat
lire.


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


---------------------------------------------------------------------
 9. PROBLÈMES COURANTS
---------------------------------------------------------------------
- Le programme a affiché « Échec de l'installation » :
    1) Vérifiez Internet et relancez le programme.
    2) Si cela échoue encore, faites une capture d'écran de la fenêtre
       et envoyez-la avec le fichier
       C:\Twitch World FF14\install-log.txt  dans une « Issue » sur la
       page GitHub du projet (onglet Issues > New issue).

- Il a indiqué ne pas trouver Dalamud : lancez le jeu une fois via
  XIVLauncher (Dalamud activé), fermez-le, puis relancez le programme
  d'installation.

- « Twitch World » n'apparaît pas dans « Installed Dev Plugins » :
  vérifiez que le chemin de la partie B est correct et que vous avez
  cliqué sur + et « Save and Close ». Fermez ensuite le jeu et
  rouvrez-le.

- L'icône s'affiche comme « ? » : désactivez puis réactivez le plugin,
  ou redémarrez le jeu.

- « Canal reconhecido » n'apparaît pas : écrivez seulement le nom de
  la chaîne.

- Le statut ne passe pas au vert : cliquez sur « Conectar » ou
  « Reconectar » et vérifiez Internet.

- Je ne vois aucun message : vérifiez que des gens discutent bien.

- Les messages apparaissent dans le mauvais onglet : refaites
  l'étape 3 de la façon 2 (Linkshell [8] uniquement dans l'onglet
  Twitch).

- Mon message ne part pas : vérifiez que vous avez choisi « Ler e
  também enviar », que le nom d'utilisateur et le token sont corrects,
  et rappelez-vous que les messages avec / ! ou des liens sont
  refusés. Il y a un délai minimal d'environ 1,5 seconde entre deux
  messages.

- Le plugin ne se charge plus après un patch du jeu : relancez le
  programme d'installation (il prépare à nouveau le plugin). Si cela
  échoue encore, Dalamud a peut-être changé et une nouvelle version
  sera nécessaire.


---------------------------------------------------------------------
 10. METTRE À JOUR, EFFACER LES PARAMÈTRES ET DÉSINSTALLER
---------------------------------------------------------------------
METTRE À JOUR / RÉINSTALLER : fermez le jeu et relancez le programme
d'installation. Il refait tout et CONSERVE vos paramètres.

SI VOUS AVIEZ UNE ANCIENNE VERSION dans un autre dossier (p. ex.
C:\TwitchWorld) : dans /xlsettings > Experimental, supprimez l'ancien
chemin (bouton corbeille) et enregistrez, pour ne pas avoir deux
copies.

EFFACER LES PARAMÈTRES (chaîne, nom d'utilisateur, token) : jeu
fermé, supprimez le fichier
   %APPDATA%\XIVLauncher\pluginConfigs\TwitchWorld.json
(collez cette adresse dans la barre d'adresse de l'Explorateur).

DÉSINSTALLER :
  1. Dans le jeu : /xlsettings > Experimental > supprimez le chemin de
     TwitchWorld.dll (corbeille) > Save and Close.
  2. Fermez le jeu.
  3. Supprimez les deux raccourcis du Bureau.
  4. Supprimez le dossier  C:\Twitch World FF14
  5. (Si vous avez utilisé un token) sur le site de Twitch, dans
     Paramètres > Connexions, révoquez l'accès de l'application, par
     sécurité.


---------------------------------------------------------------------
 Twitch World FF14 - créé par Lirou.
 Non officiel. Aucun lien avec Square Enix, Twitch ou Dalamud.
---------------------------------------------------------------------
```
