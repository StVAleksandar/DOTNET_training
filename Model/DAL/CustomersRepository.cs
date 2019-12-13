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
    public class CustomersRepository
    {
        private string cnnString = @"Data Source = (local)\SqlExpress; Initial Catalog = Northwind; Integrated Security = true";

        LoggerService logService = new LoggerService();

        public Customers getCustomerByID(string customerID)
        {
            SqlConnection konekcija = new SqlConnection();
            konekcija.ConnectionString = cnnString;
            SqlCommand komanda = new SqlCommand();
            komanda.Connection = konekcija;
            komanda.CommandType = CommandType.Text;

            SqlParameter customerIdParam
                = new SqlParameter("@customerID", SqlDbType.NChar);
            customerIdParam.Value = customerID;
            komanda.Parameters.Add(customerIdParam);

            komanda.CommandText = @"SELECT * FROM Customers WHERE CustomerID = @customerID";

            SqlDataReader reader;
            Customers customer = new Customers();
            try
            {
                konekcija.Open();
                reader = komanda.ExecuteReader();
                while (reader.Read())
                {
                    customer.customerID = reader[0].ToString();
                    customer.companyName = reader[1].ToString();
                    customer.contactName = reader[2].ToString();
                    customer.contactTitle = reader[3].ToString();
                    customer.address = reader[4].ToString();
                    customer.city = reader[5].ToString();
                    customer.region = reader[6].ToString();
                    customer.postalCode = reader[7].ToString();
                    customer.country = reader[8].ToString();
                    customer.phone = reader[9].ToString();
                    customer.fax = reader[9].ToString();
                }

                var p = customer;

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

            return customer;
        }
    }
}
