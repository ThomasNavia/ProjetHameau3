using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetHameau.Model
{
   
    public class PROPRIETAIRE
    {
        [PrimaryKey, AutoIncrement]
        public int SEQ_PRO { get; set; }
        public string NOM_PRO { get; set; }
        public string DAT_ARR { get; set; }
        public string DAT_DEP { get; set; }

        [ForeignKey("LOT")]
        public int NUM_LOT { get; set; }

        ConnexionBDD connect = new ConnexionBDD();
        List<LOT> LL = new List<LOT>();
        List<PROPRIETAIRE> LP = new List<PROPRIETAIRE>();


        public List<PROPRIETAIRE> SelectProByLot()
        {
            using (var connexion = connect.ConnexionFileBDD())
            {
                string vide = "";
                string espace = " ";
                LP = connexion.Query<PROPRIETAIRE>("SELECT PROPRIETAIRE.NUM_LOT, PROPRIETAIRE.NOM_PRO, LOT.ADRESSE, LOT.COD_PART FROM LOT INNER JOIN PROPRIETAIRE ON LOT.NUM_LOT = PROPRIETAIRE.NUM_LOT WHERE(PROPRIETAIRE.DAT_DEP =? OR PROPRIETAIRE.DAT_DEP =?) GROUP BY LOT.NUM_LOT", vide, espace);
                return LP;

            }
        }
        public List<PROPRIETAIRE> SelectProByLotDatDep()
        {
            using (var connexion = connect.ConnexionFileBDD())
            {
                LP = connexion.Query<PROPRIETAIRE>("SELECT * from PROPRIETAIRE ORDER BY NUM_LOT");
                return LP;
            }
        }

        public List<PROPRIETAIRE> SelectProByLot121()
        {
            using (var connexion = connect.ConnexionFileBDD())
            {
                string vide = "";
                string espace = " ";
                LP = connexion.Query<PROPRIETAIRE>("SELECT PROPRIETAIRE.NUM_LOT, PROPRIETAIRE.NOM_PRO, LOT.ADRESSE, LOT.COD_PART FROM LOT INNER JOIN PROPRIETAIRE ON LOT.NUM_LOT = PROPRIETAIRE.NUM_LOT WHERE((PROPRIETAIRE.DAT_DEP =? OR PROPRIETAIRE.DAT_DEP =?)AND LOT.COD_PART = 121) GROUP BY LOT.NUM_LOT", vide, espace);
                return LP;
            }
        }

        public List<PROPRIETAIRE> SelectProByLot123()
        {
            using (var connexion = connect.ConnexionFileBDD())
            {
                string vide = "";
                string espace = " ";
                LP = connexion.Query<PROPRIETAIRE>("SELECT PROPRIETAIRE.NUM_LOT, PROPRIETAIRE.NOM_PRO, LOT.ADRESSE, LOT.COD_PART FROM LOT INNER JOIN PROPRIETAIRE ON LOT.NUM_LOT = PROPRIETAIRE.NUM_LOT WHERE((PROPRIETAIRE.DAT_DEP =? OR PROPRIETAIRE.DAT_DEP =?)AND LOT.COD_PART = 123) GROUP BY LOT.NUM_LOT", vide, espace);
                return LP;
            }
        }

        public List<PROPRIETAIRE> SelectProByLot126()
        {
            using (var connexion = connect.ConnexionFileBDD())
            {
                string vide = "";
                string espace = " ";
                LP = connexion.Query<PROPRIETAIRE>("SELECT PROPRIETAIRE.NUM_LOT, PROPRIETAIRE.NOM_PRO, LOT.ADRESSE, LOT.COD_PART FROM LOT INNER JOIN PROPRIETAIRE ON LOT.NUM_LOT = PROPRIETAIRE.NUM_LOT WHERE((PROPRIETAIRE.DAT_DEP =? OR PROPRIETAIRE.DAT_DEP =?)AND LOT.COD_PART = 126) GROUP BY LOT.NUM_LOT", vide, espace);
                return LP;
            }
        }

        public List<PROPRIETAIRE> SelectProByLot129()
        {
            using (var connexion = connect.ConnexionFileBDD())
            {
                string vide = "";
                string espace = " ";
                LP = connexion.Query<PROPRIETAIRE>("SELECT PROPRIETAIRE.NUM_LOT, PROPRIETAIRE.NOM_PRO, LOT.ADRESSE, LOT.COD_PART FROM LOT INNER JOIN PROPRIETAIRE ON LOT.NUM_LOT = PROPRIETAIRE.NUM_LOT WHERE((PROPRIETAIRE.DAT_DEP =? OR PROPRIETAIRE.DAT_DEP =?)AND LOT.COD_PART = 129) GROUP BY LOT.NUM_LOT", vide, espace);
                return LP;
            }
        }
        public List<PROPRIETAIRE> SelectProByLotOne(string numlot)
        {
            using (var connexion = connect.ConnexionFileBDD())
            {
                string vide = "";
                string espace = " ";
                LP = connexion.Query<PROPRIETAIRE>("SELECT * FROM PROPRIETAIRE WHERE((PROPRIETAIRE.DAT_DEP =? OR PROPRIETAIRE.DAT_DEP =?)AND PROPRIETAIRE.NUM_LOT =?)", vide, espace,numlot);
                return LP;
            }
        }

        public List<PROPRIETAIRE> SelectProByName(string name)
        {
            using (var connexion = connect.ConnexionFileBDD())
            {
                LP = connexion.Query<PROPRIETAIRE>("SELECT * FROM PROPRIETAIRE WHERE NOM_PRO =?",name);
                return LP;
            }
        }
        public List<PROPRIETAIRE> SelectProByCha()
        {
            using (var connexion = connect.ConnexionFileBDD())
            {
                LP.Clear();
                LP = connexion.Query<PROPRIETAIRE>("SELECT PROPRIETAIRE.NOM_PRO FROM CHARGE INNER JOIN PROPRIETAIRE ON CHARGE.NUM_LOT = PROPRIETAIRE.NUM_LOT WHERE(PROPRIETAIRE.DAT_DEP =?) ORDER BY CHARGE.NUM_LOT","");
                return LP;
            }
        }

        public List<PROPRIETAIRE> SelectProByLotCha(string Lot)
        {
            using (var connexion = connect.ConnexionFileBDD())
            {
                List<PROPRIETAIRE> NLP = new List<PROPRIETAIRE>();
                LP.Clear();
                LP = connexion.Query<PROPRIETAIRE>("SELECT COUNT(*) as NUM_LOT FROM PROPRIETAIRE WHERE PROPRIETAIRE.NUM_LOT=?", Lot);
                if(LP.Count() != 0)
                {
                    int Nbr = LP[0].NUM_LOT;
                    if (Nbr >=2)
                    {
                        LP.Clear();
                        LP = connexion.Query<PROPRIETAIRE>("SELECT PROPRIETAIRE.NOM_PRO,substr(DAT_DEP, 7, 9) || substr(DAT_DEP, 1, 2) || substr(DAT_DEP, 4, 2) AS DAT_DEP,substr(DAT_ARR,7,9)||substr(DAT_ARR,1,2)||substr(DAT_ARR,4,2) AS DAT_ARR FROM PROPRIETAIRE WHERE PROPRIETAIRE.NUM_LOT = ?", Lot);
                        NLP.AddRange(connexion.Query<PROPRIETAIRE>("SELECT PROPRIETAIRE.NOM_PRO FROM CHARGE INNER JOIN PROPRIETAIRE ON CHARGE.NUM_LOT = PROPRIETAIRE.NUM_LOT WHERE(PROPRIETAIRE.NUM_LOT = ? AND substr(DAT_CHA, 7, 9) || substr(DAT_CHA, 1, 2) || substr(DAT_CHA, 4, 2) < ? AND PROPRIETAIRE.NOM_PRO = ?)", Lot, LP[0].DAT_DEP, LP[0].NOM_PRO));
                        if(Nbr >= 3)
                        {
                            for (int i = 1; i < Nbr - 1; i++)
                            {
                                NLP.AddRange(connexion.Query<PROPRIETAIRE>("SELECT PROPRIETAIRE.NOM_PRO,substr(DAT_CHA, 7, 9) || substr(DAT_CHA, 1, 2) || substr(DAT_CHA, 4, 2) as tul FROM CHARGE INNER JOIN PROPRIETAIRE ON CHARGE.NUM_LOT = PROPRIETAIRE.NUM_LOT WHERE(PROPRIETAIRE.NUM_LOT =? AND substr(DAT_CHA, 7, 9) || substr(DAT_CHA, 1, 2) || substr(DAT_CHA, 4, 2) < ? AND PROPRIETAIRE.NOM_PRO = ? AND substr(DAT_CHA, 7, 9) || substr(DAT_CHA, 1, 2) || substr(DAT_CHA, 4, 2) >= ?) ORDER BY(substr(DAT_CHA,7,9)|| substr(DAT_CHA, 1, 2) || substr(DAT_CHA, 4, 2))",Lot,LP[i].DAT_DEP,LP[i].NOM_PRO,LP[i].DAT_ARR));

                        }
                        }
                        NLP.AddRange(connexion.Query<PROPRIETAIRE>("SELECT PROPRIETAIRE.NOM_PRO FROM CHARGE INNER JOIN PROPRIETAIRE ON CHARGE.NUM_LOT = PROPRIETAIRE.NUM_LOT WHERE(PROPRIETAIRE.NUM_LOT = ? AND substr(DAT_ARR, 7, 9) || substr(DAT_ARR, 1, 2) || substr(DAT_ARR, 4, 2) < substr(DAT_CHA, 7, 9) || substr(DAT_CHA, 1, 2) || substr(DAT_CHA, 4, 2) AND PROPRIETAIRE.DAT_DEP =?) ORDER BY(substr(DAT_CHA,7,9)|| substr(DAT_CHA, 1, 2) || substr(DAT_CHA, 4, 2))", Lot, ""));
                    }
                    else
                    {
                        NLP.AddRange(connexion.Query<PROPRIETAIRE>("SELECT PROPRIETAIRE.NOM_PRO FROM CHARGE INNER JOIN PROPRIETAIRE ON CHARGE.NUM_LOT = PROPRIETAIRE.NUM_LOT WHERE(CHARGE.NUM_LOT = ?)", Lot));
                    }
                }

                //NLP.AddRange(connexion.Query<PROPRIETAIRE>("SELECT PROPRIETAIRE.NOM_PRO FROM CHARGE INNER JOIN PROPRIETAIRE ON CHARGE.NUM_LOT = PROPRIETAIRE.NUM_LOT WHERE PROPRIETAIRE.NUM_LOT=? AND substr(DAT_DEP,7,9)||substr(DAT_DEP,1,2)||substr(DAT_DEP,4,2) > substr(DAT_CHA,7,9)||substr(DAT_CHA,1,2)||substr(DAT_CHA,4,2) ORDER BY (substr(DAT_CHA,7,9)||substr(DAT_CHA,1,2)||substr(DAT_CHA,4,2))", Lot));
                return NLP;
            }
        }


        public List<PROPRIETAIRE> SelectProByChaYear(string NumYear)
        {
            using (var connexion = connect.ConnexionFileBDD())
            {
                LP.Clear();
                LP = connexion.Query<PROPRIETAIRE>("SELECT PROPRIETAIRE.NOM_PRO FROM CHARGE INNER JOIN PROPRIETAIRE ON CHARGE.NUM_LOT = PROPRIETAIRE.NUM_LOT WHERE SUBSTR(DAT_CHA,7,4) =? AND PROPRIETAIRE.DAT_DEP=? ORDER BY(substr(DAT_CHA,8,11)||substr(DAT_CHA,1,2)||substr(DAT_CHA,4,2))", NumYear,"");
                return LP;
            }
        }


        public string UpdatePro(string nompro, string Datearr, string datesor)
        {
            using (var connexion = connect.ConnexionFileBDD())
            {
                string result = "e";
                LP = SelectProByLotDatDep();
                if (LP.Count() != 0)
                {
                    for (int i = 0; i < LP.Count(); i++)
                    {
                        if (LP[i].NOM_PRO == nompro)
                        {
                            PROPRIETAIRE CurrentPro = LP[i];
                                CurrentPro.DAT_ARR = Datearr;
                                CurrentPro.DAT_DEP = datesor;
                                connexion.Update(CurrentPro);
                            result = "Propriétaire : " + nompro + " a été enregistré";
                            return result;
                        }
                    }
                    return "Aucun propriétaire de ce Nom trouvé.";
                }
                else
                {
                    result = "Aucuns propriétaires trouvés (voir avec l'administrateur de la base de donnée).";
                    return result;
                }
            }
        }

        public string InsertPro(string NomNewPro,string NUMlot,string DateArr)
        {
            int resultatparse = int.Parse(NUMlot);
            using (var connexion = connect.ConnexionFileBDD())
            {
                string result = "";
                PROPRIETAIRE CurrentPro = new PROPRIETAIRE();
                CurrentPro.NOM_PRO = NomNewPro;
                CurrentPro.DAT_ARR = DateArr;
                CurrentPro.NUM_LOT = resultatparse;
                CurrentPro.DAT_DEP = "";
                connexion.Insert(CurrentPro);
                result = "Propriétaire : " + NomNewPro + " a été enregistré";
                return result;
            }
        }
        public string UpdateNomPro(string NomProOld, string NewNomPro)
        {
            using (var connexion = connect.ConnexionFileBDD())
            {
                LP = SelectProByName(NomProOld);
                if (LP.Count() != 0)
                {
                    PROPRIETAIRE CurrentPro = LP[0];
                    CurrentPro.NOM_PRO = NewNomPro;
                    connexion.Update(CurrentPro);
                    return "Le nom du propriétaire à été modifié."; 
                }
                else
                {
                   string result = "Aucuns propriétaires trouvés (voir avec l'administrateur de la base de donnée).";
                    return result;
                }
            }
        }
    }
}
