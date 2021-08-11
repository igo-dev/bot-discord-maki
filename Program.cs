using System;
using System.Threading.Tasks;
using DSharpPlus;

namespace bot_discord
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
            Console.Read();
        }
        static async Task MainAsync()
        {
            var discordClient = await CreateDiscordClient();

                discordClient.MessageCreated += async (s, e) => 
            {
                if(e.Message.Content.ToLower().Contains("ping"))
                    await e.Message.RespondAsync("pong!");
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
