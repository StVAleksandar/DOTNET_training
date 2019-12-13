using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Model;
using InfrastructuredServices;

namespace DAL
{
    public class ProductsRepository
    {
        private string cnnString = @"Data Source = (local)\SqlExpress; Initial Catalog = Northwind; Integrated Security = true";

        LoggerService logService = new LoggerService();

        public List<Products> getAllProducts()
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = cnnString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandType = CommandType.Text;
            komanda.CommandText = @"SELECT * FROM Products";

            SqlDataReader reader;
            List<Products> products = new List<Products>();
            try
            {
                konekcija.Open();
                reader = komanda.ExecuteReader();
                while (reader.Read())
                {
                    Products product = new Products()
                    {
                        productID = (int)reader[0],
                        productName = reader[1].ToString(),
                        supplierID = (int)reader[2],
                        categoryID = (int)reader[3],
                        quantityPerUnit = reader[4].ToString(),
                        unitPrice = (decimal)reader[5],
                        unitsInStock = (short)reader[6],
                        unitsOnOrder = (short)reader[7],
                        reorderLevel = (short)reader[8],
                        discontinued = (bool)reader[9]
                    };
                    products.Add(product);
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

            return products;
        }



        public Products getProductById(int productId)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = cnnString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandType = CommandType.Text;

            SqlParameter productIdParam
                = new SqlParameter("@productID", SqlDbType.BigInt);
            productIdParam.Value = productId;
            komanda.Parameters.Add(productIdParam);

            komanda.CommandText = @"SELECT * FROM Products WHERE ProductID = @productID";

            SqlDataReader reader;
            Products product = new Products();
            try
            {
                konekcija.Open();
                reader = komanda.ExecuteReader();
                while (reader.Read())
                {
                    product.productID = (int)reader[0];
                    product.productName = reader[1].ToString();
                    product.supplierID = (int)reader[2];
                    product.categoryID = (int)reader[3];
                    product.quantityPerUnit = reader[4].ToString();
                    product.unitPrice = (decimal)reader[5];
                    product.unitsInStock = (short)reader[6];
                    product.unitsOnOrder = (short)reader[7];
                    product.reorderLevel = (short)reader[8];
                    product.discontinued = (bool)reader[9];
                }

                var p = product;

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

            return product;
        }


        public void addProduct(Products product)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = cnnString;

            try
            {
                konekcija.Open();

                SqlCommand komanda = new SqlCommand();
                komanda.Connection = konekcija;
                komanda.CommandType = CommandType.Text;
                komanda.Parameters.AddWithValue("@productName", product.productName);
                komanda.Parameters.AddWithValue("@supplierID", product.supplierID);
                komanda.Parameters.AddWithValue("@categoryID", product.categoryID);
                komanda.Parameters.AddWithValue("@quantityPerUnit", product.quantityPerUnit);
                komanda.Parameters.AddWithValue("@unitPrice", product.unitPrice);
                komanda.Parameters.AddWithValue("@unitsInStock", product.unitsInStock);
                komanda.Parameters.AddWithValue("@unitsOnOrder", product.unitsOnOrder);
                komanda.Parameters.AddWithValue("@reorderLevel", product.reorderLevel);
                komanda.Parameters.AddWithValue("@discontinued", product.discontinued);
                komanda.Parameters["@productName"].SqlDbType = SqlDbType.NVarChar;
                komanda.Parameters["@supplierID"].SqlDbType = SqlDbType.Int;
                komanda.Parameters["@categoryID"].SqlDbType = SqlDbType.Int;
                komanda.Parameters["@quantityPerUnit"].SqlDbType = SqlDbType.NVarChar;
                komanda.Parameters["@unitPrice"].SqlDbType = SqlDbType.Money;
                komanda.Parameters["@unitsInStock"].SqlDbType = SqlDbType.SmallInt;
                komanda.Parameters["@unitsOnOrder"].SqlDbType = SqlDbType.SmallInt;
                komanda.Parameters["@reorderLevel"].SqlDbType = SqlDbType.SmallInt;
                komanda.Parameters["@discontinued"].SqlDbType = SqlDbType.Bit;

                komanda.CommandText =
                    @"INSERT INTO 
                        [Northwind].[dbo].[Products] ([ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued] ) 
                        VALUES (@productName, @supplierID, @categoryID, @quantityPerUnit, @unitPrice, @unitsInStock, @unitsOnOrder, @reorderLevel, @discontinued); 
                        SELECT CAST(scope_identity() AS int)";

                int idUnetogProducta = Convert.ToInt32(komanda.ExecuteScalar());
                logService.logInfo(DateTime.Now, " Inserted product with ID: " + idUnetogProducta);
                konekcija.Close();
            }
            catch (Exception ex)
            {
                logService.logError(DateTime.Now, " Error while inserting product " + ex.Message);
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


        public void updateProduct(Products product)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = cnnString;

            try
            {
                konekcija.Open();

                SqlCommand komanda = new SqlCommand();
                komanda.Connection = konekcija;
                komanda.CommandType = CommandType.Text;
                komanda.Parameters.AddWithValue("@productID", product.productID);
                komanda.Parameters.AddWithValue("@productName", product.productName);
                komanda.Parameters.AddWithValue("@supplierID", product.supplierID);
                komanda.Parameters.AddWithValue("@categoryID", product.categoryID);
                komanda.Parameters.AddWithValue("@quantityPerUnit", product.quantityPerUnit);
                komanda.Parameters.AddWithValue("@unitPrice", product.unitPrice);
                komanda.Parameters.AddWithValue("@unitsInStock", product.unitsInStock);
                komanda.Parameters.AddWithValue("@unitsOnOrder", product.unitsOnOrder);
                komanda.Parameters.AddWithValue("@reorderLevel", product.reorderLevel);
                komanda.Parameters.AddWithValue("@discontinued", product.discontinued);
                komanda.Parameters["@productID"].SqlDbType = SqlDbType.Int;
                komanda.Parameters["@productName"].SqlDbType = SqlDbType.NVarChar;
                komanda.Parameters["@supplierID"].SqlDbType = SqlDbType.Int;
                komanda.Parameters["@categoryID"].SqlDbType = SqlDbType.Int;
                komanda.Parameters["@quantityPerUnit"].SqlDbType = SqlDbType.NVarChar;
                komanda.Parameters["@unitPrice"].SqlDbType = SqlDbType.Money;
                komanda.Parameters["@unitsInStock"].SqlDbType = SqlDbType.SmallInt;
                komanda.Parameters["@unitsOnOrder"].SqlDbType = SqlDbType.SmallInt;
                komanda.Parameters["@reorderLevel"].SqlDbType = SqlDbType.SmallInt;
                komanda.Parameters["@discontinued"].SqlDbType = SqlDbType.Bit;

                komanda.CommandText =
                    @"UPDATE [Northwind].[dbo].[Products]
                        SET [ProductName] = @productName,[SupplierID] = @supplierID,[CategoryID] = @categoryID,[QuantityPerUnit] = @quantityPerUnit,[UnitPrice] = @unitPrice,[UnitsInStock] = @unitsInStock,[UnitsOnOrder] = @unitsOnOrder,[ReorderLevel] = @reorderLevel,[Discontinued] = @discontinued
                        WHERE ProductID = @productID";

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


        public void deleteProduct(int productId)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = cnnString;

            try
            {
                konekcija.Open();

                SqlCommand komanda = new SqlCommand();
                komanda.Connection = konekcija;
                komanda.CommandType = CommandType.Text;
                komanda.Parameters.AddWithValue("@productID", productId);

                komanda.Parameters["@productID"].SqlDbType = SqlDbType.Int;

                komanda.CommandText =
                    @"DELETE FROM [Northwind].[dbo].[Products]  
                        WHERE ProductID = @productID";

                komanda.ExecuteNonQuery();
                logService.logInfo(DateTime.Now, " Deleted product with ID: " + productId);
                konekcija.Close();
            }
            catch (Exception ex)
            {
                logService.logError(DateTime.Now, " Error while deleting product " + ex.Message);
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
