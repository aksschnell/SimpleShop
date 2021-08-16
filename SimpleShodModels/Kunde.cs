using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShodModels
{
    public class Kunde
    {
        public int KundeId { get; set; }
        public string KundeNavn{ get; set; }

        public List<Ordre> Ordrere { get; set; }


        // Constructor
        public Kunde(string name)
        {
            KundeNavn = name;
        }

        public Kunde(int id, string name)
        {
            KundeId = id;
            KundeNavn = name;
        }
    }
}
