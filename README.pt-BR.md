# Twitch World FF14

[English](README.md) · **Português** · [日本語](README.ja.md) · [Deutsch](README.de.md) · [Français](README.fr.md)

<p align="center"><img src="assets/icon.png" width="128" alt="Twitch World FF14"></p>

> Leia e responda qualquer chat da Twitch dentro do Final Fantasy XIV — plugin Dalamud que você instala só com um link.

O **Twitch World** mostra o chat de qualquer canal da Twitch *dentro* do jogo (em janela própria e/ou numa aba do chat do FFXIV, com a cor de cada pessoa e selos MOD / VIP / SUB) e deixa você responder sem sair do jogo. Já vem **limpo**: nenhum canal ou conta configurados. Feito para streamers, moderadores e espectadores que jogam FFXIV.

## Instalar só com o link

Sem instalador, sem baixar nada, sem .NET. Você cola **um endereço** no Dalamud e instala o Twitch World pela lista normal de plugins. As atualizações chegam sozinhas. Funciona onde o XIVLauncher + Dalamud funcionam (Windows, Linux, macOS).

```text
https://raw.githubusercontent.com/yurammaruy/twitch-world-ff14/main/repo.json
```

1. Na caixa de chat do jogo, digite `/xlsettings` e aperte Enter. Abre a janela *Dalamud Settings*.
2. Na lista da esquerda, clique em **Experimental**.
3. Role até **Custom Plugin Repositories**.
4. Clique na caixa de texto vazia e cole este endereço com **Ctrl + V**:
5. Clique no botão **+** à direita. O endereço aparece na lista.
6. Confira que a **caixinha** ao lado do endereço está marcada.
7. Clique em **Save and Close** no final.
8. Digite `/xlplugins` e aperte Enter. Abre o instalador de plugins.
9. Clique em **All Plugins** no menu da esquerda.
10. Na caixa de busca digite `Twitch World`.
11. Clique no botão **Install**. Espere alguns segundos.
12. Procure **Twitch World** em **Installed Plugins** e confira que a chavinha está LIGADA. Você deve ver o ícone, a versão e **by Lirou**.
13. Digite `/tw-chat` no chat do jogo. A janela "Twitch World" abre.

> Dica: se o Ctrl+V não colar nada, copie o endereço de novo na caixa cinza acima (botão de copiar no canto direito).

## Recursos

- Chat da Twitch ao vivo em janela **e/ou** numa aba do chat do jogo (qualquer Linkshell ou Cross-world Linkshell de 1 a 8, explicado no guia)
- Cores dos nomes da Twitch (aproximadas à paleta do jogo) e selos [STREAMER] [MOD] [VIP] [SUB] [BOT]
- Mensagens que citam você ficam douradas; avisos de bots ficam em verde-água
- Modo só leitura **não precisa de conta nem token**; para enviar use `/tw-chat sua mensagem`
- Bloqueia comandos de bot (`/` e `!`), emojis, emotes e links; um chat por vez; **nenhuma mensagem é ocultada**
- Guia passo a passo para leigos em **5 idiomas** (English, 日本語, Deutsch, Français, Português)

## Guia completo passo a passo

📖 **[Português (Brasil) – full step-by-step guide](docs/GUIDE.PT.md)** · [English](docs/GUIDE.EN.md) · [日本語](docs/GUIDE.JA.md) · [Deutsch](docs/GUIDE.DE.md) · [Français](docs/GUIDE.FR.md)

## Importante

- Plugins do Dalamud **não são permitidos** pelos termos de serviço da Square Enix. Este plugin só lê/escreve texto e não automatiza nada no jogo, mas o risco de usar plugins existe — use por sua conta e risco.
- Projeto não oficial. Sem relação com Square Enix, Twitch ou Dalamud. "Twitch" e "Final Fantasy" pertencem aos seus donos.
- O token da Twitch (só necessário para *enviar* mensagens) é como uma senha. Nunca compartilhe.

## Ajuda / problemas

Abra uma [Issue](../../issues/new/choose) descrevendo em que passo falhou (nunca publique o seu token).

---

**Palavras-chave:** Final Fantasy XIV, FFXIV, FF14, plugin Dalamud em português, XIVLauncher, chat da Twitch no jogo, overlay de chat Twitch, ferramenta para streamer, aba de chat Linkshell.

MIT License · © 2026 Lirou
