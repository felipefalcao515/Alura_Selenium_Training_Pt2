using System;
using OpenQA.Selenium;


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
