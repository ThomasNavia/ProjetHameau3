using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetHameau.Model
{
    public class M_D_P
    {
        ConnexionBDD connect = new ConnexionBDD();

        public string MDP { get; set; }

        public string GetMDP()
        {

            using (var connexion = connect.ConnexionFileBDD())
            {
                List<M_D_P> LMDP = new List<M_D_P>();
                LMDP = connexion.Query<M_D_P>("SELECT * FROM MDP");
                if (LMDP.Count != 0)
                {
                    string mdpass = LMDP[0].MDP;
                    return mdpass;
                }
                return "000";
            }
        }
    }
}
