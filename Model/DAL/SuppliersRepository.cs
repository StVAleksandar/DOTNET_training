using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SuppliersRepository
    {
        private string cnnString = @"Data Source = (local)\SqlExpress; Initial Catalog = Northwind; Integrated Security = true";

        public List<Suppliers> getAllSuppliers()
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = cnnString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandType = CommandType.Text;
            komanda.CommandText = @"SELECT * FROM Suppliers";

            SqlDataReader reader;
            List<Suppliers> suppliers = new List<Suppliers>();
            try
            {
                konekcija.Open();
                reader = komanda.ExecuteReader();
                while (reader.Read())
                {
                    Suppliers supplier = new Suppliers()
                    {
                        supplierID = (int)reader[0],
                        companyName = reader[1].ToString(),
                        contactName = reader[2].ToString(),
                        contactTitle = reader[3].ToString(),
                        address = reader[4].ToString(),
                        city = reader[5].ToString(),
                        region = reader[6].ToString(),
                        postalCode = reader[7].ToString(),
                        country = reader[8].ToString(),
                        phone = reader[9].ToString(),
                        fax = reader[10].ToString(),
                        homePage = reader[11].ToString()
                    };
                    suppliers.Add(supplier);
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

            return suppliers;
        }



        public Suppliers getSupplierById(int supplierId)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = cnnString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandType = CommandType.Text;

            SqlParameter supplierIdParam
                = new SqlParameter("@supplierID", SqlDbType.Int);
            supplierIdParam.Value = supplierId;
            komanda.Parameters.Add(supplierIdParam);

            komanda.CommandText = @"SELECT * FROM Suppliers WHERE SupplierID = @supplierID";

            SqlDataReader reader;
            Suppliers supplier = new Suppliers();
            try
            {
                konekcija.Open();
                reader = komanda.ExecuteReader();
                while (reader.Read())
                {
                    supplier.supplierID = (int)reader[0];
                    supplier.companyName = reader[1].ToString();
                    supplier.contactName = reader[2].ToString();
                    supplier.contactTitle = reader[3].ToString();
                    supplier.address = reader[4].ToString();
                    supplier.city = reader[5].ToString();
                    supplier.region = reader[6].ToString();
                    supplier.postalCode = reader[7].ToString();
                    supplier.country = reader[8].ToString();
                    supplier.phone = reader[9].ToString();
                    supplier.fax = reader[10].ToString();
                    supplier.homePage = reader[11].ToString();
                }

                var p = supplier;

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

            return supplier;
        }


        public void addSupplier(Suppliers supplier)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = cnnString;

            try
            {
                konekcija.Open();

                SqlCommand komanda = new SqlCommand();
                komanda.Connection = konekcija;
                komanda.CommandType = CommandType.Text;
                komanda.Parameters.AddWithValue("@companyName", supplier.companyName);
                komanda.Parameters.AddWithValue("@contactName", supplier.contactName);
                komanda.Parameters.AddWithValue("@contactTitle", supplier.contactTitle);
                komanda.Parameters.AddWithValue("@address", supplier.address);
                komanda.Parameters.AddWithValue("@city", supplier.city);
                komanda.Parameters.AddWithValue("@region", supplier.region);
                komanda.Parameters.AddWithValue("@postalCode", supplier.postalCode);
                komanda.Parameters.AddWithValue("@country", supplier.country);
                komanda.Parameters.AddWithValue("@phone", supplier.phone);
                komanda.Parameters.AddWithValue("@fax", supplier.fax);
                komanda.Parameters.AddWithValue("@homePage", supplier.homePage);
                komanda.Parameters["@companyName"].SqlDbType = SqlDbType.NVarChar;
                komanda.Parameters["@contactName"].SqlDbType = SqlDbType.NVarChar;
                komanda.Parameters["@contactTitle"].SqlDbType = SqlDbType.NVarChar;
                komanda.Parameters["@address"].SqlDbType = SqlDbType.NVarChar;
                komanda.Parameters["@city"].SqlDbType = SqlDbType.NVarChar;
                komanda.Parameters["@region"].SqlDbType = SqlDbType.NVarChar;
                komanda.Parameters["@postalCode"].SqlDbType = SqlDbType.NVarChar;
                komanda.Parameters["@country"].SqlDbType = SqlDbType.NVarChar;
                komanda.Parameters["@phone"].SqlDbType = SqlDbType.NVarChar;
                komanda.Parameters["@fax"].SqlDbType = SqlDbType.NVarChar;
                komanda.Parameters["@homePage"].SqlDbType = SqlDbType.NText;

                komanda.CommandText =
                    @"INSERT INTO 
                        [Northwind].[dbo].[Suppliers] ([CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [HomePage] ) 
                        VALUES (@companyName, @contactName, @contactTitle, @address, @city, @region, @postalCode, @country, @phone, @fax, @homePage); 
                        SELECT CAST(scope_identity() AS int)";

                int supplierId = Convert.ToInt32(komanda.ExecuteScalar());

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


        public void updateSupplier(Suppliers supplier)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = cnnString;

            try
            {
                konekcija.Open();

                SqlCommand komanda = new SqlCommand();
                komanda.Connection = konekcija;
                komanda.CommandType = CommandType.Text;
                komanda.Parameters.AddWithValue("@supplierID", supplier.supplierID);
                komanda.Parameters.AddWithValue("@companyName", supplier.companyName);
                komanda.Parameters.AddWithValue("@contactName", supplier.contactName);
                komanda.Parameters.AddWithValue("@contactTitle", supplier.contactTitle);
                komanda.Parameters.AddWithValue("@address", supplier.address);
                komanda.Parameters.AddWithValue("@city", supplier.city);
                komanda.Parameters.AddWithValue("@region", supplier.region);
                komanda.Parameters.AddWithValue("@postalCode", supplier.postalCode);
                komanda.Parameters.AddWithValue("@country", supplier.country);
                komanda.Parameters.AddWithValue("@phone", supplier.phone);
                komanda.Parameters.AddWithValue("@fax", supplier.fax);
                komanda.Parameters.AddWithValue("@homePage", supplier.homePage);
                komanda.Parameters["@supplierID"].SqlDbType = SqlDbType.Int;
                komanda.Parameters["@companyName"].SqlDbType = SqlDbType.NVarChar;
                komanda.Parameters["@contactName"].SqlDbType = SqlDbType.NVarChar;
                komanda.Parameters["@contactTitle"].SqlDbType = SqlDbType.NVarChar;
                komanda.Parameters["@address"].SqlDbType = SqlDbType.NVarChar;
                komanda.Parameters["@city"].SqlDbType = SqlDbType.NVarChar;
                komanda.Parameters["@region"].SqlDbType = SqlDbType.NVarChar;
                komanda.Parameters["@postalCode"].SqlDbType = SqlDbType.NVarChar;
                komanda.Parameters["@country"].SqlDbType = SqlDbType.NVarChar;
                komanda.Parameters["@phone"].SqlDbType = SqlDbType.NVarChar;
                komanda.Parameters["@fax"].SqlDbType = SqlDbType.NVarChar;
                komanda.Parameters["@homePage"].SqlDbType = SqlDbType.NText;

                komanda.CommandText =
                    @"UPDATE [Northwind].[dbo].[Suppliers]
                        SET [CompanyName] = @companyName,[ContactName] = @contactName,[ContactTitle] = @contactTitle,[Address] = @address,[City] = @city,[Region] = @region,[PostalCode] = @postalCode,[Country] = @country,[Phone] = @phone,[Fax] = @fax,[HomePage] = @homePage
                        WHERE SupplierID = @supplierID";

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


        public void deleteSupplier(int supplierId)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = cnnString;

            try
            {
                konekcija.Open();

                SqlCommand komanda = new SqlCommand();
                komanda.Connection = konekcija;
                komanda.CommandType = CommandType.Text;
                komanda.Parameters.AddWithValue("@supplierID", supplierId);

                komanda.Parameters["@supplierID"].SqlDbType = SqlDbType.Int;

                komanda.CommandText =
                    @"DELETE FROM [Northwind].[dbo].[Suppliers]  
                        WHERE SupplierID = @supplierID";

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
