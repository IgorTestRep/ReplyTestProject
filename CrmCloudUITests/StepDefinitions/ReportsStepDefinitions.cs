using CrmCloudUITests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CrmCloudUITests.StepDefinitions
{
    [Binding]
    public class ReportsStepDefinitions
    {
        private readonly IWebDriver driver;

        private readonly TopBarComponent topBarComponent;
        private readonly ReportsPage reportsPage;

        public ReportsStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            topBarComponent = new TopBarComponent(driver);
            reportsPage = new ReportsPage(driver);
        }

        [Then(@"I Open ""([^""]*)"" report")]
        public void ThenIOpenReport(string reportName)
        {
            topBarComponent.ClickReportsButtonInReportsSettingsTileTab();
            reportsPage.SearchForReport(reportName);
            reportsPage.RunReport();
        }

        [Then(@"Report is not empty")]
        public void ThenReportIsNotEmpty()
        {
            Assert.IsTrue(reportsPage.IsReportVisible(), "Report is not visible!");
        }
    }
}