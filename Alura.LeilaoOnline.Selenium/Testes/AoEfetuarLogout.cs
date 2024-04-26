using Xunit;
using OpenQA.Selenium;
using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogout
    {
        private IWebDriver driver;

        public AoEfetuarLogout(TestFixture testFixture)
        {
            driver = testFixture.Driver;
        }

        [Fact]
        public void DadoLoginValidoDeveIrParaHomeNaoLogada()
        {
            //arrange
            var loginPO = new LoginPO(driver); //Importa a classe LoginPO da pasta PageObjects.
            //Importa os metodos da classe LoginPO
            loginPO.Visitar();
            loginPO.PreencheFormulario("fulano@example.org", "123");
            loginPO.SubmeteFormulario();

            var dashboardPO = new DashboardInteressadaPO(driver);
            //act
            dashboardPO.EfetuarLogout();
            //assert
            Assert.Contains("Próximos Leiloes", driver.PageSource);
        }
    }
}
