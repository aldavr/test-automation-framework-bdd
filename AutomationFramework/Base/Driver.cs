using AutomationFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;

namespace AutomationFramework.Base
{
    public class Driver: Browser
    {
        private static IWebElement element;

        // Clicks on Element
        public static void Click(By locator)
        {
            element = WaitHelper.ElementToBeClickable(locator);

            // Used for IE 11 for Click event.
            if (ConfigurationManager.AppSettings["Browser"].ToString() == "IE")
            {
                Actions actions = new Actions(webDriver);
                actions.MoveToElement(element).Click().Perform();
            }
            else
            {
                element.Click();
            }
        }

        // Inserts text into text field
        public static void Insert(By locator, string text)
        {
            element = WaitHelper.ElementIsVisible(locator);
            element.Clear();
            element.SendKeys(text);
        }

        // Navigates to directory (baseUrl/directory)
        public static void Goto(string url)
        {
            webDriver.Navigate().GoToUrl(baseUrl + url);
        }

        // Selects specific item from drop-down.
        public static void SelectDropdownValue(By locator, string option)
        {
            // Code below is used for IE browser.
            if (ConfigurationManager.AppSettings["Browser"].ToString() == "IE")
            {
                element = WaitHelper.ElementToBeClickable(locator);
                Click(locator);
                Click(By.XPath("//option[normalize-space(text())='" + option + "']"));
            }
            else
            {
                var select = new SelectElement(WaitHelper.ElementIsVisible(locator));
                select.SelectByText(option);
            }
        }

        // Selects Check-box
        public static void SelectCheckbox(By locator)
        {
                WaitHelper.ElementExists(locator);

                if (!webDriver.FindElement(locator).GetAttribute("aria-checked").Equals("true"))
                {
                    element = WaitHelper.ElementExists(locator);
                    Actions actions = new Actions(webDriver);
                    actions.MoveToElement(element).Click().Perform();
                }
        }

    }
}
