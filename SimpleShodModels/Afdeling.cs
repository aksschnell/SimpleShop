using SimpleShodModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimpleShopModels
{
    public class Afdeling
    {
        public int AfdelingsId { get; set; }
        public string Afdelingsnavn { get; set; }

        public List<Produkt> Produkter { get; set; }

        [JsonConstructor]
        public Afdeling(string afdelingsnavn, List<Produkt> produkter)
        {
            Afdelingsnavn = afdelingsnavn;
            Produkter = produkter;
        }

        public Afdeling(int afdelingsid, string afdelingsnavn, List<Produkt> produkter)
        {
            AfdelingsId = afdelingsid;
            Afdelingsnavn = afdelingsnavn;
            Produkter = produkter;
        }

    }
}
