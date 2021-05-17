using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;


namespace desafioFrontTest.Page_Object
{
    class MapeamentoCarrinho
    {
        private RemoteWebDriver _driver;

        public MapeamentoCarrinho(RemoteWebDriver driver) => _driver = driver;

        public IWebElement checkoutBtn => _driver.FindElement(By.Name("checkout"));
        public IWebElement continueshoppingBtn => _driver.FindElement(By.Name("continue-shopping"));
        public IWebElement removeBikelightBtn => _driver.FindElement(By.Name("remove-sauce-labs-bike-light"));
        public IWebElement removeBackpackBtn => _driver.FindElement(By.Name("remove-sauce-labs-backpack"));


        public void VerificaElementosNaPagina()
        {
            Assert.IsTrue(checkoutBtn.Displayed);
            Assert.IsTrue(continueshoppingBtn.Displayed);
            Assert.IsTrue(removeBikelightBtn.Displayed);
            Assert.IsTrue(removeBackpackBtn.Displayed);
        }

        public void CheckoutClick()
        {
            checkoutBtn.Click();
        }
    }
}
