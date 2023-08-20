using Day2AutomatedTest.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2AutomatedTest.NewtestModules
{
    public class NewPOMPracticeTest : BasePage
    {
        HomePage homePage;
        ContactUsPage contactUsPage;
        GetIntouchPage getIntouchPage;
        IWebDriver driver;

        public NewPOMPracticeTest()
        {
            driver = Initializedriver();
            homePage = new HomePage(driver);
            contactUsPage = new ContactUsPage(driver);
            getIntouchPage = new GetIntouchPage(driver);
        }

        [Test]
        public void POMTest3()
        {
            homePage.NavigateToHomePage();

            homePage.ClickContactUs();

            contactUsPage.FillContactUsForm("Joe", "Joe@abc.com", "My query", "My message");

            Assert.True(getIntouchPage.IsSuccessMsgDisplayed());
        }

        [Test]
        public void POMTest4()
        {
            homePage.NavigateToHomePage();

            homePage.ClickContactUs();

            contactUsPage.FillContactUsForm("Femi", "Femi@abc.com", "My special query", "My message");

            Assert.True(getIntouchPage.IsSuccessMsgDisplayed());
        }
    }
}
