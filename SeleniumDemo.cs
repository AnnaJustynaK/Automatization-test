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
   string myTestUrl = "https://wordpress.com";
   string myId = "mynameisfred";
   string myPw= "fredflintstone";
   int myTimeout = 10;

   //set chromedriver options
   var options = new ChromeOptions();
   //this will get rid of the yellow warning bar
   options.AddArguments("test-type");
   //this will maximize the browser
   options.AddArgument("--start-maximized");
   //this creates a new chromedriver instance
   IWebDriver driver = new ChromeDriver(@"C:\chromedriver", options);

   try
   {
    //navigate to URL
    driver.Navigate().GoToUrl(myTestUrl);
    //wait for login link to appear
    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(myTimeout));
    wait.Until(ExpectedConditions.ElementExists(By.Id("navbar-login-link")));
    //click login link
    driver.FindElement(By.Id("navbar-login-link")).Click();
    //enter ID and PW
    driver.FindElement(By.XPath("//*[@id='user_login']")).SendKeys(myId);
    driver.FindElement(By.XPath("//*[@id='user_pass']")).SendKeys(myPw);
    //click button
    driver.FindElement(By.Id("wp-submit")).Click();
   }
   catch (Exception e)
   {
    Console.WriteLine("Encountered an unforeseen error. Stack trace = " + e.Message);
   }
  }
 }
}