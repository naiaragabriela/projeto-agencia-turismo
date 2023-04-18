using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;

namespace AgenciaTurismo.Services
{
    public class PackageService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Ingrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\AgenciaTurismo\banco\TourismAgency.mdf";
        readonly SqlConnection conn;

        public PackageService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }


        public bool Insert(Package package)
        {
            bool status = false;
            try
            {
                string strInsert = "insert into Package ( Hotel, Ticket, DtRegistration, Cost, Client)" +
                    "values (@Hotel, @Ticket, @DtRegistration, @Cost, @Client)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Hotel", package.Hotel));
                commandInsert.Parameters.Add(new SqlParameter("@Ticket", package.Ticket));
                commandInsert.Parameters.Add(new SqlParameter("@DtRegistration", package.DtRegistration));
                commandInsert.Parameters.Add(new SqlParameter("@Cost", package.Cost));
                commandInsert.Parameters.Add(new SqlParameter("@Cliente", package.Client));

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



        public List<Package> FindAll()
        {
            List<Package> packageList = new List<Package>();

            StringBuilder sb = new StringBuilder();
         




            return packageList;
        }


    }
}
