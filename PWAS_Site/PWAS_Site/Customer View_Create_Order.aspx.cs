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
    public partial class Customer_View_Create_Order : System.Web.UI.Page
    {
        private string showOrders()
        {
            string ret = "";

            IOrderRepository orderRepository = RepositoryFactory.Get<IOrderRepository>();

            var query = from p in orderRepository.Orders
                        select p;

            foreach (var ord in query)
            {
                ret = ret + "ID = " + ord.orderID + " " + showUser(ord.userID) + "Job Name : " + ord.job_name;
            }

            return ret;

        }
        private string showRoles()
        {
            string ret = ">>";

            IRoleRepository roleRepo = RepositoryFactory.Get<IRoleRepository>();

            var query = roleRepo.Roles.Select(x => x);

            foreach (var ord in query)
            {
                ret = ret + " ID = " + ord.roleID + " NAME = " + ord.role_name;
            }

            return ret;

        }
        private string showOrder(int orderid)
        {
            string ret = "";

            IOrderRepository orderRepository = RepositoryFactory.Get<IOrderRepository>();
            Order o1 = orderRepository.GetById(orderid);

            ret = "Job Name = " + o1.job_name +
                  "width = " + o1.width +
                  "height = " + o1.height +
                  "quantity = " + o1.quantity +
                  "stock_finish = " + o1.stock_finish.ToString() +
                  "stock_weight = " + o1.stock_weight.ToString() +
                  "two_sided = " + o1.two_sided.ToString() +
                  "folded = " + o1.folded.ToString() +
                  "ship= " + o1.ship.ToString();

            return ret;
        }
        private void insertUser()
        {
            User usr = new User
            {
                //userID = 100,
                firstName = "pepito",
                lastName = "arteaga",
                email = "dulcardo@gmail.com",
                homePhone = "3053975553",
                s_address1 = "adfasasfsadf",
                s_city = "miami",
                s_state = "FL",
                s_zip = "33174",
                b_address1 = "asdf3adf asdf23",
                b_city = "miami",
                b_state = "FL",
                b_zip = "33174",
                roleID = 5
            };
            IUserRepository userRepo = RepositoryFactory.Get<IUserRepository>();
            userRepo.AddUser(usr);
            userRepo.SubmitChanges();
        }
        private string showUsers()
        {
            string ret = "";

            IUserRepository userRepo = RepositoryFactory.Get<IUserRepository>();

            var query = from p in userRepo.Users
                        select p;

            foreach (var usr in query)
            {
                ret = ret + " ID = " + usr.userID +
                    " Name = " + usr.firstName;
            }

            return ret;
        }
        private string showUser(int userId)
        {
            string ret = "";

            IUserRepository userRepo = RepositoryFactory.Get<IUserRepository>();
            User userCreate = userRepo.GetById(userId);

            ret = "ID = " + userCreate.userID +
                    "Name = " + userCreate.firstName;

            return ret;
        }

        protected void func_createPay(object sender, EventArgs e)
        {
            IOrderRepository orderRepository = RepositoryFactory.Get<IOrderRepository>();

            int luserID = 0;

            try
            {
                luserID = (int)Session[Constants.PWAS_SESSION_ID];
            }
            catch (Exception exception)
            {
                Response.Redirect("/login.aspx");
            }
            Order orderCreate;
            
            if(validateFields())
            {
                orderCreate = new Order {                    
                    userID = luserID,
                    job_name = this.txtJobName.Text,
                    width = Int32.Parse(this.txtFinalSizeX.Text),
		            height = Int32.Parse(this.txtFinalSizeY.Text),
		            quantity = Int32.Parse(this.txtQty.Text),
		            stock_finish = this.lstFinish.SelectedValue,
		            stock_weight = this.lstWeight.SelectedValue,
		            two_sided = this.chkTwoSide.Checked,
		            folded = this.chkfolded.Checked,
		            ship= this.chkShip.Checked
                };

                orderRepository.AddOrder(orderCreate);
                orderRepository.SubmitChanges();

                this.lblNotify.Text = "Order Created Sucessfull!  with ID :"+ orderCreate.orderID;
                this.lblNotify.ForeColor = System.Drawing.Color.Blue;
                this.lblNotify.Visible = true;
                func_clearFields(false);
            }
        }

        private void func_clearFields(bool notify)
        {
            if(notify)
                this.lblNotify.Visible = false;
            this.txtJobName.Text = "";
            this.txtFinalSizeX.Text = "";
            this.txtFinalSizeY.Text = "";
            this.txtQty.Text = "";
            this.chkTwoSide.Checked = false;
            this.chkfolded.Checked = false;
            this.chkShip.Checked = false;
        }

        private int getOrderID()
        {
            int iRet = 0;

            IOrderRepository orderRepo = RepositoryFactory.Get<IOrderRepository>();

            var max_query = (from order in orderRepo.Orders
                             select order.orderID).Max();

            iRet = max_query + 1;
            return 100;
        }

        private int getUserID()
        {
            return 1007;
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
            }catch (FormatException)
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
