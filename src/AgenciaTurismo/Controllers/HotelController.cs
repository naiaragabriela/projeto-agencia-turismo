using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;
using AgenciaTurismo.Services;

namespace AgenciaTurismo.Controllers
{
    public class HotelController
    {

        public int Insert(Hotel hotel)
        {
            return new HotelService().Insert(hotel);
        }

        public List<Hotel> FindAll()
        {
            return new HotelService().FindAll();
        }

        public int Update(Hotel hotel)
        {
            return new HotelService().Update(hotel);
        }

        public int Delete(Hotel hotel)
        {
            return new HotelService().Delete(hotel);
        }
    }
}
