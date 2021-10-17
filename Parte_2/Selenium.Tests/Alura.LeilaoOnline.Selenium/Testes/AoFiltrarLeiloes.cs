using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    [Collection("Chrome Driver")]
    public class AoFiltrarLeiloes
    {
        private IWebDriver _driver;

        public AoFiltrarLeiloes(TestFixture fixtue)
        {
            _driver = fixtue.Driver;
        }

        [Fact]
        public void DadoLoginInteressadoDeveMostrarPainelResultado()
        {
            //Arrange
            new LoginPO(_driver)
                .EfetuarLoginComCredenciais("fulano@example.org", "123");
  
            var dashboardInteressadoPO = new DashboardInterassadaPO(_driver);

            //ACT
            dashboardInteressadoPO.Filtro.PesquisarLeiloes(new List<string> { "Arte", "Coleções"}, "", true);

            //Assert
            Assert.Contains("Resultado da pesquisa", _driver.PageSource);

        }
    }
}
