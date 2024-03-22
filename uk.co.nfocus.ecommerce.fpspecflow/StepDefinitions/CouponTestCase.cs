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
    public class CouponTestCase
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private CartPOM? _cart;

        public CouponTestCase(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = (IWebDriver)_scenarioContext["driverWrapped"];
        }

        [Given(@"I have entered valid coupon '(.*)'")]
        public void GivenIHaveEnteredValidCoupon(string couponCode)
        {
            // Apply coupon using POM
            CartPOM cart = new(_driver, couponCode);
            _cart = cart;
        }

        [When(@"I Apply the Coupon")]
        public void WhenIClickApplyCoupon()
        {
            _cart.ApplyCoupon();
        }

        [Then(@"'(.*)' is taken off the subtotal")]
        public void ThenIsTakenOffTheSubtotal(string couponPercentage)
        {
            // Wait to ensure coupon value appears on web page
            StaticWaitForElement(_driver, _cart.GetCouponValueOnWebPage);

            // Collecting values for assert to check coupon is applied
            _scenarioContext["subTotal"] = Convert.ToDecimal(_cart.Sub_total.Remove(0, 1));
            _scenarioContext["couponTotal"] = Convert.ToDecimal(_cart.Coupon_total.Remove(0, 1));
            decimal couponDecimalValue = Convert.ToDecimal(couponPercentage.Remove(couponPercentage.Length - 1)) / 100;

            
            Assert.That(Decimal.Multiply((decimal)_scenarioContext["subTotal"], couponDecimalValue),
                Is.EqualTo((decimal)_scenarioContext["couponTotal"]),
                "Coupon has not applied sufficient " + couponPercentage + " off subtotal");
            

            // Reporting for the coupon assertion
            string couponScreenshot = ScrollElementIntoViewAndTakeScreenshot(_driver,
                                                                             _cart.GetCouponAmount,
                                                                             "coupon.png");
            Console.WriteLine("Coupon has applied "+ couponPercentage + "%");
            TestContext.AddTestAttachment(couponScreenshot);
        }

        [Then(@"Total takes into account coupon \+ shipping")]
        public void ThenTotalTakesIntoAccountCouponShipping()
        {
            // Collecting values for assert to check shipping and coupon is applied to total
            decimal shippingCost = Convert.ToDecimal(_cart.Shipping_total.Remove(0, 1));
            decimal finalTotal = Convert.ToDecimal(_cart.Final_total.Remove(0, 1));

            
            Assert.That(finalTotal,
                Is.EqualTo((decimal)_scenarioContext["subTotal"] - (decimal)_scenarioContext["couponTotal"] + shippingCost),
                "Final total is not properly calculated, make sure shipping" +
                " cost is applied and any coupon discounts are sufficiently applied");

            
            // Reporting for the shipping + total assertion
            string totalScreenshot = ScrollElementIntoViewAndTakeScreenshot(_driver, 
                                                                            _cart.GetFinalTotal, 
                                                                            "total.png");
            Console.WriteLine("Total has been sufficiently calculated");
            TestContext.AddTestAttachment(totalScreenshot);
        }
    }
}
