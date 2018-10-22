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
using ProjetHameau.Model;


namespace ProjetHameau.Vue
{


    public partial class VUE_ADD_CRE : Form
    {
        List<CREANCIER> LC = new List<CREANCIER>();
        GereRequetes ControllerRq;

        public VUE_ADD_CRE(GereRequetes Controller1)
        {
            ControllerRq = Controller1; 
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            VUE_CRE op = new VUE_CRE(ControllerRq);
            op.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string result = ControllerRq.AskAddCre(Nom.Text, Rue.Text, CP.Text, Ville.Text, zip.Text, Tel.Text, Contrat.Text);
            MessageBox.Show(result, "Demmande d'ajout", MessageBoxButtons.OK); 
        }

        private void VUE_ADD_CRE_Load(object sender, EventArgs e)
        {

        }
    }
}
