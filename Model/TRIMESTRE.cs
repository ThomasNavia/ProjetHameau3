using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetHameau.Model
{
    public class TRIMESTRE
    {
        List<TRIMESTRE> LT = new List<TRIMESTRE>();
        ConnexionBDD connect = new ConnexionBDD();

        [PrimaryKey, AutoIncrement]
        public int SEQ_TRI { get; set; }
        public float MNT_CHA { get; set; }
        public string DAT_PART { get; set; }

        [ForeignKey("TYP_PART")]
        public int COD_PART { get; set; }


        public int TriByYear(int CurYear)
        {
            using (var connexion = connect.ConnexionFileBDD())
            {
                string pourcent = "%/%/" + CurYear;
                LT = connexion.Query<TRIMESTRE>("select * from TRIMESTRE where TRIMESTRE.DAT_PART LIKE ?",pourcent);
                if(LT.Count() != 0)
                {
                    for(int i = 0; i < LT.Count(); i++)
                    {

                    }
                }
                if (LT.Count() != 0)
                {
                    switch (LT.Count())
                    {
                        case 4: return 4;
                        case 8: return 8;
                        case 12: return 12;
                        case 16: return 16;
                    }
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }
        public List<TRIMESTRE> AllTri()
        {
            using (var connexion = connect.ConnexionFileBDD())
            {

                LT = connexion.Query<TRIMESTRE>("select * from TRIMESTRE");
                return LT;
            }
        }

            public string AddTri(float Mnt121, float Mnt123, float Mnt126, float Mnt129, string DatPart, string Libel)
            {
                using (var connexion = connect.ConnexionFileBDD())
                {
                    TRIMESTRE CurTri = new TRIMESTRE();
                    CurTri.DAT_PART = DatPart;
                    for (int i = 0; i < 4; i++)
                    {
                        if (i == 0)
                        {
                            CurTri.COD_PART = 121;
                            CurTri.MNT_CHA = Mnt121;
                        }
                        if (i == 1)
                        {
                            CurTri.COD_PART = 123;
                            CurTri.MNT_CHA = Mnt123;
                        }
                        if (i == 2)
                        {
                            CurTri.COD_PART = 126;
                            CurTri.MNT_CHA = Mnt126;
                        }
                        if (i == 3)
                        {
                            CurTri.COD_PART = 129;
                            CurTri.MNT_CHA = Mnt129;
                        }
                        connexion.Insert(CurTri);

                        string sql = "INSERT INTO CHARGE(NUM_LOT, LIB_CHA, MNT_CHA, DAT_CHA) ";
                        sql = sql + "SELECT LOT.NUM_LOT ,?,?,? ";
                        sql = sql + "FROM LOT INNER JOIN TRIMESTRE ON LOT.COD_PART = TRIMESTRE.COD_PART ";
                        sql = sql + "where TRIMESTRE.COD_PART = ? ";
                        sql = sql + "group by NUM_LOT";

                        connexion.Execute(sql, Libel, CurTri.MNT_CHA.ToString(), DatPart, CurTri.COD_PART.ToString());


                    }
                    return "0";
                }
            }
        }
}
