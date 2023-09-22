using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CrmCloudUITests.Pages
{
    public class ContactsPage : BasePage
    {
        private readonly IWebDriver driver;
        //TODO: Split that class into separate ones

        private string ContactsHeader = "//span[@id='main-title-module']//span[text()= 'Contacts']";
        private string CreateContactButton = "//button[@name='SubPanel_create']//span";
        private string SearchInput = "//input[@class='input-text input-entry ']";

        //Add new contact form
        private string SaveButton = "//span[@id='DetailForm_save-label']";
        private string FirstNameInput = "//input[@id='DetailFormfirst_name-input']";
        private string LastNameInput = "//input[@id='DetailFormlast_name-input']";
        private string CategoryDropdown = "//div[@id='DetailFormcategories-input']//div";
        private string BusinessOptionInCategoryDropdown = "//div[text()= 'Business']";
        private string BusinessRoleDropdown = "//div[@id='DetailFormbusiness_role-input-label']";
        private string CEOOptionInBusinessRoleDropdown = "//div[text()= 'CEO']";
        private string CreatedContactSummary = "//div[@id='DetailForm-subpanels']";

        //View contact form
        private string Header = "//div[@id='_form_header']";
        private string BusinessCategoryValue = "//span[text()='Category: ']//..//..//li[text()='Business']";
        private string CEOInBusinnesRole = "//p[text()='Business Role']//..//div[text()='CEO']";        
        

        public ContactsPage(IWebDriver driver)
        {
            this.driver = driver;
            WaitUntilPageLoaded();
        }
        public void WaitUntilPageLoaded()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath(ContactsHeader))));
        }

        public void ClickCreateContact()
        {
            ClickOn(driver, CreateContactButton);
        }

        public void CreateNewContact(string firstName, string lastName)
        {
            //TODO: I could not find the Customers and Suppliers categories, so I am not filling them in
            FillField(driver, FirstNameInput, firstName);
            FillField(driver, LastNameInput, lastName);
            ClickOn(driver, CategoryDropdown);
            ClickOn(driver, BusinessOptionInCategoryDropdown);
            ClickOn(driver, BusinessRoleDropdown);
            ClickOn(driver, CEOOptionInBusinessRoleDropdown);
            ClickOn(driver, SaveButton);
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath(CreatedContactSummary))));
        }

        public void SearchForContact(string firstName, string lastName) 
        {
            ClearAndFillField(driver, SearchInput, firstName);
            ClickOn(driver, $"//a[contains(@class, 'listViewNameLink') and text() = '{firstName} {lastName}']");
        }

        public void VerifyContactData(string firstName, string lastName)
        {
            Assert.AreEqual(GetTextFromElement(driver, Header).Trim(), $"{firstName} {lastName}");
            Assert.IsTrue(IsDisplayed(driver, BusinessCategoryValue), "Bussines is not category service");
            Assert.IsTrue(IsDisplayed(driver, CEOInBusinnesRole), "CEO is not displayed");
                
        }
    }
}
