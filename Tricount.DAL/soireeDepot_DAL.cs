using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tricount.DAL
{
    public class soireeDepot_DAL : Depot_DAL<soiree_DAL>
    {
        public override List<soiree_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, nbparticipant, total_soiree, moyenne_user from soiree";
            var reader = commande.ExecuteReader();

            var listeSoiree = new List<soiree_DAL>();

            while (reader.Read())
            {
                var s = new soiree_DAL(reader.GetInt32(0),
                                                    reader.GetInt32(1),
                                                    reader.GetInt32(2),
                                                    reader.GetInt32(3));

                listeSoiree.Add(s);
            }

            DetruireConnexionEtCommande();

            return listeSoiree;
        }

        public override soiree_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, nbparticipant, total_soiree, moyenne_user from soiree where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            soiree_DAL s;

            if (reader.Read())
            {
                s = new soiree_DAL(reader.GetInt32(0),
                                                reader.GetInt32(1),
                                                reader.GetInt32(2),
                                                reader.GetInt32(3));
            }
            else
            {
                throw new Exception($"Pas de soiree avec l'ID {ID}");
            }

            DetruireConnexionEtCommande();

            return s;
        }

        public override soiree_DAL Insert(soiree_DAL soiree)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into soiree(nbparticipant, total_soiree, moyenne_user)" + " values (@NBPARTICAPANT, @TOTAL_SOIREE, @MOYENNE_USER); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@NBPARTICIPANT", soiree.nb_participant));
            commande.Parameters.Add(new SqlParameter("@ID_PANIER_GLOBAL", soiree.total_soiree));
            commande.Parameters.Add(new SqlParameter("@ID_PANIER_GLOBAL", soiree.moyenne_user));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            soiree.nb_participant = GetByID(ID).nb_participant;
            soiree.total_soiree = GetByID(ID).total_soiree;
            soiree.moyenne_user = GetByID(ID).moyenne_user;
            DetruireConnexionEtCommande();

            return soiree;
        }

        public override soiree_DAL Update(soiree_DAL soiree)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update soiree set nbparticipant=@NBPARTICIPANT, total_soiree=@TOTAL_SOIREE moyenne_user=@MOYENNE_USER where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", soiree.id));

            var nbLignes = (int)commande.ExecuteNonQuery();

            if (nbLignes != 1)
            {
                throw new Exception($"Impossible de mettre à jour la soirée d'ID {soiree.id}");
            }

            soiree.nb_participant = GetByID(soiree.id).nb_participant;
            soiree.total_soiree = GetByID(soiree.id).total_soiree;
            soiree.moyenne_user = GetByID(soiree.id).moyenne_user;

            DetruireConnexionEtCommande();

            return soiree;
        }

        public override void Delete(soiree_DAL soiree)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from soiree where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", soiree.id));

            var nbLignes = (int)commande.ExecuteNonQuery();

            if (nbLignes != 1)
            {
                throw new Exception($"Impossible de supprimer la soirée d'ID {soiree.id}");
            }

            DetruireConnexionEtCommande();
        }
    }
}
