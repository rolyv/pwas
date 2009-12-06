﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PWAS.DataAccess.Interfaces;
using PWAS.Model;

namespace PWAS_Site
{

    public partial class adminView_ManageAccounts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //check that user has access
                //if not -> redirect to home page
            if (Session[Constants.PWAS_SESSION_ID] == null || !Security.IsAuthorized((int)Session[Constants.PWAS_SESSION_ID], PwasObject.User, PwasAction.View, PwasScope.All))
            {
                Response.Redirect("customerView_Home.aspx");
            }

            //load active users and populate tableManageUsers
            IUserRepository userRepo = RepositoryFactory.Get<IUserRepository>();
            List<User> users = userRepo.Users.Where(u => u.active == true).ToList();
            bool canEdit = Security.IsAuthorized((int)Session[Constants.PWAS_SESSION_ID], PwasObject.User, PwasAction.Update, PwasScope.All);
            bool canDelete = Security.IsAuthorized((int)Session[Constants.PWAS_SESSION_ID], PwasObject.User, PwasAction.Delete, PwasScope.All);

            //load all Roles
            IRoleRepository roleRepo = RepositoryFactory.Get<IRoleRepository>();
            List<Role> roles = roleRepo.Roles.ToList<Role>();

            foreach (User user in users)
            {
                TableRow tableRow = new TableRow();
                tableRow.CssClass = "orderRow";
                
                TableCell cellEdit = new TableCell();
                if (canEdit)
                {
                    ImageButton edit = new ImageButton();
                    edit.ImageUrl = "/images/edit.gif";
                    edit.ToolTip = "Edit";
                    edit.CommandArgument = user.userID.ToString();
                    edit.Command += new CommandEventHandler(btnEditUser_Click);
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
                    delete.CommandArgument = user.userID.ToString();
                    delete.Command += new CommandEventHandler(btnDeleteUser_Click);
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
                

                TableCell cellUsername = new TableCell();
                string username = user.email.Trim();
                username = username.Substring(0, username.IndexOf('@'));
                cellUsername.Text = username;
                cellUsername.Width = Unit.Pixel(150);

                TableCell cellFullName = new TableCell();
                cellFullName.Text = user.firstName.Trim() + " " + user.lastName.Trim();
                cellFullName.Width = Unit.Pixel(150);

                TableCell cellTelephone = new TableCell();
                cellTelephone.Text = user.homePhone.Trim();
                cellTelephone.Width = Unit.Pixel(100);

                TableCell cellEmail = new TableCell();
                cellEmail.Text = user.email.Trim();
                cellEmail.Width = Unit.Pixel(200);

                TableCell cellRole = new TableCell();
                DropDownList ddRoles = new DropDownList();
                ddRoles.ID = "ddRoles";
                foreach (Role r in roles)
                {
                    ListItem item = new ListItem();
                    item.Value = r.roleID.ToString();
                    item.Text = r.role_name;
                    ddRoles.Items.Add(item);
                }
                ddRoles.Items.FindByValue(user.roleID.ToString()).Selected = true;
                cellRole.Controls.Add(ddRoles);

                TableCell cellUpdateRole = new TableCell();
                Button btnUpdateRole = new Button();
                btnUpdateRole.ToolTip = "Update Role";
                btnUpdateRole.CommandArgument = user.userID.ToString();
                btnUpdateRole.Command += new CommandEventHandler(btnUpdateRole_Click);
                cellUpdateRole.Controls.Add(btnUpdateRole);

                tableRow.Cells.Add(cellEdit);
                tableRow.Cells.Add(cellDelete);
                tableRow.Cells.Add(cellUsername);
                tableRow.Cells.Add(cellFullName);
                tableRow.Cells.Add(cellTelephone);
                tableRow.Cells.Add(cellEmail);
                tableRow.Cells.Add(cellRole);

                tableManageUsers.Rows.Add(tableRow);
            }
        }

        protected void btnEditUser_Click(object sender, EventArgs e)
        {
            ImageButton btn = sender as ImageButton;
            int userId = Int32.Parse(btn.CommandArgument);
            
            Session["PWAS_UserToEdit"] = userId;
            Response.Redirect("adminView_EditProfile.aspx");
        }

        protected void btnDeleteUser_Click(object sender, EventArgs e)
        {
            ImageButton btn = sender as ImageButton;
            int userId = Int32.Parse(btn.CommandArgument);

            IUserRepository userRepo = RepositoryFactory.Get<IUserRepository>();
            userRepo.DeactivateUser(userId);
            userRepo.SubmitChanges();
        }

        protected void btnUpdateRole_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int userId = Int32.Parse(btn.CommandArgument);

            IUserRepository userRepo = RepositoryFactory.Get<IUserRepository>();
            User user = userRepo.GetById(userId);
            user.roleID = Int32.Parse(((DropDownList)FindControl("ddRoles")).SelectedValue);
            userRepo.SubmitChanges();
        }
    }
}