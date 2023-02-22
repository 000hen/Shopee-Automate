using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using JNogueira.Discord.Webhook.Client;

namespace Shopee_Automate
{
    class DiscordWebhooker
    {
        public static string DiscordUserName = "Shopee-Automate";
        public static int DiscordEmbedColor = 0x276fff;

        private DiscordWebhookClient _client;

        public DiscordWebhooker(string? webhookURL)
        {
            if (webhookURL == null && Util.CheckDiscordWebhookFile()) webhookURL = Util.GetDiscordWebhookInfo();
            else if (webhookURL == null && !Util.CheckDiscordWebhookFile()) throw new ArgumentException("webhookURL cannot be null if there didn't have discordhook file.");
            _client = new DiscordWebhookClient(webhookURL);
        }

        public async Task SendTest()
        {
            await SendEmbed(new DiscordMessageEmbed(
                DiscordUserName,
                description: "您發送了測試用訊息!",
                color: DiscordEmbedColor
            ));
        }

        public async Task SendEmbed(DiscordMessageEmbed embed)
        {
            await _client.SendToDiscord(new DiscordMessage(
                username: DiscordUserName,
                embeds: new[] { embed }
            ));
        }
    }
}
