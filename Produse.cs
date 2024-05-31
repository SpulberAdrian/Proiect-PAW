using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace Proiect_PAW_2
{

    public partial class Produse : Form
    {
        List<Bauturi> lista = new List<Bauturi>();

        public Produse()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                int productID = Convert.ToInt32(tbProductID.Text);
                string name = Convert.ToString(tbDenumire.Text);
                string descriere = Convert.ToString(cbDescriere.Text);
                double pret = Convert.ToDouble(tbPret.Text);
                int cantitate = Convert.ToInt32(tbCantitate.Text);

                Bauturi p = new Bauturi(productID, name, descriere, pret, cantitate);
                //MessageBox.Show(p.ToString());
                lista.Add(p);
                
                ListViewItem lvitem = new ListViewItem();
                lvitem.SubItems.Add(productID.ToString());
                lvitem.SubItems.Add(name);
                lvitem.SubItems.Add(descriere);
                lvitem.SubItems.Add(pret.ToString());
                lvitem.SubItems.Add(cantitate.ToString());
                listView1.Items.Add(lvitem);

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                tbProductID.Clear();
                tbCantitate.Clear();
                tbDenumire.Clear();
                tbPret.Clear();
                cbDescriere.SelectedItem = null;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
            else
            {
                MessageBox.Show("Selectati un rand");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int count = listView1.Items.Count;
            MessageBox.Show("Total Records = " + count);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\\Users\\Spulber\\OneDrive\\Desktop\\PAW\\Proiect PAW 2\\Produse.txt";
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
                        lista.Add(p);


                        ListViewItem lvitem2 = new ListViewItem();
                        lvitem2.SubItems.Add(id.ToString());
                        lvitem2.SubItems.Add(nume);
                        lvitem2.SubItems.Add(descriere);
                        lvitem2.SubItems.Add(pret.ToString());
                        lvitem2.SubItems.Add(cantitate.ToString());
                        listView1.Items.Add(lvitem2);
                    }
                    else
                    {
                        MessageBox.Show("Fisierul este gol");
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try {
                    string filePath = "C:\\Users\\Spulber\\OneDrive\\Desktop\\PAW\\Proiect PAW 2\\Salvare.txt";
                    using (StreamWriter sw = File.AppendText(filePath))
                        {
                            foreach (Bauturi p in lista)
                                sw.WriteLine(p.ToString());
                        }
                    MessageBox.Show("Datele au fost salvate");
                }
            catch(Exception ex){
                MessageBox.Show("Datele nu au fost salvate");
            }

        }


        //public List<Bauturi> MetodaBauturi()
        //{
        //    return new List<Bauturi>(lista);
        //}

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void lotProductieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LotProd frm = new LotProd(lista);
            frm.ShowDialog();
        }
    }

}
