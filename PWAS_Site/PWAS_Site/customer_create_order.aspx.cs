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
using System.IO;


namespace PWAS_Site
{
    public partial class customer_create_order : System.Web.UI.Page
    {

        protected void saveOrder(object sender, EventArgs e)
        {
            IOrderRepository orderRepository = RepositoryFactory.Get<IOrderRepository>();
            Order orderCreate;

            if (validateFields())
            {
                orderCreate = new Order();
                orderCreate.userID = getUserID();                                                  
                orderCreate.job_name = this.txtJobName.Text;
                orderCreate.width = Int32.Parse(this.txtFinalSizeX.Text);
                orderCreate.height = Int32.Parse(this.txtFinalSizeY.Text);
                orderCreate.quantity = Int32.Parse(this.txtQty.Text);
                orderCreate.stock_finish = this.lstFinish.SelectedValue;
                orderCreate.stock_weight = this.lstWeight.SelectedValue;
                orderCreate.two_sided = this.chkTwoSide.Checked;
                orderCreate.folded = this.chkfolded.Checked;
                orderCreate.ship = this.chkShip.Checked;
                orderCreate.price = calculatePrice(orderCreate);    
                

                orderRepository.AddOrder(orderCreate);
                orderRepository.SubmitChanges();

                this.lblNotify.Text = "Order Created Sucessfull!  with ID :" + orderCreate.orderID;
                this.lblNotify.ForeColor = System.Drawing.Color.Blue;
                this.lblNotify.Visible = true;
                func_clearFields(false);
            }
        }

        private decimal calculatePrice(Order orderCreate)
        {
            decimal price = 0;
            //----------calculate the price
            price = (decimal)(orderCreate.quantity * (0.5*orderCreate.width * orderCreate.height));
            //----------------------------
            return price;
        }
        protected void func_clear(object sender, EventArgs e)
        {
            func_clearFields(true);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblNotify.Visible = false;
        }

        private void func_clearFields(bool notify)
        {
            if (notify)
                this.lblNotify.Visible = false;
            this.txtJobName.Text = "";
            this.txtFinalSizeX.Text = "";
            this.txtFinalSizeY.Text = "";
            this.txtQty.Text = "";
            this.chkTwoSide.Checked = false;
            this.chkfolded.Checked = false;
            this.chkShip.Checked = false;

            lblUploadedFile.Text = "";
            lblUploadedFile.Visible = false;
            lblUploadedFileHeader.Visible = false;
        }
        private int getUserID()
        {
            if (Session[Constants.PWAS_SESSION_ID] == null)
                Response.Redirect("login.aspx");
            return (int)Session[Constants.PWAS_SESSION_ID];
        }
        private bool validateFields()
        {
            int test;

            if (this.txtJobName.Text == ""
                || this.txtFinalSizeX.Text == ""
                || this.txtFinalSizeY.Text == ""
                || this.txtQty.Text == "")
            {
                this.lblNotify.Text = "Please complete all required fields!";
                this.lblNotify.Visible = true;
                this.lblNotify.BorderColor = System.Drawing.Color.Red;
                this.lblNotify.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            if (ViewState["attachment"] == null)
            {
                this.lblNotify.Text = "Please upload your artwork before submitting your order";
                this.lblNotify.Visible = true;
                this.lblNotify.BorderColor = System.Drawing.Color.Red;
                this.lblNotify.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            try
            {
                test = Int32.Parse(this.txtFinalSizeX.Text);
                test = Int32.Parse(this.txtFinalSizeY.Text);
                test = Int32.Parse(this.txtQty.Text);
            }
            catch (FormatException)
            {
                this.lblNotify.Text = "Please enter numbers in:<br />Final Size fields<br />Qty to Print field";
                this.lblNotify.Visible = true;
                this.lblNotify.BorderColor = System.Drawing.Color.Red;
                this.lblNotify.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            return true;
        }

        protected void btnFileUpload_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FileUpload.FileName))
            {
                lblUploadedFileHeader.Visible = true;
                lblUploadedFile.Visible = true;

                Byte[] bytes = FileUpload.FileBytes;
                ViewState["attachment"] = bytes;

                string file = FileUpload.FileName;
                int index = file.LastIndexOf("\\");
                if (index > 0) 
                    file = file.Substring(index, file.Length);
                lblUploadedFile.Text = file;
            }
        }
    }
}