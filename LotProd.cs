using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_PAW_2
{
    public partial class LotProd : Form
    {
        public LotProd(List<Bauturi> lista)
        {


            InitializeComponent();

            DateTime currentTime = DateTime.Now;
            DateTime expirationDate = currentTime.AddYears(1);

            foreach (Bauturi p in lista)
            {
                textBox1.Text += p.ToString() + "Data productiei: " + currentTime.ToString() +
                    "Data expirarii" + expirationDate.ToString() + Environment.NewLine;

            }
        }

            public double Pret(Bauturi p)
            {
                double pret = p.CalculeazaPret() * p.Quantity;
            return pret;
            }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\Users\Spulber\OneDrive\Desktop\PAW\Proiect PAW 2\Produse.txt";
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');


                    if (parts.Length == 5)
                    {
                        
                        int id = int.Parse(parts[0].Trim());
                        string nume = parts[1].Trim();
                        string descriere = parts[2].Trim();
                        double pret = double.Parse(parts[3].Trim());
                        int cantitate = int.Parse(parts[4].Trim());
                        Bauturi p = new Bauturi(id, nume, descriere, pret, cantitate);
                        double pret2 = Pret(p);
                        double pret3 = pret * cantitate;


                        string file = @"C:\Users\Spulber\OneDrive\Desktop\PAW\Proiect PAW 2\Costuri.txt";
                        try
                            {
                                using (StreamWriter sw = File.AppendText(file))
                                {
                                    sw.WriteLine(pret2.ToString() + "," + pret3.ToString());
                                }
                            }
                        catch (Exception ex)
                            {
                                MessageBox.Show("Datele nu au fost salvate");
                            }


                            ListViewItem lvitem2 = new ListViewItem();
                        lvitem2.SubItems.Add(nume);
                        lvitem2.SubItems.Add(descriere);
                        lvitem2.SubItems.Add(pret2.ToString());
                        lvitem2.SubItems.Add(pret3.ToString());
                      
                        listView1.Items.Add(lvitem2);


                    }
                    else
                    {
                        MessageBox.Show("Fisierul este gol");
                    }
                }
            }
        }

        private void genereazaGraficToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Grafic frm = new Grafic();
            frm.ShowDialog();
        }
    }
}
