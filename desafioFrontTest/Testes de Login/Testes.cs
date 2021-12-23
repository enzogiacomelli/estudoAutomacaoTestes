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
        MapeamentoLogin login;
        Usuarios user;

        [SetUp]
        public void Setup()
        {
            driver = Comandos.ComandosNavegador.abrirNavegador();
            login = new MapeamentoLogin(driver);
            user = new Usuarios();
        }

        [Test]
        public void loginBlocked()
        {
            driver.Navigate().GoToUrl(url);
            login.VerificaElementosNaPagina();
            login.LogIn(user.usuarioIncorreto());

            Assert.IsTrue(login.alertaErro.Text.Contains("Epic sadface: Sorry, this user has been locked out."));
            Console.WriteLine(login.alertaErro.Text);
        }

        [Test]
        public void loginSuccess()
        {
            driver.Navigate().GoToUrl(url);
            login.VerificaElementosNaPagina();
            login.LogIn(user.usuarioCorreto());

            Assert.IsTrue(driver.Url == "https://www.saucedemo.com/inventory.html");
            Assert.IsTrue(driver.Title == "Swag Labs");
            Console.WriteLine(driver.Url);
            Console.WriteLine(driver.Title);
        }
    }
}