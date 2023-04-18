using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;

namespace AgenciaTurismo.Services
{
    public class AddressService
    {

        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\AgenciaTurismo\banco\TourismAgency.mdf";
        readonly SqlConnection conn;

        public AddressService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool InsertAddress(Address address)
        {
            bool status = false;
            try
            {
                string strInsert = "insert into Address(Street, Number, Neighborhood, PostalCode, Description, DtRegistration) " +
                    "values (@Street, @Number, @Neighborhood, @PostalCode, @Description, @DtRegistration)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Street", address.Street));
                commandInsert.Parameters.Add(new SqlParameter("@Number", address.Number));
                commandInsert.Parameters.Add(new SqlParameter("@Neighborhood", address.Neighborhood));
                commandInsert.Parameters.Add(new SqlParameter("@PostalCode", address.PostalCode));
                commandInsert.Parameters.Add(new SqlParameter("@Description", address.Description));
                commandInsert.Parameters.Add(new SqlParameter("@DtRegistration", address.DtRegistration));
                commandInsert.Parameters.Add(new SqlParameter("@IdCity", InsertCity(address)));

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

        private int InsertCity(Address address)
        {

            string strInsert = "insert into City (Description) values (@Description); " +
                "select cast(scope_identity() as int)";

            SqlCommand commandInsert = new SqlCommand(strInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@Description", address.City.Description));
      
            return (int)commandInsert.ExecuteScalar();
        }
       
        public List<Address> FindAll()
        {
            List<Address> addressList = new List<Address>();

            StringBuilder sb = new StringBuilder();
            sb.Append("select a.Id, ");
            sb.Append("       a.Number, ");
            sb.Append("       a.Neighborhood, ");
            sb.Append("       a.PostalCode, ");
            sb.Append("       a.Description, ");
            sb.Append("       a.DtRegistration");
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
                address.Description = (string)dr["Description"];
                address.DtRegistration = (DateTime)dr["DtRegsitration"];
                address.City = new City() { Description = (string)dr["City"] };

                addressList.Add(address);
            }
            return addressList;
        }

        public int DeleteId(int id)
        {
            string _delete = "delete from Address where id =@id";
            SqlCommand commandDelete = new SqlCommand(_delete, conn);
            commandDelete.Parameters.Add(new SqlParameter("@id", id));

            return (int)commandDelete.ExecuteNonQuery();
        }




    }
}
