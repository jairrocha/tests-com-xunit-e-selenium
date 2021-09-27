using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogin
    {
        private IWebDriver _driver;

        public AoEfetuarLogin(TestFixture fixture)
        {
            _driver = fixture.Driver;

        }

        [Fact]
        public void DadoCredenciaisValidasDeveIrParaPaginaDashBoard()
        {

            //Arranje
            var loginPo = new LoginPO(_driver);
            loginPo.Visitar();
            loginPo.PrecherFormulario("jairmsn@hotmail.com", "123");

            //Act
            loginPo.SubmeterFormulario();

            //Assert
            Assert.Contains("Dashboard", _driver.Title);

        }

        [Fact]
        public void DadoCredenciaisInvalidasDeveContinuarNaPaginaDeLogin()
        {

            //Arranje
            var loginPo = new LoginPO(_driver);
            loginPo.Visitar();
            loginPo.PrecherFormulario("jairmsn@hotmail.com", "1253");

            //Act
            loginPo.SubmeterFormulario();

            //Assert
            Assert.Contains("Autenticacao", _driver.Url);

        }

    }
}
