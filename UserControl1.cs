using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_PAW_2
{
    public partial class UserControl1 : UserControl
    {
        Timer tm;
        public UserControl1()
        {
            InitializeComponent();
           tm = new Timer();
            tm.Interval = 1;
            tm.Tick += tm_tick;
            tm.Start();
        }
        void tm_tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }

    }
}
