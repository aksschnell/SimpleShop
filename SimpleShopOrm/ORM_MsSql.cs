using SimpleShodModels;
using SimpleShopModels;
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
        private string host = "localhost";
        private string username = "Uber";
        private string password  = "testtest";
        private string database = "Elgiganten";


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
      

        public Kunde GetCustomer(int id)
        {
            Kunde customer = null;


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
                    customer = new Kunde(reader.GetInt32(0),reader.GetString(1));
                    i++;
                }

                reader.Close();

                if (i != 1) return null;

            }


            return customer;
        }

        public List<Kunde> GetCustomers()
        {
            
            List<Kunde> Customers = new List<Kunde>();
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
                    Kunde customer = new Kunde(reader.GetInt32(0), reader.GetString(1));
                    Customers.Add(customer);
                    i++;
                }


                reader.Close();


            }


            return Customers;


        }

        public Produkt GetProduct(int id)
        {
            Produkt product = null;



            string query = "SELECT id, navn, pris from produkter where id = @val";
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
                    product = new Produkt(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2));
                    i++;
                }


                reader.Close();

                if (i != 1) return null;

            }


            return product;
        }

        public List<Produkt> GetProducts()
        {
            
            List<Produkt> Products = new List<Produkt>();
            string query = "SELECT id, navn, pris from produkter";
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
                    Produkt product = new Produkt(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2));
                    Products.Add(product);
                    i++;
                }

                reader.Close();

              

            }


            return Products;        


        }


        public List<Afdeling> GetAfdelinger()
        {

            List<Afdeling> Afdelinger = new List<Afdeling>();
            string query = "SELECT id, Afdelingsnavn from Afdelinger";
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
                    Afdeling afdeling = new Afdeling(reader.GetInt32(0), reader.GetString(1));
                    Afdelinger.Add(afdeling);
                    i++;
                }

                reader.Close();



            }


            return Afdelinger;
        }

        public Produkt CreateProdukt(Produkt produkt)
        {
            string query = "INSERT INTO produkter (navn,pris) VALUES (@val1, @val2); SELECT SCOPE_IDENTITY() AS id";
            SqlCommand cmd = new SqlCommand(query, dbConn);
            cmd.Parameters.AddWithValue("@val1", produkt.ProduktNavn);
            cmd.Parameters.AddWithValue("@val2", produkt.ProduktPris);
          



            if (dbConn.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    dbConn.Open();
                } catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            produkt.SetId(Convert.ToInt32(cmd.ExecuteScalar()));
            dbConn.Close();
            return produkt;

        }
    }
}
