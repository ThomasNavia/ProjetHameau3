using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetHameau.Model
{
    public class CREANCIER
    {
        [PrimaryKey, AutoIncrement]
        public int NUM_CRE { get; set; }
        [NotNull]
        public string NOM_CRE { get; set; }
        public string RUE_CRE { get; set; }
        public string POSTAL_CRE { get; set; }
        public string VILLE_CRE { get; set; }
        public string ZIP_CRE { get; set; }
        public string TEL_CRE { get; set; }
        public string FAX_CRE { get; set; }
        public string CONTRAT1_CRE { get; set; }
        public string CONTRAT2_CRE { get; set; }

        List<CREANCIER> LC = new List<CREANCIER>();
        ConnexionBDD connect = new ConnexionBDD();

        public List<CREANCIER> SelectAllCre()
        {
            using (var connexion = connect.ConnexionFileBDD())
            {
                LC = connexion.Query<CREANCIER>("SELECT * FROM CREANCIER");
                return LC;
            }
        }

        public string AddCre(string Nom, string Rue, string CP,string Ville,string zip,string Tel,string Contrat)
        {
            LC = SelectAllCre();
            if(LC.Count() != 0)
            {
                for(int i = 0; i < LC.Count(); i++)
                {
                    if(LC[i].NOM_CRE == Nom)
                    {
                        return "Vous ne pouvez pas ajouter deux fois le même créancier.";
                    }
                }
                using (var connexion = connect.ConnexionFileBDD())
                {
                    var CurrentCre = new CREANCIER()
                    {
                        NOM_CRE = Nom,
                        RUE_CRE = Rue,
                        POSTAL_CRE = CP,
                        VILLE_CRE = Ville,
                        ZIP_CRE = zip,
                        TEL_CRE = Tel,
                        CONTRAT1_CRE = Contrat,
                    };
                    connexion.Insert(CurrentCre);
                }
                return "Le créancier " + Nom + " a été enregistré.";
            }
            return "Aucun créancier trouvé, voir avec le géstionnaire de la base de donnée.";

        }

        public string ModCre(int num , string Nom, string Rue, string CP, string Ville, string zip, string Tel, string Contrat)
        {
            using (var connexion = connect.ConnexionFileBDD())
            {
                LC = SelectAllCre();
                if(LC.Count() != 0)
                {
                    for(int i = 0; i < LC.Count; i++)
                    {
                        if(LC[i].NUM_CRE == num)
                        {
                            var CurrentCre = new CREANCIER()
                            {
                                NOM_CRE = Nom,
                                RUE_CRE = Rue,
                                POSTAL_CRE = CP,
                                VILLE_CRE = Ville,
                                ZIP_CRE = zip,
                                TEL_CRE = Tel,
                                CONTRAT1_CRE = Contrat,
                            };
                            connexion.Update(CurrentCre);
                        }
                    }
                }
            }
            return "Le créancier " + Nom + " a été Modifié.";
        }

    }
}
