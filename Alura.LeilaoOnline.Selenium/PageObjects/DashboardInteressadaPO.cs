using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardInteressadaPO
    {
        private IWebDriver driver;
        private By byLogoutLink; //Define uma variavel privada para o logout, para proteger o valor.
        private By byMeuPerfilLink;

        public DashboardInteressadaPO(IWebDriver driver)
        {
            this.driver = driver;
            byLogoutLink = By.Id("logout"); //Define o que é a variavel privada de logout.
            byMeuPerfilLink = By.Id("meu-perfil");
        }

        public void EfetuarLogout()
        {
            var linkMeuPerfil = driver.FindElement(byMeuPerfilLink);
            var linkLogout = driver.FindElement(byLogoutLink); //Encontra o elemento de logout usando a variavel privada.

            //Simula a ação de um usuario usando a interface Interactions do Selenium.
            IAction acaoLogout = new Actions(driver)
                //Mover para o elemento meu-perfil.
                .MoveToElement(linkMeuPerfil)
                //Mover para o link de logout.
                .MoveToElement(linkLogout)
                //Clicar no link de logout.
                .Click()
                .Build();

            //Executa o IAction.
            acaoLogout.Perform();
        }
    }
}
