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
    public partial class VUE_MOD_CRE : Form
    {
        List<CREANCIER> LC = new List<CREANCIER>();
        GereRequetes ControllerRq;

        public VUE_MOD_CRE(GereRequetes Controller1)
        {
            ControllerRq = Controller1;
            InitializeComponent();
        }

        private void VUE_MOD_CRE_Load(object sender, EventArgs e)
        {
            LC = ControllerRq.AskAllCre();
            if (LC.Count != 0)
            {
                SelectCre.Items.Clear();
                for (int i = 0; i < LC.Count(); i++)
                {
                    string result = " " + LC[i].NUM_CRE.ToString() + " | " + LC[i].NOM_CRE;
                    SelectCre.Items.Add(result);
                }
            }
        }

        private void SelectCre_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = SelectCre.SelectedIndex + 1;
            LC = ControllerRq.AskAllCre();
            if(LC.Count() != 0)
            {
                for(int i = 0; i < LC.Count(); i++)
                {
                    if(index == LC[i].NUM_CRE)
                    {
                        Nom.Text = LC[i].NOM_CRE;
                        Rue.Text = LC[i].RUE_CRE;
                        CP.Text = LC[i].POSTAL_CRE;
                        Ville.Text = LC[i].VILLE_CRE;
                        zip.Text = LC[i].ZIP_CRE;
                        Tel.Text = LC[i].TEL_CRE;
                        Contrat.Text = LC[i].CONTRAT1_CRE;
                    }
                }
            }
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            VUE_CRE op = new VUE_CRE(ControllerRq);
            op.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
