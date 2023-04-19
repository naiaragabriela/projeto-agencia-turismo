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
    public class HotelService
    {

        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projeto-agencia-turismo\src\banco\TourismAgency.mdf";
        readonly SqlConnection conn;

        public HotelService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public int Insert(Hotel hotel)
        {
            int status = 0;
            try

            {
                string strInsert = "insert into Hotel (Name, IdAddress, CostHotel, DtRegistration) " +
                       "values (@Name, @IdAddress, @CostHotel, @DtRegistration); select cast(scope_identity() as int)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Name", hotel.Name));
                commandInsert.Parameters.Add(new SqlParameter("@IdAddress", new AddressController().Insert(hotel.Address)));
                commandInsert.Parameters.Add(new SqlParameter("@CostHotel", hotel.CostHotel));
                commandInsert.Parameters.Add(new SqlParameter("@DtRegistration", hotel.DtRegistration));

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

        public List<Hotel> FindAll()
        {
            List<Hotel> hotelList = new List<Hotel>();

            StringBuilder sb = new StringBuilder();
            sb.Append("select h.Id, ");
            sb.Append("       h.Name, ");
            sb.Append("       h.Address, ");
            sb.Append("       h.CostHotel, ");
            sb.Append("       h.DtRegistration,");
            sb.Append("  from Hotel h,");
            sb.Append("   where h.IdAddress = a.Id");
           

            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Hotel hotel = new Hotel();

                hotel.Id = (int)dr["Id"];
                hotel.Name = (string)dr["Name"];
                hotel.DtRegistration = (DateTime)dr["DtRegsitration"];
                hotel.CostHotel = (decimal)dr["CostHotel"];
                hotel.Address = new Address()
                {
                    Street = (string)dr["Street"],
                    Number = (int)dr["Number"],
                    Neighborhood = (string)dr["Neighborhood"],
                    PostalCode = (string)dr["PostalCode"],
                    Description = (string)dr["Description"]
                };
              
                hotelList.Add(hotel);
            }
            return hotelList;
        }

        public int Update(Hotel hotel)
        {

            string _update = "update Hotel set " +
                             "Name = @Name" +
                             "Adress = @IdAdress" +
                             "CostHotel = @CostHotel" +
                             " where Id = @id";
            SqlCommand commandUpdate = new SqlCommand(_update, conn);
            commandUpdate.Parameters.Add(new SqlParameter("@Name", hotel.Name));
            commandUpdate.Parameters.Add(new SqlParameter("@IdAddress", hotel.Address));
            commandUpdate.Parameters.Add(new SqlParameter("@CostHotel", hotel.CostHotel));

            return commandUpdate.ExecuteNonQuery();

        }

        public int Delete(Hotel hotel)
        {
            string _delete = "delete from Hotel where id =@id";
            SqlCommand commandDelete = new SqlCommand(_delete, conn);
            commandDelete.Parameters.Add(new SqlParameter("@id", hotel.Id));

            return (int)commandDelete.ExecuteNonQuery();
        }


    }
}
