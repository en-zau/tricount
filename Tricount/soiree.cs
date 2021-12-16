using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tricount
{
    public class soiree
    {
        public int id { get; set; }

        public int nb_participant { get; set; }

        public int total_soiree { get; set; }

        public int moyenne_user { get; set; }

        public soiree(int NB_Participant, int Total_Soiree, int Moyenne_User)
        {
            nb_participant = NB_Participant;
            total_soiree = Total_Soiree;
            moyenne_user = Moyenne_User;
        }

        public soiree(int ID, int NB_Participant, int Total_Soiree, int Moyenne_User)
            : this(NB_Participant, Total_Soiree, Moyenne_User)
        {
            id = ID;
        }
    }
}