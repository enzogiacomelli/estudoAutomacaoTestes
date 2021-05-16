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
using OpenQA.Selenium.Remote;





namespace desafioFrontTest
{
    public class Tests
    {
        private RemoteWebDriver driver;
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

            MapeamentoLogin login = new MapeamentoLogin(driver);

            login.verificaElementosNaPagina();
            
            login.username.SendKeys("locked_out_user");
            login.password.SendKeys("secret_sauce");
            login.loginBtn.Click();
            Assert.IsTrue(login.alertaErro.Text.Contains("Epic sadface: Sorry, this user has been locked out."));
            Console.WriteLine(login.alertaErro.Text);
        }
    }
}