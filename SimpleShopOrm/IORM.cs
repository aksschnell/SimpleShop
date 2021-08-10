using SimpleShodModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShopOrm
{
    public interface IORM
    {
        public List<Customer> GetCustomers();
        public Customer GetCustomer(int id);
        public List<Product> GetProducts();
        public Product GetProduct(int id);
    }
}
