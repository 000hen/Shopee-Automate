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

namespace Shopee_Automate.Forms
{
    public partial class DiscordWebhookSetup : Form
    {
        private HttpClient _httpClient = new HttpClient();

        public DiscordWebhookSetup()
        {
            InitializeComponent();

            if (this.webhookInput.Text.Trim().Length == 0 )
            {
                this.sendTestMessage.Enabled = false;
            }
        }

        private async void sendTestMessage_Click(object sender, EventArgs e)
        {
            string value = JsonConvert.SerializeObject(new
            {
                embeds = new List<object>
                {
                    new
                    {
                        type = "rich",
                        title = "Shopee-Automate",
                        description = "測試訊息",
                        color = 0x276fff
                    }
                }
            });
            var response = await _httpClient.PostAsync(this.webhookInput.Text, new StringContent(value, Encoding.UTF8, "application/json"));
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("成功發送測試用訊息!");
            } else
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
