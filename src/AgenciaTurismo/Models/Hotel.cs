using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaTurismo.Models
{
    public class Hotel
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public decimal CostHotel { get; set; }
        public DateTime DtRegistration { get; set; }

        #endregion

        public override string ToString()
        {
            return "Nome:" + Name +
                   "\nCusto do Hotel: " + CostHotel +
                   "\nEndereço: " + Address.ToString() ;
        }
    }
}
