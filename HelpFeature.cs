using System.Threading.Tasks;
using DSharpPlus;

namespace bot_discord
{
    public class HelpFeature
    {
        public static async Task Help(DiscordClient s, DSharpPlus.EventArgs.MessageCreateEventArgs e)
        {
            await e.Message.DeleteAsync();
            await e.Message.RespondAsync(
@"```
Lista de Comandos:

maki help -------------- Retorna uma lista de todos comandos disponiveis.
maki cat <texto> ------- Retorna uma imagem de gatinho aleatório com seu texto nela.
maki ping -------------- Retorna pong!
```");
        }
    }
}