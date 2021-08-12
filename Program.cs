using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using bot_discord.Handlers;
using Microsoft.Extensions.Logging;

namespace bot_discord
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
            
        }
        public static async Task MainAsync()
        {
            var discordClient = await CreateDiscordClient();

            discordClient.MessageCreated += MessageCreatedHandler.MessageCreated;
            
            await Task.Delay(-1);
        }
        static async Task<DiscordClient> CreateDiscordClient()
        {
            var discord = new DiscordClient(new DiscordConfiguration() 
            {
                Token = Environment.GetEnvironmentVariable("BOT_TOKEN"),
                TokenType = TokenType.Bot,
            });

            DiscordActivity discordActivity = new("maki help", ActivityType.Playing);
            
            await discord.ConnectAsync(discordActivity);
            return discord;
        }

    }
}
