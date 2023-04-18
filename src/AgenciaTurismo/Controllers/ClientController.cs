using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;
using AgenciaTurismo.Services;

namespace AgenciaTurismo.Controllers
{
    public class ClientController
    {
        public bool Insert(Client client)
        {
            return new ClientService().InsertClient(client);
        }

        public List<Client> FindAll()
        {
            return new ClientService().FindAll();
        }

        public int Delete(int id)
        {
            return new ClientService().DeleteId(id);
        }
    }
}
