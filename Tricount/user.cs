using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tricount
{
    public class user
    {
        public int id { get; set; }

        public string nom { get; set; }
        public int depenses { get; set; }

        public int id_soiree { get; set; }

        public user(string Nom, int Depenses, int ID_Soiree)
        {
            nom = Nom;
            depenses = Depenses;
            id_soiree = ID_Soiree;
        }

        public user(int ID, string Nom, int Depenses, int ID_Soiree)
            : this(Nom, Depenses, ID_Soiree)
        {
            id = ID;
        }
    }
}
