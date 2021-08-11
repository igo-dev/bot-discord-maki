using System.Threading.Tasks;
using DSharpPlus;

namespace bot_discord.Features
{
    public class PingPongFeature
    {
        public static async Task Ping(DiscordClient s, DSharpPlus.EventArgs.MessageCreateEventArgs e)
        {
            await e.Message.DeleteAsync();
            await e.Message.RespondAsync("pong!");
        }
        
    }
}