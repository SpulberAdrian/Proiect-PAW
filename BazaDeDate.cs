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
    public partial class BazaDeDate : Form
    {
        public BazaDeDate()
        {
            InitializeComponent();
        }

        private void BazaDeDate_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'appData1.Produse' table. You can move, or remove it, as needed.
            this.produseTableAdapter.Fill(this.appData1.Produse);
            // TODO: This line of code loads data into the 'appData.Produse' table. You can move, or remove it, as needed.
            this.produseTableAdapter.Fill(this.appData.Produse);

        }
    }
}
