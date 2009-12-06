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
    public class LoginFixture
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
        public void LoginTest()
        {
            selenium.Open("/index.aspx");
            selenium.Click("link=Login");
            selenium.WaitForPageToLoad("10");
            selenium.Type("loginEmail", "j1@gmail.com");
            selenium.Type("pwd", "12345");
            selenium.Click("loginSubmit");
            selenium.WaitForPageToLoad("10");

            Assert.IsTrue(selenium.IsTextPresent("Welcome back Javier"));
        }

    }
}