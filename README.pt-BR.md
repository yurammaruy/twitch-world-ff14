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

## Token da Twitch (só para enviar mensagens)

**Você só precisa do token para ENVIAR mensagens.** Para apenas ler um chat não precisa de conta nem de token: pule esta seção. O token é um texto longo que funciona como uma senha: ele deixa o plugin escrever no chat como você. Você nunca entrega a sua senha da Twitch ao plugin.

1. No navegador, entre na Twitch com a conta com a qual quer conversar e abra o site **https://twitchtokengenerator.com** (um site conhecido que não é da Twitch nem deste projeto).
2. Escolha **Bot Chat Token** (a opção para robôs de chat). Se o site mostrar só uma lista personalizada, marque as permissões **chat:read** e **chat:edit**. Nada além disso é necessário.
3. Clique no botão para conectar com a Twitch. Uma página da Twitch pede permissão. Confira se é a conta certa e clique em **Authorize** (Autorizar). Resolva o captcha se pedir.
4. De volta ao site aparece um texto longo chamado **Access Token** (pode haver também *Refresh Token* e *Client ID*). Copie **somente o Access Token** (botão de copiar, ou selecione e aperte Ctrl+C).
5. No jogo, digite `/tw-chat` e clique em **Config**. … Clique em **Conectar agora**. O status fica VERDE: *Conectado a #canal como seu_usuario*.

📖 **[Tutorial completo do token](docs/GUIDE.PT.md#como-gerar-o-token-da-twitch)**

## Recursos

- Chat da Twitch ao vivo em janela **e/ou** numa aba do chat do jogo (qualquer Linkshell ou Cross-world Linkshell de 1 a 8, explicado no guia)
- Cores dos nomes da Twitch (aproximadas à paleta do jogo) e selos [STREAMER] [MOD] [VIP] [SUB] [BOT]
- **Alertas do canal**: raids, inscrições, presentes, bits, resgates de pontos e anúncios aparecem no chat em cores, com som de alerta opcional (botão para ligar/desligar na janela e nas Configurações). O som toca só para alertas e mensagens de bots, nunca no chat comum.
- Mensagens que citam você ficam douradas; avisos de bots ficam em verde-água
- Modo só leitura **não precisa de conta nem token**; para enviar use `/tw-chat sua mensagem`
- Bloqueia comandos de bot (`/` e `!`), emojis, emotes e links; um chat por vez; **nenhuma mensagem é ocultada**
- Guia passo a passo para leigos em **5 idiomas** (English, 日本語, Deutsch, Français, Português)

## Importante

- Plugins do Dalamud **não são permitidos** pelos termos de serviço da Square Enix. Este plugin só lê/escreve texto e não automatiza nada no jogo, mas o risco de usar plugins existe — use por sua conta e risco.
- Projeto não oficial. Sem relação com Square Enix, Twitch ou Dalamud. "Twitch" e "Final Fantasy" pertencem aos seus donos.
- O token da Twitch (só necessário para *enviar* mensagens) é como uma senha. Nunca compartilhe.

## Ajuda / problemas

Abra uma [Issue](../../issues/new/choose) descrevendo em que passo falhou (nunca publique o seu token).

---

**Palavras-chave:** Final Fantasy XIV, FFXIV, FF14, plugin Dalamud em português, XIVLauncher, chat da Twitch no jogo, overlay de chat Twitch, ferramenta para streamer, aba de chat Linkshell.

MIT License · © 2026 Lirou
