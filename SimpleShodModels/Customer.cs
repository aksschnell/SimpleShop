using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShodModels
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public List<Order> Orders { get; set; }


        // Constructor
        public Customer(string name)
        {
            CustomerName = name;
        }

        public Customer(int id, string name)
        {
            CustomerId = id;
            CustomerName = name;
        }
    }
}
