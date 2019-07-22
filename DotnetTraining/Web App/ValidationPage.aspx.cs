using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class ValidationPage : System.Web.UI.Page
    {
        public string NameEntry => txtName.Text;
        public string EmailEntry => txtEmail.Text;
        public string AgeEntry => txtAge.Text;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //This will be the server side validation....
        protected void Unnamed3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //After all the other validations are completed, then the server side validation happens. 
            HashSet<string> emails = new HashSet<string>();
            emails.Add("ceo@gmail.com");
            emails.Add("phanirajbn@gmail.com");
            emails.Add("banutej@gmail.com");
            emails.Add("vinodkumar@gmail.com");
            emails.Add("joydip@gmail.com");
            bool valid = emails.Add(args.Value);
            args.IsValid = valid;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Page is the base type for all the Web pages in .NET It has a property called IsValid which Contains the info about the validity of the Page.  
            //if (Page.IsValid)
            //{
            //    //queryStringDemo();
            //    cookiesDemo();
            //}
        }

        private void cookiesDemo()
        {
            HttpCookie cookie = new HttpCookie("MyCookie");
            cookie.Values.Add("Name", txtName.Text);
            cookie.Values.Add("Email", txtEmail.Text);
            cookie.Values.Add("Age", txtAge.Text);
            Response.Cookies.Add(cookie);
            Response.Redirect("ConformationPage.aspx");
            
        }

        private void queryStringDemo()
        {
            var strUrl = string.Format("ConformationPage.aspx?name={0}&email={1}&age={2}", txtName.Text, txtEmail.Text, txtAge.Text);
            Response.Redirect(strUrl);
        }
    }
}