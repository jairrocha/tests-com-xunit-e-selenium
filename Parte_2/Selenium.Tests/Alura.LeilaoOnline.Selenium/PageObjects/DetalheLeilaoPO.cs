using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DetalheLeilaoPO
    {
        private IWebDriver _driver;
        private By _inputValor;
        private By _btnDarLance;
        private By _inputLanceAtual;

        public double LanceAtual 
        { 
            get 
            {
                var valorTexto = _driver.FindElement(_inputLanceAtual).Text;
                var valor = double.Parse(valorTexto, System.Globalization.NumberStyles.Currency);
                return valor;
            }
        }

        public DetalheLeilaoPO(IWebDriver driver)
        {
            _driver = driver;
            _inputValor = By.Id("Valor");
            _btnDarLance = By.Id("btnDarLance");
            _inputLanceAtual = By.Id("lanceAtual");
        }

        public void Visitar(int idLeilao)
        {
            _driver.Navigate().GoToUrl($"http://localhost:5000/Home/Detalhes/{idLeilao}");
        }

        public void EfetuarLance(double valor)
        {
            _driver.FindElement(_inputValor).Clear();
            _driver.FindElement(_inputValor).SendKeys(valor.ToString());
            _driver.FindElement(_btnDarLance).Submit();

            //Aguarda valor ser igual por até 8 segundos
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(8));
            wait.Until(drive => LanceAtual == valor);
        }
        

    }
}
