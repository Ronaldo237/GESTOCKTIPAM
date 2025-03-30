using CrystalDecisions.CrystalReports.Engine;
using GESTOCKTIPAM.BLL;
using GESTOCKTIPAM.DAL;
using System;
using System.Data;
using System.Windows.Forms;

namespace GESTOCKTIPAM.GUI.ReportsForm
{
    public partial class ProductsReport : Form
    {
        ProductsDAL ba = new ProductsDAL();  
        ProductsBLL da = new ProductsBLL();

        ReportDocument rpt = new ReportDocument();
        public ProductsReport()
        {
            InitializeComponent();
        }

        /*
         Le code ci-dessous charge un rapport Crystal Reports, 
         extrait des données de la base de données, associe ces données au rapport, 
         et affiche le rapport dans un contrôle CrystalReportViewer
        */
        private void ProductsReport_Load(object sender, EventArgs e)
        {
            // Charge un rapport Crystal Reports depuis un chemin spécifié.
            rpt.Load(@"C:\Users\PC\Documents\Visual Studio 2015\Projects\GESTOCKTIPAM\GESTOCKTIPAM\Reports\ProductReport.rpt");

            // Appelle une méthode pour récupérer des données depuis la base de données et les stocke dans un DataTable.
            DataTable dt = ba.ProductSelect(da);

            // Définit le DataTable comme la source de données pour le rapport Crystal Reports.
            rpt.SetDataSource(dt);

            // Associe le rapport Crystal Reports au contrôle CrystalReportViewer pour l'afficher à l'utilisateur.
            crystalReportViewer1.ReportSource = rpt;
        }

    }
}
