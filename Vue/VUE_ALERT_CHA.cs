using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetHameau.Vue;
using ProjetHameau.Model;
using ProjetHameau.Controller;
using System.IO;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using Microsoft.Reporting.WinForms;

namespace ProjetHameau.Vue
{
    public partial class VUE_ALERT_CHA : Form
    {
        List<CHARGE> LC = new List<CHARGE>();
        List<PROPRIETAIRE> LP = new List<PROPRIETAIRE>();
        List<LOT> LL = new List<LOT>();

        CHARGE Charge = new CHARGE() ;
        PROPRIETAIRE Proprio = new PROPRIETAIRE();
        LOT lot = new LOT();
        int index = 0;
        int ValeurList = 0;
        GereRequetes ControllerRq;
        DateTime year1 = DateTime.Today;
        int m_currentPageIndex;
        IList<Stream> m_streams;

        public VUE_ALERT_CHA(GereRequetes Controller1)
        {

            ControllerRq = Controller1;
            InitializeComponent();
            reportViewer1.ShowToolBar = true;
            DateTime Today = DateTime.Today;
            LC = ControllerRq.AskChaForAlert();
        

    }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void VUE_ALERT_CHA_Load(object sender, EventArgs e)
        {
            this.refreshviewer(0);
        }

        void refreshviewer(int idx)
        {
            string Date = RefreshDate();
            LP = ControllerRq.AskOneProBylot(LC[idx].NUM_LOT.ToString());
            LL = ControllerRq.AskOneLot(LC[idx].NUM_LOT.ToString());

            Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new ReportParameter("NomPro",LP[0].NOM_PRO),
                new ReportParameter("Adresse",LL[0].ADRESSE),
                new ReportParameter("NumLot",LL[0].NUM_LOT.ToString()),
                new ReportParameter("Retard",LC[idx].MNT_PAI.ToString()),
                new ReportParameter("Date",Date),

            };
            this.reportViewer1.LocalReport.SetParameters(p);
            this.reportViewer1.RefreshReport();
        }

        string RefreshDate()
        {
            string jour = year1.Day.ToString();
            string moi = year1.Month.ToString();
           
            if(year1.Day < 10)
            {
                jour = "0" + jour;
            }
            if(year1.Month < 10)
            {
                moi = "0" + moi;
            }
            string Date = jour + "/" + moi + "/" + year1.Year.ToString();
            return Date; 
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(index != 0)
            {
                this.refreshviewer(index - 1);
                index -= 1;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (index < LC.Count() - 1)
            {
                this.refreshviewer(index + 1);
                index += 1;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.reportViewer1.PrintDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Run();
        }
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            LP = ControllerRq.AskOneProBylot(LC[ValeurList].NUM_LOT.ToString());
            LL = ControllerRq.AskOneLot(LC[ValeurList].NUM_LOT.ToString());
            string Date = RefreshDate();
            Metafile pageImage = new
            Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.

            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left + (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top + (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);


            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);
            Font drawFont = new Font("Arial", 10);
            Font drawFontGras = new Font("Arial", 10,FontStyle.Bold);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Create point for upper-left corner of drawing.
            PointF drawPointNom = new PointF(170F, 246F);
            PointF drawPointAdresse = new PointF(170F, 270F);
            PointF drawPointNum = new PointF(200F, 337);
            PointF drawPointRetard = new PointF(300F, 576F);
            PointF drawPointDate = new PointF(620F, 1014F);
            ev.Graphics.DrawString(LP[0].NOM_PRO, drawFontGras, drawBrush, drawPointNom);
            ev.Graphics.DrawString(LL[0].ADRESSE, drawFont, drawBrush, drawPointAdresse);
            ev.Graphics.DrawString(LL[0].NUM_LOT.ToString(), drawFont, drawBrush, drawPointNum);
            ev.Graphics.DrawString(LC[ValeurList].MNT_PAI.ToString()+"€", drawFontGras, drawBrush, drawPointRetard);
            ev.Graphics.DrawString(Date, drawFont, drawBrush, drawPointDate);
            float test = drawPointNom.X ;
            
            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
            if(ValeurList != LC.Count())
            {
                ValeurList += 1;
            }
            else
            {
                ValeurList = 0;
            }
            
        }

        private void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }
        private void Run()
        {
            LocalReport report = new LocalReport();
            report.ReportPath = @"C:\Users\Hadenos_EZ\source\repos\ProjetHameau\ProjetHameau\Vue\PAGE_ALERT_CHA2.rdlc";
            if(LC.Count() != 0)
            {
                for (int i = 0; i < LC.Count(); i++)
                {
                    Export(report);
                    Print();
                }
            }
        }
        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding,  string mimeType, bool willSeek)
        {
            m_streams = new List<Stream>();
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
        private void Export(LocalReport report)
        {

            string deviceInfo =
              @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8.5in</PageWidth>
                <PageHeight>11in</PageHeight>
                <MarginTop>0.25in</MarginTop>
                <MarginLeft>0.25in</MarginLeft>
                <MarginRight>0.25in</MarginRight>
                <MarginBottom>0.25in</MarginBottom>
                </DeviceInfo>";
            Warning[] warnings;
            List<Stream> m_stream = new List<Stream>();
            report.Render("Image",deviceInfo, CreateStream , out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }

        private void reportViewer1_PrintingBegin(object sender, Microsoft.Reporting.WinForms.ReportPrintEventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Acceuil op = new Acceuil(ControllerRq);
            op.Show();
        }

        private void reportViewer1_Load_2(object sender, EventArgs e)
        {

        }
    }
}
