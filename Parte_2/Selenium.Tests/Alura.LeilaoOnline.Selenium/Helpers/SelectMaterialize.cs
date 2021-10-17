using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.Helpers
{
    class SelectMaterialize
    {
        private IWebDriver _driver;
        private IWebElement _selectWrapper;
        private IEnumerable<IWebElement> _opcoes;

        public SelectMaterialize(IWebDriver driver, By LocatorSelectWraper)
        {
            _driver = driver;
            _selectWrapper = _driver.FindElement(LocatorSelectWraper);
            _opcoes = _selectWrapper.FindElements(By.CssSelector("li>span"));
        }
        public IEnumerable<IWebElement> Options => _opcoes;

        private void OpenWrapper()
        {
            _selectWrapper.Click();
            
        }

        public void SelecByText(string option)
        {
            Thread.Sleep(2000);
            OpenWrapper();

            _opcoes
                .Where(o => o.Text.Contains(option))
                .ToList()
                .ForEach(o =>
                {
                    o.Click();
                });

            LoseFocus();
        }

   
        public void DeselecAll()
        {

            OpenWrapper();
            _opcoes.ToList().ForEach(o =>
            {
                o.Click();
            });

            LoseFocus();
        }

        private void LoseFocus()
        {
            Thread.Sleep(1000);
            _selectWrapper
                .FindElement(By.TagName("li"))
                .SendKeys(Keys.Tab);
        }
    }
}
