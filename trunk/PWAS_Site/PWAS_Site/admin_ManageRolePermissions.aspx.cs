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

        private int permID;

        protected void Page_Load(object sender, EventArgs e)
        {
            editPanel.Visible = false;
            errorLabel.Visible = false;
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
                row.CssClass = "orderRow";

                bool canEdit = true;
                bool canDelete = true;


                TableCell cellEdit = new TableCell();
                if (canEdit)
                {
                    ImageButton edit = new ImageButton();
                    edit.ImageUrl = "/images/edit.gif";
                    edit.ToolTip = "Edit";
                    edit.CommandArgument = rolePerm.permissionID.ToString(); //user.userID.ToString();
                    edit.Command += new CommandEventHandler(btnEditRolePerm_Click);
                    cellEdit.Controls.Add(edit);
                }
                else
                {
                    Image edit = new Image();
                    edit.ImageUrl = "/images/edit_gray.gif";
                    edit.ToolTip = "Edit";
                    cellEdit.Controls.Add(edit);
                }


                TableCell cellDelete = new TableCell();
                if (canDelete)
                {
                    ImageButton delete = new ImageButton();
                    delete.ImageUrl = "/images/delete.gif";
                    delete.ToolTip = "Delete";
                    delete.CommandArgument = rolePerm.permissionID.ToString(); //user.userID.ToString();
                    delete.Command += new CommandEventHandler(btnDeleteRolePerm_Click);
                    cellDelete.Controls.Add(delete);
                }
                else
                {
                    Image delete = new Image();
                    delete.ImageUrl = "/images/delete_gray.gif";
                    delete.ToolTip = "Delete";
                    cellDelete.Controls.Add(delete);
                    cellDelete.Enabled = false;
                }

                TableCell permID = new TableCell();
                permID.Text = rolePerm.permissionID.ToString();

                TableCell roleID = new TableCell();
                roleID.Text = rolePerm.roleID.ToString();

                TableCell objectDesc = new TableCell();
                objectDesc.Text = rolePerm.@object.ToString();

                TableCell objectUpdate = new TableCell();
                objectUpdate.Text = rolePerm.obj_update.ToString();

                TableCell objectView = new TableCell();
                objectView.Text = rolePerm.obj_view.ToString();

                TableCell objectCreate = new TableCell();
                objectCreate.Text = rolePerm.obj_create.ToString();

                TableCell objectDelete = new TableCell();
                objectDelete.Text = rolePerm.obj_delete.ToString();

                //add the row to the table
                row.Cells.Add(cellEdit);
                row.Cells.Add(cellDelete);
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

        protected void btnEditRolePerm_Click(object sender, EventArgs e)
        {
            //get the permission ID as the command argument
            ImageButton btn = sender as ImageButton;
            int permissionID = Int32.Parse(btn.CommandArgument);

            //set the hidden permission ID variable
            permID = permissionID;

            //get the row to to show in the panel
            IRolePermissionRepository rolePermRepo = RepositoryFactory.Get<IRolePermissionRepository>();
            var rolePermission = (from p in rolePermRepo.RolePermissions
                                  where p.permissionID == permissionID
                                  select p).Single();

            //populate the panel text box
            roleIDTextBox.Text = rolePermission.roleID.ToString();
            objectTextBox.Text = rolePermission.@object.ToString();
            updateTextBox.Text = rolePermission.obj_update.ToString();
            viewTextBox.Text = rolePermission.obj_view.ToString();
            createTextBox.Text = rolePermission.obj_create.ToString();
            deleteTextBox.Text = rolePermission.obj_delete.ToString();

            //turn off the add panel and show the edit panel
            addPanel.Visible = false;
            editPanel.Visible = true;
        }

        protected void btnDeleteRolePerm_Click(object sender, EventArgs e)
        {

            //get the permission ID as the command argument
            ImageButton btn = sender as ImageButton;
            int permissionID = Int32.Parse(btn.CommandArgument);

            //set the hidden permission ID variable 
            permID = permissionID;

            //get the row to delete
            IRolePermissionRepository rolePermRepo = RepositoryFactory.Get<IRolePermissionRepository>();
            RolePermission deleteMe = rolePermRepo.GetById(permID);

            //delete the row
            rolePermRepo.DeleteRolePermission(deleteMe.permissionID);

            //attempt to submit the changes
            try
            {
                rolePermRepo.SubmitChanges();
            }
            catch (Exception theException)
            {
                //return a error message
                errorLabel.Text = "Database error when updating role permission";
                errorLabel.Visible = true;
            }
        }

        protected void addSubmit_Click(object sender, EventArgs e)
        {
            //check for nulls
            if ((String.IsNullOrEmpty(addRoleIDTextBox.Text)) ||
                (String.IsNullOrEmpty(addObjectTextBox.Text)) ||
                (String.IsNullOrEmpty(addUpdateTextBox.Text)) ||
                (String.IsNullOrEmpty(addViewTextBox.Text)) ||
                (String.IsNullOrEmpty(addCreateTextBox.Text)) ||
                (String.IsNullOrEmpty(addDeleteTextBox.Text)))
            {
                //return a error message
                addErrorLabel.Text = "Please enter a valid value for all fields";
                addErrorLabel.Visible = true;
            }
            else
            {
                IRolePermissionRepository rolePermRepo = RepositoryFactory.Get<IRolePermissionRepository>();
                RolePermission addMe = new RolePermission();

                addMe.obj_create = int.Parse(addCreateTextBox.Text);
                addMe.obj_delete = int.Parse(addDeleteTextBox.Text);
                addMe.obj_update = int.Parse(addUpdateTextBox.Text);
                addMe.obj_view = int.Parse(addViewTextBox.Text);
                addMe.@object = addObjectTextBox.Text;
                addMe.roleID = int.Parse(addRoleIDTextBox.Text);

                rolePermRepo.AddRolePermission(addMe);

                try
                {
                    rolePermRepo.SubmitChanges();
                }
                catch (Exception theException)
                {
                    //error message
                    addErrorLabel.Text = "Database error when adding role permission";
                    addErrorLabel.Visible = true;
                }

            }
        }

        protected void editSubmit_Click(object sender, EventArgs e)
        {
            //check for nulls
            if ((String.IsNullOrEmpty(roleIDTextBox.Text)) ||
                (String.IsNullOrEmpty(objectTextBox.Text)) ||
                (String.IsNullOrEmpty(updateTextBox.Text)) ||
                (String.IsNullOrEmpty(viewTextBox.Text)) ||
                (String.IsNullOrEmpty(createTextBox.Text)) ||
                (String.IsNullOrEmpty(deleteTextBox.Text)))
            {
                //return a error message
                errorLabel.Text = "Please enter a valid value for all fields";
                errorLabel.Visible = true;
            }
            else
            {
                IRolePermissionRepository rolePermRepo = RepositoryFactory.Get<IRolePermissionRepository>();
                RolePermission updateMe = rolePermRepo.GetById(permID);

                updateMe.obj_create = int.Parse(createTextBox.Text);
                updateMe.obj_delete = int.Parse(deleteTextBox.Text);
                updateMe.obj_update = int.Parse(updateTextBox.Text);
                updateMe.obj_view = int.Parse(viewTextBox.Text);
                updateMe.@object = objectTextBox.Text;
                updateMe.roleID = int.Parse(roleIDTextBox.Text);

                try
                {
                    rolePermRepo.SubmitChanges();
                }
                catch (Exception theException)
                {
                    //error message
                    errorLabel.Text = "Database error when updating role permission";
                    errorLabel.Visible = true;
                }
            }
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            editPanel.Visible = false;
            addPanel.Visible = true;
        }
    }
}
