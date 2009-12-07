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
            //check that user has access
            //if not -> redirect to home page
            if (Session[Constants.PWAS_SESSION_ID] == null || !Security.IsAuthorized((int)Session[Constants.PWAS_SESSION_ID], PwasObject.PrintRun, PwasAction.View, PwasScope.All))
            {
                Response.Redirect("customerView_Home.aspx");
            }


            loadPrintRunList();
            loadOrderTable();
        }

        private void loadPrintRunList()
        {
            if (runList.Items.Count == 0)
            {
                IPrintRunRepository prRepo = RepositoryFactory.Get<IPrintRunRepository>();
                List<PrintRun> prList = prRepo.PrintRuns.Where(p => p.run_status == OrderConstants.ORDER_STATUS_CREATED).ToList<PrintRun>();

                ListItem tempItem;

                foreach (PrintRun pr in prList)
                {
                    tempItem = new ListItem("Run " + pr.runID+" - "+pr.run_name, pr.runID.ToString());
                    tempItem.Value = pr.runID.ToString();
                    runList.Items.Add(tempItem);
                }
            }
            
        }

        private void loadOrderTable()
        {
            //load active orders and populate tableCreatedOrders
            IOrderRepository orderRepo = RepositoryFactory.Get<IOrderRepository>();
            List<Order> paidOrders = orderRepo.Orders.Where(o => o.currentStatus == OrderConstants.ORDER_STATUS_PAID).ToList<Order>();
            bool canSelect = Security.IsAuthorized((int)Session[Constants.PWAS_SESSION_ID], PwasObject.PrintRun, PwasAction.Update, PwasScope.All);

            foreach (Order order in paidOrders)
            {
                TableRow tableRow = new TableRow();
                tableRow.CssClass = "orderRow";


                TableCell cellSelect = new TableCell();
                CheckBox check = new CheckBox();
                check.Enabled = canSelect;
                cellSelect.Controls.Add(check);

                TableCell orderID = new TableCell();
                orderID.Text = order.orderID.ToString();

                TableCell orderName = new TableCell();
                orderName.Text = order.job_name.ToString();

                TableCell orderQuantity = new TableCell();
                orderQuantity.Text = order.quantity.ToString();

                TableCell orderHeight = new TableCell();
                orderHeight.Text = order.height.ToString();

                TableCell orderWidth = new TableCell();
                orderWidth.Text = order.width.ToString();

                cellSelect.Width = Unit.Pixel(60);
                orderID.Width = Unit.Pixel(60);
                orderName.Width = Unit.Pixel(150);
                orderQuantity.Width = Unit.Pixel(100);
                orderHeight.Width = Unit.Pixel(100);
                orderWidth.Width = Unit.Pixel(100);

                tableRow.Cells.Add(cellSelect);
                tableRow.Cells.Add(orderID);
                tableRow.Cells.Add(orderName);
                tableRow.Cells.Add(orderQuantity);
                tableRow.Cells.Add(orderHeight);
                tableRow.Cells.Add(orderWidth);

                tableCreatedOrders.Rows.Add(tableRow);
            }
        }

        protected void doSubmit(object sender, EventArgs e)
        {
            int i = 0;
            bool somethingSelected = false;

            List<TableRow> toDelete = new List<TableRow>();
            foreach (TableRow row in tableCreatedOrders.Rows)
            {
                if (i > 0)//skip the first row, since it's the header row
                {
                    TableCell tempCell = row.Cells[0];
                    if (((CheckBox)tempCell.Controls[0]).Checked)
                    {
                        somethingSelected = true;
                        IOrderRepository orderRepo = RepositoryFactory.Get<IOrderRepository>();
                        orderRepo.UpdateOrderStatus(Int32.Parse(row.Cells[1].Text), OrderConstants.ORDER_STATUS_PROCESSING);
                        orderRepo.UpdateOrderRunId(Int32.Parse(row.Cells[1].Text), Int32.Parse(runList.SelectedValue));
                        toDelete.Add(row);
                    }
                }

                i++;
            }

            if (somethingSelected)
            {
                IPrintRunRepository prRepo = RepositoryFactory.Get<IPrintRunRepository>();
                prRepo.UpdatePrintRunStatus(Int32.Parse(runList.SelectedValue), OrderConstants.ORDER_STATUS_PREPRINTING);

                //1.delete the selected rows from "tableCreatedOrders"
                //2.delete the selected print run from the drop down "runList"

                foreach (TableRow row in toDelete)
                {
                    tableCreatedOrders.Rows.Remove(row);
                }

                runList.Items.Remove(runList.SelectedItem);

                messageNotify.Text = "Your orders have been added to the print run successfully.";
                messageNotify.ForeColor = System.Drawing.Color.Green;
                messageNotify.Visible = true;

            }
            
        }


       
    }
}
