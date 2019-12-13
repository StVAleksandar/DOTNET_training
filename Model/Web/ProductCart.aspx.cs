using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

namespace Web
{
    public partial class ProductCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx?");
            }

            List<OrderItem> orderItems = new List<OrderItem>();
            foreach (var kvPair in GetCart())
            {
                orderItems.Add(kvPair.Value);
            }

            decimal totalPrice = 0;

            TableRow tableHeaderRow = new TableRow();
            TableCell nameLabelCell = new TableCell { Text = "Product Name" };
            TableCell pricePerUnitCell = new TableCell { Text = "Unit Price" };
            TableCell quantityLabelCell = new TableCell { Text = "Quantity" };
            TableCell priceLabelCell = new TableCell { Text = "Price" };
            tableHeaderRow.Cells.Add(nameLabelCell);
            tableHeaderRow.Cells.Add(pricePerUnitCell);
            tableHeaderRow.Cells.Add(quantityLabelCell);
            tableHeaderRow.Cells.Add(priceLabelCell);
            TableCart.Rows.Add(tableHeaderRow);

            foreach (var orderItem in orderItems)
            {
                TableRow tableRow = new TableRow();

                TableCell nameCell = new TableCell { Text = orderItem.Product.productName };
                TableCell unitPriceCell = new TableCell { Text = orderItem.Product.unitPrice.ToString() };
                TableCell quantityCell = new TableCell { Text = orderItem.Quantity.ToString() };
                decimal price = orderItem.Product.unitPrice * orderItem.Quantity;
                totalPrice += price;
                TableCell pricelCell = new TableCell { Text = price.ToString() };

                tableRow.Cells.Add(nameCell);
                tableRow.Cells.Add(unitPriceCell);
                tableRow.Cells.Add(quantityCell);
                tableRow.Cells.Add(pricelCell);
                TableCart.Rows.Add(tableRow);
            }

            TableRow totalPriceRow = new TableRow();
            TableCell totalPriceLabelCell = new TableCell { Text = "TOTAL PRICE" };
            totalPriceLabelCell.ColumnSpan = 5;
            TableCell totalPriceCell = new TableCell { Text = totalPrice.ToString() };
            totalPriceRow.Cells.Add(totalPriceLabelCell);
            totalPriceRow.Cells.Add(totalPriceCell);
            TableCart.Rows.Add(totalPriceRow);

        }

        private Dictionary<int, OrderItem> GetCart()
        {
            if (Session["Cart"] == null)
            {
                Session.Add("Cart", new Dictionary<int, OrderItem>());
            }
            Dictionary<int, OrderItem> cartDict = (Dictionary<int, OrderItem>)Session["Cart"];
            return cartDict;
        }
    }
}