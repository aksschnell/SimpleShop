using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimpleShopModels
{
    public class PostBy
    {
        public int PostNR { get; set; } 
        public string By_navn { get;  }


        [JsonConstructor]
        public PostBy(string by_navn)
        {
            By_navn = by_navn;
        }

        public PostBy(int postnr, string by_navn)
        {
            PostNR = postnr;
            By_navn = by_navn;
        }

    }
}
