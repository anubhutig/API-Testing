
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using API_july2021.Model;


public class BillingSubmissionFormTest
{
  public IWebDriver driver;
  
    public BillingSubmissionFormTest(IWebDriver driver)
    {
        this.driver = driver;
    }
 
  public void BillingSubmissionForm(BillingOrderN order) 
    {
    driver.Navigate().GoToUrl("http://qaauto.co.nz/billing-order-form/");
    driver.Manage().Window.Size = new System.Drawing.Size(1262, 660);
    driver.FindElement(By.Id("wpforms-locked-24-field_form_locker_password")).Click();
    driver.FindElement(By.Id("wpforms-locked-24-field_form_locker_password")).SendKeys("Testing");
    driver.FindElement(By.Id("wpforms-locked-24-field_form_locker_password")).SendKeys(Keys.Enter);
    driver.FindElement(By.Id("wpforms-24-field_0")).SendKeys(order.FirstName);
    driver.FindElement(By.Id("wpforms-24-field_0-last")).SendKeys(order.LastName);
    driver.FindElement(By.Id("wpforms-24-field_1")).SendKeys(order.Email);
    driver.FindElement(By.Id("wpforms-24-field_3")).SendKeys(order.PhoneNumber);
    driver.FindElement(By.Id("wpforms-24-field_3-address2")).SendKeys(order.AddressLine1);
    driver.FindElement(By.Id("wpforms-24-field_3-city")).SendKeys(order.AddressLine2);
    {
      var dropdown = driver.FindElement(By.Id("wpforms-24-field_3-state"));
      dropdown.FindElement(By.XPath("//option[. = 'California']")).Click();
    }
    
    driver.FindElement(By.Id("wpforms-24-field_6")).SendKeys(order.Comment);
    var elements = driver.FindElements(By.CssSelector("#wpforms-confirmation-24 > p"));
   // Assert.True(elements.Count > 0);
   //  Assert.That(driver.FindElement(By.CssSelector("#wpforms-confirmation-24 > p")).Text, Is.EqualTo("Thanks for contacting us! We will be in touch with you shortly."));
    driver.FindElement(By.Id("wpforms-submit-24")).Click();
    
       }
}
