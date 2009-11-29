using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PWAS.DataAccess.Interfaces;
using PWAS.Model;
using System.Security.Cryptography;
using System.Text;

namespace PWAS_Site
{
    public partial class customerView_EditProfile : System.Web.UI.Page
    {
        int userId = -1;
        User user = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            userId = Int32.Parse(Session["PWAS_ID"].ToString());

            IUserRepository userRepo = RepositoryFactory.Get<IUserRepository>();
            user = userRepo.GetById(userId);

            populateInformation();
        }

        private void populateInformation()
        {
            txtEmailAddress.Text = user.email;
            
            txtFirstName.Text = user.firstName;
            txtLastName.Text = user.lastName;
            txtCompanyName.Text = user.company;
            txtPhoneNumber.Text = user.homePhone;
            
            txtCreditCardNumber.Text = user.cc_num;
            ddCardType.SelectedValue = user.cc_type;
            txtExpDate.Text = user.exp_date;
            txtSecurityCode.Text = user.cc_scode;
            txtNameOnCard.Text = user.cc_nameOnCard;

            txtBillAddressLine1.Text = user.b_address1;
            txtBillAddressLine2.Text = user.b_address2;
            txtBillCity.Text = user.b_city;
            txtBillState.Text = user.b_state;
            txtBillZipCode.Text = user.b_zip;

            txtShipAddressLine1.Text = user.s_address1;
            txtShipAddressLine2.Text = user.s_address2;
            txtShipCity.Text = user.s_city;
            txtShipState.Text = user.s_state;
            txtShipZipCode.Text = user.s_zip;
        }

        protected void btnEditLoginInfo_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtEmailAddress.Text) || !txtNewPassword.Text.Equals(txtNewPasswordConfirm.Text))
            {
                lblErrorMessage.Text = "Please enter required (*) information";
                lblErrorMessage.Visible = true;
                tableErrorMessage.Visible = true;
                return;
            }

            IUserRepository userRepo = RepositoryFactory.Get<IUserRepository>();

            if (! user.email.Equals(txtEmailAddress.Text))
            {
                bool userExists = userRepo.Users.Any(u => u.email.Equals(txtEmailAddress.Text));

                //check to see if email already exists
                if (userExists)
                {
                    lblErrorMessage.Text = "Username (email) already in use";
                    lblErrorMessage.Visible = true;
                    tableErrorMessage.Visible = true;
                    //return email already in use error message
                    return;
                }

                //if it doesn't, Go ahead!

                //need to update user row in db
            
                User newUser = userRepo.GetById(Int32.Parse(Session["PWAS_ID"].ToString()));
                newUser.email = txtEmailAddress.Text;

                //if password is also changed, also add it to the db
                if (!String.IsNullOrEmpty(txtNewPassword.Text.Trim()))
                {
                    newUser.password = txtNewPassword.Text.Trim();
                    //Add in MD5Encode
                }

                //userRepo.UpdateUserInfo(newUser);
                userRepo.SubmitChanges();
            }
        }
    }
}
