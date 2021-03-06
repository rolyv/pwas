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
using System.Collections.Generic;

using PWAS.Model;
using PWAS.DataAccess.Interfaces;


namespace PWAS_Site
{
    public partial class customer_view_order : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Constants.PWAS_SESSION_ID] == null) Response.Redirect("index.aspx");

            this.tblViewOrder.Visible = true;
            this.formEditOrder.Visible = false;
            panelAlert.Visible = false;
            panelAlertEmployee.Visible = false;

            IOrderRepository orderRepository = RepositoryFactory.Get<IOrderRepository>();

            int userID = getUserID();

            IQueryable<Order> orders_User = OrderUtilities.getOrdersByUser(userID, Response);// getOrdersByUser(userID);
                        
            foreach (Order current_order in orders_User)
            {
                TableRow row = new TableRow();

                TableCell cellOrderID = new TableCell();
                TableCell cellJobName = new TableCell();
                TableCell cellPrice = new TableCell();
                TableCell cellStatus = new TableCell();
                TableCell cellDate = new TableCell();
                TableCell cellEdit = new TableCell();
                TableCell cellView = new TableCell();


                cellOrderID.Controls.Add(new LiteralControl(current_order.orderID.ToString()));
                cellJobName.Controls.Add(new LiteralControl(current_order.job_name.ToString()));
                cellPrice.Controls.Add(new LiteralControl(getOrderPrice(current_order.orderID)));
                cellStatus.Controls.Add(getStatusControl(current_order));
                cellDate.Controls.Add(new LiteralControl(OrderUtilities.getCurrentOrderStatusDate(current_order.orderID)));
                cellEdit.Controls.Add(getEditButton(current_order));
                cellView.Controls.Add(getViewButton(current_order));

                //pixels
                //cellEdit.Width = Unit.Pixel(50);
                //cellView.Width = Unit.Pixel(50);
                cellOrderID.Width = Unit.Pixel(100);
                cellJobName.Width = Unit.Pixel(200);
                cellPrice.Width = Unit.Pixel(150);
                cellStatus.Width = Unit.Pixel(150);
                cellDate.Width = Unit.Pixel(200);

                //Center
                cellEdit.HorizontalAlign = HorizontalAlign.Center;
                cellDate.HorizontalAlign = HorizontalAlign.Center;
                cellStatus.HorizontalAlign = HorizontalAlign.Center;
                cellOrderID.HorizontalAlign = HorizontalAlign.Center;
                cellPrice.HorizontalAlign = HorizontalAlign.Center;
                cellView.HorizontalAlign = HorizontalAlign.Center;

                row.Cells.Add(cellEdit);
                row.Cells.Add(cellView);
                row.Cells.Add(cellOrderID);
                row.Cells.Add(cellJobName);
                row.Cells.Add(cellPrice);
                row.Cells.Add(cellStatus);
                row.Cells.Add(cellDate);               

                row.CssClass = "orderRow";

                this.orderHistoryTable.Rows.Add(row);
            }
        }
        
        private Control getViewButton(Order current_order)
        {          
            Control retControl = null;

            if (Security.IsAuthorized(getUserID(), PwasObject.Order, PwasAction.Update, PwasScope.All))
            {
                ImageButton viewButton = new ImageButton();

                viewButton.ID = current_order.orderID + "v";
                viewButton.CommandArgument = current_order.orderID.ToString();
                viewButton.ImageUrl = "/images/left-list.gif";                
                viewButton.Command += new CommandEventHandler(func_View);

                retControl = viewButton;
            }
            else if (Security.IsAuthorized(getUserID(), PwasObject.Order, PwasAction.Update, PwasScope.Self)
                    && OrderUtilities.isMyOrder(current_order.orderID,getUserID()))
            {
                ImageButton viewButton = new ImageButton();

                viewButton.ID = current_order.orderID + "v";
                viewButton.CommandArgument = current_order.orderID.ToString();
                viewButton.ImageUrl = "/images/left-list.gif";
                viewButton.Command += new CommandEventHandler(func_View);

                retControl = viewButton;
            }
            else
            {
                Image image = new Image();
                image.ImageUrl = "/images/left-list_gray.gif";
                retControl = image;
            }

            return retControl;
        }
              
        private Control getEditButton(Order current_order)
        {

            Control retControl = null;
            
            if (Security.IsAuthorized(getUserID(), PwasObject.Order, PwasAction.Update, PwasScope.All) 
                && (current_order.Status.statusId == OrderConstants.ORDER_STATUS_CREATED 
                    || current_order.Status.statusId == OrderConstants.ORDER_STATUS_PAID))
            {
                ImageButton editButton = new ImageButton();
                editButton.ID = current_order.orderID + "e";
                editButton.CommandArgument = current_order.orderID.ToString();
                editButton.ImageUrl = "/images/edit.gif";
                editButton.Command += new CommandEventHandler(func_Edit);
                retControl = editButton;
            }
            else if (Security.IsAuthorized(getUserID(), PwasObject.Order, PwasAction.Update, PwasScope.Self) 
                    && current_order.Status.statusId == OrderConstants.ORDER_STATUS_CREATED  
                    && OrderUtilities.isMyOrder(current_order.orderID,getUserID()))
            {
                ImageButton editButton = new ImageButton();
                editButton.ID = current_order.orderID + "e";
                editButton.CommandArgument = current_order.orderID.ToString();
                editButton.ImageUrl = "/images/edit.gif";
                editButton.Command += new CommandEventHandler(func_Edit);
                retControl = editButton;
            }
            else
            {
                Image image = new Image();
                image.ImageUrl = "/images/edit_gray.gif";
                retControl = image;
            }

            return retControl;
        }      
 
        private Control getStatusControl(Order currentOrder)
        {
            Status status = currentOrder.Status;

            Control ret = new LiteralControl("---");
            Button payButton;

            if (status.statusId == OrderConstants.ORDER_STATUS_CREATED)
            {
                payButton = new Button();
                payButton.ID = currentOrder.orderID + "s";
                payButton.Text = "Pay Now";
                payButton.Visible = true;
                payButton.Width = Unit.Pixel(150);                
                payButton.CommandArgument = currentOrder.orderID.ToString();
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
            IUserRepository userRepo = RepositoryFactory.Get<IUserRepository>();
            User user = userRepo.GetById((int)Session[Constants.PWAS_SESSION_ID]);

            //If the user is a customer, test the user profile
            if (user.roleID == 1)
            {
                if (!(validateUserBillingAddress(user) && validateUserCreditCardInfo(user)))
                {
                    panelAlert.Visible = true;
                    return;
                }
            }
            //If the user is not a customer, test the profile for the customer attached to the order
            else
            {
                Button btn = (Button)sender;
                int orderId = Int32.Parse(btn.CommandArgument);

                IOrderRepository orderRepo = RepositoryFactory.Get<IOrderRepository>();
                Order order = orderRepo.GetById(orderId);
                user = userRepo.GetById(order.userID);

                if (!(validateUserBillingAddress(user) && validateUserCreditCardInfo(user)))
                {
                    if (user == userRepo.GetById((int)Session[Constants.PWAS_SESSION_ID]))
                        panelAlert.Visible = true;
                    else 
                        panelAlertEmployee.Visible = true;
                    return;
                }
            }

            this.lblNotify.Text = "Order Sucessfully Paid!";
            this.lblNotify.ForeColor = System.Drawing.Color.Blue;
            this.lblNotify.Visible = true;

            int orderID = System.Int32.Parse(e.CommandArgument.ToString());
            RepositoryFactory.Get<IOrderRepository>().UpdateOrderStatus(orderID, 2);

            Response.Redirect(Request.Url.ToString());
        }

        private bool validateUserBillingAddress(User user)
        {
            bool address1 = !string.IsNullOrEmpty(user.b_address1.Trim());
            bool city = Utilities.IsValidName(user.b_city.Trim());
            bool state = Utilities.IsValidState(user.b_state.Trim());
            bool zip = Utilities.IsValidZip(user.b_zip.Trim());

            return address1 && city && state && zip;
        }

        private bool validateUserCreditCardInfo(User user)
        {
            bool cardNumber = user.cc_num != null && Utilities.IsValidCreditCard(user.cc_num.Trim());
            //bool cardtype //does not need to be validated. Is a drop-down that always contains a value.
            bool expDate = user.exp_date != null && !string.IsNullOrEmpty(user.exp_date.Trim());
            bool secCode = user.cc_scode != null && Utilities.IsValidSecurityCode(user.cc_scode.Trim());
            bool cardName = user.cc_nameOnCard != null && Utilities.IsValidName(user.cc_nameOnCard.Trim()); //Note: will find issue if there is a space between the first and last name.

            return cardNumber && expDate && secCode && cardName;
        }

        protected void btnAlertEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("customerView_EditProfile.aspx");
        }

        protected void btnAlertCancel_Click(object sender, EventArgs e)
        {
            panelAlert.Visible = false;
        }

        protected void btnAlertOk_Click(object sender, EventArgs e)
        {
            panelAlertEmployee.Visible = false;
        }

        private void func_Edit(object sender, CommandEventArgs e)
        {
            this.formEditOrder.Visible = true;
            this.tblViewOrder.Visible = false;

            IOrderRepository orderRepository = RepositoryFactory.Get<IOrderRepository>();

            int orderID =  System.Int32.Parse(e.CommandArgument.ToString());
            Session["PWAS_order_id"] = orderID;
                                    
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
            
        }

        protected void func_Save(object sender, EventArgs e)
        {
            IOrderRepository orderRepository = RepositoryFactory.Get<IOrderRepository>();

            if (Session["PWAS_order_id"] != null)
            {
                int orderID = System.Int32.Parse(Session["PWAS_order_id"].ToString());   
                Order orderEdit = orderRepository.GetById(orderID);

                if (validateFields())
                {
                    orderEdit.userID = getUserID();
                    orderEdit.job_name = this.txtJobName.Text;
                    orderEdit.width = Int32.Parse(this.txtFinalSizeX.Text);
                    orderEdit.height = Int32.Parse(this.txtFinalSizeY.Text);
                    orderEdit.quantity = Int32.Parse(this.txtQty.Text);
                    orderEdit.stock_finish = this.lstFinish.SelectedValue;
                    orderEdit.stock_weight = this.lstWeight.SelectedValue;
                    orderEdit.two_sided = this.chkTwoSide.Checked;
                    orderEdit.folded = this.chkfolded.Checked;
                    orderEdit.ship = this.chkShip.Checked;
                    orderEdit.price = calculatePrice(orderEdit);

                    orderRepository.SubmitChanges();

                    this.lblNotify.Text = "Order Edited Sucessfully!  ";
                    this.lblNotify.ForeColor = System.Drawing.Color.Blue;
                    this.lblNotify.Visible = true;
                    func_clearFields(false);

                    Response.Redirect("customer_view_order.aspx");

                }
            }
            else
            {
                Response.Redirect("customer_view_order.aspx");
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

        private void func_View(object sender, CommandEventArgs e)
        {
            int orderID = System.Int32.Parse(e.CommandArgument.ToString());
            Session["PWAS_order_id"] = orderID;
            Response.Redirect("view_Single_Order.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("customer_view_order.aspx");
        }

        private string getOrderPrice(int orderID)
        {
            IOrderRepository orderRepository = RepositoryFactory.Get<IOrderRepository>();
            Order current_order = orderRepository.GetById(orderID);
            return string.Format("{0:C}",current_order.price);             
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
            if (Session[Constants.PWAS_SESSION_ID] == null)
                Response.Redirect("index.aspx");
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
  
    }
}
