using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetHameau.Controller;

namespace ProjetHameau.Vue
{
    public partial class VUE_CLOSE : Form
    {
        int ValConnexion;
        int ValDateDay;
        public VUE_CLOSE(int ValCo, int ValDate)
        {
            InitializeComponent();
            ValConnexion = ValCo;
            ValDateDay = ValDate;
        }

        private void VUE_CLOSE_Load(object sender, EventArgs e)
        {
            if(ValDateDay == 0)
            {
                label1.Text += "La date de l'ordinateur doit être bien référencée pour utiliser ce logiciel.\r\n";

            }
            if(ValConnexion == 0)
            {
                label1.Text += "\r\n Impossible de se connecter à la base de donnée";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
