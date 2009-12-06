using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PWAS.Model;
using PWAS.DataAccess.Interfaces;

namespace PWAS_Site
{
    public partial class WebForm6 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            IPrintRunRepository PrintRunRepository = RepositoryFactory.Get<IPrintRunRepository>();

            var query =  from p
                         in PrintRunRepository.PrintRuns
                         select p; ;

            foreach (var pr in query)
            {
                TableCell cellView = new TableCell();                
                TableCell cellstatus = new TableCell();
                TableCell cellaction = new TableCell();
                TableCell cellID = new TableCell();
                TableCell cellName = new TableCell();

                cellView.Controls.Add(getViewControl(pr));               
                cellstatus.Controls.Add(getStatusControl(pr));
                cellaction.Controls.Add(getActionControl(pr));
                cellID.Text = pr.runID.ToString();
                cellName.Text = pr.run_name.ToString();

                //----
                cellView.HorizontalAlign = HorizontalAlign.Center;                
                cellstatus.HorizontalAlign = HorizontalAlign.Center;
                cellaction.HorizontalAlign = HorizontalAlign.Center;
                cellID.HorizontalAlign = HorizontalAlign.Center;

                //----
                cellID.Width = Unit.Pixel(150);
                cellName.Width = Unit.Pixel(200);
                cellstatus.Width = Unit.Pixel(200);
                cellaction.Width = Unit.Pixel(100);


                TableRow prrow = new TableRow();

                prrow.Cells.Add(cellView);                
                prrow.Cells.Add(cellID);
                prrow.Cells.Add(cellName);
                prrow.Cells.Add(cellstatus);
                prrow.Cells.Add(cellaction);

                prrow.CssClass = "orderRow";
                PrintRunTable.Rows.Add(prrow);

            }

        }



        private Control getStatusControl(PrintRun pr)
        {

            DropDownList dropListStatus = new DropDownList();
            dropListStatus.ID = pr.runID.ToString();

            IStatusRepository statusRepository = RepositoryFactory.Get<IStatusRepository>();
            var query = statusRepository.Statuses.ToList();

            foreach (int statusID in Enum.GetValues(typeof(PWAS_Site.PrintRunStatus)))
            {                
                ListItem lsItem = new ListItem(statusRepository.GetById(statusID).statusName);
                dropListStatus.Items.Add(lsItem);

                if (pr.Status.statusId == statusID)
                    dropListStatus.SelectedIndex = dropListStatus.Items.IndexOf(lsItem);

                if (pr.Status.statusId == OrderConstants.ORDER_STATUS_CREATED || pr.Status.statusId == OrderConstants.ORDER_STATUS_CLOSED)
                    dropListStatus.Enabled = false;
            }
            
            dropListStatus.Width = Unit.Pixel(200);            
            dropListStatus.SelectedIndexChanged += new EventHandler(func_selected);
            dropListStatus.AutoPostBack = true;
            
            return dropListStatus;
        }
                
        private Control getViewControl(PrintRun pr)
        {
            ImageButton editButton = new ImageButton();

            if(Security.IsAuthorized(getUserID(),PWAS_Site.PwasObject.PrintRun,PwasAction.View,PwasScope.All))
            {
                editButton.ID = pr.runID + "edit";
                editButton.CommandArgument = pr.runID.ToString();
                editButton.ImageUrl = "/images/left-list.gif";
                editButton.Visible = true;
                editButton.Command += new CommandEventHandler(func_View);
            }
            else if (Security.IsAuthorized(getUserID(), PWAS_Site.PwasObject.PrintRun, PwasAction.View, PwasScope.Self))
            {
                editButton.ID = pr.runID + "edit";
                editButton.CommandArgument = pr.runID.ToString();
                editButton.ImageUrl = "/images/left-list_gray.gif";
            }
            else{
                Response.Redirect("index.aspsx");
            }
            return editButton;
        }
        private Control getActionControl(PrintRun pr)
        {
            Button actionbutton = new Button();

            if (Security.IsAuthorized(getUserID(), PWAS_Site.PwasObject.PrintRun, PwasAction.Update, PwasScope.All))
            {
                actionbutton.ID = pr.runID + "update";
                actionbutton.CommandArgument = pr.runID.ToString();
                actionbutton.Text = "Update";
                actionbutton.Visible = true;
                actionbutton.Width = Unit.Pixel(100);
                actionbutton.Command += new CommandEventHandler(func_update);
            }else if(Security.IsAuthorized(getUserID(), PWAS_Site.PwasObject.PrintRun, PwasAction.Update, PwasScope.Self))
            {
                actionbutton.ID = pr.runID + "update";
                actionbutton.Enabled = false;
            }
            else
            {
                Response.Redirect("index.aspsx");
            }
            return actionbutton;
        }


        private void func_selected(object sender, EventArgs e)
        {            
            int printRunID = System.Int32.Parse(((DropDownList)sender).ID);
            ViewState[printRunID.ToString()] = ((DropDownList)sender).SelectedValue;
        }

        private void func_update(object sender, CommandEventArgs e)
        {
            IStatusRepository statusRepo = RepositoryFactory.Get<IStatusRepository>();
            IPrintRunRepository printRun = RepositoryFactory.Get<IPrintRunRepository>();

            int runID = System.Int32.Parse(e.CommandArgument.ToString());
            if (ViewState[runID.ToString()] != null)
            {
                string statusName = ViewState[runID.ToString()].ToString();
                Status currentStatus = statusRepo.Statuses.Single(x => x.statusName == statusName);
                printRun.UpdatePrintRunStatus(runID, currentStatus.statusId);

                if (OrderConstants.ORDER_STATUS_CLOSED == currentStatus.statusId)
                {
                    UpdateOrderStatus_PrintRun(runID, OrderConstants.ORDER_STATUS_SHIPPED);
                }
            }
            else
            {
                Response.Redirect("index.aspx");
            }

            
        }
        
        private void func_View(object sender, CommandEventArgs e)
        {
            int runID = System.Int32.Parse(e.CommandArgument.ToString());
            Session["PWAS_run_id"] = runID;
            Response.Redirect("view_Single_PrintRun.aspx");
        }

        public void UpdateOrderStatus_PrintRun(int printRundId, int statusID)
        {
            IPrintRunRepository printRepo = RepositoryFactory.Get<IPrintRunRepository>();
            IOrderRepository orderRepo = RepositoryFactory.Get<IOrderRepository>();
            

            PrintRun printRun = printRepo.GetById(printRundId);
                        
            var orders = from p
                         in orderRepo.Orders
                         where p.PrintRun.runID == printRundId
                         select p;

            foreach (var cur_Order in orders)
            {
                orderRepo.UpdateOrderStatus(cur_Order.orderID, statusID);
            }
        }
        private int getUserID()
        {
            return (int)Session[Constants.PWAS_SESSION_ID];
        }
    }
}
