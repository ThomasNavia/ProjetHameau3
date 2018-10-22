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
    public partial class VUE_CHARGE : Form
    {
        List<CHARGE> LC = new List<CHARGE>();
        List<PROPRIETAIRE> LP = new List<PROPRIETAIRE>(); 
        GereRequetes ControllerRq;
        public VUE_CHARGE(GereRequetes Controller1)
        {
            InitializeComponent();
            ControllerRq = Controller1;
            Autocomplettxtbox();

        }

        private void ListLot_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void VUE_CHARGE_Load(object sender, EventArgs e)
        {

        }

        void Autocomplettxtbox()
        {
            LP = ControllerRq.AskProByLotDatDep();
            AutoCompleteStringCollection str = new AutoCompleteStringCollection();
            for (int i = 0; i < LP.Count(); i++)
            {
                str.Add(LP[i].NOM_PRO);
            }
            textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox2.AutoCompleteCustomSource = str;
        }
        public string Cacaboudin()
        {
            return "lermkvjhesmgiev";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListCha.Items.Clear();
            double resultat = 0;
            this.Hide();
            LP = ControllerRq.AskProByNom(textBox2.Text);
            LC = ControllerRq.AskChabyNom(textBox2.Text); 
            if(LC.Count() != 0 && LP.Count()!=0)
            {
                for (int i = 0; i < LC.Count(); i++)
                {

                    string remplacementCHA = LC[i].MNT_CHA.Replace(".", ",");
                    if (remplacementCHA == "")
                    {
                        remplacementCHA = "0";
                    }
                    double MontantCHA = Math.Round(double.Parse(remplacementCHA), 2);
                    string remplacementPAI = LC[i].MNT_PAI.Replace(".", ",");
                    if (remplacementPAI == "")
                    {
                        remplacementPAI = "0";
                    }
                    double MontantPAI = Math.Round(double.Parse(remplacementPAI), 2);


                    ListViewItem Charge = new ListViewItem(LC[i].NUM_CHA.ToString());
                    Charge.SubItems.Add(LC[i].NUM_LOT.ToString());
                    Charge.SubItems.Add(LP[0].NOM_PRO);
                    Charge.SubItems.Add(LC[i].DAT_CHA);
                    Charge.SubItems.Add(MontantCHA.ToString());
                    Charge.SubItems.Add(LC[i].DAT_PAI);
                    Charge.SubItems.Add(MontantPAI.ToString());
                    Charge.SubItems.Add(LC[i].COD_PAI);
                    Charge.SubItems.Add(LC[i].ID_PAI);
                    resultat += MontantPAI - MontantCHA; 
                    Charge.SubItems.Add(Math.Round(resultat,2).ToString());
                    ListCha.Items.Add(Charge);
                }
            }
            this.Show();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            List<CHARGE> NLC = new List<CHARGE>();
            double resultat = 0;
            if (textBox1.Text != "")
            {
                Int32 result;
                Int32.TryParse(textBox1.Text, out result);
                if (result <= 84 && result >= 1)
                {
                    ListCha.Items.Clear();
                    this.Hide();
                    LP.Clear();
                    LP = ControllerRq.AskProByChaLot(result.ToString());

                    NLC = ControllerRq.AskChabyLot(result);
                    if (NLC.Count() != 0 && LP.Count() != 0)
                    {
                        for (int i = 0; i < NLC.Count(); i++)
                        {

                            string remplacementCHA = NLC[i].MNT_CHA.Replace(".", ",");
                            if (remplacementCHA == "")
                            {
                                remplacementCHA = "0";
                            }
                            double MontantCHA = Math.Round(double.Parse(remplacementCHA), 2);
                            string remplacementPAI = NLC[i].MNT_PAI.Replace(".", ",");
                            if (remplacementPAI == "")
                            {
                                remplacementPAI = "0";
                            }
                            double MontantPAI = Math.Round(double.Parse(remplacementPAI), 2);
                            ListViewItem Charge = new ListViewItem(NLC[i].NUM_CHA.ToString());
                            Charge.SubItems.Add(NLC[i].NUM_LOT.ToString());
                            Charge.SubItems.Add(LP[i].NOM_PRO);
                            Charge.SubItems.Add(NLC[i].DAT_CHA);
                            Charge.SubItems.Add(MontantCHA.ToString());
                            Charge.SubItems.Add(NLC[i].DAT_PAI);
                            Charge.SubItems.Add(MontantPAI.ToString());
                            Charge.SubItems.Add(NLC[i].COD_PAI);
                            Charge.SubItems.Add(NLC[i].ID_PAI);
                            resultat += MontantPAI - MontantCHA;
                            Charge.SubItems.Add(Math.Round(resultat, 2).ToString());
                            ListCha.Items.Add(Charge);
                            if(i != LP.Count - 1  && LP[i+1].NOM_PRO != LP[i].NOM_PRO)
                            {
                                resultat = 0;
                            }
                        }
                    }
                    this.Show();
                }
            }

        }


        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Acceuil op = new Acceuil(ControllerRq);
            op.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            String num = ListCha.SelectedItems[0].SubItems[0].Text;
            String Name = ListCha.SelectedItems[0].SubItems[2].Text;
            VUE_MOD_CHA op = new VUE_MOD_CHA(ControllerRq,num,Name);
            op.Show();
        }
    }
}
