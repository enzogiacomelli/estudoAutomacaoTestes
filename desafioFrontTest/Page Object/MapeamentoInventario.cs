using NUnit.Framework;
using OpenQA.Selenium;


namespace desafioFrontTest.Page_Object
{
    class MapeamentoInventario
    {
        private IWebDriver _driver;

        public MapeamentoInventario(IWebDriver driver) => _driver = driver;


        public IWebElement addToCartBackpack => _driver.FindElement(By.Name("add-to-cart-sauce-labs-backpack"));
        public IWebElement addToCartBikelight => _driver.FindElement(By.Name("add-to-cart-sauce-labs-bike-light"));
        public IWebElement addToCartTshirt => _driver.FindElement(By.Name("add-to-cart-sauce-labs-bolt-t-shirt"));
        public IWebElement addToCartJacket => _driver.FindElement(By.Name("add-to-cart-sauce-labs-fleece-jacket"));
        public IWebElement addToCartOnesie => _driver.FindElement(By.Name("add-to-cart-sauce-labs-onesie"));
        public IWebElement addToCartTshirRed => _driver.FindElement(By.Name("add-to-cart-test.allthethings()-t-shirt-(red)"));
        public IWebElement shoppingCart => _driver.FindElement(By.Id("shopping_cart_container"));
        public IWebElement inventoryContainer => _driver.FindElement(By.Id("inventory_container"));
       


        public void VerificaElementosNaPagina()
        {
            Assert.IsTrue(inventoryContainer.Displayed);
            Assert.IsTrue(shoppingCart.Displayed);
        }

        public void AddToCart()//o valor total desta compra é 97.17
        {
            addToCartBackpack.Click();
            addToCartBikelight.Click();
            addToCartJacket.Click();
            shoppingCart.Click();
        }

        public void AddAllToCart()//o valor total desta compra é 140.34
        {
            addToCartBackpack.Click();
            addToCartBikelight.Click();
            addToCartTshirt.Click();
            addToCartJacket.Click();
            addToCartOnesie.Click();
            addToCartTshirRed.Click();
            shoppingCart.Click();
        }

    }
}
