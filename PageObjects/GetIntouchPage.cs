using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2AutomatedTest.PageObjects
{
    public class GetIntouchPage : Hooks
    {
        public GetIntouchPage(IWebDriver _driver) : base(_driver)
        {
        }

        IWebElement successMsg => 
            driver.FindElement(
                By.CssSelector("div[class='status alert alert-success']"));

        public bool IsSuccessMsgDisplayed() => successMsg.Displayed;
    }
}
