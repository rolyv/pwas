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
    public partial class admin_ManageRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //turn off the error message, if it was on previously
            errorMessageLabel.Visible = false;

            //update the role table, so any changes are shown immediately
            updateRoleTable();
        }

        protected void editButton_Click(object sender, EventArgs e)
        {
            //update the listbox and text box when the edit panel becomes visible
            updateEditListBox();
            updateEditTextBoxes();

            //turn on the edit panel, turn off the delete and add panels
            editPanel.Visible = true;
            deletePanel.Visible = false;
            addPanel.Visible = false;

        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            //turn on the add panel, turn off the edit and delete panels
            editPanel.Visible = false;
            deletePanel.Visible = false;
            addPanel.Visible = true;
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            //update the listbox and text box when the delete panel becomes visible
            updateDeleteListBox();
            updateDeleteTextBoxes();

            //turn on the delete panel, turn off the edit and add panels
            editPanel.Visible = false;
            deletePanel.Visible = true;
            addPanel.Visible = false;
        }

        protected void editDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //update the text boxes when the user selects a diff item
            updateEditTextBoxes();
        }

        protected void deleteDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //update the text boxes when the user selects a diff item
            updateDeleteTextBoxes();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //this is the edit button click (it's misnamed)
            //as long as the item in the list box is not null, then get the role and update it
            if (editDropDownList.SelectedItem != null)
            {
                if (String.IsNullOrEmpty(editRoleNameBox.Text.Trim()) || String.IsNullOrEmpty(editRoleDescBox.Text.Trim()))
                {
                    //either the desc or name are null - send a error message to the user and do not add the role
                    errorMessageLabel.Text = "Please enter a value for both Role Name and Role Description";
                    errorMessageLabel.Visible = true;
                }
                else
                {

                    IRoleRepository roleRepo = RepositoryFactory.Get<IRoleRepository>();

                    //get the role indicated by the listbox number
                    Role updateMe = roleRepo.GetById(int.Parse(editDropDownList.SelectedItem.Value));

                    //update the role
                    updateMe.role_name = editRoleNameBox.Text;
                    updateMe.role_desc = editRoleDescBox.Text;

                    roleRepo.SubmitChanges();

                    //redraw the role table and text boxes to reflect the change
                    updateRoleTable();
                    updateEditTextBoxes();
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
            
            //for every role that is in the database, add it as a row in the table
            foreach (var role in query)
            {
                //instantiate a new row
                TableRow row = new TableRow();

                TableCell roleID = new TableCell();
                TableCell roleName = new TableCell();
                TableCell roleDesc = new TableCell();

                //enter the role information into the row
                roleID.Text = role.roleID.ToString();
                roleName.Text = role.role_name.ToString();
                roleDesc.Text = role.role_desc;

                //add the row to the table
                row.Cells.Add(roleID);
                row.Cells.Add(roleName);
                row.Cells.Add(roleDesc);

                row.CssClass = "roleRow";
                this.roleDescriptionTable.Rows.Add(row);
            }
        }

        private void updateEditListBox()
        {
            //will refresh the items in the list box - useful for when items are added and deleted
            IRoleRepository roleRepo = RepositoryFactory.Get<IRoleRepository>();
            var query = from p in roleRepo.Roles
                        select p;

            //get all roles, add their ID items to the listbox
            this.editDropDownList.Items.Clear();
            
            foreach(var role in query)
            {
                this.editDropDownList.Items.Add(new ListItem(role.roleID.ToString(), role.roleID.ToString()));
            }

        }

        private void updateDeleteListBox()
        {
            //will refresh the items in the delete list box - useful for when items are added and deleted
            IRoleRepository roleRepo = RepositoryFactory.Get<IRoleRepository>();
            var query = from p in roleRepo.Roles
                        select p;

            //get all roles, add their ID items to the listbox
            this.deleteDropDownList.Items.Clear();

            foreach (var role in query)
            {
                this.deleteDropDownList.Items.Add(new ListItem(role.roleID.ToString(), role.roleID.ToString()));
            }

        }

        private void updateEditTextBoxes()
        {
            IRoleRepository roleRepo = RepositoryFactory.Get<IRoleRepository>();

            //as long as the listbox is not null, get the selected role and fill the text box with the data
            if (editDropDownList.SelectedItem != null)
            {
                Role displayMe = new Role();
                displayMe = roleRepo.GetById(int.Parse(editDropDownList.SelectedItem.Value));

                editRoleDescBox.Text = displayMe.role_desc;
                editRoleNameBox.Text = displayMe.role_name;
            }
        }

        private void updateDeleteTextBoxes()
        {
            IRoleRepository roleRepo = RepositoryFactory.Get<IRoleRepository>();

            //as long as the listbox is not null, get the selected role and fill the text box with the data
            if (deleteDropDownList.SelectedItem != null)
            {
                Role displayMe = new Role();
                displayMe = roleRepo.GetById(int.Parse(deleteDropDownList.SelectedItem.Value));

                deleteRoleDescBox.Text = displayMe.role_desc;
                deleteRoleNameBox.Text = displayMe.role_name;
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
                //access the database and add the new role, submit
                IRoleRepository roleRepo = RepositoryFactory.Get<IRoleRepository>();

                Role newRole = new Role();

                newRole.role_desc = addRoleDescBox.Text;
                newRole.role_name = addRoleNameBox.Text;

                roleRepo.AddRole(newRole);
                roleRepo.SubmitChanges();

                //clear the text boxes
                addRoleNameBox.Text = "";
                addRoleDescBox.Text = "";

                //update the role table to reflect changes
                updateRoleTable();
            }
        }

        protected void deleteSubmit_Click(object sender, EventArgs e)
        {
            //as long as the item in the list box is not null, then get the role and delete it
            if (editDropDownList.SelectedItem != null)
            {

                IRoleRepository roleRepo = RepositoryFactory.Get<IRoleRepository>();

                //get the role indicated by the listbox number
                Role deleteMe = roleRepo.GetById(int.Parse(deleteDropDownList.SelectedItem.Value));

                //delete the role
                roleRepo.DeleteRole(deleteMe.roleID);

                try
                {
                    //try to submit
                    roleRepo.SubmitChanges();
                }
                catch (Exception theException)
                {
                    //delete failed - a user is assigned to this role
                    errorMessageLabel.Text = "Cannot delete this role - a user is assigned to it";
                    errorMessageLabel.Visible = true;
                    
                }
                

                //redraw the role table to reflect the change
                updateRoleTable();
                updateDeleteListBox();
            }
        }
        
    }
}
