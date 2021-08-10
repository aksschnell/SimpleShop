using SimpleShodModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShopOrm
{
    public class ORM_MsSql : IORM
    {

        private SqlConnection dbConn;
        private string host = "10.142.69.56";
        private string username = "SimpleShop";
        private string password  = "SimpleShop";
        private string database = "SimpleShop";


        public ORM_MsSql()
        {
            SqlConnectionStringBuilder conString = new SqlConnectionStringBuilder()
            {
                InitialCatalog = database,
                UserID = username,
                Password = password,
                DataSource = host

            };

            dbConn = new SqlConnection(conString.ToString());
        }


        public Customer GetCustomer(int id)
        {
            Customer customer = null;


            string query = "SELECT id, navn from kunde where id = @val";
            SqlCommand cmd = new SqlCommand(query, dbConn);
            cmd.Parameters.AddWithValue("@val", id);


            if(dbConn.State == System.Data.ConnectionState.Closed)
            {
                try { 
                dbConn.Open();
                }catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                int i = 0;
                while (reader.Read())
                {
                    customer = new Customer(reader.GetInt32(0),reader.GetString(1));
                    i++;
                }

                if (i != 1) return null;

            }


            return customer;
        }

        public List<Customer> GetCustomers()
        {
            
            List<Customer> Customers = new List<Customer>();
            string query = "SELECT id, navn from kunde";
            SqlCommand cmd = new SqlCommand(query, dbConn);



            if (dbConn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    dbConn.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                int i = 0;
                while (reader.Read())
                {  
                    Customer customer = new Customer(reader.GetInt32(0), reader.GetString(1));
                    Customers.Add(customer);
                    i++;
                }

              

            }


            return Customers;


        }

        public Product GetProduct(int id)
        {
            Product product = null;



            string query = "SELECT id, navn, pris from produkt where id = @val";
            SqlCommand cmd = new SqlCommand(query, dbConn);
            cmd.Parameters.AddWithValue("@val", id);


            if (dbConn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    dbConn.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                int i = 0;
                while (reader.Read())
                {
                    product = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2));
                    i++;
                }

                if (i != 1) return null;

            }


            return product;
        }

        public List<Product> GetProducts()
        {
            
            List<Product> Products = new List<Product>();
            string query = "SELECT id, navn, pris from produkt";
            SqlCommand cmd = new SqlCommand(query, dbConn);



            if (dbConn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    dbConn.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                int i = 0;
                while (reader.Read())
                {  
                    Product product = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2));
                    Products.Add(product);
                    i++;
                }

              

            }


            return Products;
        }
    }
}
