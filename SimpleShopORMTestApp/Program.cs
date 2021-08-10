using SimpleShodModels;
using SimpleShopOrm;
using System;


namespace SimpleShopORMTestApp
{
    class Program
    {
        static void Main(string[] args)
        {

            ORM_MsSql ORM = new ORM_MsSql();
            Customer cust1 = ORM.GetCustomer(1);
            Console.WriteLine(cust1.CustomerName);

        }
    }
}
