using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using PWAS.Model;
using PWAS.DataAccess.Interfaces;

namespace PWAS_Site
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            messageLabel.Visible = false;
        }

        protected void doLogin(object sender, EventArgs e)
        {
            
            string password = pwd.Text.Trim();
            string email = loginEmail.Text.Trim();

            int userID = Security.Authenticate(email, password);

            if (userID > 0)
            {
                Session[Security.PWAS_SESSION_ID] = userID;

                IUserRepository userRepo = RepositoryFactory.Get<IUserRepository>();
                User userObj = userRepo.GetById(userID);

                Session[Security.PWAS_SESSION_NAME] = userObj.firstName;

                Response.Redirect("customerView_Home.aspx");
            }
            else
            {
                messageLabel.Text = "Login information is not valid.";
                messageLabel.Visible = true;
            }

        }

    }
}
