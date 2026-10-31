# Twitch World FF14

[English](README.md) · [Português](README.pt-BR.md) · [日本語](README.ja.md) · **Deutsch** · [Français](README.fr.md)

<p align="center"><img src="assets/icon.png" width="128" alt="Twitch World FF14"></p>

> Twitch-Chat in Final Fantasy XIV lesen und beantworten – ein Dalamud-Plugin mit Ein-Datei-Installer für Nicht-Programmierer.

**Twitch World** zeigt den Chat jedes Twitch-Kanals *im* Spiel (in einem eigenen Fenster und/oder in einem Tab des FFXIV-Chats, mit der Farbe jeder Person und MOD- / VIP- / SUB-Abzeichen) und lässt dich antworten, ohne das Spiel zu verlassen. Es kommt **leer**: kein Kanal, kein Konto eingerichtet. Für Streamer, Moderatoren und Zuschauer, die FFXIV spielen.

## Download

**[⬇ Installer herunterladen (neuestes Release)](../../releases/latest)**

## Funktionen

- Live-Twitch-Chat im Fenster **und/oder** in einem Spiel-Chat-Tab (Linkshell-[8]-Trick, im Guide erklärt)
- Twitch-Namensfarben (an die Spielpalette angenähert) und Abzeichen [STREAMER] [MOD] [VIP] [SUB] [BOT]
- Nachrichten, die dich erwähnen, erscheinen golden; Bot-Meldungen in Türkis
- Nur-Lesen-Modus braucht **weder Konto noch Token**; Senden mit `/tw-chat deine Nachricht`
- Blockiert Bot-Befehle (`/` und `!`), Emojis, Emotes und Links; ein Chat gleichzeitig; **keine Nachricht wird versteckt**
- Installer für Laien in **5 Sprachen** (English, 日本語, Deutsch, Français, Português) mit Schritt-für-Schritt-Anleitung

## Schnellinstallation (Windows 10/11)

1. Lade **TwitchWorldFF14-Setup.exe** vom [neuesten Release](../../releases/latest) herunter (Bereich *Assets*).
2. FFXIV schließen. Datei doppelklicken. Erscheint das blaue Fenster *„Der Computer wurde durch Windows geschützt“*: **Weitere Informationen → Trotzdem ausführen**.
3. Sprache wählen, bestätigen und warten, bis `[6/6]` erreicht ist (beim ersten Mal lädt es .NET, ca. 250 MB).
4. Im Spiel: `/xlsettings` → **Experimental** → **Dev Plugin Locations** → einfügen (Strg+V; Pfad ist bereits kopiert) → **+** → **Save and Close**.
5. `/xlplugins` → **Dev Tools** → **Installed Dev Plugins** → **Twitch World** einschalten → `/tw-chat` eingeben.

## Vollständige Schritt-für-Schritt-Anleitung

📖 **[Deutsch – full step-by-step guide](docs/GUIDE.DE.md)** · [English](docs/GUIDE.EN.md) · [Português (Brasil)](docs/GUIDE.PT.md) · [日本語](docs/GUIDE.JA.md) · [Français](docs/GUIDE.FR.md)

## Wichtig

- Dalamud-Plugins sind laut den Nutzungsbedingungen von Square Enix **nicht erlaubt**. Dieses Plugin liest/schreibt nur Text und automatisiert nichts im Spiel, dennoch besteht ein Risiko – Nutzung auf eigene Gefahr.
- Inoffizielles Projekt. Keine Verbindung zu Square Enix, Twitch oder Dalamud. „Twitch“ und „Final Fantasy“ gehören ihren Inhabern.
- Der Installer ist **nicht digital signiert**, daher können Windows/Virenscanner warnen. Der gesamte Quellcode liegt in diesem Repository; jedes Release nennt die SHA-256-Prüfsumme. Lade nur von dieser Seite herunter.
- Das Twitch-Token (nur zum *Senden* nötig) ist wie ein Passwort. Niemals weitergeben.

## Hilfe / Fehler

Eröffne ein [Issue](../../issues/new/choose) (`install-log.txt` anhängen, niemals dein Token).

---

**Schlagwörter:** Final Fantasy XIV, FFXIV, FF14, Dalamud-Plugin, XIVLauncher, Twitch-Chat im Spiel, Twitch-Chat-Overlay, Streamer-Tool, Linkshell-Chat-Tab.

MIT License · © 2026 Lirou
