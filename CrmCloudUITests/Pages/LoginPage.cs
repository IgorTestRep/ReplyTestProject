using OpenQA.Selenium;

namespace CrmCloudUITests.Pages
{
    public class LoginPage : BasePage
    {
        private readonly IWebDriver driver;

        private string UsernameInput = "//input[@id='login_user']";
        private string PasswordInput = "//input[@id='login_pass']";
        private string LoginButton = "//button[@id='login_button']";

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetUrl()
        {
            return GetBaseUrl();
        }

        public void InputUsername(string userName)
        {
            FillField(driver, UsernameInput, userName);
        }

        public void InputPassword(string password)
        {
            FillField(driver, PasswordInput, password);
        }

        public void ClickLogin()
        {
            ClickOn(driver, LoginButton);
        }
    }
}
