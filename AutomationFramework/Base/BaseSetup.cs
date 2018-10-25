using System;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using System.IO;
using System.Configuration;
using AventStack.ExtentReports.Reporter.Configuration;
using Xunit.Abstractions;

namespace AutomationFramework.Base
{
    public class BaseSetup : IDisposable
    {
        public static ExtentReports _extent;
        public static ExtentTest _test;
        protected static readonly string _time = DateTime.Now.ToString(" MM-dd-yyyy H-mm");



        // Browser Setup
        public BaseSetup()
        {

            // Setup up report directory from App.config file.
            var reportDir = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ReportPath"];
            Directory.CreateDirectory(reportDir);
            var fileName = (reportDir + ConfigurationManager.AppSettings["ReportTitle"] + _time + ".html");
            var htmlReporter = new ExtentHtmlReporter(fileName);
            _extent = new ExtentReports();

            _extent.AttachReporter(htmlReporter);

            // Report Configurations
            //htmlReporter.LoadConfig(AppDomain.CurrentDomain.BaseDirectory + @"..\..\packages\ExtentReports.3.0.2\lib\extent-config.xml");

            // make the charts visible on report open
            htmlReporter.Configuration().ChartVisibilityOnOpen = false;
            htmlReporter.Configuration().ChartLocation = ChartLocation.Top;
            // report title
            htmlReporter.Configuration().DocumentTitle = ConfigurationManager.AppSettings["ReportTitle"];
            // DSS logo
            string dssImg = "<img src=\"..\\WAF\\Logo\\DSSinc.png\" alt=\"DSS\" style=\"padding-top: 5px; padding-left: 10px; padding-right: 30px; max-height: 90%; width: auto;\"> ";
            // report or build name
            string reportText = "<span class=\"suite-start-time label blue darken-3\" style=\"position: relative; top: -15px;\">" + ConfigurationManager.AppSettings["ReportTitle"] + " &nbsp|&nbsp Build - " + ConfigurationManager.AppSettings["ProductVersion"] + "</span>";
            htmlReporter.Configuration().ReportName = dssImg + reportText;
            // add custom css
            htmlReporter.Configuration().CSS = @".step-details > img { float: right; } td{font-size: 16px} .test-steps th:nth-child(2), tr.log > td:nth-child(2), .node-steps th:nth-child(2), .node-steps td:nth-child(2) { display: none; } .brand-logo { display: none !important; } .nav-wrapper { background-color: white; } a:last-child .label.blue.darken-3 { display: none; }";
            // add custom javascript

            _test = _extent.CreateTest("Test");

            Browser.Initialize();
        }

        // Tear down
        public void Dispose()
        {
            Browser.Quit();

            // Prints everything to test report
            _extent.Flush();

            string openTest = ConfigurationManager.AppSettings["Open"];

            // Open test report
            if (openTest[0] == 'Y' || openTest[0] == 'y')
            {
                System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ReportPath"] + ConfigurationManager.AppSettings["ReportTitle"] + _time + ".html");
            }
        }
    }
}
