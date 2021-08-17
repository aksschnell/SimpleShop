using SimpleShodModels;
using SimpleShopModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShopOrm
{
    public interface IORM
    {
        public List<Kunde> GetCustomers();
        public Kunde GetCustomer(int id);
        public List<Produkt> GetProducts();
        public Produkt GetProduct(int id);

        public Produkt CreateProdukt(Produkt produkt);

        public List<Afdeling> GetAfdelinger();


       
      


    }
}
