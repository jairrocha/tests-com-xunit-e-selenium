using Alura.LeilaoOnline.Selenium.Fixtures;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{


    [Collection("Chrome Driver")]
    public class AoNavegarParaHome
    {
        private readonly IWebDriver _driver;


        //Setup
        public AoNavegarParaHome(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
        {
            //arrange

            //act
            _driver.Navigate().GoToUrl("http://localhost:5000");

            //assert
            Assert.Contains("Leilões", _driver.Title);

        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            //arrange

            //act
            _driver.Navigate().GoToUrl("http://localhost:5000");

            //assert
            Assert.Contains("Próximos Leilões", _driver.PageSource);

        }
        [Fact]
        public void DadoChromeAbertoFormRegistroNaoDeveMostrarMsgDeErro()
        {
            //arrange

            //act
            _driver.Navigate().GoToUrl("http://localhost:5000");

            //assert
            var form = _driver.FindElement(By.TagName("form"));
            var spans = form.FindElements(By.TagName("span"));

            foreach (var span in spans)
            {
                Assert.True(string.IsNullOrEmpty(span.Text));
            }
            
        }


    }
}
