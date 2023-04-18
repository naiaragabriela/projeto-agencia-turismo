using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaTurismo.Models
{
    public class Address
    {
        #region Properties 
        public int Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string PostalCode { get; set; }
        public string Description { get; set; }
        public City City { get; set; }
        public DateTime DtRegistration { get; set; }
        #endregion

        public override string ToString()
        {
            return "Logradouro: "+ Street +
                    "\nNúmero: "+ Number+
                    "\nBairro: "+ Neighborhood+
                    "\nCEP: "+ PostalCode+
                    "\nComplemento: "+ Description+ 
                    "\nCidade: "+ City.ToString();
        }
    }
}
