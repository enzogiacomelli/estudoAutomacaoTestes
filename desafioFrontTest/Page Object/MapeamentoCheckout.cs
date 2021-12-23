using System;
using NUnit.Framework;
using OpenQA.Selenium;
using desafioFrontTest.Testes_de_Compras;


namespace desafioFrontTest.Page_Object
{
    class MapeamentoCheckout
    {
        private IWebDriver _driver;

        public MapeamentoCheckout(IWebDriver driver) => _driver = driver;

        //checkout parte 1
        public IWebElement nomeCheckout => _driver.FindElement(By.Name("firstName"));
        public IWebElement sobrenomeCheckout => _driver.FindElement(By.Name("lastName"));
        public IWebElement postalCodeCheckout => _driver.FindElement(By.Name("postalCode"));
        public IWebElement continueCheckout => _driver.FindElement(By.Name("continue"));
        public IWebElement cancelCheckout => _driver.FindElement(By.Name("cancel"));

        //checkout parte 2
        public IWebElement finalizar => _driver.FindElement(By.Name("finish"));
        public IWebElement checkoutContainer => _driver.FindElement(By.Id("checkout_summary_container"));
        public IWebElement itemTotal => _driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div[2]/div[5]"));
        public IWebElement taxa => _driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div[2]/div[6]"));
        public IWebElement total => _driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div/div[2]/div[7]"));

        //checkout parte 3 - compra finalizada
        public IWebElement backHomeBtn => _driver.FindElement(By.Name("back-to-products"));
        



        public void VerificaElementosNaPagina()
        {
            Assert.IsTrue(nomeCheckout.Displayed);
            Assert.IsTrue(sobrenomeCheckout.Displayed);
            Assert.IsTrue(postalCodeCheckout.Displayed);
            Assert.IsTrue(continueCheckout.Displayed);
            Assert.IsTrue(cancelCheckout.Displayed);
        }
        public void PreencheCheckout(Compras compra)
        {
            nomeCheckout.SendKeys(compra.nome);
            sobrenomeCheckout.SendKeys(compra.sobrenome);
            postalCodeCheckout.SendKeys(compra.postalCode);
            continueCheckout.Click();
        }
        public void VerificaCompra(Compras compra)
        {
            Assert.IsTrue(finalizar.Displayed);
            Assert.IsTrue(checkoutContainer.Displayed);
            Assert.IsTrue(cancelCheckout.Displayed);
            Assert.IsTrue(itemTotal.Displayed);
            Assert.IsTrue(taxa.Displayed);
            Assert.IsTrue(total.Displayed);
            Console.WriteLine(total.Text);
            Assert.IsTrue(total.Text.Contains(compra.valorVenda));// valores das compras: 97.17 e 140.34
            finalizar.Click();
            Assert.IsTrue(backHomeBtn.Displayed);
        }
    }
}
