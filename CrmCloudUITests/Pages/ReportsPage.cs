using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CrmCloudUITests.Pages
{
    public class ReportsPage : BasePage
    {
        private readonly IWebDriver driver;

        private readonly TopBarComponent topBarComponent;
        private string SearchInput = "//input[@class='input-text input-entry ']";
        private string RunReportButton = "//button[@name='FilterForm_applyButton']//..";
        private string FirstRow = "//tr[@data-id='0']";
        private string ReportsHeader = "//span[@id='main-title-module']//span[text()= 'Reports']";

        public ReportsPage(IWebDriver driver)
        {
            this.driver = driver;
            topBarComponent = new TopBarComponent(driver);
        }
        public void WaitUntilPageLoaded()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath(ReportsHeader))));
        }

        public void SearchForReport(string reportName)
        {
            WaitUntilPageLoaded();
            ClearAndFillField(driver, SearchInput, reportName);
            ClickOn(driver, $"//a[contains(@class, 'listViewNameLink') and text() = '{reportName}']");
        }

        public void RunReport()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='statusDiv']")));
            ClickOn(driver, RunReportButton);
        }

        public bool IsReportVisible()
        {
            return IsDisplayed(driver, FirstRow);
        }
    }
}
