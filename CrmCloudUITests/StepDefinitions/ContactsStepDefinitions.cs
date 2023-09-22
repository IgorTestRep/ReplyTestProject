using CrmCloudUITests.Helpers;
using CrmCloudUITests.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CrmCloudUITests.StepDefinitions
{
    [Binding]
    public class ContactsStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly ContactsPage contactsPage;
        private readonly TopBarComponent topBarComponent;

        private string contactFirstName = $"First {TestHelpers.RandomString(8)}";
        private string contactLastName = $"Last {TestHelpers.RandomString(10)}";


        public ContactsStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;

            contactsPage = new ContactsPage(driver);
            topBarComponent = new TopBarComponent(driver);
        }

        [Then(@"I Create new contact")]
        public void ThenCreateNewContact()
        {
            contactsPage.ClickCreateContact();
            contactsPage.CreateNewContact(contactFirstName, contactLastName);
        }

        [Then(@"Contact is created")]
        public void ThenContactIsCreated()
        {
            topBarComponent.ClickContactsButtonInSalesMarketingTab();
            contactsPage.SearchForContact(contactFirstName, contactLastName);
            contactsPage.VerifyContactData(contactFirstName, contactLastName);
        }
    }
}