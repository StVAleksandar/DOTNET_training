using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinesServices;

namespace NorthwindApp
{
    public partial class Form1 : Form
    {
        ProductsService product = new ProductsService();

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addProduct_Click(object sender, EventArgs e)
        {
            string productName = textBox1.Text;
            int supplierId = Convert.ToInt32(textBox2.Text);
            int categoryId = Convert.ToInt32(textBox3.Text);
            string quantityPerUnit = textBox4.Text;
            decimal unitPrice = Convert.ToDecimal(textBox5.Text);
            short unitsInStock = Convert.ToInt16(textBox6.Text);
            short unitsOnOrder = Convert.ToInt16(textBox7.Text);
            short reorderLevel = Convert.ToInt16(textBox8.Text);
            bool discontinued = Convert.ToBoolean(textBox9.Text);

            int status = product.addProducts(productName, supplierId, categoryId, quantityPerUnit, unitPrice, unitsInStock, unitsOnOrder, reorderLevel, discontinued);

            if (status == 1)
            {
                MessageBox.Show("Product added!");
            }
            else
            {
                MessageBox.Show("Product already exists!");

            }
        }

        private void deleteProduct_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox10.Text);

            int status = product.deleteProducts(id);

            if (status == 1)
            {
                MessageBox.Show("Product deleted!");
            }
            else
            {
                MessageBox.Show("Products with units on order cannot be deleted!");

            }
        }
    }
}
