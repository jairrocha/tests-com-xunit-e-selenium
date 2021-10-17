using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardInterassadaPO
    {
        private readonly IWebDriver _driver;
        public FiltroLeiloesPO Filtro { get; }
        public MenuLogadoPO Menu { get; }

        public DashboardInterassadaPO(IWebDriver driver)
        {
            _driver = driver;
            Filtro = new FiltroLeiloesPO(_driver);
            Menu = new MenuLogadoPO(_driver);
        }

    }
}
