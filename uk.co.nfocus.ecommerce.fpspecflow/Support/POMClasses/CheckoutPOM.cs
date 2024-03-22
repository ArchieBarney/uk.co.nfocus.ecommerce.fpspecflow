using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.nfocus.ecommerce.fpspecflow.Support.POMClasses
{
    internal class CheckoutPOM
    {
        private IWebDriver _driver;

        public CheckoutPOM(IWebDriver driver)
        {
            this._driver = driver;
        }

        private IWebElement _firstNameField => _driver.FindElement(By.CssSelector("#billing_first_name"));

        private IWebElement _lastNameField => _driver.FindElement(By.CssSelector("#billing_last_name"));

        private IWebElement _streetAddressField => _driver.FindElement(By.CssSelector("#billing_address_1"));

        private IWebElement _townCityField => _driver.FindElement(By.CssSelector("#billing_city"));

        private IWebElement _postcodeField => _driver.FindElement(By.CssSelector("#billing_postcode"));

        private IWebElement _phoneField => _driver.FindElement(By.CssSelector("#billing_phone"));

        private IWebElement _emailField => _driver.FindElement(By.CssSelector("#billing_email"));

        private IWebElement _placeOrderButton => _driver.FindElement(By.CssSelector("#place_order"));

        private IWebElement _orderNumber => _driver.FindElement(By.CssSelector("li[class='woocommerce-order-overview__order order'] strong"));

        private IWebElement _chequePayment => _driver.FindElement(By.CssSelector(".wc_payment_method.payment_method_cheque"));

        public string firstName
        {
            set
            {
                _firstNameField.Clear();
                _firstNameField.SendKeys(value);
            }
        }

        public string lastName
        {
            set
            {
                _lastNameField.Clear();
                _lastNameField.SendKeys(value);
            }
        }

        public string streetAdress
        {
            set
            {
                _streetAddressField.Clear();
                _streetAddressField.SendKeys(value);
            }
        }

        public string townCity
        {
            set
            {
                _townCityField.Clear();
                _townCityField.SendKeys(value);
            }
        }

        public string postcode
        {
            set
            {
                _postcodeField.Clear();
                _postcodeField.SendKeys(value);
            }
        }

        public string phone
        {
            set
            {
                _phoneField.Clear();
                _phoneField.SendKeys(value);
            }
        }

        public string email
        {
            set
            {
                _emailField.Clear();
                _emailField.SendKeys(value);
            }
        }

        public string Order_Number => _orderNumber.Text;

        public static By GetOrderNumberSelector
        {
            get { return By.CssSelector("li[class='woocommerce-order-overview__order order'] strong"); }
        }

        public void PlaceOrder()
        {
            _placeOrderButton.Click();
        }

        public void CheckChequePayments()
        {
            _chequePayment.Click();
        }
    }
}
