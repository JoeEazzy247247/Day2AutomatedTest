using Day2AutomatedTest.PageObjects;
using Day2AutomatedTest.UsefullMethods;
using Day2AutomatedTest.utilities;
using SeleniumExtras.WaitHelpers;
using static System.Net.WebRequestMethods;

namespace Day2AutomatedTest.TestModules
{
    public class AutomationBasics : BasePage
    {
        SelectElement seldropdown(IWebElement elem) => new SelectElement(elem);

        [Test]
        public void TestAutomation101()
        {
            browser.Navigate().GoToUrl(Enviroments.DemoqaUrl);
            Assert.That(browser.Url, Is.EqualTo(Enviroments.AutomationUrl));
            browser.Url.Should().Be(Enviroments.AutomationUrl);
            Console.WriteLine(browser.Title);
            browser.FindElement(
                By.XPath("//label[text()='Password']//following-sibling::div/input"))
                .SendKeys("password");

            var InputFields = browser.FindElements(By.TagName("input"));
            IWebElement result(int num) => InputFields?.Count() > 1
                ? InputFields[num]
                : throw new Exception("Element count is less");
            result(0).SendKeys("Joseph");
            result(1).SendKeys("Harrison");
            Thread.Sleep(3000);
            browser.Quit();
        }

        [Test, TestCaseSource(typeof(BasePage), "MyTestData")]
        //[Test, TestCaseSource(nameof(MyTestData))]
        public void TestAutomation102(string fname, string lname, string add, string mobile)
        {
            browser.Navigate().GoToUrl(Enviroments.AutomationUrl);
            var firstName = browser.FindElement(By.CssSelector("input[ng-model='FirstName']"));
            firstName.SendKeys(fname);

            var lastName = browser.FindElement(By.XPath("//*[@id=\"basicBootstrapForm\"]/div[1]/div[2]/input"));
            lastName.SendKeys(lname);

            var address = browser.FindElement(By.XPath("//textarea[contains(@class, 'form-control')]"));
            address.SendKeys(add);

            var phoneno = browser.FindElement(By.XPath("//input[@type='tel']"));
            phoneno.SendKeys(mobile);

            var inputElements = browser.FindElements(By.XPath("//input"));
            inputElements[4].Click();
            inputElements[7].Click();

            var password = browser.FindElement(By.Id("firstpassword"));
            password.SendKeys("bfjhsdhbvajdbj");

            var Cpassword = browser.FindElement(By.Id("secondpassword"));
            Cpassword.SendKeys("bfjhsdhbvajdbj");

            Thread.Sleep(2000);
            browser.Quit();
        }

        [Test]
        public void IjavascriptExample()
        {
            //IJavascript example
            browser.Navigate().GoToUrl(Enviroments.AutomationUrl);
            var inputElements = browser.FindElements(By.XPath("//input"));
            IJavaScriptExecutor js = browser; //Object of Ijavascrript
            js.ExecuteScript("arguments[0].click()", inputElements[4]);
            js.ExecuteScript("arguments[0].click()", inputElements[7]);

            var firstName = browser.FindElement(
                By.CssSelector("input[ng-model='FirstName']"));
            js.ExecuteScript("arguments[0].value='Joseph'", firstName);
            Thread.Sleep(3000);
            browser.Quit();
        }

        [Test]
        public void ActionsExample()
        {
            browser.Navigate().GoToUrl(Enviroments.AutomationUrl);
            var inputElements = browser.FindElements(By.XPath("//input"));
            Actions action = new Actions(browser); 
            action.Click(inputElements[4]).Perform();
            action.Click(inputElements[7]).Perform();

            var firstName = browser.FindElement(
                By.CssSelector("input[ng-model='FirstName']"));
            action
                .Click(firstName)
                .SendKeys("Joseph")
                .Build()
                .Perform();

            var year = browser.FindElement(By.Id("yearbox"));
            var month = browser.FindElement(By.CssSelector("[ng-model='monthbox']"));
            var day = browser.FindElement(By.Id("daybox"));
            //year.SendKeys("1990");
            //month.SendKeys("January");
            //day.SendKeys("1");

            //seldropdown(year).SelectByIndex(1);
            //seldropdown(month).SelectByIndex(1);
            //seldropdown(day).SelectByIndex(1);

            year.SelectFromDropDownByText("1990");
            month.SelectFromDropDownByText("January");
            day.SelectFromDropDownByText("1");

            //year.SelectFromDropDownByIndex(1);
            //year.SelectFromDropDownByIndex(1);
            //year.SelectFromDropDownByIndex(1);

            //year.SelectFromDropDownByValue("1990");
            //year.SelectFromDropDownByValue("January");
            //year.SelectFromDropDownByValue("1");

            var headerTxt = browser.FindElement(By.XPath("//h2")).Text;
            Console.WriteLine(headerTxt);
            Assert.That(headerTxt, Is.EqualTo("Register"));
            var image = browser.FindElement(By.CssSelector("#imagesrc"));
            var filePath = Directory.GetCurrentDirectory() + "\\testData\\test.txt";
            image.SendKeys(filePath);

            Thread.Sleep(3000);
            browser.Quit();
        }

        [Test]
        public void SwitchTabtest()
        {
            browser.Navigate().GoToUrl(Enviroments.DemoqaUrl);
            var tabs = browser.WindowHandles;
            browser.FindElement(By.Id("tabButton")).Click();
            var tab = browser.WindowHandles;
            browser.SwitchTo().Window(browser.WindowHandles[1]);
            Console.WriteLine(browser.FindElement(By.Id("sampleHeading")).Text);
            browser.SwitchTo().Window(browser.WindowHandles[0]);
            browser.FindElement(By.Id("windowButton")).Click();
            Thread.Sleep(3000);
            browser.Quit();
        }

        [Test]
        public void CrossBrowserTest()
        {
            browser.Navigate().GoToUrl(Enviroments.AutomationUrl);
            Thread.Sleep(3000);
        }

        [Test]
        public void ImplicitAndExplicitWaitTest()
        {
            browser.Navigate().GoToUrl(Enviroments.DemoqaUrlAlertPage);
            browser.FindElement(By.Id("timerAlertButton")).Click();
            //browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.AlertIsPresent());
            Console.WriteLine(browser.SwitchTo().Alert().Text);
            browser.SwitchTo().Alert().Accept();

            browser.FindElement(By.Id("confirmButton")).Click();
            browser.SwitchTo().Alert().Dismiss();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("confirmResult")));
            Console.WriteLine(browser.FindElement(By.Id("confirmResult")).Text);
        }

        [Test]
        public void ExplicitWaitTestRefactored()
        {
            browser.Navigate().GoToUrl(Enviroments.DemoqaUrlAlertPage);
            browser.FindElement(By.Id("timerAlertButton")).Click();
            //browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            browser.WaitForAlertBy();
            //CustomMethods cus = new CustomMethods();
            //cus.WaitForAlertBy(browser);
            Console.WriteLine(browser.SwitchTo().Alert().Text);
            browser.SwitchTo().Alert().Accept();

            browser.FindElement(By.Id("confirmButton")).Click();
            browser.SwitchTo().Alert().Dismiss();
            browser.WaitForElementBy(By.Id("confirmResult"));
            Console.WriteLine(browser.FindElement(By.Id("confirmResult")).Text);
        }

        //Last week
        //Wait
        //Custom methods
        //Custom extensions

        //[Test]
        //public void POMTest()
        //{
        //    HomePage homePage = new HomePage(browser);
        //    homePage.NavigateToHomePage();
        //    homePage.ClickContactUs();

        //    ContactUsPage contactUsPage = new ContactUsPage(browser);
        //    contactUsPage.FillContactUsForm("Joe", "Joe@abc.com", "My query", "My message");

        //    GetIntouchPage getIntouchPage = new GetIntouchPage(browser);
        //    Assert.True(getIntouchPage.IsSuccessMsgDisplayed());
        //}

        [Test]
        public void POMTest2()
        {
            HomePage homePage = new HomePage(browser);
            homePage.NavigateToHomePage();

            ContactUsPage contactUsPage = homePage.ClickContactUs();

            GetIntouchPage getIntouchPage = 
                contactUsPage.FillContactUsForm("Joe", "Joe@abc.com", "My query", "My message");

            Assert.True(getIntouchPage.IsSuccessMsgDisplayed());
        }



        //This week
        //Page object (Different types/Different strategies)
        //Git

        //Next Week
        //Specflow
    }
}
