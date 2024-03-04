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
        private IWebDriver _driver;
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
            
            _wrapper.Driver = _driver;

            TestPrep();
        }

        [After("@GUI")]
        public void TearDown()
        {
            _wrapper.Driver.Quit();
        }

        public void TestPrep()
        {
            // Dismiss bottom link to prevent intercepted web elements
            _driver.FindElement(By.CssSelector(".woocommerce-store-notice__dismiss-link")).Click();

            // Get to the account page from home POM
            HomePOM home = new(_driver);
            home.GoAccountLogin();
            _scenarioContext["homePOM"] = home;

            // Use account POM to login to a placeholder account
            AccountPOM account = new(_driver)
            {
                Username = Environment.GetEnvironmentVariable("EMAIL"),
                Password = Environment.GetEnvironmentVariable("PASSWORD")
            };
            account.AccountLogin();

            //Empty Basket check
            _driver.FindElement(By.PartialLinkText("Cart")).Click();
            try
            {
                _driver.FindElement(By.CssSelector(".remove")).Click();
            }
            catch (Exception)
            {
                //Do nothing, the basket is already empty
            }

            // Navigate back to shop once basket is emptied
            account.ShopNavigate();

            // Add items to cart and view cart
            ShopPOM shop = new(_driver);
            shop.AddItemToCart();
            shop.VeiwCart();
        }
    }
}
