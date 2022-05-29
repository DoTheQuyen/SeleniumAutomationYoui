using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using SeleniumAutomationYoui.Report;
namespace SeleniumAutomationYoui.Testcases
{
    class SearchBook
    {
        /// <summary>
        /// reference global variables
        /// </summary>
        private static IWebDriver driver => Tests.GetDriver();
        private static string url => Tests.GetUrl();

        /// <summary>
        /// Init contructor with Chrome environment
        /// </summary>
        public SearchBook()
        {
            
        }

        /// <summary>
        /// Function to search for a book name
        /// </summary>
        /// <param name="bookName">name of the book to search for</param>
        public void SearchBookName(string bookName)
        {
            //write log new testcase
            Report.Report.NewTestCase("Search Book.");

            try
            {
                // step 1: Load page, and find search textbox
                Report.Report.WriteLog(0, "Open Demo Web Shop successfully. Start searching for a book.");

                //step 2: click on Register href to redirect to register page
                driver.FindElement(By.Id("small-searchterms")).SendKeys(bookName);
                Report.Report.WriteLog(1, "Located search textbox. Filled in search details");
               
                //step 3: Click search button
                driver.FindElement(By.ClassName("search-box-button")).Click();
                Report.Report.WriteLog(1, "Clicked search button to search for a book name: " + bookName);
                //wait for up to 20 seconds to return result
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                //step 4: Expect some books result.
                var result = driver.FindElement(By.ClassName("product-item")).Displayed;
                if(result)
                    Report.Report.WriteLog(1, "Search completed. There are some books name " + bookName);
                else
                    Report.Report.WriteLog(1, "Search completed. There is no book name " + bookName);

                Report.Report.WriteLog(1, "Testcase completed.");

            }
            catch (NotFoundException nEx)
            {
                Report.Report.WriteLog(2, "Test case can not locate element at " + nEx);
            }
            catch (TimeoutException tEx)
            {
                Report.Report.WriteLog(2, "Test case timeout at " + tEx);
            }
            catch (Exception ex)
            {
                Report.Report.WriteLog(2, "Test case failed at " + ex);
            }
        }

    }
}
