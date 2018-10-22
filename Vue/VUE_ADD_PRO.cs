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
    public partial class VUE_ADD_PRO : Form
    {
        GereRequetes ControllerRq;
        public VUE_ADD_PRO(GereRequetes Controller1, string NumLot,string DateArr)
        {
            ControllerRq = Controller1;
            InitializeComponent();
            label2.Text = NumLot;
            label3.Text = DateArr;
        }

        private void VUE_ADD_PRO_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Nom.Text == "")
            {
                ControllerRq.AskInsertPro("PROPRIETAIRE NOM INCONNU", label2.Text, label3.Text); 
            }
            this.Hide();
            VUE_PRO op = new VUE_PRO(ControllerRq);
            op.Show();

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string result = ControllerRq.AskInsertPro(Nom.Text, label2.Text, label3.Text);
            MessageBox.Show(result, "Résultat de la sauvegarde", MessageBoxButtons.OK);
            this.Hide();
            VUE_PRO op = new VUE_PRO(ControllerRq);
            op.Show();
        }

        private void VUE_ADD_PRO_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Nom.Text == "")
            {
                ControllerRq.AskInsertPro("PROPRIETAIRE NOM INCONNU", label2.Text, label3.Text);
            }
        }
    }
}
