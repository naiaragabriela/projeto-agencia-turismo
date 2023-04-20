using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;
using Dapper;

namespace Repository
{
    public class CityRepository: ICityRepository
    {
        private string _conn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\users\adm\source\repos\projeto-agencia-turismo\src\banco\TourismAgency.mdf";


        public CityRepository ()
        {
            _conn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        }

        public List<City> GetAll()
        {
            List<City> list = new List<City>(); 

            using (var db = new SqlConnection(_conn))
            {
                var city = db.Query<City>(City.GETALL);
            }
            return list;
        }

        public bool Insert(City city)
        {
            using(var db = new SqlConnection(_conn))
            {
                db.Execute(City.INSERT, city);

            };
            return true;
        }

    }
}
