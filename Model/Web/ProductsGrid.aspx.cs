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
    public partial class ProductsGrid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"]==null)
            {
                Response.Redirect("Login.aspx?");
            }

            ProductsRepository repository = new ProductsRepository();
            List<Products> products = repository.getAllProducts();

            ProductsGridView.DataSource = products;
            ProductsGridView.DataBind();
        }
    }
}