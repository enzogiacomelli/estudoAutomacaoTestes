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
            firefoxOptions.PageLoadStrategy = PageLoadStrategy.Normal;
            firefoxOptions.AddArgument("--headless");
            driver = new FirefoxDriver(firefoxOptions);

            return driver;
        }
    }
}
