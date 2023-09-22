using OpenQA.Selenium;

namespace CrmCloudUITests.Pages
{
    public class TopBarComponent : BasePage
    {
        private readonly IWebDriver driver;

        private string SalesMarketingTile = "//a[@id='grouptab-1']";
        private string ReportsSettingsTile = "//a[@id='grouptab-5']";
        private string ContactsButton = "//a[contains(text(),' Contacts')]";
        private string ActivityLogButton = "//a[contains(text(),' Activity Log')]";

        public TopBarComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickContactsButtonInSalesMarketingTab()
        {
            ClickOn(driver, SalesMarketingTile);
            ClickOn(driver, ContactsButton);
        }

        public void ClickReportsButtonInReportsSettingsTileTab()
        {
            ClickOn(driver, ReportsSettingsTile);
        }

        public void ClickActivityLogButtonInReportsSettingsTileTab()
        {
            HoverOverElement(driver, ReportsSettingsTile);
            ClickOn(driver, ActivityLogButton);
        }
    }
}
