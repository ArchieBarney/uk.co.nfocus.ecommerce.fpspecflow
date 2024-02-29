using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static uk.co.nfocus.ecommerce.fpspecflow.Support.StaticHelperClass;

namespace uk.co.nfocus.ecommerce.fpspecflow.Support.POMClasses
{
    internal class ShopPOM
    {
        private IWebDriver _driver;

        public ShopPOM(IWebDriver driver)
        {
            this._driver = driver;
        }

        private IWebElement _addToCart => _driver.FindElement(By.CssSelector("a[aria-label='Add “Beanie” to your cart']"));

        private IWebElement _veiwCart => new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(drv => drv.FindElement(By.CssSelector("a[title='View cart']")));

        public void AddItemToCart()
        {
            _addToCart.Click();
        }

        public void VeiwCart()
        {
            StaticWaitForElement(_driver, By.CssSelector("a[title='View cart']"));
            _veiwCart.Click();
        }
    }
}
