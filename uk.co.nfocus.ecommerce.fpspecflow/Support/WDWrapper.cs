using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.nfocus.ecommerce.fpspecflow.Support
{
    internal class WDWrapper
    {
        private IWebDriver _driver;

        public IWebDriver Driver { get => _driver; set => _driver = value; }
    }
}
