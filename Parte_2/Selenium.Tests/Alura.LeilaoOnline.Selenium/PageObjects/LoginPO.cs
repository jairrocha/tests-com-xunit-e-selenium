using OpenQA.Selenium;
using System;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class LoginPO
    {
        private IWebDriver _driver;
        private By byInputLogin;
        private By byInputSenha;
        private By byBotaoLogin;

        public LoginPO(IWebDriver driver)
        {
            this._driver = driver;
            byInputLogin = By.Id("Login");
            byInputSenha = By.Id("Password");
            byBotaoLogin = By.Id("btnLogin");
        }

        public LoginPO Visitar()
        {
            _driver.Navigate().GoToUrl("http://localhost:5000/Autenticacao/Login");
            return this;
        }

        public LoginPO PreencheFormulario(string login, string senha)
        {
            InformarEmail(login);
            InformarSenha(senha);
            return this;
        }

        public LoginPO EfetuarLogin()
        {
            return SubmeteFormulario();
        }

        public LoginPO InformarEmail(string login)
        {
            _driver.FindElement(byInputLogin).SendKeys(login);
            return this;
        }

        public LoginPO InformarSenha(string senha)
        {
            _driver.FindElement(byInputSenha).SendKeys(senha);
            return this;
        }

        public LoginPO SubmeteFormulario()
        {
            _driver.FindElement(byBotaoLogin).Submit();
            return this;
        }

        public LoginPO EfetuarLoginComCredenciais(string login, string senha)
        {
            Visitar()
                .PreencheFormulario(login, senha)
                .SubmeteFormulario();

            return this;
        }

    }
}
