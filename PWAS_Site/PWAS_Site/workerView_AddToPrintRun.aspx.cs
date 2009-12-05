using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Collections.Generic;

using PWAS.DataAccess.Interfaces;
using PWAS.DataAccess.SQLRepositories;
using PWAS.Model;

namespace PWAS_Site
{
    public partial class workerView_AddToPrintRun : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IPrintRunRepository prRepo = RepositoryFactory.Get<IPrintRunRepository>();
           
            List<PrintRun> prList = prRepo.PrintRuns.Where(p => p.run_status == OrderConstants.ORDER_STATUS_CREATED).ToList<PrintRun>();

            ListItem tempItem;
            foreach (PrintRun pr in prList)
            {
                tempItem = new ListItem("Run "+pr.runID, pr.runID.ToString());
                runList.Items.Add(tempItem);
            }
        }
    }
}
