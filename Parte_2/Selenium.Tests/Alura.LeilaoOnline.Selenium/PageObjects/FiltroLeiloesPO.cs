
using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{


    public class FiltroLeiloesPO
    {
        private IWebDriver _driver;
        private By _bySelectCategorias;
        private By _byinputTermo;
        private By _byInputAdamento;
        private By _byBotaoPesquisar;

        public FiltroLeiloesPO(IWebDriver driver)
        {
            _driver = driver;
            _bySelectCategorias = By.ClassName("select-wrapper");
            _byinputTermo = By.Id("termo");
            _byInputAdamento = By.CssSelector(".switch span.lever");
            _byBotaoPesquisar = By.CssSelector("button.btn.waves-effect.waves-light");
        }

        public void PesquisarLeiloes(
            List<string> categorias,
            string termo,
            bool emAndamento)
        {

            var select = new SelectMaterialize(_driver, _bySelectCategorias);

            select.DeselecAll();

            categorias.ForEach(c =>
            {
                select.SelecByText(c);
            });

            _driver.FindElement(_byinputTermo).SendKeys(termo);

            if (emAndamento)
            {
                _driver.FindElement(_byInputAdamento).Click();
            }

            _driver.FindElement(_byBotaoPesquisar).Submit();



        }
    }
}
