﻿using System;
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
            tableErrorMessage.Visible = false;
            lblErrorMessage.Visible = false;
            lblErrorMessage.Style.Add(HtmlTextWriterStyle.Color, "red");

            userId = Int32.Parse(Session["PWAS_ID"].ToString());

            IUserRepository userRepo = RepositoryFactory.Get<IUserRepository>();
            user = userRepo.GetById(userId);

            if (!IsPostBack)
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
            //Email address is used as username and cannot be empty
            if (String.IsNullOrEmpty(txtEmailAddress.Text.Trim()))
            {
                lblErrorMessage.Text = "Please enter required (*) information";
                lblErrorMessage.Visible = true;
                tableErrorMessage.Visible = true;
                return;
            }
            //Passwords must match
            if (!txtNewPassword.Text.Equals(txtNewPasswordConfirm.Text))
            {
                lblErrorMessage.Text = "Password fields do not match";
                lblErrorMessage.Visible = true;
                tableErrorMessage.Visible = true;
                return;
            }
            //This information is already in the db and does not need to be saved again
            if (txtEmailAddress.Text.Equals(user.email) && String.IsNullOrEmpty(txtNewPassword.Text))
                return;

            IUserRepository userRepo = RepositoryFactory.Get<IUserRepository>();
            User newUser = userRepo.GetById(Int32.Parse(Session["PWAS_ID"].ToString()));

            //If username is changed
            if (!user.email.Equals(txtEmailAddress.Text))
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
                
                newUser.email = txtEmailAddress.Text;
            }

            //if password is changed, add it to the db
            if (!String.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {
                //Should verify if correct formatting in this step
                newUser.password = Security.MD5Encode(txtNewPassword.Text.Trim());
            }

            //userRepo.UpdateUserInfo(newUser);
            userRepo.SubmitChanges();

            lblErrorMessage.Text = "Request Completed";
            lblErrorMessage.Style.Add(HtmlTextWriterStyle.Color, "green");
            lblErrorMessage.Visible = true;
            tableErrorMessage.Visible = true;
        }

        protected void btnEditOtherInfo_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtFirstName.Text.Trim()) ||
                String.IsNullOrEmpty(txtLastName.Text.Trim()) ||
                String.IsNullOrEmpty(txtPhoneNumber.Text.Trim()) ||
                String.IsNullOrEmpty(txtBillAddressLine1.Text.Trim()) ||
                String.IsNullOrEmpty(txtBillCity.Text.Trim()) ||
                String.IsNullOrEmpty(txtBillState.Text.Trim()) ||
                String.IsNullOrEmpty(txtBillZipCode.Text.Trim()))
            {
                lblErrorMessage.Text = "Please enter required (*) information";
                lblErrorMessage.Visible = true;
                tableErrorMessage.Visible = true;
                return;
            }

            IUserRepository userRepo = RepositoryFactory.Get<IUserRepository>();
            User newUser = userRepo.GetById(Int32.Parse(Session["PWAS_ID"].ToString()));

            newUser.firstName = txtFirstName.Text;
            newUser.lastName = txtLastName.Text;
            newUser.company = txtCompanyName.Text;
            newUser.homePhone = txtPhoneNumber.Text;

            newUser.cc_num = txtCreditCardNumber.Text;
            newUser.cc_type = ddCardType.SelectedValue;
            newUser.exp_date = txtExpDate.Text;
            newUser.cc_scode = txtSecurityCode.Text;
            newUser.cc_nameOnCard = txtNameOnCard.Text;

            newUser.b_address1 = txtBillAddressLine1.Text;
            newUser.b_address2 = txtBillAddressLine2.Text;
            newUser.b_city = txtBillCity.Text;
            newUser.b_state = txtBillState.Text;
            newUser.b_zip = txtBillZipCode.Text;

            newUser.s_address1 = txtShipAddressLine1.Text;
            newUser.s_address2 = txtShipAddressLine2.Text;
            newUser.s_city = txtShipCity.Text;
            newUser.s_state = txtShipState.Text;
            newUser.s_zip = txtShipZipCode.Text;

            lblErrorMessage.Text = "Request Completed";
            lblErrorMessage.Style.Add(HtmlTextWriterStyle.Color, "green");
            lblErrorMessage.Visible = true;
            tableErrorMessage.Visible = true;
        }
    }
}
