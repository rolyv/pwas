using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace PWAS_Site
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblResetEmailMessage.Text = "Please enter the email address associated with the account.";
            lblResetEmailMessage.Style.Add(HtmlTextWriterStyle.Color, "Black");

            lblErrorMessage.Visible = false;
        }

        protected void btnResetPassword_Click(Object sender, EventArgs e)
        {
            Regex regex = new Regex("[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,4}");

            if (String.IsNullOrEmpty(txtEmailAddress.Text.Trim()) || !regex.IsMatch(txtEmailAddress.Text.Trim().ToUpperInvariant()))
            {
                lblErrorMessage.Visible = true;
                return;
            }

            lblResetEmailMessage.Text = "Success! A new password has been sent if the email provided was registered to an account";
            lblResetEmailMessage.Style.Add(HtmlTextWriterStyle.Color, "Green");
        }
    }
}
