using GESTOCKTIPAM.BLL;
using GESTOCKTIPAM.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GESTOCKTIPAM.GUI
{
    public partial class Stock : Form
    {
        StocksDAL pba = new StocksDAL();
        StocksBLL pda = new StocksBLL();
        ProductsBLL da = new ProductsBLL();
      
        public Stock()
        {
            InitializeComponent();
        }

        #region Méthode Stock_Load
        private void Stock_Load(object sender, EventArgs e)
        {
            // Assigne le focus au ComboBox combostatus
            combostatus.Focus();
            // Remplissage du ComboBox de l'ID
            LoadTbStatus();
            // Initialise la sélection du ComboBox des status "combostatus" à la première option.
            combostatus.SelectedIndex = 0;
            // Remplissage du DataGridView
            LoadData();
            // Remplissage du TextBox du nom
            LoadTbName();
            // Remplissage du Texbox du code
            LoadTbCode();
            //Calcul et affichage du nombre total de produits et la quantité totale dans le DataGridView.
            LoadQte();
        }

        #endregion

        #region Méthode dtp_KeyDown : Gestion de la touche Enter pour DateTimePicker
        private void dtp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Déplace le focus vers "txtcode".
                txtcode.Focus();
            }
        }
        #endregion

        #region Méthode txtcode_KeyDown : Gestion de la touche Enter pour txtcode
        private void txtcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Vérifie si le contenu de "txtcode" n'est pas vide.
                if (txtcode.Text.Length > 0)
                {
                    // Si le contenu de "txtcode" n'est pas vide, déplace le focus vers "txtnom".
                    txtnom.Focus();
                }
                else
                {
                    // Si le contenu de "txtcode" est vide, garde le focus sur "txtcode".
                    txtcode.Focus();
                }
            }
        }
        #endregion

        #region Méthode txtnom_KeyDown : Gestion de la touche Enter pour txtnom
        private void txtnom_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                // Vérifie si le contenu de "txtnom" n'est pas vide.
                if (txtnom.Text.Length > 0)
                {
                    // Si le contenu de "txtnom" n'est pas vide, déplace le focus vers "txtqte".
                    txtqte.Focus();
                }
                else
                {
                    // Si le contenu de "txtnom" est vide, garde le focus sur "txtnom".
                    txtnom.Focus();
                }
            }
        }
        #endregion

        #region Méthode txtqte_KeyDown : Gestion de la touche Enter pour txtqte
        private void txtqte_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                // Vérifie si le contenu de "txtqte" n'est pas vide.
                if (txtqte.Text.Length > 0)
                {
                    // Si le contenu de "txtqte" n'est pas vide, déplace le focus vers "combostatus".
                    combostatus.Focus();
                }
                else
                {
                    // Si le contenu de "txtqte" est vide, garde le focus sur "txtqte".
                    txtqte.Focus();
                }
            }
        }
        #endregion

        #region Méthode combostatus_KeyDown :  Gestion de la touche Enter pour combostatus
        private void combostatus_KeyDown(object sender, KeyEventArgs e)
        {
        
            if (e.KeyCode == Keys.Enter)
            {
                // Vérifie si une option a été sélectionnée dans "combostatus" (indice différent de -1).
                if (combostatus.SelectedIndex != -1)
                {
                    // Si une option a été sélectionnée, déplace le focus vers "combostatus".
                    combostatus.Focus();
                }
                else
                {
                    // Si aucune option n'a été sélectionnée, garde le focus sur "combostatus".
                    combostatus.Focus();
                }
            }
        }
        #endregion

        #region Méthode txtqte_KeyPress : Gestion de la saisie dans txtqte
        private void txtqte_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Vérifie si le caractère entré n'est ni un chiffre ni la touche Backspace ni le point.
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                // Si le caractère n'est pas autorisé, l'entrée est bloquée.
                e.Handled = true;
            }
        }
        #endregion

        #region Méthode txtid_KeyPress : Gestion de la saisie dans txtid
        private void txtid_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Vérifie si le caractère entré n'est ni un chiffre ni la touche Backspace ni le point.
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                // Si le caractère n'est pas autorisé, l'entrée est bloquée.
                e.Handled = true;
            }
        }
        #endregion

        #region Code de la méthode ClearForm()
        private void ClearForm()
        {
            // Réinitialiser tous les champs du formulaire
            txtcode.Clear();
            txtnom.Clear();
            txtqte.Clear();
            combostatus.SelectedIndex = -1;
            dtp.Value = DateTime.Now;
            
        }
        #endregion

        #region Code du bouton d'ajout
        private void btnajout_Click(object sender, EventArgs e)
        {
            // Récupérer les valeurs des champs du formulaire du stock
            pda.prodname = txtnom.Text; // Récupère le nom du produit depuis le champ de texte "txtnom".
            pda.prodcode = txtcode.Text; // Récupère le code du produit depuis le champ de texte "txtcode".
            pda.prodstatus = false; // Par défaut, le statut est défini sur false.
            pda.transdate = DateTime.Parse(dtp.Value.ToString("dd/MM/yyyy")); // Récupère la date depuis le contrôle DateTimePicker et la convertit en format spécifique.

            int quantityValue; // Variable pour stocker la valeur de la quantité entrée par l'utilisateur.

            if (int.TryParse(txtqte.Text, out quantityValue))
            {
                pda.quantity = quantityValue; // Tente de convertir la quantité en entier depuis le champ de texte "txtqte".
            }
            else
            {
                MessageBox.Show("La quantité doit être un nombre entier valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Si la conversion échoue, affichez un message d'erreur et quitter la méthode.
            }

            // Vérifier si les champs obligatoires sont remplis
            if (string.IsNullOrEmpty(pda.prodname) || string.IsNullOrEmpty(pda.prodcode) || pda.quantity == 0)
            {
                // Afficher un message d'erreur si l'un des champs obligatoires est vide ou si la quantité est nulle.
                MessageBox.Show("Veuillez remplir tous les champs obligatoires!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int productId = pba.GetProductIdByCode(pda.prodcode); // Récupérer l'ID du produit à partir de son code.

                if (productId > 0)
                {
                    // Le produit existe, on peut insérer les données dans la table "STOCKS"
                    pda.prodid = productId; // Associe l'ID du produit trouvé à l'objet pda.

                    // Déterminer le statut en fonction de la sélection de la ComboBox
                    bool status = (combostatus.SelectedIndex == 0); // 0 correspond à "Disponible" dans la ComboBox.

                    // Mettre à jour le statut de l'objet pda en fonction de la sélection de l'utilisateur.
                    pda.prodstatus = status;

                    try
                    {
                        // Appeler la méthode StockInsert avec l'objet pda pour insérer dans la base de données.
                        pba.StockInsert(pda);

                        // Afficher un message de succès si l'insertion est réussie.
                        MessageBox.Show("Produit enregistré avec succès dans le stock!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                        ClearForm(); // Réinitialiser tous les champs du formulaire en appelant la méthode ClearForm.
                        LoadData(); // Appeler LoadData() pour charger le DataGridView
                        LoadQte();  // Appeler LoadQte() pour mettre à jour les totaux
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Echec enregistrement! " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Le produit n'existe pas dans la table "PRODUCTS", affichez un message d'erreur.
                    MessageBox.Show("Le produit avec le code spécifié n'existe pas dans la table des produits.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Code du bouton de modification
        private void btnmodif_Click(object sender, EventArgs e)
        {
            // Vérifier si un produit est sélectionné dans la DataGridView.
            if (dgvs.SelectedRows.Count == 0)
            {
                // Affiche un message d'erreur si aucun produit n'est sélectionné.
                MessageBox.Show("Veuillez sélectionner un produit à mettre à jour!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (ValidateInput())
                {
                    // Récupérer les valeurs des champs du formulaire du stock
                    pda.prodname = txtnom.Text;
                    pda.prodcode = txtcode.Text;
                    pda.prodstatus = combostatus.SelectedIndex == 0;
                    pda.transdate = dtp.Value;

                    int quantityValue;
                    if (int.TryParse(txtqte.Text, out quantityValue))
                    {
                        pda.quantity = quantityValue;
                    }

                    int productId = pba.GetProductIdByCode(pda.prodcode);

                    if (productId > 0)
                    {
                        // Le produit existe, on peut mettre à jour les données dans la table "STOCKS"
                        pda.prodid = productId;

                        // Appeler la méthode StockUpdate avec l'objet pda pour mettre à jour dans la base de données.
                        pba.StockUpdate(pda);

                        // Afficher un message de succès si la mise à jour est réussie.
                        MessageBox.Show("Produit mis à jour avec succès dans le stock!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Réinitialiser tous les champs du formulaire en appelant la méthode ClearForm.
                        ClearForm();
                        LoadData();
                        LoadQte();  // Appeler LoadQte() pour mettre à jour les totaux
                    }
                    else
                    {
                        // Le produit n'existe pas dans la table "PRODUCTS", affichez un message d'erreur.
                        MessageBox.Show("Le produit avec le code spécifié n'existe pas dans la table des produits.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                // Afficher un message d'erreur si une exception est générée.
                MessageBox.Show("Erreur lors de la mise à jour du produit : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Gestionnaire d'événements txtcode_TextChanged
        private void txtcode_TextChanged(object sender, EventArgs e)
        {
            // Récupérez le code de produit saisi
            string productCode = txtcode.Text;

            // Assurez-vous que le code de produit n'est pas vide
            if (!string.IsNullOrEmpty(productCode))
            {
                // Appelez la méthode pour rechercher le nom du produit correspondant au code
                string productName = pba.GetProductNameByCodes(productCode);
                bool productStatus = pba.GetProductStatusByCodes(productCode);

                // Définissez le texte du TextBox du nom du produit
                txtnom.Text = !string.IsNullOrEmpty(productName) ? productName : string.Empty;

                // Effacez d'abord tous les éléments existants dans le ComboBox
                combostatus.Items.Clear();
                // Maintenant, ajoutez les éléments au ComboBox
                combostatus.Items.Add("Indisponible"); // Ajoutez l'élément "Indisponible" (statut false dans la BD)
                combostatus.Items.Add("Disponible");  // Ajoutez l'élément "Disponible" (statut true dans la BD)

                // Sélectionner l'élément approprié dans le ComboBox en fonction du statut du produit
                if (productStatus)
                {
                    combostatus.SelectedIndex = 1; // Sélectionnez l'élément "True" si le statut est vrai
                }
                else
                {
                    combostatus.SelectedIndex = 0; // Sélectionnez l'élément "False" si le statut est faux
                }
            }
            else
            {
                // Si le champ de code de produit est vide, réinitialisez le nom du produit et le ComboBox
                txtnom.Text = string.Empty;
                combostatus.Items.Clear(); // Effacez tous les éléments du ComboBox
            }
        }
        #endregion

        #region LoadData()
        private void LoadData()
        {
            // Appelez la méthode StockSelect pour récupérer les données du stock
            DataTable dt = pba.StockSelect(pda);

            // Triez le DataTable par l'ID (PRODID) de la plus petite à la plus grande
            DataView dv = dt.DefaultView;
            dv.Sort = "PRODID ASC";
            DataTable sortedDt = dv.ToTable();

            // Assurez-vous que dataGridView existe déjà dans votre code
            dgvs.Rows.Clear();
            foreach (DataRow item in sortedDt.Rows)
            {
                int n = dgvs.Rows.Add();
                dgvs.Rows[n].Cells["dgvno"].Value = item["PRODID"].ToString();
                dgvs.Rows[n].Cells["dgvcode"].Value = item["PRODCODE"].ToString();
                dgvs.Rows[n].Cells["dgvnom"].Value = item["PRODNAME"].ToString();
                dgvs.Rows[n].Cells["dgvqte"].Value = int.Parse(item["QUANTITY"].ToString());
                dgvs.Rows[n].Cells["dgvdate"].Value = Convert.ToDateTime(item["TRANSDATE"].ToString());

                // Convertir la valeur du statut en chaîne "Disponible" ou "Indisponible"
                bool status = (bool)item["PRODSTATUS"];
                dgvs.Rows[n].Cells["dgvstatus"].Value = status ? "Disponible" : "Indisponible";
            }
        }
        #endregion

        #region LoadTbName() 
        //Cette méthode a pour objectif de charger des noms de produits dans un TextBox txtnom pour permettre une saisie semi-automatique.
        private void LoadTbName()
        {
            try
            {
                // Récupérer la liste des noms de produits à partir de la source de données ic la base de données stockdb
                List<string> productNames = pba.GetProductByNames();
                // Créer une collection pour l'autocomplétion des noms
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                // Parcours de la liste des noms et ajout à la collection d'autocomplétion
                foreach (string name in productNames)
                {
                    col.Add(name);
                }
                // Configurer le mode d'autocomplétion pour le TextBox txtnom
                txtnom.AutoCompleteMode = AutoCompleteMode.Suggest;
                // Attribuer la collection d'autocomplétion au TextBox txtnom
                txtnom.AutoCompleteCustomSource = col;
            }
            catch (Exception ex)
            {
                // En cas d'erreur, affichez un message d'erreur
                MessageBox.Show("Erreur lors du chargement des données : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region LoadTbCode()
        //Cette méthode a un objectif similaire à LoadTbName() elle charge des codes de produits dans un TextBox  txtcode.
        private void LoadTbCode()
        {
            try
            {

                List<string> productCodes = pba.GetProductByCodes();

                AutoCompleteStringCollection col = new AutoCompleteStringCollection();

                foreach (string code in productCodes)
                {
                    col.Add(code);
                }
                txtcode.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtcode.AutoCompleteCustomSource = col;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des données : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region LoadTbStatus()
        //Cette méthode a pour objectif de charger des statuts de produits (disponible/indisponible) dans le ComboBox combostatus.
        private void LoadTbStatus()
        {
            try
            {
                // Récupérez la liste des statuts des produits (booléens : true/false)
                List<bool> productStatus = pba.GetProductByStatus();

                // Assurez-vous que le ComboBox est vide avant d'ajouter de nouveaux éléments
                combostatus.Items.Clear();
                // Ajoutez chaque statut de produit au ComboBox en tant que chaînes de caractères
                foreach (bool status in productStatus)
                {
                    if (status)
                    {
                        combostatus.Items.Add("disponible");
                    }
                    else
                    {
                        combostatus.Items.Add("indisponible");
                    }
                }
                // Vérifiez si le ComboBox contient des éléments avant de définir SelectedIndex
                if (combostatus.Items.Count > 0)
                {
                    combostatus.SelectedIndex = 0; // Définit SelectedIndex sur 0 si le ComboBox n'est pas vide
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des données : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region LoadQte() 
        //Cette méthode parcourt les lignes du DataGridView dgvs, 
        //vérifie et additionne les quantités valides des produits, et compte le nombre total de produits.
        private void LoadQte()
        {
            int totQty = 0;          // Initialise une variable pour stocker la quantité totale
            int totalProducts = 0;   // Initialise une variable pour stocker le nombre total de produits

            foreach (DataGridViewRow row in dgvs.Rows)
            {
                if (!row.IsNewRow)  // Vérifie si la ligne n'est pas une ligne vide dans le DataGridView
                {
                    DataGridViewCell qtyCell = row.Cells["dgvqte"];  // Récupère la cellule contenant la quantité
                    if (qtyCell != null && qtyCell.Value != null)  // Vérifie si la cellule existe et contient une valeur
                    {
                        int cellValue;
                        if (int.TryParse(qtyCell.Value.ToString(), out cellValue))  // Tente de convertir la valeur en entier
                        {
                            totQty += cellValue;  // Ajoute la quantité de cette ligne à la quantité totale
                        }
                    }
                    totalProducts++;  // Incrémente le compteur de produits à chaque ligne valide
                }
            }

            lblt1.Text = totalProducts.ToString();  // Affiche le nombre total de produits dans un contrôle d'étiquette
            lblt2.Text = totQty.ToString();         // Affiche la quantité totale dans un contrôle d'étiquette
        }

        #endregion

        #region ValidateInput()
        // Cette méthode valide les données saisies dans trois champs de TextBox
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtnom.Text) || string.IsNullOrWhiteSpace(txtcode.Text))
            {
                // Afficher un message d'erreur si l'un des champs obligatoires est vide.
                MessageBox.Show("Veuillez remplir tous les champs obligatoires!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int quantityValue;
            if (!int.TryParse(txtqte.Text, out quantityValue))
            {
                MessageBox.Show("La quantité doit être un nombre entier valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        #endregion

        #region Bouton de suppression
        private void btnsuppr_Click(object sender, EventArgs e)
        {
            // Vérifier si un produit est sélectionné dans la DataGridView.
            if (dgvs.SelectedRows.Count == 0)
            {
                // Affiche un message d'erreur si aucun produit n'est sélectionné.
                MessageBox.Show("Veuillez sélectionner un produit à supprimer!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Récupérer le code du produit sélectionné.
            string selectedProductCode = dgvs.SelectedRows[0].Cells["dgvcode"].Value.ToString();

            // Confirmer la suppression du produit.
            DialogResult result = MessageBox.Show("Voulez-vous vraiment supprimer ce produit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Utiliser la méthode GetProductIdByCode pour obtenir l'ID du produit en fonction de son code.
                int productId = pba.GetProductIdByCode(selectedProductCode);

                if (productId > 0)
                {
                    // Utiliser la méthode StockDelete pour supprimer le produit du stock en utilisant son ID.
                    StocksBLL productToDelete = new StocksBLL();
                    productToDelete.prodcode = selectedProductCode;
                    pba.StockDelete(productToDelete);

                    // Afficher un message de succès.
                    MessageBox.Show("Produit supprimé avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Réinitialiser tous les champs du formulaire.
                    ClearForm();  // Appelle la méthode ClearForm pour effacer les champs.
                    LoadData();  // Rafraîchit les données affichées dans l'interface.
                    LoadQte();  // Appeler LoadQte() pour mettre à jour les totaux
                }
                else
                {
                    // Afficher un message d'erreur si le produit n'a pas été trouvé.
                    MessageBox.Show("Le produit n'existe pas dans la base de données.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Dgvs_MouseDoubleClick()
        /*
         * cette méthode permet à l'utilisateur de double-cliquer 
         * sur une ligne du DataGridView pour charger automatiquement 
         * les données de cette ligne dans les champs du formulaire 
         * facilitant ainsi la modification des informations de produit existant dans le stock.
        */
        private void dgvs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvs.SelectedRows.Count > 0)
            {
                // Récupère les valeurs de la ligne sélectionnée
                txtcode.Text = dgvs.SelectedRows[0].Cells["dgvcode"].Value.ToString();
                txtnom.Text = dgvs.SelectedRows[0].Cells["dgvnom"].Value.ToString();
                txtqte.Text = dgvs.SelectedRows[0].Cells["dgvqte"].Value.ToString();
                dtp.Text = DateTime.Parse(dgvs.SelectedRows[0].Cells["dgvdate"].Value.ToString()).ToString("dd/MM/yyyy");

                // Mettre à jour l'état de l'élément dans le ComboBox
                string status = dgvs.SelectedRows[0].Cells["dgvstatus"].Value.ToString();
                combostatus.SelectedIndex = (status == "Indisponible") ? 0 : 1;
            }
        }
        #endregion

        }

    }













































