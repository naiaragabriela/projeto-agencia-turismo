using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaTurismo.Models
{
    public class City
    {
        #region Properties

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DtRegistration { get; set; }
        #endregion


        public override string ToString()
        {
            return "Descrição: " + Description;
        }

    }
}
