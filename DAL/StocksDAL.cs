using GESTOCKTIPAM.BLL; // Importe l'espace de noms GESTOCKTIPAM.BLL
using System; // Importe l'espace de noms System
using System.Collections.Generic; // Importe l'espace de noms System.Collections.Generic
using System.Configuration; // Importe l'espace de noms System.Configuration
using System.Data; // Importe l'espace de noms System.Data
using System.Data.SqlClient; // Importe l'espace de noms System.Data.SqlClient

namespace GESTOCKTIPAM.DAL // Déclare un espace de noms GESTOCKTIPAM.DAL
{
    public class StocksDAL // Définit une classe StocksDAL
    {
        //  requêtes préparées

        #region StockInsert méthode d'insertion des stocks
        public void StockInsert(StocksBLL stk)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                cnx.Open();
                // Définition de la requête SQL pour l'insertion des stocks
                string query = "INSERT INTO STOCKS (PRODID, PRODNAME, TRANSDATE, QUANTITY, PRODCODE, PRODSTATUS) VALUES (@prodid, @prodname, @transdate, @quantity, @prodcode, @prodstatus)";
                SqlCommand cmd = new SqlCommand(query, cnx);

                // Assignation des paramètres de la requête aux propriétés de l'objet StocksBLL
                cmd.Parameters.AddWithValue("@prodid", stk.prodid);
                cmd.Parameters.AddWithValue("@prodname", stk.prodname);
                cmd.Parameters.AddWithValue("@transdate", stk.transdate);
                cmd.Parameters.AddWithValue("@quantity", stk.quantity);
                cmd.Parameters.AddWithValue("@prodcode", stk.prodcode);
                cmd.Parameters.AddWithValue("@prodstatus", stk.prodstatus);

                // Exécution de la requête SQL
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region StockUpdate méthode de Mise à jour des stocks
        public void StockUpdate(StocksBLL stk)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                cnx.Open();
                // Définition de la requête SQL pour la mise à jour des stocks
                string query = "UPDATE STOCKS SET PRODNAME = @prodname, TRANSDATE = @transdate, QUANTITY = @quantity, PRODCODE = @prodcode, PRODSTATUS = @prodstatus WHERE  PRODCODE = @prodcode_where";
                SqlCommand cmd = new SqlCommand(query, cnx);

                // Assignation des paramètres de la requête aux propriétés de l'objet StocksBLL
                cmd.Parameters.AddWithValue("@prodname", stk.prodname);
                cmd.Parameters.AddWithValue("@transdate", stk.transdate);
                cmd.Parameters.AddWithValue("@quantity", stk.quantity);
                cmd.Parameters.AddWithValue("@prodcode", stk.prodcode);
                cmd.Parameters.AddWithValue("@prodcode_where", stk.prodcode);
                cmd.Parameters.AddWithValue("@prodstatus", stk.prodstatus);

                // Exécution de la requête SQL
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region StockDelete méthode de Suppression des produits du stock
        public void StockDelete(StocksBLL stk)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                cnx.Open();
                // Définition de la requête SQL pour la suppression des produits
                string query = "DELETE FROM STOCKS WHERE prodcode = @prodcode";
                SqlCommand cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@prodcode", stk.prodcode);

                // Exécution de la requête SQL
                cmd.ExecuteNonQuery();
            }
        }

        #endregion

        #region StockExist méthode de vérification d'existence d'un produit dans les stocks
        public bool StockExist(StocksBLL stk)
        {
            if (stk == null || string.IsNullOrEmpty(stk.prodcode))
            {
                return false;
            }
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                cnx.Open();
                // Définition de la requête SQL pour vérifier l'existence d'un produit dans les stocks
                string query = "SELECT COUNT(*) FROM STOCKS WHERE PRODCODE = @prodcode";
                SqlCommand cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@prodcode", stk.prodcode);
                /* ExecuteScalar() exécute la commande SQL et 
                 * renvoit la première colonne de la première ligne du résultat de la requête*/
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        #endregion

        #region GetProductIdByCode méthode pour récupérer l'ID du produit en fonction de son code
        public int GetProductIdByCode(string productCode)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                cnx.Open();
                // Définition de la requête SQL pour obtenir l'ID du produit en fonction de son code
                string query = "SELECT ID FROM PRODUCTS WHERE CODE = @code";
                SqlCommand cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@code", productCode);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }

                return 0; // Retournez 0 si le produit n'a pas été trouvé
            }
        }
        #endregion

        #region  GetProductNameByCodes méthode pour récupérer le nom du produit en fonction de son code
        //Cette méthode est conçue pour récupérer le nom d'un produit en fonction de son code spécifique.
        public string GetProductNameByCodes(string productCode)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                cnx.Open();
                // Définition de la requête SQL pour obtenir le nom du produit en fonction de son code
                string query = "SELECT NAME FROM PRODUCTS WHERE CODE = @code";
                SqlCommand cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@code", productCode);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    return result.ToString();
                }

                return string.Empty; // Retournez une chaîne vide si le produit n'a pas été trouvé
            }
        }
        #endregion

        #region GetProductStatusByCodes méthode pour récupérer le statut du produit en fonction de son code
        //Cette méthode est conçue pour récupérer le statut d'un produit en fonction de son code spécifique.
        public bool GetProductStatusByCodes(string productCode)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                cnx.Open();
                // Définition de la requête SQL pour obtenir le statut du produit en fonction de son code
                string query = "SELECT STATUS FROM PRODUCTS WHERE CODE = @code";
                SqlCommand cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@code", productCode);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToBoolean(result);
                }

                return false; // Retournez false si le produit n'a pas été trouvé ou si le statut est faux
            }
        }
        #endregion

        #region Récupération des codes de produits
        public List<string> GetProductByCodes()
        {
            // Déclaration et initialisation d'une liste de chaînes productCodes pour stocker les codes de produits extraits de la base de données.
            List<string> productCodes = new List<string>();

            // Utilisation d'un bloc using pour gérer la connexion à la base de données, garantissant la fermeture appropriée même en cas d'exception.
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                cnx.Open();

                // Requête SQL pour sélectionner les codes de produits depuis la table "products".
                string selectQuery = "SELECT code FROM products";

                using (SqlCommand cmd = new SqlCommand(selectQuery, cnx))
                {
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        // Boucle while itérant sur les résultats du lecteur de données.
                        while (rd.Read())
                        {
                            // Utilisation de GetOrdinal pour obtenir l'indice de la colonne "code".
                            // Cela garantit la fiabilité en cas de modification de la structure de la table.
                            string productCode = rd.GetString(rd.GetOrdinal("code"));
                            productCodes.Add(productCode);
                        }
                    }
                }
            }

            // Retourne la liste des codes de produits une fois la requête réalisée.
            return productCodes;
        }
        #endregion

        #region GetProductByNames récupération des noms de produits
        //Cette méthode est conçue pour récupérer les noms de tous les produits de la base de données.
        public List<string> GetProductByNames()
        {
            // Déclaration et initialisation d'une liste de chaînes productNames pour stocker les noms de produits extraits de la base de données.
            List<string> productNames = new List<string>();

            // Utilisation d'un bloc using pour gérer la connexion à la base de données, garantissant la fermeture appropriée même en cas d'exception.
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                cnx.Open();

                // Requête SQL pour sélectionner les noms de produits depuis la table "products".
                string selectQuery = "SELECT name FROM products";

                using (SqlCommand cmd = new SqlCommand(selectQuery, cnx))
                {
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        // Boucle while itérant sur les résultats du lecteur de données.
                        while (rd.Read())
                        {
                            // Obtention du nom du produit depuis la colonne "name".
                            string productName = rd.GetString(rd.GetOrdinal("name"));
                            productNames.Add(productName);
                        }
                    }
                }
            }

            // Retourne la liste des noms de produits une fois la requête réalisée.
            return productNames;
        }
        #endregion

        #region GetProductByStatus récupération des statuts de produits
        //Cette méthode est conçue pour récupérer les statuts de tous les produits de la base de données.
        public List<bool> GetProductByStatus()
        {
            // Déclaration et initialisation d'une liste de booléens productStatus pour stocker les statuts de produits extraits de la base de données.
            List<bool> productStatus = new List<bool>();

            // Requête SQL pour sélectionner les statuts de produits depuis la table "products".
            string query = "SELECT status FROM products";

            // Utilisation d'un bloc using pour gérer la connexion à la base de données, garantissant la fermeture appropriée même en cas d'exception.
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand(query, cnx))
                {
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        // Boucle while itérant sur les résultats du lecteur de données.
                        while (rd.Read())
                        {
                            // Utilisation de GetBoolean pour obtenir une valeur booléenne depuis la colonne "status".
                            bool status = rd.GetBoolean(rd.GetOrdinal("status"));
                            productStatus.Add(status);
                        }
                    }
                }
            }

            // Retourne la liste des statuts de produits une fois la requête réalisée.
            return productStatus;
        }
        #endregion

        //#region StockSelect avec dataset méthode Selection de tous les produits du stock
        //public DataSet StockSelectReport(StocksBLL stk, DateTime fromDate, DateTime toDate)
        //{
        //    // Création d'un objet DataSet pour stocker les données du résultat de la requête.
        //    DataSet ds = new DataSet();

        //    using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
        //    {
        //        cnx.Open();

        //        // Définition de la requête SQL pour sélectionner tous les produits du stock, triés par ordre croissant du nom du produit.
        //        string query = "SELECT * FROM STOCKS WHERE CAST(TransDate AS DATE) BETWEEN @FromDate AND @ToDate ORDER BY PRODNAME ASC";
        //        SqlCommand cmd = new SqlCommand(query, cnx);

        //        // Ajout des paramètres @FromDate et @ToDate avec leurs valeurs
        //        cmd.Parameters.AddWithValue("@FromDate", fromDate);
        //        cmd.Parameters.AddWithValue("@ToDate", toDate);

        //        SqlDataAdapter sdap = new SqlDataAdapter(cmd);

        //        // Remplissage du DataSet avec les données de la requête SQL.
        //        sdap.Fill(ds);
        //    }

        //    return ds;
        //}
        //#endregion

        #region StockSelect  méthode Selection de tous les produits du stock pour affichage dans le rapport
        /*
         Cette fonction exécute une requête SQL qui sélectionne les enregistrements de la table STOCKS
         où la date de transaction est comprise entre fromDate et toDate, triés par ordre croissant du nom du produit. 
         */
        public DataSet StockSelectReport(StocksBLL stk, DateTime fromDate, DateTime toDate)
        {
            // Création d'un objet DataSet pour stocker les données du résultat de la requête.
            DataSet ds = new DataSet();

            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                cnx.Open();

                // Formatage des dates pour correspondre au format de la base de données SQL Server (MM/dd/yyyy)
                //à l'aide de la méthode ToString
                string formattedFromDate = fromDate.ToString("MM/dd/yyyy");
                string formattedToDate = toDate.ToString("MM/dd/yyyy");

                // Définition de la requête SQL pour sélectionner tous les produits du stock, triés par ordre croissant du nom du produit.
                string query = "SELECT * FROM STOCKS WHERE CAST(TransDate AS DATE) BETWEEN '" + formattedFromDate + "' AND '" + formattedToDate + "' ORDER BY PRODNAME ASC";
                SqlCommand cmd = new SqlCommand(query, cnx);

                SqlDataAdapter sdap = new SqlDataAdapter(cmd);

                // Remplissage du DataSet avec les données de la requête SQL.
                sdap.Fill(ds);
            }

            return ds;
        }
        #endregion


        #region StockSelect avec datatable méthode Selection de tous les produits du stock pour affichage dans le datagridview
        public DataTable StockSelect(StocksBLL stk)
        {
            // Création d'un objet DataTable pour stocker les données du résultat de la requête.
            DataTable dt = new DataTable();

            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                cnx.Open();
                // Définition de la requête SQL pour sélectionner tous les produits du stock, triés par ordre croissant du nom du produit.
                string query = "SELECT * FROM STOCKS ORDER BY PRODNAME ASC";
                SqlCommand cmd = new SqlCommand(query, cnx);
                SqlDataAdapter sdap = new SqlDataAdapter(cmd);

                // Remplissage du DataTable avec les données de la requête SQL.
                sdap.Fill(dt);
            }

            return dt;
        }
        #endregion


    }
}
