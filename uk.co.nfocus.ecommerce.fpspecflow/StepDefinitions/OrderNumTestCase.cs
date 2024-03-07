using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace uk.co.nfocus.ecommerce.fpspecflow.StepDefinitions
{
    [Binding]
    public class OrderNumTestCase
    {
        private readonly ScenarioContext _scenarioContext;

        public OrderNumTestCase(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"I click on Proceed to Checkout")]
        public void GivenIClickOnProceedToCheckout()
        {
            _scenarioContext.Pending();
        }

        [Given(@"I fill '(.*)', '(.*)', '(.*)', '(.*)' and '(.*)' into the corresponding fields")]
        public void GivenIFillAndIntoTheCorrespondingFields(string street, string town, string postcode, string phone, string email)
        {
            _scenarioContext.Pending();
        }

        [Given(@"I place the order assuming check payment is triggered")]
        public void GivenIPlaceTheOrderAssumingCheckPaymentIsTriggered()
        {
            _scenarioContext.Pending();
        }

        [When(@"I capture the order number")]
        public void WhenICaptureTheOrderNumber()
        {
            _scenarioContext.Pending();
        }

        [Then(@"The same order number should appear at the top of account orders")]
        public void ThenTheSameOrderNumberShouldAppearAtTheTopOfAccountOrders()
        {
            _scenarioContext.Pending();
        }
    }
}
