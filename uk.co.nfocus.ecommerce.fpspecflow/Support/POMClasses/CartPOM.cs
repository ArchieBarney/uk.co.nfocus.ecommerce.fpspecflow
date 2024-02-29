using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.nfocus.ecommerce.fpspecflow.Support.POMClasses
{
    internal class CartPOM
    {
        private IWebDriver _driver;

        public CartPOM(IWebDriver driver)
        {
            this._driver = driver;
        }

        private IWebElement _couponInputBox => _driver.FindElement(By.CssSelector("#coupon_code"));

        private IWebElement _applyCouponButton => _driver.FindElement(By.CssSelector("button[value='Apply coupon']"));

        private IWebElement _subTotal => _driver.FindElement(By.CssSelector("tr[class='cart-subtotal'] bdi:nth-child(1)"));

        private IWebElement _couponAmount => _driver.FindElement(By.CssSelector("td[data-title='Coupon: edgewords'] span[class='woocommerce-Price-amount amount']"));

        private IWebElement _shippingAmount => _driver.FindElement(By.CssSelector("tr[class='woocommerce-shipping-totals shipping'] bdi:nth-child(1)"));

        private IWebElement _finalTotal => _driver.FindElement(By.CssSelector("tr[class='order-total'] bdi:nth-child(1)"));

        private IWebElement _checkoutButton => _driver.FindElement(By.PartialLinkText("Proceed to checkout"));

        public string coupon
        {
            set
            {
                _couponInputBox.Clear();
                _couponInputBox.SendKeys(value);
            }
        }

        public string Sub_total => _subTotal.Text;

        public string Coupon_total => _couponAmount.Text;

        public string Shipping_total => _shippingAmount.Text;

        public string Final_total => _finalTotal.Text;

        public IWebElement GetFinalTotal
        {
            get { return _finalTotal; }
        }

        public IWebElement GetCouponAmount
        {
            get { return _couponAmount; }
        }

        public void ApplyCoupon()
        {
            _applyCouponButton.Click();
        }

        public void ProceedToCheckout()
        {
            _checkoutButton.Click();
        }
    }
}
