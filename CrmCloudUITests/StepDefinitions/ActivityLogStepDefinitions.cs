using CrmCloudUITests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CrmCloudUITests.StepDefinitions
{
    [Binding]
    public class ActivityLogStepDefinitions
    {
        private readonly IWebDriver driver;

        private readonly TopBarComponent topBarComponent;
        private readonly ActivityLogPage activityLogPage;
        private List<string> listOfDeletedActivities;

        public ActivityLogStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            topBarComponent = new TopBarComponent(driver);
            activityLogPage = new ActivityLogPage(driver);
        }

        [Then(@"Delete (.*) rows from Activity Log")]
        public void ThenDeleteRowsFromActivityLog(int numberOfRows)
        {
            topBarComponent.ClickActivityLogButtonInReportsSettingsTileTab();

            listOfDeletedActivities = activityLogPage.GetActivity(numberOfRows);
            activityLogPage.DeleteActivities(numberOfRows);
        }

        [Then(@"Rows in Activity Log are deleted")]
        public void ThenRowsInActivityLogAreDeleted()
        {
            topBarComponent.ClickActivityLogButtonInReportsSettingsTileTab();
            var activityLogAfterDelete = activityLogPage.GetActivity(10);
            foreach (var activityLog in activityLogAfterDelete)
            {
                Assert.IsTrue(!listOfDeletedActivities.Contains(activityLog));
            }
        }
    }
}