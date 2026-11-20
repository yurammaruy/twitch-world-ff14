# Twitch World FF14

**English** · [Português](README.pt-BR.md) · [日本語](README.ja.md) · [Deutsch](README.de.md) · [Français](README.fr.md)

<p align="center"><img src="assets/icon.png" width="128" alt="Twitch World FF14"></p>

> Read and reply to any Twitch chat inside Final Fantasy XIV — a Dalamud plugin you install with just a link.

**Twitch World** shows the chat of any Twitch channel *inside* the game (in its own window and/or in a tab of the FFXIV chat, with each person's color and MOD / VIP / SUB badges) and lets you answer without leaving the game. It comes **clean**: no channel and no account configured. Made for streamers, mods and viewers who play FFXIV.

## Install with just the link

No installer, no download, no .NET. You paste **one address** into Dalamud and install Twitch World from the normal plugin list. Updates arrive on their own. It works anywhere XIVLauncher + Dalamud work (Windows, Linux, macOS).

```text
https://raw.githubusercontent.com/yurammaruy/twitch-world-ff14/main/repo.json
```

1. In the game chat box, type `/xlsettings` and press Enter. The *Dalamud Settings* window opens.
2. In the list on the left click **Experimental**.
3. Scroll to **Custom Plugin Repositories**.
4. Click the empty text box and paste this address with **Ctrl + V**:
5. Click the **+** button on the right. The address appears in the list.
6. Make sure the small **checkbox** next to the address is ticked.
7. Click **Save and Close** at the bottom.
8. Type `/xlplugins` and press Enter. The plugin installer opens.
9. Click **All Plugins** in the menu on the left.
10. In the search box type `Twitch World`.
11. Click the **Install** button. Wait a few seconds.
12. Find **Twitch World** in **Installed Plugins** and check that its switch is ON. You should see the icon, the version and **by Lirou**.
13. Type `/tw-chat` in the game chat. The "Twitch World" window opens.

> Tip: if Ctrl+V pastes nothing, copy the address again from the gray box above (use the copy button on its top-right corner).

## Features

- Live Twitch chat in a window **and/or** in a game chat tab (any Linkshell or Cross-world Linkshell, 1–8, explained in the guide)
- Twitch name colors (approximated to the game's palette) and [STREAMER] [MOD] [VIP] [SUB] [BOT] badges
- Messages that mention you are highlighted in gold; bot alerts in teal
- Read-only mode needs **no account and no token**; send with `/tw-chat your message`
- Blocks bot commands (`/` and `!`), emojis, emotes and links; one chat at a time; **no message is hidden**
- Step-by-step guide for non-programmers in **5 languages** (English, 日本語, Deutsch, Français, Português)

## Full step-by-step guide

📖 **[English – full step-by-step guide](docs/GUIDE.EN.md)** · [Português (Brasil)](docs/GUIDE.PT.md) · [日本語](docs/GUIDE.JA.md) · [Deutsch](docs/GUIDE.DE.md) · [Français](docs/GUIDE.FR.md)

## Important

- Dalamud plugins are **not allowed** by Square Enix's terms of service. This plugin only reads/writes text and automates nothing in the game, but the risk of using plugins exists — use at your own risk.
- Unofficial project. Not affiliated with Square Enix, Twitch or Dalamud. "Twitch" and "Final Fantasy" belong to their owners.
- The Twitch token (only needed to *send* messages) is like a password. Never share it.

## Help / bugs

Open an [Issue](../../issues/new/choose) and describe the step where it failed (never post your Twitch token).

---

**Keywords:** Final Fantasy XIV, FFXIV, FF14, Dalamud plugin, XIVLauncher, Twitch chat in game, Twitch chat overlay, streamer tool, Linkshell chat tab, 해외 / 日本語 / Deutsch / Français / Português.

MIT License · © 2026 Lirou
