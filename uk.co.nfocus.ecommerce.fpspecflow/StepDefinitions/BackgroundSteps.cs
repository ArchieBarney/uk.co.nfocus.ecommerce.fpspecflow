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
            // Get to the account page from home POM
            HomePOM home = new(_driver);
            // Dismiss bottom link to prevent intercepted web elements
            home.DismissCookieLink();
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
            //Empty Basket
            CartPOM cart = new(_driver);
            cart.EmptyCart();

            // Navigate back to shop once basket is emptied
            AccountPOM account = (AccountPOM)_scenarioContext["accountPOM"];
            account.ShopNavigate();

            // Add items to cart and view cart
            ShopPOM shop = new(_driver, item);
            shop.AddItemToCart();
            shop.VeiwCart();
        }
    }
}
