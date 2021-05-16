using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Threading.Tasks;
using System.Linq;



namespace desafioFrontTest.Page_Object
{
    public class MapeamentoLogin
    {
        [FindsBy(How = How.Name, Using = "user-name")]
        public IWebElement username { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement password { get; set; }

        [FindsBy(How = How.Name, Using = "login-button")]
        public IWebElement loginBtn { get; set; }
    }
}
