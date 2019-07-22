using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class ConformationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //queryStringRetrival();
            //cookiesRetrival();
            //crossPageRetrival();
        }

        private void crossPageRetrival()
        {
            if(PreviousPage == null)
            {
                lblName.Text = "This page is viewed with no info shared by the PreviousPage";
                return;
            }
            lblName.Text = PreviousPage.NameEntry;
            lblEmail.Text = PreviousPage.EmailEntry;
            lblAge.Text = PreviousPage.AgeEntry;
        }

        private void cookiesRetrival()
        {
            if(Request.Cookies["MyCookie"] == null)
            {
                lblName.Text = "This page is viewed with no info shared by the Cookie";
                return;
            }
            var cookie = Request.Cookies["MyCookie"];
            lblName.Text = cookie.Values["Name"];
            lblEmail.Text = cookie.Values["Email"];
            lblAge.Text = cookie.Values["Age"];
        }

        private void queryStringRetrival()
        {
            if (Request.QueryString.Count == 0)
            {
                lblName.Text = "This page is viewed with no info shared by the QueryString";
                return;
            }
            lblName.Text = Request.QueryString["name"];
            lblEmail.Text = Request.QueryString["email"];
            lblAge.Text = Request.QueryString["age"];
        }
    }
}