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
using ProjetHameau.Controller;

namespace ProjetHameau.Vue
{
    public partial class VUE_LISTE_EM : Form
    {
        List<PROPRIETAIRE> LP = new List<PROPRIETAIRE>();
        GereRequetes ControllerRq;
        int index = 1; 

        public VUE_LISTE_EM(GereRequetes Controller1)
        {
            InitializeComponent();
            ControllerRq = Controller1; 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void VUE_LISTE_EM_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportPath = "C:\\Users\\Hadenos_EZ\\source\\repos\\ProjetHameau\\ProjetHameau\\Vue\\LISTE_EMARGEMENT1.rdlc";
            LP = ControllerRq.AskAllProByLot();
            Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("Nom0",LP[0].NOM_PRO),
                new Microsoft.Reporting.WinForms.ReportParameter("Nom1",LP[1].NOM_PRO),
                new Microsoft.Reporting.WinForms.ReportParameter("Nom2",LP[2].NOM_PRO),
                new Microsoft.Reporting.WinForms.ReportParameter("Nom3",LP[3].NOM_PRO),
                new Microsoft.Reporting.WinForms.ReportParameter("Nom4",LP[4].NOM_PRO),
                new Microsoft.Reporting.WinForms.ReportParameter("Nom5",LP[5].NOM_PRO),
                new Microsoft.Reporting.WinForms.ReportParameter("Nom6",LP[6].NOM_PRO),
                new Microsoft.Reporting.WinForms.ReportParameter("Nom7",LP[7].NOM_PRO),
                new Microsoft.Reporting.WinForms.ReportParameter("Nom8",LP[8].NOM_PRO),
                new Microsoft.Reporting.WinForms.ReportParameter("Nom9",LP[9].NOM_PRO),
                new Microsoft.Reporting.WinForms.ReportParameter("Nom10",LP[10].NOM_PRO),
                new Microsoft.Reporting.WinForms.ReportParameter("Nom11",LP[11].NOM_PRO),
                new Microsoft.Reporting.WinForms.ReportParameter("Nom12",LP[12].NOM_PRO),
                new Microsoft.Reporting.WinForms.ReportParameter("Nom13",LP[13].NOM_PRO),
                new Microsoft.Reporting.WinForms.ReportParameter("Nom14",LP[14].NOM_PRO),
                new Microsoft.Reporting.WinForms.ReportParameter("Nom15",LP[15].NOM_PRO),
                new Microsoft.Reporting.WinForms.ReportParameter("Nom16",LP[16].NOM_PRO),
                new Microsoft.Reporting.WinForms.ReportParameter("Nom17",LP[17].NOM_PRO),
                new Microsoft.Reporting.WinForms.ReportParameter("Nom18",LP[18].NOM_PRO),
                new Microsoft.Reporting.WinForms.ReportParameter("Nom19",LP[19].NOM_PRO),
                new Microsoft.Reporting.WinForms.ReportParameter("Nom20",LP[20].NOM_PRO),
                new Microsoft.Reporting.WinForms.ReportParameter("Nom21",LP[21].NOM_PRO),
                new Microsoft.Reporting.WinForms.ReportParameter("Nom22",LP[22].NOM_PRO),
                new Microsoft.Reporting.WinForms.ReportParameter("Nom23",LP[23].NOM_PRO),
                new Microsoft.Reporting.WinForms.ReportParameter("Nom24",LP[24].NOM_PRO),
                new Microsoft.Reporting.WinForms.ReportParameter("Nom25",LP[25].NOM_PRO),
                new Microsoft.Reporting.WinForms.ReportParameter("Nom26",LP[26].NOM_PRO),
                new Microsoft.Reporting.WinForms.ReportParameter("Nom27",LP[27].NOM_PRO),



            };
            this.reportViewer1.LocalReport.SetParameters(p);
            this.reportViewer1.RefreshReport();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Acceuil op = new Acceuil(ControllerRq);
            op.Show(); 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if(index < 3)
            {
                index++;
                SwitchIndex();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(index > 1)
            {
                index--;
                SwitchIndex();
            }
        }

        private void SwitchIndex()
        {
            switch (index)
            {
                case 1:
                    this.reportViewer1.LocalReport.ReportPath = "C:\\Users\\Hadenos_EZ\\source\\repos\\ProjetHameau\\ProjetHameau\\Vue\\LISTE_EMARGEMENT1.rdlc";
                    Microsoft.Reporting.WinForms.ReportParameter[] p1 = new Microsoft.Reporting.WinForms.ReportParameter[]
                    {
                    new Microsoft.Reporting.WinForms.ReportParameter("Nom0",LP[0].NOM_PRO),
                    new Microsoft.Reporting.WinForms.ReportParameter("Nom1",LP[1].NOM_PRO),
                    new Microsoft.Reporting.WinForms.ReportParameter("Nom2",LP[2].NOM_PRO),
                    new Microsoft.Reporting.WinForms.ReportParameter("Nom3",LP[3].NOM_PRO),
                    new Microsoft.Reporting.WinForms.ReportParameter("Nom4",LP[4].NOM_PRO),
                    new Microsoft.Reporting.WinForms.ReportParameter("Nom5",LP[5].NOM_PRO),
                    new Microsoft.Reporting.WinForms.ReportParameter("Nom6",LP[6].NOM_PRO),
                    new Microsoft.Reporting.WinForms.ReportParameter("Nom7",LP[7].NOM_PRO),
                    new Microsoft.Reporting.WinForms.ReportParameter("Nom8",LP[8].NOM_PRO),
                    new Microsoft.Reporting.WinForms.ReportParameter("Nom9",LP[9].NOM_PRO),
                    new Microsoft.Reporting.WinForms.ReportParameter("Nom10",LP[10].NOM_PRO),
                    new Microsoft.Reporting.WinForms.ReportParameter("Nom11",LP[11].NOM_PRO),
                    new Microsoft.Reporting.WinForms.ReportParameter("Nom12",LP[12].NOM_PRO),
                    new Microsoft.Reporting.WinForms.ReportParameter("Nom13",LP[13].NOM_PRO),
                    new Microsoft.Reporting.WinForms.ReportParameter("Nom14",LP[14].NOM_PRO),
                    new Microsoft.Reporting.WinForms.ReportParameter("Nom15",LP[15].NOM_PRO),
                    new Microsoft.Reporting.WinForms.ReportParameter("Nom16",LP[16].NOM_PRO),
                    new Microsoft.Reporting.WinForms.ReportParameter("Nom17",LP[17].NOM_PRO),
                    new Microsoft.Reporting.WinForms.ReportParameter("Nom18",LP[18].NOM_PRO),
                    new Microsoft.Reporting.WinForms.ReportParameter("Nom19",LP[19].NOM_PRO),
                    new Microsoft.Reporting.WinForms.ReportParameter("Nom20",LP[20].NOM_PRO),
                    new Microsoft.Reporting.WinForms.ReportParameter("Nom21",LP[21].NOM_PRO),
                    new Microsoft.Reporting.WinForms.ReportParameter("Nom22",LP[22].NOM_PRO),
                    new Microsoft.Reporting.WinForms.ReportParameter("Nom23",LP[23].NOM_PRO),
                    new Microsoft.Reporting.WinForms.ReportParameter("Nom24",LP[24].NOM_PRO),
                    new Microsoft.Reporting.WinForms.ReportParameter("Nom25",LP[25].NOM_PRO),
                    new Microsoft.Reporting.WinForms.ReportParameter("Nom26",LP[26].NOM_PRO),
                    new Microsoft.Reporting.WinForms.ReportParameter("Nom27",LP[27].NOM_PRO),
                    };
                    this.reportViewer1.LocalReport.SetParameters(p1);
                    this.reportViewer1.RefreshReport();
                    break;
                case 2:
                    this.reportViewer1.LocalReport.ReportPath = "C:\\Users\\Hadenos_EZ\\source\\repos\\ProjetHameau\\ProjetHameau\\Vue\\LISTE_EMARGEMENT2.rdlc";
                    Microsoft.Reporting.WinForms.ReportParameter[] p2 = new Microsoft.Reporting.WinForms.ReportParameter[]
                    {
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom28",LP[28].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom29",LP[29].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom30",LP[30].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom31",LP[31].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom32",LP[32].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom33",LP[33].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom34",LP[34].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom35",LP[35].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom36",LP[36].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom37",LP[37].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom38",LP[38].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom39",LP[39].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom40",LP[40].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom41",LP[41].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom42",LP[42].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom43",LP[43].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom44",LP[44].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom45",LP[45].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom46",LP[46].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom47",LP[47].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom48",LP[48].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom49",LP[49].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom50",LP[50].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom51",LP[51].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom52",LP[52].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom53",LP[53].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom54",LP[54].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom55",LP[55].NOM_PRO),
                    };
                    this.reportViewer1.LocalReport.SetParameters(p2);
                    this.reportViewer1.RefreshReport();
                    break;
                case 3:
                    this.reportViewer1.LocalReport.ReportPath = "C:\\Users\\Hadenos_EZ\\source\\repos\\ProjetHameau\\ProjetHameau\\Vue\\LISTE_EMARGEMENT3.rdlc";
                    Microsoft.Reporting.WinForms.ReportParameter[] p3 = new Microsoft.Reporting.WinForms.ReportParameter[]
                    {
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom56",LP[56].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom57",LP[57].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom58",LP[58].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom59",LP[59].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom60",LP[60].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom61",LP[61].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom62",LP[62].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom63",LP[63].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom64",LP[64].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom65",LP[65].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom66",LP[66].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom67",LP[67].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom68",LP[68].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom69",LP[69].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom70",LP[70].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom71",LP[71].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom72",LP[72].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom73",LP[73].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom74",LP[74].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom75",LP[75].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom76",LP[76].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom77",LP[77].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom78",LP[78].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom79",LP[79].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom80",LP[80].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom81",LP[81].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom82",LP[82].NOM_PRO),
                        new Microsoft.Reporting.WinForms.ReportParameter("Nom83",LP[83].NOM_PRO),
                    };
                    this.reportViewer1.LocalReport.SetParameters(p3);
                    this.reportViewer1.RefreshReport();
                    break;
            }
        }
    }
}
