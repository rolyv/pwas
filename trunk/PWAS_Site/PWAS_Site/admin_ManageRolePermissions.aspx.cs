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
            errorLabel.Visible = false;
            updateRolePermissionTable();
        }

        private void updateRolePermissionTable()
        {
            //used to update the role table entries
            //IRoleRepository roleRepo = RepositoryFactory.Get<IRoleRepository>();
            IRolePermissionRepository rolePermRepo = RepositoryFactory.Get<IRolePermissionRepository>();

            var query = from p in rolePermRepo.RolePermissions
                        select p;

            //clear existing roles, get a new list (in case any are added / deleted / changed)
            this.rolePermissionTable.Rows.Clear();

            this.rolePermissionTable.Rows.Add(titleRow);

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

                TableCell roleName = new TableCell();
                roleName.Text = rolePerm.Role.role_name.Trim();

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
                row.Cells.Add(roleName);
                row.Cells.Add(objectDesc);
                row.Cells.Add(objectUpdate);
                row.Cells.Add(objectView);
                row.Cells.Add(objectCreate);
                row.Cells.Add(objectDelete);

                this.rolePermissionTable.Rows.Add(row);
            }
        }

        protected void btnEditRolePerm_Click(object sender, EventArgs e)
        {
            //get the permission ID as the command argument
            ImageButton btn = sender as ImageButton;
            int permissionID = Int32.Parse(btn.CommandArgument);

            //get the row to to show in the panel
            IRolePermissionRepository rolePermRepo = RepositoryFactory.Get<IRolePermissionRepository>();
            var theQuery = from p in rolePermRepo.RolePermissions
                           where p.permissionID == permissionID
                           select p;

            //populate the panel text box
            foreach (var thePermission in theQuery)
            {
                this.editRoleIDTextBox.Text = thePermission.roleID.ToString();
                this.editObjectTextBox.Text = thePermission.@object.ToString();
                this.editUpdateTextBox.Text = thePermission.obj_update.ToString();
                this.editViewTextBox.Text = thePermission.obj_view.ToString();
                this.editCreateTextBox.Text = thePermission.obj_create.ToString();
                this.editDeleteTextBox.Text = thePermission.obj_delete.ToString();

                this.editPermLabel.Text = permissionID.ToString();
            }

            //turn off the other panels and show the edit panel
            addPanel.Visible = false;
            editPanel.Visible = true;
            deletePanel.Visible = false;
        }

        protected void btnDeleteRolePerm_Click(object sender, EventArgs e)
        {
            //get the permission ID as the command argument
            ImageButton btn = sender as ImageButton;
            int permissionID = Int32.Parse(btn.CommandArgument);

            //update the delete panel
            IRolePermissionRepository rolePermRepo = RepositoryFactory.Get<IRolePermissionRepository>();
            var theQuery = from p in rolePermRepo.RolePermissions
                           where p.permissionID == permissionID
                           select p;

            foreach (var thePermission in theQuery)
            {
                this.deleteRoleIDTextBox.Text = thePermission.roleID.ToString();
                this.deleteObjectTextBox.Text = thePermission.@object.ToString();
                this.deleteUpdateTextBox.Text = thePermission.obj_update.ToString();
                this.deleteViewTextBox.Text = thePermission.obj_view.ToString();
                this.deleteCreateTextBox.Text = thePermission.obj_create.ToString();
                this.deleteDeleteTextBox.Text = thePermission.obj_delete.ToString();

                this.deletePermLabel.Text = permissionID.ToString();
            }

            //turn off the other panels and show the delete panel
            this.editPanel.Visible = false;
            this.addPanel.Visible = false;
            this.deletePanel.Visible = true;

        }

        protected void deleteSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                IRolePermissionRepository rolePermRepo = RepositoryFactory.Get<IRolePermissionRepository>();
                RolePermission deleteMe = rolePermRepo.GetById(int.Parse(deletePermLabel.Text));

                rolePermRepo.DeleteRolePermission(deleteMe.permissionID);

                rolePermRepo.SubmitChanges();

                //return a validation message
                errorLabel.Text = "Permission has been deleted";
                errorLabel.Visible = true;

                //hide the panel
                deletePanel.Visible = false;
            }
            catch (Exception)
            {
                //error message
                errorLabel.Text = "Database error when deleting role permission";
                errorLabel.Visible = true;
            }

            updateRolePermissionTable();

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
                errorLabel.Text = "Please enter a valid value for all fields";
                errorLabel.Visible = true;
            }
            else
            {
                try
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

                    rolePermRepo.SubmitChanges();

                    //return a validation message
                    errorLabel.Text = "New Permission has been added";
                    errorLabel.Visible = true;

                    //hide the panel
                    addPanel.Visible = false;
                }
                catch (Exception)
                {
                    //error message
                    errorLabel.Text = "Database error when adding role permission";
                    errorLabel.Visible = true;
                }

                updateRolePermissionTable();

            }
        }

        protected void editSubmit_Click(object sender, EventArgs e)
        {
            //check for nulls
            if ((String.IsNullOrEmpty(editRoleIDTextBox.Text)) ||
                (String.IsNullOrEmpty(editObjectTextBox.Text)) ||
                (String.IsNullOrEmpty(editUpdateTextBox.Text)) ||
                (String.IsNullOrEmpty(editViewTextBox.Text)) ||
                (String.IsNullOrEmpty(editCreateTextBox.Text)) ||
                (String.IsNullOrEmpty(editDeleteTextBox.Text)))
            {
                //return a error message
                errorLabel.Text = "Please enter a valid value for all fields";
                errorLabel.Visible = true;
            }
            else
            {
                try
                {
                    IRolePermissionRepository rolePermRepo = RepositoryFactory.Get<IRolePermissionRepository>();
                    RolePermission editMe = rolePermRepo.GetById(int.Parse(editPermLabel.Text));

                    editMe.obj_create = int.Parse(editCreateTextBox.Text);
                    editMe.obj_delete = int.Parse(editDeleteTextBox.Text);
                    editMe.obj_update = int.Parse(editUpdateTextBox.Text);
                    editMe.obj_view = int.Parse(editViewTextBox.Text);
                    editMe.@object = editObjectTextBox.Text;
                    editMe.roleID = int.Parse(editRoleIDTextBox.Text);

                    //rolePermRepo.editRolePermission(editMe);

                    rolePermRepo.SubmitChanges();

                    //return a validation message
                    errorLabel.Text = "Permission has been editted";
                    errorLabel.Visible = true;

                    //hide the panel
                    editPanel.Visible = false;
                }
                catch (Exception)
                {
                    //error message
                    errorLabel.Text = "Database error when editing role permission";
                    errorLabel.Visible = true;
                }

                updateRolePermissionTable();
            }
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            //turn off the other panels and show the add panel
            this.editPanel.Visible = false;
            this.addPanel.Visible = true;
            this.deletePanel.Visible = false;
        }
    }
}
