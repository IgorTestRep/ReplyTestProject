using OpenQA.Selenium;

namespace CrmCloudUITests.Pages
{
    public class DashboardPage : BasePage
    {
        private readonly IWebDriver driver;

        private string DashboardTitle = "//div[@id='main-title']";

        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool IsDashboardTitleDisplayed()
        {
            return IsDisplayed(driver, DashboardTitle);
        }
    }
}
