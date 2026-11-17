# Twitch World FF14

[English](README.md) · **Português** · [日本語](README.ja.md) · [Deutsch](README.de.md) · [Français](README.fr.md)

**Instalar:** 📦 com o instalador (.exe) – abaixo · 🔗 **[com o link do GitHub – guia completo](docs/INSTALL_GITHUB.PT.md)**

<p align="center"><img src="assets/icon.png" width="128" alt="Twitch World FF14"></p>

> Leia e responda qualquer chat da Twitch dentro do Final Fantasy XIV — plugin Dalamud com instalador de um arquivo só, feito para quem não é programador.

O **Twitch World** mostra o chat de qualquer canal da Twitch *dentro* do jogo (em janela própria e/ou numa aba do chat do FFXIV, com a cor de cada pessoa e selos MOD / VIP / SUB) e deixa você responder sem sair do jogo. Já vem **limpo**: nenhum canal ou conta configurados. Feito para streamers, moderadores e espectadores que jogam FFXIV.

## Baixar

**[⬇ Baixar o instalador (versão mais recente)](../../releases/tag/v1.0.0)**

## Recursos

- Chat da Twitch ao vivo em janela **e/ou** numa aba do chat do jogo (truque do Linkshell [8], explicado no guia)
- Cores dos nomes da Twitch (aproximadas à paleta do jogo) e selos [STREAMER] [MOD] [VIP] [SUB] [BOT]
- Mensagens que citam você ficam douradas; avisos de bots ficam em verde-água
- Modo só leitura **não precisa de conta nem token**; para enviar use `/tw-chat sua mensagem`
- Bloqueia comandos de bot (`/` e `!`), emojis, emotes e links; um chat por vez; **nenhuma mensagem é ocultada**
- Instalador para leigos em **5 idiomas** (English, 日本語, Deutsch, Français, Português) com guia passo a passo em cada um

## Instalação rápida (Windows 10/11)

1. Baixe o **TwitchWorldFF14-Setup.exe** na [última versão (Release)](../../releases/tag/v1.0.0), seção *Assets*.
2. Feche o FFXIV. Dê dois cliques no arquivo. Se o Windows mostrar a janela azul *"O Windows protegeu o computador"*: **Mais informações → Executar assim mesmo**.
3. Escolha o idioma, confirme e espere chegar em `[6/6]` (na primeira vez baixa o .NET, ~250 MB).
4. No jogo: `/xlsettings` → **Experimental** → **Dev Plugin Locations** → cole (Ctrl+V; o caminho já foi copiado) → **+** → **Save and Close**.
5. `/xlplugins` → **Dev Tools** → **Installed Dev Plugins** → ligue **Twitch World** → digite `/tw-chat`.

## Guia completo passo a passo

📖 **[Português (Brasil) – full step-by-step guide](docs/GUIDE.PT.md)** · [English](docs/GUIDE.EN.md) · [日本語](docs/GUIDE.JA.md) · [Deutsch](docs/GUIDE.DE.md) · [Français](docs/GUIDE.FR.md)

## Importante

- Plugins do Dalamud **não são permitidos** pelos termos de serviço da Square Enix. Este plugin só lê/escreve texto e não automatiza nada no jogo, mas o risco de usar plugins existe — use por sua conta e risco.
- Projeto não oficial. Sem relação com Square Enix, Twitch ou Dalamud. "Twitch" e "Final Fantasy" pertencem aos seus donos.
- O instalador **não tem assinatura digital**, então o Windows/antivírus pode avisar. Todo o código está neste repositório e cada versão traz o checksum SHA-256. Baixe somente desta página.
- O token da Twitch (só necessário para *enviar* mensagens) é como uma senha. Nunca compartilhe.

## Ajuda / problemas

Abra uma [Issue](../../issues/new/choose) (anexe o `install-log.txt`, nunca o seu token).

---

**Palavras-chave:** Final Fantasy XIV, FFXIV, FF14, plugin Dalamud em português, XIVLauncher, chat da Twitch no jogo, overlay de chat Twitch, ferramenta para streamer, aba de chat Linkshell.

MIT License · © 2026 Lirou
