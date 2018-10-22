using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetHameau.Controller;
using ProjetHameau.Vue;
using System.IO; 

namespace ProjetHameau
{
    class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]



        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GereRequetes ControllerRq = new GereRequetes();
            int result2 = ControllerRq.FirtTimeAskCo();
            int result = ControllerRq.RefFichier();
            if(result == 1 && result2 == 1)
            {
                Application.Run(new Acceuil(ControllerRq));
            }
            else
            {
                Application.Run(new VUE_CLOSE(result2,result));
            }


        }
        
    }
}
