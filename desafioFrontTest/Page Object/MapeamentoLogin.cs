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






namespace desafioFrontTest.Page_Object
{
    public class MapeamentoLogin
    {
        private RemoteWebDriver _driver;

        public MapeamentoLogin(RemoteWebDriver driver) => _driver = driver;


        public IWebElement username => _driver.FindElement(By.Name("user-name"));
        public IWebElement password => _driver.FindElement(By.Name("password"));
        public IWebElement loginBtn => _driver.FindElement(By.Name("login-button"));
        public IWebElement alertaErro => _driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[1]/div[1]/div/form/div[3]/h3"));

        public void verificaElementosNaPagina()
        {
            Assert.IsTrue(username.Displayed);
            Assert.IsTrue(password.Displayed);
            Assert.IsTrue(loginBtn.Displayed);
        }
    }
}
