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
        public int Insert(City city)
        {
            return new CityService().Insert(city);
        }

        public List<City> FindAll()
        {
            return new CityService().FindAll();
        }

        public int Update(City city)
        {
            return new CityService().UpdateDescription(city);
        }

        public int Delete(City city)
        {
            return new CityService().DeleteId(city);
        }
    }
}
