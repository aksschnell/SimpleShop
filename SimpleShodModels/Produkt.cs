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
        public int ProduktId { get; set; }
        public string ProduktNavn { get; set; }      

        public decimal ProduktPris { get; set; }

        [JsonConstructor]
        public Produkt(string produktnavn, decimal produktpris)
        {
            ProduktNavn = produktnavn;
            ProduktPris = produktpris;   
        }
                
        public Produkt(int produktid, string produktnavn, decimal produktpris)
        {
            ProduktId = produktid;
            ProduktNavn = produktnavn;
            ProduktPris = produktpris;
        }


      
        public void SetId(int id)
        {
            ProduktId = id;
        }

    }
}
