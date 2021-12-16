using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tricount
{
    public class utilisateur
    {
        public int id { get; set; }

        public int nom { get; set; }

        public int id_organisteur { get; set; }

        public int dettes { get; set; }

        public int depenses { get; set; }

        public int id_soiree { get; set; }

        public utilisateur(int Nom, int ID_Organisateur, int Dettes, int Depenses, int ID_Soiree)
        {
            nom = Nom;
            id_organisteur = ID_Organisateur;
            dettes = Dettes;
            depenses = Depenses;
            id_soiree = ID_Soiree;
        }

        public utilisateur(int ID, int Nom, int ID_Organisateur, int Dettes, int Depenses, int ID_Soiree)
            : this(Nom, ID_Organisateur, Dettes, Depenses, ID_Soiree)
        {
            id = ID;
        }
    }
}