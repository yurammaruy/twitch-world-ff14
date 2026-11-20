# Twitch World FF14 · Instalar com o link do GitHub – guia completo

[← README](../README.pt-BR.md)

[English](GUIDE.EN.md) · **Português** · [日本語](GUIDE.JA.md) · [Deutsch](GUIDE.DE.md) · [Français](GUIDE.FR.md)

> Sem instalador, sem baixar nada, sem .NET. Você cola **um endereço** no Dalamud e instala o Twitch World pela lista normal de plugins. As atualizações chegam sozinhas. Funciona onde o XIVLauncher + Dalamud funcionam (Windows, Linux, macOS).

## Antes de começar

- Final Fantasy XIV aberto pelo **XIVLauncher com o Dalamud ligado** pelo menos uma vez (se você já usa plugins, você tem isso).
- Conexão com a internet.
- Se você já instalou o Twitch World pelo `.exe`, faça primeiro o **Passo 0** abaixo.

## Importante

- Plugins do Dalamud **não são permitidos** pelos termos da Square Enix. Este plugin só lê e escreve texto e não automatiza nada no jogo, mas o risco existe. Use por sua conta e risco.
- Projeto não oficial, sem relação com Square Enix, Twitch ou Dalamud.
- O "token" (Parte C) é como uma senha. Nunca mostre a ninguém.
- O Dalamud vai marcar isto como *repositório de terceiros*. É normal: qualquer pessoa pode ler o código-fonte neste projeto do GitHub.

## Passo 0 – Só se você já usou o .exe

1. Digite `/xlsettings`, aperte Enter e clique em **Experimental**.
2. Em **Dev Plugin Locations**, clique na lixeira ao lado do caminho do `TwitchWorld.dll`.
3. Clique em **Save and Close**. Feche o jogo e abra de novo.
4. (Você pode apagar a pasta `C:\Twitch World FF14` depois. Suas configurações são mantidas.)

## Parte A – Adicionar o link do GitHub no Dalamud (uma vez)

1. Na caixa de chat do jogo, digite `/xlsettings` e aperte Enter. Abre a janela *Dalamud Settings*.
2. Na lista da esquerda, clique em **Experimental**.
3. Role até **Custom Plugin Repositories**.
4. Clique na caixa de texto vazia e cole este endereço com **Ctrl + V**:

   ```text
   https://raw.githubusercontent.com/yurammaruy/twitch-world-ff14/main/repo.json
   ```

5. Clique no botão **+** à direita. O endereço aparece na lista.
6. Confira que a **caixinha** ao lado do endereço está marcada.
7. Clique em **Save and Close** no final.

> Dica: se o Ctrl+V não colar nada, copie o endereço de novo na caixa cinza acima (botão de copiar no canto direito).

## Parte B – Instalar o plugin pela lista (uma vez)

1. Digite `/xlplugins` e aperte Enter. Abre o instalador de plugins.
2. Clique em **All Plugins** no menu da esquerda.
3. Na caixa de busca digite `Twitch World`.
4. Clique no botão **Install**. Espere alguns segundos.
5. Procure **Twitch World** em **Installed Plugins** e confira que a chavinha está LIGADA. Você deve ver o ícone, a versão e **by Lirou**.
6. Digite `/tw-chat` no chat do jogo. A janela "Twitch World" abre.

> Pronto: o plugin está instalado. Agora escolha qual chat ler (Parte C).

## Como gerar o token da Twitch

**Você só precisa do token para ENVIAR mensagens.** Para apenas ler um chat não precisa de conta nem de token: pule esta seção. O token é um texto longo que funciona como uma senha: ele deixa o plugin escrever no chat como você. Você nunca entrega a sua senha da Twitch ao plugin.

1. No navegador, entre na Twitch com a conta com a qual quer conversar e abra o site **https://twitchtokengenerator.com** (um site conhecido que não é da Twitch nem deste projeto).
2. Escolha **Bot Chat Token** (a opção para robôs de chat). Se o site mostrar só uma lista personalizada, marque as permissões **chat:read** e **chat:edit**. Nada além disso é necessário.
3. Clique no botão para conectar com a Twitch. Uma página da Twitch pede permissão. Confira se é a conta certa e clique em **Authorize** (Autorizar). Resolva o captcha se pedir.
4. De volta ao site aparece um texto longo chamado **Access Token** (pode haver também *Refresh Token* e *Client ID*). Copie **somente o Access Token** (botão de copiar, ou selecione e aperte Ctrl+C).
5. No jogo, digite `/tw-chat` e clique em **Config**.
6. Em "2) O que você quer fazer?" escolha **Ler e também enviar mensagens (/tw-chat)**.
7. Em "Seu nome de usuário da Twitch" digite o nome da mesma conta que você autorizou.
8. Clique na caixa "Token de acesso" e cole com **Ctrl + V**. Aparecem só bolinhas.
9. Clique em **Conectar agora**. O status fica VERDE: *Conectado a #canal como seu_usuario*.
10. Teste: digite algo na caixa de baixo da janela do plugin e aperte Enter, ou digite `/tw-chat olá` no chat do jogo.

### Mantenha em segurança

- Nunca mostre o token a ninguém e nunca publique prints da janela Config com ele visível.
- Se vazar, entre em **https://www.twitch.tv/settings/connections**, ache o aplicativo (o site do token) e clique em **Disconnect** (Desconectar). Depois gere um token novo.
- O token fica salvo em texto simples em `%APPDATA%\XIVLauncher\pluginConfigs\TwitchWorld.json`. Não compartilhe esse arquivo.

### Se não funcionar

**O status diz "Login authentication failed" ou as mensagens não são enviadas**  
O token foi copiado incompleto, é de outra conta ou expirou. Gere um novo e cole de novo. O usuário precisa ser o da mesma conta que autorizou.

**Há espaços ou caracteres estranhos**  
Selecione o token inteiro, copie de novo e cole num campo vazio. Não digite à mão.

**O site do token não abre**  
Desligue o bloqueador de anúncios para ele ou use outro navegador. O visual do site pode mudar com o tempo: procure a opção para robôs de chat / *Bot Chat Token*.

**Ler funciona, mas enviar não**  
Confira se escolheu "Ler e também enviar mensagens" e se usuário e token estão preenchidos.

## Partes C, D e comandos

```text
---------------------------------------------------------------------
 6. PARTE C - CONECTAR AO CHAT DE UMA TWITCH
---------------------------------------------------------------------
O plugin vem LIMPO: nenhum canal e nenhuma conta configurados.

Palavras que você vai ver na tela do plugin (está em português):
   Config ......................... Configurações
   Conectar / Conectar agora ...... Conectar
   Reconectar ..................... Reconectar
   Desconectar .................... Desconectar

  1. Na janela "Twitch World", clique em  Config.

  2. Em  "1) Link do chat (ou só o nome do canal)"  escreva o canal.
     Pode ser qualquer um destes jeitos:
        https://www.twitch.tv/nomedocanal
        https://dashboard.twitch.tv/popout/u/nomedocanal/stream-manager/chat
        nomedocanal
     Abaixo deve aparecer em verde:  "Canal reconhecido: nomedocanal".

  3. Em  "2) O que você quer fazer?"  escolha UMA opção:
        ( ) Só ler as mensagens do chat
              -> mais simples. NÃO precisa de conta nem de token.
        ( ) Ler e também enviar mensagens (/tw-chat)
              -> precisa do passo 4.

  4. (SÓ se escolheu enviar mensagens) Pegue um token da Twitch:
        a) Abra no navegador:  https://twitchtokengenerator.com
           (site de terceiros bastante conhecido).
        b) Escolha a opção  "Bot Chat Token".
        c) Marque as permissões  chat:read  e  chat:edit  e autorize
           com a SUA conta da Twitch.
        d) Copie o  "Access Token"  (um texto longo).
        e) No plugin, preencha:
             "Seu nome de usuário da Twitch" = o nome da sua conta
             "Token de acesso" = o token copiado (Ctrl+V)
     LEMBRE: o token é como uma senha. Não mostre a ninguém.

  5. Clique em  "Conectar agora".  O status deve ficar VERDE:
        Conectado a #nomedocanal

  6. (Opcional) Marque  "Conectar automaticamente ao abrir o jogo".

As mensagens aparecem na janela "Twitch World".


---------------------------------------------------------------------
 7. PARTE D - USAR: AS DUAS FORMAS
---------------------------------------------------------------------

=== FORMA 1: NA JANELA DO PLUGIN ===
  * Digite  /tw-chat  (sem texto) para abrir ou fechar a janela.
  * Arraste a janela e puxe os cantos para mudar o tamanho.
  * Se escolheu "Ler e também enviar", escreva na caixa de baixo e
    aperte Enter. Aqui NÃO precisa digitar /tw-chat.

=== FORMA 2: DENTRO DO CHAT DO JOGO (numa aba) ===
O jogo não deixa um plugin criar abas sozinho, então você cria uma e
diz qual "canal" de chat ela mostra. Faça isto uma vez:

  1. CRIAR A ABA: na janela de chat do jogo clique no botão  +  ao
     lado das abas e dê o nome  Twitch.

  2. NO PLUGIN (/tw-chat > Config):
        - marque  "Mostrar as mensagens no chat do jogo (só você vê)"
        - em "Canal usado no chat do jogo" deixe  "Linkshell [8]
          (recomendado)".

  3. NO JOGO, escolha qual canal cada aba mostra:
        - abra  Character Configuration (Configurações do Personagem)
          > Log Window Settings > Log Filters  (Filtros do Log).
        - escolha a aba  "Twitch",  sub-aba  "Chat".
        - MARQUE só  "Linkshell [8]"  (desmarque o resto dessa aba).
        - agora escolha a aba  "General"  (e as outras que quiser) e
          DESMARQUE  "Linkshell [8]",  para as mensagens não aparecerem
          em dois lugares.
        (Os nomes no seu jogo aparecem no idioma do seu jogo. Procure
        o número [8].)

  4. As mensagens aparecem na aba Twitch assim:
        [SELOS] Nome disse: mensagem
     Só VOCÊ vê isso. Ninguém no jogo vê.

  Para ENVIAR, digite no chat do jogo:
        /tw-chat sua mensagem
  (Dica: crie uma macro com frases prontas, ex: /tw-chat obrigado!)

CORES E SELOS (em /tw-chat > Config > "Cores e destaques do chat"):
  * cada pessoa aparece com a cor que escolheu na Twitch. No chat do
    jogo a cor é APROXIMADA (o jogo tem poucas cores).
  * selos antes do nome: [STREAMER] [MOD] [VIP] [SUB] [BOT]
  * mensagens que citam você ficam em DOURADO
  * mensagens de bots (avisos de seguidor, raid...) ficam em verde-água
  * nenhuma mensagem é escondida.

---------------------------------------------------------------------
 8. COMANDOS
---------------------------------------------------------------------
   /tw-chat                  abre ou fecha a janela
   /tw-chat sua mensagem     envia a mensagem para o chat da Twitch
   /xlplugins                gerenciador de plugins do Dalamud
   /xlsettings               configurações do Dalamud
```

> Dica: na lista de canais do plugin você pode escolher qualquer **Linkshell [1]–[8]**, qualquer **Cross-world Linkshell [1]–[8]**, **Echo** ou **Falar**. Nos Filtros de Log, marque só o canal que você escolheu, e só na sua aba Twitch.

## Problemas comuns (instalação pelo link)

**"Twitch World" não aparece em All Plugins**  
Confira se o endereço foi colado inteiro e se a caixinha está marcada (Parte A, passos 5–7). Clique em **Save and Close** e abra `/xlplugins` de novo. Se não resolver, reinicie o jogo.

**O endereço dá "404" ou o Dalamud mostra erro no repositório**  
O dono do projeto pode ainda não ter terminado de publicar (o primeiro build leva alguns minutos) ou o projeto está privado. Tente mais tarde ou abra uma Issue.

**Aparecem dois "Twitch World" ou o plugin não liga**  
Você ainda tem a cópia antiga do `.exe` como *dev plugin*. Faça o **Passo 0**, reinicie o jogo e instale de novo.

**O ícone aparece como "?"**  
Desligue e ligue o plugin, ou reinicie o jogo.

**O plugin parou depois de um patch do jogo**  
O Dalamud se atualiza após os patches; espere a atualização do plugin (aparece em *Updates* no `/xlplugins`). Se continuar falhando, abra uma Issue no GitHub.

**Qualquer outra coisa**  
Abra uma Issue neste projeto do GitHub e descreva em que passo falhou. Nunca publique seu token da Twitch.

## Atualizar, apagar configurações e desinstalar

- **Atualizar:** automático. Abra `/xlplugins` → **Installed Plugins** → **Update** quando aparecer versão nova.
- **Apagar as configurações** (canal, usuário, token): com o jogo fechado, apague `%APPDATA%\XIVLauncher\pluginConfigs\TwitchWorld.json` (cole isso na barra de endereço do Explorador de Arquivos).
- **Desinstalar:** `/xlplugins` → **Installed Plugins** → Twitch World → **Delete**. Depois `/xlsettings` → Experimental → remova o endereço em Custom Plugin Repositories (lixeira) → Save and Close.
- Se usou token, revogue o acesso do app no site da Twitch (Configurações → Conexões).

---

Unofficial · MIT License · © 2026 Lirou
