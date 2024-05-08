using System;
using OpenQA.Selenium;
using Xunit;
using Alura.LeilaoOnline.Selenium.PageObjects;
using Alura.LeilaoOnline.Selenium.Fixtures;
using System.Linq;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaFormNovoLeilao
    {
        private IWebDriver driver;

        public AoNavegarParaFormNovoLeilao(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginAdmDeveMostrarTresCategorias()
        {
            //arrange
            // Usa as classes para o fluxo de login e criação de um novo leilão sem submeter.
            var LoginPO = new LoginPO(driver);
            LoginPO.Visitar();
            LoginPO.PreencheFormulario("admin@example.org", "123");
            LoginPO.SubmeteFormulario();

            var novoLeilaoPo = new NovoLeilaoPO(driver);
            novoLeilaoPo.Visitar();
            //act
            //assert
            Assert.Equal(3, novoLeilaoPo.Categorias.Count());// Usa a classe validador para contar os elementos dentro de "Categoria".
        }
    }
}
