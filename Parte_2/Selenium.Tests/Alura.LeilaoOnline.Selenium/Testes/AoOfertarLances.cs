using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoOfertarLances
    {
        private IWebDriver _driver;


        public AoOfertarLances(TestFixture fixture)
        {
            _driver = fixture.Driver;
      

        }

        [Fact]
        public void DadoLoginInteressadaDeveAtualizarLanceAtual()
        {
            //Arrange
            new LoginPO(_driver)
                .EfetuarLoginComCredenciais("fulano@example.org", "123");
            
            var detalhePO = new DetalheLeilaoPO(_driver);
            detalhePO.Visitar(1);

            double lance = 7000;

            //Act
            detalhePO.EfetuarLance(lance);

            //Assert
            Assert.Equal(lance, detalhePO.LanceAtual);

        }
    }
}
