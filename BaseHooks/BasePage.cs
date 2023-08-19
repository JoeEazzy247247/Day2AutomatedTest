using Day2AutomatedTest.utilities;
using Microsoft.VisualBasic.FileIO;
using OpenQA.Selenium;

namespace Day2AutomatedTest.BaseHooks
{
    public enum Btype
    {
        Chrome,
        Firefox,
        Edge,
        Chromium
    }

    public class BasePage
    {
        //This is base page
        public WebDriver browser; 

        [SetUp]
        public void Start()
        {
            //ChooseWithTanery(Btype.Chromium, getChromiumOptions());
            //ChooseWithTanery(Btype.Chromium,getChromiumOptions());
            browser = Initializedriver();
        }

        public void ChooseWithTanery(Btype browserType,
            ChromeOptions? coption = null, FirefoxOptions? foptions = null,
            EdgeOptions? eoptions = null)
        {
            var browsers = browserType == Btype.Chrome
                ? browser = new ChromeDriver(coption)
                : browserType == Btype.Firefox
                ? browser = new FirefoxDriver(foptions)
                : browserType == Btype.Edge
                ? browser = new EdgeDriver(eoptions)
                : browserType == Btype.Chromium
                ? browser = new ChromeDriver(coption)
                : throw new NoSuchDriverException("Check browser exist");
        }

       public IWebDriver ChooseWithSwitch(Btype type, 
            ChromeOptions? coption = null,
            FirefoxOptions? foptions = null,
            EdgeOptions? eoptions = null
            ) => type switch
        {
            Btype.Chrome => browser = new ChromeDriver(coption),
            Btype.Firefox => browser = new FirefoxDriver(foptions),
            Btype.Edge => browser = new EdgeDriver(eoptions),
            Btype.Chromium => browser = new ChromeDriver(coption),
            _=> throw new Exception("No such browser")
        };

        public WebDriver Initializedriver()
        {
            if (browser == null)
            {
                ChooseWithSwitch(Btype.Chrome, getCoptions());
            }
            return browser;
        }

        public ChromeOptions getCoptions()
        {
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("--headless");
            options.AddArguments("start-maximized", "incognito");
            options.AddArguments("disable-infobars");
            options.AddExcludedArgument("enable-automation");
            return options;
        }

        public FirefoxOptions getFoptions()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArguments("--width=1920", "--height=1080");
            options.AddArguments("disable-infobars");
            //options.AddExcludedArgument("enable-automation");
            return options;
        }

        public EdgeOptions getEoptions()
        {
            EdgeOptions options = new EdgeOptions();
            options.AddArguments("start-maximized", "incognito");
            options.AddArguments("disable-infobars");
            options.AddExcludedArgument("enable-automation");
            return options;
        }

        public ChromeOptions getChromiumOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.BinaryLocation = 
                @"C:\Users\joeea\Downloads\chromedriver_win32\chromedriver.exe";
            options.AddArguments("start-maximized", "incognito");
            options.AddArguments("disable-infobars");
            options.AddExcludedArgument("enable-automation");
            return options;
        }

        private static IEnumerable<TestCaseData> MyTestData()
        {
            string[] datas = { "Joseph", "Harrison", "abc is my address", "078978976567" };
            yield return new TestCaseData(datas).
                SetName("TestAutomation102");
        }

        [TearDown]
        public void End()
        {
            if (browser != null)
            {
                browser.Quit();
                browser = null!;
            }
            Console.WriteLine();
        }
    }
}
