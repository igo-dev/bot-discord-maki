using System;
using System.Threading.Tasks;
using DSharpPlus;
using bot_discord.Features;
using DSharpPlus.EventArgs;

namespace bot_discord
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
            Console.Read();
            
        }
        public static async Task MainAsync()
        {
            var discordClient = await CreateDiscordClient();

            discordClient.MessageCreated += async (s, e) => 
            {
                if(e.Message.Content.ToLower().StartsWith("maki ping"))
                    await PingPongFeature.Ping(s, e);

                else if(e.Message.Content.ToLower().StartsWith("maki cat "))
                    await CatFeature.Cat(s, e);

                else if(e.Message.Content.ToLower().StartsWith("maki help"))
                    await HelpFeature.Help(s, e);
            };
        }

        static async Task<DiscordClient> CreateDiscordClient()
        {
            var discord = new DiscordClient(new DiscordConfiguration() 
            {
                Token = Environment.GetEnvironmentVariable("BOT_TOKEN"),
                TokenType = TokenType.Bot
            });
            
            await discord.ConnectAsync();
            return discord;
        }

    }
}
