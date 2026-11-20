# Twitch World FF14 · Install with the GitHub link – complete guide

[← README](../README.md)

**English** · [Português](GUIDE.PT.md) · [日本語](GUIDE.JA.md) · [Deutsch](GUIDE.DE.md) · [Français](GUIDE.FR.md)

> No installer, no download, no .NET. You paste **one address** into Dalamud and install Twitch World from the normal plugin list. Updates arrive on their own. It works anywhere XIVLauncher + Dalamud work (Windows, Linux, macOS).

## Before you start

- Final Fantasy XIV launched through **XIVLauncher with Dalamud turned on** at least once (if you already use plugins, you have this).
- An internet connection.
- If you installed Twitch World with the `.exe` before, do **Step 0** below first.

## Important

- Dalamud plugins are **not allowed** by Square Enix's terms of service. This plugin only reads and writes text and automates nothing in the game, but the risk exists. Use at your own risk.
- Unofficial project, not related to Square Enix, Twitch or Dalamud.
- A "token" (Part C) works like a password. Never show it to anyone.
- Dalamud will mark this as a *third-party repository*. That is expected: anyone can read the source code in this GitHub project.

## Step 0 – Only if you used the .exe before

1. Type `/xlsettings` and press Enter, then click **Experimental**.
2. In **Dev Plugin Locations**, click the trash icon next to the `TwitchWorld.dll` path.
3. Click **Save and Close**. Close the game and open it again.
4. (You can delete the folder `C:\Twitch World FF14` later. Your settings are kept.)

## Part A – Add the GitHub link to Dalamud (once)

1. In the game chat box, type `/xlsettings` and press Enter. The *Dalamud Settings* window opens.
2. In the list on the left click **Experimental**.
3. Scroll to **Custom Plugin Repositories**.
4. Click the empty text box and paste this address with **Ctrl + V**:

   ```text
   https://raw.githubusercontent.com/yurammaruy/twitch-world-ff14/main/repo.json
   ```

5. Click the **+** button on the right. The address appears in the list.
6. Make sure the small **checkbox** next to the address is ticked.
7. Click **Save and Close** at the bottom.

> Tip: if Ctrl+V pastes nothing, copy the address again from the gray box above (use the copy button on its top-right corner).

## Part B – Install the plugin from the list (once)

1. Type `/xlplugins` and press Enter. The plugin installer opens.
2. Click **All Plugins** in the menu on the left.
3. In the search box type `Twitch World`.
4. Click the **Install** button. Wait a few seconds.
5. Find **Twitch World** in **Installed Plugins** and check that its switch is ON. You should see the icon, the version and **by Lirou**.
6. Type `/tw-chat` in the game chat. The "Twitch World" window opens.

> Done: the plugin is installed. Now choose which chat to read (Part C).

## Parts C, D and the commands

```text
---------------------------------------------------------------------
 6. PART C - CONNECT TO A TWITCH CHAT
---------------------------------------------------------------------
The plugin comes CLEAN: no channel and no account configured.

Words you will see on the plugin's screen (it is in Portuguese):
   Config ......................... Settings
   Conectar / Conectar agora ...... Connect / Connect now
   Reconectar ..................... Reconnect
   Desconectar .................... Disconnect
   Só ler as mensagens do chat .... Only read the chat messages
   Ler e também enviar mensagens .. Read and also send messages
   Canal reconhecido .............. Channel recognized
   Conectado a #canal ............. Connected to #channel

  1. In the "Twitch World" window, click  Config.

  2. In  "1) Link do chat (ou só o nome do canal)"  write the channel.
     Any of these works:
        https://www.twitch.tv/channelname
        https://dashboard.twitch.tv/popout/u/channelname/stream-manager/chat
        channelname
     Below it you should see, in green:  "Canal reconhecido: channelname".

  3. In  "2) O que você quer fazer?"  choose ONE option:
        ( ) Só ler as mensagens do chat   (only read)
              -> simplest. NO account and NO token needed.
        ( ) Ler e também enviar mensagens (/tw-chat)   (read and send)
              -> needs step 4.

  4. (ONLY if you chose to send messages) Get a Twitch token:
        a) Open in your browser:  https://twitchtokengenerator.com
           (a well-known third-party site).
        b) Choose the option  "Bot Chat Token".
        c) Tick the permissions  chat:read  and  chat:edit  and
           authorize with YOUR Twitch account.
        d) Copy the  "Access Token"  (a long text).
        e) In the plugin, fill in:
             "Seu nome de usuário da Twitch" = your account name
             "Token de acesso" = the copied token (Ctrl+V)
     REMEMBER: the token is like a password. Show it to no one.

  5. Click  "Conectar agora".  The status should turn GREEN:
        Conectado a #channelname

  6. (Optional) Tick  "Conectar automaticamente ao abrir o jogo"
     (connect automatically when the game starts).

Messages appear in the "Twitch World" window.


---------------------------------------------------------------------
 7. PART D - USING IT: THE TWO WAYS
---------------------------------------------------------------------

=== WAY 1: IN THE PLUGIN WINDOW ===
  * Type  /tw-chat  (with no text) to open or close the window.
  * Drag the window and pull its corners to resize it.
  * If you chose "Ler e também enviar", type in the box at the bottom
    and press Enter. You do NOT need to type /tw-chat here.

=== WAY 2: INSIDE THE GAME CHAT (in a tab) ===
The game does not let a plugin create tabs on its own, so you create
one and tell it which chat "channel" to show. Do this once:

  1. CREATE THE TAB: in the game chat window click the  +  button next
     to the tabs and name it  Twitch.

  2. IN THE PLUGIN (/tw-chat > Config):
        - tick  "Mostrar as mensagens no chat do jogo (só você vê)"
          (show the messages in the game chat, only you see them)
        - under "Canal usado no chat do jogo" keep  "Linkshell [8]
          (recomendado)".

  3. IN THE GAME, choose which channel each tab shows:
        - open  Character Configuration > Log Window Settings >
          Log Filters.
        - select the  "Twitch"  tab, then the  "Chat"  sub-tab.
        - TICK only  "Linkshell [8]"  (untick the rest of that tab).
        - now select the  "General"  tab (and any others you like) and
          UNTICK  "Linkshell [8]",  so the messages do not show up in
          two places.

  4. The messages appear in the Twitch tab like this:
        [BADGES] Name disse: message
     Only YOU see this. Nobody else in the game does.

  To SEND, type in the game chat:
        /tw-chat your message
  (Tip: make a macro with ready-made phrases, e.g. /tw-chat thanks!)

COLORS AND BADGES (in /tw-chat > Config > "Cores e destaques do chat"):
  * each person appears in the color they chose on Twitch. In the game
    chat the color is APPROXIMATED (the game has few colors).
  * badges before the name: [STREAMER] [MOD] [VIP] [SUB] [BOT]
  * messages that mention you are shown in GOLD
  * bot messages (follower alerts, raids...) are shown in teal
  * no message is hidden.

---------------------------------------------------------------------
 8. COMMANDS
---------------------------------------------------------------------
   /tw-chat                  opens or closes the window
   /tw-chat your message     sends the message to the Twitch chat
   /xlplugins                Dalamud plugin manager
   /xlsettings               Dalamud settings
```

> Tip: in the plugin's channel list you can choose any **Linkshell [1]–[8]**, any **Cross-world Linkshell [1]–[8]**, **Echo** or **Say**. In Log Filters, tick only the channel you chose, and only in your Twitch tab.

## Common problems (installing with the link)

**"Twitch World" does not appear in All Plugins**  
Check that the address was pasted whole and that its checkbox is ticked (Part A, steps 5–7). Click **Save and Close**, then reopen `/xlplugins`. In `/xlplugins` you can also click the refresh/reload button if it exists in your Dalamud version, or restart the game.

**The address gives a "404" or Dalamud shows an error for the repository**  
The project owner may not have finished publishing it yet (the first build takes a few minutes) or the project is private. Try again later or open an Issue.

**Two "Twitch World" appear, or the plugin does not turn on**  
You still have the old `.exe` copy as a *dev plugin*. Do **Step 0**, restart the game and install again.

**The icon is a "?"**  
Switch the plugin off and on, or restart the game.

**The plugin stopped working after a game patch**  
Dalamud updates itself after patches; wait for the plugin update (it appears under *Updates* in `/xlplugins`). If it keeps failing, open an Issue on GitHub.

**Anything else**  
Open an Issue on this GitHub project and describe the step where it failed. Never post your Twitch token.

## Update, clear settings and uninstall

- **Update:** automatic. Open `/xlplugins` → **Installed Plugins** → **Update** when it shows a new version.
- **Clear settings** (channel, username, token): with the game closed, delete `%APPDATA%\XIVLauncher\pluginConfigs\TwitchWorld.json` (paste that into the File Explorer address bar).
- **Uninstall:** `/xlplugins` → **Installed Plugins** → Twitch World → **Delete**. Then `/xlsettings` → Experimental → remove the address under Custom Plugin Repositories (trash icon) → Save and Close.
- If you used a token, revoke the app's access on the Twitch website (Settings → Connections).

---

Unofficial · MIT License · © 2026 Lirou
