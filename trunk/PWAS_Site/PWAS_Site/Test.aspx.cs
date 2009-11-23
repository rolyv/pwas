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
using PWAS.DataAccess.SQLRepositories;

namespace PWAS_Site
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Configuration.Configuration rootWebConfig =
                System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/PWAS_Site");
            System.Configuration.ConnectionStringSettings connString;
            connString =
                    rootWebConfig.ConnectionStrings.ConnectionStrings["PwasConnectionString"];
            IRolePermissionRepository rp = new RolePermissionRepository(connString.ConnectionString);

            this.Label1.Text = rp.GetById(2).@object + "\tHello";
        }
    }
}
