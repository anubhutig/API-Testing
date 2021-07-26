using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace API_july2021.specflowBDD
{
    [Binding]
    public class BillingOrderSteps
    {
        IWebDriver browser;
        private readonly ScenarioContext scenarioContext;


        public BillingOrderSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;

        }

        [Given(@"Open Billing Order Page")]
        public void GivenOpenBillingOrderPage()
        {
            browser = (IWebDriver)scenarioContext["ChromeDriver"];
            browser.Url = "http://www.google.com";
        }
        
        [When(@"Enter User Details")]
        public void WhenEnterUserDetails()
        {
            
        }
        
        [When(@"Submit User Details")]
        public void WhenSubmitUserDetails()
        {
            
        }
        
        [Then(@"Form should be submitted successfully")]
        public void ThenFormShouldBeSubmittedSuccessfully()
        {
            
        }
    }
}
