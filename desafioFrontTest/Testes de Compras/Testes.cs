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
        Usuarios user;
        MapeamentoLogin login;
        MapeamentoInventario inventario;
        MapeamentoCheckout checkout;
        MapeamentoCarrinho carrinho;
        Compras compra;

        [SetUp]
        public void Setup()
        {
            driver = Comandos.ComandosNavegador.abrirNavegador();
            user = new Usuarios().usuarioCorreto();
            login = new MapeamentoLogin(driver);
            inventario = new MapeamentoInventario(driver);
            checkout = new MapeamentoCheckout(driver);
            carrinho = new MapeamentoCarrinho(driver);
            compra = new Compras();
        }

        [Test]
        public void compraParcial()
        {
            driver.Navigate().GoToUrl(url);

            login.VerificaElementosNaPagina();
            login.LogIn(user);

            inventario.VerificaElementosNaPagina();
            inventario.AddToCart();

            carrinho.VerificaElementosNaPagina();
            carrinho.CheckoutClick();

            checkout.VerificaElementosNaPagina();
            
            checkout.PreencheCheckout(compra.vendaParcial());
            checkout.VerificaCompra(compra.vendaParcial());
        }

        [Test]
        public void compraCompleta()
        {
            driver.Navigate().GoToUrl(url);

            login.VerificaElementosNaPagina();
            login.LogIn(user);

            inventario.VerificaElementosNaPagina();
            inventario.AddAllToCart();

            carrinho.VerificaElementosNaPagina();
            carrinho.CheckoutClick();

            checkout.VerificaElementosNaPagina();
            checkout.PreencheCheckout(compra.vendaCompleta());
            checkout.VerificaCompra(compra.vendaCompleta());
        }
    }
}
