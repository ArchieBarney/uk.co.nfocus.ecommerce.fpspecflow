using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace uk.co.nfocus.ecommerce.fpspecflow.StepDefinitions
{
    [Binding]
    public class CouponTestCase
    {
        private readonly ScenarioContext _scenarioContext;

        public CouponTestCase(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I have entered valid coupon '(.*)'")]
        public void GivenIHaveEnteredValidCoupon(string couponCode)
        {
            _scenarioContext.Pending();
        }

        [When(@"I click Apply Coupon")]
        public void WhenIClickApplyCoupon()
        {
            _scenarioContext.Pending();
        }

        [Then(@"(.*) is taken off the subtotal")]
        public void ThenIsTakenOffTheSubtotal(int couponValue)
        {
            _scenarioContext.Pending();
        }

        [Then(@"Total takes into account coupon \+ shipping")]
        public void ThenTotalTakesIntoAccountCouponShipping()
        {
            _scenarioContext.Pending();
        }
    }
}
