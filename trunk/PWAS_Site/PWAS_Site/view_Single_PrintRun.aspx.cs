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
    public partial class View_single_printRun : System.Web.UI.Page
    {
        protected void backButton(object sender, EventArgs e)
        {
            Response.Redirect("view_print_run.aspx");
        }

        protected void okButton(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PWAS_run_id"] != null)
            {
                int runID = System.Int32.Parse(Session["PWAS_run_id"].ToString());                                
                IOrderRepository orderRepository = RepositoryFactory.Get<IOrderRepository>();

                var query = from p
                            in orderRepository.Orders
                            where p.runID == runID
                            select p;

                foreach (var current_order in query)
                {
                    TableRow row = new TableRow();

                    TableCell cellOrderID = new TableCell();
                    TableCell cellJobName = new TableCell();
                    TableCell cellPrice = new TableCell();
                    TableCell cellQuantity = new TableCell();
                    


                    cellOrderID.Controls.Add(new LiteralControl(current_order.orderID.ToString()));
                    cellJobName.Controls.Add(new LiteralControl(current_order.job_name.ToString()));
                    cellPrice.Controls.Add(new LiteralControl(String.Format("{0:C}",current_order.price.ToString())));
                    cellQuantity.Controls.Add(new LiteralControl(current_order.quantity.ToString()));
                    
                    //pixels
                    
                    cellOrderID.Width = Unit.Pixel(100);
                    cellJobName.Width = Unit.Pixel(200);
                    cellPrice.Width = Unit.Pixel(150);
                    cellQuantity.Width = Unit.Pixel(150);
                    

                    //Center
                    
                    cellQuantity.HorizontalAlign = HorizontalAlign.Center;
                    cellOrderID.HorizontalAlign = HorizontalAlign.Center;
                    cellPrice.HorizontalAlign = HorizontalAlign.Center;
                    
                                        
                    row.Cells.Add(cellOrderID);
                    row.Cells.Add(cellJobName);
                    row.Cells.Add(cellQuantity);
                    row.Cells.Add(cellPrice);
                    
                    
                    row.CssClass = "orderRow";

                    this.PrintRunTableView.Rows.Add(row);
                    
                }
            }
            else
            {
                Response.Redirect("view_print_run.aspx");
            }

        }
    }
}
