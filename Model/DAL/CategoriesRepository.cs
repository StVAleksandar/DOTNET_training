using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    class CategoriesRepository
    {
        private string cnnString = @"Data Source = (local)\SqlExpress; Initial Catalog = Northwind; Integrated Security = true";

        public List<Categories> getAllCategories()
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = cnnString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandType = CommandType.Text;
            komanda.CommandText = @"SELECT * FROM Categories";

            SqlDataReader reader;
            List<Categories> categories = new List<Categories>();
            try
            {
                konekcija.Open();
                reader = komanda.ExecuteReader();
                while (reader.Read())
                {
                    Categories category = new Categories()
                    {
                        categoryID = (int)reader[0],
                        categoryName = reader[1].ToString(),
                        description = reader[2].ToString(),
                        picture = (byte[])reader[3]
                    };
                    categories.Add(category);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (konekcija.State == ConnectionState.Open)
                {
                    konekcija.Close();
                }
            }

            return categories;
        }



        public Categories getCategoryById(int categoryId)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = cnnString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandType = CommandType.Text;

            SqlParameter categoryIdParam
                = new SqlParameter("@categoryID", SqlDbType.Int);
            categoryIdParam.Value = categoryId;
            komanda.Parameters.Add(categoryIdParam);

            komanda.CommandText = @"SELECT * FROM Categories WHERE CategoryID = @categoryID";

            SqlDataReader reader;
            Categories category = new Categories();
            try
            {
                konekcija.Open();
                reader = komanda.ExecuteReader();
                while (reader.Read())
                {
                    category.categoryID = (int)reader[0];
                    category.categoryName = reader[1].ToString();
                    category.description = reader[2].ToString();
                    category.picture = (byte[])reader[3];
                }

                var p = category;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (konekcija.State == ConnectionState.Open)
                {
                    konekcija.Close();
                }
            }

            return category;
        }


        public void addCategory(Categories category)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = cnnString;

            try
            {
                konekcija.Open();

                SqlCommand komanda = new SqlCommand();
                komanda.Connection = konekcija;
                komanda.CommandType = CommandType.Text;
                komanda.Parameters.AddWithValue("@categoryName", category.categoryName);
                komanda.Parameters.AddWithValue("@description", category.description);
                komanda.Parameters.AddWithValue("@picture", category.picture);
                komanda.Parameters["@categoryName"].SqlDbType = SqlDbType.NVarChar;
                komanda.Parameters["@description"].SqlDbType = SqlDbType.NText;
                komanda.Parameters["@picture"].SqlDbType = SqlDbType.Image;

                komanda.CommandText =
                    @"INSERT INTO 
                        [Northwind].[dbo].[Categories] ([CategoryName], [Description], [Picture] ) 
                        VALUES (@categoryName, @description, @picture); 
                        SELECT CAST(scope_identity() AS int)";

                int categoryId = Convert.ToInt32(komanda.ExecuteScalar());

                konekcija.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (konekcija.State == ConnectionState.Open)
                {
                    konekcija.Close();
                }
            }

        }


        public void updateCategory(Categories category)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = cnnString;

            try
            {
                konekcija.Open();

                SqlCommand komanda = new SqlCommand();
                komanda.Connection = konekcija;
                komanda.CommandType = CommandType.Text;
                komanda.Parameters.AddWithValue("@categoryID", category.categoryID);
                komanda.Parameters.AddWithValue("@categoryName", category.categoryName);
                komanda.Parameters.AddWithValue("@description", category.description);
                komanda.Parameters.AddWithValue("@picture", category.picture);
                komanda.Parameters["@categoryID"].SqlDbType = SqlDbType.Int;
                komanda.Parameters["@categoryName"].SqlDbType = SqlDbType.NVarChar;
                komanda.Parameters["@description"].SqlDbType = SqlDbType.NText;
                komanda.Parameters["@picture"].SqlDbType = SqlDbType.Image;

                komanda.CommandText =
                    @"UPDATE [Northwind].[dbo].[Categories]
                        SET [CategoryName] = @categoryName,[Description] = @description,[Picture] = @picture
                        WHERE CategoryID = @categoryID";

                komanda.ExecuteNonQuery();

                konekcija.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (konekcija.State == ConnectionState.Open)
                {
                    konekcija.Close();
                }
            }
        }


        public void deleteCategory(int categoryId)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = cnnString;

            try
            {
                konekcija.Open();

                SqlCommand komanda = new SqlCommand();
                komanda.Connection = konekcija;
                komanda.CommandType = CommandType.Text;
                komanda.Parameters.AddWithValue("@categoryID", categoryId);

                komanda.Parameters["@categoryID"].SqlDbType = SqlDbType.Int;

                komanda.CommandText =
                    @"DELETE FROM [Northwind].[dbo].[Categories]  
                        WHERE CategoryID = @categoryID";

                komanda.ExecuteNonQuery();

                konekcija.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (konekcija.State == ConnectionState.Open)
                {
                    konekcija.Close();
                }
            }
        }
    }
}
