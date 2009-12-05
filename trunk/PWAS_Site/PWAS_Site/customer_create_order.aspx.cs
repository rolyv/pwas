﻿using System;
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
    public partial class Formulario_web1 : System.Web.UI.Page
    {

        protected void saveOrder(object sender, EventArgs e)
        {
            IOrderRepository orderRepository = RepositoryFactory.Get<IOrderRepository>();
            Order orderCreate;

            if (validateFields())
            {
                orderCreate = new Order
                {
                    userID = getUserID(),
                    job_name = this.txtJobName.Text,
                    width = Int32.Parse(this.txtFinalSizeX.Text),
                    height = Int32.Parse(this.txtFinalSizeY.Text),
                    quantity = Int32.Parse(this.txtQty.Text),
                    stock_finish = this.lstFinish.SelectedValue,
                    stock_weight = this.lstWeight.SelectedValue,
                    two_sided = this.chkTwoSide.Checked,
                    folded = this.chkfolded.Checked,
                    ship = this.chkShip.Checked                    
                };
                
                orderRepository.AddOrder(orderCreate);
                orderRepository.SubmitChanges();

                this.lblNotify.Text = "Order Created Sucessfull!  with ID :" + orderCreate.orderID;
                this.lblNotify.ForeColor = System.Drawing.Color.Blue;
                this.lblNotify.Visible = true;
                func_clearFields(false);
            }
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
        }


        private int getUserID()
        {
            return (int)Session[Constants.PWAS_SESSION_ID];
        }

        private bool validateFields()
        {
            int test;

            bool ret = true;
            if (this.txtJobName.Text == ""
                || this.txtFinalSizeX.Text == ""
                || this.txtFinalSizeY.Text == ""
                || this.txtQty.Text == "")
            {
                this.lblNotify.Text = "You need to complete all the fields!";
                this.lblNotify.Visible = true;
                this.lblNotify.BorderColor = System.Drawing.Color.Red;
                this.lblNotify.ForeColor = System.Drawing.Color.Red;
                ret = false;
            }
            try
            {
                test = Int32.Parse(this.txtFinalSizeX.Text);
                test = Int32.Parse(this.txtFinalSizeY.Text);
                test = Int32.Parse(this.txtQty.Text);
            }
            catch (FormatException)
            {
                this.lblNotify.Text = "Bad Input in some field that are Integer required";
                this.lblNotify.Visible = true;
                this.lblNotify.BorderColor = System.Drawing.Color.Red;
                this.lblNotify.ForeColor = System.Drawing.Color.Red;
                ret = false;
            }
            return ret;
        }

        protected void func_clear(object sender, EventArgs e)
        {
            func_clearFields(true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}