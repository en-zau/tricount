using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricount.DAL;

namespace Tricount
{
    class Program
    {
        static int menu()
        {
            Console.WriteLine("Bienvenue sur l'Application de soirée !");
            Console.WriteLine("1 Créer une soirée");
            Console.WriteLine("2 Participer à une soirée");
            Console.WriteLine("3 Affichage des dettes et dépenses");
            int choixmenu = int.Parse(Console.ReadLine());

            if (choixmenu == 1)
            {
                creersoiree();
            }
            if (choixmenu == 2)
            {
                participersoiree();
            }
            if (choixmenu == 3)
            {
                affichage();
            }
            else
            {
                menu();
            }

            return 0;
        }

        static int creersoiree()
        {

            Console.WriteLine("soirée créee !");

            return 0;
        }

        static int participersoiree()
        {
            var soiree = new soireeDepot_DAL();

            var listeSoiree = soiree.GetAll();

            Console.WriteLine("Voici la liste des soirée :\n");

            for (int i = 0; i != listeSoiree.size(); i++)
            {
                Console.WriteLine("", i, listeSoiree);
            }

            Console.WriteLine("Souhaitez vous participer à quelle soirée ?");
            int choixsoiree = int.Parse(Console.ReadLine());

            for (int i = 0; i != listeSoiree.size(); i++)
            {
                if (choixsoiree == soiree.id)
                {
                    var Soiree = soiree.GetByID(choixsoiree);

                    int nbparticipant = Soiree.nbparticipant;
                    nbparticipant = nbparticipant++;
                }
            } 

            return 0;
        }

        static int affichage()
        {
            var user = new userDepot_DAL();

            Console.WriteLine("Voici vos dettes : ", user.dettes);
            Console.WriteLine("Voci vos dépenses : ", user.depenses);
            return 0;
        }


        static void Main(string[] args)
        {
            menu();
        }
    }
}





/* var depo = new UserDepot_DAL();

            var user = new User(3, "bob", 12.2);

            var user1 = new User_DAL(3, "bob", 12.65);
            depo.Insert(user1);

 var test = depo.GetByID(3);
            test.ADRESSE = "88888";
            depo.Update(test);
 




        static int creerpartie()
        {
            var depo = new SpendingGroupDepot_DAL();

            var tmp = new SpendingGroup_DAL("romain1erdlan", '2022-01-01 00:00:00.00');

            depo.Insert(tmp);
            return 0;
        }
    }
}
