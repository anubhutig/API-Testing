using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace API_july2021.specflowBDD
{
    [Binding]
    public class BillingOrderSteps
    {
        int num1;
        int num2;
        int sum;

        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int num1)
        {
            this.num1 = num1;
        }
        
        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int num2)
        {
           this.num2 = num2;
        }
        
        [When(@"the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            sum = num1 + num2;
        }
        
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int expected)
        {
            Assert.AreEqual(expected, sum);
        }
    }
}
