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
                        
            RolePermission firstPermission = rolePermissionsRepo.GetById(1);
            Role firstRole = rolesRepo.GetById(firstPermission.roleID);

            string msg = "<p>The first Role is: '" + firstRole.role_name + "'<br />";
            msg += "The first RolePermission is for '" + firstRole.role_name + "' on objects of type '"
                    + firstPermission.@object + "'<br /></p>";

            this.Label1.Text = msg;

            rolesRepo.Roles.All(x => x.role_name.EndsWith("w"));
        }
    }
}
