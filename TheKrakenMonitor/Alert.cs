using System;
using System.Collections.Generic;
using System.Text;
using Discord;

namespace TheKrakenMonitor
{
    class Alert
    {
        private ulong guild, channel;
        private string alertName, creator, sourceUrl, xPath, triggerCondition;
        public Alert(ulong guild, ulong channel, string alertName, string creator, string sourceUrl, string xPath, string triggerCondition)
        {
            this.guild = guild;
            this.channel = channel;
            this.alertName = alertName;
            this.creator = creator;
            this.sourceUrl = sourceUrl;
            this.xPath = xPath;
            this.triggerCondition = triggerCondition;
        }

        public EmbedBuilder info()
        {
            EmbedBuilder embed = new EmbedBuilder();

            embed.AddField("Alert Name", alertName, false)
                .WithFooter(footer => footer.Text = "The Kraken Monitor")
                .WithTitle("Alert Info")
                .WithUrl("https://twitter.com/Kraken_Bot")
                .WithCurrentTimestamp()
                .Build();
            embed.AddField("Creator", creator, false);
            embed.AddField("Guild ID", guild, false);
            embed.AddField("Channel ID", channel, false);
            embed.AddField("Source URL", sourceUrl, false);
            embed.AddField("Xpath Checked", xPath, false);
            embed.AddField("Trigger Condition", triggerCondition, false);

            return embed;
        }
    }
}
