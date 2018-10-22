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
using ProjetHameau.Model; 
using Microsoft.VisualBasic;

namespace ProjetHameau.Vue
{
    public partial class VUE_TRIMESTRE : Form
    {
        List<TRIMESTRE> LT = new List<TRIMESTRE>();  
        GereRequetes ControllerRq;
        DateTime year = DateTime.Today;
        string DateResult;
        public VUE_TRIMESTRE(GereRequetes Controller1)
        {
            ControllerRq = Controller1;
            InitializeComponent();
            UpdateDate();

        }

        private void VUE_TRIMESTRE_Load(object sender, EventArgs e)
        {
            LT = ControllerRq.AskAllTri();
            if (LT.Count() != 0)
            {
                for (int i = 0; i < LT.Count(); i++)
                {
                        ListViewItem lot = new ListViewItem(LT[i].COD_PART.ToString());
                        lot.SubItems.Add(LT[i].MNT_CHA.ToString());
                        lot.SubItems.Add(LT[i].DAT_PART);
                        ListLot.Items.Add(lot);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            label6.Text = string.Format(comboBox1.SelectedItem.ToString());
            label7.Text = string.Format(comboBox1.SelectedItem.ToString());
            label8.Text = string.Format(comboBox1.SelectedItem.ToString());
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            label16.Text = tb.Text;
            label17.Text = tb.Text;
            label18.Text = tb.Text;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = Interaction.InputBox("Entrez le montant pour les lots. (Pour les relatifs utiliser une virgule)", "Nouvelle valeure", "", -1, -1);
            if(result != "")
            {
               label12.Text = string.Format(result);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string result = Interaction.InputBox("Entrez le montant pour les lots. (Pour les relatifs utiliser une virgule)", "Nouvelle valeure", "", -1, -1);
            if (result != "")
            {
                label13.Text = string.Format(result);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string result = Interaction.InputBox("Entrez le montant pour les lots. (Pour les relatifs utiliser une virgule)", "Nouvelle valeure", "", -1, -1);
            if (result != "")
            {
                label14.Text = string.Format(result);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string result = Interaction.InputBox("Entrez le montant pour les lots. (Pour les relatifs utiliser une virgule)", "Nouvelle valeure", "", -1, -1);
            if (result != "")
            {
                label15.Text = string.Format(result);
            }

        }
        public void UpdateDate()
        {
            int resulttri = ControllerRq.AskTrimestre(year.Year);
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
                switch (resulttri)
                {
                    case 0:
                        if(year.Month >= 1)
                        {
                            comboBox1.Items.Add("1 Trimestre");
                            comboBox2.Items.Add(year.Year.ToString());
                        }
                        break;
                    case 4:
                        if (year.Month <= 3)
                        {
                            comboBox1.Items.Add("2 Trimestre");
                            comboBox2.Items.Add(year.Year.ToString());
                        }
                        break;
                    case 8:
                        if (year.Month >= 6)
                        {
                            comboBox1.Items.Add("3 Trimestre");
                            comboBox2.Items.Add(year.Year.ToString());
                        }
                        break;
                    case 12:
                        if (year.Month >= 9)
                        {
                            comboBox1.Items.Add("4 Trimestre");
                            comboBox2.Items.Add(year.Year.ToString());
                        }
                        break;
                    case 16:
                        if (year.Month >= 12)
                        {
                            int result = year.Year + 1;
                            comboBox2.Items.Add(result);
                            comboBox1.Items.Add("1 Trimestre");
                        } 
                        break;
                }
            
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            label16.Text = string.Format(comboBox2.SelectedItem.ToString());
            label17.Text = string.Format(comboBox2.SelectedItem.ToString());
            label18.Text = string.Format(comboBox2.SelectedItem.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {

            int Select1 = comboBox1.SelectedIndex;
            int Select2 = comboBox2.SelectedIndex;
            if(Select1 != -1 && Select2 != -1)
            {
                float Mnt121 = float.Parse(label12.Text);
                float Mnt123 = float.Parse(label13.Text);
                float Mnt126 = float.Parse(label14.Text);
                float Mnt129 = float.Parse(label15.Text);
                string Lib = label6.Text + " " + label16.Text;
                char[] Date1 = year.ToString().ToCharArray();
                for(int i = 0; i < 10; i++)
                {
                    DateResult += Date1[i];
                }
                string result = ControllerRq.AskAddTri(Mnt121, Mnt123, Mnt126, Mnt129, DateResult, Lib);

            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Acceuil op = new Acceuil(ControllerRq);
            op.Show(); 
        }
    }
}
