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
    public partial class VUE_MOD_CHA : Form
    {
        List<CHARGE> LC = new List<CHARGE>();
        List<PROPRIETAIRE> LP = new List<PROPRIETAIRE>();
        GereRequetes ControllerRq;
        string numchar;
        string NomPro;
        DateTime date = DateTime.Today;
        public VUE_MOD_CHA(GereRequetes Controller1,string numCha,string Nom)
        {
            InitializeComponent();
            ControllerRq = Controller1;
            numchar = numCha;
            NomPro = Nom;
            initform();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void VUE_MOD_CHA_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            VUE_CHARGE op = new VUE_CHARGE(ControllerRq);
            op.Show();
        }

        void initform()
        {
            LP = ControllerRq.AskProByNom(NomPro);
            LC = ControllerRq.AskOneCha(numchar);
            if (LC.Count() != 0 && LP.Count() != 0)
            {
                label10.Text = LC[0].NUM_CHA.ToString() + " | " + LC[0].LIB_CHA;
                label12.Text = LP[0].NOM_PRO;
                label11.Text = LC[0].NUM_LOT.ToString();
                label13.Text = LC[0].DAT_CHA;
                label14.Text = LC[0].MNT_CHA.ToString();
                Montanttxt.Text += LC[0].MNT_PAI.ToString();
                Datetxt.Text += LC[0].DAT_PAI.ToString();
                Numchequetxt.Text += LC[0].ID_PAI.ToString();
                comboBox1.Items.Add("Chèque");
                comboBox1.Items.Add("Carte bancaire");
                comboBox1.Items.Add("Espèce");
                comboBox1.Items.Add("TIP");
                comboBox1.Items.Add("Virement");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            float result;
            DateTime date = new DateTime();
            if (Datetxt.Text != "" && Montanttxt.Text != "" && comboBox1.SelectedIndex != -1)
            {
               if (float.TryParse(Montanttxt.Text, out result))
               {
                  if (DateTime.TryParse(Datetxt.Text, out date))
                  {
                        switch (comboBox1.SelectedIndex)
                        {
                            case 0 : ControllerRq.AskUpdateCha(numchar, Datetxt.Text, result, "CHQ", Numchequetxt.Text);
                                break;
                            case 1:
                                ControllerRq.AskUpdateCha(numchar, Datetxt.Text, result, "CTB", Numchequetxt.Text);
                                break;
                            case 2:
                                ControllerRq.AskUpdateCha(numchar, Datetxt.Text, result, "ESP", Numchequetxt.Text);
                                break;
                            case 3:
                                ControllerRq.AskUpdateCha(numchar, Datetxt.Text, result, "TIP", Numchequetxt.Text);
                                break;
                            case 4:
                                ControllerRq.AskUpdateCha(numchar, Datetxt.Text, result, "VIR", Numchequetxt.Text);
                                break;
                        }
                            
                  }
               } 
            }
           
        }
        string ModifDate(DateTime op)
        {
            string Date; 
            if (op.Day < 10)
            {
                Date = "0" + op.Day.ToString();
            }
            else
            {
                Date = op.Day.ToString();
            }

            if(op.Month < 10)
            {
                 Date += "/0" + op.Month.ToString();
            }
            else
            {
                Date += "/" + op.Month.ToString();
            }
            Date += "/"+op.Year.ToString();

            return Date;
        }
    }
}
