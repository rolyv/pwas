using System;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using Selenium;
using PWAS_Site;
using PWAS.DataAccess;
using PWAS.Model;
using PWAS.DataAccess.SQLRepositories;
using PWAS.DataAccess.Interfaces;

namespace PWAS.Tests
{
    [TestFixture]
    public class RegistrationFixture
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

            if (userRepo.Users.Where(u => u.email.Trim() == "j1@gmail.com").Count() > 0)
            {
                User user = userRepo.Users.First(u => u.email.Trim() == "j1@gmail.com");
                userRepo.DeleteUser(user.userID);
                userRepo.SubmitChanges();
            }
            verificationErrors = new StringBuilder();
            Thread.Sleep(10000);
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                selenium.Stop();                

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
        public void RegistrationTest()
        {
            selenium.Open("/index.aspx");
            selenium.Click("link=Login");
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


            int count = userRepo.Users.Where(u => u.email.Trim() == "j1@gmail.com").Count();
            Assert.AreEqual(1, count);

            User newUser = userRepo.Users.Where(u => u.email.Trim() == "j1@gmail.com").Single();
            Assert.AreEqual("Javier", newUser.firstName.Trim());
            Assert.AreEqual("Mesa", newUser.lastName.Trim());
            Assert.AreEqual("82-7C-CB-0E-EA-8A-70-6C-4C-34-A1-68-91-F8-4E-7B", newUser.password.Trim());
            Assert.AreEqual("XYZ Printing", newUser.company.Trim());
            Assert.AreEqual("7862986707", newUser.homePhone.Trim());
            Assert.AreEqual("2601 W 2nd Ave", newUser.b_address1.Trim());
            Assert.AreEqual("Hialeah", newUser.b_city.Trim());
            Assert.AreEqual("FL", newUser.b_state.Trim());
            Assert.AreEqual("33010", newUser.b_zip.Trim());           
        }
    }
}