using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class RegistroPO
    {
        private IWebDriver _driver;
        private By _byFormRegistro;
        private By _byInputNome;
        private By _byInputEmail;
        private By _byInputSenha;
        private By _byInputCofirmSenha;
        private By _byBotaoRegistro;
        private By _spanErroEmail;

        public string MenssageErro =>
                            _driver.FindElement(_spanErroEmail).Text;

        public RegistroPO(IWebDriver driver)
        {
            _driver = driver;
            _byFormRegistro = By.TagName("form");
            _byInputNome = By.Id("Nome");
            _byInputEmail = By.Id("Email");
            _byInputSenha = By.Id("Password");
            _byInputCofirmSenha = By.Id("ConfirmPassword");
            _byBotaoRegistro = By.Id("btnRegistro");
            _spanErroEmail = By.CssSelector("span.msg-erro[data-valmsg-for=Email]");

        }



        public void Visitar()
        {
            _driver.Navigate().GoToUrl("http://localhost:5000");
        }

        public void SubmeteFormulario()
        {
            _driver.FindElement(_byBotaoRegistro).Click();
        }

        public void PreencheFormulario(string nome, string email, string senha, string confirmacaoSenha)
        {
            _driver.FindElement(_byInputNome).SendKeys(nome);
            _driver.FindElement(_byInputEmail).SendKeys(email);
            _driver.FindElement(_byInputSenha).SendKeys(senha);
            _driver.FindElement(_byInputCofirmSenha).SendKeys(confirmacaoSenha);

        }
    }
}
