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
    public partial class Formulario_web11 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            IOrderRepository orderRepository = RepositoryFactory.Get<IOrderRepository>();
            
            int userID = (int)Session[Constants.PWAS_SESSION_ID];
            

            var query = from p in orderRepository.Orders where p.userID == userID select p;


            foreach (var ord in query)
            {
                TableRow row = new TableRow();

                TableCell cellOrderID = new TableCell();
                TableCell cellJobName = new TableCell();
                TableCell cellStatus = new TableCell();
                TableCell cellDate = new TableCell();

                cellOrderID.Controls.Add(new LiteralControl(ord.orderID.ToString()));
                cellJobName.Controls.Add(new LiteralControl(ord.job_name.ToString()));
                cellStatus.Controls.Add(getStatusControl(ord.orderID));

                cellDate.Controls.Add(new LiteralControl(getCurrentOrderStatusDate(ord.orderID)));

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
            Status status = getCurrentOrderStatus(orderID);

            Control ret = new LiteralControl("---");
            LinkButton payButton;

            if (status.statusId == 1)
            {
                payButton = new LinkButton();
                payButton.ID = orderID + "";
                payButton.Text = "Pay Now";
                payButton.Visible = true;
                payButton.Command += new CommandEventHandler(func_Pay);

                ret = payButton;
            }
            else
            {
                ret = new LiteralControl(status.statusName);
            }

            return ret;
        }
        

        private void func_Pay(object sender, CommandEventArgs e)
        {
            this.lblNotify.Text = "Order Sucessfully Paid!";
            this.lblNotify.ForeColor = System.Drawing.Color.Blue;
            this.lblNotify.Visible = true;
            updateOrderStatus(System.Int32.Parse(((LinkButton)sender).ID.ToString()));
            
        }

        private void updateOrderStatus(int orderID)
        {
            IOrderRepository orderRepository = RepositoryFactory.Get<IOrderRepository>();
            IStatusRepository statusReposiory = RepositoryFactory.Get<IStatusRepository>();
            Order currentOrder = orderRepository.GetById(orderID);
            currentOrder.Status = new Status { statusId= 2,statusName = "Paid"};// statusReposiory.GetById(2);

            orderRepository.SubmitChanges();
            
            Response.Redirect(Request.Url.ToString());
        }

        private Status getCurrentOrderStatus(int orderID)
        {          
            IOrderRepository orderRepository = RepositoryFactory.Get<IOrderRepository>();
            IStatusRepository statusReposiory = RepositoryFactory.Get<IStatusRepository>();
            Order currentOrder = orderRepository.GetById(orderID);
            Status currentStatus = statusReposiory.GetById(currentOrder.Status.statusId);

            return currentStatus;
        }

        private string getCurrentOrderStatusDate(int orderID)
        {
            IOrderRepository orderRepository = RepositoryFactory.Get<IOrderRepository>();
            IOrderHistoryRepository historyRepository = RepositoryFactory.Get<IOrderHistoryRepository>();

            Order currentOrder = orderRepository.GetById(orderID);

            OrderHistory currentHistory = historyRepository.OrderHistories.Single(x => x.orderId == orderID && x.statusId == currentOrder.Status.statusId);// & x.statusId = currentOrder.Status);

            return currentHistory.modifiedDate.ToString();            
        }

    }
}
