using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaTurismo.Models
{
    public class City
    {

        public static readonly string GETALL = "SELECT Id, Drescription FROM City";
        public static readonly string INSERT = "INSERT into City (Description) VALUES (@Description)";

        #region Properties

        public int Id { get; set; }
        public string NameCity { get; set; }
        public DateTime DtRegistration { get; set; }
        #endregion


        public override string ToString()
        {
            return "Nome da cidade: " + NameCity;
        }

    }
}
