using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace AutomationTest.Steps
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        Calculator calculate = new Calculator();
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int firstNumber)
        {
            calculate.FirstNumber = firstNumber;
        }

        [Given(@"I have also entered (.*) into the calculator")]
        public void GivenIHaveAlsoEnteredIntoTheCalculator(int secondNumber)
        {
            calculate.SecondNumber = secondNumber;
        }


        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            var actualResult = calculate.Add();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int expected)
        {
            var actualResult = calculate.Add();
            Assert.Equal(expected, actualResult);
        }

    }
}
