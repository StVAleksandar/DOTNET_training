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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductsRepository repository = new ProductsRepository();
            List<Products> products = repository.getAllProducts();

            //GridView1.DataSource = products;
            //GridView1.DataBind();

            //ListBox1.SelectionMode = ListSelectionMode.Multiple;
            //ListBox2.SelectionMode = ListSelectionMode.Multiple;

            RadioButtonList1.RepeatColumns = 3;
            RadioButtonList1.RepeatDirection = RepeatDirection.Vertical;
            CheckBoxList1.RepeatColumns = 3;
            CheckBoxList1.RepeatDirection = RepeatDirection.Horizontal;

            if (!IsPostBack)
            {
                //DropDownList1.DataSource = products;
                //DropDownList1.DataTextField = "productID";
                //DropDownList1.DataValueField = "productID";
                //DropDownList1.DataBind();

                //ListBox1.DataSource = products;
                //ListBox1.DataTextField = "productID";
                //ListBox1.DataValueField = "productID";
                //ListBox1.DataBind();

                RadioButtonList1.DataSource = products;
                RadioButtonList1.DataTextField = "productID";
                RadioButtonList1.DataValueField = "productID";
                CheckBoxList1.DataSource = products;
                CheckBoxList1.DataTextField = "productName";
                CheckBoxList1.DataValueField = "productName";
                DataBind();
            }



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //    Label1.Text = DropDownList1.SelectedValue;


            //foreach (ListItem item in ListBox1.Items)
            //{
            //    if (item.Selected)
            //    {
            //        ListBox2.Items.Add(item);
            //    }
            //}
            //ListBox2.DataBind();
            Label1.Text = RadioButtonList1.SelectedItem.ToString() + "<br/>";
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected)
                {
                    Label1.Text += item.Text + "<br/>";
                }
            }
        }
    }
}