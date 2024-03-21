using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.nfocus.ecommerce.fpspecflow.Support.POMClasses
{
    internal class HomePOM
    {
        private IWebDriver _driver;

        public HomePOM(IWebDriver driver)
        {
            this._driver = driver;
        }

        private IWebElement _accountLink => _driver.FindElement(By.PartialLinkText("My account"));

        private IWebElement _dismissLink => _driver.FindElement(By.CssSelector(".woocommerce-store-notice__dismiss-link"));

        private IWebElement _logoutButton => _driver.FindElement(By.CssSelector("li[class='woocommerce-MyAccount-navigation-link woocommerce-MyAccount-navigation-link--customer-logout'] a"));

        public void GoAccountLogin()
        {
            _accountLink.Click();
        }

        public void DismissCookieLink()
        {
            _dismissLink.Click();
        }

        public void Logout()
        {
            _logoutButton.Click();
        }
    }
}
