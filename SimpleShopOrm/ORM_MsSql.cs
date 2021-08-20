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

            Kunde kunde = null;

            string query = "select k.ID, k.Navn, k.Gade, p.PostNR, p.By_navn FROM Kunder AS k INNER JOIN PostBy AS p ON k.PostNR = p.PostNR where id = @val ";
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

                    PostBy postby = new PostBy(reader.GetInt32(3),reader.GetString(4));                                     

                    kunde = new Kunde(reader.GetInt32(0),reader.GetString(1),reader.GetString(2), postby);
                    i++;
                }


                reader.Close();

                if (i != 1) return null;

            }


            return kunde;
        }

        
        
        public List<Kunde> GetCustomers()
        {


            List<Kunde> kunder = new List<Kunde>();
            string query = "select k.ID, k.Navn, k.Gade, p.PostNR, p.By_navn FROM Kunder AS k INNER JOIN PostBy AS p ON k.PostNR = p.PostNR";
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
                    PostBy postby = new PostBy(reader.GetInt32(3),reader.GetString(4));

                    Kunde kunde = new Kunde(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), postby);
                    kunder.Add(kunde);
                    i++;
                }

                reader.Close();



            }


            return kunder;


        }



        public Kunde EditCustomer(Kunde kunde)
        {


            string query = "Update Kunder SET Navn = @val1, Gade = @val2, PostNR = @val3 where id = @val4";
            SqlCommand cmd = new SqlCommand(query, dbConn);
            cmd.Parameters.AddWithValue("@val1", kunde.KundeNavn);
            cmd.Parameters.AddWithValue("@val2", kunde.Gade);
            cmd.Parameters.AddWithValue("@val3", kunde.Postby.PostNR);
            cmd.Parameters.AddWithValue("@val4", kunde.KundeId);


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
            }

            kunde.SetId(Convert.ToInt32(cmd.ExecuteScalar()));
            dbConn.Close();
            return kunde;
        }

        public bool DeleteCustomer(int id)
        {


            int rowsEffect = 0;


            string query = "DELETE FROM kunder WHERE id = @val";
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
            }


            try
            {
                rowsEffect = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            dbConn.Close();

            if (rowsEffect == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Kunde CreateCustomer(Kunde kunde)
        {
            string query = "INSERT INTO kunder (Navn,Gade,PostNR) VALUES (@val1, @val2, @val3); SELECT SCOPE_IDENTITY() AS id";
            SqlCommand cmd = new SqlCommand(query, dbConn);
            cmd.Parameters.AddWithValue("@val1", kunde.KundeNavn);
            cmd.Parameters.AddWithValue("@val2", kunde.Gade);
            cmd.Parameters.AddWithValue("@val3", kunde.Postby.PostNR);



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
            }

            kunde.SetId(Convert.ToInt32(cmd.ExecuteScalar()));
            dbConn.Close();
            return kunde;
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
                    //Afdeling afdeling = new Afdeling(reader.GetInt32(0), reader.GetString(1));
                   // Afdelinger.Add(afdeling);
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

        public Produkt EditProduct(Produkt produkt)
        {

            string query = "Update Produkter SET pris = @val1, navn = @val2 where id = @val3";
            SqlCommand cmd = new SqlCommand(query, dbConn);    
            cmd.Parameters.AddWithValue("@val1", produkt.ProduktPris);
            cmd.Parameters.AddWithValue("@val2", produkt.ProduktNavn);
            cmd.Parameters.AddWithValue("@val3", produkt.ProduktId);


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
            }

            produkt.SetId(Convert.ToInt32(cmd.ExecuteScalar()));
            dbConn.Close();
            return produkt;


        }

      
        public bool DeleteProduct(int id)
        {


            int rowsEffect = 0;          


            string query = "DELETE FROM Produkter WHERE id = @val";
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
            }


           try
            {
               rowsEffect = cmd.ExecuteNonQuery();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            dbConn.Close();

            if (rowsEffect == 1)
            {
                return true;
            }
            else
            {
                return false;
            } 

        }


        public OrdreStatus GetStatus(int id)
        {

            OrdreStatus status = null;



            string query = "SELECT id, Statusbeskrivelse from Statuser where id = @val";
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
                    status = new OrdreStatus(reader.GetInt32(0), reader.GetString(1));
                    i++;
                }


                reader.Close();

                if (i != 1) return null;

            }


            return status;




        }

        public List<OrdreStatus> GetStatuses()
        {

            List<OrdreStatus> statuser = new List<OrdreStatus>();
            string query = "select id, statusbeskrivelse from statuser";
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
                    OrdreStatus status = new OrdreStatus(reader.GetInt32(0), reader.GetString(1));
                    statuser.Add(status);
                    i++;
                }

                reader.Close();



            }


            return statuser;
        }

        public OrdreStatus EditStatus(OrdreStatus status)
        {


            string query = "Update statuser SET statusbeskrivelse = @val1 where id = @val2";
            SqlCommand cmd = new SqlCommand(query, dbConn);
            cmd.Parameters.AddWithValue("@val1", status.StatusBeskrivelse);   
            cmd.Parameters.AddWithValue("@val2", status.OrdreStatusId);


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
            }

            status.SetId(Convert.ToInt32(cmd.ExecuteScalar()));
            dbConn.Close();
            return status;
        }

        public bool DeleteStatus(int id)
        {


            int rowsEffect = 0;


            string query = "DELETE FROM statuser WHERE id = @val";
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
            }


            try
            {
                rowsEffect = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            dbConn.Close();

            if (rowsEffect == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public OrdreStatus CreateStatus(OrdreStatus status)
        {

            string query = "INSERT INTO statuser (Statusbeskrivelse) VALUES (@val1); SELECT SCOPE_IDENTITY() AS id";
            SqlCommand cmd = new SqlCommand(query, dbConn);
            cmd.Parameters.AddWithValue("@val1", status.StatusBeskrivelse);
    


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
            }

            status.SetId(Convert.ToInt32(cmd.ExecuteScalar()));
            dbConn.Close();
            return status;
        }

        public Butik GetButik(int id)
        {

            Butik butik = null;

            string query = "select b.ID, b.Gade, p.PostNR, p.By_navn FROM butikker AS b INNER JOIN PostBy AS p ON b.PostNR = p.PostNR where id = @val ";
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

                    PostBy postby = new PostBy(reader.GetInt32(2),reader.GetString(3));

                    //butik = new Butik(reader.GetInt32(0), reader.GetString(1),postby);
                    i++;
                }


                reader.Close();

                if (i != 1) return null;

            }


            return butik;
        }

        public List<Butik> GetButikker()
        {


            List<Butik> butikker = new List<Butik>();
            string query = "select b.ID, b.Gade, p.PostNR, p.By_navn FROM butikker AS b INNER JOIN PostBy AS p ON b.PostNR = p.PostNR";
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
                    PostBy postby = new PostBy(reader.GetInt32(2), reader.GetString(3));

                    //Butik butik = new Butik(reader.GetInt32(0), reader.GetString(1), postby);
                 //   butikker.Add(butik);
                    i++;
                }

                reader.Close();



            }


            return butikker;
        }

        public Butik EditButik(Butik butik)
        {

            string query = "Update butikker SET gade = @val1, Gade = @val2 where id = @val3";
            SqlCommand cmd = new SqlCommand(query, dbConn);
            cmd.Parameters.AddWithValue("@val1", butik.Gade);
        


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
            }

            butik.SetId(Convert.ToInt32(cmd.ExecuteScalar()));
            dbConn.Close();
            return butik;
        }

        public bool DeleteButik(int id)
        {
            throw new NotImplementedException();
        }

        public Butik CreateButik(Butik butik)
        {
            throw new NotImplementedException();
        }
    }








}
