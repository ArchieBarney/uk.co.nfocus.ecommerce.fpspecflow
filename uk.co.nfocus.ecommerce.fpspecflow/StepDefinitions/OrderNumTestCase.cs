using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uk.co.nfocus.ecommerce.fpspecflow.Support.POMClasses;

using static uk.co.nfocus.ecommerce.fpspecflow.Support.StaticHelperClass;


namespace uk.co.nfocus.ecommerce.fpspecflow.StepDefinitions
{
    [Binding]
    public class OrderNumTestCase
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private CartPOM? _cart;
        private CheckoutPOM? _checkout;

        public OrderNumTestCase(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = (IWebDriver)_scenarioContext["driverWrapped"];
        }

        [Given(@"I click on Proceed to Checkout")]
        public void GivenIClickOnProceedToCheckout()
        {
            // Set the cart up to proceed to checkout
            CartPOM cart = new(_driver);
            _cart = cart;
            _cart.ProceedToCheckout();
        }

        [When(@"I fill order details into the corresponding fields")]
        public void WhenIFillOrderDetailsIntoTheCorrespondingFields(Table orderDetailsTable)
        {
            // Converts input table into dictionary
            var dictionary = ToDictionary(orderDetailsTable);

            // Instansiate the checkout class with all the required fields to pass an order
            CheckoutPOM checkout = new(_driver)
            {
                firstName = dictionary["FirstName"],
                lastName = dictionary["Surname"],
                streetAdress = dictionary["Street"],
                townCity = dictionary["City"],
                postcode = dictionary["Postcode"],
                phone = dictionary["PhoneNumber"],
                email = dictionary["Email"]
            };
            _checkout = checkout;
        }

        [When(@"Cheque Payment is selected")]
        public void WhenChequePaymentIsSelected()
        {
            // Seperate reference for stale element (Thread works, web driver wait doesnt work)
            Thread.Sleep(1000);
            var checkPayment = _driver.FindElement(By.CssSelector(".wc_payment_method.payment_method_cheque"));
            checkPayment.Click();

        }

        [When(@"I place an order")]
        public void WhenIPlaceAnOrder()
        {
            _checkout.PlaceOrder();
        }

        [Then(@"an Order Number is displayed")]
        public void ThenAnOrderNumberIsDisplayed()
        {
            // Wait for the page to load in order to recieve the order number
            StaticWaitForElement(_driver, By.CssSelector("li[class='woocommerce-order-overview__order order'] strong"));
            string checkoutOrderNumber = _checkout.Order_Number;
            _scenarioContext["CheckoutOrderNum"] = checkoutOrderNumber;
            Console.WriteLine("Order number is: " + checkoutOrderNumber);
        }

        [Then(@"that Order Number appears in the account order history")]
        public void ThenThatOrderNumberAppearsInTheAccountOrderHistory()
        {
            // Go back to the account and get access to the account order history
            HomePOM home = (HomePOM)_scenarioContext["homePOM"];
            home.GoAccountLogin();
            AccountPOM account = new AccountPOM(_driver);
            account.GoToAccountOrders();

            try
            {
                Assert.That(account.Account_Order_Num.Remove(0, 1), Is.EqualTo((string)_scenarioContext["CheckoutOrderNum"]));
            }
            catch (Exception)
            {
                throw new Exception("order on checkout does not appear on account");
            }

            // Reporting for the Order number assertion
            string totalScreenshot = ScrollElementIntoViewAndTakeScreenshot(_driver, account.GetAccountOrders, "ordernum.png");
            Console.WriteLine("Order number has been recorded and shows on the account");
            TestContext.AddTestAttachment(totalScreenshot);
        }
    }
}
