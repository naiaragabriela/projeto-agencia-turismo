using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaTurismo.Models
{
    public class Client
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
        public DateTime DtRegistration { get; set; }

        #endregion

        public override string ToString()
        {
            return "Nome: " + Name+
                   "\nPhone: "+ Phone+
                   "\nEndereço: "+ Address.ToString();
        }
    }
}
