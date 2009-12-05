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
    public partial class view_Single_Order : System.Web.UI.Page
    {
        protected void backButton(object sender, EventArgs e)
        {
            Response.Redirect("customer_view_order.aspx");
        }

        protected void okButton(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PWAS_order_id"] != null)
            {
                int orderID = System.Int32.Parse(Session["PWAS_order_id"].ToString());

                IOrderRepository orderRepository = RepositoryFactory.Get<IOrderRepository>();
                Order current_order = orderRepository.GetById(orderID);
                                
                this.txtJobName.Text = current_order.job_name;
                this.txtFinalSizeX.Text = current_order.width.ToString();
                this.txtFinalSizeY.Text = current_order.height.ToString();
                this.txtQty.Text = current_order.quantity.ToString();
                this.lstFinish.SelectedIndex = this.lstFinish.Items.IndexOf(lstFinish.Items.FindByText(current_order.stock_finish));
                this.lstWeight.SelectedIndex = this.lstWeight.Items.IndexOf(lstWeight.Items.FindByText(current_order.stock_weight));
                this.chkTwoSide.Checked = current_order.two_sided;
                this.chkfolded.Checked = current_order.folded;
                this.chkShip.Checked = current_order.ship;
                

                //disable
                this.txtJobName.Enabled = false;
                this.txtFinalSizeX.Enabled = false;
                this.txtFinalSizeY.Enabled = false;
                this.txtQty.Enabled = false;
                this.lstFinish.Enabled = false;
                this.lstWeight.Enabled = false;
                this.chkTwoSide.Enabled = false;
                this.chkfolded.Enabled = false;
                this.chkShip.Enabled = false;
            }
            else
            {
                Response.Redirect("customer_view_order.aspx");
            }

        }
    }
}
