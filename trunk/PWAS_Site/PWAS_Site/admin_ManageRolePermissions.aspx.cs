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
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            updateRolePermissionTable();
        }

        private void updateRolePermissionTable ()
        {
            //used to update the role table entries
            //IRoleRepository roleRepo = RepositoryFactory.Get<IRoleRepository>();
            IRolePermissionRepository rolePermRepo = RepositoryFactory.Get<IRolePermissionRepository>();

            var query = from p in rolePermRepo.RolePermissions
                        select p;

            //clear existing roles, get a new list (in case any are added / deleted / changed)
            //this.rolePermissionTable.Rows.Clear();
            
            //for every role that is in the database, add it as a row in the table
            foreach (var rolePerm in query)
            {
                //instantiate a new row
                TableRow row = new TableRow();

                TableCell permID = new TableCell();
                TableCell roleID = new TableCell();
                TableCell objectDesc = new TableCell();
                TableCell objectUpdate = new TableCell();
                TableCell objectView = new TableCell();
                TableCell objectCreate = new TableCell();
                TableCell objectDelete = new TableCell();

                //enter the role information into the row
                permID.Text = rolePerm.permissionID.ToString();
                roleID.Text = rolePerm.roleID.ToString();
                objectDesc.Text = rolePerm.@object.ToString();
                objectUpdate.Text = rolePerm.obj_update.ToString();
                objectView.Text = rolePerm.obj_view.ToString();
                objectCreate.Text = rolePerm.obj_create.ToString();
                objectDelete.Text = rolePerm.obj_delete.ToString();

                //add the row to the table
                row.Cells.Add(permID);
                row.Cells.Add(roleID);
                row.Cells.Add(objectDesc);
                row.Cells.Add(objectUpdate);
                row.Cells.Add(objectView);
                row.Cells.Add(objectCreate);
                row.Cells.Add(objectDelete);

                row.CssClass = "rolePermRow";
                this.rolePermissionTable.Rows.Add(row);
            }
        }
    }
}
