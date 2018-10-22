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
    public partial class VUE_PROC : Form
    {
        public VUE_PROC()
        {
            InitializeComponent();
        }

        private void VUE_PROC_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GereRequetes ControllerRq = new GereRequetes(); 
            this.Hide();
            Acceuil op = new Acceuil(ControllerRq);
            op.Show();
        }
    }
}
