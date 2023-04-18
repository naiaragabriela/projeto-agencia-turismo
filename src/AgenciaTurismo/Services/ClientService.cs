using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Controllers;
using AgenciaTurismo.Models;

namespace AgenciaTurismo.Services
{
    public class ClientService
    {

        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projeto-agencia-turismo\src\banco\TourismAgency.mdf";
        readonly SqlConnection conn;

        public ClientService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }
        public int InsertClient(Client client)
        {
            int status = 0;
            try
            {
                string strInsert = "insert into Client (Name, Phone, DtRegistration, IdAddress) " +
                    "values (@Name, @Phone, @DtRegistration,@IdAddress); select cast(scope_identity() as int)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Name", client.Name));
                commandInsert.Parameters.Add(new SqlParameter("@Phone", client.Phone));
                commandInsert.Parameters.Add(new SqlParameter("@DtRegistration", client.DtRegistration));
                commandInsert.Parameters.Add(new SqlParameter("@IdAddress", new AddressController().Insert(client.Address)));
               
                status = (int)commandInsert.ExecuteScalar(); 
            }
            catch (Exception)
            {
                status = 0;
                throw;
            }
            finally
            {
                conn.Close();
            }

            return status;
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

        //falta fazer o update de cliente

        public int DeleteId(int id)
        {
            string _delete = "delete from Client where id =@id";
            SqlCommand commandDelete = new SqlCommand(_delete, conn);
            commandDelete.Parameters.Add(new SqlParameter("@id", id));

            return (int)commandDelete.ExecuteNonQuery();
        }

    }
}

