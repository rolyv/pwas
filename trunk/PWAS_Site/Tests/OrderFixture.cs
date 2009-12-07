using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium;
using PWAS.DataAccess.Interfaces;
using PWAS.DataAccess.SQLRepositories;
using System.Threading;
using PWAS.Model;

namespace PWAS.Tests
{
    [TestFixture]
    public class OrderFixture
    {
        private ISelenium selenium;
        private StringBuilder verificationErrors;
        private IUserRepository userRepo;
        private IOrderRepository orderRepo;
        private IOrderHistoryRepository orderHistoryRepo;

        [TestFixtureSetUp]
        public void SetupTest()
        {
            selenium = new DefaultSelenium("localhost", 4444, "*chrome", "http://localhost:2641/");
            selenium.Start();
            userRepo = new UserRepository(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Documents and Settings\RolandoV\My Documents\PWAS\PWAS_Site\PWAS_Site\App_Data\PWAS_DB.mdf;Integrated Security=True;User Instance=True");
            orderRepo = new OrderRepository(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Documents and Settings\RolandoV\My Documents\PWAS\PWAS_Site\PWAS_Site\App_Data\PWAS_DB.mdf;Integrated Security=True;User Instance=True");
            orderHistoryRepo = new OrderHistoryRepository(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Documents and Settings\RolandoV\My Documents\PWAS\PWAS_Site\PWAS_Site\App_Data\PWAS_DB.mdf;Integrated Security=True;User Instance=True");           

            verificationErrors = new StringBuilder();

            if (orderRepo.Orders.Where(o => o.job_name == "Salsa Impulse").Count() > 0)
            {
                List<Order> orders = orderRepo.Orders.Where( o => o.job_name == "Salsa Impulse").ToList();
                List<OrderHistory> ohistories = (from oh in orderHistoryRepo.OrderHistories
                                                 where (from o in orders
                                                        select o.orderID).Contains(oh.orderId)
                                                 select oh).ToList();
                Table<OrderHistory> ohTable = (Table<OrderHistory>)orderHistoryRepo.OrderHistories;
                ohTable.DeleteAllOnSubmit(ohistories);

                Table<Order> orderTable = (Table<Order>)orderRepo.Orders;
                orderTable.DeleteAllOnSubmit(orders);

                ohTable.Context.SubmitChanges();
                orderTable.Context.SubmitChanges();
            }

            if (userRepo.Users.Where(u => u.email == "j1@gmail.com").Count() > 0)
            {
                User user = userRepo.Users.First(u => u.email.Trim() == "j1@gmail.com");
                userRepo.DeleteUser(user.userID);
                userRepo.SubmitChanges();
            }

            Thread.Sleep(2000);
        }

        [TestFixtureTearDown]
        public void TeardownTest()
        {
            try
            {
                selenium.Stop();

                List<Order> orders = orderRepo.Orders.Where(o => o.job_name == "Salsa Impulse").ToList();

                var histories = (from oh in orderHistoryRepo.OrderHistories
                                 where orders.Any(o => o.orderID == oh.orderId)
                                 select oh).ToList();
                
                Table<OrderHistory> ohTable = (Table<OrderHistory>)orderHistoryRepo.OrderHistories;
                ohTable.DeleteAllOnSubmit(histories);

                Table<Order> orderTable = (Table<Order>)orderRepo.Orders;
                orderTable.DeleteAllOnSubmit(orders);

                User user = userRepo.Users.First(u => u.email.Trim() == "j1@gmail.com");
                userRepo.DeleteUser(user.userID);
                userRepo.SubmitChanges();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void CreateOrder()
        {
            RegisterAndLogin();
            selenium.Open("/customerView_Home.aspx");
            selenium.WaitForPageToLoad("5000");
            selenium.Click("ctl00_navigation_menu_NavigationControl_NavTreeViewt0");
            selenium.WaitForPageToLoad("5000");
            selenium.Type("ctl00_body_content_txtJobName", "Salsa Impulse");
            selenium.Type("ctl00_body_content_txtFinalSizeX", "5");
            selenium.Type("ctl00_body_content_txtFinalSizeY", "5");
            selenium.Type("ctl00_body_content_txtQty", "1000");
            selenium.Select("ctl00_body_content_lstWeight", "label=Light");
            selenium.Check("ctl00_body_content_chkTwoSide");
            selenium.Type("ctl00_body_content_FileUpload", "C:\\Documents and Settings\\Javier\\Desktop\\Salsa Impulse\\SalsaImpulseBusinessCard.jpg");
            selenium.Click("ctl00_body_content_btnFileUpload");

            selenium.WaitForPageToLoad("5000");
            Assert.IsTrue(selenium.IsTextPresent("Uploaded File:"));
            Assert.IsTrue(selenium.IsTextPresent("SalsaImpulseBusinessCard.jpg"));

            selenium.Click("ctl00_body_content_createPay");
            selenium.WaitForPageToLoad("5000");

            int count = orderRepo.Orders.Where(o => o.job_name == "Salsa Impulse").Count();
            Assert.AreEqual(1, count);

            Order order = orderRepo.Orders.Where(o => o.job_name == "Salsa Impulse").Single();
            Assert.AreEqual("Salsa Impulse", order.job_name.Trim());
            Assert.AreEqual(5.0, order.width);
            Assert.AreEqual(5.0, order.height);
            Assert.AreEqual(1000, order.quantity);
            Assert.IsTrue(order.two_sided);
        }

        private void RegisterAndLogin()
        {
            selenium.Open("/index.aspx");
            selenium.WaitForPageToLoad("5000");
            selenium.Click("link=Login");
            selenium.WaitForPageToLoad("5000");
            selenium.Click("link=Register");
            selenium.WaitForPageToLoad("5000");
            selenium.Type("ctl00_body_content_txtEmailAddress", "j1@gmail.com");
            selenium.Type("ctl00_body_content_txtPassword", "12345");
            selenium.Type("ctl00_body_content_txtPasswordConfirm", "12345");
            selenium.Type("ctl00_body_content_txtFirstName", "Javier");
            selenium.Type("ctl00_body_content_txtLastName", "Mesa");
            selenium.Type("ctl00_body_content_txtCompanyName", "XYZ Printing");
            selenium.Type("ctl00_body_content_txtPhoneNumber", "7862986707");
            selenium.Type("ctl00_body_content_txtBillAddressLine1", "2601 W 2nd Ave");
            selenium.Type("ctl00_body_content_txtBillCity", "Hialeah");
            selenium.Type("ctl00_body_content_txtBillState", "FL");
            selenium.Type("ctl00_body_content_txtBillZipCode", "33010");
            selenium.Click("ctl00_body_content_btnRegister");
            selenium.WaitForPageToLoad("5000");

            selenium.Open("/index.aspx");
            selenium.WaitForPageToLoad("5000");
            selenium.Click("link=Login");
            selenium.WaitForPageToLoad("5000");
            selenium.Type("ctl00_body_content_loginEmail", "j1@gmail.com");
            selenium.Type("ctl00_body_content_pwd", "12345");
            selenium.Click("ctl00_body_content_loginSubmit");
            selenium.WaitForPageToLoad("5000");
        }

        [Test]
        public void ManageOrders()
        {
            //CreateOrder();
            selenium.Click("ctl00_navigation_menu_NavigationControl_NavTreeViewt1");
            selenium.WaitForPageToLoad("5000");

            int orderId = orderRepo.Orders.Single(o => o.job_name.Contains("Salsa Impulse")).orderID;

            Assert.IsTrue(selenium.IsTextPresent("Salsa Impulse"));
            Assert.IsTrue(selenium.IsElementPresent("ctl00_body_content_" + orderId + "s"));

            selenium.Click("ctl00_body_content_" + orderId + "s");
            Thread.Sleep(2000);
            Assert.AreEqual(2, orderRepo.Orders.Single(o => o.job_name.Contains("Salsa Impulse")).currentStatus);
            
            selenium.Click("ctl00_body_content_" + orderId + "v");
            selenium.Click("ctl00_body_content_OkviewOrder");
            selenium.Click("ctl00_logoutLnk");
        }
    }
}
