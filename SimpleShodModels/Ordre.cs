using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShodModels
{
    public class Ordre
    {
        public int OrderId { get; set; }   
        public OrdreStatus OrderStatus { get; set; }
        public List<Produkt> Produkter { get; set; }

        public int Leveringsfirma { get; set; }
        public int KundeID { get; set; }



        public Ordre(OrdreStatus orderstatus, List<Produkt>produkter)
        {
            OrderStatus = orderstatus;
            Produkter = produkter;
        }

        public Ordre(int orderid, OrdreStatus orderstatus, List<Produkt> produkter)
        {
            OrderStatus = orderstatus;
            Produkter = produkter;
        }





    }
}
