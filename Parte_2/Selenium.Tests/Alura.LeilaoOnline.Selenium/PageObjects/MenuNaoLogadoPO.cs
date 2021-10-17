using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class MenuNaoLogadoPO
    {
        private IWebDriver _driver;
        private By _byMenuMobile;

        public bool MenuMobileVisivel 
        {
            get
            {
                var elemento = _driver.FindElement(_byMenuMobile).Displayed;
                return elemento;
            }
        }

        public MenuNaoLogadoPO(IWebDriver driver)
        {
            _driver = driver;
            _byMenuMobile = By.ClassName("sidenav-trigger");
        }

        
    }
}