using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Threading;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoCriarLeilao
    {
        private IWebDriver _driver;

        public AoCriarLeilao(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginAdminEInfoValidasDeveCadastrarLeilao()
        {
            //arranje
            var loginPO = new LoginPO(_driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("admin@example.org", "123");
            loginPO.SubmeteFormulario();

            var novoLeilaoPO = new NovoLeilaoPO(_driver);
            novoLeilaoPO.Visitar();
            novoLeilaoPO.PreencheFormulario(
                "Leilao Coleção 1",
                "Descrição",
                "Item de Colecionador",
                4000,
                @"C:\Users\jairm\Downloads\1.jpg",
                DateTime.Today.AddDays(20),
                DateTime.Today.AddDays(21)
                );

            //act
            novoLeilaoPO.SubmeteFormulario();

            //assert
            Assert.Contains("Leilões cadastrados no sistema", _driver.PageSource);
        }
    }
}
