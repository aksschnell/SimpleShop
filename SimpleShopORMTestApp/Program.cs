using SimpleShodModels;
using SimpleShopModels;
using SimpleShopOrm;
using System;
using System.Collections.Generic;

namespace SimpleShopORMTestApp
{
    class Program
    {
        static void Main(string[] args)
        {


            int currentId = 0;
            ORM_MsSql ORM = new ORM_MsSql();






            //Console.WriteLine("indtast et kunde ID");
            //currentId = int.Parse(Console.ReadLine());


            //Customer cust1 = ORM.GetCustomer(currentId);
            //Console.WriteLine(cust1.CustomerName);



            //List<Customer> Customers = ORM.GetCustomers();


            //for (int i = 0; i < Customers.Count; i++)
            //{

            // Console.WriteLine(Customers[i].CustomerName);
            //}



            //Console.WriteLine(ORM.GetProduct(1).ProductName);



            List<Produkt> Products = ORM.GetProducts();

            //for (int i = 0; i < Products.Count; i++)
            //{

            //    Console.WriteLine(Products[i].ProduktNavn);
            //}


            List<Afdeling> Afdelinger = ORM.GetAfdelinger();


            for (int i = 0; i < Afdelinger.Count; i++)
            {

                Console.WriteLine(Afdelinger[i].Afdelingsnavn);
            }




        }
    }
}
