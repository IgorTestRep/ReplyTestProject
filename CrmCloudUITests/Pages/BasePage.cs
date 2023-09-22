using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;

namespace CrmCloudUITests.Pages
{
    public class BasePage
    {
        private string baseUrl = Helpers.ConfigurationManager.AppSetting["BaseUrl"];
        protected WebDriverWait wait;
              

        public string GetBaseUrl()
        {
            return baseUrl;
        }

        public bool IsDisplayed(IWebDriver driver, string locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            bool isDisplayed = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator))).Displayed;
            return isDisplayed;
        }

        public void FillField(IWebDriver driver, string locator, string value)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator))).SendKeys(value);
        }

        public void ClearAndFillField(IWebDriver driver, string locator, string value)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement field = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));

            field.Clear();
            field.SendKeys(value);
            field.SendKeys(Keys.Enter);
        }

        public void ClickOn(IWebDriver driver, string locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(locator))).Click();
        }

        public void HoverOverElement(IWebDriver driver, string locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));

            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
        }

        public string GetTextFromElement(IWebDriver driver, string locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
            return element.Text;
        }

        public string GrabValueFromAttribute(IWebDriver driver, string locator, string attributeName)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
            return element.GetAttribute(attributeName);
        }
    }
}
