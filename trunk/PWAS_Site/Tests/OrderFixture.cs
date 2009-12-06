using System;
using System.Collections.Generic;
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

        [SetUp]
        public void SetupTest()
        {
            selenium = new DefaultSelenium("localhost", 4444, "*chrome", "http://localhost:2641/");
            selenium.Start();
            userRepo = new UserRepository(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Documents and Settings\RolandoV\My Documents\PWAS\PWAS_Site\PWAS_Site\App_Data\PWAS_DB.mdf;Integrated Security=True;User Instance=True");
            orderRepo = new OrderRepository(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Documents and Settings\RolandoV\My Documents\PWAS\PWAS_Site\PWAS_Site\App_Data\PWAS_DB.mdf;Integrated Security=True;User Instance=True");

            if (userRepo.Users.Where(u => u.email.Trim() == "j1@gmail.com").Count() != 1)
            {
                RegistrationFixture registration = new RegistrationFixture();
                registration.RegistrationTest();
            }

            LoginFixture login = new LoginFixture();
            login.LoginTest();
            
            verificationErrors = new StringBuilder();

            Thread.Sleep(10000);
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                selenium.Stop();

                Order order = orderRepo.Orders.First(o => o.job_name == "Salsa Impulse");
                orderRepo.DeleteOrder(order.orderID);
                orderRepo.SubmitChanges();

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
            selenium.Click("ctl00_navigation_menu_NavigationControl_NavTreeViewt0");
            selenium.WaitForPageToLoad("10");
            selenium.Type("ctl00_body_content_txtJobName", "Salsa Impulse");
            selenium.Type("ctl00_body_content_txtFinalSizeX", "5");
            selenium.Type("ctl00_body_content_txtFinalSizeY", "5");
            selenium.Type("ctl00_body_content_txtQty", "1000");
            selenium.Select("ctl00_body_content_lstWeight", "label=Light");
            selenium.Click("ctl00_body_content_chkTwoSide");
            selenium.Type("ctl00_body_content_FileUpload", "C:\\Documents and Settings\\Javier\\Desktop\\Salsa Impulse\\SalsaImpulseBusinessCard.jpg");
            selenium.Click("ctl00_body_content_btnFileUpload");

            selenium.WaitForPageToLoad("2");
            Assert.IsTrue(selenium.IsTextPresent("Uploaded File:"));
            Assert.IsTrue(selenium.IsTextPresent("SalsaImpulseBusinessCard.jpg"));

            selenium.Click("ctl00_body_content_createPay");
            selenium.WaitForPageToLoad("5");

            int count = orderRepo.Orders.Where(o => o.job_name == "Salsa Impulse").Count();
            Assert.AreEqual(1, count);

            Order order = orderRepo.Orders.Where(o => o.job_name == "Salsa Impulse").Single();
            Assert.AreEqual("Salsa Impulse", order.job_name.Trim());
            Assert.AreEqual(5.0, order.width);
            Assert.AreEqual(5.0, order.height);
            Assert.AreEqual(1000, order.quantity);
            Assert.IsTrue(selenium.IsChecked("ctl00_body_content_chkTwoSide"));
        }

        [Ignore]
        [Test]
        public void ManageOrders()
        {
            selenium.Click("ctl00_navigation_menu_NavigationControl_NavTreeViewt1");
            selenium.Click("ctl00_body_content_3s");
            selenium.Click("ctl00_body_content_3v");
            selenium.Click("ctl00_body_content_OkviewOrder");
            selenium.Click("ctl00_logoutLnk");
        }
    }
}
