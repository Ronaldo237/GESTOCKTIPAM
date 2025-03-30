using GESTOCKTIPAM.BLL;  // Importe le namespace GESTOCKTIPAM.BLL pour accéder aux classes de logique métier.
using GESTOCKTIPAM.DAL;  // Importe le namespace GESTOCKTIPAM.DAL pour accéder aux classes d'accès aux données.
using System;             // Importe le namespace System pour les fonctionnalités de base de C#.
using System.Data;        // Importe le namespace System.Data pour la gestion de données.
using System.Windows.Forms;  // Importe le namespace System.Windows.Forms pour la création d'interfaces Windows Forms.

namespace GESTOCKTIPAM.GUI  // Déclare un nouveau namespace GESTOCKTIPAM.GUI.
{
    public partial class Products : Form  // Définit une classe "Products" qui hérite de Form pour créer l'interface utilisateur.
    {
        ProductsDAL pba = new ProductsDAL();  // Instancie un objet de la classe ProductsDAL pour interagir avec la base de données.
        ProductsBLL pda = new ProductsBLL();  // Instancie un objet de la classe ProductsBLL pour gérer la logique métier.

        public Products()  // Constructeur de la classe Products.
        {
            InitializeComponent();  // Initialise les composants de l'interface utilisateur (généré automatiquement).
        }

        #region Code de l'événement Products_Load
        private void Products_Load(object sender, EventArgs e)
        {
            cmboprod.SelectedIndex = 0;  // Sélectionne le premier élément de la ComboBox cmboprod.
            LoadData();  // Charge les données dans l'interface.
        }
        #endregion

        #region Bouton d'ajout des produits
        private void btnajout_Click(object sender, EventArgs e)
        {
            // Récupérer les valeurs des champs du formulaire.
            pda.name = txtnomprod.Text;  // Stocke le nom du produit à partir du champ txtnomprod dans l'objet pda.
            pda.code = txtcodeprod.Text;  // Stocke le code du produit à partir du champ txtcodeprod dans l'objet pda.

            // Vérifier si les champs obligatoires sont remplis.
            if (string.IsNullOrEmpty(pda.name) || string.IsNullOrEmpty(pda.code))
            {
                // Affiche un message d'erreur si les champs obligatoires ne sont pas remplis.
                MessageBox.Show("Veuillez remplir tous les champs obligatoires!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Vérifier si le produit existe déjà dans la base de données.
                if (pba != null && pba.ProductExist(pda))
                {
                    // Affiche un message si le produit existe déjà dans la base de données.
                    MessageBox.Show("Désolé, ce produit existe déjà dans la base de données!");
                }
                else
                {
                    // Déterminer le statut en fonction de la sélection de la ComboBox.
                    bool status = (cmboprod.SelectedIndex == 0); // 0 correspond à "Disponible".
                    // Appeler la méthode productinsert avec l'objet pda.
                    pda.status = status;

                    try
                    {
                        pba.ProductInsert(pda);  // Insère le produit dans la base de données en utilisant l'objet pda.
                                                 // Affiche un message de succès.
                        MessageBox.Show("Produit enregistré avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // En cas d'échec, affiche un message d'erreur avec les détails.
                        MessageBox.Show("Echec enregistrement! " + ex.Message, "erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Réinitialiser tous les champs du formulaire.
                    ClearForm();  // Appelle la méthode ClearForm pour effacer les champs.
                    LoadData();  // Rafraîchit les données affichées dans l'interface.
                }
            }
        }
        #endregion

        #region Bouton de modification des produits
        private void btnmodif_Click(object sender, EventArgs e)
        {
            // Vérifier si un produit est sélectionné dans la DataGridView.
            if (dgv.SelectedRows.Count == 0)
            {
                // Affiche un message d'erreur si aucun produit n'est sélectionné.
                MessageBox.Show("Veuillez sélectionner un produit à mettre à jour!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Récupérer les valeurs des champs du formulaire.
            pda.name = txtnomprod.Text;  // Stocke le nom du produit à partir du champ txtnomprod dans l'objet pda.
            pda.code = txtcodeprod.Text;  // Stocke le code du produit à partir du champ txtcodeprod dans l'objet pda.
            // Déterminer le statut en fonction de la sélection de la ComboBox.
            bool status = (cmboprod.SelectedIndex == 0); // 0 correspond à "Disponible" et 1 à "Indisponible".
            // Mettre à jour le produit dans la base de données.
            try
            {
                // La méthode productupdate() est appelée avec la valeur du statut en tant que deuxième paramètre 
                // pour que la méthode puisse accéder à la valeur du statut.
                pba.ProductUpdate(pda, status);
                // Affiche un message de succès.
                MessageBox.Show("Produit mis à jour avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Affiche un message d'erreur en cas de problème.
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Réinitialiser tous les champs du formulaire.
            ClearForm();  // Appelle la méthode ClearForm pour effacer les champs.
            LoadData();  // Rafraîchit les données affichées dans l'interface.
        }
        #endregion

        #region Bouton de suppression des produits
        private void btnsuppr_Click(object sender, EventArgs e)
        {
            // Vérifier si un produit est sélectionné dans la DataGridView.
            if (dgv.SelectedRows.Count == 0)
            {
                // Affiche un message d'erreur si aucun produit n'est sélectionné.
                MessageBox.Show("Veuillez sélectionner un produit à supprimer!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Récupérer le code du produit sélectionné.
            pda.code = dgv.SelectedRows[0].Cells[0].Value.ToString();

            // Confirmer la suppression du produit.
            DialogResult result = MessageBox.Show("Voulez-vous vraiment supprimer ce produit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Supprimer le produit de la base de données.
                pba.ProductDelete(pda);

                // Affiche un message de succès.
                MessageBox.Show("Produit supprimé avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Réinitialiser tous les champs du formulaire.
                ClearForm();  // Appelle la méthode ClearForm pour effacer les champs.
                LoadData();  // Rafraîchit les données affichées dans l'interface.
            }
        }
        #endregion

        #region Bouton de Recherche des produits

        private void btnrecherche_Click(object sender, EventArgs e)
        {
            // Récupérer le mot clé de la recherche.
            string keyword = txtrecherche.Text;

            // Appeler la méthode searchproducts() pour rechercher le produit.
            DataTable dt = pba.ProductSearch(keyword);

            // Afficher le résultat de la recherche dans la DataGridView.
            if (dt.Rows.Count > 0)
            {
                dgv.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Aucun produit ne correspond à ce mot clé!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion

        #region Méthode LoadData pour charger les données dans un DataTable

        // Méthode utilisée pour charger des données depuis la base de données, dans un contrôle DataGridView (ou dgvs) en utilisant un DataTable.
        // Un DataTable est une classe dans le framework ADO.NET de Microsoft qui représente une table de données relationnelle en mémoire.
        private void LoadData()
        {
            // Appelez la méthode selectproducts pour récupérer les données via le DataTable.
            DataTable dt = pba.ProductSelect(pda);

            // Assurez-vous que dataGridView existe déjà dans votre code.
            dgv.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dgv.Rows.Add();
                dgv.Rows[n].Cells[0].Value = item["Code"].ToString();
                dgv.Rows[n].Cells[1].Value = item["Name"].ToString();

                // Convertir la valeur du statut en chaîne "Disponible" ou "Indisponible".
                bool status = (bool)item["Status"];
                dgv.Rows[n].Cells[2].Value = status ? "Disponible" : "Indisponible";
            }
        }
        #endregion

        #region Code de la méthode ClearForm()
        private void ClearForm()
        {
            // Réinitialiser tous les champs du formulaire.
            txtnomprod.Text = string.Empty;
            txtcodeprod.Text = string.Empty;

        }
        #endregion

        #region Code de l'événement dgv_MouseDoubleClick
        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Lorsque l'utilisateur double-clique sur une ligne de la DataGridView (dgv), les données de cette ligne sont chargées dans les champs du formulaire.

            // Récupère le code du produit depuis la cellule de la première colonne (index 0) de la ligne sélectionnée et l'affiche dans le champ txtcodeprod.
            txtcodeprod.Text = dgv.SelectedRows[0].Cells[0].Value.ToString();

            // Récupère le nom du produit depuis la cellule de la deuxième colonne (index 1) de la ligne sélectionnée et l'affiche dans le champ txtnomprod.
            txtnomprod.Text = dgv.SelectedRows[0].Cells[1].Value.ToString();

            // Vérifie si le statut du produit (cellule de la troisième colonne, index 2) est "Disponible".
            if (dgv.SelectedRows[0].Cells[2].Value.ToString() == "Disponible")
            {
                // Si le statut est "Disponible", sélectionne la première option dans la ComboBox cmboprod (index 0) qui correspond à "Disponible".
                cmboprod.SelectedIndex = 0;
            }
            else
            {
                // Si le statut est "Indisponible", sélectionne la deuxième option dans la ComboBox cmboprod (index 1) qui correspond à "Indisponible".
                cmboprod.SelectedIndex = 1;
            }
        }
        #endregion
    }
}
