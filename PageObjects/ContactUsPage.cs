using Day2AutomatedTest.UsefullMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2AutomatedTest.PageObjects
{
    public class ContactUsPage : Hooks
    {
        CustomMethods customMethods;
        public ContactUsPage(IWebDriver _driver) : base(_driver)
        {
            customMethods = new CustomMethods();
        }

        IWebElement name => driver.FindElement(By.CssSelector("input[name=name]"));
        IWebElement email => driver.FindElement(By.CssSelector("input[name=email]"));
        IWebElement subject => driver.FindElement(By.CssSelector("input[name=subject]"));
        IWebElement msg => driver.FindElement(By.CssSelector("textarea[name=message]"));
        IWebElement submitbtn => driver.FindElement(By.CssSelector("input[name=submit]"));


        public GetIntouchPage FillContactUsForm(string Name, string Email
            , string Subject, string Msg)
        {
            name.SendKeys(Name);
            email.SendKeys(Email);
            subject.SendKeys(Subject);
            msg.SendKeys(Msg);
            submitbtn.Click();
            driver.SwitchTo().Alert().Accept();
            customMethods.WaitForElementBy(driver, 
                By.CssSelector("div[class='status alert alert-success']"));
            return new GetIntouchPage(driver);
        }
    }
}
