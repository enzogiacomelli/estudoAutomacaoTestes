using System;
using NUnit.Framework;
using OpenQA.Selenium;
using desafioFrontTest.Page_Object;



namespace desafioFrontTest.Testes_de_Login
{
    public class Testes
    {
        private IWebDriver driver;
        private string url = "https://www.saucedemo.com/";


        [SetUp]
        public void Setup()
        {
            driver = Comandos.ComandosNavegador.abrirNavegador();
        }

        [Test]
        public void loginBlocked()
        {
            driver.Navigate().GoToUrl(url);

            MapeamentoLogin login = new MapeamentoLogin(driver);

            login.VerificaElementosNaPagina();
            Usuarios user = new Usuarios().usuarioIncorreto();
            login.LogIn(user);

            Assert.IsTrue(login.alertaErro.Text.Contains("Epic sadface: Sorry, this user has been locked out."));
            Console.WriteLine(login.alertaErro.Text);
        }

        [Test]
        public void loginSuccess()
        {
            driver.Navigate().GoToUrl(url);

            MapeamentoLogin login = new MapeamentoLogin(driver);

            login.VerificaElementosNaPagina();
            Usuarios user = new Usuarios().usuarioCorreto();
            login.LogIn(user);

            Assert.IsTrue(driver.Url == "https://www.saucedemo.com/inventory.html");
            Assert.IsTrue(driver.Title == "Swag Labs");
            Console.WriteLine(driver.Url);
            Console.WriteLine(driver.Title);
        }

        //[Test]
        /*public void compraCompleta()
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
        }*/
    }
}