using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Alura.LeilaoOnline.Selenium.Helpers;
using Xunit;
using Alura.LeilaoOnline.Selenium.PageObjects;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    public class AoNavegarParaHomeMobile: IDisposable
    {
        private ChromeDriver _driver;
          
        [Fact]
        public void DataLargura400DeveEntrarNoModoMobile()
        {
            //Arrange

            /*Opções avançadas do chrome: Manipulando a configuração de exibição para mobile*/
            var deviceSettings = new ChromeMobileEmulationDeviceSettings();
            deviceSettings.Width = 400;
            deviceSettings.Height = 800;
            deviceSettings.UserAgent = "Customizada";
            var options = new ChromeOptions();
            options.EnableMobileEmulation(deviceSettings);
            _driver = new ChromeDriver(TestHelper.PastaDoExecutavel, options);


            //ACT
            var HomePO = new HomeNaoLogadaPO(_driver);
            HomePO.Visitar();


            //Assert
            Assert.True(HomePO.Menu.MenuMobileVisivel);

            
        }

        [Fact]
        public void DataLargura993NaoDeveEntrarNoModoMobile()
        {
            //Arrange
            /*Opções avançadas do chrome: Manipulando a configuração de exibição para mobile*/
            var deviceSettings = new ChromeMobileEmulationDeviceSettings();
            deviceSettings.Width = 993;
            deviceSettings.Height = 800;
            deviceSettings.UserAgent = "Customizada";
            var options = new ChromeOptions();
            options.EnableMobileEmulation(deviceSettings);
            _driver = new ChromeDriver(TestHelper.PastaDoExecutavel, options);

            //ACT
            var HomePO = new HomeNaoLogadaPO(_driver);
            HomePO.Visitar();


            //Assert
            Assert.False(HomePO.Menu.MenuMobileVisivel);
        }

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}
