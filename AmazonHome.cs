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
 public class AmazonHome
 {
   private readonly string amazonUrl = "https://www.amazon.com/";
   private readonly IWebDriver driver;

   public AmazonHome(IWebDriver driver)
   {
     this.driver = driver;
   }

  //web element locators
  private readonly string searchDropdown = "searchDropdownBox";
  private readonly string searchTextbox = "twotabsearchtextbox";
  private readonly string searchButton = "//*[@id='nav-search']/form/div[2]/div/input";

  //this test action is a collection of class methods
  public AmazonHome AmazonSearch(string searchDept, string searchString)
  {
   try
   {
    AmazonNavigate();
    SelectDepartment(searchDept);
    EnterSearchCriteria(searchString);
    ClickSearch();
   }
   catch (Exception e)
   {
    Console.WriteLine("Encountered an error during item search. Stack trace = " + e.Message);
   }
   return this;
  }

  //navigate to Amazon URL
  public AmazonHome AmazonNavigate()
  {
   try
   {
    driver.Navigate().GoToUrl(amazonUrl);
   }
   catch (Exception e)
   {
    Console.WriteLine("Encountered a navigation error. Stack trace = " + e.Message);
   }
   return this;
  }

  //select by text in dropdown
  public AmazonHome SelectDepartment(string selectText)
  {
   try
   {
    //create a SelectElement and locate dropdown item by text
    SelectElement deptSelect = new SelectElement(driver.FindElement(By.Id((searchDropdown))));
    deptSelect.SelectByText(selectText);
   }
   catch (Exception e)
   {
    Console.WriteLine("Encountered an error when trying to access dropdown. Stack trace = " + e.Message);
   }
   return this;
  }

  //enters text into search textbox
  public AmazonHome EnterSearchCriteria(string searchText)
  {
   driver.FindElement(By.Id(searchTextbox)).SendKeys(searchText);
   return this;
  }

  //clicks search button
  public AmazonHome ClickSearch()
  {
   driver.FindElement(By.XPath(searchButton)).Click();
   return this;
  }
 }
} 