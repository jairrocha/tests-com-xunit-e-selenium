

using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {

        private readonly IWebDriver _driver;

        public AoEfetuarRegistro(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }
        
        [Theory]
        [InlineData("Agradecimento","Jair","jairmsn@hotmail.com","123","123")]
        public void Teste(string UrlEsperada, string nome, string email, string senha, string confirmacao_senha)
        {
            //Arranje - Dado Chrome aberto, dado registros informados
            _driver.Navigate().GoToUrl("http://localhost:5000");

            
            _driver.FindElement(By.Id("Nome")).SendKeys(nome);
            _driver.FindElement(By.Id("Email")).SendKeys(email);
            _driver.FindElement(By.Id("Password")).SendKeys(senha);
            _driver.FindElement(By.Id("ConfirmPassword")).SendKeys(confirmacao_senha);

            //ACT - Quando eu efetuo o registro
            _driver.FindElement(By.Id("btnRegistro")).Click();

            //Assert - Devo ser direcionado para página de agradecimento
            Assert.Contains(UrlEsperada, _driver.Url);
        }

        [Theory]
        [InlineData("Registre-se para participar dos leilões!", "", "jairmsn@hotmail.com", "123", "123")]
        [InlineData("Registre-se para participar dos leilões!", "Jair", "", "123", "123")]
        [InlineData("Registre-se para participar dos leilões!", "Jair", "jairmsn@hotmail.com", "", "123")]
        [InlineData("Registre-se para participar dos leilões!", "Jair", "jairmsn@hotmail.com", "123", "")]
        [InlineData("Registre-se para participar dos leilões!", "Jair", "jairmsnhotmail.com", "123", "123")]
        [InlineData("Registre-se para participar dos leilões!", "Jair", "jairmsn@hotmail.com", "124", "123")]
        [InlineData("Registre-se para participar dos leilões!", "", "", "", "")]
        public void DadoInfoInvalidasDeveContinuarNaHome(string txtEsperado, string nome, string email, string senha, string confirmacao_senha)
        {
            //Arranje - Dado Chrome aberto, dado registros informados
            _driver.Navigate().GoToUrl("http://localhost:5000");


            _driver.FindElement(By.Id("Nome")).SendKeys(nome);
            _driver.FindElement(By.Id("Email")).SendKeys(email);
            _driver.FindElement(By.Id("Password")).SendKeys(senha);
            _driver.FindElement(By.Id("ConfirmPassword")).SendKeys(confirmacao_senha);

            //ACT - Quando eu efetuo o registro
            _driver.FindElement(By.Id("btnRegistro")).Click();

            //Assert - Devo ser direcionado para página de agradecimento
            Assert.Contains(txtEsperado, _driver.PageSource);
        }

        [Fact]
        public void DadoCampoNomeVazioExibirMsg()
        {
            //Arranje - Dado Chrome aberto, dado registros informados
            _driver.Navigate().GoToUrl("http://localhost:5000");


            _driver.FindElement(By.Id("Nome")).SendKeys("");
            _driver.FindElement(By.Id("Email")).SendKeys("jairmsn@hotmail.com");
            _driver.FindElement(By.Id("Password")).SendKeys("123");
            _driver.FindElement(By.Id("ConfirmPassword")).SendKeys("123");

            //ACT - Quando eu efetuo o registro
            _driver.FindElement(By.Id("btnRegistro")).Click();

            //Assert - Devo ser direcionado para página de agradecimento
            IWebElement elemento = _driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Nome]"));
            Assert.Contains("Nome", elemento.Text);
   
        }

        [Fact]
        public void DadoCampoEmailInvalidoExibirMsg()
        {
            //Arranje - Dado Chrome aberto, dado registros informados
            var registroPO = new RegistroPO(_driver);

            registroPO.Visitar();

            registroPO.PreencheFormulario("Jair", "jairmsnhotmail.com", "123", "123");

            //ACT - Quando eu efetuo o registro
            registroPO.SubmeteFormulario();

            //Assert - Devo ser direcionado para página de agradecimento
            Assert.Contains("mail", registroPO.MenssageErro);

        }
    }
}
