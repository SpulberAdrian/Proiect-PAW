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
    public partial class Overview : Form
    {
        //List<Bauturi> lista3 = new List<Bauturi>();


        public Overview()
        {
            InitializeComponent();
        }

        private async void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Produse frm = new Produse();
            frm.ShowDialog();
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            ImaginiProduse frm = new ImaginiProduse();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BazaDeDate frm = new BazaDeDate();
            frm.ShowDialog();
        }
    }
}
