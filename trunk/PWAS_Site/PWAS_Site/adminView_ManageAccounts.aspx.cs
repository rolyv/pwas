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
                    TableCell tableCell = new TableCell();
                    Image edit = new Image();
                    edit.ImageUrl = "images/";
                    tableRow.Cells.Add(new TableCell());
                    tableRow.Cells.Add(new TableCell());

                }
            }
        }
    }
}
