using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginCtrl_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if((loginCtrl.UserName =="training") && (loginCtrl.Password == "training123"))
            {
                FormsAuthentication.RedirectFromLoginPage(loginCtrl.UserName, true);
            }
           
            
        }
    }
}