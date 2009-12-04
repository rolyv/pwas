using System;
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
            if (!IsPostBack)
            {
                //load all users and populate tableManageUsers
                IUserRepository userRepo = RepositoryFactory.Get<IUserRepository>();
                List<User> users = userRepo.Users.ToList();

                foreach (User user in users)
                {
                    TableRow tableRow = new TableRow();
                    tableRow.CssClass = "orderRow";
                    
                    TableCell cellEdit = new TableCell();
                    Image edit = new Image();
                    edit.ImageUrl = "/images/edit.gif";
                    cellEdit.Controls.Add(edit);
                    
                    TableCell cellDelete = new TableCell();
                    Image delete = new Image();
                    delete.ImageUrl = "/images/delete.gif";
                    cellDelete.Controls.Add(delete);

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

                    tableRow.Cells.Add(cellEdit);
                    tableRow.Cells.Add(cellDelete);
                    tableRow.Cells.Add(cellUsername);
                    tableRow.Cells.Add(cellFullName);
                    tableRow.Cells.Add(cellTelephone);
                    tableRow.Cells.Add(cellEmail);

                    tableManageUsers.Rows.Add(tableRow);

                }
            }
        }
    }
}
