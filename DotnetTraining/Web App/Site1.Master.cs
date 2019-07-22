using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var items = Session["myCart"] as HashSet<Product>;
            lblCart.Text = string.Format("Cart({0})", items.Count);
        }

        protected void Unnamed1_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

        protected void lnkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("FinalCart.aspx");
        }
    }
}