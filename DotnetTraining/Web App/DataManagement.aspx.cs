using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class DataManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var data = Application["AllItems"] as List<Product>;
                lstProducts.DataTextField = "ProductName";//What the user sees..
                lstProducts.DataValueField = "ProductID";//What it represents....
                lstProducts.DataSource = data;//only Collections can be set as source to DataSource...
                lstProducts.DataBind();
            }
        }
        //This happens when the user selects an item from the listbox.... 
        protected void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = int.Parse(lstProducts.SelectedValue);
            var allItems = Application["AllItems"] as List<Product>;
            var item = allItems.Find((p) => p.ProductID == id);
            if(item == null)
            {
                Response.Write("Not found");
                return;
            }
            lblProductID.Text = item.ProductID.ToString();
            lblName.Text = item.ProductName;
            lblPrice.Text = item.ProductCost.ToString();
        }
    }
}