using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Model;

namespace Web
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        ProductsRepository repository = new ProductsRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx?");
            }

            int id = Convert.ToInt32(Request.QueryString["id"]);
            Products product = repository.getProductById(id);
            List<Products> products = new List<Products>();
            products.Add(product);

            ProductDetailsGridView.DataSource = products;
            ProductDetailsGridView.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            Products product = repository.getProductById(id);

            OrderItem orderItem = new OrderItem
            {
                ProductId = id,
                Product = product,
                Quantity = Convert.ToInt32(TextBox1.Text)
            };

            AddToCart(orderItem);
            Response.Redirect("ProductCart.aspx?");
        }

        private void AddToCart(OrderItem orderItem)
        {
            Dictionary<int, OrderItem> cart = GetCart();

            if (cart.ContainsKey(orderItem.ProductId))
            {
                cart[orderItem.ProductId].Quantity += orderItem.Quantity;
            }
            else
            {
                cart.Add(orderItem.ProductId, orderItem);
            }
            Session.Remove("Cart");
            Session.Add("Cart", cart);
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