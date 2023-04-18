using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;
using AgenciaTurismo.Services;

namespace AgenciaTurismo.Controllers
{
    public class CityController
    {
        public bool Insert(City city)
        {
            return new CityService().InsertCity(city);
        }

        public List<City> FindAll()
        {
            return new CityService().FindAll();
        }

        public int Delete(int id)
        {
            return new CityService().DeleteId(id);
        }
    }
}
