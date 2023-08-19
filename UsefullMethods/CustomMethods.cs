using SeleniumExtras.WaitHelpers;

namespace Day2AutomatedTest.UsefullMethods
{
    public class CustomMethods
    {
        public void WaitForAlertBy(IWebDriver browser)
        {
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.AlertIsPresent());
        }

        public void WaitForElementBy(IWebDriver browser, By by)
        {
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public void WaitForElementTextBy(IWebDriver browser, By by, string text)
        {
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.TextToBePresentInElementLocated(by, text));
        }

        public void WaitForElementByWithoutSeleniumExtras(IWebDriver browser, By by)
        {
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(60));
            wait.Until(x => x.FindElement(by));
            //if (browser.FindElement(by).Displayed)
            //{
            //    wait.Until(mo => mo.FindElement(by));
            //}
        }

        public void SelectFromDropDownByText(IWebElement element, string text)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByText(text);
        }

        public void SelectFromDropDownByIndex(IWebElement element, int index)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByIndex(index);
        }

        public void SelectFromDropDownByValue(IWebElement element, string value)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByValue(value);
        }
    }

    public static class CustomMethodsWithStatic
    {
        public static void WaitForAlertBy(this IWebDriver browser)
        {
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.AlertIsPresent());
        }

        public static void WaitForElementBy(this IWebDriver browser, By by)
        {
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public static void WaitForElementByWithoutSeleniumExtras(IWebDriver browser, By by)
        {
            WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(60));
            wait.Until(x => x.FindElement(by));
            //if (browser.FindElement(by).Displayed)
            //{
            //    wait.Until(mo => mo.FindElement(by));
            //}
        }

        public static void SelectFromDropDownByText(this IWebElement element, string text)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByText(text);
        }

        public static void SelectFromDropDownByIndex(this IWebElement element, int index)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByIndex(index);
        }

        public static void SelectFromDropDownByValue(this IWebElement element, string value)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByValue(value);
        }
    }
}
