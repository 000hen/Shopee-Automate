using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Shopee_Automate.Forms
{
    public partial class Panel : Form
    {
        private static SetAccount _setAccount = new SetAccount();
        private static DiscordWebhookSetup _discordWebhookSetup = new DiscordWebhookSetup();
        private static ScheduleTimeSet _scheduleTimeSet = new ScheduleTimeSet();

        private static Scheduler _scheduler = new Scheduler();

        private string ShopeeUsername;
        private string ShopeePassword;

        public Panel()
        {
            InitializeComponent();

            if (Util.CheckAccountFile())
            {
                string[] data = Util.ReadAccountInfo();

                ShopeeUsername = data[0];
                ShopeePassword = data[1];
            } else
            {
                this.start.Enabled = false;
                this.setAuto.Enabled = false;
                this.unsetAuto.Enabled = false;
            }

            if (!_scheduler.CheckTaskExists())
            {
                this.unsetAuto.Enabled = false;
            } else
            {
                this.setAuto.Enabled = false;
            }

            if (!File.Exists(Util.CookiesPath)) this.removeCookies.Enabled = false;
        }

        private void setLoginInformation_Click(object sender, EventArgs e)
        {
            DialogResult dl = _setAccount.ShowDialog();

            if (dl == DialogResult.OK)
            {
                List<string> a = _setAccount.GetAccount();
                ShopeeUsername = a[0];
                ShopeePassword = a[1];

                File.WriteAllText(Util.LoginInfoPath, String.Format("{0}:{1}", ShopeeUsername, ShopeePassword));

                this.start.Enabled = true;
                this.setAuto.Enabled = true;
                this.unsetAuto.Enabled = true;
            }
            else if (dl == DialogResult.Cancel)
            {
                _setAccount.Close();
            }

        }

        private void setAuto_Click(object sender, EventArgs e)
        {
            DialogResult dl = _scheduleTimeSet.ShowDialog();

            if (dl == DialogResult.OK)
            {
                _scheduler.CreateTask(new Microsoft.Win32.TaskScheduler.DailyTrigger
                {
                    StartBoundary = _scheduleTimeSet.GetDateTime(),
                    DaysInterval = 1
                });

                this.setAuto.Enabled = false;
                this.unsetAuto.Enabled = true;
            }

        }

        private void unsetAuto_Click(object sender, EventArgs e)
        {
            _scheduler.DeleteTask();

            this.setAuto.Enabled = true;
            this.unsetAuto.Enabled = false;
        }

        private void start_Click(object sender, EventArgs e)
        {
            Close();
            if (ShopeeUsername == null || ShopeePassword == null)
            {
                return;
            }

            Task.Run(async () =>
            {
                await Program.Runner(ShopeeUsername, ShopeePassword);
            }).Wait();
        }

        private void removeCookies_Click(object sender, EventArgs e)
        {
            if (File.Exists(Util.CookiesPath)) File.Delete(Util.CookiesPath);
            Console.WriteLine("已刪除登入Cookies");
        }

        private void generateBAT_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Batch File|*.bat",
                Title = "儲存啟動BAT檔案"
            };
            sfd.ShowDialog();

            if (sfd.FileName != "")
            {
                FileStream fs = (FileStream)sfd.OpenFile();
                byte[] strings = Encoding.UTF8.GetBytes(String.Format("{0} nogui", Program.ExecutePath));
                foreach (byte str in strings)
                {
                    fs.WriteByte(str);
                }
                fs.Close();
            }
        }

        private void setDiscordWebhook_Click(object sender, EventArgs e)
        {
            DialogResult dl = _discordWebhookSetup.ShowDialog();

            if (dl == DialogResult.OK)
            {
                string webhookURL = _discordWebhookSetup.GetDiscordWebhook();
                File.WriteAllText(Util.DiscordWebhookPath, webhookURL);
            }
            else if (dl == DialogResult.Cancel)
            {
                _discordWebhookSetup.Close();
            }
        }

    }
}
