using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace desafioFrontTest.Comandos
{
    class ComandosNavegador
    {
        public static  IWebDriver abrirNavegador()
        {
            IWebDriver driver;
            var edgeOptinos = new EdgeOptions();
            edgeOptinos.PageLoadStrategy = PageLoadStrategy.Normal;
            edgeOptinos.AddArgument("headless");
            driver = new EdgeDriver(edgeOptinos);

            return driver;
        }
    }
}
