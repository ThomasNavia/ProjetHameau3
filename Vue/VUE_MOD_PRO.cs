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
    public partial class VUE_MOD_PRO : Form
    {
        string nom;
        GereRequetes ControllerRq; 
        public VUE_MOD_PRO(string NomPro, GereRequetes Controller1)
        {
            InitializeComponent();
            nom = NomPro;
            ControllerRq = Controller1; 
        }

        private void VUE_MOD_PRO_Load(object sender, EventArgs e)
        {
            Nom.Text = nom; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(Nom.Text != "")
            {
                string result =  ControllerRq.AskUpdateNomPro(nom, Nom.Text);
                MessageBox.Show(result, "Résultat de la sauvegarde", MessageBoxButtons.OK);
                this.Hide();
                VUE_PRO op = new VUE_PRO(ControllerRq);
                op.Show(); 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            VUE_PRO op = new VUE_PRO(ControllerRq);
            op.Show(); 
        }
    }
}
