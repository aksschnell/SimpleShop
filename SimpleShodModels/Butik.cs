using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimpleShopModels
{
    public class Butik
    {
        public int ID { get; set; }
        public string Gade { get; set; }
        public PostBy PostBy{ get; set; }

        public Afdeling Afdeling { get; set; }


        [JsonConstructor]
        public Butik(string gade, PostBy postby, Afdeling afdeling)
        {
            Gade = gade;
            PostBy = postby;
            Afdeling = afdeling;
        }

        public Butik(int id, string gade, PostBy postby, Afdeling afdeling)
        {
            ID = id;
            Gade = gade;
            PostBy = postby;
            Afdeling = afdeling;
        }

        public void SetId(int id)
        {
            ID = id;
        }

    }
}
