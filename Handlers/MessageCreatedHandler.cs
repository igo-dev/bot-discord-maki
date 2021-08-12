using System.Threading.Tasks;
using bot_discord.Features;
using DSharpPlus;

namespace bot_discord.Handlers
{
    public class MessageCreatedHandler
    {
        public static async Task MessageCreated(DiscordClient s, DSharpPlus.EventArgs.MessageCreateEventArgs e)
        {
            if(e.Message.Content.ToLower().StartsWith("maki ping"))
                    await PingPongFeature.Ping(s, e);

                else if(e.Message.Content.ToLower().StartsWith("maki cat "))
                    await CatFeature.Cat(s, e);

                else if(e.Message.Content.ToLower().StartsWith("maki help"))
                    await HelpFeature.Help(s, e);
        }
    }
}