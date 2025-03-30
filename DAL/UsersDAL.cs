using System.Data.SqlClient;
using System.Configuration;
using GESTOCKTIPAM.BLL;
using System.Data;
using System;

namespace GESTOCKTIPAM.DAL
{
    public class UserDAL
    {
        #region Méthode userinsert
        public void userinsert(UserBLL usr)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                cnx.Open();
                string query = "INSERT INTO users (username, password, photo) VALUES (@username, @password, @photo)";
                SqlCommand cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@username", usr.username);
                cmd.Parameters.AddWithValue("@password", usr.password);
                cmd.Parameters.AddWithValue("@photo", usr.photo);
                cmd.ExecuteNonQuery();
            }
        }

        #endregion

        #region Méthode userupdate
        public void userupdate(UserBLL usr)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                cnx.Open();
                string query = "UPDATE users SET username = @username, password = @password, photo = @photo WHERE ID = @id";
                SqlCommand cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@id", usr.id);
                cmd.Parameters.AddWithValue("@username", usr.username);
                cmd.Parameters.AddWithValue("@password", usr.password);
                cmd.Parameters.AddWithValue("@photo", usr.photo);
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region Méthode userexiste
        public bool userexiste(UserBLL usr)
        {
            if (usr == null || string.IsNullOrEmpty(usr.username))
            {
                return false;
            }

            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                cnx.Open();
                string query = "SELECT COUNT(*) FROM users WHERE username = @username";
                SqlCommand cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@username", usr.username);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        #endregion

        #region UserSelect méthode Sélection de tous les utilisateurs
        public DataTable UserSelect(UserBLL usr)
        {
            // Création d'un objet DataTable pour stocker les données du résultat de la requête.
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
                {
                    cnx.Open();

                    string query = "SELECT * FROM USERS ORDER BY USERNAME ASC";
                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    using (SqlDataAdapter sdap = new SqlDataAdapter(cmd))
                    {
                        // Remplissage du DataTable avec les données de la requête SQL.
                        sdap.Fill(dt);
                    }
                }
            }
            catch (SqlException ex)
            {
                // On utilise ex.Message pour obtenir des informations sur l'erreur en cas d'erreur de selection des utilisateurs.
                throw new Exception("Erreur lors de la récupération des utilisateurs.", ex);
            }

            return dt;
        }
        #endregion

        #region Méthode VerifyUserInDatabase

        //Le mot de passe stocké dans la base de données est chiffré à l'aide de la clé de chiffrement tipam2@2023xxxxxxxxxx237doualalogbessouiuc. 
        //Par conséquent, le code doit déchiffrer le mot de passe avant de le comparer au mot de passe entré par l'utilisateur. 
        //Cela est rendu possible par la méthode VerifyUserInDatabase() qui déchiffre le mot de passe stocké dans la base de données 
        //avant de le comparer au mot de passe entré par l'utilisateur.
        public bool VerifyUserInDatabase(string username, string password)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("SELECT Password FROM users WHERE username = @username", cnx);
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Récupérer le mot de passe stocké dans la base de données
                    string storedPassword = reader.GetString(0);

                    // Déchiffrer le mot de passe stocké
                    string decryptedPassword = Cryptography.Decrypter(storedPassword);

                    // Comparer le mot de passe entré avec le mot de passe stocké
                    if (decryptedPassword == password)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        #endregion

        #region Méthode GetPasswordFromDatabase 
        //Cette méthode fonctionne de la même manière que la méthode VerifyUserInDatabase(), sauf qu'elle ne renvoie pas un booléen indiquant si l'utilisateur existe ou non. Elle renvoie simplement le mot de passe stocké dans la base de données pour l'utilisateur spécifié.
        public string GetPasswordFromDatabase(string username)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("SELECT Password FROM users WHERE username = @username", cnx);
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Récupérer le mot de passe stocké dans la base de données
                    return reader.GetString(0);
                }

                return "";
            }
        }
        #endregion

        #region Méthode GetPasswordForUsername pour récupérer un mot de passe oublié
        public string GetPasswordForUsername(string username)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                cnx.Open();
                string query = "SELECT Password FROM users WHERE username = @username";
                SqlCommand cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Récupérer le mot de passe stocké dans la base de données
                    string storedPassword = reader.GetString(0);

                    // Déchiffrer le mot de passe stocké
                    string decryptedPassword = Cryptography.Decrypter(storedPassword);

                    return decryptedPassword;
                }

                // Si l'utilisateur n'existe pas, renvoyer null ou une valeur par défaut
                return null;
            }
        }
        #endregion



    }
}
