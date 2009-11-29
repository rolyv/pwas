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
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IRolePermissionRepository rolePermissionsRepo = RepositoryFactory.Get<IRolePermissionRepository>();
            IRoleRepository rolesRepo = RepositoryFactory.Get<IRoleRepository>();
            IUserRepository userRepo = RepositoryFactory.Get<IUserRepository>();
                        
            RolePermission firstPermission = rolePermissionsRepo.GetById(1);
            Role firstRole = rolesRepo.GetById(firstPermission.roleID);

            string msg = "<p>The first Role is: '" + firstRole.role_name + "'<br />";
            msg += "The first RolePermission is for '" + firstRole.role_name + "' on objects of type '"
                    + firstPermission.@object + "'<br /></p>";

            this.Label1.Text = msg;

            //bool auth = Security.IsAuthorized(2, PwasObject.Order, PwasAction.Create, PwasScope.All);

            //this.Label1.Text += "<p>" + auth.ToString() + "</p>";

            //this.Label1.Text += "<p>" + Security.Authenticate("hi@goodbye.com", "hello") + "</p>";


            //User newUser = new User();
            //newUser.email = "hello@goodbye.com";
            //newUser.password = "12345";
            //newUser.firstName = "Roly";
            //newUser.lastName = "Vicaria";
            //newUser.homePhone = "3055532414";
            //newUser.b_address1 = "1313 Mockingbird Lane";
            //newUser.b_city = "Miami";
            //newUser.b_state = "FL";
            //newUser.b_zip = "33175";

            //userRepo.AddUser(newUser);
            //userRepo.SubmitChanges();
            int roleId = 1;// (int)Session[Constants.PWAS_SESSION_ID];
            Security.SetControlVisibility(roleId, this.Controls);
        }
    }
}
