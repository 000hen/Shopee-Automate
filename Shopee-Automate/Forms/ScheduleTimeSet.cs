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
    public partial class ScheduleTimeSet : Form
    {
        private DateTime _time;

        public ScheduleTimeSet()
        {
            InitializeComponent();
        }

        private void submit_Click(object sender, EventArgs e)
        {
            _time = this.timePicker.Value;
        }

        public DateTime GetDateTime()
        {
            return _time;
        }
    }
}
