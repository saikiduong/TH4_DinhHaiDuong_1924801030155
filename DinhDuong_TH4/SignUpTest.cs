using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhDuong_TH4
{
    [TestFixture]
    public class SignUpTest
    {
        private IWebDriver driver;
        private string baseURL;
        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "http://automationpractice.com";
        }
        [TearDown]
        public void TeardownTest()
        {
            driver.Quit();
        }
        [Test]
        public void TC_Register_01()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email_create")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("dinhhaiduongsaki@gmail.com");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            string checkedd = "An account using this email address has already been registered. Please enter a valid password or request a new one.";
            if ((driver.FindElement(By.CssSelector("#create_account_error ol li")).Text).Equals(checkedd)) { return; }
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("duong");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("dinh");
            driver.FindElement(By.Id("passwd")).SendKeys("123456");
            driver.FindElement(By.Id("days")).SendKeys("11");
            driver.FindElement(By.Id("months")).SendKeys("August");
            driver.FindElement(By.Id("years")).SendKeys("2001");
            driver.FindElement(By.Id("address1")).SendKeys("Binh Duong");
            driver.FindElement(By.Id("city")).SendKeys("Binh Duong");
            driver.FindElement(By.Id("id_state")).SendKeys("New York");
            driver.FindElement(By.Id("postcode")).SendKeys("12346");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("0123456");
            driver.FindElement(By.Id("submitAccount")).Click();
            Assert.AreEqual("Sign out", driver.FindElement(By.LinkText("Sign out")).Text);
            Assert.AreEqual("duong dinh", driver.FindElement(By.LinkText("duong dinh")).Text);
        }
        [Test]
        public void TC_Register_02()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email_create")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            Assert.AreEqual("Email is required.", driver.FindElement(By.CssSelector("#create_account_error ol li")).Text);
        }
        [Test]
        public void TC_Register_03()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email_create")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("dinhhaiduongsaki.com");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            Assert.AreEqual("Invalid email address.", driver.FindElement(By.CssSelector("#create_account_error ol li")).Text);
        }
        [Test]
        public void TC_Register_04()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email_create")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("dinhhaiduongsoma@gmail.com");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            Assert.AreEqual("An account using this email address has already been registered. Please enter a valid password or request a new one.", driver.FindElement(By.CssSelector("#create_account_error ol li")).Text);
        }
        [Test]
        public void TC_Register_05()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email_create")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("1924801030155@student.tdmu.edu.vn");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("duong");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("");
            driver.FindElement(By.Id("passwd")).SendKeys("123456");
            driver.FindElement(By.Id("days")).SendKeys("11");
            driver.FindElement(By.Id("months")).SendKeys("August");
            driver.FindElement(By.Id("years")).SendKeys("2001");
            driver.FindElement(By.Id("address1")).SendKeys("Binh Duong");
            driver.FindElement(By.Id("city")).SendKeys("Binh Duong");
            driver.FindElement(By.Id("id_state")).SendKeys("New York");
            driver.FindElement(By.Id("postcode")).SendKeys("12345");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("012345");
            driver.FindElement(By.Id("submitAccount")).Click();
            Assert.AreEqual("Last name is required.", driver.FindElement(By.CssSelector("#center_column div ol li")).Text);
        }
        [Test]
        public void TC_Register_06()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email_create")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("1924801030155@student.tdmu.edu.vn");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("saiki");
            driver.FindElement(By.Id("passwd")).SendKeys("123456");
            driver.FindElement(By.Id("days")).SendKeys("11");
            driver.FindElement(By.Id("months")).SendKeys("August");
            driver.FindElement(By.Id("years")).SendKeys("2001");
            driver.FindElement(By.Id("address1")).SendKeys("Binh Duong");
            driver.FindElement(By.Id("city")).SendKeys("Binh Duong");
            driver.FindElement(By.Id("id_state")).SendKeys("New York");
            driver.FindElement(By.Id("postcode")).SendKeys("12345");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("012345");
            driver.FindElement(By.Id("submitAccount")).Click();
            Assert.AreEqual("First name is required.", driver.FindElement(By.CssSelector("#center_column div ol li")).Text);
        }
        [Test]
        public void TC_Register_07()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email_create")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("1924801030155@student.tdmu.edu.vn");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("duong");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("saiki");
            driver.FindElement(By.Id("passwd")).SendKeys("1234");
            driver.FindElement(By.Id("days")).SendKeys("11");
            driver.FindElement(By.Id("months")).SendKeys("August");
            driver.FindElement(By.Id("years")).SendKeys("2001");
            driver.FindElement(By.Id("address1")).SendKeys("Binh Duong");
            driver.FindElement(By.Id("city")).SendKeys("Binh Duong");
            driver.FindElement(By.Id("id_state")).SendKeys("New York");
            driver.FindElement(By.Id("postcode")).SendKeys("12345");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("012345");
            driver.FindElement(By.Id("submitAccount")).Click();
            Assert.AreEqual("Password less than 5 digits.", driver.FindElement(By.CssSelector("#center_column div ol li")).Text);
        }
        [Test]
        public void TC_Register_08()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email_create")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("1924801030155@student.tdmu.edu.vn");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("duong");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("saiki");
            driver.FindElement(By.Id("passwd")).SendKeys("123456");
            driver.FindElement(By.Id("days")).SendKeys("11");
            driver.FindElement(By.Id("months")).SendKeys("August");
            driver.FindElement(By.Id("years")).SendKeys("2001");
            driver.FindElement(By.Id("address1")).SendKeys("");
            driver.FindElement(By.Id("city")).SendKeys("Binh Duong");
            driver.FindElement(By.Id("id_state")).SendKeys("New York");
            driver.FindElement(By.Id("postcode")).SendKeys("12345");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("012345");
            driver.FindElement(By.Id("submitAccount")).Click();
            Assert.AreEqual("Address is required.", driver.FindElement(By.CssSelector("#center_column div ol li")).Text);
        }
        [Test]
        public void TC_Register_09()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email_create")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("1924801030155@student.tdmu.edu.vn");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("duong");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("saiki");
            driver.FindElement(By.Id("passwd")).SendKeys("123456");
            driver.FindElement(By.Id("days")).SendKeys("11");
            driver.FindElement(By.Id("months")).SendKeys("August");
            driver.FindElement(By.Id("years")).SendKeys("2001");
            driver.FindElement(By.Id("address1")).SendKeys("Binh Duong");
            driver.FindElement(By.Id("city")).SendKeys("");
            driver.FindElement(By.Id("id_state")).SendKeys("New York");
            driver.FindElement(By.Id("postcode")).SendKeys("12345");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("012345");
            driver.FindElement(By.Id("submitAccount")).Click();
            Assert.AreEqual("city is required.", driver.FindElement(By.CssSelector("#center_column div ol li")).Text);
        }
        [Test]
        public void TC_Register_10()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email_create")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("1924801030155@student.tdmu.edu.vn");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("duong");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("saiki");
            driver.FindElement(By.Id("passwd")).SendKeys("123456");
            driver.FindElement(By.Id("days")).SendKeys("11");
            driver.FindElement(By.Id("months")).SendKeys("August");
            driver.FindElement(By.Id("years")).SendKeys("2001");
            driver.FindElement(By.Id("address1")).SendKeys("Binh Duong");
            driver.FindElement(By.Id("city")).SendKeys("Binh Duong");
            driver.FindElement(By.Id("id_state")).SendKeys("");
            driver.FindElement(By.Id("postcode")).SendKeys("12345");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("012345");
            driver.FindElement(By.Id("submitAccount")).Click();
            Assert.AreEqual("State is required.", driver.FindElement(By.CssSelector("#center_column div ol li")).Text);
        }
        [Test]
        public void TC_Register_11()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email_create")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("1924801030155@student.tdmu.edu.vn");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("duong");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("saiki");
            driver.FindElement(By.Id("passwd")).SendKeys("123456");
            driver.FindElement(By.Id("days")).SendKeys("11");
            driver.FindElement(By.Id("months")).SendKeys("August");
            driver.FindElement(By.Id("years")).SendKeys("2001");
            driver.FindElement(By.Id("address1")).SendKeys("Binh Duong");
            driver.FindElement(By.Id("city")).SendKeys("Binh Duong");
            driver.FindElement(By.Id("id_state")).SendKeys("New York");
            driver.FindElement(By.Id("postcode")).SendKeys("");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("012345");
            driver.FindElement(By.Id("submitAccount")).Click();
            Assert.AreEqual("The Zip/Postal code you've entered is invalid. It must follow this format: 00000", driver.FindElement(By.CssSelector("#center_column div ol li")).Text);
        }

        //[TestCase]
        //public void TC_Login_01()
        //{
        //    driver.Navigate().GoToUrl(baseURL + "/index.php");
        //    driver.FindElement(By.LinkText("Sign in")).Click();
        //    driver.FindElement(By.Id("email")).Click();
        //    driver.FindElement(By.Id("email")).SendKeys("dinhhaiduongsoma@gmail.com");
        //    driver.FindElement(By.Id("passwd")).Click();
        //    driver.FindElement(By.Id("passwd")).SendKeys("123456");
        //    driver.FindElement(By.CssSelector("#login_form .submit")).Click();
        //    driver.FindElement(By.CssSelector("#SubmitLogin > span")).Click();
        //    Assert.AreEqual("Sign out", driver.FindElement(By.LinkText("Sign out")).Text);
        //}
    }
}
