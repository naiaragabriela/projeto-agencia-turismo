using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;

namespace Repository
{
    public interface ICityRepository
    {
        bool Insert(City city);

        List<City> GetAll();
    }
}
