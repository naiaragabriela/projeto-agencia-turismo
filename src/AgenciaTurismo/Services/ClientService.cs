using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;

namespace AgenciaTurismo.Services
{
    public class ClientService
    {

        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Ingrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\AgenciaTurismo\banco\TourismAgency.mdf";
        readonly SqlConnection conn;

        public ClientService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }
        public bool InsertClient(Client client)
        {
            bool status = false;
            try
            {
                string strInsert = "insert into Client (Name, Phone, DtRegistration) " +
                    "values (@Name, @Phone, @DtRegistration)";



                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Name", client.Name));
                commandInsert.Parameters.Add(new SqlParameter("@Phone", client.Phone));
                commandInsert.Parameters.Add(new SqlParameter("@DtRegistration", client.DtRegistration));
                commandInsert.Parameters.Add(new SqlParameter("@IdAddress", InsertAddress(client)));

                commandInsert.ExecuteNonQuery();
                status = true;
            }
            catch (Exception)
            {
                status = false;
                throw;
            }
            finally
            {
                conn.Close();
            }

            return status;
        }

        private int InsertAddress(Client client)
        {

            string strInsert = "insert into Address(Street, Number, Neighborhood, PostalCode, Description, DtRegistration, City) " +
                    "values (@Street, @Number, @Neighborhood, @PostalCode, @Description, @DtRegistration, @City); " +
                    "select cast(scope_identity() as int)";

            SqlCommand commandInsert = new SqlCommand(strInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@Street", client.Address.Street));
            commandInsert.Parameters.Add(new SqlParameter("@Number", client.Address.Number));
            commandInsert.Parameters.Add(new SqlParameter("@Neighborhood", client.Address.Neighborhood));
            commandInsert.Parameters.Add(new SqlParameter("@PostalCode", client.Address.PostalCode));
            commandInsert.Parameters.Add(new SqlParameter("@Description", client.Address.Description));

            return (int)commandInsert.ExecuteScalar();
        }


        public List<Client> FindAll()
        {
            List<Client> clientList = new List<Client>();

            StringBuilder sb = new StringBuilder();
            sb.Append("select c.Id, ");
            sb.Append("       c.Name, ");
            sb.Append("       c.Phone, ");
            sb.Append("       c.DtRegistration");
            sb.Append("  from Client c,");
            sb.Append("   where c.IdAddress = a.Id");


            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Client client = new Client();

                client.Id = (int)dr["Id"];
                client.Name = (string)dr["Name"];
                client.Phone = (string)dr["Phone"];
                client.DtRegistration = (DateTime)dr["DtRegsitration"];
                client.Address = new Address() { Street = (string)dr["Street"],
                                                 Number = (int)dr["Number"],
                                                 Neighborhood= (string)dr["Neighborhood"],
                                                 PostalCode = (string)dr["PostalCode"],
                                                 Description = (string)dr["Description"] };
                clientList.Add(client);
            }
            return clientList;
        }

        public int DeleteId(int id)
        {
            string _delete = "delete from Client where id =@id";
            SqlCommand commandDelete = new SqlCommand(_delete, conn);
            commandDelete.Parameters.Add(new SqlParameter("@id", id));

            return (int)commandDelete.ExecuteNonQuery();
        }

    }
}

