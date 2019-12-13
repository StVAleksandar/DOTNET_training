using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;

namespace Web
{
    public partial class Login : System.Web.UI.Page
    {
        CustomersRepository repository = new CustomersRepository();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Customers customer = repository.getCustomerByID(username.Text);
            if (customer != null)
            {
                if (customer.customerID== username.Text && customer.postalCode==pass.Text)
                {
                    if (Session["User"] == null)
                    {
                        Session.Add("User", customer.customerID);
                    }
                    Response.Redirect("ProductsGrid.aspx?");
                }
            }

        }
    }
}