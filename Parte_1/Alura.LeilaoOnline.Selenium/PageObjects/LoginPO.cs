using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    class LoginPO
    {
        private readonly IWebDriver _driver;
        private readonly By _byInputLogin;
        private readonly By _byInputSenha;
        private readonly By _bybtnLogin;


        public LoginPO(IWebDriver driver)
        {
            _driver = driver;
            _byInputLogin = By.Id("Login");
            _byInputSenha = By.Id("Password");
            _bybtnLogin = By.Id("btnLogin");
        }


        public void Visitar()
        {
            _driver.Navigate().GoToUrl("http://localhost:5000/Autenticacao/Login");
        }

        public void PrecherFormulario(string login, string senha)
        {
            _driver.FindElement(_byInputLogin).SendKeys(login);
            _driver.FindElement(_byInputSenha).SendKeys(senha);

        }
        public void SubmeterFormulario()
        {
            _driver.FindElement(_bybtnLogin).Click();
        }

    }
}
