using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;

namespace Shopee_Automate.Forms
{
    public partial class DiscordWebhookSetup : Form
    {
        private DiscordWebhooker _discordWebhook;

        public DiscordWebhookSetup()
        {
            InitializeComponent();

            if (Util.CheckDiscordWebhookFile()) this.webhookInput.Text = Util.GetDiscordWebhookInfo();
            if (this.webhookInput.Text.Trim().Length == 0 )
            {
                this.sendTestMessage.Enabled = false;
            }
        }

        private async void sendTestMessage_Click(object sender, EventArgs e)
        {
            try
            {
                _discordWebhook = new DiscordWebhooker(this.webhookInput.Text);
                await _discordWebhook.SendTest();
                Console.WriteLine("成功發送測試用訊息!");
            } catch (Exception ex)
            {
                Console.WriteLine("無法發送測試用訊息! 可能是您的Webhook連結無效。");

            }
        }

        private void webhookInput_TextChanged(object sender, EventArgs e)
        {
            if (this.webhookInput.Text.Trim().Length > 0 && this.webhookInput.Text.StartsWith("https://discord.com/api/webhooks/"))
            {
                this.sendTestMessage.Enabled = true;
            } else
            {
                this.sendTestMessage.Enabled = false;
            }
        }

        public string GetDiscordWebhook()
        {
            return this.webhookInput.Text;
        }
    }
}
