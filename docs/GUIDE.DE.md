# Twitch World FF14 · Deutsch

[← back](../README.md)

```text
=====================================================================
 TWITCH WORLD FF14 - Installationsanleitung (Deutsch)
 Erstellt von Lirou
=====================================================================

Weitere Sprachen in diesem Ordner (Docs): README_PT.txt (Português) |
README_EN.txt (English) | README_JA.txt (日本語) | README_FR.txt (Français)

Das Plugin selbst ist auf Portugiesisch. Nur diese Anleitung gibt es
in mehreren Sprachen. Eine kleine Wortliste der Bildschirmtexte des
Plugins steht in Teil C.


---------------------------------------------------------------------
 1. WAS IST TWITCH WORLD
---------------------------------------------------------------------
Ein Dalamud-Plugin, das den Chat eines beliebigen Twitch-Kanals IM
Final Fantasy XIV anzeigt und dir, wenn du möchtest, erlaubt zu
antworten, ohne das Spiel zu verlassen.

Es gibt ZWEI Arten, den Chat zu sehen (du kannst beide gleichzeitig
nutzen):
  * FENSTER: ein kleines Plugin-Fenster, das du über den Bildschirm
    ziehen kannst.
  * REGISTERKARTE IM SPIELCHAT: die Nachrichten erscheinen in einem
    Tab des FF14-Chats selbst, mit der Farbe jeder Person und
    MOD-/VIP-Abzeichen.

Was das Plugin NICHT durchlässt (feste Regeln):
  * Nachrichten, die mit / oder ! beginnen (Bot-Befehle)
  * Emojis, Emotes und Links
  * mehr als ein verbundener Chat gleichzeitig


---------------------------------------------------------------------
 2. BEVOR DU ANFÄNGST (Liste prüfen)
---------------------------------------------------------------------
[ ] Ein PC mit Windows 10 oder 11 und Internet.
[ ] Final Fantasy XIV ist installiert und wird über den XIVLauncher
    mit aktiviertem Dalamud gestartet (wer schon Plugins nutzt, hat
    das).
[ ] Du hast das Spiel mindestens EINMAL über den XIVLauncher gestartet.
[ ] Etwa 600 MB freier Platz auf Laufwerk C: und 5 bis 15 Minuten
    Geduld.
[ ] Das Spiel ist während der Installation (Teil A) GESCHLOSSEN.

Du brauchst KEIN Twitch-Konto, um den Chat nur zu LESEN. Ein Konto
brauchst du nur zum SENDEN von Nachrichten.


---------------------------------------------------------------------
 3. WICHTIGE HINWEISE
---------------------------------------------------------------------
* Dalamud-Plugins sind laut den Nutzungsbedingungen von Square Enix
  NICHT erlaubt. Dieses Plugin liest und schreibt nur Text und
  automatisiert nichts im Spiel, aber das Risiko bei der Nutzung von
  Plugins besteht. Nutzung auf eigene Gefahr.
* Der Twitch-"Token" (Teil C) funktioniert wie ein PASSWORT. Zeige ihn
  niemandem und sende ihn niemandem. Er wird im Klartext auf deinem PC
  gespeichert.
* Dieses Plugin ist NICHT offiziell und steht in keiner Verbindung zu
  Square Enix, Twitch oder Dalamud.
* Das Installationsprogramm hat keine kostenpflichtige digitale
  Signatur. Deshalb kann Windows (und manches Antivirenprogramm)
  misstrauisch reagieren. Siehe Teil A.


---------------------------------------------------------------------
 4. TEIL A - INSTALLIEREN (am Computer, bei geschlossenem Spiel)
---------------------------------------------------------------------
  1. Mache einen DOPPELKLICK auf die Datei  TwitchWorldFF14-Setup.exe

  2. Falls ein BLAUES Fenster mit "Der Computer wurde durch Windows
     geschützt" erscheint:
        - klicke auf  "Weitere Informationen"
        - dann auf die Schaltfläche  "Trotzdem ausführen"
     (Das erscheint bei jedem neuen Programm ohne kostenpflichtige
     digitale Signatur. Wenn DEIN Antivirenprogramm es blockiert, erlaube
     es nur, wenn du die Datei von der offiziellen GitHub-Projektseite
     (Reiter Releases) heruntergeladen hast.)

  3. Ein schwarzes Fenster öffnet sich. Tippe die Nummer deiner Sprache
     und drücke die Eingabetaste. Beispiel: 3 und Eingabetaste für
     Deutsch.

  4. Ein Fenster fragt "Möchtest du fortfahren?". Klicke auf JA.

  5. WARTE. Das schwarze Fenster zeigt den Fortschritt von [1/6] bis
     [6/6]. SCHLIESSE es NICHT. Beim ersten Mal lädt es .NET herunter
     (etwa 250 MB), was mehrere Minuten dauern kann. Wenn es hängt,
     warte weiter: Es arbeitet.

  6. Am Ende erscheint die Meldung "Alles fertig!" und:
        - diese Anleitung öffnet sich im Editor;
        - zwei Verknüpfungen erscheinen auf deinem Desktop:
            "Twitch World FF14"  (öffnet den Ordner)
            "Twitch World FF14 - Anleitung"  (öffnet diese Anleitung)
        - der PFAD des Plugins wird automatisch KOPIERT (du fügst ihn
          in Teil B im Spiel ein).

Das Programm wurde in diesem Ordner installiert:   C:\Twitch World FF14

Wenn eine Fehlermeldung erscheint, siehe Abschnitt 9 (Häufige Probleme).


---------------------------------------------------------------------
 5. TEIL B - PLUGIN IM SPIEL AKTIVIEREN (nur EINMAL nötig)
---------------------------------------------------------------------
  1. Starte Final Fantasy XIV über den XIVLauncher und melde dich mit
     deinem Charakter an.

  2. Tippe im Chatfeld des Spiels:   /xlsettings   und drücke die
     Eingabetaste. Das Fenster "Dalamud Settings" öffnet sich.

  3. Klicke in der Liste links auf  "Experimental".

  4. Scrolle nach unten bis  "Dev Plugin Locations".

  5. Klicke in das leere Textfeld dieses Bereichs und FÜGE den Pfad mit
     Strg + V  ein. Es muss genau so dastehen:

        C:\Twitch World FF14\Source\bin\Release\TwitchWorld.dll

     (Falls nichts eingefügt wurde, tippe den Pfad oben sorgfältig ab.)

  6. Klicke auf die Schaltfläche  +  neben dem Feld. Der Pfad kommt in
     die Liste.

  7. Klicke unten auf  "Save and Close".

  8. Tippe   /xlplugins   und drücke die Eingabetaste.

  9. Klicke im Menü links auf  "Dev Tools"  und dann auf
     "Installed Dev Plugins".

 10. Suche  "Twitch World"  und stelle sicher, dass der Schalter AN
     (leuchtend) ist. Du solltest das Twitch-World-Symbol, "v1.0.0.0"
     und "by Lirou" sehen.

 11. Tippe   /tw-chat   im Spielchat. Das Fenster "Twitch World"
     öffnet sich.

Fertig! Das Plugin ist installiert. Jetzt musst du nur noch wählen,
welchen Chat du lesen willst.


---------------------------------------------------------------------
 6. TEIL C - MIT EINEM TWITCH-CHAT VERBINDEN
---------------------------------------------------------------------
Das Plugin kommt SAUBER: kein Kanal und kein Konto eingerichtet.

Wörter, die du auf dem Plugin-Bildschirm siehst (er ist portugiesisch):
   Config ......................... Einstellungen
   Conectar / Conectar agora ...... Verbinden / Jetzt verbinden
   Reconectar ..................... Neu verbinden
   Desconectar .................... Trennen
   Só ler as mensagens do chat .... Nur die Chatnachrichten lesen
   Ler e também enviar mensagens .. Lesen und auch Nachrichten senden
   Canal reconhecido .............. Kanal erkannt
   Conectado a #canal ............. Verbunden mit #Kanal

  1. Klicke im Fenster "Twitch World" auf  Config.

  2. Schreibe bei  "1) Link do chat (ou só o nome do canal)"  den Kanal.
     Jede dieser Formen funktioniert:
        https://www.twitch.tv/kanalname
        https://dashboard.twitch.tv/popout/u/kanalname/stream-manager/chat
        kanalname
     Darunter muss in Grün stehen:  "Canal reconhecido: kanalname".

  3. Wähle bei  "2) O que você quer fazer?"  EINE Option:
        ( ) Só ler as mensagens do chat   (nur lesen)
              -> am einfachsten. KEIN Konto und KEIN Token nötig.
        ( ) Ler e também enviar mensagens (/tw-chat)   (lesen und senden)
              -> braucht Schritt 4.

  4. (NUR wenn du das Senden gewählt hast) Hole einen Twitch-Token:
        a) Öffne im Browser:  https://twitchtokengenerator.com
           (eine bekannte Seite eines Drittanbieters).
        b) Wähle die Option  "Bot Chat Token".
        c) Hake die Berechtigungen  chat:read  und  chat:edit  an und
           autorisiere mit DEINEM Twitch-Konto.
        d) Kopiere den  "Access Token"  (ein langer Text).
        e) Trage im Plugin ein:
             "Seu nome de usuário da Twitch" = dein Kontoname
             "Token de acesso" = der kopierte Token (Strg+V)
     DENK DARAN: Der Token ist wie ein Passwort. Zeige ihn niemandem.

  5. Klicke auf  "Conectar agora".  Der Status muss GRÜN werden:
        Conectado a #kanalname

  6. (Optional) Hake  "Conectar automaticamente ao abrir o jogo"  an
     (beim Spielstart automatisch verbinden).

Die Nachrichten erscheinen im Fenster "Twitch World".


---------------------------------------------------------------------
 7. TEIL D - NUTZEN: DIE ZWEI ARTEN
---------------------------------------------------------------------

=== ART 1: IM PLUGIN-FENSTER ===
  * Tippe  /tw-chat  (ohne Text), um das Fenster zu öffnen oder zu
    schließen.
  * Ziehe das Fenster und die Ecken, um die Größe zu ändern.
  * Wenn du "Ler e também enviar" gewählt hast, tippe unten in das Feld
    und drücke die Eingabetaste. Hier musst du NICHT /tw-chat tippen.

=== ART 2: IM SPIELCHAT (in einem Tab) ===
Das Spiel erlaubt Plugins nicht, selbst Tabs anzulegen. Du legst also
einen an und sagst ihm, welchen Chat-"Kanal" er zeigt. Einmalig:

  1. TAB ANLEGEN: Klicke im Chatfenster des Spiels auf die Schaltfläche
     +  neben den Tabs und nenne ihn  Twitch.

  2. IM PLUGIN (/tw-chat > Config):
        - hake  "Mostrar as mensagens no chat do jogo (só você vê)"  an
          (Nachrichten im Spielchat zeigen, nur du siehst sie)
        - bei "Canal usado no chat do jogo" lasse  "Linkshell [8]
          (recomendado)".

  3. IM SPIEL: lege fest, welchen Kanal jeder Tab zeigt:
        - öffne  Character Configuration > Log Window Settings >
          Log Filters.  (Im Spiel stehen die Namen in der Sprache
          deines Spiels; achte auf die Nummer [8].)
        - wähle den Tab  "Twitch",  dann den Unter-Tab  "Chat".
        - Hake NUR  "Linkshell [8]"  an (alles andere in diesem Tab
          abwählen).
        - wähle nun den Tab  "General"  (und weitere, wenn du willst)
          und WÄHLE  "Linkshell [8]"  AB, damit die Nachrichten nicht an
          zwei Stellen erscheinen.

  4. Die Nachrichten erscheinen im Twitch-Tab so:
        [ABZEICHEN] Name disse: Nachricht
     Nur DU siehst das. Niemand sonst im Spiel.

  Zum SENDEN tippe im Spielchat:
        /tw-chat deine Nachricht
  (Tipp: Lege ein Makro mit fertigen Sätzen an, z. B. /tw-chat danke!)

FARBEN UND ABZEICHEN (in /tw-chat > Config > "Cores e destaques do
chat"):
  * jede Person erscheint in der Farbe, die sie auf Twitch gewählt hat.
    Im Spielchat ist die Farbe ANGENÄHERT (das Spiel hat nur wenige
    Farben).
  * Abzeichen vor dem Namen: [STREAMER] [MOD] [VIP] [SUB] [BOT]
  * Nachrichten, die dich erwähnen, erscheinen in GOLD
  * Bot-Nachrichten (Follower-Meldungen, Raids ...) erscheinen in
    Türkis
  * keine Nachricht wird ausgeblendet.


---------------------------------------------------------------------
 8. BEFEHLE
---------------------------------------------------------------------
   /tw-chat                   öffnet oder schließt das Fenster
   /tw-chat deine Nachricht   sendet die Nachricht an den Twitch-Chat
   /xlplugins                 Dalamud-Plugin-Verwaltung
   /xlsettings                Dalamud-Einstellungen


---------------------------------------------------------------------
 9. HÄUFIGE PROBLEME
---------------------------------------------------------------------
- Das Installationsprogramm zeigte "Leider fehlgeschlagen":
    1) Prüfe das Internet und starte das Programm erneut.
    2) Wenn es weiter nicht klappt, mache einen Screenshot des Fensters
       und sende ihn zusammen mit der Datei
       C:\Twitch World FF14\install-log.txt  in einem "Issue" auf der
       GitHub-Projektseite (Reiter Issues > New issue).

- Es meldete, Dalamud nicht zu finden: Starte das Spiel einmal über den
  XIVLauncher (mit aktiviertem Dalamud), beende es und starte das
  Installationsprogramm erneut.

- "Twitch World" erscheint nicht unter "Installed Dev Plugins": Prüfe,
  ob der Pfad aus Teil B stimmt und ob du auf + und "Save and Close"
  geklickt hast. Schließe dann das Spiel und öffne es neu.

- Das Symbol erscheint als "?": Schalte das Plugin aus und wieder an
  oder starte das Spiel neu.

- "Canal reconhecido" erscheint nicht: Schreibe nur den Kanalnamen.

- Der Status wird nicht grün: Klicke auf "Conectar" oder "Reconectar"
  und prüfe das Internet.

- Ich sehe keine Nachrichten: Prüfe, ob im Kanal überhaupt geschrieben
  wird.

- Nachrichten erscheinen im falschen Tab: Wiederhole Schritt 3 von
  Art 2 (Linkshell [8] nur im Twitch-Tab).

- Meine Nachricht wird nicht gesendet: Prüfe, ob du "Ler e também
  enviar" gewählt hast, ob Benutzername und Token stimmen, und denke
  daran, dass Nachrichten mit / ! oder Links abgelehnt werden. Zwischen
  zwei Nachrichten liegt eine Mindestpause von ~1,5 Sekunden.

- Das Plugin lädt nach einem Spiel-Patch nicht mehr: Starte das
  Installationsprogramm erneut (es bereitet das Plugin neu vor). Wenn
  es weiter fehlschlägt, hat sich Dalamud eventuell geändert und es
  wird eine neue Version nötig.


---------------------------------------------------------------------
 10. AKTUALISIEREN, EINSTELLUNGEN LÖSCHEN UND DEINSTALLIEREN
---------------------------------------------------------------------
AKTUALISIEREN / NEU INSTALLIEREN: Schließe das Spiel und starte das
Installationsprogramm erneut. Es macht alles neu und BEHÄLT deine
Einstellungen.

FALLS DU EINE ALTE VERSION in einem anderen Ordner hattest (z. B.
C:\TwitchWorld): Entferne in /xlsettings > Experimental den alten Pfad
(Papierkorb-Schaltfläche) und speichere, damit du nicht zwei Kopien
hast.

EINSTELLUNGEN LÖSCHEN (Kanal, Benutzername, Token): Lösche bei
geschlossenem Spiel die Datei
   %APPDATA%\XIVLauncher\pluginConfigs\TwitchWorld.json
(füge diese Adresse in die Adressleiste des Explorers ein).

DEINSTALLIEREN:
  1. Im Spiel: /xlsettings > Experimental > entferne den Pfad von
     TwitchWorld.dll (Papierkorb) > Save and Close.
  2. Schließe das Spiel.
  3. Lösche die zwei Verknüpfungen auf dem Desktop.
  4. Lösche den Ordner  C:\Twitch World FF14
  5. (Falls du einen Token benutzt hast) widerrufe auf der
     Twitch-Website unter Einstellungen > Verbindungen den Zugriff der
     App, zur Sicherheit.


---------------------------------------------------------------------
 Twitch World FF14 - erstellt von Lirou.
 Inoffiziell. Keine Verbindung zu Square Enix, Twitch oder Dalamud.
---------------------------------------------------------------------
```
