using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using Microsoft.Reporting.WinForms;
using ProjetHameau.Model;
using ProjetHameau.Controller;
using System.IO;

namespace ProjetHameau.Vue
{
    public partial class VUE_PRINT_CHA : Form
    {
        List<CHARGE> LC = new List<CHARGE>();
        List<CHARGE> LCPai = new List<CHARGE>(); 
        List<PROPRIETAIRE> LP = new List<PROPRIETAIRE>();
        List<LOT> LL = new List<LOT>();

        CHARGE Charge = new CHARGE();
        PROPRIETAIRE Proprio = new PROPRIETAIRE();
        LOT lot = new LOT();
        int ValeurList = 0;
        DateTime year1 = DateTime.Today;
        int m_currentPageIndex;
        IList<Stream> m_streams;
        GereRequetes ControllerRq;
        public VUE_PRINT_CHA(GereRequetes Controller1)
        {
            InitializeComponent();
            ControllerRq = Controller1;
            LL = ControllerRq.AskAllLot(); 
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            
            LP = ControllerRq.AskOneProBylot(LL[ValeurList].NUM_LOT.ToString());
            LC = ControllerRq.AskChaByNoDatPai(LL[ValeurList].NUM_LOT.ToString());
            double resultat = 0; 
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
            Font drawFontGras = new Font("Arial", 10, FontStyle.Bold);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Create point for upper-left corner of drawing.
            PointF drawPointNom = new PointF(170F, 197F);
            PointF drawPointAdresse = new PointF(170F, 225F);
            PointF drawPointNum = new PointF(200F, 289F);
            PointF drawPointCha = new PointF (350F, 550F);
            ev.Graphics.DrawString(LP[0].NOM_PRO, drawFontGras, drawBrush, drawPointNom);
            ev.Graphics.DrawString(LL[ValeurList].ADRESSE, drawFont, drawBrush, drawPointAdresse);
            ev.Graphics.DrawString(LL[ValeurList].NUM_LOT.ToString(), drawFont, drawBrush, drawPointNum);
            float Height = 550;
            float largeur = 84;
            if (LC.Count() != 0)
            {
                for (int i = 0; i < LC.Count(); i++)
                {
                    PointF drawPointCha1 = new PointF(largeur,Height);
                    PointF drawPointMnt = new PointF(550, Height);
                    ev.Graphics.DrawString(LC[i].LIB_CHA, drawFont, drawBrush, drawPointCha1);
                    ev.Graphics.DrawString(LC[i].MNT_CHA.ToString(), drawFont, drawBrush, drawPointMnt);
                    Height += 20;
                    resultat += double.Parse(LC[i].MNT_CHA.Replace('.',','));
                }
            }
            Height += 30;
            PointF DrawPointTotal = new PointF(largeur, Height);
            ev.Graphics.DrawString("Total à régler", drawFontGras, drawBrush, DrawPointTotal);
            PointF drawPointTotalAR = new PointF(550, Height);
            ev.Graphics.DrawString(resultat.ToString(), drawFontGras, drawBrush, drawPointTotalAR);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
            if (ValeurList != LL.Count())
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
            report.ReportPath = @"C:\Users\Hadenos_EZ\source\repos\ProjetHameau\ProjetHameau\Vue\PAGE_CHARGE.rdlc";
            //for(int i = 0; i < 84; i++)
            //{
                Export(report);
                Print();
            //}
        }
        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
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
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Run();
        }

        private void VUE_PRINT_CHA_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Acceuil op = new Acceuil(ControllerRq);
            op.Show(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Run();
        }
    }
}
