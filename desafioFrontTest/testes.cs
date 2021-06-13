using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using desafioFrontTest.Page_Object;


namespace desafioFrontTest
{
    public class Tests
    {
        private string url = "https://www.saucedemo.com/";
        IWebDriver driver;


        [SetUp]
        public void Setup()
        {
            driver = Comandos.AbrirNavegador.abrirNavegador();
        }

        [Test]
        public void loginBlocked()
        {
            driver.Navigate().GoToUrl(url);

            MapeamentoLogin login = new MapeamentoLogin(driver);

            login.VerificaElementosNaPagina();
            login.LogIn("locked_out_user", "secret_sauce");

            Assert.IsTrue(login.alertaErro.Text.Contains("Epic sadface: Sorry, this user has been locked out."));
            Console.WriteLine(login.alertaErro.Text);
        }

        [Test]
        public void compraCompleta()
        {
            driver.Navigate().GoToUrl(url);
            MapeamentoLogin login = new MapeamentoLogin(driver);
            MapeamentoInventario inventario = new MapeamentoInventario(driver);
            MapeamentoCheckout checkout = new MapeamentoCheckout(driver);
            MapeamentoCarrinho carrinho = new MapeamentoCarrinho(driver);

            login.VerificaElementosNaPagina();
            login.LogIn("standard_user", "secret_sauce");

            inventario.VerificaElementosNaPagina();
            inventario.AddToCart();

            carrinho.VerificaElementosNaPagina();
            carrinho.CheckoutClick();

            checkout.VerificaElementosNaPagina();
            checkout.PreencheCheckout("Enzo", "Giacomelli", "987654321");
            checkout.VerificaCompra("Total: $97.17");
        }

        [Test]
        public void validarValorTotal()
        {
            driver.Navigate().GoToUrl(url);
            MapeamentoLogin login = new MapeamentoLogin(driver);
            MapeamentoInventario inventario = new MapeamentoInventario(driver);
            MapeamentoCheckout checkout = new MapeamentoCheckout(driver);
            MapeamentoCarrinho carrinho = new MapeamentoCarrinho(driver);

            login.VerificaElementosNaPagina();
            login.LogIn("standard_user", "secret_sauce");

            inventario.VerificaElementosNaPagina();
            inventario.AddAllToCart();

            carrinho.VerificaElementosNaPagina();
            carrinho.CheckoutClick();

            checkout.VerificaElementosNaPagina();
            checkout.PreencheCheckout("Enzo", "Giacomelli", "987654321");
            checkout.VerificaCompra("Total: $140.34");
        }
    }
}