using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetHameau.Model;
using ProjetHameau.Vue;
using ProjetHameau.Controller;
using Microsoft.VisualBasic;


namespace ProjetHameau.Vue
{
    public partial class VUE_PRO : Form
    {
        GereRequetes ControllerRq;
        List<LOT> LL = new List<LOT>();
        List<PROPRIETAIRE> LP = new List<PROPRIETAIRE>();

        public VUE_PRO(GereRequetes Controller1)
        {
            ControllerRq = Controller1;
            InitializeComponent();
            Autocomplettxtbox();
        }

        private void VUE_PRO_Load(object sender, EventArgs e)
        {
            LP = ControllerRq.AskProByLotDatDep();
            if (LP.Count() != 0)
            {
                for (int i = 0; i < LP.Count(); i++)
                {
                    ListViewItem Pro = new ListViewItem(LP[i].NUM_LOT.ToString());
                    Pro.SubItems.Add(LP[i].NOM_PRO);
                    Pro.SubItems.Add(LP[i].DAT_ARR);
                    Pro.SubItems.Add(LP[i].DAT_DEP);
                    ListPro.Items.Add(Pro);
                }
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {
            LP = ControllerRq.AskProByLotDatDep();
            if (LP.Count() != 0)
            {
                for (int i = 0; i < LP.Count(); i++)
                {
                    if(LP[i].NOM_PRO == Protxt.Text)
                    {
                        textBox1.Visible = true;
                        textBox2.Visible = true;
                        button1.Visible = true;
                        button5.Visible = true;
                        label4.Text = LP[i].NOM_PRO;
                        textBox1.Text = LP[i].DAT_ARR;
                        textBox2.Text = LP[i].DAT_DEP;
                    }
                }
            }
        }
        void Autocomplettxtbox()
        {
            LP = ControllerRq.AskProByLotDatDep();
            AutoCompleteStringCollection str = new AutoCompleteStringCollection();
            for (int i = 0; i < LP.Count(); i++)
            {
                str.Add(LP[i].NOM_PRO);
            }
            Protxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            Protxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            Protxt.AutoCompleteCustomSource = str;
        }

        private void Protxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string affichage; 
            LP = ControllerRq.AskProByLotDatDep();
            DateTime date = new DateTime();
            bool testDateA = DateTime.TryParse(textBox1.Text, out date);
            bool testDateB = DateTime.TryParse(textBox2.Text, out date);
            if (LP.Count() != 0)
            {
                for(int i = 0; i < LP.Count(); i++)
                {
                    if(LP[i].NOM_PRO == Protxt.Text)
                    {
                        if(textBox1.Text != LP[i].DAT_ARR && textBox2.Text == LP[i].DAT_DEP)
                        {
                            if(testDateA == true)
                            {
                                string result = Interaction.InputBox("Entrez le mot de passe administrateur", "Vérification", " ", -1, -1);
                                M_D_P mdp = new M_D_P();
                                string Motdepasse = mdp.GetMDP();
                                if (result != "")
                                {
                                    if (Motdepasse == result)
                                    {
                                        affichage = ControllerRq.AskUpdatePro(LP[i].NOM_PRO, textBox1.Text, textBox2.Text);
                                        MessageBox.Show(affichage, "Résultat de la sauvegarde", MessageBoxButtons.OK);
                                        break;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Pour une modification de données senssible (date d'arrivée) le mot de passe administrateur doit être saisie correctement.", "Erreur de mot de passe", MessageBoxButtons.OK);
                                    }
                                }
                                break;
                            }
                            else
                            {
                                MessageBox.Show("La date que vous avez saisie n'est pas au format JJ/MM/AAA");
                            }
                        }

                        if (textBox1.Text == LP[i].DAT_ARR && textBox2.Text != LP[i].DAT_DEP)
                        {
                            if(LP[i].DAT_DEP == "")
                            {
                                if(testDateB == true)
                                {
                                    affichage = ControllerRq.AskUpdatePro(LP[i].NOM_PRO, textBox1.Text, textBox2.Text);
                                    MessageBox.Show(affichage, "Résultat de la sauvegarde", MessageBoxButtons.OK);
                                    this.Hide();
                                    VUE_ADD_PRO op = new VUE_ADD_PRO(ControllerRq, LP[i].NUM_LOT.ToString(), textBox2.Text);
                                    op.Show();
                                    break;
                                }
                                else
                                {
                                    MessageBox.Show("La date que vous avez saisie n'est pas au format JJ/MM/AAA");
                                }
                            }
                            else
                            {
                                if (testDateB == true)
                                {
                                    string result = Interaction.InputBox("Entrez le mot de passe administrateur", "Vérification", "", -1, -1);
                                    M_D_P mdp = new M_D_P();
                                    string Motdepasse = mdp.GetMDP();
                                    if (result != "")
                                    {
                                        if (Motdepasse == result)
                                        {
                                            affichage = ControllerRq.AskUpdatePro(LP[i].NOM_PRO, textBox1.Text, textBox2.Text);
                                            MessageBox.Show(affichage, "Résultat de la sauvegarde", MessageBoxButtons.OK);
                                            break;
                                        }
                                    }
                                    break;
                                }
                                else
                                {
                                    MessageBox.Show("La date que vous avez saisie n'est pas au format JJ/MM/AAA");
                                }

                            }
                        }

                        if (textBox1.Text != LP[i].DAT_ARR && textBox2.Text != LP[i].DAT_DEP)
                        {
                            if(testDateA == true && testDateB == true)
                            {
                                string result = Interaction.InputBox("Entrez le mot de passe administrateur", "Vérification", " ", -1, -1);
                                M_D_P mdp = new M_D_P();
                                string Motdepasse = mdp.GetMDP();
                                if (result != "")
                                {
                                    if (Motdepasse == result)
                                    {
                                        affichage = ControllerRq.AskUpdatePro(LP[i].NOM_PRO, textBox1.Text, textBox2.Text);
                                        MessageBox.Show(affichage, "Résultat de la sauvegarde", MessageBoxButtons.OK);
                                        if(LP[i].DAT_DEP == "")
                                        {
                                            this.Hide();
                                            VUE_ADD_PRO op = new VUE_ADD_PRO(ControllerRq, LP[i].NUM_LOT.ToString(),textBox2.Text);
                                            op.Show();
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Pour une modification de données senssible (date d'arrivée et date de sortie) le mot de passe administrateur doit être inséré correctement.", "Erreur de mot de passe", MessageBoxButtons.OK);
                                    }
                                }
                                break;
                            }
                            else
                            {
                                MessageBox.Show("La date que vous avez saisie n'est pas au format JJ/MM/AAA");
                            }
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Acceuil op = new Acceuil(ControllerRq);
            op.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            VUE_MOD_PRO op = new VUE_MOD_PRO(label4.Text,ControllerRq);
            op.Show(); 
        }
    }
}

