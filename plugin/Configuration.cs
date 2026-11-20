using System;
using Dalamud.Configuration;

namespace TwitchWorld;

[Serializable]
public class Configuration : IPluginConfiguration
{
    public int Version { get; set; } = 0;

    // Link do chat (ou so o nome do canal)
    public string ChannelLink { get; set; } = "";

    // false = so ler | true = ler e tambem enviar
    public bool Interactive { get; set; } = false;

    // Necessarios apenas para enviar mensagens
    public string TwitchLogin { get; set; } = "";
    public string OAuthToken { get; set; } = "";

    public bool AutoConnect { get; set; } = false;

    // Mostrar tambem as mensagens no chat normal do jogo
    public bool EchoToGameChat { get; set; } = false;

    // (Antigo) indice da lista de canais das versoes 1.0/1.1. So serve para migrar a escolha antiga.
    public int GameChatChannel { get; set; } = 0;

    // Canal do chat do jogo onde as mensagens aparecem (valor de XivChatType). -1 = ainda nao escolhido
    // (usa a escolha antiga acima; se for instalacao nova, Linkshell [8]).
    public int GameChatChannelType { get; set; } = -1;

    // ----- Cores e destaques -----

    // Mostra [MOD] [VIP] [SUB] [STREAMER] [BOT] antes do nome
    public bool ShowBadges { get; set; } = true;

    // Usa a cor que cada pessoa escolheu na Twitch
    public bool ColorizeNames { get; set; } = true;

    // Mensagens que citam voce ficam douradas
    public bool HighlightMentions { get; set; } = true;

    // Mensagens de bots (avisos de seguidor, raid, etc.) ficam destacadas
    public bool HighlightBots { get; set; } = true;

    public string BotNames { get; set; } = "nightbot,streamelements,streamlabs,moobot,fossabot,wizebot,sery_bot";

    // Outros nomes para destacar, alem do seu usuario da Twitch
    public string ExtraHighlightNames { get; set; } = "";

    public void Save() => Plugin.PluginInterface.SavePluginConfig(this);
}
