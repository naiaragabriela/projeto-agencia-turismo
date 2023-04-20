using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;

namespace Repository
{
    internal interface IClientRepository
    {
        bool Insert(Client client);

        List<Client> GetAll();
    }
}
