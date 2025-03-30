using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GESTOCKTIPAM.GUI
{
    public partial class StockMain : Form
    {

        public StockMain()
        {
            InitializeComponent();
        }

        #region Le code du Formulaire StockMain
        bool close = true;
        private void StockMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close)
            {

                DialogResult result = MessageBox.Show("Voulez-vous vraiment quitter l'application ?", "Quitter", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    close = false;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion

        #region Le code du MenuStrip
        private void produitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Products prod = new Products();
            prod.MdiParent = this;
            prod.Show();
            prod.StartPosition = FormStartPosition.CenterScreen;
        }

        #endregion

        #region Le code d'appel du formulaire de Stock
        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock st = new Stock();
            st.MdiParent = this;
            st.StartPosition = FormStartPosition.CenterScreen;
            st.Show();
        }
        #endregion

        private void listeDesProduitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crée une nouvelle instance de la classe ProductsReport dans l'espace de noms ReportsForm.
            ReportsForm.ProductsReport prd = new ReportsForm.ProductsReport();
            // Définit la fenêtre parente de la nouvelle instance de ProductsReport comme étant "this",
            // qui fait référence à la fenêtre actuelle où le gestionnaire d'événements est exécuté.
            prd.MdiParent = this;
            // Définit la position de départ de la fenêtre ProductsReport au centre de la fenêtre parente.
            prd.StartPosition = FormStartPosition.CenterScreen;
            // Affiche la fenêtre ProductsReport. Cela affiche la fenêtre enfant à l'intérieur de la fenêtre principale.
            prd.Show();
        }

        private void listeDuStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crée une nouvelle instance de la classe StocksReport dans l'espace de noms ReportsForm.
            ReportsForm.StocksReport stk = new ReportsForm.StocksReport();
            // Définit la fenêtre parente de la nouvelle instance de StocksReport comme étant "this",
            // qui fait référence à la fenêtre actuelle où le gestionnaire d'événements est exécuté.
            stk.MdiParent = this;
            // Définit la position de départ de la fenêtre StocksReportt au centre de la fenêtre parente.
            stk.StartPosition = FormStartPosition.CenterScreen;
            // Affiche la fenêtre StocksReport. Cela affiche la fenêtre enfant à l'intérieur de la fenêtre principale.
            stk.Show();
        }
    }
}
