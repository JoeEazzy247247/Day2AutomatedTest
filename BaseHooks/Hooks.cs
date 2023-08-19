using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2AutomatedTest.BaseHooks
{
    public class Hooks
    {
        public IWebDriver driver;
        public Hooks(IWebDriver _driver)
        {
            driver = _driver;  
        }

        //Just a comment
    }
}
