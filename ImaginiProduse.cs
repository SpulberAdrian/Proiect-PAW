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
    public partial class ImaginiProduse : Form
    {
        public ImaginiProduse()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void flowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            
            foreach (string file in files)
            {
                try
                {
                   
                    PictureBox pictureBox = new PictureBox
                    {
                        Image = Image.FromFile(file),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Height = 100,
                        Width = 100,
                        Margin = new Padding(10)
                    };

                   
                    flowLayoutPanel1.Controls.Add(pictureBox);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {file}\n{ex.Message}");
                }
            }
        }
    }
}
