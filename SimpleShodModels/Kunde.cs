using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SimpleShopModels;

namespace SimpleShodModels
{
    public class Kunde
    {
        public int KundeId { get; private set; }
        public string KundeNavn{ get; set; }

        public string Gade { get; set; }

        public PostBy Postby { get; set; }

      

        
        // Constructor
        [JsonConstructor]
        public Kunde(string kundenavn, string gade, PostBy postby)
        {
            KundeNavn = kundenavn;
            Gade = gade;
            Postby = postby;
            
        }

        public Kunde(int kundeid, string kundenavn, string gade, PostBy postby)
        {
            KundeId = kundeid;
            KundeNavn = kundenavn;
            Gade = gade;
            Postby = postby;
           
        }



        public void SetId(int id)
        {
            KundeId = id;
        }


    }
}
