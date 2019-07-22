using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class FinalCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var cart = Session["myCart"] as HashSet<Product>;
                rpCart.DataSource = cart;
                rpCart.DataBind();
                loadFinalAmount();
            }
        }
        private void loadFinalAmount()
        {
            var items = Session["myCart"] as HashSet<Product>;
            var totalAmount = 0.0;
            foreach(var item in items)
            {
                totalAmount += item.ProductCost * item.Quantity;
            }
            lblFinalPrice.Text = string.Format("{0:C}",totalAmount);
        }

        protected void btnPayment_Click(object sender, EventArgs e)
        {
            Response.Write(string.Format("The payment of {0} is made thro Credit Cart", lblFinalPrice.Text));
            Session.Abandon();
        }
    }
}