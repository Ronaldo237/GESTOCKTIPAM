using GESTOCKTIPAM.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTOCKTIPAM.DAL
{
    public class ProductsDAL
    {
        #region Méthode d'insertion des produits
        public void ProductInsert(ProductsBLL prdt)
        {
           
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                cnx.Open();
                string query = "INSERT INTO Products (name, status, code) VALUES (@name, @status, @code)";
                SqlCommand cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@name", prdt.name);
                cmd.Parameters.AddWithValue("@status", prdt.status);
                cmd.Parameters.AddWithValue("@code", prdt.code);

                cmd.ExecuteNonQuery();
            }
        }

        #endregion

        #region Méthode de Mise à jour des produits
        public void ProductUpdate(ProductsBLL prdt, bool status)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                cnx.Open();
                string query = "UPDATE products SET name = @name, status = @status, code = @code WHERE code = @code_where";
                SqlCommand cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@name", prdt.name);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@code", prdt.code);
                cmd.Parameters.AddWithValue("@code_where", prdt.code);

                cmd.ExecuteNonQuery();
            }
        }
        #endregion

        #region Méthode de Suppression des produits
        public void ProductDelete(ProductsBLL prdt)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                cnx.Open();
                string query = "DELETE FROM products WHERE code = @code";
                SqlCommand cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@code", prdt.code);

                cmd.ExecuteNonQuery();
            }
        }
        #endregion
      
        #region Méthode Selection des produits
        public DataTable ProductSelect(ProductsBLL pdt)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                cnx.Open();
                //La requête SQL ci-dessous permet de sélectionner tous les produits 
                //de la base de données et de les trier par ordre alphabétique croissant en fonction de leur nom grâce à la clauseORDER BY Name ASC
                //ASC est utilisé pour indiquer que les résultats d'une requête doivent être triés dans l'ordre croissant et DESC dans le cas contraire.
                string query = "SELECT * FROM Products ORDER BY Name ASC";
                SqlCommand cmd = new SqlCommand(query, cnx);
                SqlDataAdapter sdap = new SqlDataAdapter(cmd);
                sdap.Fill(dt);
            }

            return dt;
        }

        #endregion

        #region Méthode de Recherche des produits
        //Cette méthode prend en entrée le code du produit à rechercher.Elle retourne un objet DataTable contenant les données du produit correspondant.
        //public DataTable searchproducts(ProductsBLL pdt)
        public DataTable ProductSearch(string keyword)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                cnx.Open();
                string query = "SELECT * FROM Products WHERE code LIKE '%" + keyword + "%' OR name LIKE '%" + keyword + "%'";
                // Utiliser la méthode LIKE pour rechercher les produits
                SqlCommand cmd = new SqlCommand(query, cnx);
                SqlDataAdapter sdap = new SqlDataAdapter(cmd);
                sdap.Fill(dt);
            }

            return dt;
        }
        #endregion

        #region Méthode de vérification d'existence d'un poduit
        public bool ProductExist(ProductsBLL prdt)
        {
            if (prdt == null || string.IsNullOrEmpty(prdt.code))
            {
                return false;
            }

            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                cnx.Open();
                string query = "SELECT COUNT(*) FROM Products WHERE code = @code";
                SqlCommand cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@code", prdt.code);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        #endregion




        #region Méthodes connexes

        public void ProductsUpdate(ProductsBLL prdt, bool status)
        {
            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                cnx.Open();
                SqlTransaction transaction = cnx.BeginTransaction();

                try
                {
                    // Mettre à jour la table PRODUCTS
                    string updateProductsQuery = "UPDATE products SET name = @name, status = @status, code = @code WHERE code = @code_where";
                    SqlCommand productsCmd = new SqlCommand(updateProductsQuery, cnx, transaction);
                    productsCmd.Parameters.AddWithValue("@name", prdt.name);
                    productsCmd.Parameters.AddWithValue("@status", status);
                    productsCmd.Parameters.AddWithValue("@code", prdt.code);
                    productsCmd.Parameters.AddWithValue("@code_where", prdt.code);

                    productsCmd.ExecuteNonQuery();

                    // Mettre à jour la table STOCKS
                    string updateStocksQuery = "UPDATE STOCKS SET PRODNAME = @prodname, TRANSDATE = @transdate, QUANTITY = @quantity, PRODCODE = @prodcode, PRODSTATUS = @prodstatus WHERE  PRODCODE = @prodcode_where";
                    SqlCommand stocksCmd = new SqlCommand(updateStocksQuery, cnx, transaction);
                    stocksCmd.Parameters.AddWithValue("@prodname", prdt.name);
                    stocksCmd.Parameters.AddWithValue("@prodstatus", status);
                    stocksCmd.Parameters.AddWithValue("@prodcode", prdt.code);
                    stocksCmd.Parameters.AddWithValue("@prodcode_where", prdt.code);

                    stocksCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw; // Gérer l'exception ou la remonter pour indiquer qu'une erreur s'est produite
                }
            }
        }
        public List<ProductsBLL> GetAllProducts()
        {
            List<ProductsBLL> products = new List<ProductsBLL>();

            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                cnx.Open();
                string query = "SELECT * FROM Products ORDER BY Name ASC";
                SqlCommand cmd = new SqlCommand(query, cnx);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProductsBLL product = new ProductsBLL(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetBoolean(3));
                    products.Add(product);
                }

                reader.Close();
            }

            return products;
        }

        public ProductsBLL GetProductById(int id)
        {
            ProductsBLL prdt = null;

            using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                cnx.Open();
                string query = "SELECT * FROM Products WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    prdt = new ProductsBLL(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetBoolean(3));
                }

                reader.Close();
            }

            return prdt;
        }

        #endregion
    }
}
