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
        protected void Page_Load(object sender, EventArgs e)
        {
            tableErrorMessage.Visible = false;
            lblErrorMessage.Visible = false;
            lblErrorMessage.Style.Add(HtmlTextWriterStyle.Color, "red");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtEmailAddress.Text) ||
                String.IsNullOrEmpty(txtPassword.Text) ||
                String.IsNullOrEmpty(txtPasswordConfirm.Text) ||
                String.IsNullOrEmpty(txtFirstName.Text) ||
                String.IsNullOrEmpty(txtLastName.Text) ||
                String.IsNullOrEmpty(txtPhoneNumber.Text) ||
                String.IsNullOrEmpty(txtBillAddressLine1.Text) ||
                String.IsNullOrEmpty(txtBillCity.Text) ||
                String.IsNullOrEmpty(txtBillState.Text) ||
                String.IsNullOrEmpty(txtBillZipCode.Text))
            {
                lblErrorMessage.Text = "Please enter required (*) information";
                lblErrorMessage.Visible = true;
                tableErrorMessage.Visible = true;
                return;
            }

            //Do Validation for fields
            //=========================
            if (!txtPassword.Text.Equals(txtPasswordConfirm.Text))
            {
                lblErrorMessage.Text = "Passwords do not match";
                lblErrorMessage.Visible = true;
                tableErrorMessage.Visible = true;

                return;
            }


            //=========================


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
    }
}
