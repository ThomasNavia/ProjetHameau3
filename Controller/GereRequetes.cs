using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ProjetHameau.Model;
using System.IO;

namespace ProjetHameau.Controller
{
    public class GereRequetes
    {
        string path = System.Windows.Forms.Application.StartupPath;
        string fn = "DateGet.txt";
        LOT Lot = new LOT();
        PROPRIETAIRE Pro = new PROPRIETAIRE();
        CREANCIER Cre = new CREANCIER();
        TRIMESTRE Tri = new TRIMESTRE();
        CHARGE Cha = new CHARGE();

        List<LOT> LL = new List<LOT>();
        List<PROPRIETAIRE> LP = new List<PROPRIETAIRE>();
        List<CREANCIER> LC = new List<CREANCIER>();
        List<TRIMESTRE> LT = new List<TRIMESTRE>();
        List<CHARGE> LCC = new List<CHARGE>(); 

        public SQLiteConnection DemmandeDeConnexion()
        {
            Model.ConnexionBDD op = new Model.ConnexionBDD();
            return (op.ConnexionFileBDD());
        }
        public int DemmandeInitialisationTable(SQLiteConnection CO)
        {
            Model.ConnexionBDD rq = new Model.ConnexionBDD();
            rq.InitTables(CO);
            return 0;
        }

        public List<LOT> AskAllLot()
        {
            LL = Lot.SelectAllLot();
            return LL ;
        }
        public List<LOT> AskAllLot121()
        {
            LL = Lot.SelectAllLot121();
            return LL;
        }
        public List<LOT> AskAllLot123()
        {
            LL = Lot.SelectAllLot123();
            return LL;
        }
        public List<LOT> AskAllLot126()
        {
            LL = Lot.SelectAllLot126();
            return LL;
        }
        public List<LOT> AskAllLot129()
        {
            LL = Lot.SelectAllLot129();
            return LL;
        }

        public List<PROPRIETAIRE> AskAllProByLot()
        {
            LP = Pro.SelectProByLot();
            return LP;
        }
        public List<PROPRIETAIRE> AskProByLotDatDep()
        {
            LP = Pro.SelectProByLotDatDep();
            return LP;
        }
        public List<PROPRIETAIRE> AskAllProByLot121()
        {
            LP = Pro.SelectProByLot121();
            return LP;
        }

        public List<PROPRIETAIRE> AskAllProByLot123()
        {
            LP = Pro.SelectProByLot123();
            return LP;
        }
        public List<PROPRIETAIRE> AskAllProByLot126()
        {
            LP = Pro.SelectProByLot126();
            return LP;
        }
        public List<PROPRIETAIRE> AskAllProByLot129()
        {
            LP = Pro.SelectProByLot129();
            return LP;
        }
        public string AskUpdatePro(string nom, string DA, string DS)
        {
            string result = Pro.UpdatePro(nom, DA, DS);
            return result;
        }
        public string AskInsertPro(string nom, string Num, string DA)
        {
            string result = Pro.InsertPro(nom, Num, DA);
            return result;
        }

        public List<CREANCIER> AskAllCre()
        {
            LC = Cre.SelectAllCre();
            return LC; 
        }

        public string AskAddCre(string Nom, string Rue, string CP, string Ville, string zip, string Tel, string Contrat)
        {
            string result = Cre.AddCre(Nom, Rue, CP, Ville, zip, Tel, Contrat);
            return result;
        }
        public int AskTrimestre(int CurYear)
        {
            int result = Tri.TriByYear(CurYear);
            return result;
        }
        public int RefFichier()
        {
            string path = System.Windows.Forms.Application.StartupPath; //chemin du repertoire
            string fn = "DateGet.txt"; //nom du fichier 

            // {#1} Chemin de location du fichier stocké dans la variable filename
            string filename = System.IO.Path.Combine(path, fn);

            // {#2} Vérification si le fichier existe 
            if (System.IO.File.Exists(filename)) 
            { // si oui 

                using (var sr = new StreamReader(filename, true))
                {
                    // {#3} récupération de la date dans le fichier
                    string DateFichier = sr.ReadLine();

                    // {#4} conversion de la date du fichier en format Datetime
                    DateTime Date_A_Comparer = Convert.ToDateTime(DateFichier);

                    // {#5} récupération de la date du jour de l'ordinateur
                    DateTime DateDuJour = DateTime.Today;  

                    sr.Close();   //Fermeture du lecteur
                    sr.Dispose(); // libération de la mémoire

                    if (DateDuJour < Date_A_Comparer) //comparaison des deux dates 
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            else
            { // si non Création du fichier et écriture de la date à l'intérieur  
               
                using (var sw2 = new StreamWriter(filename, true))
                {

                    DateTime op = DateTime.Today; 
                    sw2.WriteLine(op.ToString());
                    sw2.Flush();
                    sw2.Close();
                    sw2.Dispose();
                    return 1;
                }
            }
        }
        public void OnApplicationExit(object sender, EventArgs e)
        {

            string path = System.Windows.Forms.Application.StartupPath;
            string fn = "DateGet.txt";

            // {#1} Chemin de location du fichier stocké dans la variable filename
            string filename = System.IO.Path.Combine(path, fn);

                // {#2} Définition d'un lecteur de fichier nommé Sr à partir de filename définie en {#2}
                using (var Sr = new StreamReader(filename, true))
                {
                    // {#3} stock la première ligne du fichier dans Maliste
                    string Malist = Sr.ReadLine(); 

                    // {#4} fermeture de la lecture du fichier
                    Sr.Close();

                    // {#5} Définition d'un écrivant pour le fichier 
                    StreamWriter Sw = new StreamWriter(filename);

                    // {#6} récupération de la date du jour
                    DateTime Today = DateTime.Today;

                    // {#7} écriture de la date dans le fichier
                    Sw.Write(Today.ToString());

                    Sw.Close();     //  Fermeture de l'écrivant
                    Sw.Dispose();   //  libération de la mémoire
                }
        }
        public int FirtTimeAskCo()
        {
            Model.ConnexionBDD op = new ConnexionBDD();
            int value = op.ConnectionFirst();
            return value; 
        }
        public string AskAddTri(float Mnt121, float Mnt123, float Mnt126, float Mnt129, string DatPart, string Libel)
        {
            string result = Tri.AddTri(Mnt121, Mnt123, Mnt126, Mnt129, DatPart, Libel);
            return result; 
        }

        public List<TRIMESTRE> AskAllTri()
        {
            return Tri.AllTri(); 
        }
        public string AskUpdateNomPro(string NomProOld , string NewNomPro)
        {
            return Pro.UpdateNomPro(NomProOld, NewNomPro);
        }
        public List<CHARGE> AskSelectAllCha()
        {
            return LCC = Cha.SelectAllCha(); 
        }
        public List<CHARGE> AskChabyNom(string nom)
        {
            return LCC = Cha.SelectChaByNom(nom); 
        }

        public List<CHARGE> AskChabyLot(int num)
        {
            return LCC = Cha.SelectChaByLot(num);
        }
        public List<CHARGE> AskChabyYeart(string num)
        {
            return LCC = Cha.SelectChaByYear(num);
        }
        public List<CHARGE> AskOneYearCha(string Year)
        {
            return LCC = Cha.SelectOneYear(Year);
        }
        public List<CHARGE> AskYearCha()
        {
            return LCC = Cha.SelectYearCha();
        }
        public List<CHARGE> AskOneCha(string num)
        {
            return LCC = Cha.SelectOneCha(num);
        }

        public List<PROPRIETAIRE> AskProByNom(string nom)
        {
            LP = Pro.SelectProByName(nom);
            return LP;
        }
        public string AskUpdateCha(string numcha,string DateVal,float montant, string LibPai,string Numcheque)
        { 
            return Cha.updateCha(numcha, DateVal, montant, LibPai, Numcheque);
        }
        public List<PROPRIETAIRE> AskOneProBylot(string numlot)
        {
            return Pro.SelectProByLotOne(numlot);
        }

        public List<PROPRIETAIRE> AskProByCha()
        {
            return Pro.SelectProByCha();
        }
        public List<PROPRIETAIRE> AskProByChaYear(string NumYear)
        {
            return Pro.SelectProByChaYear(NumYear);
        }
        public List<PROPRIETAIRE> AskProByChaLot(string NumLot)
        {
            return Pro.SelectProByLotCha(NumLot);
        }
        public List<CHARGE> AskChaForAlert()
        {
            return Cha.SelectChaForAlert();
        }
        public List<CHARGE> AskChaForallAlert()
        {
            return Cha.SelectChaForallAlert();
        }
        public List<LOT> AskOneLot(string num)
        {
            return Lot.SelectOneLot(num);
        }
        public List<CHARGE> AskChaByNoDatPai(string numlot)
        {
            return Cha.SelectChaByNoDatPai(numlot);
        }
    }
}
