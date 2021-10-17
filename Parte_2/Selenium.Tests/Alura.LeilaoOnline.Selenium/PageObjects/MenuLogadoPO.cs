using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class MenuLogadoPO
    {
        private IWebDriver _driver;
        private By _byLogoutLink;
        private By _meuPerfilLink;

        public MenuLogadoPO(IWebDriver driver)
        {
            _driver = driver;
            _byLogoutLink = By.Id("logout");
            _meuPerfilLink = By.Id("meu-perfil");
        }

        public void EfetuarLogout()
        {
            var linkMeuPerfil = _driver.FindElement(_meuPerfilLink);
            var linkLogout = _driver.FindElement(_byLogoutLink);

            //Cria Acao
            IAction acaoLogout = new Actions(_driver)
                //Mover mouse para o elemento pai
                .MoveToElement(linkMeuPerfil)
                //mover mouse para o link logout
                .MoveToElement(linkLogout)
                //clicar no link de logout
                .Click()
                .Build();

            //Executa ação criada
            acaoLogout.Perform();

        }
    }
}
