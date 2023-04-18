using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaTurismo.Services
{
    public class TicketService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\projeto-agencia-turismo\src\banco\TourismAgency.mdf";
        readonly SqlConnection conn;
    }
}
