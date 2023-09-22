using CrmCloudUITests.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CrmCloudUITests.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly LoginPage loginPage;
        private readonly DashboardPage dashboardPage;

        public LoginStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;

            loginPage = new LoginPage(driver);
            dashboardPage = new DashboardPage(driver);
        }

        [Given(@"I navigate to login page")]
        public void GivenINavigateToLoginPage()
        {
            string url = loginPage.GetUrl();
            driver.Navigate().GoToUrl(url);
        }

        [Given(@"I enter following for login")]
        public void GivenIEnterFollowingForLogin()
        {
            loginPage.InputUsername(Helpers.ConfigurationManager.AppSetting["AdminUsername"]);
            loginPage.InputPassword(Helpers.ConfigurationManager.AppSetting["AdminPassword"]);        
        }

        [When(@"I click login button")]
        public void WhenIClickLoginButton()
        {
            loginPage.ClickLogin();
        }
    }
}