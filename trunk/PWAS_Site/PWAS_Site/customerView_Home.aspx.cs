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

namespace PWAS_Site
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        int userId = -1;
        User user = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Constants.PWAS_SESSION_ID] == null)
                Response.Redirect("index.aspx");

            welcomeName.Text = (string)Session[Constants.PWAS_SESSION_NAME];

            tableErrorMessage.Visible = false;
            lblErrorMessage.Visible = false;
            lblErrorMessage.Style.Add(HtmlTextWriterStyle.Color, "red");

            userId = Convert.ToInt32(Session[Constants.PWAS_SESSION_ID]);

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

        protected void btnEditUserInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("customerView_EditProfile.aspx");
        }
    }
}
