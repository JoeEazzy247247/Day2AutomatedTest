namespace Day2AutomatedTest.NewtestModules
{
    public class NewPracticalTest : BasePage
    {
        //Inheritance
        //Creating the object of the class
        //Dependency injection (POM)

        [Test]
        public void NewPracticalTest01()
        {
            //Actions Example
            var inputElements = browser.FindElements(By.XPath("//input"));
            Actions action = new Actions(browser); //Object of Actions class
            action.Click(inputElements[4]).Perform();
            action.Click(inputElements[7]).Perform();

            var firstName = browser.FindElement(
                By.CssSelector("input[ng-model='FirstName']"));
            action
                .Click(firstName)
                .SendKeys("Joseph")
                .Build()
                .Perform();

            Thread.Sleep(3000);
        }
    }

    public class NewPracticalTest2
    {
        [Test]
        public void NewPracticalTest001()
        {
            //Create object of basepage class
            BasePage basePage = new BasePage();
            basePage.Start();
            var inputElements = basePage.browser.FindElements(By.XPath("//input"));
            Actions action = new Actions(basePage.browser); //Object of Actions class
            action.Click(inputElements[5]).Perform();
            action.Click(inputElements[6]).Perform();

            var firstName = basePage.browser.FindElement(
                By.CssSelector("input[ng-model='FirstName']"));
            action
                .Click(firstName)
                .SendKeys("Joseph")
                .Build()
                .Perform();

            Thread.Sleep(3000);
            basePage.End();
        }
    }

    public class NewPracticalTest3 : BasePage
    {
        [Test]
        public void NewPracticalTest0001()
        {
            var inputElements = browser.FindElements(By.XPath("//input"));
            Actions action = new Actions(browser); //Object of Actions class
            action.Click(inputElements[5]).Perform();
            action.Click(inputElements[6]).Perform();

            var firstName = browser.FindElement(
                By.CssSelector("input[ng-model='FirstName']"));
            action
                .Click(firstName)
                .SendKeys("Joseph")
                .Build()
                .Perform();

            Thread.Sleep(3000);
        }
    }
}
