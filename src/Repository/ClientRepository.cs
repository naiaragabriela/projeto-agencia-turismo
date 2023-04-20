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
    internal class ClientRepository: IClientRepository
    {
        private string _conn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\users\adm\source\repos\projeto-agencia-turismo\src\banco\TourismAgency.mdf";


        public ClientRepository()
        {
            _conn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        }

        
        public bool Insert(Client client)
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Execute(Client.INSERT, client);

            };
            return true;
        }

        List<Client> IClientRepository.GetAll()
        {
            List<Client> list = new List<Client>();

            using (var db = new SqlConnection(_conn))
            {
                var client = db.Query<Client>(Client.GETALL);
            }
            return list;

        }
    }
}
