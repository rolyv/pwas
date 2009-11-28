using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PWAS.DataAccess.Interfaces;
using PWAS.Model;
using PWAS.DataAccess.SQLRepositories;

namespace PWAS_Site
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                return;
            }
            
            //Do Validation for fields
            //=========================
            if (!txtPassword.Text.Equals(txtPasswordConfirm.Text))
            {
                return;
            }


            //=========================


            IUserRepository userRepo = RepositoryFactory.Get<IUserRepository>();
            bool userExists = userRepo.Users.Any(u => u.email.Equals(txtEmailAddress.Text));

            if (userExists)
            {
                //return email already in use error message
                return;
            }

            User newUser = new User();
            newUser.email = txtEmailAddress.Text;
            newUser.password = txtPassword.Text;
            newUser.firstName = txtFirstName.Text;
            newUser.lastName = txtLastName.Text;
            newUser.homePhone = txtPhoneNumber.Text;
            newUser.b_address1 = txtBillAddressLine1.Text;
            newUser.b_city = txtBillCity.Text;
            newUser.b_state = txtBillState.Text;
            newUser.b_zip = txtBillZipCode.Text;

            userRepo.AddUser(newUser);

            Response.Redirect("/index.aspx");

        }
    }
}
