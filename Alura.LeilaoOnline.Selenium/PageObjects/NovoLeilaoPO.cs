using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class NovoLeilaoPO
    {
        private IWebDriver driver;

        //Elementos do formulario.
        private By byInputTitulo;
        private By byInputDescricao;
        private By byInputCategoria;
        private By byInputValorInicial;
        private By byInputImagem;
        private By byInputInicioPregao;
        private By byInputTerminoPregao;
        private By byBotaoSalvar;

        public NovoLeilaoPO(IWebDriver driver)
        {
            this.driver = driver;
            //Licalizador dos elementos do formulario.
            byInputTitulo = By.Id("Titulo");
            byInputDescricao = By.Id("Descricao");
            byInputCategoria = By.Id("Categoria");
            byInputValorInicial = By.Id("ValorInicial");
            byInputImagem = By.Id("ArquivoImagem");
            byInputInicioPregao = By.Id("InicioPregao");
            byInputTerminoPregao = By.Id("TerminoPregao");
            byBotaoSalvar = By.CssSelector("button [type=submit]");
        }

        public IEnumerable<string> Categorias //Usa o pacote "Support" para validar as opções dentro de categoria.
        {
            get
            {
                var elementoCategoria = new SelectElement(driver.FindElement(byInputCategoria)); // Define uma classe validadora do campo Categoria.
                //elementoCategoria.FindElements(By.TagName("option"));
                return elementoCategoria.Options
                    .Where(o => o.Enabled) // Define como validação apenas elementos html ativos.
                    .Select(o => o.Text); // Define como selação dos elementos de texto.
            }
        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("https://localhost:5000/Leloes/Novo");
        }

        public void PreencherFormulario(
            string titulo, // Nome do leilão.
            string descricao, // Descrição do Leilão.
            string categoria, // Categoria do Leilão.
            double valor,   // Valor do Leilão.
            string imagem,  // Caminho da imagem, no caso local.
            DateTime inicio, // Data inicio.
            DateTime termino    // Data fim.
            ) // Define os valores para serem inseridos.
        {
            driver.FindElement(byInputTitulo).SendKeys(titulo);
            driver.FindElement(byInputDescricao).SendKeys(descricao);
            driver.FindElement(byInputCategoria).SendKeys(categoria);
            driver.FindElement(byInputValorInicial).SendKeys(valor.ToString());
            driver.FindElement(byInputImagem).SendKeys(imagem);
            driver.FindElement(byInputInicioPregao).SendKeys(inicio.ToString("dd/mm/yyyy")); //Usa o sendkeys para inserir a data do pregão, convertendo o que seria um númerico para string.
            driver.FindElement(byInputTerminoPregao).SendKeys(termino.ToString("dd/mm/yyyy")); //Usa o sendkeys para inserir a data do pregão, convertendo o que seria um númerico para string.
        }

        public void SubmeteFormulario()
        {
            driver.FindElement(byBotaoSalvar).Click();
        }
    }
}
