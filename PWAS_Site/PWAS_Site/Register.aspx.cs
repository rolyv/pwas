using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using PWAS.DataAccess.Interfaces;
using PWAS.Model;
using PWAS.DataAccess.SQLRepositories;

namespace PWAS_Site
{
    public partial class Register : System.Web.UI.Page
    {
        #region Event Handlers
        protected void Page_Load(object sender, EventArgs e)
        {
            tableErrorMessage.Visible = false;
            lblErrorMessage.Visible = false;
            lblErrorMessage.Style.Add(HtmlTextWriterStyle.Color, "red");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //check that required fields are not empty
            if (!areReqFieldsEmpty())
            {
                lblErrorMessage.Text = "Please enter required (*) information";
                lblErrorMessage.Visible = true;
                tableErrorMessage.Visible = true;
                return;
            }

            //validate input -> prints error message if any
            string errorMessage = string.Empty;
            if (!areAllFieldsValid(out errorMessage))
            {
                lblErrorMessage.Text = errorMessage;
                lblErrorMessage.Visible = true;
                tableErrorMessage.Visible = true;
                return;
            }            

            IUserRepository userRepo = RepositoryFactory.Get<IUserRepository>();
            bool userExists = userRepo.Users.Any(u => u.email.Equals(txtEmailAddress.Text));

            if (userExists)
            {
                lblErrorMessage.Text = "Username (email) already in use";
                lblErrorMessage.Visible = true;
                tableErrorMessage.Visible = true;
                //return email already in use error message
                return;
            }

            User newUser = new User();
            newUser.email = txtEmailAddress.Text.Trim();
            newUser.password = Security.MD5Encode(txtPassword.Text.Trim());
            newUser.firstName = txtFirstName.Text.Trim();
            newUser.lastName = txtLastName.Text.Trim();
            newUser.company = txtCompanyName.Text.Trim();
            newUser.homePhone = txtPhoneNumber.Text.Trim();
            newUser.b_address1 = txtBillAddressLine1.Text.Trim();
            newUser.b_address2 = txtBillAddressLine2.Text.Trim();
            newUser.b_city = txtBillCity.Text.Trim();
            newUser.b_state = txtBillState.Text.Trim();
            newUser.b_zip = txtBillZipCode.Text.Trim();

            userRepo.AddUser(newUser);
            userRepo.SubmitChanges();

            Response.Redirect("/index.aspx");
        }
        #endregion

        #region Helper Methods
        private bool areAllFieldsValid(out string errorMessage)
        {
            bool validEmail =  Utilities.IsValidEmail(txtEmailAddress.Text);
            bool validPassword = Utilities.isValidPassword(txtPassword.Text, 6, 8);
            bool validPasswordMatch = txtPassword.Text.Equals(txtPasswordConfirm.Text);
            bool validName = Utilities.IsValidName(txtFirstName.Text) && Utilities.IsValidName(txtLastName.Text);
            //not validating company name.
            bool validPhone = Utilities.IsValidPhone(txtPhoneNumber.Text);
            //not validating address1 field            
            //not validating address2 field
            bool validCity = Utilities.IsValidName(txtBillCity.Text);
            bool validState = Utilities.IsValidState(txtBillState.Text);
            bool validZip = Utilities.IsValidZip(txtBillZipCode.Text);

            if (validEmail && validPassword && validPasswordMatch && validName && validPhone && validCity && validState && validZip)
            {
                errorMessage = "";
                return true;
            }
            else
            {
                if (!validEmail) errorMessage = "Please enter a valid Email.";
                else if (!validPassword) errorMessage = "Please enter a valid password, which <br />consists of 6 to 8 letters and/or digits.";
                else if (!validPasswordMatch) errorMessage = "Password does not match Confirm Password.";
                else if (!validName) errorMessage = "Please note that your First and Last Name must be composed of only letters.";
                else if (!validPhone) errorMessage = "Please enter a 10 or 11 digit phone number.";
                else if (!validCity) errorMessage = "Please enter only letters for the name of the City you live in.";
                else if (!validState) errorMessage = "Please enter a 2 letter State";
                else errorMessage = "Please enter a 5 digit Zip Code.";
                return false;
            }
        }

        private bool areReqFieldsEmpty()
        {
            if (String.IsNullOrEmpty(txtEmailAddress.Text.Trim()) ||
                String.IsNullOrEmpty(txtPassword.Text.Trim()) ||
                String.IsNullOrEmpty(txtPasswordConfirm.Text.Trim()) ||
                String.IsNullOrEmpty(txtFirstName.Text.Trim()) ||
                String.IsNullOrEmpty(txtLastName.Text.Trim()) ||
                String.IsNullOrEmpty(txtPhoneNumber.Text.Trim()) ||
                String.IsNullOrEmpty(txtBillAddressLine1.Text.Trim()) ||
                String.IsNullOrEmpty(txtBillCity.Text.Trim()) ||
                String.IsNullOrEmpty(txtBillState.Text.Trim()) ||
                String.IsNullOrEmpty(txtBillZipCode.Text.Trim()))
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
