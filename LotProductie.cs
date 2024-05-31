using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PAW_2
{
    internal class LotProductie
    {
        Bauturi bauturi;
        DateTime DataProductie = DateTime.Now;
        DateTime DataExpirare = DateTime.Now.AddYears(1);

        public DateTime DataProductie1 { get => DataProductie; set => DataProductie = value; }
        public DateTime DataExpirare1 { get => DataExpirare; set => DataExpirare = value; }
        internal Bauturi Bauturi { get => bauturi; set => bauturi = value; }

        public LotProductie()
        {
            bauturi = new Bauturi();
            DataProductie = DateTime.Now;
            DataExpirare= DateTime.Now.AddYears(1);
        }

        public LotProductie(Bauturi b , DateTime p, DateTime e)
        {
            bauturi = b;
            DataProductie = p;
            DataExpirare = e;
        }

        public override string ToString()
        {
            string rezultat = bauturi.ToString() +"Data productiei: "+DataProductie.ToString() + "Data expirarii" + DataExpirare.ToString();
            return base.ToString();
        }
    }
}
