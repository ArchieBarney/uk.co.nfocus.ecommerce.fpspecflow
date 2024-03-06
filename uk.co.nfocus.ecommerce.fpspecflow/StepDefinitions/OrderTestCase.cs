using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace uk.co.nfocus.ecommerce.fpspecflow.StepDefinitions
{
    [Binding]
    public class OrderTestCase
    {
        private readonly ScenarioContext _scenarioContext;

        public OrderTestCase(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I have entered valid coupon '(.*)'")]
        public void GivenIHaveEnteredValidCoupon(string edgewords0)
        {
            _scenarioContext.Pending();
        }

        [When(@"I click Apply Coupon")]
        public void WhenIClickApplyCoupon()
        {
            _scenarioContext.Pending();
        }

        [Then(@"'(.*)' is taken off the subtotal")]
        public void ThenIsTakenOffTheSubtotal(string p0)
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
