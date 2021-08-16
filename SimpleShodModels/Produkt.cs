using SimpleShopModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShodModels
{
    public class Produkt
    {
        public int ProduktId { get; set; }
        public string ProduktNavn { get; set; }

        public Afdeling Afdeling { get; set; }

        public decimal ProduktPris { get; set; }

        public Produkt(string name, decimal price, Afdeling afdeling)
        {
            ProduktNavn = name;
            ProduktPris = price;
            Afdeling = afdeling;
        }

        public Produkt(int id, string name, decimal price)
        {
            ProduktId = id;
            ProduktNavn = name;
            ProduktPris = price;

        }

        

    }
}
