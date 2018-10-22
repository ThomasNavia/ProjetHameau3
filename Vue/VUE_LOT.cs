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
using ProjetHameau.Vue;

namespace ProjetHameau.Vue
{
    public partial class Lot : Form
    {
        GereRequetes ControllerRq;
        List<LOT> LL = new List<LOT>();
        List<PROPRIETAIRE> LP = new List<PROPRIETAIRE>();

        public Lot(GereRequetes Controller1)
        {
            ControllerRq = Controller1; 
            InitializeComponent();
            Autocomplettxtbox();
        }

        private void VUE_LOT_Load(object sender, EventArgs e)
        {
            LL = ControllerRq.AskAllLot();
            LP = ControllerRq.AskAllProByLot();
            if(LL.Count() != 0)
            {
                for(int i = 0; i < LL.Count(); i++)
                {
                    if (LL[i].NUM_LOT == LP[i].NUM_LOT)
                    {
                        ListViewItem lot = new ListViewItem(LL[i].NUM_LOT.ToString());
                        lot.SubItems.Add(LL[i].ADRESSE);
                        lot.SubItems.Add(LL[i].COD_PART.ToString());
                        lot.SubItems.Add(LP[i].NOM_PRO);
                        ListLot.Items.Add(lot);
                    }
                    
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListLot.Items.Clear();
            this.Show();
            LL = ControllerRq.AskAllLot123();
            LP = ControllerRq.AskAllProByLot123();
            if(LL.Count() != 0)
            {
                for (int i = 0; i < LL.Count(); i++)
                {
                    ListViewItem lot = new ListViewItem(LL[i].NUM_LOT.ToString());
                    lot.SubItems.Add(LL[i].ADRESSE);
                    lot.SubItems.Add(LL[i].COD_PART.ToString());
                    lot.SubItems.Add(LP[i].NOM_PRO);
                    ListLot.Items.Add(lot);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListLot.Items.Clear();
            this.Show();
            LL = ControllerRq.AskAllLot126();
            LP = ControllerRq.AskAllProByLot126();
            if (LL.Count() != 0)
            {
                for (int i = 0; i < LL.Count(); i++)
                {
                    ListViewItem lot = new ListViewItem(LL[i].NUM_LOT.ToString());
                    lot.SubItems.Add(LL[i].ADRESSE);
                    lot.SubItems.Add(LL[i].COD_PART.ToString());
                    lot.SubItems.Add(LP[i].NOM_PRO);
                    ListLot.Items.Add(lot);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListLot.Items.Clear();
            this.Show();
            LL = ControllerRq.AskAllLot129();
            LP = ControllerRq.AskAllProByLot129();
            if (LL.Count() != 0)
            {
                for (int i = 0; i < LL.Count(); i++)
                {
                    ListViewItem lot = new ListViewItem(LL[i].NUM_LOT.ToString());
                    lot.SubItems.Add(LL[i].ADRESSE);
                    lot.SubItems.Add(LL[i].COD_PART.ToString());
                    lot.SubItems.Add(LP[i].NOM_PRO);
                    ListLot.Items.Add(lot);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListLot.Items.Clear();
            this.Show();
            LL = ControllerRq.AskAllLot();
            LP = ControllerRq.AskAllProByLot();
            if (LL.Count() != 0)
            {
                for (int i = 0; i < LL.Count(); i++)
                {
                    ListViewItem lot = new ListViewItem(LL[i].NUM_LOT.ToString());
                    lot.SubItems.Add(LL[i].ADRESSE);
                    lot.SubItems.Add(LL[i].COD_PART.ToString());
                    lot.SubItems.Add(LP[i].NOM_PRO);
                    ListLot.Items.Add(lot);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListLot.Items.Clear();
            this.Show();
            LL = ControllerRq.AskAllLot121();
            LP = ControllerRq.AskAllProByLot121();
            if (LL.Count() != 0)
            {
                for (int i = 0; i < LL.Count(); i++)
                {
                    ListViewItem lot = new ListViewItem(LL[i].NUM_LOT.ToString());
                    lot.SubItems.Add(LL[i].ADRESSE);
                    lot.SubItems.Add(LL[i].COD_PART.ToString());
                    lot.SubItems.Add(LP[i].NOM_PRO);
                    ListLot.Items.Add(lot);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(Protxt.Text != "")
            {
                int set = 0;
                LL = ControllerRq.AskAllLot();
                LP = ControllerRq.AskAllProByLot();
                for(int i = 0; i < LP.Count(); i++)
                {
                    if(Protxt.Text == LP[i].NOM_PRO)
                    {
                        this.Hide();
                        ListLot.Items.Clear();
                        this.Show();
                        ListViewItem lot = new ListViewItem(LL[i].NUM_LOT.ToString());
                        lot.SubItems.Add(LL[i].ADRESSE);
                        lot.SubItems.Add(LL[i].COD_PART.ToString());
                        lot.SubItems.Add(LP[i].NOM_PRO);
                        ListLot.Items.Add(lot);
                        i = LP.Count() + 1;
                        set = 1;
                    }
                }
                if(set == 0)
                {
                    MessageBox.Show("Aucun propriétaire nommé "+Protxt.Text+" trouvé.", "Erreur de saisie", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Vous devez saisir le nom d'un propriétaire pour faire une recherche.", "Erreur de saisie",MessageBoxButtons.OK);
            }
        }

        private void Protxt_TextChanged(object sender, EventArgs e)
        {

        }
        void Autocomplettxtbox()
        {
            LP = ControllerRq.AskAllProByLot();
            AutoCompleteStringCollection str = new AutoCompleteStringCollection();
            for(int i = 0; i < LP.Count(); i++)
            {
                str.Add(LP[i].NOM_PRO);
            }
            Protxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            Protxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            Protxt.AutoCompleteCustomSource = str;
        }

        private void Protxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Numtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Acceuil op = new Acceuil(ControllerRq);
            op.Show();
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
