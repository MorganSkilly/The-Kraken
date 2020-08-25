using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using HtmlAgilityPack;

namespace TheKrakenMonitor
{
    [Group("!k")]
    public class admincommands : ModuleBase<SocketCommandContext>
    {
        [Command("test")]
        public async Task help()
        {
            string serverList = "";

            foreach (SocketGuild guild in Context.Client.Guilds)
                serverList = serverList + guild.Name + "\n";

            EmbedBuilder embed = new EmbedBuilder();

            embed.AddField("Joined Servers", serverList)
                .WithFooter(footer => footer.Text = "The Kraken Monitor")
                .WithColor(Color.DarkPurple)
                .WithTitle("The Kraken Monitor: Joined Server List")
                .WithUrl("https://morgan.games/discord-bot/")
                .WithCurrentTimestamp()
                .Build();

            await ReplyAsync(null, false, embed.Build(), null);
        }
    }
}
