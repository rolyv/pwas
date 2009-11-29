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
    public partial class customerView_View_Orders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IOrderRepository orderRepository = RepositoryFactory.Get<IOrderRepository>();
            int userID = 1007;// (int)Session[Constants.PWAS_SESSION_ID];
            
            /*
            try
            {
                userID = (int)Session[Constants.PWAS_SESSION_ID];
            }
            catch (Exception exception)
            {
                Response.Redirect("/login.aspx");
            }*/

            var query = from p in orderRepository.Orders where p.userID == userID select p ;
            
                        
            foreach(var ord in query)
            {
                TableRow row = new TableRow();
                
                TableCell cellOrderID = new TableCell();
                TableCell cellJobName = new TableCell();
                TableCell cellStatus = new TableCell();
                TableCell cellDate = new TableCell();

                cellOrderID.Controls.Add(new LiteralControl(ord.orderID.ToString()));
                cellJobName.Controls.Add(new LiteralControl(ord.job_name.ToString()));
                cellStatus.Controls.Add(getStatusControl(ord.orderID));
                
                cellDate.Controls.Add(new LiteralControl(getCurrentOrderStatusDate()));

                row.Cells.Add(cellOrderID);
                row.Cells.Add(cellJobName);
                row.Cells.Add(cellStatus);
                row.Cells.Add(cellDate);

                row.CssClass = "orderRow";

                this.orderHistoryTable.Rows.Add(row);
                
                
            }
        }

        private Control getStatusControl(int orderID)
        {
            string status = getCurrentOrderStatus();

            Control ret = new LiteralControl("---");
            LinkButton payButton;

            if (status.Equals("created"))
            {
                payButton = new LinkButton();
                payButton.ID = orderID+"";
                payButton.Text = "Pay Now";
                payButton.Visible = true;
                payButton.Command += new CommandEventHandler(func_Pay);
                
                ret = payButton;
            }
            else
            {
                ret = new LiteralControl(status);
            }

            return ret;
        }

        private void func_Pay(object sender, CommandEventArgs e)
        {
            this.lblNotify.Text = "Order Sucessfully Paid!";
            this.lblNotify.ForeColor = System.Drawing.Color.Blue;
            this.lblNotify.Visible = true;
        }

        private string getCurrentOrderStatus()
        {
            return "created";
        }
        private string getCurrentOrderStatusDate()
        {
            return "11/29/2009";
        }
    }
}
