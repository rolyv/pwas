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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //turn off the error message, if it was on previously
            errorMessageLabel.Visible = false;

            //update the role table, so any changes are shown immediately
            updateRoleTable();
        }


        protected void addButton_Click(object sender, EventArgs e)
        {
            //turn on the add panel, turn off the edit and delete panels
            editPanel.Visible = false;
            deletePanel.Visible = false;
            addPanel.Visible = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //this is the edit button click (it's misnamed)
            //as long as the item in the list box is not null, then get the role and update it
            if (!string.IsNullOrEmpty(editLabel.Text))
            {
                if (String.IsNullOrEmpty(editRoleNameBox.Text.Trim()) || String.IsNullOrEmpty(editRoleDescBox.Text.Trim()))
                {
                    //either the desc or name are null - send a error message to the user and do not add the role
                    errorMessageLabel.Text = "Please enter a value for both Role Name and Role Description";
                    errorMessageLabel.Visible = true;
                }
                else
                {
                    try
                    {
                        IRoleRepository roleRepo = RepositoryFactory.Get<IRoleRepository>();

                        //get the role indicated by the listbox number
                        Role updateMe = roleRepo.GetById(int.Parse(editLabel.Text));

                        //update the role
                        updateMe.role_name = editRoleNameBox.Text;
                        updateMe.role_desc = editRoleDescBox.Text;

                        roleRepo.SubmitChanges();

                        errorMessageLabel.Text = "Role has been editted";
                        errorMessageLabel.Visible = true;
                    }
                    catch (Exception)
                    {
                        //respond with error message
                        errorMessageLabel.Text = "Database error when editting role";
                        errorMessageLabel.Visible = true;
                    }

                    //clear the text boxes
                    editRoleNameBox.Text = "";
                    editRoleDescBox.Text = "";

                    //hide the panel
                    editPanel.Visible = false;

                    //update the role table to reflect changes
                    updateRoleTable();
                }
            }
        }

        private void updateRoleTable()
        {
            //used to update the role table entries
            IRoleRepository roleRepo = RepositoryFactory.Get<IRoleRepository>();

            var query = from p in roleRepo.Roles
                        select p;

            //clear existing roles, get a new list (in case any are added / deleted / changed)
            this.roleDescriptionTable.Rows.Clear();

            this.roleDescriptionTable.Rows.Add(titleRow);

            //for every role that is in the database, add it as a row in the table
            foreach (var role in query)
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
                    edit.CommandArgument = role.roleID.ToString();
                    edit.Command += new CommandEventHandler(btnEditRole_Click);
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
                    delete.CommandArgument = role.roleID.ToString();
                    delete.Command += new CommandEventHandler(btnDeleteRole_Click);
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

                TableCell roleID = new TableCell();
                roleID.Text = role.roleID.ToString();

                TableCell roleName = new TableCell();
                roleName.Text = role.role_name.ToString();

                TableCell roleDesc = new TableCell();
                roleDesc.Text = role.role_desc;

                //add the row to the table
                row.Cells.Add(cellEdit);
                row.Cells.Add(cellDelete);
                row.Cells.Add(roleID);
                row.Cells.Add(roleName);
                row.Cells.Add(roleDesc);

                this.roleDescriptionTable.Rows.Add(row);
            }
        }

        protected void btnDeleteRole_Click(object sender, EventArgs e)
        {
            //get the permission ID as the command argument
            ImageButton btn = sender as ImageButton;
            int roleID = Int32.Parse(btn.CommandArgument);

            //update the text box when the delete panel becomes visible
            updateDeletePanel(roleID);

            //turn on the delete panel, turn off the edit and add panels
            editPanel.Visible = false;
            deletePanel.Visible = true;
            addPanel.Visible = false;

        }

        protected void btnEditRole_Click(object sender, EventArgs e)
        {
            //get the permission ID as the command argument
            ImageButton btn = sender as ImageButton;
            int roleID = Int32.Parse(btn.CommandArgument);

            //update the text box when the delete panel becomes visible
            updateEditPanel(roleID);

            //turn on the delete panel, turn off the edit and add panels
            editPanel.Visible = true;
            deletePanel.Visible = false;
            addPanel.Visible = false;

        }

        private void updateEditPanel(int roleID)
        {
            IRoleRepository roleRepo = RepositoryFactory.Get<IRoleRepository>();

            try
            {
                Role displayMe = new Role();
                displayMe = roleRepo.GetById(roleID);

                editLabel.Text = roleID.ToString();
                editRoleDescBox.Text = displayMe.role_desc;
                editRoleNameBox.Text = displayMe.role_name;

            }
            catch (Exception)
            {
                errorMessageLabel.Text = "Error retrieving role from the database";
                errorMessageLabel.Visible = true;
            }
        }

        private void updateDeletePanel(int roleID)
        {
            IRoleRepository roleRepo = RepositoryFactory.Get<IRoleRepository>();

            try
            {
                Role displayMe = new Role();
                displayMe = roleRepo.GetById(roleID);

                deleteLabel.Text = roleID.ToString();
                deleteRoleDescBox.Text = displayMe.role_desc;
                deleteRoleNameBox.Text = displayMe.role_name;

            }
            catch (Exception)
            {
                errorMessageLabel.Text = "Error retrieving role from the database";
                errorMessageLabel.Visible = true;
            }

        }

        protected void addSubmit_Click(object sender, EventArgs e)
        {
            //check to make sure the data is not null

            if (String.IsNullOrEmpty(addRoleDescBox.Text.Trim()) || String.IsNullOrEmpty(addRoleNameBox.Text.Trim()))
            {
                //either the desc or name are null - send a error message to the user and do not add the role
                errorMessageLabel.Text = "Please enter a value for both Role Name and Role Description";
                errorMessageLabel.Visible = true;
            }
            else
            {
                try
                {
                    //access the database and add the new role, submit
                    IRoleRepository roleRepo = RepositoryFactory.Get<IRoleRepository>();

                    Role newRole = new Role();

                    newRole.role_desc = addRoleDescBox.Text;
                    newRole.role_name = addRoleNameBox.Text;

                    roleRepo.AddRole(newRole);
                    roleRepo.SubmitChanges();

                    errorMessageLabel.Text = "Role has been added";
                    errorMessageLabel.Visible = true;
                }
                catch (Exception)
                {
                    //error message
                    errorMessageLabel.Text = "Database error when inserting new role";
                    errorMessageLabel.Visible = true;
                }

                //clear the text boxes
                addRoleNameBox.Text = "";
                addRoleDescBox.Text = "";

                //hide the panel
                addPanel.Visible = false;

                //update the role table to reflect changes
                updateRoleTable();
            }
        }

        protected void deleteSubmit_Click(object sender, EventArgs e)
        {
            //as long as the roleID in the label is not null, then get the role and delete it
            if (String.IsNullOrEmpty(deleteLabel.Text) == false)
            {
                try
                {
                    IRoleRepository roleRepo = RepositoryFactory.Get<IRoleRepository>();

                    //get the role indicated by the listbox number
                    Role deleteMe = roleRepo.GetById(int.Parse(deleteLabel.Text));

                    //delete the role
                    roleRepo.DeleteRole(deleteMe.roleID);

                    //try to submit
                    roleRepo.SubmitChanges();

                    errorMessageLabel.Text = "Role has been deleted";
                }
                catch (Exception)
                {
                    //delete failed - a user is assigned to this role
                    errorMessageLabel.Text = "Cannot delete this role - a user is assigned to it";
                    errorMessageLabel.Visible = true;

                }

                //clear the text boxes
                deleteRoleNameBox.Text = "";
                deleteRoleDescBox.Text = "";
                deleteLabel.Text = "";

                //hide the panel
                deletePanel.Visible = false;

                //redraw the role table to reflect the change
                updateRoleTable();

            }
        }
    }
}
