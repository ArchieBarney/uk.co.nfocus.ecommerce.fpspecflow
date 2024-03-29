﻿using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.nfocus.ecommerce.fpspecflow.Support
{
    internal static class StaticHelperClass
    {
        public static void StaticWaitForElement(IWebDriver driver, By locator, int timeInSeconds = 3)
        {
            WebDriverWait myWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds));
            myWait.Until(drv => drv.FindElement(locator).Enabled);
        }

        public static string ScrollElementIntoViewAndTakeScreenshot(IWebDriver driver, IWebElement element, string nameOfScreenshot)
        {
            // Thread sleep to give time for the injected js to get to the element on webpage
            Thread.Sleep(500);

            IJavaScriptExecutor? jsdriver = driver as IJavaScriptExecutor;

            if (jsdriver != null)
            {
                jsdriver.ExecuteScript("arguments[0].scrollIntoView()", element);
            }

            return ScreenshotPage(driver, nameOfScreenshot);
        }

        public static string ScreenshotPage(IWebDriver driver, string nameOfScreenshot)
        {
            Screenshot screenshot = driver.TakeScreenshot();
            screenshot.SaveAsFile(Directory.GetCurrentDirectory() + nameOfScreenshot);
            return Directory.GetCurrentDirectory() + nameOfScreenshot;
        }

        public static Dictionary<string, string> ToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach(var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }
    }
}
