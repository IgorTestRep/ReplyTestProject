using CrmCloudUITests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CrmCloudUITests.StepDefinitions
{
    [Binding]
    public class DashboardStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly DashboardPage dashboardPage;
        private readonly TopBarComponent topBarComponent;

        public DashboardStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;

            dashboardPage = new DashboardPage(driver);
            topBarComponent = new TopBarComponent(driver);
        }

        [Then(@"I should be able to access the dashboard view")]
        public void ThenIShouldBeAbleToAccessTheDashboardView()
        {
            Assert.IsTrue(dashboardPage.IsDashboardTitleDisplayed(), "Dashboard Is not displayed");
        }

        [Then(@"I Open Contacts view")]
        public void ThenOpenContactsView()
        {
            topBarComponent.ClickContactsButtonInSalesMarketingTab();
        }
    }
}