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
        private SetAccount _setAccount;

        private string LoginInfoFile = Util.LoginInfoPath;

        private string ShopeeUsername;
        private string ShopeePassword;

        public Panel()
        {
            InitializeComponent();

            if (File.Exists(LoginInfoFile))
            {
                string[] data = Util.ReadAccountInfo();

                ShopeeUsername = data[0];
                ShopeePassword = data[1];
            } else
            {
                this.start.Enabled = false;
            }
        }

        private void setLoginInformation_Click(object sender, EventArgs e)
        {
            _setAccount = new SetAccount();
            DialogResult dl = _setAccount.ShowDialog();

            if (dl == DialogResult.OK)
            {
                List<string> a = _setAccount.GetAccount();
                ShopeeUsername = a[0];
                ShopeePassword = a[1];

                File.WriteAllText(LoginInfoFile, String.Format("{0}:{1}", ShopeeUsername, ShopeePassword));

                this.start.Enabled = true;
            }
            else if (dl == DialogResult.Cancel)
            {
                _setAccount.Close();
            }

        }

        private void setAuto_Click(object sender, EventArgs e)
        {

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
    }
}
