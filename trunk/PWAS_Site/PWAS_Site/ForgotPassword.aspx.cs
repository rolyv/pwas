using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.IO;
using System.Net.Mail;
using System.Web.Security;
using PWAS.DataAccess.Interfaces;
using PWAS.Model;

namespace PWAS_Site
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        //private string companyEmail = "XYZPrintShop@gmail.com";
        //private string companyPassword = "1234abcd";
        private string companyEmail = "javiermesa85@gmail.com";
        private string companyPassword = "reivaJ4u";

        protected void Page_Load(object sender, EventArgs e)
        {
            lblResetEmailMessage.Text = "Please enter the email address associated with the account.";
            lblResetEmailMessage.Style.Add(HtmlTextWriterStyle.Color, "Black");

            lblErrorMessage.Visible = false;
        }

        protected void btnResetPassword_Click(Object sender, EventArgs e)
        {
            Regex regex = new Regex("[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,4}");

            string emailAddress = txtEmailAddress.Text.Trim().ToUpperInvariant();
            if (String.IsNullOrEmpty(emailAddress) || !regex.IsMatch(emailAddress))
            {
                lblErrorMessage.Visible = true;
                return;
            }

            //Test if Email doesn't correspond to an account
            IUserRepository userRepo = RepositoryFactory.Get<IUserRepository>();
            bool userExists = userRepo.Users.Any(u => u.email.Equals(emailAddress));
            if (! userExists)
            {
                //Prints success for security reasons (Account Harvesting)
                lblResetEmailMessage.Text = "Success! A new password has been sent if the email provided was registered to an account";
                lblResetEmailMessage.Style.Add(HtmlTextWriterStyle.Color, "Green");
                return;
            }

            //Already checked that db entry exists. Now pull the user object!
            User editUser = userRepo.Users.First(u => u.email.Equals(emailAddress));

            //Generate Password
            string passwordGenerated = Membership.GeneratePassword(8, 0);
            
            //Work-around for bug in Membership.GeneratePassword() which adds 1 non-alphanumeric character
            Regex regexPW = new Regex("[^A-Za-z0-9]");
            passwordGenerated = regexPW.Replace(passwordGenerated,"");
 
            //Stores new Password in User table
            editUser.password = passwordGenerated;
            userRepo.SubmitChanges();

            //Emails Password
            string message = String.Empty;
            string from = companyEmail;
            string to = emailAddress;
            string subject = "Password Reset Message";
            string body = "Dear jmesa,\n"
                         + "\n"
                         + "You have requested a new password to access XYZ Print Shop's website.\n"
                         + "\n"
                         + "Use the following password to sign on\n"
                         + "\n"
                         + "Password: " + passwordGenerated + "\n"
                         + "\n"
                         + "If you have any questions, please feel free to contact us at " + companyEmail + "\n"
                         + "\n"
                         + "Sincerely, "
                         + "XYZ Support Group\n"
                         + "\n"
                         + "ABOUT THIS MESSAGE\n"
                         + "This is a service e-mail message about the XYZ Print Shop Website.\n"
                         + "Please do not reply to this service e-mail message as no response will be returned to you.\n";

            if (SendEMail(from, to, subject, body, ref message))
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
                theMailMessage.Body = "TEST BODY";
                
                SmtpClient theClient = new SmtpClient("smtp.gmail.com", 587);
                theClient.UseDefaultCredentials = true;
                theClient.EnableSsl = true;
                System.Net.NetworkCredential theCredential = new System.Net.NetworkCredential(companyEmail, companyPassword);
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
