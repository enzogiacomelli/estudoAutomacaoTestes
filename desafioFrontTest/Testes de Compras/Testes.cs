using System;
using NUnit.Framework;
using OpenQA.Selenium;
using desafioFrontTest.Page_Object;
using desafioFrontTest.Testes_de_Login;

namespace desafioFrontTest.Testes_de_Compras
{
    class Testes
    {
        private IWebDriver driver;
        private string url = "https://www.saucedemo.com/";


        [SetUp]
        public void Setup()
        {
            driver = Comandos.ComandosNavegador.abrirNavegador();
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
            Usuarios user = new Usuarios().usuarioCorreto();
            login.LogIn(user);

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
            Usuarios user = new Usuarios().usuarioCorreto();
            login.LogIn(user);

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
