using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using GESTOCKTIPAM.BLL;
using GESTOCKTIPAM.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace GESTOCKTIPAM.GUI.ReportsForm
{
    public partial class StocksReport : Form
    {

        StocksDAL pba = new StocksDAL();
        StocksBLL pda = new StocksBLL();

        ReportDocument rpt = new ReportDocument();

        public StocksReport()
        {
            InitializeComponent();
        }

        private void StocksReport_Load(object sender, EventArgs e)
        {

        }

        private void btnRapp_Click(object sender, EventArgs e)
        {
            // Charger le rapport Crystal Reports depuis le chemin spécifié
            rpt.Load(@"C:\Users\PC\Documents\Visual Studio 2015\Projects\GESTOCKTIPAM\GESTOCKTIPAM\Reports\StockReport.rpt");

            // Définir les dates de début et de fin pour la recherche
            DateTime fromDate = dtp1.Value; //  DateTimePicker pour la date de début.
            DateTime toDate = dtp2.Value;   // DateTimePicker pour la date de fin.
            // Appeler la méthode StockSelectReport pour obtenir le DataSet
            DataSet dst = pba.StockSelectReport(pda, fromDate, toDate);
            // Définir la source de données du rapport Crystal Reports
            //Tables[0] fait référence à la première table du DataSet ici la table Stocks
            //Chargé via StockSelectReport
            rpt.SetDataSource(dst.Tables[0]);
            // Passer les paramètres au rapport
            rpt.SetParameterValue("@FromDate", fromDate.ToString("dd/MM/yyyy"));
            rpt.SetParameterValue("@ToDate", toDate.ToString("dd/MM/yyyy"));
            // Afficher le rapport dans le CrystalReportViewer
            crystalReportViewer1.ReportSource = rpt;
        }

        // Lorsque le bouton d'exportation est cliqué
        private void btnExport_Click(object sender, EventArgs e)
        {
            // Créez des instances d'options d'exportation et de la boîte de dialogue de sauvegarde de fichier
            ExportOptions exportOption = new ExportOptions();
            DiskFileDestinationOptions diskFileDestinationOptions = new DiskFileDestinationOptions();
            SaveFileDialog sfd = new SaveFileDialog();
            // Configure le filtre de la boîte de dialogue pour afficher uniquement les fichiers Excel et PDF
            sfd.Filter = "Fichier Excel (*.xls)|*.xls|Fichier PDF (*.pdf)|*.pdf";
            // Si l'utilisateur sélectionne un emplacement de sauvegarde et clique sur OK
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // Configure les options d'exportation avec le fichier de destination sélectionné
                exportOption.ExportDestinationOptions = diskFileDestinationOptions;
                diskFileDestinationOptions.DiskFileName = sfd.FileName;
                // Essaie d'exporter le rapport
                try
                {
                    // Si le fichier sélectionné a une extension .xls
                    if (sfd.FileName.EndsWith(".xls"))
                    {
                        // Configure les options d'exportation pour Excel
                        exportOption.ExportDestinationType = ExportDestinationType.DiskFile;
                        exportOption.ExportFormatType = ExportFormatType.Excel;
                        exportOption.ExportFormatOptions = new ExcelFormatOptions();
                    }
                    // Si le fichier sélectionné a une extension .pdf
                    else if (sfd.FileName.EndsWith(".pdf"))
                    {
                        // Configure les options d'exportation pour PDF
                        exportOption.ExportDestinationType = ExportDestinationType.DiskFile;
                        exportOption.ExportFormatType = ExportFormatType.PortableDocFormat;
                        exportOption.ExportFormatOptions = new PdfRtfWordFormatOptions();
                    }
                    // Exporte le document
                    rpt.Export(exportOption);
                    // Affiche un message de réussite si l'exportation est réussie
                    MessageBox.Show("Exportation réussie.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (System.Runtime.InteropServices.COMException comEx)
                {
                    // Capture et affiche une exception spécifique aux erreurs COM
                    MessageBox.Show("Erreur lors de l'exportation : " + comEx.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    // Capture et affiche toute autre exception générique
                    MessageBox.Show("Une erreur inattendue s'est produite : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }

}

