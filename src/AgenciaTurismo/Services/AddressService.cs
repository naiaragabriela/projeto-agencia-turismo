using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
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
                commandInsert.Parameters.Add(new SqlParameter("@IdCity", new CityController().Insert(address.City))) ;

                
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


        public Address FindId (int id)
        { 
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
            commandSelect.Parameters.Add(new SqlParameter("@id", id));
            SqlDataReader dr = commandSelect.ExecuteReader();

                Address findId = new Address();

            while (dr.Read())
            {

                findId.Id = (int)dr["Id"];
                findId.Number = (int)dr["Number"];
                findId.Neighborhood = (string)dr["Neighborhood"];
                findId.Description = (string)dr["Description"];
                findId.DtRegistration = (DateTime)dr["DtRegsitration"];
                findId.City = new City() { Description = (string)dr["City"] };
            }
            return findId;

        }

        public int Update(int id)
        {
            var findId = FindId(id);

            Console.WriteLine("Digite o número que vc deseja alterar:");
            int newNumber = int.Parse(Console.ReadLine());
            findId.Number = newNumber;

            Console.WriteLine("Digite o bairro que vc deseja alterar:");
            string newNeighborhood = Console.ReadLine();
            findId.Neighborhood = newNeighborhood;

            Console.WriteLine("Digite o complemento que vc deseja alterar:");
            string newDescription = Console.ReadLine();
            findId.Description = newDescription;

            string _update = " update from Address where id =@id";
            SqlCommand commandUpdate = new SqlCommand(_update, conn);
            commandUpdate.Parameters.Add(new SqlParameter("@id", id));

            return (int)commandUpdate.ExecuteNonQuery();
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
