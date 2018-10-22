using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetHameau.Model
{

    public class LOT //Définition de la class LOT
    {
        [PrimaryKey, AutoIncrement] //Clé primaire de la class (NUM_LOT)
        public int NUM_LOT { get; set; } //Entier pour le numéro de lot
        public string ADRESSE { get; set; } // Chaine de caractère pour l'adresse

        [ForeignKey("TYP_PART")] 
        public int COD_PART { get; set; } // Entier pour le type de Lot

        List<LOT> LL = new List<LOT>();
        ConnexionBDD connect = new ConnexionBDD();


        public List<LOT> SelectAllLot()
        {   //{#1} connexion à la base de données 
            using (var connexion = connect.ConnexionFileBDD())
            {
                //{#2} Déclaration d'une liste de LOT
                List<LOT> ListeLot = new List<LOT>();

                //{#3} implémentation de la liste via la base de données
                ListeLot = connexion.Query<LOT>("SELECT * FROM LOT");

                //{#4}renvoie de la liste
                return ListeLot; 
            }
        }
        public List<LOT> SelectAllLot121()
        {
            using (var connexion = connect.ConnexionFileBDD())
            {
                LL = connexion.Query<LOT>("SELECT * FROM LOT WHERE COD_PART=?", 121);
                return LL;
            }
        }
        public List<LOT> SelectAllLot123()
        {
            using (var connexion = connect.ConnexionFileBDD())
            {
                LL = connexion.Query<LOT>("SELECT * FROM LOT WHERE COD_PART=?", 123);
                return LL;
            }
        }
        public List<LOT> SelectAllLot126()
        {
            using (var connexion = connect.ConnexionFileBDD())
            {
                LL = connexion.Query<LOT>("SELECT * FROM LOT WHERE COD_PART=?", 126);
                return LL;
            }
        }
        public List<LOT> SelectAllLot129()
        {
            using (var connexion = connect.ConnexionFileBDD())
            {
                LL = connexion.Query<LOT>("SELECT * FROM LOT WHERE COD_PART=?", 129);
                return LL;
            }
        }
        public List<LOT> SelectOneLot(string numLot)
        {
            using (var connexion = connect.ConnexionFileBDD())
            {
                LL = connexion.Query<LOT>("SELECT * FROM LOT WHERE NUM_LOT=?", numLot);
                return LL;
            }
        }
    }
}
