using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace desafioFrontTest.Comandos
{
    public class AbrirNavegador
    {
        public static IWebDriver abrirNavegador()
        {
            IWebDriver driver;
            var firefoxOptions = new FirefoxOptions();
            firefoxOptions.PageLoadStrategy = PageLoadStrategy.Eager;
            driver = new FirefoxDriver(firefoxOptions);

            return driver;
        }
    }
}
