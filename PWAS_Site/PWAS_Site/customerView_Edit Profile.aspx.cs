using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PWAS.DataAccess.Interfaces;
using PWAS_Site;
using PWAS.DataAccess.SQLRepositories;
using PWAS.Model;

public partial class customerView_Edit_Profile : System.Web.UI.Page
{
    int userId = -1;

    protected void Page_Load(object sender, EventArgs e)
    {
        userId = Int32.Parse( Session["PWAS_ID"].ToString() );

        IUserRepository userRepo = RepositoryFactory.Get<IUserRepository>();
        User user = userRepo.GetById(userId);
        
        populateInformation();
    }

    private void populateInformation()
    {
        
    }
}
