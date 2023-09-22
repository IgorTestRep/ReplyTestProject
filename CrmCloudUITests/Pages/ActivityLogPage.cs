using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CrmCloudUITests.Pages
{
    public class ActivityLogPage : BasePage
    {
        private readonly IWebDriver driver;

        private string ActivityLogHeader = "//span[@id='main-title-module']//span[text()= 'Activity Log']";
        private string CellboxWithAction = "//tbody//tr//td[2]";
        private string Checkbox = "//tbody//tr//td[1]";
        private string ActionsButton = "//button[contains(@id,'ActionButtonHead')]";
        private string DeleteButton = "//div[text()= 'Delete']";

        public ActivityLogPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void WaitUntilPageLoaded()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath(ActivityLogHeader))));
        }

        public List<string> GetActivity(int numberOfRows)
        {
            WaitUntilPageLoaded();
            IList<IWebElement> selectElements = driver.FindElements(By.XPath(CellboxWithAction));
            var activities = new List<string>();

            for (int i = 0; i < numberOfRows; i++)
            {
                var text = selectElements[i].Text;
                activities.Add(text);
            }
            return activities;
        }

        public void DeleteActivities(int numberOfRows)
        {
            IList<IWebElement> checkboxes = driver.FindElements(By.XPath(Checkbox));

            for (int i = 0; i < numberOfRows; i++)
            {
                checkboxes[i].Click();
            }
            ClickOn(driver, ActionsButton);
            ClickOn(driver, DeleteButton);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }
    }
}
