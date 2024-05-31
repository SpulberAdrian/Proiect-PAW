using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PAW_2
{
    public class Bauturi
    {
        private int productID;
        private string name;
        private string description;
        private double price;
        private int quantity;

        public int ProductID { get => productID; set => productID = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public double Price { get => price; set => price = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public Bauturi()
        {
            productID = 0;
            name = " ";
            description = " ";
            price = 0;
            quantity = 0;
        }

        public Bauturi(int p , string n, string d, double pr, int q)
        {
            productID = p;
            name = n;
            description = d;
            price = pr;
            quantity = q;
        }

        public override string ToString()
        {
            string rezultat = "ProductID:" + productID + ", denumirea:" + name + ", descriere:"
                + description + ",are pretul:" + price + ", cantitate:" + quantity + Environment.NewLine;
            return rezultat;
        }

        public  double CalculeazaPret()
        {
            double pret  = 0;
            string descriere = description;
             switch(descriere)
            {
                case "Doza 0.33 litri":
                    pret = 0.3;
                    break;
                case "Doza 0.5 litri":
                    pret = 0.5;
                    break;
                case "Sticla 0.33 litri":
                    pret = 1.5;
                    break;
                case "PET 0.5 litri":
                    pret = 0.5;
                    break;
                case "PET 1 litri":
                    pret = 0.8;
                    break;
                case "PET 1.25 litri":
                    pret = 1.2;
                    break;
                case "PET 2 litri":
                    pret = 1.5;
                    break;
                case "PET 2.5 litri":
                    pret = 1.8;
                    break;

            }
            return pret;
        }
    }
}
