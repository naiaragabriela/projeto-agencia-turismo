﻿using System;
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
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projeto-agencia-turismo\src\banco\TourismAgency.mdf";
        readonly SqlConnection conn;

        public CityService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }
        public int Insert(City city)
        {
            int status = 0;
            try
            {
                string strInsert = "insert into City (Description, DtRegistration) " +
                    "values (@Description, @DtRegistration); select cast(scope_identity() as int)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Description", city.Description));
                commandInsert.Parameters.Add(new SqlParameter("@DtRegistration", city.DtRegistration));

                 
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


        public List<City> FindAll()
        {
            List<City> cityList = new List<City>();

            StringBuilder sb = new StringBuilder();
            sb.Append("select c.Id, ");
            sb.Append("       c.Description ");
            sb.Append("  FROM City c");


            SqlCommand commandSelect = new SqlCommand(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                City city = new City();

                city.Id = (int)dr["Id"];
                city.Description = (string)dr["Description"];

                cityList.Add(city);
            }
            return cityList;
        }

        public int UpdateDescription(City city)
        {
            string _update = "update City set Description = @Description where Id = @id";
            SqlCommand commandUpdate = new SqlCommand(_update, conn);
            commandUpdate.Parameters.Add(new SqlParameter("@Description", city.Description));
            commandUpdate.Parameters.Add(new SqlParameter("@Id", city.Id));

            return commandUpdate.ExecuteNonQuery();
        }


        public int DeleteId(City city)
        {
            string _delete = "delete from City where Id =@id";
            SqlCommand commandDelete = new SqlCommand(_delete,conn);
            commandDelete.Parameters.Add(new SqlParameter("@id", city.Id));

            return (int)commandDelete.ExecuteNonQuery();
        }

    }
}
