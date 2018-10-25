using AutomationFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace AutomationFramework.Helpers
{
    public class WaitHelper
    {
        private readonly static int _timeSpan = 10;

        // An expectation for checking that an element is present on the DOM of a page and visible. 
        // Visibility means that the element is not only displayed but also has a height and width that is greater than 0.
        internal static IWebElement ElementIsVisible(By locator)
        {
            try
            {
                var wait = new WebDriverWait(Browser.webDriver, TimeSpan.FromSeconds(_timeSpan))
                {
                    PollingInterval = TimeSpan.FromSeconds(2)
                };
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
                return Browser.webDriver.FindElement(locator);
            }
            catch (Exception)
            {
                throw new NoSuchElementException("Element is not visible <b>" + locator.ToString());
            }
        }

        //  An expectation for checking an element is visible and enabled such that you can click it.
        internal static IWebElement ElementToBeClickable(By locator)
        {
            try
            {
                var wait = new WebDriverWait(Browser.webDriver, TimeSpan.FromSeconds(_timeSpan))
                {
                    PollingInterval = TimeSpan.FromSeconds(2)
                };
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
                wait.Until(ExpectedConditions.ElementToBeClickable(locator));
                return Browser.webDriver.FindElement(locator);
            }
            catch (Exception)
            {
                throw new NoSuchElementException("Element is not clickable: <b>" + locator.ToString());
            }
        }

        //  An expectation for checking that an element is present on the DOM of a page. This does not necessarily mean that the element is visible.
        internal static IWebElement ElementExists(By locator)
        {
            try
            {
                var wait = new WebDriverWait(Browser.webDriver, TimeSpan.FromSeconds(_timeSpan))
                {
                    PollingInterval = TimeSpan.FromSeconds(2)
                };
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
                wait.Until(ExpectedConditions.ElementExists(locator));
                return Browser.webDriver.FindElement(locator);
            }
            catch (Exception)
            {
                throw new NoSuchElementException("Element is not exists: <b>" + locator.ToString());
            }
        }
    }
}
