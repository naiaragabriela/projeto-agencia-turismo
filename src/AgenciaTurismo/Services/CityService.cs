using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;

namespace AgenciaTurismo.Services
{
    public class CityService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Ingrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\AgenciaTurismo\banco\TourismAgency.mdf";
        readonly SqlConnection conn;

        public CityService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }
        public bool InsertCity(City city)
        {
            bool status = false;
            try
            {
                string strInsert = "insert into City (Description, DtRegistration) " +
                    "values (@Description, @DtRegistration)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Description", city.Description));
                commandInsert.Parameters.Add(new SqlParameter("@DtResgistration", city.DtRegistration));

                commandInsert.ExecuteNonQuery();
                status = true;

            }catch (Exception) 
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


        public List<City> FindAll()
        {
            List<City> cityList = new List<City>();

            StringBuilder sb = new StringBuilder();
            sb.Append("select c.Id, ");
            sb.Append("       c.Description, ");
            sb.Append("       c.DtRegistration");
            sb.Append("  from City c");


            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                City city = new City();

                city.Id = (int)dr["Id"];
                city.Description = (string)dr["Description"];
                city.DtRegistration = (DateTime)dr["DtRegsitration"]; 


                cityList.Add(city);
            }
            return cityList;
        }

        public int DeleteId(int id)
        {
            string _delete = "delete from City where id =@id";
            SqlCommand commandDelete = new SqlCommand(_delete,conn);
            commandDelete.Parameters.Add(new SqlParameter("@id", id));

            return (int)commandDelete.ExecuteNonQuery();
        }

    }
}
