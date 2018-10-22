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
    public partial class VUE_CRE : Form
    {
        List<CREANCIER> LC = new List<CREANCIER>();
        GereRequetes ControllerRq; 

        public VUE_CRE(GereRequetes Controller1)
        {
            ControllerRq = Controller1; 
            InitializeComponent();
        }

        private void VUE_CRE_Load(object sender, EventArgs e)
        {
            LC = ControllerRq.AskAllCre();
            if (LC.Count() != 0)
            {
                for (int i = 0; i < LC.Count(); i++)
                {
                    ListViewItem Cre = new ListViewItem(LC[i].NUM_CRE.ToString());
                    Cre.SubItems.Add(LC[i].NOM_CRE);
                    Cre.SubItems.Add(LC[i].RUE_CRE.ToString());
                    Cre.SubItems.Add(LC[i].POSTAL_CRE);
                    Cre.SubItems.Add(LC[i].VILLE_CRE);
                    Cre.SubItems.Add(LC[i].ZIP_CRE);
                    Cre.SubItems.Add(LC[i].TEL_CRE);
                    Cre.SubItems.Add(LC[i].CONTRAT1_CRE);
                    ListCre.Items.Add(Cre);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Acceuil op = new Acceuil(ControllerRq);
            op.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            VUE_ADD_CRE op = new VUE_ADD_CRE(ControllerRq);
            op.Show(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            VUE_MOD_CRE op = new VUE_MOD_CRE(ControllerRq);
            op.Show();
        }
    }
}
