using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.IO;
using System.Net.Mail;

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

            string message = String.Empty;

            if (SendEMail("XYZPrintShop@gmail.com", txtEmailAddress.Text.Trim(), "Password Reset Message", "This is a test body where a randomized password should go", ref message))
            {
                lblResetEmailMessage.Text = "Success! A new password has been sent if the email provided was registered to an account";
                lblResetEmailMessage.Style.Add(HtmlTextWriterStyle.Color, "Green");
            }
            else
                lblResetEmailMessage.Text = message;

            
        }

        private bool SendEMail( string from,   // e.g., "sender@csharp-online.net"
                                string to,     // e.g., "receiver@csharp-online.net"
                                string subject,// e.g., "Please read this!"
                                string body,   // e.g., "Thanks for the memories."
                                ref string message)
        {
            try
            {
                //MailMessage theMailMessage = new MailMessage("administrator@crm.com", "test@hotmail.com");
                MailMessage theMailMessage = new MailMessage();
                theMailMessage.From = new MailAddress(from);
                theMailMessage.To.Add(to);
                theMailMessage.Subject = subject;
                theMailMessage.Body = body;
                
                SmtpClient theClient = new SmtpClient("smtp.gmail.com", 587);
                theClient.UseDefaultCredentials = true;
                theClient.EnableSsl = true;
                System.Net.NetworkCredential theCredential = new System.Net.NetworkCredential("XYZPrintShop@gmail.com", "1234abcd");
                theClient.Credentials = theCredential;
                theClient.Send(theMailMessage);

                return true;
            }
            catch (Exception ex)
            {
                message = ex.ToString();
                return false;
            }
        }
    }
}
