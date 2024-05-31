using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proiect_PAW_2
{
    public partial class Grafic : Form
    {

        List<double> productionCosts = new List<double>();
        List<double> sellingCosts = new List<double>();
        bool dataLoaded = false;

        Graphics gr;

        const int marg = 10;
        Color colorProduction = Color.Blue;
        Color colorSelling = Color.Green;

        public Grafic()
        {
            InitializeComponent();
        }
 

        private void incarcaDateleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string file = @"C:\Users\Spulber\OneDrive\Desktop\PAW\Proiect PAW 2\Costuri.txt";
            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            productionCosts.Add(Convert.ToDouble(parts[0]));
                            sellingCosts.Add(Convert.ToDouble(parts[1]));
                            dataLoaded = true;
                        }
                    }
                }
                panel1.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading data: " + ex.Message);
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            gr = e.Graphics;
            if (dataLoaded)
            {
                Rectangle rec = new Rectangle(panel1.ClientRectangle.X + marg,
                    panel1.ClientRectangle.Y + 2 * marg,
                    panel1.ClientRectangle.Width - 2 * marg,
                    panel1.ClientRectangle.Height - 3 * marg);
                Pen pen = new Pen(Color.Red, 3);
                gr.DrawRectangle(pen, rec);

                int numberOfBars = productionCosts.Count;
                double barWidth = rec.Width / numberOfBars / 2;
                double spacing = (rec.Width - numberOfBars * barWidth) / (numberOfBars + 1);
                double maxCost = Math.Max(productionCosts.Max(), sellingCosts.Max());

                Brush brushProduction = new SolidBrush(colorProduction);
                Brush brushSelling = new SolidBrush(colorSelling);

                for (int i = 0; i < numberOfBars; i++)
                {
                    // Production cost bars
                    Rectangle productionRect = new Rectangle(
                        (int)(rec.Location.X + (i + 1) * spacing + i * barWidth),
                        (int)(rec.Location.Y + rec.Height - rec.Height / maxCost * productionCosts[i]),
                        (int)barWidth,
                        (int)(rec.Height / maxCost * productionCosts[i]));
                    gr.FillRectangle(brushProduction, productionRect);

                    // Selling cost bars
                    Rectangle sellingRect = new Rectangle(
                        (int)(rec.Location.X + (i + 1) * spacing + i * barWidth + barWidth / 2),
                        (int)(rec.Location.Y + rec.Height - rec.Height / maxCost * sellingCosts[i]),
                        (int)barWidth,
                        (int)(rec.Height / maxCost * sellingCosts[i]));
                    gr.FillRectangle(brushSelling, sellingRect);

                    // Draw the values above bars
                    gr.DrawString(productionCosts[i].ToString(), this.Font, brushProduction,
                        new Point((int)(productionRect.Location.X + barWidth / 2),
                        (int)(productionRect.Location.Y - this.Font.Height)));

                    gr.DrawString(sellingCosts[i].ToString(), this.Font, brushSelling,
                        new Point((int)(sellingRect.Location.X + barWidth / 2),
                        (int)(sellingRect.Location.Y - this.Font.Height)));
                }
            }
        }


        private void schimbaCuloareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                colorProduction = dlg.Color;
                panel1.Invalidate();
            }
        }


        private void pd_print(object sender, PrintPageEventArgs e)
        {
            gr = e.Graphics;
            if (dataLoaded)
            {
                Rectangle rec = new Rectangle(e.PageBounds.X + marg,
                    e.PageBounds.Y + 2 * marg,
                    e.PageBounds.Width - 2 * marg,
                    e.PageBounds.Height - 3 * marg);
                Pen pen = new Pen(Color.Red, 3);
                gr.DrawRectangle(pen, rec);

                int numberOfBars = productionCosts.Count;
                double barWidth = rec.Width / numberOfBars / 2;
                double spacing = (rec.Width - numberOfBars * barWidth) / (numberOfBars + 1);
                double maxCost = Math.Max(productionCosts.Max(), sellingCosts.Max());

                Brush brushProduction = new SolidBrush(colorProduction);
                Brush brushSelling = new SolidBrush(colorSelling);

                for (int i = 0; i < numberOfBars; i++)
                {
                    // Production cost bars
                    Rectangle productionRect = new Rectangle(
                        (int)(rec.Location.X + (i + 1) * spacing + i * barWidth),
                        (int)(rec.Location.Y + rec.Height - rec.Height / maxCost * productionCosts[i]),
                        (int)barWidth,
                        (int)(rec.Height / maxCost * productionCosts[i]));
                    gr.FillRectangle(brushProduction, productionRect);

                    // Selling cost bars
                    Rectangle sellingRect = new Rectangle(
                        (int)(rec.Location.X + (i + 1) * spacing + i * barWidth + barWidth / 2),
                        (int)(rec.Location.Y + rec.Height - rec.Height / maxCost * sellingCosts[i]),
                        (int)barWidth,
                        (int)(rec.Height / maxCost * sellingCosts[i]));
                    gr.FillRectangle(brushSelling, sellingRect);

                    // Draw the values above bars
                    gr.DrawString(productionCosts[i].ToString(), this.Font, brushProduction,
                        new Point((int)(productionRect.Location.X + barWidth / 2),
                        (int)(productionRect.Location.Y - this.Font.Height)));

                    gr.DrawString(sellingCosts[i].ToString(), this.Font, brushSelling,
                        new Point((int)(sellingRect.Location.X + barWidth / 2),
                        (int)(sellingRect.Location.Y - this.Font.Height)));
                }
            }
        }


        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_print);
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.Document = pd;
            dlg.ShowDialog();

        }
    }
}
