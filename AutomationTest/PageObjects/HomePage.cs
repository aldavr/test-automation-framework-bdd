using AutomationFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AutomationTest.PageObjects
{
    public class HomePage
    {
        #region Page Elements

        //internal static By elementName = By.XPath("");
        private static readonly By elementName = By.XPath("");

        #endregion

        #region Actions

        internal static void VerifyPageElements() 
        {
            Driver.Click(elementName);
        }

        #endregion

        #region Navigations

        internal static void NavigateToHomePage()
        {
            Driver.Click(elementName);
        }

        #endregion
    }
}
