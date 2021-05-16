using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System.Configuration;
using desafioFrontTest.Page_Object;





namespace desafioFrontTest.Page_Object
{
    public class Tests
    {
        private IWebDriver driver;
        private string url = "https://www.saucedemo.com/";


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver("C:\\Users\\egiac\\Desktop");
        }

        [Test]
        public void loginBlocked()
        {
            driver.Navigate().GoToUrl(url);

            MapeamentoLogin login = new MapeamentoLogin();
            PageFactory.InitElements(driver, login);

            Assert.IsTrue(login.username.Displayed);
            Assert.IsTrue(login.password.Displayed);
            Assert.IsTrue(login.loginBtn.Displayed);
            
            login.username.SendKeys("locked_out_user");
            login.password.SendKeys("secret_sauce");
            login.loginBtn.Click();
            Assert.Pass();
        }
    }
}