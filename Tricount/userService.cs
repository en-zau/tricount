using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricount.DAL;

namespace Tricount
{
    public class userService
    {
        private userDepot_DAL depot = new userDepot_DAL();

        public List<user> GetAllUser()
        {
            var user = depot.GetAll()
                    .Select(u => new user(u.id, u.nom, u.organisteur, u.dettes, u.depenses, u.id_soiree))
                    .ToList();

            return user;
        }
        public user GetByID(int ID)
        {
            var u = depot.GetByID(ID);
            var user = new user(u.id, u.nom, u.organisteur, u.dettes, u.depenses, u.id_soiree);
            return user;
        }
        public user Insert(user u)
        {
            var user = new user_DAL(u.nom, u.organisteur, u.dettes, u.depenses, u.id_soiree);
            depot.Insert(user);

            return u;
        }
        public user Update(user u)
        {
            var user = new user_DAL(u.nom, u.organisteur, u.dettes, u.depenses, u.id_soiree);
            depot.Update(user);

            return u;
        }
        public void Delete(user u)
        {
            var user = new user_DAL(u.nom, u.organisteur, u.dettes, u.depenses, u.id_soiree);
            depot.Delete(user);
        }
    }
}
