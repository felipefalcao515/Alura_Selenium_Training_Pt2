using System;
using OpenQA.Selenium;
using Xunit;
using Alura.LeilaoOnline.Selenium.PageObjects;
using Alura.LeilaoOnline.Selenium.Fixtures;
using System.Threading;


namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public  class AoCriarLeilao
    {
        private IWebDriver driver;

        public AoCriarLeilao(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginAdministratoEInfoValidasDeveCadastrarLeilao()
        {
            //arrange
            var LoginPO = new LoginPO(driver);
            LoginPO.Visitar();
            LoginPO.PreencheFormulario("admin@example.org","123");
            LoginPO.SubmeteFormulario();

            var novoLeilaoPo = new NovoLeilaoPO(driver);
            novoLeilaoPo.Visitar();
            novoLeilaoPo.PreencherFormulario(
                "Leilão de Coleção 1", // Nome do leilão.
                "Nullam aliquet condimentum elit vitae volutpat. Vivamus ut nisi venenatis, facilisis odio eget, lobortis tortor. Cras mattis sit amet dolor id bibendum. Nulla turpis justo, porttitor eget leo vel, dictum tempor diam. Sed dui arcu, feugiat nec placerat ac, suscipit a mi. Etiam eget risus et tellus placerat tincidunt at ut lorem.",
                "Item de Colecionador",
                4000, // Valor R$ do leilão.
                "c:\\imagens\\colecao1.jpg", // Caminho da imagem no armazenamento local.
                DateTime.Now.AddDays(20), // Valor de data inicio do pregão.
                DateTime.Now.AddDays(40) // Valor de data fim do pregão.
                );
            //act
            novoLeilaoPo.SubmeteFormulario();
            //assert
            Assert.Contains("Leilões cadastrados no sistema", driver.PageSource);

            Thread.Sleep(5000);
        }
    }
}
