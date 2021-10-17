using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    class NovoLeilaoPO
    {
        private readonly IWebDriver _driver;
        private By _byInputTitulo;
        private By _byInputDescricao;
        private By _byCssCbxCategoria;
        private By _byIdCbxCategoria;
        private By _byInputValorIncial;
        private By _byInputInicioPregao;
        private By _byInputFimPregao;
        private By _byInputImagem;
        private By _byButtonSalvar;
        

        public IEnumerable<string> Categorias 
        { 
            get
            {
                var elemetCategoria = new SelectElement(_driver.FindElement(_byIdCbxCategoria));
                return elemetCategoria
                            .Options
                            .Where(o=> o.Enabled)
                            .Select( o => o.Text);

            }
        
        }

        public NovoLeilaoPO(IWebDriver driver)
        {
            _driver = driver;
            _byInputTitulo = By.Id("Titulo");
            _byInputDescricao = By.Id("Descricao");
            _byCssCbxCategoria = By.CssSelector(".select-wrapper input.select-dropdown");
            _byIdCbxCategoria = By.Id("Categoria");
            _byInputValorIncial = By.Id("ValorInicial");
            _byInputInicioPregao = By.Id("InicioPregao");
            _byInputFimPregao = By.Id("TerminoPregao");
            _byInputImagem = By.Id("ArquivoImagem");
            _byButtonSalvar = By.CssSelector("button[type=submit]");

        }

        public void Visitar()
        {
            _driver.Navigate().GoToUrl("http://localhost:5000/Leiloes/Novo");
        }

        public void PreencheFormulario(
            string titulo,
            string descricao,
            string categoria,
            double valor,
            string imagem,
            DateTime inicio,
            DateTime termino
            )
        {
            _driver.FindElement(_byInputTitulo).SendKeys(titulo);
            _driver.FindElement(_byInputDescricao).SendKeys(descricao);

            /*Tentei usar o método do link abaixo no cbx, mas não funcionou
             *https://www.guru99.com/select-option-dropdown-selenium-webdriver.html 
             *
             *Método proposto na aula tbm não funcionou
             *_driver.FindElement(By.Id("Categoria")).SendKeys(categoria);
             */


            //Selecionar no cmbx (Á unica forma que deu certo)
            new Actions(_driver)
                .MoveToElement(_driver.FindElement(_byCssCbxCategoria))
                .Click()
                .Build()
                .Perform();
            new Actions(_driver)
                .MoveToElement(_driver.FindElement(_byCssCbxCategoria))
                .SendKeys(categoria)
                .SendKeys(Keys.Enter)
                .Build()
                .Perform();

            _driver.FindElement(_byInputValorIncial).SendKeys(valor.ToString());
            _driver.FindElement(_byInputInicioPregao).SendKeys(inicio.ToString("dd/MM/yyyy"));
            _driver.FindElement(_byInputFimPregao).SendKeys(termino.ToString("dd/MM/yyyy"));
            _driver.FindElement(_byInputImagem).SendKeys(imagem);
        }

        public void SubmeteFormulario()
        {
            _driver.FindElement(_byButtonSalvar).Submit();
        }
    }
}
