using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using SQLite;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetHameau.Model
{
    public class CHARGE
    {
        List<TRIMESTRE> LT = new List<TRIMESTRE>();
        List<CHARGE> LC = new List<CHARGE>();
        List<PROPRIETAIRE> LP = new List<PROPRIETAIRE>(); 
        
        ConnexionBDD connect = new ConnexionBDD();

        [PrimaryKey, AutoIncrement]
        public int NUM_CHA { get; set; }
        public string LIB_CHA { get; set; }
        public string MNT_CHA { get; set; }
        public string DAT_CHA { get; set; }
        public string MNT_PAI { get; set; }
        public string DAT_PAI { get; set; }
        public string ID_PAI { get; set; }
        public string COD_PAI { get; set; }
        public string test { get; set; }

        [ForeignKey("LOT")]
        public int NUM_LOT { get; set; }

        public List<CHARGE> SelectAllCha()
        {
            using (var connexion = connect.ConnexionFileBDD())
            {
                LC = connexion.Query<CHARGE>("SELECT CHARGE.NUM_CHA,CHARGE.NUM_LOT,CHARGE.LIB_CHA,CHARGE.MNT_CHA,CHARGE.DAT_CHA,CHARGE.MNT_PAI,CHARGE.DAT_PAI,CHARGE.COD_PAI,CHARGE.ID_PAI FROM  CHARGE INNER JOIN PROPRIETAIRE ON CHARGE.NUM_LOT = PROPRIETAIRE.NUM_LOT WHERE PROPRIETAIRE.DAT_DEP =? ORDER BY  (substr(DAT_CHA,7,9)||substr(DAT_CHA,1,2)||substr(DAT_CHA,4,2))", "");
                return LC;
            }
        }

        public List<CHARGE> SelectChaByNom(string Nompro)
        {
            using (var connexion = connect.ConnexionFileBDD())
            {
                LC.Clear();
                LP.Clear();
                LP = connexion.Query<PROPRIETAIRE>("SELECT PROPRIETAIRE.NOM_PRO, substr(DAT_ARR,7,9)||substr(DAT_ARR,1,2)||substr(DAT_ARR,4,2) AS DAT_ARR,substr(DAT_DEP,7,9)||substr(DAT_DEP,1,2)||substr(DAT_DEP,4,2) AS DAT_DEP,PROPRIETAIRE.NUM_LOT FROM PROPRIETAIRE WHERE PROPRIETAIRE.NOM_PRO =?", Nompro);
                if (LP.Count() != 0)
                {
                    if (LP[0].DAT_DEP == "")
                    {
                        LC = connexion.Query<CHARGE>("SELECT CHARGE.NUM_CHA,CHARGE.NUM_LOT,CHARGE.LIB_CHA,CAST(CHARGE.MNT_CHA AS CHAR) AS MNT_CHA,CHARGE.DAT_CHA,CAST(CHARGE.MNT_PAI AS CHAR) AS MNT_PAI,CHARGE.DAT_PAI,CHARGE.COD_PAI,CHARGE.ID_PAI FROM CHARGE INNER JOIN PROPRIETAIRE ON CHARGE.NUM_LOT = PROPRIETAIRE.NUM_LOT WHERE ((CHARGE.NUM_LOT = ?) AND (substr(DAT_CHA,7,9)||substr(DAT_CHA,1,2)||substr(DAT_CHA,4,2) > ?) AND PROPRIETAIRE.NOM_PRO = ?)", LP[0].NUM_LOT.ToString(), LP[0].DAT_ARR, LP[0].NOM_PRO);
                    }
                    else
                    {
                        LC = connexion.Query<CHARGE>("SELECT CHARGE.NUM_CHA,CHARGE.NUM_LOT,CHARGE.LIB_CHA,CHARGE.DAT_CHA,CHARGE.MNT_PAI,CHARGE.DAT_PAI,CHARGE.COD_PAI,CHARGE.ID_PAI FROM CHARGE INNER JOIN PROPRIETAIRE ON CHARGE.NUM_LOT = PROPRIETAIRE.NUM_LOT WHERE (CHARGE.NUM_LOT = ? AND  (substr(DAT_CHA,7,9)||substr(DAT_CHA,1,2)||substr(DAT_CHA,4,2) >=?)  AND  (substr(DAT_CHA,7,9)||substr(DAT_CHA,1,2)||substr(DAT_CHA,4,2) <= ?) AND PROPRIETAIRE.NOM_PRO = ?)", LP[0].NUM_LOT.ToString(), LP[0].DAT_ARR, LP[0].DAT_DEP, LP[0].NOM_PRO);
                    }
                }
                return LC;
            }
        }

        public List<CHARGE> SelectChaByLot(int NumLot)
        {
            using (var connexion = connect.ConnexionFileBDD())
            {
                LC.Clear();
                LC = connexion.Query<CHARGE>("SELECT CHARGE.NUM_CHA,CHARGE.NUM_LOT,CHARGE.LIB_CHA,CAST(CHARGE.MNT_CHA AS CHAR) AS MNT_CHA,CHARGE.DAT_CHA,CAST(CHARGE.MNT_PAI AS CHAR) AS MNT_PAI,CHARGE.DAT_PAI,CHARGE.COD_PAI,CHARGE.ID_PAI FROM  CHARGE INNER JOIN PROPRIETAIRE ON CHARGE.NUM_LOT = PROPRIETAIRE.NUM_LOT WHERE PROPRIETAIRE.NUM_LOT =? AND PROPRIETAIRE.DAT_DEP=? ORDER BY (substr(DAT_CHA,7,9)||substr(DAT_CHA,1,2)||substr(DAT_CHA,4,2))", NumLot,"" );
                return LC;
            }
        }

        public List<CHARGE> SelectChaByYear(string NumYear)
        {
            using (var connexion = connect.ConnexionFileBDD())
            {
                LC.Clear();
                LC = connexion.Query<CHARGE>("SELECT CHARGE.NUM_CHA, CHARGE.NUM_LOT,CHARGE.LIB_CHA,CHARGE.MNT_CHA,CHARGE.DAT_CHA,CHARGE.MNT_PAI,CHARGE.DAT_PAI,CHARGE.COD_PAI,CHARGE.ID_PAI FROM CHARGE INNER JOIN PROPRIETAIRE ON CHARGE.NUM_LOT = PROPRIETAIRE.NUM_LOT WHERE  SUBSTR(CHARGE.DAT_CHA,7,4)=?  ORDER BY (substr(DAT_CHA,7,9)||substr(DAT_CHA,1,2)||substr(DAT_CHA,4,2))", "", NumYear);
                return LC;
            }
        }

        public List<CHARGE> SelectYearCha()
        {
            using (var connexion = connect.ConnexionFileBDD())
            {
                LC.Clear();
                LC = connexion.Query<CHARGE>("SELECT SUBSTR(CHARGE.DAT_CHA,7) as DAT_CHA FROM  CHARGE group by SUBSTR(CHARGE.DAT_CHA,7,4)");
                return LC;
            }
        }

        public List<CHARGE> SelectOneYear(string Year)
        {
            using (var connexion = connect.ConnexionFileBDD())
            {
                LC.Clear();
                LC = connexion.Query<CHARGE>("SELECT CHARGE.NUM_CHA,CHARGE.NUM_LOT,CHARGE.LIB_CHA,CHARGE.MNT_CHA,CHARGE.DAT_CHA,CHARGE.MNT_PAI,CHARGE.DAT_PAI,CHARGE.COD_PAI,CHARGE.ID_PAI FROM CHARGE INNER JOIN PROPRIETAIRE ON CHARGE.NUM_LOT = PROPRIETAIRE.NUM_LOT WHERE (PROPRIETAIRE.DAT_DEP = ? AND SUBSTR(CHARGE.DAT_CHA,7,4)= ? )", "", Year);
                return LC;
            }
        }


        public List<CHARGE> SelectOneCha(string num)
        {
            int result = int.Parse(num);
            LC.Clear();
            using (var connexion = connect.ConnexionFileBDD())
            {
                LC = connexion.Query<CHARGE>("SELECT * FROM CHARGE WHERE NUM_CHA =?",result);
                return LC;
            }
        }

        public List<CHARGE> SelectChaForAlert()
        {
            LC.Clear();
            using (var connexion = connect.ConnexionFileBDD())
            {
                LC = connexion.Query<CHARGE>("SELECT SUM(CHARGE.MNT_CHA) - SUM(CHARGE.MNT_PAI) as MNT_PAI, 3 * CHARGE.MNT_CHA as MNT_CHA, CHARGE.NUM_LOT FROM CHARGE INNER JOIN PROPRIETAIRE ON PROPRIETAIRE.NUM_LOT = CHARGE.NUM_LOT GROUP BY CHARGE.NUM_LOT");
                if(LC.Count() != 0)
                {
                    for(int i = 0; i < LC.Count() ; i++)
                    {
                        if(double.Parse(LC[i].MNT_PAI.Replace('.',',')) < double.Parse(LC[i].MNT_CHA.Replace('.', ',')))
                        {
                            LC.RemoveAt(i);
                            i = -1;
                        }
                    }
                }
                return LC;
            }
        }
        public List<CHARGE> SelectChaForallAlert()
        {
            LC.Clear();
            using (var connexion = connect.ConnexionFileBDD())
            {
                LC = connexion.Query<CHARGE>("SELECT SUM(CHARGE.MNT_CHA) - SUM(CHARGE.MNT_PAI) as MNT_PAI, 3 * CHARGE.MNT_CHA as MNT_CHA, CHARGE.NUM_LOT FROM CHARGE INNER JOIN PROPRIETAIRE ON PROPRIETAIRE.NUM_LOT = CHARGE.NUM_LOT GROUP BY CHARGE.NUM_LOT");
                return LC;
            }
        }
        public List<CHARGE> SelectChaByNoDatPai(string NumLot)
        {
            using (var connexion = connect.ConnexionFileBDD())
            {
                LC.Clear(); 
                LC = connexion.Query<CHARGE>("SELECT * FROM CHARGE WHERE CHARGE.DAT_PAI =? AND CHARGE.NUM_LOT =?", "", NumLot);
                return LC;
            }
        }

        public string updateCha(string numcha, string DateVal, double montant, string LibPai, string Numcheque)
        {
            using (var connexion = connect.ConnexionFileBDD())
            {
                LC = SelectOneCha(numcha);
                if (LC.Count != 0)
                {
                    CHARGE CurCha = LC[0];
                    CurCha.DAT_PAI = DateVal;
                    CurCha.MNT_PAI = montant.ToString();
                    CurCha.COD_PAI = LibPai;
                    CurCha.ID_PAI = Numcheque;
                    connexion.Update(CurCha);
                    return "La chage à bien été modifiée."; 
                }
                return "Impossible d'accéder à cette charge.";
            }          
        }
    }
}
