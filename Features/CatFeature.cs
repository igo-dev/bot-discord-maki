using System;
using System.Net.Http;
using System.Threading.Tasks;
using DSharpPlus;
using Newtonsoft.Json;

namespace bot_discord.Features
{
    public class CatFeature
    {
        public static async Task Cat(DiscordClient s, DSharpPlus.EventArgs.MessageCreateEventArgs e)
        {
            string str = Uri.EscapeUriString(e.Message.Content.Substring(9));
            if(str == string.Empty)
                await e.Message.RespondAsync($"É assim que se usa este comando:\n cat hello");
            
            else
            using (HttpClient httpClient = new HttpClient())
            {
                string response = await httpClient.GetStringAsync($"https://cataas.com/cat?json=true");
                string catId = JsonConvert.DeserializeObject<dynamic>(response).Property("url").Value;
                await e.Message.RespondAsync($"https://cataas.com{catId}/says/{str}?width=300");
            };
        }
    }
}