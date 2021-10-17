using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogout
    {
        private readonly IWebDriver _driver;

        public AoEfetuarLogout(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Theory]
        [InlineData("Próximos Leilões", "jairmsn@hotmail.com", "123")]
        public void DadoLoginValidoDeveIrParaHomeNaoLogada(string textoEsperado, string login, string senha)
        {
            //Arranje

            //Encadeando métodos na mesma chamada (Para funcionar precisa retornar a própria instância).
            //Observe o retono nos métodos encadeados: (Visitar, InformarEmail, InformarSenha, EfetuarLogin)
            new LoginPO(_driver)
                .Visitar()
                .InformarEmail(login)
                .InformarSenha(senha)
                .EfetuarLogin();
      
            //act - efeturar logout
            var dashboard = new DashboardInterassadaPO(_driver);
            dashboard.Menu.EfetuarLogout();

            //assert
            Assert.Contains(textoEsperado, _driver.PageSource);

        }
    }
}
