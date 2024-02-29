using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.nfocus.ecommerce.fpspecflow.Support.POMClasses
{
    internal class AccountPOM
    {
        private IWebDriver _driver;

        public AccountPOM(IWebDriver driver)
        {
            this._driver = driver;
        }

        private IWebElement _usernameField => _driver.FindElement(By.Id("username"));

        private IWebElement _passwordField => _driver.FindElement(By.Id("password"));

        private IWebElement _loginButton => _driver.FindElement(By.CssSelector("button[value='Log in']"));

        private IWebElement _shopButton => _driver.FindElement(By.PartialLinkText("Shop"));

        private IWebElement _accountOrders => _driver.FindElement(By.PartialLinkText("Orders"));

        private IWebElement _topAccountOrderNum => _driver.FindElement(By.CssSelector("tbody :first-child :first-child a"));

        public string Username
        {
            set
            {
                _usernameField.Clear();
                _usernameField.SendKeys(value);
            }
        }

        public string Password
        {
            set
            {
                _passwordField.Clear();
                _passwordField.SendKeys(value);
            }
        }

        public string Account_Order_Num => _topAccountOrderNum.Text;

        public IWebElement GetAccountOrders
        {
            get { return _accountOrders; }
        }

        public void AccountLogin()
        {
            _loginButton.Click();
        }

        public void ShopNavigate()
        {
            _shopButton.Click();
        }

        public void GoToAccountOrders()
        {
            _accountOrders.Click();
        }
    }
}
