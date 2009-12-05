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

using PWAS.Model;
using PWAS.DataAccess.Interfaces;


namespace PWAS_Site
{
    public partial class workerView_CreatePrintRun : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            notifyMsg.Visible = false;
        }

        public void createPrintRun(object sender, EventArgs e)
        {
            IPrintRunRepository prRepo = RepositoryFactory.Get<IPrintRunRepository>();
            PrintRun newRun;

            if (validateFields())
            {

                newRun = new PrintRun();
                newRun.height = Int32.Parse(runHeight.Text);
                newRun.width = Int32.Parse(runWidth.Text);
                newRun.quantity = Int32.Parse(runQuantity.Text);
                newRun.stock_finish = runFinish.SelectedValue;
                newRun.stock_weight = runWeight.SelectedValue;
                newRun.run_name = runName.Text;

                prRepo.AddPrintRun(newRun);
                prRepo.SubmitChanges();

                notifyMsg.Text = "Print Run Created Sucessfully";
                notifyMsg.ForeColor = System.Drawing.Color.Green;
                notifyMsg.Visible = true;

            }
           

        }

        private bool validateFields()
        {
           
            //validate form fields
            if (runName.Text.Trim().Equals("") || runFinish.SelectedValue.Trim().Equals("") ||
                runWeight.SelectedValue.Trim().Equals("") ||
                runHeight.Text.Trim().Equals("") || runWidth.Text.Trim().Equals("") ||
                runQuantity.Text.Trim().Equals(""))
            {
                notifyMsg.Text = "Some required fields are still empty.";
                notifyMsg.ForeColor = System.Drawing.Color.Red;
                notifyMsg.Visible = true;

                return false;
            }

            int result;
            if (!Int32.TryParse(runQuantity.Text.Trim(), out result))
            {
                notifyMsg.Text = "Quantity must be an integer value.";
                notifyMsg.ForeColor = System.Drawing.Color.Red;
                notifyMsg.Visible = true;

                return false;
            }
            
            if (!Int32.TryParse(runHeight.Text.Trim(), out result) || !Int32.TryParse(runWidth.Text.Trim(), out result))
            {
                notifyMsg.Text = "Dimensions must be integer values.";
                notifyMsg.ForeColor = System.Drawing.Color.Red;
                notifyMsg.Visible = true;

                return false;
            }

            return true;
        }
    }
}
