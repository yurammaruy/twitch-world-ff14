# Twitch World FF14

**English** · [Português](README.pt-BR.md) · [日本語](README.ja.md) · [Deutsch](README.de.md) · [Français](README.fr.md)

<p align="center"><img src="assets/icon.png" width="128" alt="Twitch World FF14"></p>

> Read and reply to any Twitch chat inside Final Fantasy XIV — a Dalamud plugin with a one-file Windows installer for non-programmers.

**Twitch World** shows the chat of any Twitch channel *inside* the game (in its own window and/or in a tab of the FFXIV chat, with each person's color and MOD / VIP / SUB badges) and lets you answer without leaving the game. It comes **clean**: no channel and no account configured. Made for streamers, mods and viewers who play FFXIV.

## Download

**[⬇ Download the installer (latest release)](../../releases/latest)**

## Features

- Live Twitch chat in a window **and/or** in a game chat tab (Linkshell [8] trick, explained in the guide)
- Twitch name colors (approximated to the game's palette) and [STREAMER] [MOD] [VIP] [SUB] [BOT] badges
- Messages that mention you are highlighted in gold; bot alerts in teal
- Read-only mode needs **no account and no token**; send with `/tw-chat your message`
- Blocks bot commands (`/` and `!`), emojis, emotes and links; one chat at a time; **no message is hidden**
- Installer for non-programmers in **5 languages** (English, 日本語, Deutsch, Français, Português) with a step-by-step guide in each

## Quick install (Windows 10/11)

1. Download **TwitchWorldFF14-Setup.exe** from the [latest release](../../releases/latest) (*Assets* section).
2. Close FFXIV. Double-click the file. If Windows shows a blue *"Windows protected your PC"* box: **More info → Run anyway**.
3. Choose your language, confirm, and wait for `[6/6]` (the first time it downloads .NET, ~250 MB).
4. In the game: `/xlsettings` → **Experimental** → **Dev Plugin Locations** → paste (Ctrl+V; already copied for you) → **+** → **Save and Close**.
5. `/xlplugins` → **Dev Tools** → **Installed Dev Plugins** → switch **Twitch World** ON → type `/tw-chat`.

## Full step-by-step guide

📖 **[English – full step-by-step guide](docs/GUIDE.EN.md)** · [Português (Brasil)](docs/GUIDE.PT.md) · [日本語](docs/GUIDE.JA.md) · [Deutsch](docs/GUIDE.DE.md) · [Français](docs/GUIDE.FR.md)

## Important

- Dalamud plugins are **not allowed** by Square Enix's terms of service. This plugin only reads/writes text and automates nothing in the game, but the risk of using plugins exists — use at your own risk.
- Unofficial project. Not affiliated with Square Enix, Twitch or Dalamud. "Twitch" and "Final Fantasy" belong to their owners.
- The installer is **not digitally signed**, so Windows/antivirus may warn. The source is all in this repository, and each release lists the SHA-256 checksum. Download only from this page.
- The Twitch token (only needed to *send* messages) is like a password. Never share it.

## Help / bugs

Open an [Issue](../../issues/new/choose) (attach `install-log.txt`, never your token).

---

**Keywords:** Final Fantasy XIV, FFXIV, FF14, Dalamud plugin, XIVLauncher, Twitch chat in game, Twitch chat overlay, streamer tool, Linkshell chat tab, 해외 / 日本語 / Deutsch / Français / Português.

MIT License · © 2026 Lirou
