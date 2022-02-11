In this example we are going to perform a search on Amazon and navigate to the second page of search results.  First create two page classes.  One is for the home page (AmazonHome.cs), and the other is for the search results page (AmazonResults.cs).
In the Program.cs we will create instances of these PageObject classes and execute the search workflow.
First you should see a browser launch and do a search on Amazon.
Then you should see the Next Page button get clicked and proceed to the second page of search results.
At the end of the test, the browser should close itself.

Note that some of web element types were handled differently:
SelectElement deptSelect = new SelectElement(driver.FindElement(By.Id((searchDropdown))));
deptSelect.SelectByText(selectText);

We handled the dropdown by creating a SelectElement object.  Then we selected a specific item in the dropdown using the text property of the dropdown.

Also, we introduced the concept of a test action.  A call to the AmazonSearch function performs four consecutive actions:
// 1) Navigates to the Amazon home page
    AmazonNavigate();
    // 2) Selects the search category in the dropdown
    SelectDepartment(searchDept);
    // 3) Enters the search text
    EnterSearchCriteria(searchString);
    // 4) Clicks the search button
    ClickSearch();

Selenium itself is only a set of tools, you will need to code your tests using a test framework and an IDE.  

Step 1.  Download a Visual Studio IDE if you don’t already have one.  Microsoft offers many different versions of Visual Studio.
Step 2.  Create a new C# console app and name the solution “SeleniumDemo”
Step 3.  Get the latest Selenium DLL’s from: https://sites.google.com/a/chromium.org/chromedriver/
Step 4.  Get the latest version of chromedriver from: https://sites.google.com/a/chromium.org/chromedriver/
Step 5.  Add project references pointing to the Selenium DLL’s
Step 6.  Use the Program class to create a simple self-contained browser test
Step 7.  Build and run.

You should see a new browser launch and attempt to login using a bogus ID/PW combo.

This script utilized Selenium functions called WebDriverWait and By.

In the code sample below, WebDriver will wait until a certain condition is met or until a timeout occurs.  If you get a timeout, WebDriver will throw an exception.

WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(myTimeout));
wait.Until(ExpectedConditions.ElementExists(By.Id("navbar-login-link")));

WebDriver finds the login web element using an ID locator:

driver.FindElement(By.Id("navbar-login-link")).Click();

Elsewhere in the script, XPath was used as a locator instead of ID.