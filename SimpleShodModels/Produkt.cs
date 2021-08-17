using SimpleShopModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimpleShodModels
{
    public class Produkt
    {
        public int ProduktId { get; private set; }
        public string ProduktNavn { get; set; }

        public Afdeling Afdeling { get; set; }

        public decimal ProduktPris { get; set; }

        [JsonConstructor]
        public Produkt(string produktnavn, decimal produktpris)
        {
            ProduktNavn = produktnavn;
            ProduktPris = produktpris;
   
        }


        public Produkt(int id, string name, decimal price)
        {
            ProduktId = id;
            ProduktNavn = name;
            ProduktPris = price;

        }



        public Produkt(string name, decimal price, Afdeling afdeling)
        {
            ProduktNavn = name;
            ProduktPris = price;
            Afdeling = afdeling;
        }

        
        public void SetId(int id)
        {
            ProduktId = id;
        }

    }
}
