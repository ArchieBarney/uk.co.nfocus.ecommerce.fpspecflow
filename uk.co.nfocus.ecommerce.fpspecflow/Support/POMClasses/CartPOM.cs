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
        private string _coupon;
        private string _couponSelector;

        public CartPOM(IWebDriver driver, string coupon = " ")
        {
            this._driver = driver;
            this._coupon = coupon;
            this._couponSelector = "td[data-title='Coupon: " + _coupon + "'] span[class='woocommerce-Price-amount amount']";
        }

        private IWebElement _couponInputBox => _driver.FindElement(By.CssSelector("#coupon_code"));

        private IWebElement _applyCouponButton => _driver.FindElement(By.CssSelector("button[value='Apply coupon']"));

        private IWebElement _subTotal => _driver.FindElement(By.CssSelector("tr[class='cart-subtotal'] bdi:nth-child(1)"));

        private IWebElement _couponAmount => _driver.FindElement(By.CssSelector(_couponSelector));

        private IWebElement _shippingAmount => _driver.FindElement(By.CssSelector("tr[class='woocommerce-shipping-totals shipping'] bdi:nth-child(1)"));

        private IWebElement _finalTotal => _driver.FindElement(By.CssSelector("tr[class='order-total'] bdi:nth-child(1)"));

        private IWebElement _checkoutButton => _driver.FindElement(By.PartialLinkText("Proceed to checkout"));

        private IWebElement _cartButton => _driver.FindElement(By.PartialLinkText("Cart"));

        private IWebElement _emptyCartButton => _driver.FindElement(By.CssSelector(".remove"));

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

        public By GetCouponValueOnWebPage
        {
            get { return By.CssSelector(_couponSelector); }
        }

        public void ApplyCoupon()
        {
            _couponInputBox.Clear();
            _couponInputBox.SendKeys(_coupon);
            _applyCouponButton.Click();
        }

        public void ProceedToCheckout()
        {
            _checkoutButton.Click();
        }

        public void EmptyCart()
        {
            _cartButton.Click();
            try
            {
                _emptyCartButton.Click();
            }
            catch (Exception)
            {
                //Do nothing, the basket is already empty
            }
        }
    }
}
