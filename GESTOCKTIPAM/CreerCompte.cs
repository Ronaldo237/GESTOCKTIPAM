using GESTOCKTIPAM.BLL;
using GESTOCKTIPAM.DAL;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace GESTOCKTIPAM.GUI
{
    public partial class CreerCompte : Form
    {
        UserDAL ba = new UserDAL();
        UserBLL da = new UserBLL();
        public CreerCompte()
        {
            InitializeComponent();
        }

        private void CreerCompte_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        #region Méthode du bouton d'enregistrement
        private void btnenreg_Click(object sender, EventArgs e)
        {
            // Récupérer les valeurs des champs du formulaire
            da.username = txtusr.Text;
            da.password = txtpass.Text;
          
            string confirmPassword = txtconfirmpass.Text;

            if (string.IsNullOrEmpty(da.username) || string.IsNullOrEmpty(da.password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Veuillez remplir tous les champs!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Cette condition compare deux chaînes de caractères pour déterminer si elles sont égales après avoir été converties en minuscules (ou en majuscules, car ToLower() convertit le texte en minuscules) et après avoir supprimé les espaces en début et en fin de chaque chaîne. 
            else if (da.password.Trim().ToLower() == confirmPassword.Trim().ToLower()) // Validation des mots de passe
            {
                da.password = Cryptography.Encrypter(da.password); // Encrypter le mot de passe

                if (ba.userexiste(da))
                {
                    MessageBox.Show("Désolé, cet utilisateur existe déjà dans la base de données!");
                }
                else
                {
                    // Appeler la méthode userinsert avec l'objet da
                    ba.userinsert(da);
                    MessageBox.Show("Utilisateur enregistré avec succès!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Réinitialiser tous les champs du formulaire
                    ClearForm();
                    LoadData();  // Rafraîchit les données affichées dans l'interface.
                }
            }
            else
            {
                MessageBox.Show("Le mot de passe et le mot de passe de confirmation sont différents! Vérifiez-les.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Méthode ClearForm
        private void ClearForm()
        {
            // Réinitialiser tous les champs du formulaire
            txtusr.Text = string.Empty;
            txtpass.Text = string.Empty;
            txtconfirmpass.Text = string.Empty;
      
        }
        #endregion

        #region Méthode d'appel du formulaire de connexion
        private void btnconnexion_Click(object sender, EventArgs e)
        {
            Connexion frmcon= new Connexion();
            frmcon.Show();
            this.Hide();
        }
        #endregion

        #region Charger le datagridview
        private void LoadData()
        {
            try
            {
                // Appeler la méthode UserSelect pour récupérer les données des utilisateurs
                DataTable dt = ba.UserSelect(da);
                // Effacer le dataGridView pour y ajouter des données à jour
                dgvu.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dgvu.Rows.Add();
                    dgvu.Rows[n].Cells["dgvno"].Value = item["ID"].ToString();
                    dgvu.Rows[n].Cells["dgvname"].Value = item["USERNAME"].ToString();
                    dgvu.Rows[n].Cells["dgvpass"].Value = item["PASSWORD"].ToString();
                    // Récupérer les données binaires de la colonne PHOTO
                    if (item["PHOTO"] != DBNull.Value)
                    {
                        byte[] photoBytes = (byte[])item["PHOTO"];

                        // Convertir les données binaires en une image
                        using (MemoryStream ms = new MemoryStream(photoBytes))
                        {
                            Image originalImage = Image.FromStream(ms);

                            // Redimensionner l'image pour correspondre à la taille de la colonne
                            int imageSize = 64; // Taille souhaitée de l'image (64x64, par exemple)
                            Image resizedImage = ResizeImage(originalImage, imageSize, imageSize);

                            dgvu.Rows[n].Cells["dgvimg"].Value = resizedImage;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des données : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region redimensionner l'image
        // Fonction pour redimensionner une image
        private Image ResizeImage(Image sourceImage, int width, int height)
        {
            // Crée une nouvelle instance de la classe Bitmap 
            //pour l'image redimensionnée avec la largeur et la hauteur spécifiées.
            Bitmap resizedImage = new Bitmap(width, height);
            // Crée un objet Graphics à partir de l'image redimensionnée, 
            //ce qui permet de dessiner sur cette image.
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                // Définit le mode d'interpolation pour le redimensionnement. 
                //L'interpolation Bicubique de haute qualité produit un résultat lisse.
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                // Dessine l'image source (non redimensionnée) sur l'image redimensionnée 
                //avec les dimensions spécifiées (0, 0, width, height).
                g.DrawImage(sourceImage, 0, 0, width, height);
            }
            // Retourne l'image redimensionnée.
            return resizedImage;
        }

        #endregion

        #region Sélection l'image
        //Le bouton ci-dessous permet à l'utilisateur de sélectionner une image depuis son système de fichiers. 
        private void btnpar_Click_1(object sender, EventArgs e)
        {
            // Créer une nouvelle instance de la classe OpenFileDialog, 
            //qui permet à l'utilisateur de sélectionner un fichier à ouvrir.
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // Définir un filtre pour spécifier quels types 
            //de fichiers l'utilisateur peut sélectionner. 
            //Dans ce cas, il est configuré pour permettre les fichiers
            //d'images aux formats .jpg, .jpeg, .png, .bmp ou .gif.
            openFileDialog.Filter = "Images (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            // Afficher la boîte de dialogue de sélection de fichiers 
            //et attend que l'utilisateur fasse son choix. 
            //Si l'utilisateur appuie sur le bouton "OK" dans la boîte de dialogue, 
            //le code suivant est exécuté.
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Charger l'image depuis le fichier sélectionné par l'utilisateur en créant une instance 
                //de la classe Image à partir du chemin du fichier (openFileDialog.FileName). 
                //L'utilisation de using nous garantit que les ressources 
                //sont libérées correctement après utilisation.
                using (Image img = Image.FromFile(openFileDialog.FileName))
                {
                    // Créer une instance de la classe MemoryStream, qui permet de stocker des données en mémoire.
                    using (MemoryStream ms = new MemoryStream())
                    {
                        // On peut choisir le format approprié ici en fonction de l'extension du fichier sélectionné
                        ImageFormat imageFormat = ImageFormat.Jpeg; // Par défaut, nous utilisons le format JPEG.
                        string fileExtension = Path.GetExtension(openFileDialog.FileName).ToLower(); // Obtenir l'extension du fichier en minuscules.
                        // Vérifier l'extension du fichier pour déterminer le format de l'image.
                        if (fileExtension == ".png")
                        {
                            // Le fichier est une image PNG.
                            imageFormat = ImageFormat.Png;
                        }
                        else if (fileExtension == ".bmp")
                        {
                            // Le fichier est une image BMP.
                            imageFormat = ImageFormat.Bmp;
                        }
                        else if (fileExtension == ".gif")
                        {
                            // Le fichier est une image GIF.
                            imageFormat = ImageFormat.Gif;
                        }
                        // Sauvegarder l'image dans le format choisi dans le MemoryStream.
                        img.Save(ms, imageFormat);
                        // Convertir le contenu du MemoryStream en un tableau de bytes (byte[]) 
                        //et l'attribue à la propriété da.photo de UserBLL.
                        da.photo = ms.ToArray();
                    }
                    // Afficher l'image dans un contrôle PictureBox pbx en créant une instance 
                    //de la classe Bitmap 
                    //à partir du chemin du fichier sélectionné.
                    pbx.Image = new Bitmap(openFileDialog.FileName);
                }
            }
        }
        #endregion

    }
}

