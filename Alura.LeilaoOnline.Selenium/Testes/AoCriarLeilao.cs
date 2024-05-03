using System;
using OpenQA.Selenium;
using Xunit;
using Alura.LeilaoOnline.Selenium.PageObjects;
using Alura.LeilaoOnline.Selenium.Fixtures;


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

            
            //action
            //assert
        }
    }
}
