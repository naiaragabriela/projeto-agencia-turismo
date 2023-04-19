using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Controllers;
using AgenciaTurismo.Models;

namespace AgenciaTurismo.Services
{
    public class PackageService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projeto-agencia-turismo\src\banco\TourismAgency.mdf";
        readonly SqlConnection conn;

        public PackageService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }


        public int Insert(Package package)
        {
            int status = 0;
            try
            {
                string strInsert = "insert into Package (IdHotel, IdTicket, DtRegistration, Cost, IdClient)" +
                    "values (@IdHotel, @IdTicket, @DtRegistration, @Cost, @IdClient)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@IdHotel", new HotelController().Insert(package.Hotel)));
                commandInsert.Parameters.Add(new SqlParameter("@IdTicket", new TicketController().Insert(package.Ticket)));
                commandInsert.Parameters.Add(new SqlParameter("@DtRegistration", package.DtRegistration));
                commandInsert.Parameters.Add(new SqlParameter("@Cost", package.Cost));
                commandInsert.Parameters.Add(new SqlParameter("@IdCliente", new ClientController().Insert(package.Client)));

                status = (int)commandInsert.ExecuteNonQuery();

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

        public List<Package> FindAll()
        {
        List <Package> packageList = new List<Package>();

            StringBuilder sb = new StringBuilder();
            sb.Append("select p.Id, ");
            sb.Append("       p.Hotel, ");
            sb.Append("       p.Ticket, ");
            sb.Append("       p.Client, ");
            sb.Append("       p.DtRegistration,");
            sb.Append("       p.Cost");
            sb.Append("  from Ticket t,");
            sb.Append("   where p.IdHotel = h.Id");
            sb.Append("   where p.IdTicket = t.Id");
            sb.Append("   where p.IdCliente = c.Id");

            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Package package = new Package();

                package.Id = (int)dr["Id"];
                package.DtRegistration = (DateTime)dr["DtRegsitration"];
                package.Cost = (decimal)dr["Cost"];
                package.Hotel = new Hotel()
                {
                    Id = (int)dr["Id"],
                    Name= (string)dr["Name"],
                    CostHotel = (decimal)dr["CostHotel"]
                };
                package.Ticket = new Ticket()
                {
                    Id = (int)dr["Id"],
                    CostTicket = (decimal)dr["CostTiket"]
                };
                package.Client = new Client()
                {
                    Id = (int)dr["Id"],
                    Name = (string)dr["Name"],
                    Phone = (string)dr["Phone"]
                };
                packageList.Add(package);
            }
            return packageList;
        }

        public int Update(Package package)
        {

            string _update = "update Package set " +
                             "Hotel = @IdHotel" +
                             "Ticket = @IdTicket" +
                             "Client = @IdClient"+
                             "Cost = @Cost" +
                             " where Id = @id";

            SqlCommand commandUpdate = new SqlCommand(_update, conn);
            
            commandUpdate.Parameters.Add(new SqlParameter("@IdHotel", package.Hotel));
            commandUpdate.Parameters.Add(new SqlParameter("@IdTicket", package.Ticket));
            commandUpdate.Parameters.Add(new SqlParameter("@IdClient", package.Client));
            commandUpdate.Parameters.Add(new SqlParameter("@Cost", package.Cost));

            return commandUpdate.ExecuteNonQuery();

        }

        public int Delete(Package package)
        {
            string _delete = "delete from Package where id =@id";
            SqlCommand commandDelete = new SqlCommand(_delete, conn);
            commandDelete.Parameters.Add(new SqlParameter("@id", package.Id));

            return (int)commandDelete.ExecuteNonQuery();
        }

    }
}
