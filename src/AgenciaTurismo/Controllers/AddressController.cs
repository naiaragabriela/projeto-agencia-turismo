using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;
using AgenciaTurismo.Services;

namespace AgenciaTurismo.Controllers
{
    public class AddressController
    {
        public int Insert(Address address)
        {
            return new AddressService().InsertAddress(address);
        }

        public List<Address> FindAll()
        {
            return new AddressService().FindAll();
        }
        public int Update(Address address)
        {
            return new AddressService().Update(address);
        }
        public int Delete(Address address)
        {
            return new AddressService().Delete(address);
        }
    }
}
