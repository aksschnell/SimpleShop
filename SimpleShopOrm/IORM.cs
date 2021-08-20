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

        //Customers
        public List<Kunde> GetCustomers();
        public Kunde GetCustomer(int id);
        public Kunde EditCustomer(Kunde kunde);
        public bool DeleteCustomer(int id);
        public Kunde CreateCustomer(Kunde kunde);


        //Products
        public List<Produkt> GetProducts();
        public Produkt GetProduct(int id);

        public Produkt EditProduct(Produkt produkt);

        public bool DeleteProduct(int id);

        public Produkt CreateProdukt(Produkt produkt);


        //Afdelinger
        public List<Afdeling> GetAfdelinger();


        //Statuser

        public OrdreStatus GetStatus(int id);

        public List<OrdreStatus> GetStatuses();

        public OrdreStatus EditStatus(OrdreStatus status);

        public bool DeleteStatus(int id);

        public OrdreStatus CreateStatus(OrdreStatus status);


        //Butikker

        public Butik GetButik(int id);

        public List<Butik> GetButikker();

        public Butik EditButik(Butik butik);

        public bool DeleteButik(int id);

        public Butik CreateButik(Butik butik);




    }
}
