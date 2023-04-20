using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Controllers;
using AgenciaTurismo.Models;

namespace AgenciaTurismo.Services
{
    public class AddressService
    {

        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projeto-agencia-turismo\src\banco\TourismAgency.mdf";
        readonly SqlConnection conn;

        public AddressService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public int InsertAddress(Address address)
        {
            int status = 0;
            try
            {
                string strInsert = "insert into Address(Street, Number, Neighborhood, PostalCode, Description, DtRegistration,IdCity) " +
                    "values (@Street, @Number, @Neighborhood, @PostalCode, @Description, @DtRegistration,@IdCity); " +
                    "select cast(scope_identity() as int)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Street", address.Street));
                commandInsert.Parameters.Add(new SqlParameter("@Number", address.Number));
                commandInsert.Parameters.Add(new SqlParameter("@Neighborhood", address.Neighborhood));
                commandInsert.Parameters.Add(new SqlParameter("@PostalCode", address.PostalCode));
                commandInsert.Parameters.Add(new SqlParameter("@Description", address.Description));
                commandInsert.Parameters.Add(new SqlParameter("@DtRegistration", address.DtRegistration));
                commandInsert.Parameters.Add(new SqlParameter("@IdCity", new CityController().Insert(address.City)));


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

        public List<Address> FindAll()
        {
            List<Address> addressList = new List<Address>();

            StringBuilder sb = new StringBuilder();
            sb.Append("select a.Id, ");
            sb.Append("       a.Number, ");
            sb.Append("       a.Neighborhood, ");
            sb.Append("       a.PostalCode, ");
            sb.Append("       a.Description,");
            sb.Append("       c.Id, ");
            sb.Append("       c.Description ");
            sb.Append("       from Address a,");
            sb.Append("       City c");
            sb.Append("       where a.IdCity = c.Id");


            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Address address = new Address();

                address.Id = (int)dr["Id"];
                address.Number = (int)dr["Number"];
                address.Neighborhood = (string)dr["Neighborhood"];
                address.PostalCode = (string)dr["PostalCode"];
                address.Description = (string)dr["Description"];
                address.City = new City()
                {
                    Id = (int)dr["Id"],
                    Description = (string)dr["Description"] 
                };

                addressList.Add(address);
            }
            return addressList;
        }


        public int Update(Address address)

        {
            string _update = "update Address set " +
                 "Street = @Street" +
                 "Number = @Number" +
                 "Neighborhood = @Neighborhood" +
                 "PostalCode = @PostalCode" +
                 "Description = @Description" +
                 "City = @IdCity" +
                 " where Id = @id";
            SqlCommand commandUpdate = new SqlCommand(_update, conn);
            commandUpdate.Parameters.Add(new SqlParameter("@Street", address.Street));
            commandUpdate.Parameters.Add(new SqlParameter("@Number", address.Number));
            commandUpdate.Parameters.Add(new SqlParameter("@Neighborhood", address.Neighborhood));
            commandUpdate.Parameters.Add(new SqlParameter("@PostalCode", address.PostalCode));
            commandUpdate.Parameters.Add(new SqlParameter("@Description", address.Description));
            commandUpdate.Parameters.Add(new SqlParameter("@IdCity", address.City ));

            return commandUpdate.ExecuteNonQuery();
        }

        public int Delete(Address address)
        {
            string _delete = "delete from Address where id =@id";
            SqlCommand commandDelete = new SqlCommand(_delete, conn);
            commandDelete.Parameters.Add(new SqlParameter("@id", address.Id));

            return (int)commandDelete.ExecuteNonQuery();
        }

    }
}
