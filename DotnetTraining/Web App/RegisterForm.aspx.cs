using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class RegisterForm : System.Web.UI.Page
    {

        

        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //This is event handler for the Click event of the Button....
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            var name = txtName.Text;
            var email = txtEmail.Text;
            var phone = txtPhone.Text;
            var qualification = txtDetails.Text;
            var display = string.Format("The Name is {0}<br/>The Email Address: {1}<br/>The Contact No: {2}", name, email, phone);
            lblDisplay.Text = display;
        }
    }
}