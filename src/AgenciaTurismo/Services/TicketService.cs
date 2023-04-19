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
    public class TicketService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projeto-agencia-turismo\src\banco\TourismAgency.mdf";
        readonly SqlConnection conn;

        public TicketService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }


        public int InsertTicket(Ticket ticket)
        {
            int status = 0;
            try
            {
                string strInsert = "insert into Ticket (IdSource, IdDestination, IdClient, DtRegistration, CostTicket) " +
                       "values (@IdSource, @IdDestination, @IdClient, @DtRegistration, @CostTicket); select cast(scope_identity() as int)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@IdSource", new AddressController().Insert(ticket.Source)));
                commandInsert.Parameters.Add(new SqlParameter("@IdDestination", new AddressController().Insert(ticket.Destination)));
                commandInsert.Parameters.Add(new SqlParameter("@IdClient", new ClientController().Insert(ticket.Client)));
                commandInsert.Parameters.Add(new SqlParameter("@DtRegistration", ticket.DtRegistration));
                commandInsert.Parameters.Add(new SqlParameter("@CostTicket", ticket.CostTicket));

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
        public List<Ticket> FindAll()
        {
            List<Ticket> ticketList = new List<Ticket>();

            StringBuilder sb = new StringBuilder();
            sb.Append("select t.Id, ");
            sb.Append("       t.Source, ");
            sb.Append("       t.Destination, ");
            sb.Append("       t.Client, ");
            sb.Append("       t.DtRegistration,");
            sb.Append("       t.CostTicket");
            sb.Append("  from Ticket t,");
            sb.Append("   where t.IdSource = a.Id");
            sb.Append("   where t.IdDestination = a.Id");
            sb.Append("   where t.IdCliente = c.Id");

            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Ticket ticket = new Ticket();

                ticket.Id = (int)dr["Id"];
                ticket.DtRegistration = (DateTime)dr["DtRegsitration"];
                ticket.CostTicket = (decimal)dr["CostTiket"];
                ticket.Source = new Address()
                {
                    Street = (string)dr["Street"],
                    Number = (int)dr["Number"],
                    Neighborhood = (string)dr["Neighborhood"],
                    PostalCode = (string)dr["PostalCode"],
                    Description = (string)dr["Description"]
                };
                ticket.Destination = new Address()
                {
                    Street = (string)dr["Street"],
                    Number = (int)dr["Number"],
                    Neighborhood = (string)dr["Neighborhood"],
                    PostalCode = (string)dr["PostalCode"],
                    Description = (string)dr["Description"]
                };
                ticket.Client = new Client()
                {
                    Id = (int)dr["Id"],
                    Name = (string)dr["Name"],
                    Phone = (string)dr["Phone"]
                };
                ticketList.Add(ticket);
            }
            return ticketList;
        }


        public int Update(Ticket ticket)
        {
   
            string _update = "update Ticket set " +
                             "Source = @IdSource" +
                             "Destination = @IdDestination" +
                             "Client = @IdClient"+
                             "CostTicket = @CostTicket" +
                             " where Id = @id";
            SqlCommand commandUpdate = new SqlCommand(_update, conn);
            commandUpdate.Parameters.Add(new SqlParameter("@IdSource", ticket.Source));
            commandUpdate.Parameters.Add(new SqlParameter("@IdDestination", ticket.Destination));
            commandUpdate.Parameters.Add(new SqlParameter("@IdClient", ticket.Client));
            commandUpdate.Parameters.Add(new SqlParameter("@CostTicket", ticket.CostTicket));

            return commandUpdate.ExecuteNonQuery();

        }

        public int Delete(Ticket ticket)
        {
            string _delete = "delete from Ticket where id =@id";
            SqlCommand commandDelete = new SqlCommand(_delete, conn);
            commandDelete.Parameters.Add(new SqlParameter("@id", ticket.Id));

            return (int)commandDelete.ExecuteNonQuery();
        }
    }
}
