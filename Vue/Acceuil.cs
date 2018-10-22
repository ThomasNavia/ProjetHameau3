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
using SQLite;
using ProjetHameau.Vue;

namespace ProjetHameau.Vue
{
    public partial class Acceuil : Form
    {
        GereRequetes ControllerRq;
        public Acceuil(GereRequetes Controller1)
        {
            ControllerRq = Controller1;
            InitializeComponent();
            Application.ApplicationExit += new EventHandler(ControllerRq.OnApplicationExit);
        }

        private void Acceuil_Load(object sender, EventArgs e)
        {
            label1.Text = "AFUL Hameau du parc Trésorerie ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Lot op = new Lot(ControllerRq);
            op.Show(); 
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Lot op = new Lot(ControllerRq);
            op.Show();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            Lot op = new Lot(ControllerRq);
            op.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            VUE_CRE op = new VUE_CRE(ControllerRq);
            op.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            VUE_PRO op = new VUE_PRO(ControllerRq);
            op.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            VUE_TRIMESTRE op = new VUE_TRIMESTRE(ControllerRq);
            op.Show();

        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            VUE_CHARGE op = new VUE_CHARGE(ControllerRq);
            op.Show(); 
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            VUE_ALERT_CHA op = new VUE_ALERT_CHA(ControllerRq);
            op.Show(); 
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            VUE_PROC op = new VUE_PROC();
            op.Show();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {

        }

        private void button13_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            VUE_CHARGE op = new VUE_CHARGE(ControllerRq);
            op.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            VUE_LISTE_EM op = new VUE_LISTE_EM(ControllerRq);
            op.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            VUE_PRINT_CHA op = new VUE_PRINT_CHA(ControllerRq);
            op.Show();
        }
    }
}
