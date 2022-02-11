using System;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumDemo
{
 class Program
 {
  static void Main(string[] args)
  {
  //test vars
  string itemDept = "CDs & Vinyl";
  string itemName = "Van Halen";

  //setup chromedriver
  var options = new ChromeOptions();
  options.AddArguments("test-type");
  options.AddArgument("--start-maximized");
  IWebDriver driver = new ChromeDriver(@"C:\chromedriver", options);

  try
  {
   //instance of AmazonHome PageObject
   AmazonHome amazonHomePageObject = new AmazonHome(driver);
   amazonHomePageObject.AmazonSearch(itemDept, itemName);
   //instance of AmazonResults PageObject
   AmazonResults amazonResultsPageObject = new AmazonResults(driver);
   amazonResultsPageObject.AmazonClickNext();
  }
  catch (Exception e)
  {
   Console.WriteLine("Encountered an unforeseen error. Stack trace = " + e.Message);
  }

  //close chromedriver
  driver.Quit();
  }
 }
}
