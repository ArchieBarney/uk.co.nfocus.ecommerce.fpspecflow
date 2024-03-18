using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uk.co.nfocus.ecommerce.fpspecflow.Support.POMClasses;
using uk.co.nfocus.ecommerce.fpspecflow.Support;

namespace uk.co.nfocus.ecommerce.fpspecflow.StepDefinitions
{
    [Binding]
    public class BackgroundSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        public BackgroundSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = (IWebDriver)_scenarioContext["driverWrapped"];
        }

        [Given(@"I am logged in as a customer")]
        public void GivenIAmLoggedInAsACustomer()
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
            _scenarioContext["accountPOM"] = account;
        }

        [Given(@"I have added '(.*)' to my cart")]
        public void GivenIHaveAddedToMyCart(string item)
        {
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
            AccountPOM account = (AccountPOM)_scenarioContext["accountPOM"];
            account.ShopNavigate();

            // Add items to cart and view cart
            ShopPOM shop = new(_driver);
            shop.AddItemToCart();
            shop.VeiwCart();
        }
    }
}
