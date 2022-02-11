using System;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SeleniumDemo
{
 public class AmazonResults
 {
  private readonly IWebDriver driver;

  public AmazonResults(IWebDriver driver)
  {
   this.driver = driver;
  }

  //web element locators
  private readonly string resultsNext = "//*[@id='pagnNextLink']/span[2]";

  //click method
  public AmazonResults AmazonClickNext()
  {
   try
   {
    driver.FindElement(By.XPath(resultsNext)).Click();
   }
   catch (Exception e)
   {
    Console.WriteLine("Encountered an error while trying to click next button. Stack trace = " + e.Message);
   }
   return this;
  }
 }
} 
