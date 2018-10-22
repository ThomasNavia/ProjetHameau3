using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SQLite;

namespace ProjetHameau.Model
{
    class ConnexionBDD
    {
        public SQLiteConnection ConnexionFileBDD()
        {
            string path = System.Windows.Forms.Application.StartupPath;
            string fn = "HameauDuParc.db3";
            string filename = System.IO.Path.Combine(path, fn);
            var connexion = new SQLiteConnection(filename);
            return connexion;
        }
        public int ConnectionFirst()
        {
            string path = System.Windows.Forms.Application.StartupPath;
            string fn = "HameauDuParc.db3";
            string filename = System.IO.Path.Combine(path, fn);
            if (!System.IO.File.Exists(filename))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public int InitTables(SQLiteConnection Co)
        {
            var connect = new ConnexionBDD();
            using (var connexion = connect.ConnexionFileBDD())
            {
                return 0;
            }
        }
    }


}