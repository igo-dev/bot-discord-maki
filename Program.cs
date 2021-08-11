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
        }
        static async Task MainAsync()
        {
            var discord = new DiscordClient(new DiscordConfiguration() 
            {
                Token = Environment.GetEnvironmentVariable("BOT_TOKEN"),
                TokenType = TokenType.Bot
            });
            
            discord.MessageCreated += async (s, e) => 
            {
                if(e.Message.Content.ToLower().Contains("ping"))
                    await e.Message.RespondAsync("pong!");
            };

            await discord.ConnectAsync();
            await Task.Delay(-1);

        }
    }
}
