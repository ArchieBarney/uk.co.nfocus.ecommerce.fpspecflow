using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uk.co.nfocus.ecommerce.fpspecflow.Support;
using uk.co.nfocus.ecommerce.fpspecflow.Support.POMClasses;

namespace uk.co.nfocus.ecommerce.fpspecflow.StepDefinitions
{
    [Binding]
    internal class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly WDWrapper _wrapper;

        public Hooks(ScenarioContext scenarioContext, WDWrapper wrapper)
        {
            _scenarioContext = scenarioContext;
            _wrapper = wrapper;
        }

        [Before("@GUI")]
        public void SetUp()
        {
            IWebDriver _driver;
            string browser = Environment.GetEnvironmentVariable("BROWSER");

            if (browser == null)
            {
                Console.WriteLine("browser is null, using default (Edge)");
            }

            switch (browser)
            {
                case "chrome":
                    _driver = new ChromeDriver();
                    break;
                case "firefox":
                    _driver = new FirefoxDriver();
                    break;
                case "ie":
                    _driver = new InternetExplorerDriver();
                    break;
                case "firefoxheadless":
                    FirefoxOptions firefoxOptions = new();
                    firefoxOptions.AddArgument("--headless");
                    _driver = new FirefoxDriver(firefoxOptions);
                    break;
                case "chromeheadless":
                    ChromeOptions chromeOptions = new();
                    chromeOptions.AddArgument("--headless");
                    _driver = new ChromeDriver(chromeOptions);
                    break;
                default:
                    _driver = new EdgeDriver();
                    break;
            }
            string startURL = TestContext.Parameters["WebAppURL"];
            if (startURL == null)
            {
                Console.WriteLine("URL provided is null, using default");
                startURL = "https://www.edgewordstraining.co.uk/demo-site/";
            }
            _driver.Url = startURL;

            _driver.Manage().Window.Maximize();

            _wrapper.Driver = _driver;
            _scenarioContext["driverWrapped"] = _wrapper.Driver;
        }

        [After("@GUI")]
        public void TearDown()
        {
            HomePOM home = (HomePOM)_scenarioContext["homePOM"];
            home.GoAccountLogin();
            home.Logout();
            _wrapper.Driver.Quit();
        }
    }
}
