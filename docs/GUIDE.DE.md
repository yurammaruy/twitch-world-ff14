# Twitch World FF14 · Mit dem GitHub-Link installieren – vollständige Anleitung

[← README](../README.de.md)

[English](GUIDE.EN.md) · [Português](GUIDE.PT.md) · [日本語](GUIDE.JA.md) · **Deutsch** · [Français](GUIDE.FR.md)

> Kein Installer, kein Download, kein .NET. Du fügst **eine Adresse** in Dalamud ein und installierst Twitch World über die normale Plugin-Liste. Updates kommen automatisch. Funktioniert überall, wo XIVLauncher + Dalamud laufen (Windows, Linux, macOS).

## Bevor du anfängst

- Final Fantasy XIV mindestens einmal über den **XIVLauncher mit aktiviertem Dalamud** gestartet (wenn du schon Plugins nutzt, hast du das).
- Eine Internetverbindung.
- Falls du Twitch World früher mit der `.exe` installiert hast, mache zuerst **Schritt 0**.

## Wichtig

- Dalamud-Plugins sind laut den Nutzungsbedingungen von Square Enix **nicht erlaubt**. Dieses Plugin liest/schreibt nur Text und automatisiert nichts im Spiel, dennoch besteht ein Risiko. Nutzung auf eigene Gefahr.
- Inoffizielles Projekt, keine Verbindung zu Square Enix, Twitch oder Dalamud.
- Ein „Token“ (Teil C) ist wie ein Passwort. Zeige es niemandem.
- Dalamud kennzeichnet das als *Drittanbieter-Repository*. Das ist normal: Den Quellcode kann jeder in diesem GitHub-Projekt lesen.

## Schritt 0 – Nur falls du früher die .exe benutzt hast

1. Tippe `/xlsettings`, drücke Enter und klicke auf **Experimental**.
2. Klicke bei **Dev Plugin Locations** auf das Papierkorb-Symbol neben dem Pfad zu `TwitchWorld.dll`.
3. Klicke auf **Save and Close**. Schließe das Spiel und starte es neu.
4. (Den Ordner `C:\Twitch World FF14` kannst du später löschen. Deine Einstellungen bleiben erhalten.)

## Teil A – GitHub-Link in Dalamud hinzufügen (einmalig)

1. Tippe im Spielchat `/xlsettings` und drücke Enter. Das Fenster *Dalamud Settings* öffnet sich.
2. Klicke links in der Liste auf **Experimental**.
3. Scrolle zu **Custom Plugin Repositories**.
4. Klicke in das leere Textfeld und füge diese Adresse mit **Strg + V** ein:

   ```text
   https://raw.githubusercontent.com/yurammaruy/twitch-world-ff14/main/repo.json
   ```

5. Klicke rechts auf die Schaltfläche **+**. Die Adresse erscheint in der Liste.
6. Prüfe, dass das kleine **Kästchen** neben der Adresse angehakt ist.
7. Klicke unten auf **Save and Close**.

> Tipp: Wenn Strg+V nichts einfügt, kopiere die Adresse aus dem grauen Kasten oben erneut (Kopieren-Symbol rechts oben).

## Teil B – Plugin aus der Liste installieren (einmalig)

1. Tippe `/xlplugins` und drücke Enter. Der Plugin-Installer öffnet sich.
2. Klicke links im Menü auf **All Plugins**.
3. Gib im Suchfeld `Twitch World` ein.
4. Klicke auf **Install** und warte einige Sekunden.
5. Suche **Twitch World** unter **Installed Plugins** und prüfe, dass der Schalter AN ist. Du solltest das Symbol, die Version und **by Lirou** sehen.
6. Tippe `/tw-chat` im Spielchat. Das Fenster „Twitch World“ öffnet sich.

> Fertig: Das Plugin ist installiert. Wähle jetzt den Chat aus (Teil C).

## Teil C, Teil D und Befehle

```text
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
```

> Tipp: In der Kanalliste des Plugins kannst du jede **Linkshell [1]–[8]**, jede **Cross-World-Linkshell [1]–[8]**, **Echo** oder **Sagen** wählen. Hake in den Log-Filtern nur den gewählten Kanal an, und nur im Twitch-Tab.

## Häufige Probleme (Installation per Link)

**„Twitch World“ erscheint nicht unter All Plugins**  
Prüfe, ob die Adresse vollständig eingefügt und das Kästchen angehakt ist (Teil A, Schritte 5–7). Klicke auf **Save and Close** und öffne `/xlplugins` neu. Sonst starte das Spiel neu.

**Die Adresse zeigt „404“ oder Dalamud meldet einen Repository-Fehler**  
Die Veröffentlichung ist eventuell noch nicht fertig (der erste Build dauert einige Minuten) oder das Projekt ist privat. Versuche es später oder eröffne ein Issue.

**Es erscheinen zwei „Twitch World“ oder das Plugin lässt sich nicht einschalten**  
Die alte `.exe`-Kopie ist noch als *Dev-Plugin* eingetragen. Mache **Schritt 0**, starte das Spiel neu und installiere erneut.

**Das Symbol ist ein „?“**  
Plugin aus- und wieder einschalten oder das Spiel neu starten.

**Nach einem Spiel-Patch funktioniert es nicht mehr**  
Dalamud aktualisiert sich nach Patches; warte auf das Plugin-Update (unter *Updates* in `/xlplugins`). Hilft das nicht, eröffne ein Issue auf GitHub.

**Alles andere**  
Eröffne ein Issue in diesem GitHub-Projekt und beschreibe den Schritt, an dem es scheitert. Poste niemals dein Twitch-Token.

## Aktualisieren, Einstellungen löschen und deinstallieren

- **Aktualisieren:** automatisch. Öffne `/xlplugins` → **Installed Plugins** → **Update**, sobald eine neue Version angezeigt wird.
- **Einstellungen löschen** (Kanal, Benutzername, Token): Lösche bei geschlossenem Spiel `%APPDATA%\XIVLauncher\pluginConfigs\TwitchWorld.json` (in die Adressleiste des Explorers einfügen).
- **Deinstallieren:** `/xlplugins` → **Installed Plugins** → Twitch World → **Delete**. Danach `/xlsettings` → Experimental → Adresse unter Custom Plugin Repositories entfernen (Papierkorb) → Save and Close.
- Falls du ein Token genutzt hast, widerrufe den Zugriff der App auf der Twitch-Website (Einstellungen → Verbindungen).

---

Unofficial · MIT License · © 2026 Lirou
