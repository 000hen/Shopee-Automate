using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopee_Automate.Forms
{
    public partial class SetAccount : Form
    {
        public SetAccount()
        {
            InitializeComponent();
        }

        private void username_TextChanged(object sender, EventArgs e)
        {
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
        }

        public List<string> GetAccount()
        {
            List<string> l = new List<string>
            {
                this.username.Text,
                this.password.Text
            };

            return l;
        }

        private void Submit_Click(object sender, EventArgs e)
        {

        }
    }
}
