using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShopModels
{
    public class Afdeling
    {
        public int AfdelingsId { get; set; }
        public string Afdelingsnavn { get; set; }



        public Afdeling(string beskrivelse)
        {
            Afdelingsnavn = beskrivelse;
        }

        public Afdeling(int id, string beskrivelse)
        {
            AfdelingsId = id;
            Afdelingsnavn = beskrivelse;

        }
        

    }
}
