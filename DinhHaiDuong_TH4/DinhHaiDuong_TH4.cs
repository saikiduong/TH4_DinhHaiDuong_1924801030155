using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhHaiDuong_TH4
{
    [TestFixture]
   public class DinhHaiDuong_TH4
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

        [TestCase]
        public void TC_Login_01()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).SendKeys("dinhhaiduongsoma@gmail.com");
            driver.FindElement(By.Id("passwd")).Click();
            driver.FindElement(By.Id("passwd")).SendKeys("123456");
            driver.FindElement(By.CssSelector("#login_form .submut")).Click();

            Assert.AreEqual("haha", driver.FindElement(By.CssSelector("ol > li")).Text);
        }
    }

}
