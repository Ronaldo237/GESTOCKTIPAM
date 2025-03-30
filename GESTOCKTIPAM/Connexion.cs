using GESTOCKTIPAM.BLL;
using GESTOCKTIPAM.DAL;
using GESTOCKTIPAM.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GESTOCKTIPAM
{
    public partial class Connexion : Form
    {
        UserDAL ba = new UserDAL();
        UserBLL da = new UserBLL();
        //DataTable dt = new DataTable();
        public Connexion()
        {
            InitializeComponent();
        }

        #region Méthode du bouton effacer
        private void btneffacer_Click(object sender, EventArgs e)
        {
            txtusr.Clear();
            txtusr.Focus();
            txtpass.Text = "";
        }
        #endregion

        #region Méthode du bouton de connexion
        private void btnlogin_Click(object sender, EventArgs e)
        {
            // Récupérer les valeurs des champs du formulaire
            da.username = txtusr.Text;
            da.password = txtpass.Text;

            if (string.IsNullOrEmpty(da.username) || string.IsNullOrEmpty(da.password))
            {
                MessageBox.Show("Veuillez remplir tous les champs!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Vérifier si l'utilisateur existe dans la base de données
                bool userExists = ba.VerifyUserInDatabase(da.username, da.password);

                if (userExists)
                {
                    // Récupérer le mot de passe stocké dans la base de données
                    string storedPassword = ba.GetPasswordFromDatabase(da.username);

                    // Comparer le mot de passe entré avec le mot de passe stocké (vous devrez peut-être déchiffrer ici si nécessaire)
                    if (Cryptography.Decrypter(storedPassword).Equals(da.password))
                    {
                        MessageBox.Show("Connexion réussie", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        StockMain sm = new StockMain();
                        sm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Mauvais mot de passe!...", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Identifiants incorrects! Veuillez réessayer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btneffacer_Click(sender, e);
                }
            }
         
        }
        #endregion

        #region Méthode d'appel du formulaire de création de compte
        private void btncreercompte_Click(object sender, EventArgs e)
        {
            CreerCompte frmenreg = new CreerCompte();
            frmenreg.Show();
            this.Hide();
        }
        #endregion

        private void linkLabeloubli_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string username = txtusr.Text;
            // Appeler la méthode pour obtenir le mot de passe
            string password = ba.GetPasswordForUsername(username);

            if (!string.IsNullOrEmpty(password))
            {
                lblrecup.Text = "Votre mot de passe est " + password;
            }
            else
            {
                MessageBox.Show("Utilisateur invalide!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}
